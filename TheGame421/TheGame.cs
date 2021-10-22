﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TheGame421
{
    public class TheGame
    {
        int HCode = 0;
        string input = "";
        List<Player> Players = new List<Player>();
        List<Monster> Monsters = new List<Monster>();
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
            ThePlayer.Gold = 5;
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
            throw new System.NotImplementedException();
        }

        public int Attack()
        {
            int damage = 0;
            damage = 5;

            return damage;
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
            if(Players[0].Level >= 9)
            {
                TextGrapics("Game Level: Dead Kings Dungeon");
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
            CreateMonster();
            Console.WriteLine(Monsters[0].Name + "Has appeared " + "with healthamount: " + Monsters[0].Health);
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
            Console.WriteLine("*                     "   + text +       "                *");
            Console.WriteLine("***********************************************************");
        }
    }
}