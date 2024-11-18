namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitializeGame();
            while (!isQuit)
            {
                DisplayMenu();
                HandleUserInput();
            }
        }

        static string[] mName = new string[] { "史萊姆", "哥布林", "野豬騎士", "鱷魚", "飛龍" };
        static int[] mHp, mHpMax, mExp;
        static bool[] mIsDead;
        static string[] Class = new string[] { "戰士", "遊俠", "盜賊", "法師" };
        static string pName;
        static int pClass, pLevel, pStr, pInt, pDex, pLuk, pExp, pExpMax, attackTarget, pDamage;
        static int[] bag = new int[5] { 0, 0, 0, 0, 0 };
        static bool isQuit, isSetClass;
        static string Anser = null;
        static Random ram = new Random();

        static void InitializeGame()
        {
            mHp = new int[] { 100, 200, 300, 400, 500, 600 };
            mHpMax = new int[] { 100, 200, 300, 400, 500, 600 };
            mExp = new int[] { 10, 20, 30, 40, 50 };
            mIsDead = new bool[] { false, false, false, false, false };
            attackTarget = -1;
            pExpMax = 150;
            Console.WriteLine("歡迎來到地獄M\n請輸入您的姓名:");
            pName = Console.ReadLine();
            while (!isSetClass)
            {
                SetPlayerClass();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("[0]結束遊戲 [1]顯示玩家狀態 [2]選擇目標怪物 [3]攻擊 [4]使用炸彈 [5]重生怪物");
        }

        static void SetPlayerClass()
        {
            Console.WriteLine($"您好，勇者{pName}，請選擇您的職業\n1.戰士\n2.遊俠\n3.盜賊\n4.法師");
            Anser = Console.ReadLine();
            if (Anser == "1")
            {
                SetClassStats(0, 10, 1, 5, 2);
            }
            else if (Anser == "2")
            {
                SetClassStats(1, 5, 2, 10, 1);
            }
            else if (Anser == "3")
            {
                SetClassStats(2, 2, 1, 5, 10);
            }
            else if (Anser == "4")
            {
                SetClassStats(3, 1, 10, 4, 3);
            }
            else
            {
                Console.WriteLine("已取消，返回選擇選單");
            }
        }

        static void SetClassStats(int classIndex, int str, int intel, int dex, int luk)
        {
            pClass = classIndex;
            pStr = str;
            pInt = intel;
            pDex = dex;
            pLuk = luk;
            isSetClass = true;
            Console.WriteLine(
                $"{Class[classIndex]}:\n力量:{str}\n智力:{intel}\n敏捷:{dex}\n幸運:{luk}\n確定要選擇{Class[classIndex]}嗎?(Y/N)");
            string input = Console.ReadLine();
            if (input == "y" || input == "Y")
            {
                isSetClass = true;
            }
            else
            {
                Console.WriteLine("已取消，返回選擇選單");
                isSetClass = false;
            }
        }

        static void HandleUserInput()
        {
            Anser = Console.ReadLine();
            if (Anser == "0")
            {
                QuitGame();
            }
            else if (Anser == "1")
            {
                DisplayPlayerStatus();
            }
            else if (Anser == "2")
            {
                SelectAttackTarget();
            }
            else if (Anser == "3")
            {
                Attack();
            }
            else if (Anser == "4")
            {
                UseBoom();
            }
            else if (Anser == "5")
            {
                ReviveMonster();
            }
            else
            {
                Console.WriteLine("請輸入正確指令");
            }
        }

        static void QuitGame()
        {
            Console.WriteLine("將會遺失遊戲資料，確定要退出遊戲嗎?(Y/N)");
            Anser = Console.ReadLine();
            if (Anser == "y" || Anser == "Y")
            {
                isQuit = true;
            }
        }

        static void DisplayPlayerStatus()
        {
            Console.WriteLine(
                $"名稱:{pName}\n職業:{Class[pClass]}\n等級:{pLevel}\n\n能力值\n力量:{pStr}\n智力:{pInt}\n敏捷:{pDex}\n幸運:{pLuk}\n\n經驗值:{pExp}/{pExpMax}");
            Console.WriteLine("背包");
            Console.WriteLine(
                $"||{GetItemName(0)}||{GetItemName(1)}||{GetItemName(2)}||{GetItemName(3)}||{GetItemName(4)}||");
        }

        static string GetItemName(int position)
        {
            int item = bag[position];
            if (item == 0)
            {
                return "空";
            }
            else if (item == 1)
            {
                return "炸彈";
            }
            else
            {
                return "空";
            }
        }

        static void SelectAttackTarget()
        {
            Console.WriteLine($"[1]{mName[0]} [2]{mName[1]} [3]{mName[2]} [4]{mName[3]} [5]{mName[4]}");
            Anser = Console.ReadLine();
            if (Anser == "1" && !mIsDead[0])
            {
                Console.WriteLine($"{mName[0]}\n血量:{mHp[0]}/{mHpMax[0]}\n掉落經驗值:{mExp[0]}");
                attackTarget = 0;
            }
            else if (Anser == "2" && !mIsDead[1])
            {
                Console.WriteLine($"{mName[1]}\n血量:{mHp[1]}/{mHpMax[1]}\n掉落經驗值:{mExp[1]}");
                attackTarget = 1;
            }
            else if (Anser == "3" && !mIsDead[2])
            {
                Console.WriteLine($"{mName[2]}\n血量:{mHp[2]}/{mHpMax[2]}\n掉落經驗值:{mExp[2]}");
                attackTarget = 2;
            }
            else if (Anser == "4" && !mIsDead[3])
            {
                Console.WriteLine($"{mName[3]}\n血量:{mHp[3]}/{mHpMax[3]}\n掉落經驗值:{mExp[3]}");
                attackTarget = 3;
            }
            else if (Anser == "5" && !mIsDead[4])
            {
                Console.WriteLine($"{mName[4]}\n血量:{mHp[4]}/{mHpMax[4]}\n掉落經驗值:{mExp[4]}");
                attackTarget = 4;
            }
            else
            {
                Console.WriteLine("請輸入正確指令");
            }
        }

        static void Attack()
        {
            if (attackTarget != -1)
            {
                CalculateDamage();
                int dice = ram.Next(0, 20);
                if (dice == 0)
                {
                    Console.WriteLine("大失敗，未命中");
                    Console.WriteLine($"{mName[attackTarget]}對你搖了搖屁股\n");
                }
                else if (dice > 0 && dice < 10)
                {
                    DealDamage(pDamage + (dice * 2));
                }
                else
                {
                    Console.WriteLine("大成功，爆擊!!");
                    DealDamage(2 * (pDamage + dice));
                }

                if (mHp[attackTarget] <= 0)
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

        static void CalculateDamage()
        {
            switch (pClass)
            {
                case 0:
                    pDamage = 10 * pStr + 2 * pInt + 3 * pDex + 2 * pLuk;
                    break;
                case 1:
                    pDamage = 3 * pStr + 2 * pInt + 7 * pDex + 2 * pLuk;
                    break;
                case 2:
                    pDamage = 4 * pStr + 2 * pInt + 3 * pDex + 6 * pLuk;
                    break;
                case 3:
                    pDamage = 1 * pStr + 10 * pInt + 1 * pDex + 1 * pLuk;
                    break;
            }
        }

        static void DealDamage(int damage)
        {
            Console.WriteLine($"對{mName[attackTarget]}造成了{damage}點傷害");
            if (damage > mHp[attackTarget])
            {
                mHp[attackTarget] = 0;
            }
            else
            {
                mHp[attackTarget] -= damage;
                Console.WriteLine($"{mName[attackTarget]}  血量:{mHp[attackTarget]}/{mHpMax[attackTarget]}\n");
            }
        }

        static void DefeatMonster(int index)
        {
            Console.WriteLine($"已擊敗{mName[index]}\n");
            mIsDead[index] = true;
            int dice = ram.Next(0, 100);
            if (dice < 50)
            {
                Console.WriteLine("恭喜!!獲得一個炸彈\n");
                AddToBag();
            }

            GainExperience(mExp[index]);
        }

        static void AddToBag()
        {
            bool IsAdd = false;
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] == 0 && IsAdd == false)
                {
                    bag[i] = 1;
                    IsAdd = true;
                    break;
                }
            }

            if (IsAdd == false)
            {
                Console.WriteLine("背包已滿，炸彈已被丟棄");
            }
        }

        static void GainExperience(int exp)
        {
            pExp += exp;
            if (pExp >= pExpMax)
            {
                LevelUp();
            }
            else
            {
                Console.WriteLine($"\n獲得經驗值:{exp}\n經驗值:{pExp}/{pExpMax}");
            }
        }

        static void LevelUp()
        {
            pLevel++;
            pExp -= pExpMax;
            Console.WriteLine("升級!!");
            Console.WriteLine(
                $"名稱:{pName}\n職業:{Class[pClass]}\n等級:{pLevel}\n\n能力值\n力量:{pStr}+{pLevel}\n智力:{pInt}+{pLevel}\n敏捷:{pDex}+{pLevel}\n幸運:{pLuk}+{pLevel}\n\n經驗值:{pExp}/{pExpMax}");
            pStr += pLevel;
            pInt += pLevel;
            pLuk += pLevel;
            pDex += pLevel;
            pExpMax = pLevel * 50 + pLevel;
        }

        static void UseBoom()
        {
            if (attackTarget == -1)
            {
                Console.WriteLine("請先選擇攻擊目標");
            }
            else if (CheckBoom())
            {
                Console.WriteLine($"使用炸彈，對{mName[attackTarget]}造成了{3 * pDamage}點傷害");
                bag[0] -= 1;
                DealDamage(3 * pDamage);
                if (mHp[attackTarget] <= 0)
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

        static void ReviveMonster()
        {
            Console.WriteLine($"請選擇重生的目標:\n[1]{mName[0]} [2]{mName[1]} [3]{mName[2]} [4]{mName[3]} [5]{mName[4]}");
            Anser = Console.ReadLine();
            if (Anser == "1" && mIsDead[0])
            {
                mIsDead[0] = false;
                mHp[0] = mHpMax[0];
                Console.WriteLine($"{mName[0]}已成功重生");
            }
            else if (Anser == "2" && mIsDead[1])
            {
                mIsDead[1] = false;
                mHp[1] = mHpMax[1];
                Console.WriteLine($"{mName[1]}已成功重生");
            }
            else if (Anser == "3" && mIsDead[2])
            {
                mIsDead[2] = false;
                mHp[2] = mHpMax[2];
                Console.WriteLine($"{mName[2]}已成功重生");
            }
            else if (Anser == "4" && mIsDead[3])
            {
                mIsDead[3] = false;
                mHp[3] = mHpMax[3];
                Console.WriteLine($"{mName[3]}已成功重生");
            }
            else if (Anser == "5" && mIsDead[4])
            {
                mIsDead[4] = false;
                mHp[4] = mHpMax[4];
                Console.WriteLine($"{mName[4]}已成功重生");
            }
            else
            {
                Console.WriteLine($"{mName[int.Parse(Anser) - 1]}未死亡\n請選擇死亡的目標");
            }
        }

        static bool CheckBoom()
        {
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] == 1)
                {
                    bag[i] = 0;
                    return true;
                }
            }
            return false;
        }
    }
}