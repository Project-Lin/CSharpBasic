namespace Exercise4
{
    internal class ClassAbilitySet
    {
        public string[] Class = new string[] { "戰士", "遊俠", "盜賊", "法師" };

        public int warriorClass = 0;
        public int warriorStr = 10;
        public int warriorInt = 1;
        public int warriorDex = 5;
        public int warriorLuk = 2;

        public int rangerClass = 1;
        public int rangerStr = 5;
        public int rangerInt = 2;
        public int rangerDex = 10;
        public int rangerLuk = 1;

        public int thiefClass = 2;
        public int thiefStr = 2;
        public int thiefInt = 1;
        public int thiefDex = 5;
        public int thiefLuk = 10;

        public int mageClass = 3;
        public int mageStr = 1;
        public int mageInt = 10;
        public int mageDex = 4;
        public int mageLuk = 3;

        public void Show(int _Class)
        {
            switch (_Class)
            {
                case 0:
                    Console.WriteLine($"{Class[_Class]}");
                    Console.WriteLine($"力量:{warriorStr}");
                    Console.WriteLine($"智力:{warriorInt}");
                    Console.WriteLine($"敏捷:{warriorDex}");
                    Console.WriteLine($"幸運:{warriorLuk}");
                    Console.WriteLine($"\n確定要選擇{Class[_Class]}嗎?(Y/N)");
                    break;

                case 1:
                    Console.WriteLine($"{Class[_Class]}");
                    Console.WriteLine($"力量:{rangerStr}");
                    Console.WriteLine($"智力:{rangerInt}");
                    Console.WriteLine($"敏捷:{rangerDex}");
                    Console.WriteLine($"幸運:{rangerLuk}");
                    Console.WriteLine($"\n確定要選擇{Class[_Class]}嗎?(Y/N)");
                    break;

                case 2:
                    Console.WriteLine($"{Class[_Class]}");
                    Console.WriteLine($"力量:{thiefStr}");
                    Console.WriteLine($"智力:{thiefInt}");
                    Console.WriteLine($"敏捷:{thiefDex}");
                    Console.WriteLine($"幸運:{thiefLuk}");
                    Console.WriteLine($"\n確定要選擇{Class[_Class]}嗎?(Y/N)");
                    break;
                
                case 3:
                    Console.WriteLine($"{Class[_Class]}");
                    Console.WriteLine($"力量:{mageStr}");
                    Console.WriteLine($"智力:{mageInt}");
                    Console.WriteLine($"敏捷:{mageDex}");
                    Console.WriteLine($"幸運:{mageLuk}");
                    Console.WriteLine($"\n確定要選擇{Class[_Class]}嗎?(Y/N)");
                    break;
            }


        }

        public void Set(int Class)
        {
            Player player = new Player();
            switch (Class)
            {
                case 0:
                    player.Class = warriorClass;
                    player.Str = warriorStr;
                    player.Int = warriorInt;
                    player.Dex = warriorDex;
                    player.Luk = warriorLuk;
                    break;

                case 1:
                    player.Class = rangerClass;
                    player.Str = rangerStr;
                    player.Int = rangerInt;
                    player.Dex = rangerDex;
                    player.Luk = rangerLuk;
                    break;

                case 2:
                    player.Class = thiefClass;
                    player.Str = thiefStr;
                    player.Int = thiefInt;
                    player.Dex = thiefDex;
                    player.Luk = thiefLuk;
                    break;

                case 3:
                    player.Class = mageClass;
                    player.Str = mageStr;
                    player.Int = mageInt;
                    player.Dex = mageDex;
                    player.Luk = mageLuk;
                    break;
            }


        }
    }
}
