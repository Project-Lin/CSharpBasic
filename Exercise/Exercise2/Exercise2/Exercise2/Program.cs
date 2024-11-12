namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] mName = new string[] { "史萊姆", "哥布林", "野豬騎士", "鱷魚", "飛龍" };
            int[] mHp = new int[] { 100, 200, 300, 400, 500, 600 };
            int[] mHpMax = new int[] { 100, 200, 300, 400, 500, 600 };
            int[] mExp = new int[] { 10, 20, 30, 40, 50 };
            bool[] mIsDead = new bool[] { false, false, false, false, false };
            string[] Class = new string[] { "戰士", "遊俠", "盜賊", "法師" };
            string pName = null;
            int pClass = 0;
            int pLevel = 1;
            int pStr = 0;
            int pInt = 0;
            int pDex = 0;
            int pLuk = 0;
            int pExp = 0;
            int pExpMax = 40;
            int attackTarget = -1;
            int pDamage = 10;
            int[] bag = new int[5] { 0, 0, 0, 0, 0 };
            bool isQuit = false;
            bool isSetClass = false;
            string Anser = null;
            Random ram = new Random();

            Console.WriteLine("歡迎來到地獄M\n請輸入您的姓名:");
            pName = Console.ReadLine();

            while (!isQuit)
            {
                while (!isSetClass)
                {
                    Console.WriteLine($"您好，勇者{pName}，請選擇您的職業\n1.戰士\n2.遊俠\n3.盜賊\n4.法師");
                    Anser = Console.ReadLine();
                    if (Anser == "1")
                    {
                        Console.WriteLine("戰士:\n力量:10\n智力:1\n敏捷:5\n幸運:2\n確定要選擇戰士嗎?(Y/N)");

                        string input = Console.ReadLine();
                        if (input == "y" || input == "Y")
                        {
                            pClass = 0;
                            pStr = 10;
                            pInt = 1;
                            pDex = 5;
                            pLuk = 2;
                            isSetClass = true;
                        }
                        else
                        {
                            Console.WriteLine("已取消，返回選擇選單");
                        }
                    }
                    else if (Anser == "2")
                    {
                        Console.WriteLine("遊俠:\n力量:5\n智力:2\n敏捷:10\n幸運:1\n確定要選擇遊俠嗎?(Y/N)");

                        string input = Console.ReadLine();
                        if (input == "y" || input == "Y")
                        {
                            pClass = 1;
                            pStr = 5;
                            pInt = 2;
                            pDex = 10;
                            pLuk = 1;
                            isSetClass = true;
                        }
                        else
                        {
                            Console.WriteLine("已取消，返回選擇選單");
                        }
                    }
                    else if (Anser == "3")
                    {
                        Console.WriteLine("盜賊:\n力量:2\n智力:1\n敏捷:5\n幸運:10\n確定要選擇盜賊嗎?(Y/N)");

                        string input = Console.ReadLine();
                        if (input == "y" || input == "Y")
                        {
                            pClass = 2;
                            pStr = 2;
                            pInt = 1;
                            pDex = 5;
                            pLuk = 10;
                            isSetClass = true;
                        }
                        else
                        {
                            Console.WriteLine("已取消，返回選擇選單");
                        }
                    }

                    else if (Anser == "4")
                    {
                        Console.WriteLine("法師:\n力量:1\n智力:10\n敏捷:4\n幸運:3\n確定要選擇法師嗎?(Y/N)");

                        string input = Console.ReadLine();
                        if (input == "y" || input == "Y")
                        {
                            pClass = 3;
                            pStr = 1;
                            pInt = 10;
                            pDex = 4;
                            pLuk = 3;
                            isSetClass = true;
                        }
                        else
                        {
                            Console.WriteLine("已取消，返回選擇選單");
                        }
                    }
                }

                Console.WriteLine("[0]結束遊戲 [1]顯示玩家狀態 [2]選擇目標怪物 [3]攻擊 [4]使用炸彈 [5]重生怪物");

                //傷害計算
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

                Anser = Console.ReadLine();
                if (Anser == "0")
                {
                    Console.WriteLine("將會遺失遊戲資料，確定要退出遊戲嗎?(Y/N)");
                    Anser = Console.ReadLine();
                    if (Anser == "y" || Anser == "Y")
                    {
                        isQuit = true;
                    }
                }
                else if (Anser == "1")
                {
                    Console.WriteLine($"名稱:{pName}\n職業:{Class[pClass]}\n等級:{pLevel}\n\n能力值\n力量:{pStr}\n智力:{pInt}\n敏捷:{pDex}\n幸運:{pLuk}\n\n經驗值:{pExp}/{pExpMax}");
                    //Console.WriteLine("\n背包");
                }
                else if (Anser == "2")
                {
                    Console.WriteLine($"[1]{mName[0]} [2]{mName[1]} [3]{mName[2]} [4]{mName[3]} [5]{mName[4]}");
                    Anser = Console.ReadLine();
                    if (Anser == "1")
                    {
                        if (mIsDead[0])
                        {
                            Console.WriteLine($"{mName[0]}已死亡，請選擇其他怪物或使用重生功能");
                            continue;
                        }
                        Console.WriteLine($"{mName[0]}\n血量:{mHp[0]}/{mHpMax[0]}\n掉落經驗值:{mExp[0]}");
                        attackTarget = 0;
                    }
                    else if (Anser == "2")
                    {
                        if (mIsDead[1])
                        {
                            Console.WriteLine($"{mName[1]}已死亡，請選擇其他怪物或使用重生功能");
                            continue;
                        }
                        Console.WriteLine($"{mName[1]}\n血量:{mHp[1]}/{mHpMax[1]}\n掉落經驗值:{mExp[1]}");
                        attackTarget = 1;
                    }
                    else if (Anser == "3")
                    {
                        if (mIsDead[2])
                        {
                            Console.WriteLine($"{mName[2]}已死亡，請選擇其他怪物或使用重生功能");
                            continue;
                        }
                        Console.WriteLine($"{mName[2]}\n血量:{mHp[2]}/{mHpMax[2]}\n掉落經驗值:{mExp[2]}");
                        attackTarget = 2;
                    }
                    else if (Anser == "4")
                    {
                        if (mIsDead[3])
                        {
                            Console.WriteLine($"{mName[3]}已死亡，請選擇其他怪物或使用重生功能");
                            continue;
                        }
                        Console.WriteLine($"{mName[3]}\n血量:{mHp[3]}/{mHpMax[3]}\n掉落經驗值:{mExp[3]}");
                        attackTarget = 3;
                    }
                    else if (Anser == "5")
                    {
                        if (mIsDead[4])
                        {
                            Console.WriteLine($"{mName[4]}已死亡，請選擇其他怪物或使用重生功能");
                            continue;
                        }
                        Console.WriteLine($"{mName[4]}\n血量:{mHp[4]}/{mHpMax[4]}\n掉落經驗值:{mExp[4]}");
                        attackTarget = 4;
                    }
                    else
                    {
                        Console.WriteLine("請輸入正確指令");
                    }

                }
                else if (Anser == "3")
                {
                    if (attackTarget != -1)
                    {

                        int dice = ram.Next(0, 20);
                        if (dice == 0)
                        {
                            Console.WriteLine("大失敗，未命中");
                            Console.WriteLine($"{mName[attackTarget]}對你搖了搖屁股\n");
                        }
                        else if (dice > 0 && dice < 10)
                        {
                            Console.WriteLine($"對{mName[attackTarget]}造成了{pDamage + (dice * 2)}點傷害");
                            if (pDamage + (dice * 2) > mHp[attackTarget])
                            {
                                mHp[attackTarget] = 0;
                            }
                            else
                            {
                                mHp[attackTarget] -= pDamage + (dice * 2);
                                Console.WriteLine($"{mName[attackTarget]}  血量:{mHp[attackTarget]}/{mHpMax[attackTarget]}\n");
                            }


                        }
                        else
                        {
                            Console.WriteLine("大成功，爆擊!!");
                            Console.WriteLine($"對{mName[attackTarget]}造成了{2 * (pDamage + dice)}點傷害");
                            if (2 * (pDamage + dice) > mHp[attackTarget])
                            {
                                mHp[attackTarget] = 0;
                            }
                            else
                            {
                                mHp[attackTarget] -= 2 * (pDamage + dice);
                                Console.WriteLine($"{mName[attackTarget]}  血量:{mHp[attackTarget]}/{mHpMax[attackTarget]}\n");
                            }

                        }
                        if (mHp[attackTarget] <= 0)
                        {
                            Console.WriteLine($"已擊敗{mName[attackTarget]}\n");
                            mIsDead[attackTarget] = true;

                            dice = ram.Next(0, 100);
                            if (dice < 50)
                            {
                                Console.WriteLine("恭喜!!獲得一個炸彈\n");
                                bag[0] += 1;
                            }

                            pExp += mExp[attackTarget];
                            if (pExp >= pExpMax)
                            {
                                pLevel++;
                                pExp -= pExpMax;
                                Console.WriteLine("升級!!");
                                Console.WriteLine($"名稱:{pName}\n職業:{Class[pClass]}\n等級:{pLevel}\n\n能力值\n力量:{pStr}+{pLevel}\n智力:{pInt}+{pLevel}\n敏捷:{pDex}+{pLevel}\n幸運:{pLuk}+{pLevel}\n\n經驗值:{pExp}/{pExpMax}");
                                pStr += pLevel;
                                pInt += pLevel;
                                pLuk += pLevel;
                                pDex += pLevel;
                            }
                            else
                            {
                                Console.WriteLine($"\n獲得經驗值:{mExp[attackTarget]}\n經驗值:{pExp}/{pExpMax}");
                            }
                            attackTarget = -1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("請先選擇攻擊目標");
                    }


                }
                else if (Anser == "4")
                {
                    if (attackTarget == -1)
                    {
                        Console.WriteLine("請先選擇攻擊目標");
                    }
                    else
                    {
                        if (bag[0] > 0)
                        {
                            Console.WriteLine($"使用炸彈，對{mName[attackTarget]}造成了{3 * pDamage}點傷害");
                            bag[0] -= 1;
                            if (3 * pDamage > mHp[attackTarget])
                            {
                                mHp[attackTarget] = 0;
                            }
                            else
                            {
                                mHp[attackTarget] -= 3 * pDamage;
                                Console.WriteLine(
                                    $"{mName[attackTarget]}  血量:{mHp[attackTarget]}/{mHpMax[attackTarget]}\n");

                                if (mHp[attackTarget] <= 0)
                                {
                                    Console.WriteLine($"已擊敗{mName[attackTarget]}\n");
                                    mIsDead[attackTarget] = true;

                                    int dice = ram.Next(0, 100);
                                    if (dice < 50)
                                    {
                                        Console.WriteLine("恭喜!!獲得一個炸彈\n");
                                        bag[0] += 1;
                                    }

                                    pExp += mExp[attackTarget];
                                    if (pExp >= pExpMax)
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
                                    }
                                    else
                                    {
                                        Console.WriteLine($"\n獲得經驗值:{mExp[attackTarget]}\n經驗值:{pExp}/{pExpMax}");
                                    }

                                    attackTarget = -1;
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("沒有炸彈可以使用");
                        }
                    }
                }
                else if (Anser == "5")
                {
                    Console.WriteLine($"請選擇重生的目標:\n[1]{mName[0]} [2]{mName[1]} [3]{mName[2]} [4]{mName[3]} [5]{mName[4]}");
                    Anser = Console.ReadLine();
                    if (Anser == "1")
                    {
                        if (mIsDead[0] == true)
                        {
                            mIsDead[0] = false;
                            mHp[0] = mHpMax[0];
                            Console.WriteLine($"{mName[0]}已成功重生");
                        }
                        else
                        {
                            Console.WriteLine($"{mName[0]}未死亡\n請選擇死亡的目標");
                        }
                    }
                    else if (Anser == "2")
                    {
                        if (mIsDead[1] == true)
                        {
                            mIsDead[1] = false;
                            mHp[1] = mHpMax[1];
                            Console.WriteLine($"{mName[1]}已成功重生");
                        }
                        else
                        {
                            Console.WriteLine($"{mName[1]}未死亡\n請選擇死亡的目標");
                        }
                    }
                    else if (Anser == "3")
                    {
                        if (mIsDead[2] == true)
                        {
                            mIsDead[2] = false;
                            mHp[2] = mHpMax[2];
                            Console.WriteLine($"{mName[2]}已成功重生");
                        }
                        else
                        {
                            Console.WriteLine($"{mName[2]}未死亡\n請選擇死亡的目標");
                        }
                    }
                    else if (Anser == "4")
                    {
                        if (mIsDead[3] == true)
                        {
                            mIsDead[3] = false;
                            mHp[3] = mHpMax[3];
                            Console.WriteLine($"{mName[3]}已成功重生");
                        }
                        else
                        {
                            Console.WriteLine($"{mName[3]}未死亡\n請選擇死亡的目標");
                        }
                    }
                    else if (Anser == "5")
                    {
                        if (mIsDead[4] == true)
                        {
                            mIsDead[4] = false;
                            mHp[4] = mHpMax[4];
                            Console.WriteLine($"{mName[4]}已成功重生");
                        }
                        else
                        {
                            Console.WriteLine($"{mName[4]}未死亡\n請選擇死亡的目標");
                        }
                    }
                    else
                    {
                        Console.WriteLine("請輸入正確指令");
                    }
                }
                else
                {
                    Console.WriteLine("請輸入正確指令");
                }

            }
        }
    }
}
