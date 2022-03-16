using System;
using System.Collections.Generic;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;

    public class Room
    {
        private readonly string name;
        private readonly ICollection<Item> items;
        private readonly ICollection<Exit> exits;

        public Room(string name)
        {
            this.Name = name;
            this.items = new List<Item>();
            this.exits = new List<Exit>();
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

        public ICollection<Item> Items => this.items;

        public ICollection<Exit> Exits => this.exits;

        public void AddItem(Item item) => this.items.Add(item);

        public void RemoveItem(Item item)
        {
            if (!this.items.Contains(item))
            {
                throw new ArgumentException();
            }

            this.items.Remove(item);
        }

        public void AddExit(Exit exit) => this.exits.Add(exit);
    }
}