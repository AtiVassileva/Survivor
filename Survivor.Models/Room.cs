using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Item FindItem(string itemName)
        {
            var item = this.items
                .FirstOrDefault(x => 
                    string.Equals(x.Name, itemName, 
                        StringComparison.CurrentCultureIgnoreCase));

            if (item == null)
            {
                throw new ArgumentException(NonExistingItemExceptionMsg);
            }

            return item;
        }

        public void AddExit(Exit exit) => this.exits.Add(exit);

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Available items:");

            if (!this.Items.Any())
            {
                sb.AppendLine("No available items.");
            }
            else
            {
                foreach (var item in this.items)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            sb
                .Append("Exits: ")
                .AppendLine(string.Join(", ", this.exits
                    .Select(x => x.Name)));
            
            sb.AppendLine(new string('-', 70));
            return sb.ToString().Trim();
        }
    }
}