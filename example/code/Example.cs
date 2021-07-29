using System;
using Sandbox;

namespace SnboxExample
{
    //[Library("snexample", Title = "s!box example")]
    public partial class Example : Sandbox.Game
    {
        public override void ClientJoined(Client client)
        {
            base.ClientJoined(client);

            Console.WriteLine("Creating pawn for: " + client.Name);

            var player = new ExamplePlayer();
			client.Pawn = player;

			player.Respawn();
        }
    }
}