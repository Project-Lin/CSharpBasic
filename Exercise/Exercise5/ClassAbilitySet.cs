namespace Exercise4
{
    internal class ClassAbilitySet
    {
        public const string WorriorName = "戰士";
        public const int WorriorClassNumber = 0;
        public const int WorriorStr = 10;
        public const int WorriorInt = 1;
        public const int WorriorDex = 5;
        public const int WorriorLuk = 2;

        public const string RangerName = "遊俠";
        public const int RangerClassNumber = 1;
        public const int RangerStr = 5;
        public const int RangerInt = 2;
        public const int RangerDex = 10;
        public const int RangerLuk = 1;

        public const string ThiefName = "盜賊";
        public const int ThiefClassNumber = 2;
        public const int ThiefStr = 2;
        public const int ThiefInt = 1;
        public const int ThiefDex = 5;
        public const int ThiefLuk = 10;

        public const string MageName = "法師";
        public const int MageClassNumber = 3;
        public const int MageStr = 1;
        public const int MageInt = 10;
        public const int MageDex = 4;
        public const int MageLuk = 3;

        public static string[] ClassName = new string[] { WorriorName, RangerName, ThiefName, MageName };
        public static int[] ClassStr = new int[] { WorriorStr, RangerStr, ThiefStr, MageStr };
        public static int[] ClassInt = new int[] { WorriorInt, RangerInt, ThiefInt, MageInt };
        public static int[] ClassDex = new int[] { WorriorDex, RangerDex, ThiefDex, MageDex };
        public static int[] ClassLuk = new int[] { WorriorLuk, RangerLuk, ThiefLuk, MageLuk };
    }
}