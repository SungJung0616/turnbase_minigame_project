// See https://aka.ms/new-console-template for more information
using C__DailyStudy.Characters; 


class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Do you want to start you story? ");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");
        Console.WriteLine("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            Console.WriteLine("Let's start the story!");
        }
        else
        {
            Console.WriteLine("Goodbye!");
            return;
        }

        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Player player = new Player(name);
        player.ShowStats();

        int choice2 = 0;

        while (choice2 != 3) { 

            Console.WriteLine("Do you really want keep this name and stats?");
            Console.WriteLine("Which one do you want to change?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Stats");
            Console.WriteLine("3. Yes, Start the Game");
            Console.WriteLine("Enter your choice: ");

            choice2 = Convert.ToInt32(Console.ReadLine());
            if (choice2 == 1)
            {
                Console.WriteLine("You Choice Name. Enter you new Name");
                string newName = Console.ReadLine();
                player.ChangeName(newName);
                player.ShowStats();

            }
            else if (choice2 == 2)
            {
                Console.WriteLine("You Choice Stats. Here is your new Stats");
                player.RandomStatGenerater();
                player.ShowStats();
            }
            else if (choice2 == 3)
            {
                Console.WriteLine("Great! Let's start the game!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

}

