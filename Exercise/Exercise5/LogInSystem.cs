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

        public static void SaveGame()
        {
            var saveData = new Dictionary<string, object>();
            foreach (var player in playerData)
            {
                saveData[player.Key] = new {
                    Name = player.Value.name,
                    Level = player.Value.level,
                    Class = player.Value.playerClass.number,
                    Hp = player.Value.hp,
                    Exp = player.Value.exp,
                    Gold = player.Value.Gold,
                    Inventory = player.Value.Inventory.Select(i => new {
                        ItemName = i.Key.Name,
                        Count = i.Value
                    }).ToList()
                };
            }
            
            File.WriteAllText(saveFilePath, JsonSerializer.Serialize(saveData));
        }
    }
}