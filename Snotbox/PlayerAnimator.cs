using System;

namespace Sandbox
{
    public abstract class PlayerAnimator
    {
        public abstract void Tick();

        public void SetParam(string name, float value)
        {
            Console.WriteLine("[PlayerAnimator] " + name + " = " + value);
        }
    }
}
