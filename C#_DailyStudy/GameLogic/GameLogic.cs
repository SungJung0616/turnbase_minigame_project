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

            Console.WriteLine("\nWelcome to the game, " + player.Name + "!");
            Console.WriteLine("Press any key to start the first round...");
            Console.ReadKey();

            while(player.HP > 0)
            {
                StartRound();
                if (enemy.HP <= 0)
                {
                    Console.WriteLine($"You defeated {enemy.Name}!");
                    EndGame(player.HP > 0);
                }
                currentRound++;
                Console.WriteLine($"currentRound : {currentRound} ");
            }            
        }

        public void StartRound()
        {
            Console.Clear();
            Console.WriteLine($"Round {currentRound} Start!");
            Console.WriteLine("----------------------------");

            // 적 생성
            enemy = new Enemy("Goblin");
            Console.WriteLine($"Enemy Appears: {enemy.Name}");

            // 누가 먼저 공격할지 랜덤 결정
            bool isPlayerAttacking = random.Next(2) == 0;

            // 전반부
            if (isPlayerAttacking)
            {
                Console.WriteLine($"{player.Name} is attacking first!");
                ExecuteTurn(player, enemy, true);  // 플레이어 공격
                ExecuteTurn(enemy, player, false); // 적 방어
            }
            else
            {
                Console.WriteLine($"{enemy.Name} is attacking first!");
                ExecuteTurn(enemy, player, true);  // 적 공격
                ExecuteTurn(player, enemy, false); // 플레이어 방어
            }

            // 후반부 (공격자와 방어자 교대)
            if (isPlayerAttacking)
            {
                ExecuteTurn(enemy, player, true);  // 적 공격
                ExecuteTurn(player, enemy, false); // 플레이어 방어
            }
            else
            {
                ExecuteTurn(player, enemy, true);  // 플레이어 공격
                ExecuteTurn(enemy, player, false); // 적 방어
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine($"Round {currentRound} End!");
            Console.WriteLine($"{player.Name} HP: {player.HP}, MP: {player.MP}");
            Console.WriteLine($"{enemy.Name} HP: {enemy.HP}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // 다음 라운드로 진행
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


        private void ExecuteTurn(Character attacker, Character defender, bool isAttacking)
        {
            if (isAttacking)
            {
                Console.WriteLine($"\n{attacker.Name}'s turn to attack!");

                if (attacker is Player) // 플레이어의 공격
                {
                    string[] attackOptions = { "Attack", "Magic Attack", "Charge" };
                    int selectedIndex = 0;

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"{attacker.Name}'s turn to attack!");
                        for (int i = 0; i < attackOptions.Length; i++)
                        {
                            if (i == selectedIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine($"> {attackOptions[i]}");
                            }
                            else
                            {
                                Console.ResetColor();
                                Console.WriteLine($"  {attackOptions[i]}");
                            }
                        }
                        Console.ResetColor();

                        ConsoleKey key = Console.ReadKey(true).Key;

                        if (key == ConsoleKey.UpArrow)
                        {
                            selectedIndex--;
                            if (selectedIndex < 0) selectedIndex = attackOptions.Length - 1;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedIndex++;
                            if (selectedIndex >= attackOptions.Length) selectedIndex = 0;
                        }
                        else if (key == ConsoleKey.Enter)
                        {
                            switch (selectedIndex)
                            {
                                case 0:
                                    attacker.AttackTarget(defender);
                                    break;
                                case 1:
                                    attacker.MagicAttackTarget(defender);
                                    break;
                                case 2:
                                    attacker.Charge();
                                    break;
                            }
                            break;
                        }
                    }
                }
                else // 적의 공격 (랜덤)
                {
                    int enemyAction = random.Next(3);
                    switch (enemyAction)
                    {
                        case 0:
                            attacker.AttackTarget(defender);
                            break;
                        case 1:
                            attacker.MagicAttackTarget(defender);
                            break;
                        case 2:
                            attacker.Charge();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"\n{defender.Name}'s turn to defend!");

                if (defender is Player) // 플레이어의 방어
                {
                    string[] defenseOptions = { "Defend", "Evade" };
                    int selectedIndex = 0;

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"{defender.Name}'s turn to defend!");
                        for (int i = 0; i < defenseOptions.Length; i++)
                        {
                            if (i == selectedIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine($"> {defenseOptions[i]}");
                            }
                            else
                            {
                                Console.ResetColor();
                                Console.WriteLine($"  {defenseOptions[i]}");
                            }
                        }
                        Console.ResetColor();

                        ConsoleKey key = Console.ReadKey(true).Key;

                        if (key == ConsoleKey.UpArrow)
                        {
                            selectedIndex--;
                            if (selectedIndex < 0) selectedIndex = defenseOptions.Length - 1;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedIndex++;
                            if (selectedIndex >= defenseOptions.Length) selectedIndex = 0;
                        }
                        else if (key == ConsoleKey.Enter)
                        {
                            switch (selectedIndex)
                            {
                                case 0:
                                    defender.Defend();
                                    break;
                                case 1:
                                    defender.Evade();
                                    break;
                            }
                            break;
                        }
                    }
                }
                else // 적의 방어 (랜덤)
                {
                    int enemyAction = random.Next(2);
                    switch (enemyAction)
                    {
                        case 0:
                            defender.Defend();
                            break;
                        case 1:
                            defender.Evade();
                            break;
                    }
                }
            }
        }

        private void EndGame(bool playerWon)
        {
            Console.Clear();
            if (playerWon)
            {
                Console.WriteLine("Congratulations! You won the game!");
            }
            else
            {
                Console.WriteLine("Game Over! Better luck next time.");
            }
            Console.WriteLine("Press any key to return to the Main Menu...");
            Console.ReadKey();
        }
    }
}
