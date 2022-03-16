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
        private readonly ICollection<Monster> monsters;

        public Room(string name)
        {
            this.Name = name;
            this.items = new List<Item>();
            this.exits = new List<Exit>();
            this.monsters = new List<Monster>();
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

        public ICollection<Monster> Monsters => this.monsters;

        public void AddItem(Item item)
        {
            if (item == null)
            {
                throw new InvalidOperationException(NullItemExceptionMsg);
            }

            this.items.Add(item);
        }

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

        public void AddMonster(Monster monster)
        {
            if (monster == null)
            {
                throw new InvalidOperationException(NullMonsterExceptionMsg);
            }

            this.monsters.Add(monster);
        }

        public void RemoveMonster(Monster monster)
        {
            if (monster == null || !this.monsters.Contains(monster))
            {
                throw new InvalidOperationException(NullMonsterExceptionMsg);
            }

            this.monsters.Remove(monster);
        }

        public Monster FindMonster(string monsterName)
        {
            var monster = this.monsters
                .FirstOrDefault(x =>
                    string.Equals(x.Name, monsterName,
                        StringComparison.CurrentCultureIgnoreCase));

            if (monster == null)
            {
                throw new ArgumentException(NonExistingMonsterExceptionMsg);
            }

            return monster;
        }

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
            
            sb
                .AppendLine("Monsters: ")
                .AppendLine(string.Join("\n", this.monsters
                    .Select(x => x.ToString())));
            
            
            sb.AppendLine(new string('-', 70));
            return sb.ToString().Trim();
        }
    }
}