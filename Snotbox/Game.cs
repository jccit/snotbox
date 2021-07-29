using System;
using System.Collections.Generic;

namespace Sandbox
{
    public class Game
    {
        public const bool IsServer = true;
        public const bool IsClient = false;

        public Game()
        {
            Client.All = new List<Client>();
            Console.WriteLine("[BASE GAME] Game starting");
        }

        public void Dev_AddPlayer(string name)
        {
            var newClient = new Client(name);
            Client.All.Add(newClient);
            ClientJoined(newClient);
        }

        public void Dev_Simulate()
        {
            foreach (var client in Client.All)
            {
                Simulate(client);
            }
        }

        #region Sandbox API

        /// <summary>
        /// Runs every tick
        /// </summary>
        public virtual void Simulate(Client client)
        {
            client.Pawn.Simulate(client);
        }

        /// <summary>
        /// Called when a player has joined the server
        /// </summary>
        public virtual void ClientJoined(Client player)
        {
            Console.WriteLine("[BASE GAME] Client joined");
        }

        /// <summary>
        /// Called when a player has left the server
        /// </summary>
        public virtual void ClientDisconnect(Client player)
        {
            Console.WriteLine("[BASE GAME] Client disconnected");
        }

        /// <summary>
        /// Player has tried to use noclip
        /// </summary>
        public virtual void DoPlayerNoclip(Client player)
        {

        }

        /// <summary>
        /// Player has tried to suicide
        /// </summary>
        public virtual void DoPlayerSuicide(Client player)
        {

        }

        #endregion
    }
}
