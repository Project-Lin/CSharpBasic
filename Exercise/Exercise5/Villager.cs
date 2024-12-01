namespace Exercise5;

public class Villager : Npc
{
    public enum VillagerType
    {
        Merchant,
        Blacksmith,
        Alchemist
    }

    private VillagerType type;
    private List<Item> goods = new List<Item>();

    public Villager(VillagerType type)
    {
        this.type = type;
        InitializeVillager();
    }

    private void InitializeVillager()
    {
        switch (type)
        {
            case VillagerType.Merchant:
                Name = "商人";
                InitializeMerchantGoods();
                break;
            case VillagerType.Blacksmith:
                Name = "武器匠";
                InitializeBlacksmithGoods();
                break;
            case VillagerType.Alchemist:
                Name = "煉金術士";
                InitializeAlchemistGoods();
                break;
        }
    }

    private void InitializeMerchantGoods()
    {
        goods.Add(new Potion("小藥水", 30, 50) { Description = "恢復30點HP的藥水" });
        goods.Add(new Potion("中藥水", 60, 100) { Description = "恢復60點HP的藥水" });
        goods.Add(new Bomb("小型炸彈", 100) { Description = "對所有敵人造成1.5倍攻擊力的傷害", DamageMultiplier = 1.5f });
    }

    private void InitializeBlacksmithGoods()
    {
        // TODO: 添加武器裝備
    }

    private void InitializeAlchemistGoods()
    {
        goods.Add(new Potion("超級藥水", 150, 300) { Description = "恢復150點HP的藥水" });
        goods.Add(new Bomb("超級炸彈", 300) { Description = "對所有敵人造成2.5倍攻擊力的傷害", DamageMultiplier = 2.5f });
    }

    public override void Talk()
    {
        switch (type)
        {
            case VillagerType.Merchant:
                Console.WriteLine($"\n{Name}: 歡迎光臨!我這裡有各種實用的物品。");
                break;
            case VillagerType.Blacksmith:
                Console.WriteLine($"\n{Name}: 需要什麼武器裝備嗎?");
                break;
            case VillagerType.Alchemist:
                Console.WriteLine($"\n{Name}: 我的藥水和炸彈都是最好的!");
                break;
        }

        ShowGoods();
    }

    private void ShowGoods()
    {
        Console.WriteLine("\n商品列表:");
        for (int i = 0; i < goods.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {goods[i].Name} - {goods[i].Value}金幣");
            Console.WriteLine($"    {goods[i].Description}");
        }

        Console.WriteLine("[0] 離開");

        HandlePurchase();
    }

    private void HandlePurchase()
    {
        ConsoleKeyInfo answer = Console.ReadKey();
        int selection;
        if (int.TryParse(answer.KeyChar.ToString(), out selection))
        {
            if (selection == 0) return;
            if (selection > 0 && selection <= goods.Count)
            {
                Item selectedItem = goods[selection - 1];
                if (GameManager.player.Gold >= selectedItem.Value)
                {
                    GameManager.player.Gold -= selectedItem.Value;
                    GameManager.player.AddItem(selectedItem);
                    Console.WriteLine($"\n購買了 {selectedItem.Name}!");
                }
                else
                {
                    Console.WriteLine("\n金幣不足!");
                }
            }
            else
            {
                Console.WriteLine("\n無效的選擇");
            }
        }
    }
}