using System;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;

    public  class Item
    {
        private readonly string name;
        private readonly double weight;

        public Item(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
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

        public double Weight
        {
            get => this.weight;
            private init
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException(InvalidWeightExceptionMsg);
                }

                this.weight = value;
            }
        }
    }
}