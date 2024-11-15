using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class Monster
    {
        public string[] Name = new string[] { "史萊姆", "哥布林", "野豬騎士", "鱷魚", "飛龍" };
        public int[] Hp, HpMax, Exp;
        public bool[] IsDead;

        public Monster()
        {
            Hp = new int[] { 100, 200, 300, 400, 500, 600 };
            HpMax = new int[] { 100, 200, 300, 400, 500, 600 };
            Exp = new int[] { 100, 20, 30, 40, 50 };
            IsDead = new bool[] { false, false, false, false, false };
        }

        public string GetName(int posision)
        {
            return Name[posision];
        }

        public int ReviveMonster(Monster _monster)
        {
            Console.WriteLine($"請選擇重生的目標:\n[1]{Name[0]} [2]{Name[1]} [3]{Name[2]} [4]{Name[3]} [5]{Name[4]}");
            string Anser = Console.ReadLine();
            if (Anser == "1" && IsDead[0])
            {
                SetValue(_monster, 0);
                return 0;
            }
            else if (Anser == "2" && IsDead[1])
            {
                SetValue(_monster, 1);
                return 1;
            }
            else if (Anser == "3" && IsDead[2])
            {
                SetValue(_monster, 2);
                return 2;
            }
            else if (Anser == "4" && IsDead[3])
            {
                SetValue(_monster, 3);
                return 3;
            }
            else if (Anser == "5" && IsDead[4])
            {
                SetValue(_monster, 4);
                return 4;
            }
            else
            {
                Console.WriteLine("目標未死亡\n請選擇死亡的目標");
                return -1;
            }
        }

        void SetValue(Monster _monster, int num)
        {
            _monster.IsDead[num] = false;
            _monster.Hp[num] = _monster.HpMax[num];
            Console.WriteLine($"{_monster.Name[num]}已成功重生");
        }
    }
}