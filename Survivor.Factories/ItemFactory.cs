using Survivor.Models;

namespace Survivor.Factories
{
    public static class ItemFactory
    {
        public static Item CreateItem(string name, double weight) => new Item(name, weight);
    }
}
