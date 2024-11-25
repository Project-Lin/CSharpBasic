namespace Exercise5;

public class ExploreSystem
{
     private int currentLevel = 1;
     public  List<Mob> mobToFightList = new List<Mob>();
     Random ram = new Random();
     Mob targetMob = new Mob();
     Mob mob = new Mob();
     Menu menu = new Menu();
     public static int target = -1;

    public  void Fight()
    {
        CreateFightList();
        bool hasTarget =false;
        while (!hasTarget)
        {
            target = menu.FightMenu(mobToFightList);
            if (target >= 0)
            {
                hasTarget = true;
            }
        }
        
        while (target != -1)
        {
            targetMob = mobToFightList[target];
            targetMob.ShowInfo();
            
            switch (targetMob.OnSelect())
            {
                case 0:
                    Menu.MobMenu();
                    break;
                case 1:
                    Attack();
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    menu.FightMenu(mobToFightList);
                    break;
                
            }
        }
        
    }

    public void Event()
    {
        Console.WriteLine("事件");
    }

    public void Treasure()
    {
        Console.WriteLine("寶藏");
    }
    public void CreateScenes()
    {
        int dice = ram.Next(1,100);
        if (dice < 99)
        {
            Fight();
        }
        else if (dice >99)
        {
            Treasure();
        }
        else
        {
            Event();
        }
        
    }

    public  void CreateFightList()
    {
        
        for (int i = 0; i <= ram.Next(1,4); i++)
        {
            int type=ram.Next(0,3);
            switch (type)
            {
                
                case 0:
                    mob = new Mob(Mob.MobType.slime, currentLevel);
                    mobToFightList.Add(mob);
                    break;
                case 1:
                    mob = new Mob(Mob.MobType.goblin, currentLevel);
                    mobToFightList.Add(mob);
                    break;
                case 2:
                    mob = new Mob(Mob.MobType.pig, currentLevel);
                    mobToFightList.Add(mob);
                    break;
                case 3:
                    mob = new Mob(Mob.MobType.dragon, currentLevel);
                    mobToFightList.Add(mob);
                    break;
            }
            
        }
    }

    public void Attack()
    {
        int dice = ram.Next(1,20);
        int damage = 0;
        if (dice == 1)
        {
            Console.WriteLine("大失敗");
            damage = 1;
        }
        else if (dice == 20)
        {
            Console.WriteLine("大成功");
            damage = GameManager.player.damage * 2;
        }
        else
        {
            damage = GameManager.player.damage;
        }
        
        if (damage <= targetMob.Hp)
        {
            Console.WriteLine($"對{targetMob.Name}造成{damage}點傷害");
            targetMob.Hp-=damage;
        }
        else
        {
            targetMob.Hp = 0;
        }

        if (targetMob.Hp == 0)
        {
            Console.WriteLine("目標已死亡");
            mobToFightList.Remove(targetMob);
            menu.FightMenu(mobToFightList);
            //target = -1;
        }
    }
    
}