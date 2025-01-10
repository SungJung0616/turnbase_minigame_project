using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__DailyStudy.Characters
{
    internal class Character
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Attack { get; set; }
        public int MagicAttack { get; set; }
        public int Defense { get; set; }

        public virtual void ShowStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"HP: {HP}, Attack: {Attack}, MagicAttack: {MagicAttack} ,Defense: {Defense}");
        }

        public virtual void AttackTarget(Character target)
        {
            int damage = Attack - target.Defense;
            if (damage < 0) damage = 0;

            target.HP -= damage;
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
        }

        public virtual void MagicAttackTarget(Character target)
        {
            if (MP < 10)
            {
                Console.WriteLine($"{Name} does not have enough MP to cast a spell!");
                return;
            }
            MP -= 10;
            int damage = MagicAttack;
            if (damage < 0) damage = 0;
            target.HP -= damage;
            Console.WriteLine($"{Name} attacks {target.Name} with magic for {damage} damage!");
        }


    }
}
