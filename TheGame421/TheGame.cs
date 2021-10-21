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
        List<Player> Players = new List<Player>();
        public void CreatePlayer()
        {
            Player ThePlayer = new Player();
            Console.Write("Enter Player Name: ");
            ThePlayer.Name = Console.ReadLine();
            HCode = ThePlayer.GetHashCode();
            Players.Add(ThePlayer);
        }


        public void GameOver()
        {
            throw new System.NotImplementedException();
        }

        public void GoAdventureChoice()
        {
            throw new System.NotImplementedException();
        }

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void ShopChoice()
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public void ShowPlayerInfo()
        {

            for (int i = 0; i < Players.Count; i++)
            {
                Console.WriteLine(Players[i].Name);

            }



        }


        public void CreateMonster()
        {
            throw new System.NotImplementedException();
        }

        public void CreateBoss()
        {
            throw new System.NotImplementedException();
        }

        public void CreateLastBoss()
        {
            throw new System.NotImplementedException();
        }

        public void GrafiskMenu()
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
    }
}