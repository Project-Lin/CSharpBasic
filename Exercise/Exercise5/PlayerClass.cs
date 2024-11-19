﻿using Exercise4;

namespace Exercise5;

public class PlayerClass
{
    public string name;
    public int str, Int, dex, luk;

    public enum pClass
    {
        warrior,
        ranger,
        thief,
        mage,
    }

    public void SetAbility(pClass pAbility)
    {
        switch (pAbility)
        {
            case pClass.warrior:
                name = $"{ClassAbilitySet.WorriorName}";
                str = ClassAbilitySet.WorriorStr;
                Int = ClassAbilitySet.WorriorInt;
                dex = ClassAbilitySet.WorriorDex;
                luk = ClassAbilitySet.WorriorLuk;
                break;
            case pClass.ranger:
                name = $"{ClassAbilitySet.RangerName}";
                str = ClassAbilitySet.RangerStr;
                Int = ClassAbilitySet.RangerInt;
                dex = ClassAbilitySet.RangerDex;
                luk = ClassAbilitySet.RangerLuk;
                break;
            case pClass.thief:
                name = $"{ClassAbilitySet.ThiefName}";
                str = ClassAbilitySet.ThiefStr;
                Int = ClassAbilitySet.ThiefInt;
                dex = ClassAbilitySet.ThiefDex;
                luk = ClassAbilitySet.ThiefLuk;
                break;
            case pClass.mage:
                name = $"{ClassAbilitySet.MageName}";
                str = ClassAbilitySet.MageStr;
                Int = ClassAbilitySet.MageInt;
                dex = ClassAbilitySet.MageDex;
                luk = ClassAbilitySet.MageLuk;
                break;
        }
    }

    public void ShowAbility(int ClassNum)
    {
        Console.WriteLine($"\n職業:{ClassAbilitySet.ClassName[ClassNum]}");

        Console.WriteLine("\n能力值");
        Console.WriteLine($"力量:{ClassAbilitySet.ClassStr[ClassNum]}");
        Console.WriteLine($"智力:{ClassAbilitySet.ClassInt[ClassNum]}");
        Console.WriteLine($"敏捷:{ClassAbilitySet.ClassDex[ClassNum]}");
        Console.WriteLine($"幸運:{ClassAbilitySet.ClassLuk[ClassNum]}");
    }
}