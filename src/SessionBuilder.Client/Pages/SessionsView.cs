using System.Linq;
using System;
using SessionBuilder.Core.DataAccess;
using SessionBuilder.Core.Models;

namespace SessionBuilder.Client.Pages
{
    public class SessionsView : PageModel
    {
        private readonly SessionsHandler sessionHandler;
        public SessionsView() : base(2)
        {
            this.sessionHandler = new SessionsHandler(new SpeakerInMemoryDao());
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
            Console.WriteLine($"Session for {this.sessionHandler.Speaker.Name}");
            // subheader get num of days till birthday
            Console.WriteLine($"Speakers Birthday in {this.sessionHandler.DaysUntillBirthday()} days");
            foreach (var session in this.sessionHandler.Speaker.Sessions)
            {
                Console.WriteLine("****************************************");
                // header
                // Title
                Console.WriteLine($"      {session.Title}    ");
                // the time range from start to finish
                Console.WriteLine($"     {this.sessionHandler.SessionStartEndTime(session)}        ");
                Console.WriteLine($"Submitted {session.SubmittedAt} ({this.sessionHandler.GetDaySinceSubmitted(session)} days ago)");
                Console.WriteLine($"{session.Abstract}");
                if (this.sessionHandler.SpeakerHasLaterSessions(session))
                {
                    Console.WriteLine("Speaker has one or more sessions after this");
                }
                else
                {
                    Console.WriteLine("Speaker has no more sessions after this");
                }
                if (this.sessionHandler.IsSessionOverlapping(session))
                {
                    var defaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Session is Overlapping");
                    Console.ForegroundColor = defaultColor;
                }
                var timeToNextSession = this.sessionHandler.TimeTillNextSession(session);
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