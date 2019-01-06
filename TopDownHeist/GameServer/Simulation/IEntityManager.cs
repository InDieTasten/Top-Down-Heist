using System.Collections.Generic;
using TopDownHeist.GameServer.Simulation.Base;

namespace TopDownHeist.GameServer.Simulation
{
    interface IEntityManager
    {
        void Add(Entity entity);
        IReadOnlyCollection<Entity> GetAll();
    }
}
