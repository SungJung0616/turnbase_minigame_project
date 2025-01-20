using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__DailyStudy.Characters;

namespace C__DailyStudy.GameLogic
{
    internal class GameLogic
    {
        private Player player;
        private Enemy enemy;
        private int currentRound = 1;
        private Random random = new Random();
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Enter your Character's name: ");
            string name = Console.ReadLine();
            player = new Player(name);

            StartRound();

        }

        public void StartRound()
        {
            Console.Clear();
            Console.WriteLine($"Round {currentRound} Start!");
            Console.WriteLine("----------------------------");

            enemy = new Enemy("Goblin");
            if (enemy == null)
            {
                Console.WriteLine("You have defeated all the enemies! Congratulations!");
                return;
            }

            Console.WriteLine($"\nEnemy Appears: {enemy.Name}");

            bool isPlayerAttacking = random.Next(2) == 0;

            if (isPlayerAttacking)
            {
                Console.WriteLine($"{player.Name} is attacking first!");
                ExcuteTurn(player, enemy, true);
                ExcuteTurn(enemy, player, false);
            }
            else
            {
                Console.WriteLine($"{enemy.Name} is attacking first!");
                ExcuteTurn(enemy, player, true);
                ExcuteTurn(player, enemy, false);
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine($"Round {currentRound} End!");
            Console.WriteLine($"{player.Name} HP: {player.HP}, MP: {player.MP}");
            Console.WriteLine($"{enemy.Name} HP: {enemy.HP}");
            Console.WriteLine("Press any key to continue to the next round...");
            Console.ReadKey();

            // 라운드 진행
            currentRound++;
            if (player.HP > 0 && enemy.HP > 0)
            {
                StartRound();
            }
            else
            {
                EndGame(player.HP > 0);
            }
        }

        private void ExcuteTurn(Character attacker, Character defender, bool isAttacking)
        {
            int selectedIndex = 0;
            string[] menuItems = { "Attack","Mgic Attack" ,"Charge"};

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

                }
            }

            if (isAttacking)
            {
                Console.WriteLine($"\n{attacker.Name}'s turn to attack!");
            }
        }

        private void EndGame()
        { 
        }
    }
}
