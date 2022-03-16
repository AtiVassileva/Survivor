using System;
using System.Linq;
using System.Text;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;

    public class Player
    {
        private const int MaxHealth = 100;

        private readonly string name;
        private int health;

        public Player(string name, Backpack backpack)
        {
            this.Name = name;
            this.Backpack = backpack;
            this.health = MaxHealth;
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

        public int Health => this.health;

        public bool IsDead => this.Health <= 0;

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

        public string FightMonster(Monster monster)
        {
            if (monster.Damage >= this.Health)
            {
                this.health = 0;
                return $"You die! {monster.Name} defeated you!";
            }

            this.health -= monster.Damage;
            this.CurrentRoom.RemoveMonster(monster);
            return $"Congratulations! You defeated {monster.Name}! Remaining health: {this.Health}";
        }
    }
}