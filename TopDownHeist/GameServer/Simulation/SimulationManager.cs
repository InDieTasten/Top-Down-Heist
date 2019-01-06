namespace TopDownHeist.GameServer.Simulation
{
    internal class SimulationManager : ISimulationManager
    {
        private long _currentTick = 0;
        private readonly IEntityManager _entityManager;
        public float TicksPerSecond { get; set; } = 30f;

        public SimulationManager(IEntityManager entityManager)
        {
            _entityManager = entityManager;
        }


        public void SimulateNextTick()
        {
            _currentTick++;

            // TODO
            // Calculate new velocities based on accelerations
            // Calculate provisional new positions based on velocities
            // Detect collisions between ICollidables
            // Add normal
        }
    }
}
