using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Exercise5
{
    internal class LogInSystem
    {
        public static Dictionary<string, Player> playerData = new Dictionary<string, Player>();
        public static bool isLoggedIn = false;
        private static string saveFilePath = "playerData.json";

        public static Player LogIn()
        {
            Console.WriteLine("歡迎來到<地獄M>");
            Console.WriteLine("\n登入:");
            Console.WriteLine("請輸入玩家名稱");
            string input = Console.ReadLine();

            if (playerData.ContainsKey(input))
            {
                Console.WriteLine("登入成功");
                Console.WriteLine($"玩家名稱:{input}");
                isLoggedIn = true;
                return playerData[input];
            }
            else
            {
                Console.WriteLine("創建成功");
                Console.WriteLine($"玩家名稱:{input}");
                Player player = new Player(input);
                playerData.Add(input, player);
                isLoggedIn = true;
                return player;
            }
        }
    }
}