namespace TopDownHeist.GameServer.Simulation
{
    interface ISimulationManager
    {
        float TicksPerSecond { get; set; }

        void SimulateNextTick();
    }
}
