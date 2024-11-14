using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{

    internal class PlayerClass
    {
        Player player = new Player();
        ClassAbilitySet classAbilitySet = new ClassAbilitySet();
        Menu menu = new Menu();
        public bool isSetClass = false;

        public enum pClass 
        {
            warrior,
            ranger,
            thief,
            mage,
        }

        public void SetPlayerClass()
        {
            Console.WriteLine($"您好，勇者{player.GetName()}，請選擇您的職業\n1.戰士\n2.遊俠\n3.盜賊\n4.法師");
            string Anser = Console.ReadLine();
            if (Anser == "1")
            {
                SetClassStats((int)pClass.warrior);
            }
            else if (Anser == "2")
            {
                SetClassStats((int)pClass.ranger);
            }
            else if (Anser == "3")
            {
                SetClassStats((int)pClass.thief);
            }
            else if (Anser == "4")
            {
                SetClassStats((int)pClass.mage);
            }
            else
            {
                Console.WriteLine("已取消，返回選擇選單");
            }
        }

        public void SetClassStats(int classIndex)
        {
            

            classAbilitySet.Show(classIndex);
            bool Anser = menu.Check();
            
            if (Anser)
            {
                classAbilitySet.Set(classIndex);
                player.CalculateDamage();
                isSetClass = true;
            }
        }

        public string GetName(int pClass)
        {
            return classAbilitySet.Class[pClass];
        }
    }
}
