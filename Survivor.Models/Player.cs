using System;
using System.Collections.Generic;

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
            => CurrentRoom == null 
                ? "Player is currently not in any room" 
                : CurrentRoom.Name;

        public void ChangeCurrentRoom(Room nextRoom) => this.CurrentRoom = nextRoom;
    }
}