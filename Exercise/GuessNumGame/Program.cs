namespace GuessNumGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("歡迎來到猜數字遊戲");
            Console.WriteLine("請選擇要挑戰幾位數");
            int numOfDigital = 0;
            while (numOfDigital == 0)
            {
                string anser = Console.ReadLine();


                if (int.TryParse(anser, out numOfDigital))
                {
                    Console.WriteLine($"選擇{numOfDigital}位數");
                    Console.WriteLine("遊戲開始");
                }
                else
                {
                    Console.WriteLine("請輸入數字");
                }
            }

            Random random = new Random();

            long anserNum = 0;
            int digit = 1;
            int[] ansers = new int[numOfDigital];
            int[] gusNums = new int[numOfDigital];
            bool isOk = false;
            int maxNumb = 1;
            int minNumb = 0;
            int Acount = 0;
            int Bcount = 0;
            int gusNumInt = -1;
            for (int i = 0; i < numOfDigital; i++)
            {
                maxNumb *= 10;
            }


            for (int i = numOfDigital - 1; i > 0; i--)
            {
                long randomNum = random.Next(1, 9);
                ansers[i - 1] = (int)randomNum;
                digit *= 10;
                randomNum *= digit;
                anserNum += randomNum;
            }

            int num = random.Next(0, 9);
            anserNum += num;
            ansers[numOfDigital - 1] = num;

            //Console.WriteLine(anserNum);


            bool isWin = false;
            while (!isWin)
            {
                GuessNum();
            }


            void GuessNum()
            {
                Console.WriteLine($"猜一個{numOfDigital}位數字");
                //確保數字位數正確


                int digitTemp = digit;
                while (isOk == false)
                {
                    string gusNum = Console.ReadLine();
                    if (int.TryParse(gusNum, out gusNumInt))
                    {
                    }
                    else
                    {
                        Console.WriteLine("請輸入數字");
                    }

                    if (gusNumInt >= maxNumb || gusNumInt == -1 || gusNumInt <= (maxNumb / 10) - 1)
                    {
                        Console.WriteLine("超出數字範圍，請重新輸入");
                    }
                    else
                    {
                        isOk = true;
                    }
                }


                for (int i = 0; i < numOfDigital; i++)
                {
                    gusNums[i] = gusNumInt / digitTemp;
                    gusNumInt = gusNumInt % digitTemp;
                    digitTemp /= 10;
                }


                for (var i = 0; i < numOfDigital; i++)
                {
                    int tempAnser = ansers[i];
                    if (gusNums[i] == tempAnser)
                    {
                        Acount++;
                    }
                    else
                    {
                        for (var j = 0; j < numOfDigital; j++)
                        {
                            if (tempAnser == gusNums[j])
                            {
                                Bcount++;
                                break;
                            }
                        }
                    }
                }

                // for (int i = 0; i < numOfDigital; i++)
                // {
                //     if (gusNums[i] == ansers[i])
                //     {
                //         Acount++;
                //     }
                // }

                //Bcount -= Acount;
                if (Acount == numOfDigital)
                {
                    Console.WriteLine("你猜對了");
                    isWin = true;
                }
                else
                {
                    Console.WriteLine($"{Acount}A{Bcount}B");
                    gusNumInt = -1;
                    isOk = false;
                    Acount = 0;
                    Bcount = 0;
                }
            }
        }
    }
}