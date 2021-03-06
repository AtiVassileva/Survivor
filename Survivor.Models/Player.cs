using System;
using System.Linq;
using System.Text;
using Survivor.Models.Enums;

namespace Survivor.Models
{
    using static Common.ExceptionMessages;
    using static Common.GlobalConstants;

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

        public string HealthStatus => $"Health status: {this.Health}";

        public string GetCurrentLocation()
        {
            if (this.CurrentRoom == null)
            {
                return PlayerNotInRoomExceptionMsg;
            }

            var sb = new StringBuilder();

            sb.AppendLine($"Current location: {this.CurrentRoom.Name}")
                .AppendLine($"Health status: {this.HealthStatus}")
                .Append("Available exits: ")
                .Append(string.Join(", ", 
                this.CurrentRoom.Exits
                .Select(x => x.Name)));

            return sb.ToString().Trim();
        }

        public string ChangeCurrentRoom(Room nextRoom)
        {
            this.CurrentRoom = nextRoom;
            this.health -= 2;
            return this.HealthStatus;
        }

        public string FightMonster(Monster monster)
        {
            if (this.Backpack.Items.All(x => x.Category != Category.Weapon))
            {
                return NoWeaponMsg;
            }

            if (monster.Damage >= this.Health)
            {
                this.health = 0;
                return string.Format(DefeatedByMonsterMsg, monster.Name);
            }

            this.health -= monster.Damage;
            this.CurrentRoom.RemoveMonster(monster);
            return string.Format(DefeatedMonsterMsg, monster.Name, this.HealthStatus);
        }

        public void UpdateHealthStatus(Item item)
        {
            switch (item.Category)
            {
                case Category.DangerPotion:
                    this.health -= 10;
                    break;
                case Category.HealthPotion:
                    this.health += 10;
                    break;
                case Category.Food:
                    this.health += 5;
                    break;
                default:
                    return;
            }
        }

        public string ExitCurrentRoom(Exit exit)
        {
            var result = exit.ExitType switch
            {
                ExitType.Door => ExitRoom(Category.Key, ExitType.Door),
                ExitType.Window => ExitRoom(Category.Hammer, ExitType.Window),
                ExitType.Shaft => ExitRoom(Category.Weapon, ExitType.Shaft),
                _ => string.Empty
            };

            return result;
        }

        private string ExitRoom(Category category, ExitType exitType)
        {
            string result;

            if (this.Backpack.Items.Any(x => x.Category == category))
            {
                result = string.Format(SuccessfullyExitedRoomMsg, this.CurrentRoom.Name);
                this.ChangeCurrentRoom(null);
            }
            else
            {
                result = string.Format(FailedExecutionMsg, category, exitType);
            }

            return result;
        }
    }
}