using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__DailyStudy.Characters
{
    internal class Player : Character
    {
        public Player(string name)
        {
            Name = name;
            RandomStatGenerater();
        }

        public void RandomStatGenerater()
        {
            Random random = new Random();
            HP = random.Next(95, 100);
            MP = random.Next(15, 20);
            Attack = random.Next(15, 20);
            MagicAttack = random.Next(15, 20);
            Defense = random.Next(3, 6);
        }

        public void ChangeName(string newName)
        {
            Name = newName;
            Console.WriteLine($"Name changed to {Name}");
        }
    }
}
