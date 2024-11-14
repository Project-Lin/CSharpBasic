using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class GameManager
    {
        Monster monster = new Monster();
        Player player = new Player();
        PlayerClass playerClass = new PlayerClass();
        public bool isQuit = false;
        public void InitializeGame()
        {
            player.SetName();
            while (!playerClass.isSetClass)
            {
                playerClass.SetPlayerClass();
            }
        }

        public void QuitGame()
        {
            Console.WriteLine("將會遺失遊戲資料，確定要退出遊戲嗎?(Y/N)");
            string Anser = Console.ReadLine();
            if (Anser == "y" || Anser == "Y")
            {
                isQuit = true;
            }
        }

        public string GetPlayerName()
        {
            string name = player.Name;
            return name;
        }

        public void ShowPlayerState()
        {
            player.ShowState();
        }

    }
}
