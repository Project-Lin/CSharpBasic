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
            Console.WriteLine("\n玩家狀態");
            Console.WriteLine($"名稱:{GameManager.player.name}");
            
        }
        else if (Anser.Key == ConsoleKey.D3)
        {
            //選擇地圖(村莊、荒野)
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
                LogInSystem.isLoggedIn = false;
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

    private bool CheckSelect(string DoWhat)
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
}