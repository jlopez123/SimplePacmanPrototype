namespace Code.Maze
{
    public class PrefabMaze : IMazeGenerator
    {
        private string _mazeRepresentation = "**************************/" +
                                             "*..........***...........*/" +
                                             "*.***.****.***.****.****.*/" +
                                             "*........................*/" +
                                             "*.***.****.*****.*******.*/" +
                                             "*.....****.*****.****....*/" +
                                             "*****.***.........***.****/" +
                                             "*****.....*******.....****/" +
                                             "*.....***.*     *.***....*/" +
                                             "*****.....*******.....****/" +
                                             "*****.***.........***.****/" +
                                             "*.....****.*****.****....*/" +
                                             "*.***.****.*****.*******.*/" +
                                             "*........................*/" +
                                             "*.***.****.***.****.****.*/" +
                                             "*..........***...........*/" +
                                             "**************************/";
        
        public char[,] GenerateMaze()
        {
            var splitString = _mazeRepresentation.Split('/');

            var cols = _mazeRepresentation.IndexOf('/');
            var rows = _mazeRepresentation.Length / cols;

            var maze = new char[rows, cols];

            for (var i = 0; i < maze.GetLength(0); i++)
            {
                var currentLine = splitString[i];
                for (var j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j] = currentLine[j];
                }
            }
            return maze;
        }
    }
}