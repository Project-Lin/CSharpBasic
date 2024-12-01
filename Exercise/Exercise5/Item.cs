namespace Exercise5
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public ItemType Type { get; set; }

        public enum ItemType
        {
            Potion,
            Boom,
        }

        public virtual void Use(Player player)
        {
        }
    }

    public class Potion : Item
    {
        public int HealAmount { get; set; }

        public Potion(string name, int healAmount, int value)
        {
            Name = name;
            HealAmount = healAmount;
            Value = value;
            Type = ItemType.Potion;
        }

        public override void Use(Player player)
        {
            player.hp = Math.Min(player.hpMax, player.hp + HealAmount);
            Console.WriteLine($"\n使用了{Name}, 回復了{HealAmount}點HP!");
        }
    }

    public class Bomb : Item
    {
        public float DamageMultiplier { get; set; } = 2.0f;

        public Bomb(string name, int value)
        {
            Name = name;
            Value = value;
            Type = ItemType.Boom;
            Description = $"對所有敵人造成{DamageMultiplier}倍攻擊力的傷害";
        }

        public override void Use(Player player)
        {
            int damage = (int)(player.damage * DamageMultiplier);
            var mobs = ExploreSystem.currentMobs = GameManager.Instance().exploreSystem.mobToFightList;

            Console.WriteLine($"\n使用了{Name}!");
            foreach (var mob in mobs.ToList())
            {
                mob.Hp -= damage;
                Console.WriteLine($"{mob.Name} 受到 {damage} 點傷害!");

                if (mob.Hp <= 0)
                {
                    Console.WriteLine($"{mob.Name} 被炸死了!");
                    mobs.Remove(mob);

                    int goldDrop = mob.GetGoldDrop();
                    GameManager.player.Gold += goldDrop;
                    Console.WriteLine($"獲得 {goldDrop} 金幣");

                    Console.WriteLine($"獲得 {mob.Exp} 點經驗值");
                    if (GameManager.player.exp + mob.Exp >= GameManager.player.expMax)
                    {
                        int extraExp = GameManager.player.exp + mob.Exp - GameManager.player.expMax;
                        GameManager.player.LevelUp(extraExp);
                    }
                    else
                    {
                        GameManager.player.exp += mob.Exp;
                        Console.WriteLine($"經驗值:{GameManager.player.exp}/{GameManager.player.expMax}");
                    }
                }
            }

            if (mobs.Count == 0)
            {
                Console.WriteLine("\n已殲滅所有敵人，進入下一關");
                ExploreSystem.currentLevel++;
                ExploreSystem.target = -1;
                ExploreSystem.isCompleteTheLevel = true;
                ExploreSystem.isCrateFightList = false;
            }
        }
    }
}