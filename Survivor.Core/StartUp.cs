using System;
using Survivor.Models;

namespace Survivor.Core
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var backpack = new Backpack(10);
            var player = new Player("Gosho", backpack);

            var maze = new Maze(player);

            var room1 = new Room("First-Room");

            room1.AddItem(new Item("Banana", 0.1));
            room1.AddItem(new Item("Sword", 0.5));
            room1.AddItem(new Item("Bomb", 1.2));

            room1.AddExit(new Exit("Door"));
            room1.AddExit(new Exit("Window"));
            room1.AddExit(new Exit("Shaft"));

            var room2 = new Room("Second-Room");

            room1.AddItem(new Item("Banana", 0.1));
            room1.AddItem(new Item("Sword", 0.5));
            room1.AddItem(new Item("Bomb", 1.2));

            room1.AddExit(new Exit("Door"));
            room1.AddExit(new Exit("Window"));
            room1.AddExit(new Exit("Shaft"));

            maze.AddRoom(room1);
            maze.AddRoom(room2);

            var engine = new Engine(maze, player);

            try
            {
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}