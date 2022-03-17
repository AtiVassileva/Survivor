using System;
using System.Collections.Generic;
using System.Linq;
using Survivor.Core.Seeders;
using Survivor.Models;

namespace Survivor.Core
{
    using static Common.GlobalConstants;
    using static Common.ExceptionMessages;

    public class Engine
    {
        private Player player;
        private Maze maze;
        
        public void Run()
        {
            this.player = TestSeeder.InitializePlayer();
            this.maze = TestSeeder.InitializeMaze(this.player);
            TestSeeder.InitializeRooms(this.maze);

            StartGame();
        }

        private void StartGame()
        {
            Console.WriteLine(string.Format(WelcomeMessage, this.player.Name));
            Console.WriteLine(this.maze.ToString());

            while (true)
            {
                if (this.player.IsDead)
                {
                    break;
                }

                Console.Write(CommandMessage);

                var input =
                    Console.ReadLine()
                        .Split(" ")
                        .ToArray();

                var command = input[0];

                if (command.ToLower() == QuitCommand)
                {
                    break;
                }

                try
                {
                    ParseCommand(command, input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                
            }

            Environment.Exit(0);
        }

        private void ParseCommand(string command, string[] input)
        {
            switch (command.ToLower())
            {
                case "help":
                    PrintCommands();
                    break;
                case "location":
                    Console.WriteLine(player.GetCurrentLocation());
                    break;
                case "go":
                    var roomName = input[2];
                    GoToRoom(roomName);
                    Console.WriteLine(player.GetCurrentLocation());
                    break;
                case "items":
                    PrintPlayerItems();
                    break;
                case "pickup":
                    var itemName = input[1];
                    PickUpItem(itemName);
                    PrintPlayerItems();
                    break;
                case "drop":
                    var item = input[1];
                    DropItem(item);
                    PrintPlayerItems();
                    break;
                case "fight":
                    var monsterName = input[1];
                    FightMonster(monsterName);
                    break;
                case "exit":
                    var exitName = input[1];
                    ExitRoom(exitName);
                    break;
                default:
                    throw new InvalidOperationException(InvalidCommandExcMsg);
            }
        }

        private static void PrintCommands()
        {
            Console.WriteLine("Available commands:");

            var commands = new List<string>
            {
                "location",
                "go to {room name}",
                "items",
                "pickup {item name}",
                "drop {item name}",
                "fight {monster name}",
                "exit {exit name}",
                "quit"
            };

            foreach (var cmd in commands)
            {
                Console.WriteLine(cmd);
            }
        }

        private void GoToRoom(string roomName)
        {
            var room = this.maze.FindRoomByName(roomName);
            this.player.ChangeCurrentRoom(room);
            Console.WriteLine(string.Format(WelcomeToRoomMessage, room.Name, this.player.HealthStatus));
            Console.WriteLine(room.ToString());
        }

        private void PrintPlayerItems()
        {
            var itemsInfo = this.player.Backpack.ShowItems();
            Console.WriteLine(itemsInfo);
        }

        private void PickUpItem(string itemName)
        {
            if (this.player.CurrentRoom == null)
            {
                throw new ArgumentException(NotInARoomExcMsg);
            }

            var item = this.player.CurrentRoom.FindItem(itemName);

            this.player.Backpack.AddItem(item);
            this.player.CurrentRoom.RemoveItem(item);
            this.player.UpdateHealthStatus(item);

            Console.WriteLine(string.Format(SuccessfullyPickedUpItemMessage, 
                item.Name, this.player.HealthStatus));
        }

        private void DropItem(string itemName)
        {
            var item = this.player.CurrentRoom.FindItem(itemName);

            this.player.Backpack.DropItem(item);
            this.player.CurrentRoom.AddItem(item);
            Console.WriteLine(string.Format(SuccessfullyDroppedItemMessage, item.Name));
        }

        private void FightMonster(string monsterName)
        {
            if (this.player.CurrentRoom == null)
            {
                throw new ArgumentException(NotInARoomExcMsg);
            }

            var monster = this.player.CurrentRoom.FindMonster(monsterName);
            var fightResult = this.player.FightMonster(monster);
            Console.WriteLine(fightResult);
        }

        private void ExitRoom(string exitName)
        {
            if (this.player.CurrentRoom == null)
            {
                throw new ArgumentException(NotInARoomExcMsg);
            }

            var exit = this.player.CurrentRoom.FindExit(exitName);
            var exitResult = this.player.ExitCurrentRoom(exit);
            Console.WriteLine(exitResult);
        }
    }
}