using System;

namespace Sandbox
{
    public class Player
    {
        public virtual void Spawn()
        {
            Console.WriteLine("[BASE PLAYER] Spawned");
        }

        public virtual void Respawn()
        {
            Console.WriteLine("[BASE PLAYER] Respawning");
        }

        public virtual void OnKilled()
        {
            Console.WriteLine("[BASE PLAYER] Killed");
        }

        public virtual void TakeDamage(DamageInfo info)
        {
            Console.WriteLine("[BASE PLAYER] Took damage");
        }
    }
}
