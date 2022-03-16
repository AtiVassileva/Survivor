using System;
using System.Collections.Generic;
using System.Linq;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;

    public class Maze
    {
        private readonly ICollection<Room> rooms;

        public Maze(Player player)
        {
            this.Player = player;
            this.rooms = new HashSet<Room>();
        }

        public Player Player { get;}

        public ICollection<Room> Rooms => this.rooms;

        public void AddRoom(Room room) => this.rooms.Add(room);

        public bool ContainsRoom (Room room) => this.rooms.Contains(room);

        public Room FindRoomByName(string name)
        {
            var room = this.rooms
                .FirstOrDefault(x => x.Name == name);

            if (room == null)
            {
                throw new ArgumentException(NonExistingRoomExceptionMsg);
            }

            return room;
        }
    }
}