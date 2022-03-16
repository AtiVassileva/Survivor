using System;
using System.Collections.Generic;
using System.Linq;

using Survivor.Models;

namespace Survivor.Core
{
    public class Engine
    {
        private readonly Player player;
        private readonly Maze maze;


        public Engine(Maze maze, Player player)
        {
            this.maze = maze;
            this.player = player;
        }

        public void Run()
        {
            StartGame();
        }

        private void StartGame()
        {

            while (true)
            {
                var input =
                    Console.ReadLine()
                        .Split(" ")
                        .ToArray();

                var command = input[0];

                if (command.ToLower() == "quit")
                {
                    break;
                }

                try
                {
                    switch (command.ToLower())
                    {
                        case "help":
                            Console.WriteLine("Available commands:");
                            PrintCommands();
                            break;
                        case "location":
                            Console.WriteLine(this.player.GetCurrentLocation());
                            break;
                        case "go":
                            var roomName = input[2];
                            GoToRoom(roomName);
                            break;
                        case "items":
                            PrintPlayerItems();
                            break;
                        case "pickup":
                            var itemName = input[1];
                            PickUpItem(itemName);
                            break;
                        case "drop":
                            var item = input[1];
                            DropItem(item);
                            break;
                        default:
                            throw new InvalidOperationException("Invalid command!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                
            }

            Environment.Exit(0);
        }

        private static void PrintCommands()
        {
            var commands = new List<string>
            {
                "location",
                "go to {room name}",
                "items",
                "pickup {item name}",
                "drop {item name}",
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
            Console.WriteLine($"Successfully moved to {roomName}!");
        }

        private void PrintPlayerItems()
        {
            foreach (var playerItem in this.player.Backpack.Items)
            {
                Console.WriteLine(playerItem);
            }
        }

        private void PickUpItem(string itemName)
        {
            if (this.player.CurrentRoom == null)
            {
                throw new ArgumentException("You have to go to a room to pick up items!");
            }

            var item = this.player.CurrentRoom.Items
                .FirstOrDefault(x => x.Name == itemName);

            if (item == null)
            {
                throw new ArgumentException();
            }

            this.player.Backpack.AddItem(item);
            Console.WriteLine($"Successfully picked up {itemName}!");
        }

        private void DropItem(string itemName)
        {
            var item = this.player.CurrentRoom.Items
                .FirstOrDefault(x => x.Name == itemName);

            if (!this.player.Backpack.ContainsItem(item))
            {
                throw new ArgumentException();
            }

            this.player.Backpack.DropItem(item);
            // TODO: this.player.CurrentRoom.AddItem(item);
            Console.WriteLine($"Successfully dropped {itemName}!");
        }
    }
}
