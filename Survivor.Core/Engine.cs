using System;
using System.Collections.Generic;
using System.Linq;
using Survivor.Core.Seeders;
using Survivor.Models;

namespace Survivor.Core
{
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
            Console.WriteLine($"Welcome, {this.player.Name}! Enter a command... (type 'help' if you need some.)");
            Console.WriteLine(this.maze.ToString());

            while (true)
            {
                Console.Write("Your command: ");

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
                    Console.WriteLine("Available commands:");
                    PrintCommands();
                    break;
                case "location":
                    Console.WriteLine(player.GetCurrentLocation());
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
            Console.WriteLine($"Welcome to {roomName}!");
            Console.WriteLine(room.ToString());
        }

        private void PrintPlayerItems()
        {
            if (!this.player.Backpack.Items.Any())
            {
                Console.WriteLine("No items in backpack.");
            }
            else
            {
                foreach (var playerItem in this.player.Backpack.Items)
                {
                    Console.WriteLine(playerItem);
                }
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

            this.player.Backpack.AddItem(item);
            this.player.CurrentRoom.RemoveItem(item);
            Console.WriteLine($"Successfully picked up {itemName}!");
        }

        private void DropItem(string itemName)
        {
            var item = this.player.CurrentRoom.Items
                .FirstOrDefault(x => x.Name == itemName);

            this.player.Backpack.DropItem(item);
            this.player.CurrentRoom.AddItem(item);
            Console.WriteLine($"Successfully dropped {itemName}!");
        }
    }
}