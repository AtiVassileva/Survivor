using System;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;
    public class Monster
    {
        private readonly string name;
        private readonly int damage;

        public Monster(string name, int damage)
        {
            this.Name = name;
            this.Damage = damage;
        }

        public string Name
        {
            get => this.name;
            private init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidNameExceptionMsg);
                }

                this.name = value;
            }
        }

        public int Damage
        {
            get => this.damage;
            private init
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidDamageExceptionMsg);
                }

                this.damage = value;
            }
        }

        public override string ToString() 
            => $"{this.Name} (damage: {this.Damage})";
    }
}
