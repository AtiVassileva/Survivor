using System;
using Survivor.Models.Enums;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;

    public  class Item
    {
        private readonly string name;
        private readonly double weight;

        public Item(string name, double weight, Category category)
        {
            this.Name = name;
            this.Weight = weight;
            this.Category = category;
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

        public Category Category { get; }

        public override string ToString() 
            => $"{this.Name} ({this.Weight} kg.) - {this.Category}";
    }
}