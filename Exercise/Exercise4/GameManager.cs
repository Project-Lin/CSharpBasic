using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class GameManager
    {
        private static GameManager isInstance = null;

        private GameManager()
        {
        }

        public static GameManager Instance()
        {
            if (isInstance == null)
            {
                isInstance = new GameManager();
            }

            return isInstance;
        }

        Player player = new Player();
        Monster monster = new Monster();
        Menu menu = new Menu();
        Random ram = new Random();
        public bool isQuit = false;

        public void InitializeGame()
        {
            player.SetName();
            while (!player.isSetClass)
            {
                player.SetClass();
            }

            player.CalculateDamage();
        }

        public void QuitGame()
        {
            Console.WriteLine("將會遺失遊戲資料，確定要退出遊戲嗎?(Y/N)");
            string Anser = Console.ReadLine();
            if (Anser == "y" || Anser == "Y")
            {
                isQuit = true;
            }
        }

        public string GetPlayerName()
        {
            string name = player.Name;
            return name;
        }


        public void StartGame()
        {
            while (!isQuit)
            {
                menu.DisplayMenu();
                HandleUserInput();
            }
        }

        public void HandleUserInput()
        {
            string Anser = Console.ReadLine();
            if (Anser == "0")
            {
                QuitGame();
            }
            else if (Anser == "1")
            {
                player.ShowState(player.bag);
            }
            else if (Anser == "2")
            {
                SelectAttackTarget();
            }
            else if (Anser == "3")
            {
                NormalAttack();
            }
            else if (Anser == "4")
            {
                UseBoom();
            }
            else if (Anser == "5")
            {
                int reviveNumber = monster.ReviveMonster(monster);
                if (reviveNumber != -1)
                {
                    player.attackTarget = reviveNumber;
                    Console.WriteLine($"已將攻擊目標設定為{monster.Name[reviveNumber]}");
                }
            }
            else
            {
                Console.WriteLine("請輸入正確指令");
            }
        }

        public void SelectAttackTarget()
        {
            Console.WriteLine(
                $"[1]{monster.Name[0]} [2]{monster.Name[1]} [3]{monster.Name[2]} [4]{monster.Name[3]} [5]{monster.Name[4]}");
            string Anser = Console.ReadLine();
            if (Anser == "1")
            {
                CheckMonsterIsDead(0);
            }
            else if (Anser == "2")
            {
                CheckMonsterIsDead(1);
            }
            else if (Anser == "3")
            {
                CheckMonsterIsDead(2);
            }
            else if (Anser == "4")
            {
                CheckMonsterIsDead(3);
            }
            else if (Anser == "5")
            {
                CheckMonsterIsDead(4);
            }
            else
            {
                Console.WriteLine("請輸入正確指令");
            }
        }

        private void CheckMonsterIsDead(int number)
        {
            if (monster.IsDead[number])
            {
                Console.WriteLine($"{monster.Name[number]}已死亡");
            }
            else
            {
                Console.WriteLine(
                    $"{monster.Name[number]}\n血量:{monster.Hp[number]}/{monster.HpMax[number]}\n掉落經驗值:{monster.Exp[number]}");
                player.attackTarget = number;
            }
        }

        public void NormalAttack()
        {
            if (player.attackTarget != -1)
            {
                int dice = ram.Next(0, 20);
                if (dice == 0)
                {
                    Console.WriteLine("大失敗，未命中");
                    Console.WriteLine($"{monster.GetName(player.attackTarget)}對你搖了搖屁股\n");
                }
                else if (dice > 0 && dice < 19)
                {
                    DealDamage(player.damage + (dice * 2));
                }
                else
                {
                    Console.WriteLine("大成功，爆擊!!");
                    DealDamage(2 * (player.damage + dice));
                }

                if (monster.Hp[player.attackTarget] <= 0)
                {
                    DefeatMonster(player.attackTarget);
                    player.attackTarget = -1;
                }
            }
            else
            {
                Console.WriteLine("請先選擇攻擊目標");
            }
        }

        void DealDamage(int damage)
        {
            Console.WriteLine($"對{monster.Name[player.attackTarget]}造成了{damage}點傷害");
            if (damage > monster.Hp[player.attackTarget])
            {
                monster.Hp[player.attackTarget] = 0;
                // DefeatMonster(player.attackTarget);
            }
            else
            {
                monster.Hp[player.attackTarget] -= damage;
                Console.WriteLine(
                    $"{monster.Name[player.attackTarget]}  血量:{monster.Hp[player.attackTarget]}/{monster.HpMax[player.attackTarget]}\n");
            }
        }

        public void DefeatMonster(int index)
        {
            Bag bag = new Bag();
            Console.WriteLine($"已擊敗{monster.Name[index]}\n");
            monster.IsDead[index] = true;
            int dice = ram.Next(0, 100);
            if (dice < 50)
            {
                Console.WriteLine("恭喜!!獲得一個炸彈\n");
                player.bag.AddToBag();
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
            player.level++;
            player.Exp -= player.ExpMax;
            player.ability.str += player.level;
            player.ability.Int += player.level;
            player.ability.luk += player.level;
            player.ability.dex += player.level;
            player.ExpMax = player.level * 50 + player.ExpMax;
            player.ShowLevelUpState(2);
        }

        public void UseBoom()
        {
            if (player.attackTarget == -1)
            {
                Console.WriteLine("請先選擇攻擊目標");
            }
            else if (player.bag.CheckBoom())
            {
                Console.WriteLine($"使用炸彈，對{monster.Name[player.attackTarget]}造成了{3 * player.damage}點傷害");
                player.bag.bag[0] -= 1;
                DealDamage(3 * player.damage);
                if (monster.Hp[player.attackTarget] <= 0)
                {
                    DefeatMonster(player.attackTarget);
                    player.attackTarget = -1;
                }
            }
            else
            {
                Console.WriteLine("沒有炸彈可以使用");
            }
        }
    }
}