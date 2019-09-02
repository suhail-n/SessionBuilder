using System;
using System.Linq;
using SessionBuilder.Core.DataAccess;
using SessionBuilder.Core.Models;

namespace SessionBuilder.Client.Pages
{
    public class SessionsHandler
    {
        private ISpeakerDao _speakerDao;
        public Speaker Speaker { get; }
        public SessionsHandler(ISpeakerDao speakerDao)
        {
            this._speakerDao = speakerDao;
            this.Speaker = speakerDao.FindAllSpeakers().First();
        }
        public bool IsSessionOverlapping(Session currentSession)
        {
            foreach (var session in this.Speaker.Sessions)
            {
                if (session.Id == currentSession.Id) continue;

                // check if currentSession start time is between session start and end time
                if (currentSession.SubmittedAt >= session.SubmittedAt && currentSession.SubmittedAt < session.SubmittedAt.Add(session.Length)) return true;

                // check if currenSession end time is between session start and end time by comparing if session start time is between current session start and end time.
                if (session.SubmittedAt >= currentSession.SubmittedAt && session.SubmittedAt < currentSession.SubmittedAt.Add(session.Length)) return true;
            }
            return false;
        }

        public int DaysUntillBirthday()
        {
            // use .Date to convert the UtcNow to this systems date to match the birthday format
            var today = DateTimeOffset.UtcNow.Date;
            // to avoid issues with Leap years, we start the day at 1 and then Add days to add the remainder
            var birthday = new DateTime(today.Year, this.Speaker.Birthday.Month, 1);
            birthday = birthday.AddDays(this.Speaker.Birthday.Day - 1);

            // if birthday ahs already passed then we should look into the next year. 
            // This is better than just converting a negative total days to positive 
            // since this way it accounts for special dates like leap years
            if (birthday < today)
            {
                birthday = new DateTime(today.Year + 1, this.Speaker.Birthday.Month, 1);
                birthday.AddDays(this.Speaker.Birthday.Day - 1);
            }
            return (int)(birthday - today).TotalDays;
        }

        public string SessionStartEndTime(Session session) => $"{session.ScheduledAt.ToString("hh:mm tt")} - {session.ScheduledAt.Add(session.Length).ToString("hh:mm tt")}";

        public int GetDaySinceSubmitted(Session session)
        {
            var today = DateTimeOffset.UtcNow;
            return (int)(today - session.SubmittedAt).TotalDays;
        }

        public bool SpeakerHasLaterSessions(Session session) => this.Speaker.Sessions.Any(sess => sess.Id != session.Id && sess.ScheduledAt > session.ScheduledAt);

        public TimeSpan? TimeTillNextSession(Session session)
        {
            var nextSession = this.Speaker.Sessions
                .OrderBy(sess => sess.ScheduledAt)
                .FirstOrDefault(sess => sess.Id != session.Id && sess.ScheduledAt > session.ScheduledAt);
            if (nextSession == null) return null;

            return nextSession.ScheduledAt - session.ScheduledAt.Add(session.Length);
        }

    }
}