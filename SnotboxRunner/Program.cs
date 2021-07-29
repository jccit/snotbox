using System;
using Sandbox;

namespace SnotboxRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Sandbox.Game game = new Sandbox.Game();
            game.Dev_AddPlayer("test");
        }
    }
}
