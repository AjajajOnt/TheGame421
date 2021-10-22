using System;

namespace TheGame421
{
    class Program
    {

        static void Main(string[] args)
        {
            int MenuChoice = 0;
            TheGame start = new TheGame();
            start.CreateShop();
            start.CreatePlayer();
            while (true)
            {
                Console.Clear();
                start.GraphicMeny();
                Console.Write("Enter Choice: ");
                try
                {
                    MenuChoice = int.Parse(Console.ReadLine());
                }
                catch(Exception)
                {
                    MenuChoice = 0;
                    Console.Clear();
                }
                switch (MenuChoice)
                {
                    
                    case 1:
                        start.GoAdventureChoice();
                        //start.Fight();

                        break;
                    case 2:
                        start.ShowPlayerInfo2();
                        break;
                    case 3:
                        start.ShopChoice();
                        break;
                    case 4:
                        start.ExitChoice();
                        break;
                    case 5:
                        start.GameLevels();
                        break;
                    default:
                        MenuChoice = 0;
                        break;




                }

        }
        }
    }
}
