using System.Collections.Generic;

namespace Survivor.Core.Common
{
    public static class GlobalConstants
    {
        public const string WelcomeMessage =
            "Welcome, {0}! Enter a command... (type 'help' if you need some.)";

        public const string CommandMessage = "Your command: ";

        public const string QuitCommand = "quit";

        public const string WelcomeToRoomMessage =
            "Welcome to {0}! {1}";

        public const string SuccessfullyPickedUpItemMessage =
            "Successfully picked up {0}! {1}";
        
        public const string SuccessfullyDroppedItemMessage =
            "Successfully dropped {0}!";

        public const string GoodbyeMsg = "Goodbye survivor!";
    }
}
