using Survivor.Models;
using Survivor.Models.Enums;

namespace Survivor.Factories
{
    public static class ItemFactory
    {
        public static Item CreateItem(string name, double weight, Category category) 
            => new Item(name, weight, category);
    }
}