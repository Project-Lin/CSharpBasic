using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Exercise4.PlayerAbility;

namespace Exercise4
{
    internal class Player
    {
        public Bag bag = new Bag();
        public PlayerAbility ability = new PlayerAbility();
        public string Name = null;
        public int level, Exp, ExpMax, attackTarget, damage;
        public bool isSetClass = false;

        public Player()
        {
            level = 1;
            Exp = 0;
            ExpMax = 150;
            attackTarget = -1;
        }

        public void ShowState(Bag _bag)
        {
            ShowAbility();
            Console.WriteLine("\n背包");
            _bag.ShowBag();
        }

        public void ShowLevelUpState(int puls)
        {
            Console.WriteLine("升級!!");
            Console.WriteLine($"名稱:{Name}");
            Console.WriteLine($"職業:{ability.className}");
            Console.WriteLine($"等級:{level}");

            Console.WriteLine("\n能力值");
            Console.WriteLine($"力量:{ability.str}+{puls}");
            Console.WriteLine($"智力:{ability.Int}+{puls}");
            Console.WriteLine($"敏捷:{ability.dex}+{puls}");
            Console.WriteLine($"幸運:{ability.luk}+{puls}");

            Console.WriteLine($"\n經驗值{Exp}/{ExpMax}");
        }

        public void ShowAbility()
        {
            Console.WriteLine($"名稱:{Name}");
            Console.WriteLine($"職業:{ability.className}");
            Console.WriteLine($"等級:{level}");

            Console.WriteLine("\n能力值");
            Console.WriteLine($"力量:{ability.str}");
            Console.WriteLine($"智力:{ability.Int}");
            Console.WriteLine($"敏捷:{ability.dex}");
            Console.WriteLine($"幸運:{ability.luk}");

            Console.WriteLine($"\n經驗值{Exp}/{ExpMax}");
        }

        public void CalculateDamage()
        {
            switch (ability.classNumber)
            {
                case 0:
                    damage = 10 * ability.str + 2 * ability.Int + 3 * ability.dex + 2 * ability.luk;
                    break;
                case 1:
                    damage = 3 * ability.str + 2 * ability.Int + 7 * ability.dex + 2 * ability.luk;
                    break;
                case 2:
                    damage = 4 * ability.str + 2 * ability.Int + 3 * ability.dex + 6 * ability.luk;
                    break;
                case 3:
                    damage = 1 * ability.str + 10 * ability.Int + 1 * ability.dex + 1 * ability.luk;
                    break;
            }
        }


        public void SetName()
        {
            Console.WriteLine("歡迎來到地獄M\n請輸入您的姓名:");
            string Anser = Console.ReadLine();
            Name = Anser;
        }

        public void SetClass()
        {
            Console.WriteLine("請選擇職業");
            for (int i = 0; i < ClassAbilitySet.ClassName.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {ClassAbilitySet.ClassName[i]}");
            }

            string Anser = Console.ReadLine();
            if (Anser == "1")
            {
                ShowSelectClass(0);
                Confirm(0);
            }
            else if (Anser == "2")
            {
                ShowSelectClass(1);
                Confirm(1);
            }
            else if (Anser == "3")
            {
                ShowSelectClass(2);
                Confirm(2);
            }
            else if (Anser == "4")
            {
                ShowSelectClass(3);
                Confirm(3);
            }
            else
            {
                Console.WriteLine("請輸入正確指令");
            }
        }

        private void ShowSelectClass(int _classNumber)
        {
            Console.WriteLine($"{ClassAbilitySet.ClassName[_classNumber]}");
            Console.WriteLine("能力值");
            Console.WriteLine($"力量:{ClassAbilitySet.ClassStr[_classNumber]}");
            Console.WriteLine($"智力:{ClassAbilitySet.ClassInt[_classNumber]}");
            Console.WriteLine($"敏捷:{ClassAbilitySet.ClassDex[_classNumber]}");
            Console.WriteLine($"幸運:{ClassAbilitySet.ClassLuk[_classNumber]}");
        }

        private void Confirm(int _classNumber)
        {
            Console.WriteLine("確定要選擇這個職業嗎?(Y/N)");
            bool sayYes = Menu.CheckYesOrNo();
            if (sayYes)
            {
                CreatPlayerClass(_classNumber);
                isSetClass = true;
            }
        }

        private void CreatPlayerClass(int _classNumber)
        {
            ability = new PlayerAbility(_classNumber);
        }
    }
}