﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame421
{
    public class Player
    {
        public string Name { get; set; }


        public int Health { get; set; }

        public int Exp { get; set; }

        public int Level { get; set; }

        public int Gold { get; set; }

        public bool PlayerBool { get; set; }

        public bool AmuletOfStrength { get; set; }

        public bool AmuletOfToughness { get; set; }

        public bool HealingPotion { get; set; }

        public bool HealingSword { get; set; }

        public int Strength { get; set; }

        public int Toughness { get; set; }

        public bool Monster { get; set; }

        public bool Boss { get; set; }

        public int LastBoss { get; set; }

        public int PotionAmount { get; set; }

        public bool IsDead { get; set; }

        public bool GameLevel1 { get; set; }

        public bool GameLevel2 { get; set; }

        public bool GameLevel3 { get; set; }

        public bool GameLevel4 { get; set; }

        public int MaxHealth { get; set; }
        

        
    }
    }