namespace Exercise5
{
    internal class GameManager
    {
        private static GameManager isInstance = null;
        public Menu menu = new Menu();
        public static Player player = new Player("null");
        int LogInPlayerID;
        public List<Mob> mobList = new List<Mob>();
        bool isSetClass = false;
        public ExploreSystem exploreSystem = new ExploreSystem();
        public static bool startExplore = false;

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

            while (player.playerClass == null)
            {
                player.SetPlayerClass();
                menu.SettingClassMenu(player.playerClass);
                
            }

        }

        public void StartGame()
        {
            while (true)
            {
                if (!LogInSystem.isLoggedIn || player == null)
                {
                    return;
                }

                while (!startExplore)
                {
                    menu.MainMenu();
                }

                ExploreSystem.isCompleteTheLevel = false;
                while (!ExploreSystem.isCompleteTheLevel)
                {
                    StartExplore();
                }
            }
        }

        private void StartExplore()
        {
            if (player == null) return;
            
            player.CalculateDamage();
            exploreSystem.CreateScenes();
            
        }
    }
}