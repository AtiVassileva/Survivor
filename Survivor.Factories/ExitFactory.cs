using Survivor.Models;
using Survivor.Models.Enums;

namespace Survivor.Factories
{
    public static class ExitFactory
    {
        public static Exit CreateExit(string name, ExitType exitType) => new Exit(name, exitType);
    }
}