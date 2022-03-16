using System;
using System.Collections.Generic;
using Survivor.Factories;
using Survivor.Models;

namespace Survivor.Core.Seeders
{
    public static class TestSeeder
    {
        private const int BackpackTestCapacity = 5;

        public static Player InitializePlayer()
        {
            Console.Write("Player name: ");
            var name = Console.ReadLine();

            var backpack = BackpackFactory.CreateBackpack(BackpackTestCapacity);
            var playerInstance = PlayerFactory.CreatePlayer(name, backpack);

            return playerInstance;
        }

        public static Maze InitializeMaze(Player player)
        {
            var mazeInstance = new Maze(player);
            return mazeInstance;
        }

        public static void InitializeRooms(Maze maze)
        {
            var heavenRoom = RoomFactory.CreateRoom("Heaven");

            var testItems = CreateTestItems();
            AddItemsInRoom(heavenRoom, testItems);
            var testExits = CreateTestExits();
            AddExitsToRoom(heavenRoom, testExits);

            var hellRoom = RoomFactory.CreateRoom("Hell");
            AddItemsInRoom(hellRoom, testItems);
            AddExitsToRoom(hellRoom, testExits);

            maze.AddRoom(heavenRoom);
            maze.AddRoom(hellRoom);
        }

        private static IEnumerable<Item> CreateTestItems()
        {
            var banana = ItemFactory.CreateItem("Banana", 0.1);
            var sword = ItemFactory.CreateItem("Sword", 0.5);
            var bomb = ItemFactory.CreateItem("Bomb", 1.2);

            return new List<Item> { banana, sword, bomb };
        }

        private static IEnumerable<Exit> CreateTestExits()
        {
            var doorExit = new Exit("Door");
            var windowExit = new Exit("Window");
            var shaftExit = new Exit("Shaft");

            return new List<Exit> { doorExit, windowExit, shaftExit };
        }

        private static void AddItemsInRoom(Room room, IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                room.AddItem(item);
            }
        }

        private static void AddExitsToRoom(Room room, IEnumerable<Exit> exits)
        {
            foreach (var exit in exits)
            {
                room.AddExit(exit);
            }
        }
    }
}