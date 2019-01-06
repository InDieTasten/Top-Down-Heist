using System;
using System.Collections.Generic;
using TopDownHeist.GameServer.Simulation.Base;

namespace TopDownHeist.GameServer.Simulation
{
    internal class EntityManager : IEntityManager
    {
        private readonly List<Entity> _entities = new List<Entity>();
        public void Add(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (_entities.Contains(entity))
            {
                // TODO make custom exception for this
                throw new Exception("Already exists");
            }

            _entities.Add(entity);
        }
        public IReadOnlyCollection<Entity> GetAll() => _entities;
    }
}
