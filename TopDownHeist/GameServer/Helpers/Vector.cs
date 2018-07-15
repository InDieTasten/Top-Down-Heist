using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopDownHeist.GameServer.Helpers
{
    class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    class Vector3 : Vector2
    {
        public float Z { get; set; }
    }
}
