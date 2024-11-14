using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class Menu
    {
        GameManager gameManager = new GameManager();
        //Player player = new Player();
        Attack attack = new Attack();
        //Monster monster = new Monster();

        public void DisplayMenu()
        {
            Console.WriteLine("[0]結束遊戲 [1]顯示玩家狀態 [2]選擇目標怪物 [3]攻擊 [4]使用炸彈 [5]重生怪物");
        }
        public void HandleUserInput()
        {
            
            string Anser = Console.ReadLine();
            if (Anser == "0")
            {
                gameManager.QuitGame();
            }
            else if (Anser == "1")
            {
                gameManager.ShowPlayerState();
            }
            else if (Anser == "2")
            {
                attack.SelectAttackTarget();
            }
            else if (Anser == "3")
            {
                attack.NormalAttack();
            }
            else if (Anser == "4")
            {
                attack.UseBoom();
            }
            else if (Anser == "5")
            {
                monster.ReviveMonster();
            }
            else
            {
                Console.WriteLine("請輸入正確指令");
            }
        }

        public bool Check()
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
