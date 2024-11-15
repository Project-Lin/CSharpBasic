using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class PlayerAbility
    {
        public enum pClass
        {
            warrior,
            ranger,
            thief,
            mage,
        }

        public bool isSetClass = false;

        public string className = null;
        public int classNumber = -1;
        public int str = 0;
        public int Int = 0;
        public int dex = 0;
        public int luk = 0;

        public PlayerAbility(string _name, int _classNumber, int _str, int _Int, int _dex, int _luk)
        {
            classNumber = _classNumber;
            str = _str;
            Int = _Int;
            dex = _dex;
            luk = _luk;
        }

        public PlayerAbility(int _classNumber)
        {
            switch (_classNumber)
            {
                case 0:
                    SetAbility(0);
                    break;
                case 1:
                    SetAbility(1);
                    break;
                case 2:
                    SetAbility(2);
                    break;
                case 3:
                    SetAbility(3);
                    break;
            }
        }

        public PlayerAbility()
        {
        }


        public void SetAbility(int _classNumber)
        {
            className = $"{ClassAbilitySet.ClassName[_classNumber]}";
            classNumber = _classNumber;
            str = ClassAbilitySet.ClassStr[_classNumber];
            Int = ClassAbilitySet.ClassInt[_classNumber];
            dex = ClassAbilitySet.ClassDex[_classNumber];
            luk = ClassAbilitySet.ClassLuk[_classNumber];
        }
    }
}