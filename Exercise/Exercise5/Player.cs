using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    internal class Player
    {
        public string name;
        public int level,hp,hpMax,damage,exp,expMax;
        public int str, dex, Int, luk;


        public Player(string _name)
        {
            name = _name;
        }

        public void ShowInfo()
        {
            Console.WriteLine(name);
        }
    }
}
