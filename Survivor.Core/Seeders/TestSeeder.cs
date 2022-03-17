using System;
using System.Collections.Generic;
using Survivor.Factories;
using Survivor.Models;
using Survivor.Models.Enums;

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
            var heavenRoom = CreateHeaven();

            var hellRoom = CreateHell();

            maze.AddRoom(heavenRoom);
            maze.AddRoom(hellRoom);
        }

        private static Room CreateHeaven()
        {
            var heavenRoom = RoomFactory.CreateRoom("Heaven");

            var heavenItems = CreateHeavenItems();
            AddItemsInRoom(heavenRoom, heavenItems);

            var heavenExits = CreateHeavenExits();
            AddExitsToRoom(heavenRoom, heavenExits);
            return heavenRoom;
        }

        private static Room CreateHell()
        {
            var hellRoom = RoomFactory.CreateRoom("Hell");

            var hellItems = CreateHellItems();
            AddItemsInRoom(hellRoom, hellItems);

            var hellExits = CreateHellExits();
            AddExitsToRoom(hellRoom, hellExits);

            var monsters = CreateMonsters();
            AddMonstersInRoom(hellRoom, monsters);
            return hellRoom;
        }

        private static IEnumerable<Item> CreateHellItems()
        {
            var banana = ItemFactory.CreateItem("Banana", 0.1, Category.Food);
            var sword = ItemFactory.CreateItem("Sword", 0.5, Category.Weapon);
            var bomb = ItemFactory.CreateItem("Bomb", 1.2, Category.Weapon);
            var hammer = ItemFactory.CreateItem("ClawHammer", 2, Category.Hammer);
            var key = ItemFactory.CreateItem("GoldenKey", 0.2, Category.Key);
            var poison = ItemFactory.CreateItem("Poison", 0.4, Category.DangerPotion);

            return new List<Item> { banana, sword, bomb, hammer, key, poison };
        }
        
        private static IEnumerable<Item> CreateHeavenItems()
        {
            var chicken = ItemFactory.CreateItem("Chicken", 0.3, Category.Food);
            var key = ItemFactory.CreateItem("GoldenKey", 0.2, Category.Key);
            var elixir = ItemFactory.CreateItem("Elixir", 0.4, Category.HealthPotion);
            var gem = ItemFactory.CreateItem("Gem", 0.2, Category.Currency);

            return new List<Item> { chicken, key, elixir, gem };
        }

        private static IEnumerable<Exit> CreateHeavenExits()
        {
            var doorExit = new Exit("Door", ExitType.Door);
            var windowExit = new Exit("Window", ExitType.Window);

            return new List<Exit> { doorExit, windowExit };
        }
        
        private static IEnumerable<Exit> CreateHellExits()
        {
            var doorExit = new Exit("Door", ExitType.Door);
            var windowExit = new Exit("Window", ExitType.Window);
            var shaftExit = new Exit("Shaft", ExitType.Shaft);

            return new List<Exit> { doorExit, windowExit, shaftExit };
        }

        private static IEnumerable<Monster> CreateMonsters()
        {
            var kraken = MonsterFactory.CreateMonster("Kraken", 60);
            var dragon = MonsterFactory.CreateMonster("Dracus", 30);
            var bee = MonsterFactory.CreateMonster("Bee", 10);

            return new List<Monster> { kraken, dragon, bee };
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

        private static void AddMonstersInRoom(Room room, IEnumerable<Monster> monsters)
        {
            foreach (var monster in monsters)
            {
                room.AddMonster(monster);
            }
        }
    }
}