using System.Xml;

namespace Survivor.Models.Common
{
    public static class GlobalConstants
    {
        public const string Separator
            = "----------------------------------------------------";

        public const string NoItemsInBackpackMsg 
            = "No items in backpack.";

        public const string AvailableItemsMsg
            = "Picked up items: ";

        public const string AvailableRoomsMsg
            = "Maze available rooms: ";

        public const string NoAvailableItemsMsg
            = "No available items.";

        public const string NoWeaponMsg
            = "You need a weapon to fight a monster!";

        public const string DefeatedByMonsterMsg
            = "You die! {0} defeated you!";

        public const string DefeatedMonsterMsg
            = "Congratulations! You defeated {0}! {1}";

        public const string SuccessfullyExitedRoomMsg
            = "Successfully exited {0}";

        public const string FailedExecutionMsg
            = "You need an item of type {0} in order to exit through a {1}!";
    }
}
