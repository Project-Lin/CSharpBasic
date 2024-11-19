namespace Exercise5;

public class Menu
{
    public void MainMenu()
    {
        Console.WriteLine("\n<大廳>");
        Console.WriteLine("\n[1]選單 [2]顯示玩家狀態 [3]選擇地圖");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            OptionsMenu();
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            GameManager.player.ShowInfo();
        }
        else if (Anser.Key == ConsoleKey.D3)
        {
            MapMenu();
        }
        else
        {
            Console.WriteLine("\n請輸入正確指令");
        }
    }

    public void OptionsMenu()
    {
        Console.WriteLine("\n< 選單 >");
        Console.WriteLine("[1]登出 [2]離開遊戲 [3]返回大廳");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            if (CheckSelect("登出"))
            {
                GameManager.player = null;
                LogInSystem.isLoggedIn = false;
            }
            else
            {
                OptionsMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            Console.WriteLine("\n確定要離開遊戲嗎?(Y/N)");
        }
        else if (Anser.Key == ConsoleKey.D3)
        {
            MainMenu();
        }

        else
        {
            Console.WriteLine("\n請輸入正確指令");
        }
    }

    public void MapMenu()
    {
        Console.WriteLine("\n< 地圖 >");
        Console.WriteLine("[1]村莊 [2]荒野 [3]返回大廳");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            if (CheckSelect("前往村莊"))
            {
                VillageMenu();
            }
            else
            {
                MapMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            if (CheckSelect("前往荒野"))
            {
                
            }
            else
            {
                MapMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D3)
        {
            MainMenu();
        }

        else
        {
            Console.WriteLine("\n請輸入正確指令");
        }
    }

    public void VillageMenu()
    {
        Console.WriteLine("\n< 村莊 >");
        Console.WriteLine("[1]商人 [2]武器匠 [3]煉金術士 [4]返回地圖選擇");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            if (CheckSelect("選擇商人"))
            {
                
            }
            else
            {
                VillageMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            if (CheckSelect("選擇武器匠"))
            {
                
            }
            else
            {
                VillageMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D3)
        {
            if (CheckSelect("選擇武器匠"))
            {
                
            }
            else
            {
                VillageMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D4)
        {
            MapMenu();
        }

        else
        {
            Console.WriteLine("\n請輸入正確指令");
        }
    }

    public void WildMenu()
    {
        Console.WriteLine("\n< 荒野 >");
        Console.WriteLine("[1]往前探索 [2]返回村莊");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            if (CheckSelect("往前探索"))
            {
                
            }
            else
            {
                WildMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            if (CheckSelect("返回村莊"))
            {
                VillageMenu();
            }
            else
            {
                WildMenu();
            }
        }
        
        else if (Anser.Key == ConsoleKey.D4)
        {
            WildMenu();
        }

        else
        {
            Console.WriteLine("\n請輸入正確指令");
        }
    }

    public void FlightMenu()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo Anser = Console.ReadKey();
            if (Anser.Key == ConsoleKey.D1)
            {
                //選擇目標(列出目標)
            }
            else if (Anser.Key == ConsoleKey.D2)
            {
                //往前探索
            }
            else if (Anser.Key == ConsoleKey.D3)
            {
                //返回大廳
            }
            else
            {
                Console.WriteLine("請輸入正確指令");
            }
        }
    }

    private static bool CheckSelect(string DoWhat)
    {
        Console.WriteLine($"\n確定要{DoWhat}嗎?(Y/N)");
        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.Y)
        {
            return true;
        }
        else if (Anser.Key == ConsoleKey.N)
        {
            return false;
        }
        else
        {
            Console.WriteLine("\n請輸入正確指令");
            return false;
        }
    }

    public void SettingClassMenu(PlayerClass _PlayerClass)
    {
        bool isSet = false;
        while (!isSet)
        {
            Console.WriteLine("\n<選擇職業>");
            Console.WriteLine("\n[1]戰士 [2]遊俠 [3]盜賊 [4]法師");

            ConsoleKeyInfo Anser = Console.ReadKey();
            if (Anser.Key == ConsoleKey.D1)
            {
                _PlayerClass.ShowAbility(0);
                if (CheckSelect("選擇戰士"))
                {
                    _PlayerClass.SetAbility(PlayerClass.pClass.warrior);
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("取消選擇");
                }
            }
            else if (Anser.Key == ConsoleKey.D2)
            {
                _PlayerClass.ShowAbility(1);
                if (CheckSelect("選擇遊俠"))
                {
                    _PlayerClass.SetAbility(PlayerClass.pClass.ranger);
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("取消選擇");
                }
            }
            else if (Anser.Key == ConsoleKey.D3)
            {
                _PlayerClass.ShowAbility(2);
                if (CheckSelect("選擇盜賊"))
                {
                    _PlayerClass.SetAbility(PlayerClass.pClass.thief);
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("取消選擇");
                }
            }
            else if (Anser.Key == ConsoleKey.D4)
            {
                _PlayerClass.ShowAbility(3);
                if (CheckSelect("選擇法師"))
                {
                    _PlayerClass.SetAbility(PlayerClass.pClass.mage);
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("取消選擇");
                }
            }
            else
            {
                Console.WriteLine("\n請輸入正確指令");
            }
        }
    }
}