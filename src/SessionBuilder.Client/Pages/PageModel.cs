using System;

namespace SessionBuilder.Client.Pages
{
    public abstract class PageModel : IPage
    {
        private readonly int numOfOptions;
        public PageModel(int numOfOptions)
        {
            this.numOfOptions = numOfOptions;
        }
        public abstract void PrintMenu();
        public abstract void HandleInput(int option);
        public bool ValidateInput(string input)
        {
            int number;
            var res = int.TryParse(input, out number);
            if (res && (number >= 0 && number <= this.numOfOptions))
            {
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Input was invalid.");
                this.PrintMenu();
                return false;
            }
        }
        public void Load()
        {
            bool valid = false;
            String keyPressed;
            int input = int.MaxValue;
            this.PrintMenu();
            do
            {
                keyPressed = Console.ReadLine();
                valid = this.ValidateInput(keyPressed);
                if (valid)
                {
                    input = int.Parse(keyPressed);
                    this.HandleInput(input);
                }

            } while (input != 0);
        }
    }
}