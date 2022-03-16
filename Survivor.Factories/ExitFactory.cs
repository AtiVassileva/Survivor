using Survivor.Models;

namespace Survivor.Factories
{
    public static class ExitFactory
    {
        public static Exit CreateExit(string name) => new Exit(name);
    }
}