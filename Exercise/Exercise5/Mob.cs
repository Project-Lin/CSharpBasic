namespace Exercise5
{
    public class Mob : Npc
    {
        private Random random = new Random();
        public int Attack { get; set; }
        public int MinGold { get; private set; }
        public int MaxGold { get; private set; }

        public enum MobType
        {
            slime,
            goblin,
            pig,
            dragon
        }

        public Mob(MobType mobType, int level)
        {
            switch (mobType)
            {
                case MobType.slime:
                    Name = "史萊姆";
                    MaxHp = (100 + random.Next(-10, 50)) + (10 * level * level);
                    Attack = (10 + random.Next(-2, 5)) * level;
                    MinGold = 10 * level;
                    MaxGold = 20 * level;
                    break;

                case MobType.goblin:
                    Name = "哥布林";
                    MaxHp = (200 + random.Next(-10, 50)) + (20 * level * level);
                    Attack = (20 + random.Next(-3, 8)) * level;
                    MinGold = 20 * level;
                    MaxGold = 35 * level;
                    break;

                case MobType.pig:
                    Name = "野豬騎士";
                    MaxHp = (400 + random.Next(-10, 50)) + (30 * level * level);
                    Attack = (35 + random.Next(-5, 10)) * level;
                    MinGold = 35 * level;
                    MaxGold = 50 * level;
                    break;

                case MobType.dragon:
                    Name = "飛龍";
                    MaxHp = (800 + random.Next(-10, 50)) + (40 * level * level);
                    Attack = (50 + random.Next(-8, 15)) * level;
                    MinGold = 50 * level;
                    MaxGold = 100 * level;
                    break;
            }

            Hp = MaxHp;
            Exp = 100;
        }

        public Mob()
        {
        }

        public int GetGoldDrop()
        {
            return random.Next(MinGold, MaxGold + 1);
        }

        public override int OnSelect()
        {
            return Menu.MobMenu();
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"血量:{Hp}/{MaxHp}");
            Console.WriteLine($"經驗值:{Exp}");
        }
    }
}