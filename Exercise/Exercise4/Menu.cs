using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class Menu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("[0]結束遊戲 [1]顯示玩家狀態 [2]選擇目標怪物 [3]攻擊 [4]使用炸彈 [5]重生怪物");
        }

        public static bool CheckYesOrNo()
        {
            string input = Console.ReadLine();
            if (input == "y" || input == "Y")
            {
                return true;
            }
            else
            {
                Console.WriteLine("已取消，返回選擇選單");
                return false;
            }
        }
    }
}