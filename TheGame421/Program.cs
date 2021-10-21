using System;

namespace TheGame421
{
    class Program
    {
        static void Main(string[] args)
        {
            TheGame start = new TheGame();

            start.CreatePlayer();
            start.GrafiskMenu();
        }
    }
}
