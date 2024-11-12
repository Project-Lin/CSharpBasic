namespace Exercise3
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

            StartSet();
            while (isQuit)
            {
                SetClass();
            }

            void StartSet()
            {
                Console.WriteLine("歡迎來到地獄M\n請輸入您的姓名:");
                pName = Console.ReadLine();
            }
            void SetClass()
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
            }
        }

        

    }
}