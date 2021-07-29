using System;

namespace Sandbox
{
    public class Player : Entity
    {
        public bool EnableAllCollisions = false;
        public bool EnableDrawing = false;
        public bool EnableHideInFirstPerson = false;
        public bool EnableShadowInFirstPerson = false;

        public PlayerController Controller;
        public PlayerAnimator Animator;
        public BaseCamera Camera;

        public virtual void Spawn()
        {
            Console.WriteLine("[BASE PLAYER] Spawned");
        }

        public virtual void Respawn()
        {
            Console.WriteLine("[BASE PLAYER] Respawning");
        }

        public virtual void TakeDamage(DamageInfo info)
        {
            Console.WriteLine("[BASE PLAYER] Took damage");
        }
    }
}
