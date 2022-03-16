using System;
using System.Linq;
using System.Text;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;

    public class Player
    {
        private readonly string name;

        public Player(string name, Backpack backpack)
        {
            this.Name = name;
            this.Backpack = backpack;
        }

        public string Name
        {
            get => this.name;
            private init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidNameExceptionMsg);
                }

                this.name = value;
            }
        }

        public Backpack Backpack { get; }

        public Room CurrentRoom { get; private set; }

        public string GetCurrentLocation()
        {
            if (this.CurrentRoom == null)
            {
                return PlayerNotInRoomExceptionMsg;
            }

            var sb = new StringBuilder();

            sb.AppendLine($"Current location: {this.CurrentRoom.Name}")
                .Append("Available exits: ")
                .Append(string.Join(", ", 
                this.CurrentRoom.Exits
                .Select(x => x.Name)));

            return sb.ToString().Trim();
        }

        public void ChangeCurrentRoom(Room nextRoom) => this.CurrentRoom = nextRoom;
    }
}