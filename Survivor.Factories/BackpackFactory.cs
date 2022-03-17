using Survivor.Models;

namespace Survivor.Factories
{
    public static class BackpackFactory
    {
        public static Backpack CreateBackpack(int capacity) => new Backpack(capacity);
    }
}