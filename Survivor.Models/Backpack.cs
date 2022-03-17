using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;
    using static Common.GlobalConstants;

    public class Backpack
    {
        private readonly int capacityInKg;
        private readonly ICollection<Item> items;

        public Backpack(int capacityInKg)
        {
            this.CapacityInKg = capacityInKg;
            this.items = new List<Item>();
        }

        public int CapacityInKg
        {
            get => this.capacityInKg;
            private init
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCapacityExceptionMsg);
                }

                this.capacityInKg = value;
            }
        }

        public ICollection<Item> Items => this.items;

        private double AllItemsWeight => this.items.Sum(x => x.Weight);

        public void AddItem(Item item)
        {
            if (item.Weight + AllItemsWeight > this.CapacityInKg)
            {
                throw new ArgumentException(UnableToAddItemToBackpackExceptionMsg);
            }

            if (item == null)
            {
                throw new NullReferenceException(NullItemExceptionMsg);
            }

            this.items.Add(item);
        }

        public void DropItem(Item item)
        {
            if (!ContainsItem(item) || item == null)
            {
                throw new ArgumentException(NonExistingItemExceptionMsg);
            }

            this.items.Remove(item);
        }

        public Item FindItem(string itemName)
        {
            var item = this.Items
                .FirstOrDefault(x => string.Equals(x.Name, itemName, 
                    StringComparison.CurrentCultureIgnoreCase));

            if (item == null)
            {
                throw new ArgumentException(NonExistingItemExceptionMsg);
            }

            return item;
        }
        public bool ContainsItem(Item item) => this.items.Contains(item);

        public string ShowItems()
        {
            var sb = new StringBuilder();

            if (!this.Items.Any())
            {
                sb.AppendLine(NoItemsInBackpackMsg);
            }
            else
            {
                sb.AppendLine(AvailableItemsMsg);

               foreach (var item in this.Items)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            sb.AppendLine(Separator);
            return sb.ToString().Trim();
        }
    }
}