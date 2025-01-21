using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__DailyStudy.Characters
{
    internal class Enemy : Character
    {
        public Enemy(string name)
        {
            Name = name;
            RandomStatGenerater();
        }

        public void RandomStatGenerater()
        {
            Random random = new Random();
            HP = random.Next(45, 50);
            MP = random.Next(15, 20);
            Attack = random.Next(15, 20);
            MagicAttack = random.Next(15, 20);
            Defense = random.Next(3, 6);
        }
    }
}
