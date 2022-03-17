namespace Survivor.Models.Common
{
    public static class ExceptionMessages
    {
        public const string InvalidNameExceptionMsg =
            "Name cannot be null or whitespace!";

        public const string InvalidCapacityExceptionMsg =
            "Backpack capacity cannot be less than 0 kg!";

        public const string InvalidWeightExceptionMsg =
            "Weight cannot be less than 0!";

        public const string UnableToAddItemToBackpackExceptionMsg =
            "Item cannot be added! Not enough backback capacity!";

        public const string NonExistingItemExceptionMsg =
            "Backpack does not contain such item!";
        
        public const string NonExistingMonsterExceptionMsg =
            "Monster does not exist!";
        
        public const string NonExistingExitExceptionMsg =
            "Exit does not exist!";

        public const string NonExistingRoomExceptionMsg =
            "Room does not exist!";

        public const string PlayerNotInRoomExceptionMsg =
            "Player is currently not in any room!";

        public const string NullItemExceptionMsg =
            "Item cannot be null!";
        
        public const string NullMonsterExceptionMsg =
            "Monster cannot be null!";

        public const string InvalidDamageExceptionMsg =
            "Damage cannot be less or equal to 0!";
    }
}