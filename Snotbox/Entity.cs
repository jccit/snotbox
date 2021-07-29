using System;

namespace Sandbox
{
    public class Entity
    {
        public Entity() {}

        public virtual void OnKilled()
        {
            Console.WriteLine("[BASE ENTITY] Killed");
        }
    }
}
