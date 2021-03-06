using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;
    using static Common.GlobalConstants;
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

        public Room FindRoomByName(string name)
        {
            var room = this.rooms
                .FirstOrDefault(x => 
                    string.Equals(x.Name, name, 
                        StringComparison
                            .CurrentCultureIgnoreCase));

            if (room == null)
            {
                throw new ArgumentException(NonExistingRoomExceptionMsg);
            }

            return room;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Separator);

            sb.Append(AvailableRoomsMsg);

            var roomNames = this.rooms
                .Select(x => x.Name)
                .ToArray();

            sb.Append(string.Join(", ", roomNames));

            return sb.ToString().Trim();
        }
    }
}