using Survivor.Models;

namespace Survivor.Factories
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(string name, Backpack backpack) => new Player(name, backpack);
    }
}
