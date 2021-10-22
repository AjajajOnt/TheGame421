using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TheGame421
{
    public class TheGame
    {
        
        int HCode = 0;
        int choice = 0;
        int chance = 0;
        string input = "";
        List<Player> Players = new List<Player>();
        List<Monster> Monsters = new List<Monster>();
        List<Shop> Shops = new List<Shop>();

        internal void CreateShop()
        {
            Shop TheShop = new Shop();
            TheShop.AmuletOfStrength = true;
            TheShop.AmuletOfToughness = true;
            TheShop.Gold = 500;
            TheShop.HealingPotion = true;
            TheShop.HealingSword = true;
            Shops.Add(TheShop);

        }
        public void CreatePlayer()
        {
            Player ThePlayer = new Player();
            // Console.Write("Enter Player Name: ");
            // ThePlayer.Name = Console.ReadLine();
            ThePlayer.Name = "MilkyJuicer";
            ThePlayer.Health = 100;
            ThePlayer.MaxHealth = 100;
            ThePlayer.Level = 1;
            ThePlayer.Exp = 1;
            ThePlayer.Gold = 500;
            HCode = ThePlayer.GetHashCode();
            Players.Add(ThePlayer);
            Console.Clear();
        }


        public void GameOver()
        {
            throw new System.NotImplementedException();
        }

        public void GoAdventureChoice()
        {
            var Ran = new Random();
            chance = Ran.Next(1, 100);
            if (chance >= 90 )
            {
                Console.WriteLine("Grass");
            }
            else
            {
                Fight();
            }
            
        }

        public int Attack()
        {
            int damage = 0;
            damage = 5;

            return damage;
        }

        public void ShopChoice()
        {
            TextGrapics("Welcome to the shop");
            BuyStuff();
        }

        public void ExitChoice()
        {
            throw new System.NotImplementedException();
        }

        public void HealChoice()
        {
            throw new System.NotImplementedException();
        }

        public void GameLevels()
        {
            if(Players[0].Level >= 9)
            {
                TextGrapics("Game Level: Dead Kings Dungeon");
            }
            else if (Players[0].Level >= 6)
            {
                TextGrapics("Game Level: Abandoned Castle");
            }
            else if (Players[0].Level >= 3)
            {
                TextGrapics("Game Level: Empty Gold Mine");
            }
            else 
            {
                TextGrapics("Game Level: Abandoned Town");

            }
        }

        public void ShowPlayerInfo()
        {

            for (int i = 0; i < Players.Count; i++)
            {
                Console.WriteLine("      Name: " + Players[i].Name + "     Health: " + Players[i].Health + "     Gold: " + Players[i].Gold + "     Exp: " + Players[i].Exp + "     Level: " + Players[i].Level);

            }



        }


        public void CreateMonster()
        {
            Monster NewMonster = new Monster();
            var Ran = new Random();
            NewMonster.Name = RandomName();
            NewMonster.Health = Players[0].MaxHealth / 3;
            NewMonster.Gold = Ran.Next(Players[0].Level, Players[0].Level + 3);
            NewMonster.Exp = Ran.Next(Players[0].Level + 3, Players[0].Level + 7);
            Monsters.Add(NewMonster);
        }

        public void CreateBoss()
        {
            throw new System.NotImplementedException();
        }

        public void CreateLastBoss()
        {
            throw new System.NotImplementedException();
        }

        public void GraphicMeny()
        {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                        1.    Go Adventure                         |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                        2.    Heal                                 |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                        3.    Shop                                 |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                        4.    Exit                                 |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("***********************************************************************");
            ShowPlayerInfo();
        }

        public string RandomName()
        {
            string Morphedname = "Mon-";
            var Ran = new Random();
            int RandomNumber = Ran.Next(100, 999);
            Morphedname += RandomNumber;
            return Morphedname;

        }

        public void Fight()
        {
            Console.Clear();
            CreateMonster();
            GameLevels();
            Console.WriteLine(Monsters[0].Name + " Has appeared " + "with healthamount: " + Monsters[0].Health);
            while (Monsters[0].Health > 0 && Players[0].Health > 0)
            {
                if (Monsters[0].Health > 0)
                {
                    Players[0].Health -= Attack();
                    Console.WriteLine(Players[0].Name + " Took a hit and Has " + Players[0].Health + " Left");
                    if (Players[0].Health > 0)
                    {
                        Monsters[0].Health -=  Attack();
                        Console.WriteLine(Monsters[0].Name + " Took a hit and Has " + Monsters[0].Health + " Left");

                    }
                }
            }
            if (Players[0].Health > 0)
            {
                Players[0].Gold += Monsters[0].Gold;
                Players[0].Exp += Monsters[0].Exp;
            }
            LevelUp();
            Monsters.Remove(Monsters[0]);
        }

        public void LevelUp()
        {
            if(Players[0].Exp >= 12)
            {
                Players[0].Exp %= 12;
                Players[0].Level++;
                Players[0].MaxHealth += 25;
                Players[0].Health = Players[0].MaxHealth;
            }
        }

        public void TextGrapics(string text)
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                     "   + text                            );
            Console.WriteLine("***********************************************************");
        }

        public void BuyStuff()
        {
            TextGrapics("What do you want to buy?");
            if (Shops[0].AmuletOfStrength.Equals(true))
            {
                Console.WriteLine("    1. Amulet Of Strength.   Price: 100");
            }
            if (Shops[0].AmuletOfToughness.Equals(true))
            {
                Console.WriteLine("    2. Amulet Of Toughness.  Price: 100");
            }
            if (Shops[0].HealingPotion.Equals(true))
            {
                Console.WriteLine("    3. Healing Sword.        Price: 100");
            }
            if (Shops[0].HealingSword.Equals(true))
            {
                Console.WriteLine("    4. Healing Potion.       Price: 100");
            }
            Console.WriteLine("             Shop Gold: " + Shops[0].Gold);
            Console.Write("Enter item number you wanna buy: ");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1 && Shops[0].AmuletOfStrength.Equals(true) && Players[0].Gold >= 100)
            {
                Shops[0].AmuletOfStrength = false;
                Players[0].AmuletOfStrength = true;
                Players[0].Gold -= 100;
                Shops[0].Gold += 100;

            }
            if (choice == 2 && Shops[0].AmuletOfToughness.Equals(true) && Players[0].Gold >= 100)
            {
                Shops[0].AmuletOfToughness = false;
                Players[0].AmuletOfToughness = true;
                Players[0].Gold -= 100;
                Shops[0].Gold += 100;

            }
            if (choice == 3 && Shops[0].HealingPotion.Equals(true) && Players[0].Gold >=100)
            {
                Shops[0].HealingPotion = false;
                Players[0].HealingPotion = true;
                Players[0].Gold -= 100;
                Shops[0].Gold += 100;

            }
            if (choice == 4 && Shops[0].HealingSword.Equals(true) && Players[0].Gold >= 100)
            {
                Shops[0].HealingSword = false;
                Players[0].HealingSword = true;
                Players[0].Gold -= 100;
                Shops[0].Gold += 100;


            }

        }

        public void SellStuff()
        {
            throw new System.NotImplementedException();
        }
    }
}