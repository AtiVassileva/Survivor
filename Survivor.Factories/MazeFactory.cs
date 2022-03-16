using Survivor.Models;

namespace Survivor.Factories
{
    public static class MazeFactory
    {
        public static Maze CreateMaze(Player player) => new Maze(player);
    }
}