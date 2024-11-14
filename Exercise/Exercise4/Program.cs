namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            Menu menu = new Menu();
            gameManager.InitializeGame() ;
            while (!gameManager.isQuit)
            {
                menu.DisplayMenu();
                menu.HandleUserInput();
            }
        }
    }
}
