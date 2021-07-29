using System;
using Sandbox;

namespace SnboxExample
{
    //[Library("snexample", Title = "s!box example")]
    public partial class ExamplePlayer : Sandbox.Player
    {
        public override void Respawn()
        {
            Console.WriteLine("I've just respawned!");

            Controller = new WalkController();
            Animator = new StandardPlayerAnimator();
            Camera = new ThirdPersonCamera();

            base.Respawn();
        }
    }
}