namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mName = "巴隆";
            int mID = 1234;
            int mLevel = 10;
            int mHp = 200;
            int mMp = 100;
            int mStr = 20;
            int mDex = 10;
            int mAc = 10;
            int mExp = 150;
            bool isStun = false;
            bool mIsDead = false;

            string pName = "玩家";
            int pID = 1234;
            int pLevel = 5;
            int pHp = 100;
            int pMp = 50;
            int pStr = 15;
            int pDex = 20;
            int pAcc = 10;
            long pExp = 100;
            long pLevelUpExp = pLevel * (pLevel * 8);


            bool isHit = false;
            int hitDamage = 0;

            isHit = (pLevel - mLevel) + (pDex) >= mDex;
            hitDamage = (pStr * 10) - (mAc * 5);

            while (true)
            {
                Console.WriteLine("是否攻擊巴隆(y/n)");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    if (isHit)
                    {
                        Console.WriteLine($"造成了{hitDamage}點傷害\n");
                        mHp -= hitDamage;
                        if (mHp <= 0)
                        {
                            mIsDead = true;
                            pExp += mExp;
                            Console.WriteLine($"{mName}死亡\n獲得經驗值:{mExp}\n當前經驗值:{pExp}");
                            break;
                        }
                        Console.WriteLine($"{mName}\n剩餘血量:{mHp}\n");
                    }
                    else
                        Console.WriteLine("未命中");
                }
                else if (input == "n")
                    Console.WriteLine("結束此回合");
                else
                    Console.WriteLine("請輸入y或n");


            }




        }
    }
}