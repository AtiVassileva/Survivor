using Survivor.Models;

namespace Survivor.Factories
{
    public static class RoomFactory
    {
        public static Room CreateRoom(string name) => new Room(name);
    }
}