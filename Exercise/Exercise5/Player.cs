using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Exercise5
{
    internal class Player
    {
        public string name;
        public int level,hp,hpMax,exp,expMax;
        public int damage { get; set; }
        public PlayerClass playerClass = null;


        public Player(string _name)
        {
            name = _name;
            level = 1;
            
        }

        public void ShowInfo()
        {
            Console.WriteLine("\n玩家狀態");
            Console.WriteLine($"名稱:{name}");
            Console.WriteLine($"職業:{playerClass.name}");
            Console.WriteLine($"等級:{level}");

            Console.WriteLine("\n能力值");
            Console.WriteLine($"力量:{playerClass.str}");
            Console.WriteLine($"敏捷:{playerClass.dex}");
            Console.WriteLine($"智力:{playerClass.Int}");
            Console.WriteLine($"幸運:{playerClass.luk}");
        }

        public void SetPlayerClass()
        {
            PlayerClass _playerClass = new PlayerClass();
            playerClass = _playerClass;
        }
        

    }
}
