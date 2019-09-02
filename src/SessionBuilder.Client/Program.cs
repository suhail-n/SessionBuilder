using System;
using SessionBuilder.Client.Pages;

namespace SessionBuilder.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Run(new HomeView());
            }
        }
        static void Run(IPage page)
        {
            page.Load();
        }
    }
}
