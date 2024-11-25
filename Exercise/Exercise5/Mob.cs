namespace Exercise5
{
    public class Mob:Npc
    {
        Random random = new Random();
        public int Attack { get; set; }
        //TODO 製作怪物生成
        public enum MobType
        {
            slime,
            goblin,
            pig,
            dragon,
        }
        public Mob()
        {
            
        }
        public Mob(MobType mobType,int level)
        {
            switch (mobType)
            {
                case MobType.slime :
                    Name ="史萊姆";
                    MaxHp = (100 + random.Next(-10, 50))+(10 * level *level);
                    Hp = MaxHp;
                    Exp = 100;
                    Attack = (10 + random.Next(-2, 5)) * level;
                    break;
                case MobType.goblin :
                    Name = "哥布林";
                    MaxHp = (200 + random.Next(-10, 50))+(20 * level *level);
                    Hp = MaxHp;
                    Exp = 100;
                    Attack = (20 + random.Next(-3, 8)) * level;
                    break;
                case MobType.pig :
                    Name ="野豬騎士";
                    MaxHp = (400 + random.Next(-10, 50))+(30 * level *level);
                    Hp = MaxHp;
                    Exp = 100;
                    Attack = (35 + random.Next(-5, 10)) * level;
                    break;
                case MobType.dragon :
                    Name ="飛龍";
                    MaxHp = (800 + random.Next(-10, 50))+(40 * level *level);
                    Hp = MaxHp;
                    Exp = 100;
                    Attack = (50 + random.Next(-8, 15)) * level;
                    break;
            }
        }

        public override int OnSelect()
        {
            // switch (Menu.MobMenu())
            // {
            //     case 0:
            //         Menu.MobMenu();
            //         break;
            //     case 1:
            //         //攻擊
            //         Hp -= GameManager.player.damage;
            //         break;
            //     case 2:
            //         //道具 
            //         break;
            //     case 3:
            //         //逃跑 返回怪物清單
            //         break;
            // }
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