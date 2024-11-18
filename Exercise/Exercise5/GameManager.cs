namespace Exercise5
{
    internal class GameManager
    {
        private static GameManager isInstance = null;
        //public static List<Player> playerList = new List<Player>();
        public static Player player = new Player("null");
        int LogInPlayerID;
        public List<Mob> mobList = new List<Mob>();
        bool isSetClass = false;

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
            player = LogInSystem.LogIn();
            if(player.playerClass == null)
            {
                while (!isSetClass)
                {

                }
            }
            
            loadSave();
        }

        private void loadSave()
        {

        }

    }
}
