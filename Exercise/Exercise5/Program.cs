namespace Exercise5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = GameManager.Instance();
            Menu menu = new Menu();

            while (true)
            {
                if (!LogInSystem.isLoggedIn)
                {
                    gameManager.InitializeGame();
                }

                gameManager.StartGame();
            }
        }
    }
}