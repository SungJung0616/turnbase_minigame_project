using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private const int MaxChargeCount = 3;
        private int ChargeCount { get; set; } = 0;
        private bool IsCharging { get; set; } = false;
        private bool IsEvading { get; set; } = false;   
        private bool IsDefending { get; set; } = false;
        

        public virtual void ShowStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"HP: {HP}, MP: {MP}, Attack: {Attack}, MagicAttack: {MagicAttack} ,Defense: {Defense}");
        }

        public virtual void AttackTarget(Character target)
        {
            int damage = IsCharging ? (int)(Attack * 1.5) : Attack;
            damage -= target.Defense;
            if (damage < 0) damage = 0;

            target.HP -= damage;
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");

            if (IsCharging)
            {
                IsCharging = false; // 기모으기 상태 해제
                Console.WriteLine($"{Name} finishes charging and resets attack power.");
            }
        }

        public virtual void MagicAttackTarget(Character target)
        { 
            if (MP < 10)
            {
                Console.WriteLine($"{Name} does not have enough MP to cast a spell!");
                return;
            }
            MP -= 10;
            int damage = IsCharging ? (int)(MagicAttack *1.2) : MagicAttack;
            
            if (damage < 0) damage = 0;
            target.HP -= damage;
            Console.WriteLine($"{Name} attacks {target.Name} with magic for {damage} damage!");

            if (IsCharging)
            {
                IsCharging = false; // 기모으기 상태 해제
                Console.WriteLine($"{Name} finishes charging and resets attack power.");
            }
        }

        public virtual void Charge()
        {
            if (ChargeCount >= MaxChargeCount)
            {
                Console.WriteLine($"{Name} cannot charge anymore this round!");
                return;
            }
            IsCharging = true;
            ChargeCount++;
            Console.WriteLine($"{Name} is charging! Next attack or magic attack will deal 50% more damage.");
         }

        public virtual void Defend()
        {
            IsDefending = true;
            Console.WriteLine($"{Name} is defending! Incoming physical damage will be reduced to 60%, and magical damage to 85%.");
        }

        public virtual void Evade()
        {
            IsEvading = true;
            Console.WriteLine($"{Name} is evading! Next attack will be completely dodged.");
        }
    }
}
