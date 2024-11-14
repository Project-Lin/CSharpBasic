﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Exercise4.PlayerClass;

namespace Exercise4
{
    internal class Player
    {
        PlayerClass playerClass = new PlayerClass();
        Bag bag = new Bag();
        public string Name = null;
        public int Class, Level, Str, Int, Dex, Luk, Exp, ExpMax, attackTarget, Damage;
        public bool isSetClass = false;
        public Player()
        {
            Exp = 0;
            ExpMax = 150;
            attackTarget = -1;            
        }
        public void ShowState()
        {
            Console.WriteLine($"名稱:{Name}");
            Console.WriteLine($"職業:{playerClass.GetName(Class)}");
            Console.WriteLine($"等級:{Level}");

            Console.WriteLine("\n能力值");
            Console.WriteLine($"力量:{Str}");
            Console.WriteLine($"智力:{Int}");
            Console.WriteLine($"敏捷:{Dex}");
            Console.WriteLine($"幸運:{Luk}");

            Console.WriteLine($"\n經驗值{Exp}/{ExpMax}");

            Console.WriteLine("背包");
            bag.ShowBag();
            
        }

        public void CalculateDamage()
        {
            switch (Class)
            {
                case 0:
                    Damage = 10 * Str + 2 * Int + 3 * Dex + 2 * Luk;
                    break;
                case 1:
                    Damage = 3 * Str + 2 * Int + 7 * Dex + 2 * Luk;
                    break;
                case 2:
                    Damage = 4 * Str + 2 * Int + 3 * Dex + 6 * Luk;
                    break;
                case 3:
                    Damage = 1 * Str + 10 * Int + 1 * Dex + 1 * Luk;
                    break;
            }
        }

        public void ShowLevelUpState()
        {
            PlayerClass playerClass = new PlayerClass();
            Console.WriteLine("升級!!");
            Console.WriteLine($"\n名稱:{Name}");
            Console.WriteLine($"職業:{playerClass.GetName(Class)}");
            Console.WriteLine($"等級:{Level}");

            Console.WriteLine("\n能力值");
            Console.WriteLine($"力量:{Str}+{Level}");
            Console.WriteLine($"智力:{Int}+{Level}");
            Console.WriteLine($"敏捷:{Dex}+{Level}");
            Console.WriteLine($"幸運:{Luk}+{Level}");

            Console.WriteLine($"\n經驗值{Exp}/{ExpMax}");

        }

        public void SetName()
        {
            Console.WriteLine("歡迎來到地獄M\n請輸入您的姓名:");
            string Anser = Console.ReadLine();
            Name = Anser;
        }

        public void SetPlayerClass()
        {
            Console.WriteLine($"您好，勇者{GetName()}，請選擇您的職業\n1.戰士\n2.遊俠\n3.盜賊\n4.法師");
            string Anser = Console.ReadLine();
            if (Anser == "1")
            {
                SetClassStats((int)pClass.warrior);
            }
            else if (Anser == "2")
            {
                SetClassStats((int)pClass.ranger);
            }
            else if (Anser == "3")
            {
                SetClassStats((int)pClass.thief);
            }
            else if (Anser == "4")
            {
                SetClassStats((int)pClass.mage);
            }
            else
            {
                Console.WriteLine("已取消，返回選擇選單");
            }
        }

        public void SetClassStats(int classIndex)
        {


            playerClass.ShowAbility(classIndex);
            bool Anser = menu.Check();

            if (Anser)
            {
                classAbilitySet.Set(classIndex);
                CalculateDamage();
                isSetClass = true;
            }
        }

    }
}
