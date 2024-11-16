using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    internal class LogInSystem
    {
        Dictionary<string, Player> playerData = new Dictionary<string, Player>();
        

        public void LogIn()
        {
            
            Console.WriteLine("請輸入玩家名稱");
            string input = Console.ReadLine();
            playerData[input] = new Player();
            for (int i = 0; playerData.Keys.Count > i; i++) 
            {
                if (input == playerData.Keys[i])
                {

                }
            }
            
        }
    }
}
