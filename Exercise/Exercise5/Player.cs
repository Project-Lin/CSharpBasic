namespace Exercise5
{
    public class Player
    {
        public string name;
        public int level, hp, hpMax, exp, expMax;
        public int damage { get; set; }
        public PlayerClass playerClass = null;
        public int defense { get; set; }
        public Dictionary<Item, int> Inventory { get; set; } = new Dictionary<Item, int>();
        public int Gold { get; set; } = 0;

        public Player(string _name)
        {
            expMax = 150;
            name = _name;
            level = 1;
            hpMax = 1000;
            hp = hpMax;
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

            int strGrowth = 1;
            int intGrowth = 1;
            int dexGrowth = 1;
            int lukGrowth = 1;

            switch (playerClass.number)
            {
                case 0: // 戰士
                    strGrowth = 3;
                    break;
                case 1: // 遊俠
                    dexGrowth = 3;
                    break;
                case 2: // 盜賊
                    lukGrowth = 3;
                    break;
                case 3: // 法師
                    intGrowth = 3;
                    break;
            }

            playerClass.str += strGrowth;
            playerClass.Int += intGrowth;
            playerClass.dex += dexGrowth;
            playerClass.luk += lukGrowth;

            // HP成長
            hpMax += level * 20;
            hp = hpMax; // 升級時回滿HP

            expMax = level * 50 + 100; // 調整經驗值曲線

            ShowLevelUpState(strGrowth, intGrowth, dexGrowth, lukGrowth);
        }

        public void ShowLevelUpState(int strGrowth, int intGrowth, int dexGrowth, int lukGrowth)
        {
            Console.WriteLine("\n*** 升級! ***");
            Console.WriteLine($"等級提升到 {level}!");
            Console.WriteLine($"\n能力值成長:");
            Console.WriteLine($"力量: +{strGrowth}");
            Console.WriteLine($"智力: +{intGrowth}");
            Console.WriteLine($"敏捷: +{dexGrowth}");
            Console.WriteLine($"幸運: +{lukGrowth}");
            Console.WriteLine($"最大HP: {hpMax}");
            Console.WriteLine($"\n經驗值: {exp}/{expMax}");
        }

        public void CalculateDefense()
        {
            defense = (int)(playerClass.str * 0.5 + playerClass.dex * 0.3);
        }

        public bool TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - defense);
            hp -= actualDamage;
            Console.WriteLine($"\n受到 {actualDamage} 點傷害!");

            if (hp <= 0)
            {
                hp = 0;
                return true; // 死亡
            }

            return false;
        }

        public void AddItem(Item item, int count = 1)
        {
            if (Inventory.ContainsKey(item))
            {
                Inventory[item] += count;
            }
            else
            {
                Inventory.Add(item, count);
            }

            Console.WriteLine($"\n獲得 {item.Name} x{count}");
        }

        public bool UseItem(Item item)
        {
            if (!Inventory.ContainsKey(item) || Inventory[item] <= 0)
            {
                Console.WriteLine("\n沒有足夠的物品!");
                return false;
            }

            if (GameManager.startExplore && !(item is Potion || item is Bomb))
            {
                Console.WriteLine("\n戰鬥中只能使用藥水或炸彈!");
                return false;
            }

            if (item is Potion && hp >= hpMax)
            {
                Console.WriteLine("\nHP已經是滿的!");
                return false;
            }

            item.Use(this);
            Inventory[item]--;
            if (Inventory[item] <= 0)
            {
                Inventory.Remove(item);
            }

            return true;
        }

        public void ShowInventory()
        {
            Console.WriteLine("\n背包:");
            Console.WriteLine($"金幣: {Gold}");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"{item.Key.Name} x{item.Value}");
            }
        }
    }
}