namespace Exercise5;

public class ExploreSystem
{
    public static int currentLevel = 1;
    public List<Mob> mobToFightList = new List<Mob>();
    private Random ram = new Random();
    private Mob targetMob = new Mob();
    private Menu menu = new Menu();
    public static int target = -1;
    public static bool isCrateFightList = false;
    public static bool isCompleteTheLevel = false;
    public static List<Mob> currentMobs = new List<Mob>();

    private List<Item> commonTreasures = new List<Item>()
    {
        new Potion("小藥水", 50, 30) { Description = "恢復30點HP的藥水" },
        new Potion("中藥水", 100, 60) { Description = "恢復60點HP的藥水" },
        new Bomb("小型炸彈", 100) { Description = "對所有敵人造成雙倍攻擊力的傷害" },
    };

    private List<Item> rareTreasures = new List<Item>()
    {
        new Potion("超級藥水", 300, 150) { Description = "恢復150點HP的藥水" },
        new Bomb("超級炸彈", 300) { Description = "對所有敵人造成雙倍攻擊力的傷害" },
    };

    public void StartExplore()
    {
        Console.WriteLine($"\n=== 當前位置：荒野 第{currentLevel}層 ===");
        CreateScenes();
    }

    public void CreateScenes()
    {
        currentMobs.Clear();
        int sceneType = ram.Next(0, 10);

        switch (sceneType)
        {
            case < 6:
                Console.WriteLine("\n遭遇敵人!");
                CreateFightList();
                Fight();
                break;

            case < 8:
                HandleEvent();
                break;

            default:
                HandleTreasure();
                break;
        }
    }

    private void CreateFightList()
    {
        mobToFightList.Clear();
        int mobCount = ram.Next(1, Math.Min(currentLevel + 1, 5));

        for (int i = 0; i < mobCount; i++)
        {
            Mob.MobType type = GetRandomMobType();
            mobToFightList.Add(new Mob(type, currentLevel));
        }

        currentMobs = mobToFightList;
        isCrateFightList = true;
    }

    private Mob.MobType GetRandomMobType()
    {
        int dice = ram.Next(0, 100);
        if (currentLevel >= 5 && dice < 10)
        {
            return Mob.MobType.dragon;
        }

        if (currentLevel >= 3 && dice < 30)
        {
            return Mob.MobType.pig;
        }

        return dice < 60 ? Mob.MobType.slime : Mob.MobType.goblin;
    }

    private void HandleEvent()
    {
        int eventType = ram.Next(0, 3);
        switch (eventType)
        {
            case 0:
                HandleHealingSpring();
                break;
            case 1:
                HandleTrap();
                break;
            case 2:
                HandleMerchant();
                break;
        }

        Console.WriteLine($"\n已完成第{currentLevel}層!");
        currentLevel++;
        ShowNextLevelMenu();
        isCompleteTheLevel = true;
    }

    private void HandleHealingSpring()
    {
        Console.WriteLine("\n發現了治癒之泉!");
        int healAmount = GameManager.player.hpMax / 2;
        GameManager.player.hp = Math.Min(GameManager.player.hpMax, GameManager.player.hp + healAmount);
        Console.WriteLine($"恢復了 {healAmount} 點HP!");
        Console.WriteLine($"當前HP: {GameManager.player.hp}/{GameManager.player.hpMax}");
    }

    private void HandleTrap()
    {
        Console.WriteLine("\n踩到陷阱!");
        int damage = currentLevel * 20;
        if (GameManager.player.TakeDamage(damage))
        {
            GameOver();
        }
    }

    private void HandleMerchant()
    {
        Console.WriteLine("\n遇到了神秘商人!");
        // 商人的購買
    }


    private void HandleTreasure()
    {
        Console.WriteLine("\n發現寶箱!");
        bool isRare = ram.Next(0, 100) < 20;

        var treasureList = isRare ? rareTreasures : commonTreasures;
        var treasure = treasureList[ram.Next(treasureList.Count)];

        GameManager.player.AddItem(treasure);
        Console.WriteLine($"獲得了 {treasure.Name}!");
        Console.WriteLine($"描述: {treasure.Description}");

        Console.WriteLine($"\n已完成第{currentLevel}層!");
        currentLevel++;
        ShowNextLevelMenu();
        isCompleteTheLevel = true;
    }

    private void HandleBattleReward(Mob mob)
    {
        Console.WriteLine($"\n擊敗了 {mob.Name}!");

        // 獲得金幣
        int goldDrop = mob.GetGoldDrop();
        GameManager.player.Gold += goldDrop;
        Console.WriteLine($"獲得 {goldDrop} 金幣");

        // 獲得經驗值
        Console.WriteLine($"獲得 {mob.Exp} 點經驗值");

        if (GameManager.player.exp + mob.Exp >= GameManager.player.expMax)
        {
            int extraExp = GameManager.player.exp + mob.Exp - GameManager.player.expMax;
            GameManager.player.LevelUp(extraExp);
        }
        else
        {
            GameManager.player.exp += mob.Exp;
            Console.WriteLine($"經驗值: {GameManager.player.exp}/{GameManager.player.expMax}");
        }

        // 檢查是否所有怪物都被擊敗
        if (mobToFightList.Count == 0)
        {
            Console.WriteLine($"\n已完成第{currentLevel}層!");
            currentLevel++;
            ShowNextLevelMenu();
            isCompleteTheLevel = true;
        }
    }

    public void Fight()
    {
        if (!isCrateFightList)
        {
            CreateFightList();
            isCrateFightList = true;
        }

        while (mobToFightList.Count > 0 && !isCompleteTheLevel)
        {
            target = menu.FightMenu(mobToFightList);
            if (target == -1) continue;

            targetMob = mobToFightList[target];
            targetMob.ShowInfo();

            while (targetMob.Hp > 0 && !isCompleteTheLevel)
            {
                switch (targetMob.OnSelect())
                {
                    case 0:
                        Menu.MobMenu();
                        break;
                    case 1:
                        Attack();
                        if (isCompleteTheLevel) return;
                        continue;
                    case 2:
                        if (targetMob.Hp > 0)
                        {
                            if (GameManager.player.TakeDamage(targetMob.Attack))
                            {
                                GameOver();
                                return;
                            }
                        }

                        break;
                    case 3:
                        if (TryEscape())
                        {
                            Console.WriteLine("\n成功逃脫!");
                            isCompleteTheLevel = true;
                            isCrateFightList = false;
                            GameManager.startExplore = false;
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\n逃跑失敗!");
                            Console.WriteLine($"\n{targetMob.Name} 發動攻擊!");
                            if (GameManager.player.TakeDamage(targetMob.Attack))
                            {
                                GameOver();
                                return;
                            }

                            Console.WriteLine($"玩家血量: {GameManager.player.hp}/{GameManager.player.hpMax}");
                            continue;
                        }
                }
            }
        }
    }

    private bool TryEscape()
    {
        int escapeChance = 40 + (GameManager.player.playerClass.dex * 2);
        return ram.Next(1, 101) <= escapeChance;
    }

    public void Attack()
    {
        int dice = ram.Next(1, 20);
        int damage = 0;
        if (dice == 1)
        {
            Console.WriteLine("\n大失敗");
            damage = 1;
        }
        else if (dice == 20)
        {
            Console.WriteLine("\n大成功");
            damage = GameManager.player.damage * 2;
        }
        else
        {
            damage = GameManager.player.damage;
        }

        if (damage <= targetMob.Hp)
        {
            Console.WriteLine($"\n對{targetMob.Name}造成{damage}點傷害");
            targetMob.Hp -= damage;
        }
        else
        {
            targetMob.Hp = 0;
        }

        if (targetMob.Hp <= 0)
        {
            mobToFightList.Remove(targetMob);
            HandleBattleReward(targetMob);
        }
        else
        {
            Console.WriteLine($"\n{targetMob.Name} 發動攻擊!");
            if (GameManager.player.TakeDamage(targetMob.Attack))
            {
                GameOver();
                return;
            }

            Console.WriteLine($"玩家血量: {GameManager.player.hp}/{GameManager.player.hpMax}");
        }
    }

    private void GameOver()
    {
        Console.WriteLine("\n遊戲結束!");
        Console.WriteLine($"你在第 {currentLevel} 關被擊敗了");
        currentLevel = 1;
        GameManager.startExplore = false;
        isCompleteTheLevel = true;
        isCrateFightList = false;

        GameManager.player.hp = GameManager.player.hpMax;
    }

    private void ShowNextLevelMenu()
    {
        while (true)
        {
            Console.WriteLine($"\n=== 選擇下一步 ===");
            Console.WriteLine($"當前位置：第{currentLevel}層");
            Console.WriteLine("[1] 繼續探索");
            Console.WriteLine("[2] 返回村莊");

            ConsoleKeyInfo answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.D1)
            {
                Console.WriteLine("\n繼續前進...");
                isCompleteTheLevel = false;
                return;
            }
            else if (answer.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\n返回村莊...");
                GameManager.startExplore = false;
                GameManager.player.hp = GameManager.player.hpMax; // 返回村莊時回滿血
                return;
            }
            else
            {
                Console.WriteLine("\n請輸入正確指令");
            }
        }
    }
}