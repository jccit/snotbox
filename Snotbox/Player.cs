using System;

namespace Sandbox
{
    public class Player
    {
        public void Spawn()
        {
            Console.WriteLine("[BASE PLAYER] Spawned");
        }

        public void Respawn()
        {
            Console.WriteLine("[BASE PLAYER] Respawning");
        }

        public void OnKilled()
        {
            Console.WriteLine("[BASE PLAYER] Killed");
        }

        public void TakeDamage(DamageInfo info)
        {
            Console.WriteLine("[BASE PLAYER] Took damage");
        }
    }
}
