using System;

namespace Code.Maze
{
    public interface IMazeGenerator
    {
        char[,] GenerateMaze();
    }
    public class MazeGeneratorImp : IMazeGenerator
    {
        public char[,] GenerateMaze()
        {
            throw new NotImplementedException();
        }
    }
}