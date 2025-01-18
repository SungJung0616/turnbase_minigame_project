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
        public static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Enter your Character's name: ");
            string name = Console.ReadLine();

            Player player = new Player(name);
            Console.WriteLine("\nGenerating random stats for your character... ");
            player.RandomStatGenerater();
            player.ShowStats();

        }
    }
}
