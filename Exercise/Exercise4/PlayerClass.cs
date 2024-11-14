using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{

    internal class PlayerClass
    {
        //Player player = new Player();
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



        //public void SetClassStats(int classIndex)
        //{
            

        //    classAbilitySet.Show(classIndex);
        //    bool Anser = menu.Check();
            
        //    if (Anser)
        //    {
        //        classAbilitySet.Set(classIndex);
        //        player.CalculateDamage();
        //        isSetClass = true;
        //    }
        //}

        public string GetName(int pClass)
        {
            return classAbilitySet.Class[pClass];
        }

        public void ShowAbility(int classIndex)
        {

        }
    }
}
