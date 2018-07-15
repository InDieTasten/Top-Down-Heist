using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopDownHeist.GameServer.Helpers;

namespace TopDownHeist.GameServer.Simulation.World
{
    class Player
    {
        public string ConnectionId { get; set; }
        public Vector3 Position { get; set; }
    }
}
