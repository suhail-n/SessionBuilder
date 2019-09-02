using System;

namespace SessionBuilder.Client.Pages
{
    public class HomeView : PageModel
    {
        public HomeView() : base(2) { }
        public override void PrintMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine(
                @"Select a number from the menu:
                    0. Back
                    1. Load Sessions
                    2. Exit"
            );
            System.Console.Write("-> ");
        }
        public override void HandleInput(int option)
        {
            if (option == 1)
            {
                IPage sessions = new SessionsView();
                sessions.Load();
                this.PrintMenu();
            }
            if (option == 2)
            {
                System.Console.WriteLine("You chose option 2");
            }
            if (option == 3)
            {
                Environment.Exit(0);
            }

        }
    }
}