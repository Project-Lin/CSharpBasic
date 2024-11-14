using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static Exercise4.PlayerClass;

namespace Exercise4
{

    internal class Attack
    {
        int attackTarget = -1;
        string targetName = null;
        Random ram = new Random();
        Monster monster = new Monster();
        Player player = new Player();

        public void NormalAttack() 
        {
            
            if (attackTarget != -1)
            {
                int dice = ram.Next(0, 20);
                if (dice == 0)
                {
                    Console.WriteLine("大失敗，未命中");
                    Console.WriteLine($"{monster.GetName(attackTarget)}對你搖了搖屁股\n");
                }
                else if (dice > 0 && dice < 10)
                {
                    DealDamage(player.Damage + (dice * 2));
                }
                else
                {
                    Console.WriteLine("大成功，爆擊!!");
                    DealDamage(2 * (player.Damage + dice));
                }
                if (monster.Hp[attackTarget] <= 0)
                {
                    DefeatMonster(attackTarget);
                    attackTarget = -1;
                }
            }
            else
            {
                Console.WriteLine("請先選擇攻擊目標");
            }
        }
        public void SelectAttackTarget()
        {
            Console.WriteLine($"[1]{monster.Name[0]} [2]{monster.Name[1]} [3]{monster.Name[2]} [4]{monster.Name[3]} [5]{monster.Name[4]}");
            string Anser = Console.ReadLine();
            if (Anser == "1" && !monster.IsDead[0])
            {
                Console.WriteLine($"{monster.Name[0]}\n血量:{monster.Hp[0]}/{monster.HpMax[0]}\n掉落經驗值:{monster.Exp[0]}");
                attackTarget = 0;
            }
            else if (Anser == "2" && !monster.IsDead[1])
            {
                Console.WriteLine($"{monster.Name[1]}\n血量:{monster.Hp[1]}/{monster.HpMax[1]}\n掉落經驗值:{monster.Exp[1]}");
                attackTarget = 1;
            }
            else if (Anser == "3" && !monster.IsDead[2])
            {
                Console.WriteLine($"{monster.Name[2]}\n血量:{monster.Hp[2]}/{monster.HpMax[2]}\n掉落經驗值:{monster.Exp[2]}");
                attackTarget = 2;
            }
            else if (Anser == "4" && !monster.IsDead[3])
            {
                Console.WriteLine($"{monster.Name[3]}\n血量:{monster.Hp[3]}/{monster.HpMax[3]}\n掉落經驗值:{monster.Exp[3]}");
                attackTarget = 3;
            }
            else if (Anser == "5" && !monster.IsDead[4])
            {
                Console.WriteLine($"{monster.Name[4]}\n血量:{monster.Hp[4]}/{monster.HpMax[4]}\n掉落經驗值:{monster.Exp[4]}");
                attackTarget = 4;
            }
            else
            {
                Console.WriteLine("請輸入正確指令");
            }
        }
        void DealDamage(int damage)
        {
            Console.WriteLine($"對{monster.Name[attackTarget]}造成了{damage}點傷害");
            if (damage > monster.Hp[attackTarget])
            {
                monster.Hp[attackTarget] = 0;
            }
            else
            {
                monster.Hp[attackTarget] -= damage;
                Console.WriteLine($"{monster.Name[attackTarget]}  血量:{monster.Hp[attackTarget]}/{monster.HpMax[attackTarget]}\n");
            }
        }

        public void DefeatMonster(int index)
        {
            Bag bag = new Bag();
            Console.WriteLine($"已擊敗{monster.Name[index]}\n");
            monster.IsDead[index] = true;
            int dice = ram.Next(0, 100);
            if (dice < 100)
            {
                Console.WriteLine("恭喜!!獲得一個炸彈\n");
                //bag[0] += 1;
                bag.AddToBag();
            }
            GainExperience(monster.Exp[index]);
        }

        public void GainExperience(int exp)
        {
            player.Exp += exp;
            if (player.Exp >= player.ExpMax)
            {
                LevelUp();
            }
            else
            {
                Console.WriteLine($"\n獲得經驗值:{exp}\n經驗值:{player.Exp}/{player.ExpMax}");
            }
        }

        void LevelUp()
        {
            player.Level++;
            player.Exp -= player.ExpMax;

            player.ShowLevelUpState();

            player.Str += player.Level;
            player.Int += player.Level;
            player.Luk += player.Level;
            player.Dex += player.Level;
            player.ExpMax = player.Level * 50 + player.Level;
        }

        public void UseBoom()
        {
            Bag bag = new Bag();
            if (attackTarget == -1)
            {
                Console.WriteLine("請先選擇攻擊目標");
            }
            else if (bag.CheckBoom())
            {
                Console.WriteLine($"使用炸彈，對{monster.Name[attackTarget]}造成了{3 * player.Damage}點傷害");
                bag.bag[0] -= 1;
                DealDamage(3 * player.Damage);
                if (monster.Hp[attackTarget] <= 0)
                {
                    DefeatMonster(attackTarget);
                    attackTarget = -1;
                }
            }
            else
            {
                Console.WriteLine("沒有炸彈可以使用");
            }
        }



    }
}
