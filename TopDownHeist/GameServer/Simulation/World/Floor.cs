namespace TopDownHeist.GameServer.Simulation.World
{
    internal class Floor
    {
        private readonly int[,] _tileTypeIds;

        public Floor(int width, int height)
        {
            _tileTypeIds = new int[width, height];
        }
    }
}
