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
        int Choice= 0;
        int Chance = 0;
        string Input = "";
        List<Player> Players = new List<Player>();
        List<SpecificMonster> Monsters = new List<SpecificMonster>();
        List<Shop> Shops = new List<Shop>();

        internal void CreateShop()
        {
            Shop TheShop = new Shop();
            TheShop.AmuletOfStrength = true;
            TheShop.AmuletOfStrengthAmount = 5;
            TheShop.AmuletOfToughness = true;
            TheShop.AmuletOfToughnessAmount = 5;
            TheShop.Gold = 1000;
            TheShop.HealingPotion = true;
            TheShop.PotionAmount = 5;
            TheShop.HealingSword = true;
            Shops.Add(TheShop);

        }
        public void CreatePlayer()
        {
            Player ThePlayer = new Player();
            Console.Write("Enter Player Name: ");
            ThePlayer.Name = Console.ReadLine();
            ThePlayer.Health = 100;
            ThePlayer.MaxHealth = 100;
            ThePlayer.Level = 1;
            ThePlayer.Exp = 1;
            ThePlayer.MaxExpThisLevel = 12;
            ThePlayer.Gold = 10;
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
            Chance = Ran.Next(1, 100);
            if (Chance >= 90 )
            {
                Console.WriteLine("You see nothing but Grass");
                PressSomething();
            }
            else
            {
                Fight();
            }
            
        }

        public void PlayerAttack()
        {
            int damage = 0;
            var Ran = new Random();
            

            if (Players[0].HealingSword.Equals(true))
            {
                Players[0].Damage = Players[0].MaxHealth / 5;
                Players[0].Damage = (Players[0].Strength / 10 * Players[0].Damage) + Players[0].Damage;
                damage = Ran.Next(Players[0].Damage / 2, Players[0].Damage);
                Monsters[0].Health -= damage;
                Players[0].Health += damage / 2;
                if (Players[0].Health >= Players[0].MaxHealth)
                {
                    Players[0].Health = Players[0].MaxHealth;
                }
                RedDamageText(Players[0].Name, " Attacks ", Monsters[0].Name, " for ", damage.ToString(), " damage. Health Left: ", Monsters[0].Health.ToString(), "/", Monsters[0].MaxHealth.ToString());
                GreenHealText("Your sword heals you for ", (damage / 2).ToString() , " Health");
            }
            else
            {
                Players[0].Damage = Players[0].MaxHealth / 5;
                Players[0].Damage = (Players[0].Strength / 10 * Players[0].Damage) + Players[0].Damage;
                damage = Ran.Next(Players[0].Damage / 2, Players[0].Damage);
                Monsters[0].Health -= damage;
                if (Monsters[0].Health < 0)
                {
                    Monsters[0].Health = 0;
                }
                RedDamageText2(Players[0].Name, " Attacks ", Monsters[0].Name, " for ", damage.ToString(), " damage. Health Left: ", Monsters[0].Health.ToString(), "/", Monsters[0].MaxHealth.ToString());

            }
                

            

            
        }

        public void ShopChoice()
        {
            TextGrapics("Welcome to the shop");
            Console.WriteLine("         1. Buy items");
            Console.WriteLine("         2. Sell items");
            Console.WriteLine("         3. Exit");
            Console.Write("Enter your choice: ");
            Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    BuyStuff();
                    break;
                case 2:
                    SellStuff();
                    break;
            }

        }

        public void ExitChoice()
        {
            throw new System.NotImplementedException();
        }

        public void HealChoice()
        {
            TextGrapics("Old Priests Church");
            Console.WriteLine("1. Pay " + Players[0].Level * 4 + " to heal 30-60%");
            Console.WriteLine("2. Exit");
            Choice = int.Parse(Console.ReadLine());
            if (Choice == 1 && Players[0].Gold >= Players[0].Level * 4)
            {
                SpendGold(Players[0].Level * 4);
                HealUp();

            }
            else
            {
                Console.WriteLine("You don't have enough gold. Go kill some monsters.");
            }


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
                Console.WriteLine("      Name: " + Players[i].Name + "     Health: " + Players[i].Health + "/" + Players[i].MaxHealth + "     Gold: " + Players[i].Gold + "     Exp: " + Players[i].Exp + "/" + Players[i].MaxExpThisLevel  + "     Level: " + Players[i].Level);

            }



        }
        public void ShowPlayerInfo2()
        {
                  

            Console.WriteLine("* Name: "  + Players[0].Name);
            Console.WriteLine("* Level: " + Players[0].Level);
            Console.WriteLine("* Hp: " + Players[0].Health+"/"+ Players[0].MaxHealth);
            Console.WriteLine("* Exp: " + Players[0].Exp+ "/" + Players[0].MaxExpThisLevel);
            Console.WriteLine("* Gold: " + Players[0].Gold);
            Console.WriteLine("* Strength: " + Players[0].Strength);
            Console.WriteLine("* Toughness: " + Players[0].Toughness);

            PressSomething();

        }
        public void CreateEliteMonster(string MonsterName)
        {
            SpecificMonster NewMonster = new SpecificMonster();
            var Ran = new Random();
            NewMonster.Name = MonsterName;
            NewMonster.Health = Players[0].MaxHealth / 2;
            NewMonster.MaxHealth = NewMonster.Health;
            NewMonster.Gold = Ran.Next(Players[0].Level + 100, Players[0].Level + 200);
            NewMonster.Exp = Ran.Next(Players[0].Level + 6, Players[0].Level + 10);
            NewMonster.EliteMonster = true;
            Monsters.Add(NewMonster);
        }

        public void CreateMonster(string MonsterName)
        {
            SpecificMonster NewMonster = new SpecificMonster();
            var Ran = new Random();
            NewMonster.Name = MonsterName;
            NewMonster.Health = Players[0].MaxHealth / 3;
            NewMonster.MaxHealth = NewMonster.Health;
            NewMonster.Gold = Ran.Next(Players[0].Level + 25, Players[0].Level + 50);
            NewMonster.Exp = Ran.Next(Players[0].Level + 3, Players[0].Level + 7);
            NewMonster.Monster = true;
            Monsters.Add(NewMonster);
        }

        public void CreateLastBoss(string MonsterName)
        {
            SpecificMonster NewMonster = new SpecificMonster();
            var Ran = new Random();
            NewMonster.Name = MonsterName;
            NewMonster.Health = Players[0].MaxHealth * 2;
            NewMonster.MaxHealth = NewMonster.Health;
            NewMonster.LastBoss = true;
            NewMonster.Gold = Ran.Next(1000);
            NewMonster.Exp = Ran.Next(1000);
            Monsters.Add(NewMonster);
        }

        public void GraphicMeny()
        {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                        1.    Go Adventuring                       |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                        2.    Show details about your character    |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                        3.    Go to Shop                           |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                        4.    Heal                                 |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("*|                        5.    Exit                                 |*");
            Console.WriteLine("*|                                                                   |*");
            Console.WriteLine("***********************************************************************");
            ShowPlayerInfo();
        }

        public string SpawnMonsterOrEliteOrBoss()
        {
            String MorphedName = "";
            var Ran = new Random();
            int RandomNumber = Ran.Next(1, 100);
            int RandomName = Ran.Next(1, 6);



            if(RandomNumber >= 70 && Players[0].Level >= 4 && Players[0].Level < 9)
            {
                MorphedName += "Elite ";
                MorphedName = RandomeNames(RandomName, MorphedName);
                CreateEliteMonster(MorphedName);
                Monsters[0].EliteMonster = true;
            }
            else if (Players[0].Level == 9)
            {
                MorphedName += "Boss ";
                MorphedName = RandomeNames(RandomName, MorphedName);
                CreateLastBoss(MorphedName);
            }
            else       
            {
                    MorphedName = RandomeNames(RandomName, MorphedName);
                    CreateMonster(MorphedName);

                
            }

            return MorphedName;

        }

        private static string RandomeNames(int RandomName, string MorphedName)
        {
            switch (RandomName)
            {
                case 1:
                    MorphedName += "Snake";
                    break;
                case 2:
                    MorphedName += "Skeleton";
                    break;
                case 3:
                    MorphedName += "Knight";
                    break;
                case 4:
                    MorphedName += "Soldier";
                    break;
                case 5:
                    MorphedName += "Bear";
                    break;
                case 6:
                    MorphedName += "Tiger";
                    break;
                default:
                    break;
            }

            return MorphedName;
        }

        public void Fight()
        {
            Console.Clear();
            var ran = new Random();
            SpawnMonsterOrEliteOrBoss();
            GameLevels();
            Console.WriteLine(Monsters[0].Name + " Has appeared " + "with healthamount: " + Monsters[0].Health);
            while (Monsters[0].Health > 0 && Players[0].Health > 0)
            {
                if (Monsters[0].Health > 0)
                {
                    MonsterAttack();
                    
                    if (Monsters[0].Health > 0)
                    {
                        PlayerAttack();

                    }
                    PressSomething();
                }
            }
            if (Monsters[0].Health <= 0 && Players[0].Health > 0)
            {
                GreenBGWithBlueText(Monsters[0].Name + " Has died. You won the battle");
            }
            if (Players[0].Health > 0)
            {
                Players[0].Gold += Monsters[0].Gold;
                Players[0].Exp += Monsters[0].Exp;
            }
            else
            {
                Players.Remove(Players[0]);
                Console.Clear();
                Console.WriteLine("You died and lost the game.");
                CreatePlayer();
            }
            if(Players)

            
            LevelUp();
            PressSomething();
            Monsters.Remove(Monsters[0]);
        }

        public void LevelUp()
        {
            
            if (Players[0].Exp >= Players[0].MaxExpThisLevel)
            {
                Players[0].Exp %= Players[0].MaxExpThisLevel;
                Players[0].MaxExpThisLevel += 5;
                Players[0].Level++;
                Players[0].MaxHealth += 25;
                Players[0].Health = Players[0].MaxHealth;
                WhiteBGWithBlackText("You leveled up and are now level " + Players[0].Level);
            }
            
        }

        private void WhiteBGWithBlackText(string Text)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(Text);
            Console.ResetColor();
            PressSomething();
        }
        private void GreenBGWithBlueText(string Text)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Text);
            Console.ResetColor();
            
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
            if (Shops[0].AmuletOfStrength.Equals(true) && Shops[0].AmuletOfStrengthAmount >= 1)
            {
                Console.WriteLine("    1. Amulet Of Strength.  " + Shops[0].AmuletOfStrengthAmount + " Left.  Price: 100");
            }
            if (Shops[0].AmuletOfToughness.Equals(true) && Shops[0].AmuletOfToughnessAmount >= 1)
            {
                Console.WriteLine("    2. Amulet Of Toughness. " + Shops[0].AmuletOfToughnessAmount + " Left.  Price: 100");
            }
                    
            if (Shops[0].HealingSword.Equals(true))
            {
                Console.WriteLine("    3. Healing Sword.                Price: 100");
            }
                Console.WriteLine("    4. Exit");
            Console.WriteLine("             Shop Gold: " + Shops[0].Gold);
            Console.Write("Enter item number you wanna buy: ");
            Choice = int.Parse(Console.ReadLine());
            if (Choice == 1 && Shops[0].AmuletOfStrength.Equals(true) && Players[0].Gold >= 100)
            {
                Shops[0].AmuletOfStrengthAmount -= 1;

                if (Shops[0].AmuletOfStrengthAmount <= 0)
                {
                    Shops[0].AmuletOfStrength = false;
                }
                
                Players[0].AmuletOfStrength = true;
                Players[0].AmuletOfStrengthAmount += 1;
                Players[0].Strength += 5;
                Players[0].Gold -= 100;
                Shops[0].Gold += 100;

            }
            if (Choice == 2 && Shops[0].AmuletOfToughness.Equals(true) && Players[0].Gold >= 100)
            {
                Shops[0].AmuletOfToughnessAmount -= 1;

                if (Shops[0].AmuletOfToughnessAmount <= 0)
                {
                    Shops[0].AmuletOfToughness = false;
                }

                Players[0].AmuletOfToughness = true;
                Players[0].AmuletOfToughnessAmount += 1;
                Players[0].Toughness += 2;
                Players[0].Gold -= 100;
                Shops[0].Gold += 100;

            }

            if (Choice == 3 && Shops[0].HealingSword.Equals(true) && Players[0].Gold >= 100)
            {
                Shops[0].HealingSword = false;
                Players[0].HealingSword = true;
                Players[0].Gold -= 100;
                Shops[0].Gold += 100;


            }

        }

        public void SellStuff()
        {
            TextGrapics("What do you want to Sell?");
            if (Players[0].AmuletOfStrength.Equals(true) && Players[0].AmuletOfStrengthAmount >= 1)
            {
                Console.WriteLine("    1. Amulet Of Strength.  " + Players[0].AmuletOfStrengthAmount + " Left.  Price: 100");
            }
            if (Players[0].AmuletOfToughness.Equals(true) && Players[0].AmuletOfToughnessAmount >= 1)
            {
                Console.WriteLine("    2. Amulet Of Toughness. " + Players[0].AmuletOfToughnessAmount + " Left.  Price: 100");
            }
            if (Players[0].HealingSword.Equals(true))
            {
                Console.WriteLine("    3. Healing Sword.                Price: 100");
            }
                Console.WriteLine("    4. Exit");
            Console.WriteLine("             Shop Gold: " + Shops[0].Gold);
            Console.Write("Enter item number you wanna Sell: ");
            Choice = int.Parse(Console.ReadLine());
            if (Choice == 1 && Players[0].AmuletOfStrength.Equals(true) && Shops[0].Gold >= 100 && Players[0].AmuletOfStrengthAmount >= 1)
            {
                Players[0].AmuletOfStrengthAmount -= 1;

                if (Players[0].AmuletOfStrengthAmount <= 0)
                {
                    Players[0].AmuletOfStrength = false;
                }


                Players[0].Strength -= 5;
                Shops[0].AmuletOfStrength = true;
                Shops[0].AmuletOfStrengthAmount += 1;
                Shops[0].Gold -= 100;
                Players[0].Gold += 100;

            }
            if (Choice == 2 && Players[0].AmuletOfToughness.Equals(true) && Shops[0].Gold >= 100 && Players[0].AmuletOfToughnessAmount >= 1)
            {
                Players[0].AmuletOfToughnessAmount -= 1;

                if (Players[0].AmuletOfToughnessAmount <= 0)
                {
                    Players[0].AmuletOfToughness = false;
                }

                Players[0].Toughness -= 2;
                Shops[0].AmuletOfToughness = true;
                Shops[0].AmuletOfToughnessAmount += 1;
                Shops[0].Gold -= 100;
                Players[0].Gold += 100;

            }

            
            if (Choice == 3 && Players[0].HealingSword.Equals(true) && Shops[0].Gold >= 100)
            {
                Players[0].HealingSword = false;
                Shops[0].HealingSword = true;
                Shops[0].Gold -= 100;
                Players[0].Gold += 100;


            }

        }

        public void PressSomething()
        {
            Console.WriteLine("[Enter to continue.]");
            Console.ReadKey();
        }

        public void MonsterAttack()
        {
            int damage = 0;
            var Ran = new Random();

            if (Monsters[0].Monster.Equals(true))
            {
                Monsters[0].Damage = ((Players[0].MaxHealth / 6) + (Players[0].Level * 5) - ((Players[0].MaxHealth / 6) + (Players[0].Level * 5)) * (Players[0].Toughness / 10)) ;
            }
            else if (Monsters[0].EliteMonster.Equals(true))
            {
                Monsters[0].Damage = ( (Players[0].MaxHealth / 5) + (Players[0].Level * 6) - ((Players[0].MaxHealth / 5) + (Players[0].Level * 6)) * (Players[0].Toughness / 10));


            }
            else if (Monsters[0].LastBoss.Equals(true))
            {
                Monsters[0].Damage = ( (Players[0].MaxHealth / 3) - (Players[0].MaxHealth / 3) * (Players[0].Toughness / 10)) ;
                
            }
            damage = Ran.Next(Monsters[0].Damage / 3, Monsters[0].Damage);
            Players[0].Health -= damage;
            
            RedDamageText(Monsters[0].Name , " Attacks " ,  Players[0].Name , " for "  , damage.ToString() ,  " damage. Health Left: " ,  Players[0].Health.ToString(), "/", Players[0].MaxHealth.ToString());


        }

        public int SpendGold(int GoldAmount)
        {
            if (Players[0].Gold >= GoldAmount)
            {
                Players[0].Gold -= GoldAmount;
            }
            else
            {
                Console.WriteLine("You don't have enough gold. Go kill some monsters.");
            }

            return GoldAmount;
        }

        public void HealUp()
        {
            int HealingAmount = 0;
            var Ran = new Random();
            HealingAmount = Ran.Next(Convert.ToInt32(Players[0].MaxHealth * 0.3), Convert.ToInt32(Players[0].MaxHealth * 0.6));
            Players[0].Health += HealingAmount;
            if (Players[0].Health >= Players[0].MaxHealth)
            {
                Players[0].Health = Players[0].MaxHealth;
            }
            GreenBGWithBlueText("You healed for: " + HealingAmount.ToString() + " health and now have " + Players[0].Health + " health");
            PressSomething();
            
        }



        public void RedDamageText(string PlayerName1, string Text2, string MonsterName3, string Text4, string CText5, string Text6, string CText7, string Text8, string CText9)
        {
            if (Monsters[0].Monster.Equals(true))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(PlayerName1);
                Console.ResetColor();
                Console.Write(Text2);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(MonsterName3);
                Console.ResetColor();
                Console.Write(Text4);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(CText5);
                Console.ResetColor();
                Console.Write(Text6);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText7);
                Console.ResetColor();
                Console.Write(Text8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText9);
                Console.ResetColor();
                Console.WriteLine();

            }
            else if (Monsters[0].EliteMonster.Equals(true))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(PlayerName1);
                Console.ResetColor();
                Console.Write(Text2);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(MonsterName3);
                Console.ResetColor();
                Console.Write(Text4);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(CText5);
                Console.ResetColor();
                Console.Write(Text6);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText7);
                Console.ResetColor();
                Console.Write(Text8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText9);
                Console.ResetColor();
                Console.WriteLine();

            }
            else if (Monsters[0].LastBoss.Equals(true))
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(PlayerName1);
                Console.ResetColor();
                Console.Write(Text2);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(MonsterName3);
                Console.ResetColor();
                Console.Write(Text4);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(CText5);
                Console.ResetColor();
                Console.Write(Text6);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText7);
                Console.ResetColor();
                Console.Write(Text8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText9);
                Console.ResetColor();
                Console.WriteLine();

            }
            
            

        }
        public void RedDamageText2(string PlayerName1, string Text2, string MonsterName3, string Text4, string CText5, string Text6, string CText7, string Text8, string CText9)
        {
            if (Monsters[0].Monster.Equals(true))
            {

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(PlayerName1);
                Console.ResetColor();
                Console.Write(Text2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(MonsterName3);
                Console.ResetColor();
                Console.Write(Text4);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(CText5);
                Console.ResetColor();
                Console.Write(Text6);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText7);
                Console.ResetColor();
                Console.Write(Text8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText9);
                Console.ResetColor();
                Console.WriteLine();

            }
            else if (Monsters[0].EliteMonster.Equals(true))
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(PlayerName1);
                Console.ResetColor();
                Console.Write(Text2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(MonsterName3);
                Console.ResetColor();
                Console.Write(Text4);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(CText5);
                Console.ResetColor();
                Console.Write(Text6);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText7);
                Console.ResetColor();
                Console.Write(Text8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText9);
                Console.ResetColor();
                Console.WriteLine();

            }
            else if (Monsters[0].LastBoss.Equals(true))
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(PlayerName1);
                Console.ResetColor();
                Console.Write(Text2);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(MonsterName3);
                Console.ResetColor();
                Console.Write(Text4);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(CText5);
                Console.ResetColor();
                Console.Write(Text6);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText7);
                Console.ResetColor();
                Console.Write(Text8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CText9);
                Console.ResetColor();
                Console.WriteLine();

            }



        }

        public void GreenHealText(string Text, string CText, string Text2)
        {
            Console.Write(Text);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(CText);
            Console.ResetColor();
            Console.WriteLine(Text2);
        }
    }
}