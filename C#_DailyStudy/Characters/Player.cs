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
            HP = 100;
            MP = 20;
            Attack = 20;
            MagicAttack = 10;
            Defense = 10;
        }
    }
}
