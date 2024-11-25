
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
            expMax = 150;
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
        
        public void CalculateDamage()
        {
            switch (playerClass.number)
            {
                case 0:
                    damage = 10 * playerClass.str + 2 * playerClass.Int + 3 * playerClass.dex + 2 * playerClass.luk;
                    break;
                case 1:
                    damage = 3 * playerClass.str + 2 * playerClass.Int + 7 * playerClass.dex + 2 * playerClass.luk;
                    break;
                case 2:
                    damage = 4 * playerClass.str + 2 * playerClass.Int + 3 * playerClass.dex + 6 * playerClass.luk;
                    break;
                case 3:
                    damage = 1 * playerClass.str + 10 * playerClass.Int + 1 * playerClass.dex + 1 * playerClass.luk;
                    break;
            }
        }

        public void LevelUp(int extraExp)
        {
            level++;
            
            exp = extraExp;
            playerClass.str += level;
            playerClass.Int += level;
            playerClass.luk += level;
            playerClass.dex += level;
            expMax = level * 50 + expMax;
            ShowLevelUpState(2);
        }
        
        public void ShowLevelUpState(int puls)
        {
            Console.WriteLine("升級!!");
            Console.WriteLine($"名稱:{name}");
            Console.WriteLine($"職業:{playerClass.name}");
            Console.WriteLine($"等級:{level}");

            Console.WriteLine("\n能力值");
            Console.WriteLine($"力量:{playerClass.str}+{puls}");
            Console.WriteLine($"智力:{playerClass.Int}+{puls}");
            Console.WriteLine($"敏捷:{playerClass.dex}+{puls}");
            Console.WriteLine($"幸運:{playerClass.luk}+{puls}");

            Console.WriteLine($"\n經驗值{exp}/{expMax}");
        }

    }
}
