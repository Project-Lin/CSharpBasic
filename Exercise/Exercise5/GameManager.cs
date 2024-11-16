using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    internal class GameManager
    {
        private static GameManager isInstance = null;
        public List<Player> playerList = new List<Player>();
        int LogInPlayerID;
        public List<Mob> mobList = new List<Mob>();

        private GameManager()
        {
        }

        public static GameManager Instance()
        {
            if (isInstance == null)
            {
                isInstance = new GameManager();
            }

            return isInstance;
        }

        public void InitializeGame()
        {
            LogIn();
            loadSave();
            
        }

        private void loadSave() 
        {
            
        }
        
    }
}
