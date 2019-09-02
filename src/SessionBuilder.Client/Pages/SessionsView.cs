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
            System.Console.WriteLine(
                @"Select an Option from the menu:
                    0. Go Back
                    1. Exit"
            );
            System.Console.WriteLine(
                @"========================================
                SESSIONS
========================================"
            );
            System.Console.WriteLine($"Session for {this._sessionHandler.Speaker.Name}");
            // subheader get num of days till birthday
            System.Console.WriteLine($"Speakers Birthday in {this._sessionHandler.DaysUntillBirthday()} days");
            foreach (var session in this._sessionHandler.Speaker.Sessions)
            {
                System.Console.WriteLine("****************************************");
                // header
                // Title
                System.Console.WriteLine($"      {session.Title}    ");
                // the time range from start to finish
                System.Console.WriteLine($"     {this._sessionHandler.SessionStartEndTime(session)}        ");
                System.Console.WriteLine($"Submitted {session.SubmittedAt} ({this._sessionHandler.GetDaySinceSubmitted(session)} days ago)");
                System.Console.WriteLine($"{session.Abstract}");
                if (this._sessionHandler.SpeakerHasLaterSessions(session))
                {
                    System.Console.WriteLine("Speaker has one or more sessions after this");
                }
                else
                {
                    System.Console.WriteLine("Speaker has no more sessions after this");
                }
                if (this._sessionHandler.IsSessionOverlapping(session))
                {
                    var defaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Session is Overlapping");
                    Console.ForegroundColor = defaultColor;
                }
                var timeToNextSession = this._sessionHandler.TimeTillNextSession(session);
                if (timeToNextSession == null)
                {
                    System.Console.WriteLine("There are no upcoming sessions");
                }
                else
                {
                    System.Console.WriteLine($"Time till next session: {timeToNextSession.ToString()}");
                }

                System.Console.WriteLine("****************************************");
            }
        }


    }
}