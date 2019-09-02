using System.Linq;
using System;
using SessionBuilder.Core.DataAccess;
using SessionBuilder.Core.Models;

namespace SessionBuilder.Client.Pages
{
    public class SessionsView : PageModel
    {
        private SessionsHandler _sessionHandler;
        public SessionsView() : base(2)
        {
            this._sessionHandler = new SessionsHandler(new SpeakerInMemoryDao());
        }

        public override void HandleInput(int option)
        {
            if (option == 1)
            {
                Environment.Exit(0);
            }
        }

        public override void PrintMenu()
        {
            System.Console.Clear();
            Console.WriteLine(
                @"Select an Option from the menu:
                    0. Go Back
                    1. Exit"
            );
            Console.WriteLine(
                @"========================================
                SESSIONS
========================================"
            );
            Console.WriteLine($"Session for {this._sessionHandler.Speaker.Name}");
            // subheader get num of days till birthday
            Console.WriteLine($"Speakers Birthday in {this._sessionHandler.DaysUntillBirthday()} days");
            foreach (var session in this._sessionHandler.Speaker.Sessions)
            {
                Console.WriteLine("****************************************");
                // header
                // Title
                Console.WriteLine($"      {session.Title}    ");
                // the time range from start to finish
                Console.WriteLine($"     {this._sessionHandler.SessionStartEndTime(session)}        ");
                Console.WriteLine($"Submitted {session.SubmittedAt} ({this._sessionHandler.GetDaySinceSubmitted(session)} days ago)");
                Console.WriteLine($"{session.Abstract}");
                if (this._sessionHandler.SpeakerHasLaterSessions(session))
                {
                    Console.WriteLine("Speaker has one or more sessions after this");
                }
                else
                {
                    Console.WriteLine("Speaker has no more sessions after this");
                }
                if (this._sessionHandler.IsSessionOverlapping(session))
                {
                    var defaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Session is Overlapping");
                    Console.ForegroundColor = defaultColor;
                }
                var timeToNextSession = this._sessionHandler.TimeTillNextSession(session);
                if (timeToNextSession == null)
                {
                    Console.WriteLine("There are no upcoming sessions");
                }
                else
                {
                    Console.WriteLine($"Time till next session: {timeToNextSession.ToString()}");
                }

                Console.WriteLine("****************************************");
            }
        }


    }
}