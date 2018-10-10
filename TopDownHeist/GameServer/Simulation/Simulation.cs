using System;
using System.Collections.Generic;
using System.Threading;
using TopDownHeist.GameServer.Simulation.Base;
using TopDownHeist.GameServer.Simulation.World;

namespace TopDownHeist.GameServer.Simulation
{
    class Simulation
    {
        private long _currentTick;
        private readonly float _ticksPerSecond = 30f;

        public Floor Floor { get; set; }
        public List<GameEntity> Entities { get; set; }
        public List<GameObject> Objects { get; set; }

        public Simulation()
        {
            _currentTick = 0;
        }

        public void SimulateNextTick()
        {
            _currentTick++;

            // TODO To be moved to Simulate method
            Thread.Sleep(TimeSpan.FromSeconds(1 / _ticksPerSecond));
        }
    }
}
