using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class Bag
    {

        public int[] bag = new int[5] { 0, 0, 0, 0, 0 };

        public string GetItemName(int position)
        {
            int item = bag[position];
            if (item == 0)
            {
                return "空";
            }
            else if (item == 1)
            {
                return "炸彈";
            }
            else
            {
                return "空";
            }

        }
        public void ShowBag()
        {
            Console.WriteLine($"||{GetItemName(0)}||{GetItemName(1)}||{GetItemName(2)}||{GetItemName(3)}||{GetItemName(4)}||");
        }

        public void AddToBag()
        {
            bool IsAdd = false;
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] == 0 && IsAdd == false)
                {
                    bag[i] = 1;
                    IsAdd = true;
                    break;
                }
            }
            if (IsAdd == false)
            {
                Console.WriteLine("背包已滿，炸彈已被丟棄");
            }
        }

        public bool CheckBoom()
        {
            for (int i = 0; i < bag.Length; i++)
            {
                if (bag[i] == 1)
                {
                    bag[i] = 0;
                    return true;
                }
            }
            return false;
        }

    }
}
