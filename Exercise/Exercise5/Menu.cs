namespace Exercise5;

public class Menu
{
    public void MainMenu()
    {
        Console.WriteLine("\n<大廳>");
        Console.WriteLine("\n[1]選單 [2]顯示玩家狀態 [3]查看背包 [4]選擇地圖");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            OptionsMenu();
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            GameManager.player.ShowInfo();
        }
        else if (Anser.Key == ConsoleKey.D3)
        {
            GameManager.player.ShowInventory();
            Console.WriteLine("\n按任意鍵返回大廳...");
            Console.ReadKey();
        }
        else if (Anser.Key == ConsoleKey.D4)
        {
            MapMenu();
        }
        else
        {
            Console.WriteLine("\n請輸入正確指令");
        }
    }

    public void OptionsMenu()
    {
        Console.WriteLine("\n< 選單 >");
        Console.WriteLine("[1]登出 [2]離開遊戲 [3]返回大廳");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            if (CheckSelect("登出"))
            {
                LogInSystem.SaveGame();
                GameManager.player = null;
                LogInSystem.isLoggedIn = false;
                ExploreSystem.currentLevel = ExploreSystem.currentLevel;
                GameManager.startExplore = false;
                ExploreSystem.isCompleteTheLevel = false;
                ExploreSystem.isCrateFightList = false;
                return;
            }
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            if (CheckSelect("離開遊戲"))
            {
                Environment.Exit(0);
            }
        }
        else if (Anser.Key == ConsoleKey.D3)
        {
            MainMenu();
        }

        else
        {
            Console.WriteLine("\n請輸入正確指令");
        }
    }

    public void MapMenu()
    {
        Console.WriteLine("\n< 地圖 >");
        Console.WriteLine("[1]村莊 [2]荒野 [3]返回大廳");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            if (CheckSelect("前往村莊"))
            {
                VillageMenu();
            }
            else
            {
                MapMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            if (CheckSelect("前往荒野"))
            {
                WildMenu();
            }
            else
            {
                MapMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D3)
        {
            MainMenu();
        }

        else
        {
            Console.WriteLine("\n請輸入正確指令");
        }
    }

    public void VillageMenu()
    {
        Console.WriteLine("\n< 村莊 >");
        Console.WriteLine("[1]商人 [2]武器匠 [3]煉金術士 [4]返回地圖選擇");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            if (CheckSelect("選擇商人"))
            {
            }
            else
            {
                VillageMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            if (CheckSelect("選擇武器匠"))
            {
            }
            else
            {
                VillageMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D3)
        {
            if (CheckSelect("選擇武器匠"))
            {
            }
            else
            {
                VillageMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D4)
        {
            MapMenu();
        }

        else
        {
            Console.WriteLine("\n請輸入正確指令");
        }
    }

    //TODO 探索系統
    public void WildMenu()
    {
        Console.WriteLine("\n< 荒野 >");
        Console.WriteLine("[1]往前探索 [2]返回村莊");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            if (CheckSelect("往前探索"))
            {
                GameManager.startExplore = true;
            }
            else
            {
                WildMenu();
            }
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            if (CheckSelect("返回村莊"))
            {
                VillageMenu();
            }
            else
            {
                WildMenu();
            }
        }

        else if (Anser.Key == ConsoleKey.D4)
        {
            WildMenu();
        }

        else
        {
            Console.WriteLine("\n請輸入正確指令");
        }
    }

    public int FightMenu(List<Mob> mobList)
    {
        Console.WriteLine($"\n關卡{ExploreSystem.currentLevel}:");
        Console.WriteLine($"<遭遇戰>");
        Console.WriteLine("\n敵人:");
        if (mobList.Count == 0)
        {
            return -1;
        }
        for (int i = 0; i < mobList.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {mobList[i].Name} ");
        }

        bool isSelected = false;
        int selectedMob = -1;
        while (!isSelected)
        {
            ConsoleKeyInfo Anser = Console.ReadKey();

            if (Anser.Key == ConsoleKey.D1 && mobList.Count >= 1)
            {
                if (CheckSelect($"選擇{mobList[0].Name}"))
                {
                    selectedMob = 0;
                    isSelected = true;
                }
                else
                {
                    selectedMob = -1;
                    isSelected = false;
                    break;
                }
            }
            else if (Anser.Key == ConsoleKey.D2 && mobList.Count >= 2)
            {
                if (CheckSelect($"選擇{mobList[1].Name}"))
                {
                    selectedMob = 1;
                    isSelected = true;
                }
                else
                {
                    selectedMob = -1;
                    isSelected = false;
                    break;
                }
            }
            else if (Anser.Key == ConsoleKey.D3 && mobList.Count >= 3)
            {
                if (CheckSelect($"選擇{mobList[2].Name}"))
                {
                    selectedMob = 2;
                    isSelected = true;
                }
                else
                {
                    selectedMob = -1;
                    isSelected = false;
                    break;
                }
            }
            else if (Anser.Key == ConsoleKey.D4 && mobList.Count >= 4)
            {
                if (CheckSelect($"選擇{mobList[3].Name}"))
                {
                    selectedMob = 3;
                    isSelected = true;
                }
                else
                {
                    selectedMob = -1;
                    isSelected = false;
                    break;
                }
            }
            else if (Anser.Key == ConsoleKey.D5 && mobList.Count >= 5)
            {
                if (CheckSelect($"選擇{mobList[4].Name}"))
                {
                    selectedMob = 4;
                    isSelected = true;
                }
                else
                {
                    selectedMob = -1;
                    isSelected = false;
                    break;
                }
            }
            else
            {
                Console.WriteLine("\n請輸入正確指令");
                break;
            }
        }

        return selectedMob;
    }

    // private void ShowMobInfo(int number, List<Mob> mobList)
    // {
    //     Console.WriteLine($"{mobList[number].Name}");
    //     Console.WriteLine($"{mobList[number].Hp}/{mobList[number].MaxHp}");
    //     Console.WriteLine($"{mobList[number].Exp}");
    // }

    private static bool CheckSelect(string DoWhat)
    {
        Console.WriteLine($"\n確定要{DoWhat}嗎?(Y/N)");
        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.Y)
        {
            return true;
        }
        else if (Anser.Key == ConsoleKey.N)
        {
            return false;
        }
        else
        {
            Console.WriteLine("\n請輸入正確指令");
            return false;
        }
    }

    public void SettingClassMenu(PlayerClass _PlayerClass)
    {
        bool isSet = false;
        while (!isSet)
        {
            Console.WriteLine("\n<選擇職業>");
            Console.WriteLine("\n[1]戰士 [2]遊俠 [3]盜賊 [4]法師");

            ConsoleKeyInfo Anser = Console.ReadKey();
            if (Anser.Key == ConsoleKey.D1)
            {
                _PlayerClass.ShowAbility(0);
                if (CheckSelect("選擇戰士"))
                {
                    _PlayerClass.SetAbility(PlayerClass.pClass.warrior);
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("取消選擇");
                }
            }
            else if (Anser.Key == ConsoleKey.D2)
            {
                _PlayerClass.ShowAbility(1);
                if (CheckSelect("選擇遊俠"))
                {
                    _PlayerClass.SetAbility(PlayerClass.pClass.ranger);
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("取消選擇");
                }
            }
            else if (Anser.Key == ConsoleKey.D3)
            {
                _PlayerClass.ShowAbility(2);
                if (CheckSelect("選擇盜賊"))
                {
                    _PlayerClass.SetAbility(PlayerClass.pClass.thief);
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("取消選擇");
                }
            }
            else if (Anser.Key == ConsoleKey.D4)
            {
                _PlayerClass.ShowAbility(3);
                if (CheckSelect("選擇法師"))
                {
                    _PlayerClass.SetAbility(PlayerClass.pClass.mage);
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("取消選擇");
                }
            }
            else
            {
                Console.WriteLine("\n請輸入正確指令");
            }
        }
    }

    public static int MobMenu()
    {
        Console.WriteLine("\n< 戰鬥 >");
        Console.WriteLine("[1]攻擊 [2]使用道具 [3]逃跑");

        ConsoleKeyInfo Anser = Console.ReadKey();
        if (Anser.Key == ConsoleKey.D1)
        {
            return 1;
        }
        else if (Anser.Key == ConsoleKey.D2)
        {
            Menu menu = new Menu();
            menu.UseItem();
            return 0;
        }
        else if (Anser.Key == ConsoleKey.D3)
        {
            if (CheckSelect("逃跑"))
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            Console.WriteLine("\n請輸入正確指令");
            return 0;
        }
    }

    public void UseItem()
    {
        Console.WriteLine("\n使用道具:");
        
        // 顯示藥水和炸彈
        var usableItems = GameManager.player.Inventory
            .Where(i => (i.Key.Type == Item.ItemType.Potion || 
                        (i.Key is Bomb)) && 
                        i.Value > 0)
            .ToList();
        
        if (usableItems.Count == 0)
        {
            Console.WriteLine("沒有可使用的道具!");
            return;
        }

        for (int i = 0; i < usableItems.Count; i++)
        {
            var item = usableItems[i];
            if (item.Key is Potion potion)
            {
                Console.WriteLine($"[{i + 1}] {item.Key.Name} x{item.Value} ({potion.HealAmount}HP)");
            }
            else if (item.Key is Bomb)
            {
                Console.WriteLine($"[{i + 1}] {item.Key.Name} x{item.Value} (造成{GameManager.player.damage * 2}傷害)");
            }
        }
        
        Console.WriteLine("[0] 返回");
        
        ConsoleKeyInfo answer = Console.ReadKey();
        if (answer.KeyChar == '0') return;
        
        int selection;
        if (int.TryParse(answer.KeyChar.ToString(), out selection) && 
            selection > 0 && selection <= usableItems.Count)
        {
            GameManager.player.UseItem(usableItems[selection - 1].Key);
        }
        else
        {
            Console.WriteLine("\n無效的選擇");
        }
    }
}