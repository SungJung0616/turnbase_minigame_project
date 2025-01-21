// See https://aka.ms/new-console-template for more information
using C__DailyStudy.Characters; 
using C__DailyStudy.GameLogic;


class MainClass
{
    public static void Main(string[] args)
    {
        int selectedIndex = 0;
        string[] menuItems = { "Start Game", "Customize Character", "Load Game", "Exit" };
        GameLogic GameLogic = new GameLogic();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(menuItems[i]);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(menuItems[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= menuItems.Length)
                {
                    selectedIndex = 0;
                }
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = menuItems.Length - 1;
                }
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("You have selected: " + menuItems[selectedIndex]);
                if (selectedIndex == 0)
                {
                    Console.WriteLine("Let's start the game!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    GameLogic.StartGame();
                    
                }
                else if (selectedIndex == 1)
                {
                    Console.WriteLine("Customize Character");
                }
                else if (selectedIndex == 2)
                {
                    Console.WriteLine("Load Game");
                }
                else if (selectedIndex == 3)
                {
                    Console.WriteLine("Exit");
                    break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

}



