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
            Client.All.Add(new Client(name));
            Console.WriteLine("[BASE GAME] Added player: " + name + ". Total players: " + Client.All.Count);
        }

        #region Sandbox API

        /// <summary>
        /// Called when a player has joined the server
        /// </summary>
        public void ClientJoined(Client player)
        {
            Console.WriteLine("[BASE GAME] Client joined");
        }

        /// <summary>
        /// Called when a player has left the server
        /// </summary>
        public void ClientDisconnect(Client player)
        {
            Console.WriteLine("[BASE GAME] Client disconnected");
        }

        /// <summary>
        /// Player has tried to use noclip
        /// </summary>
        public void DoPlayerNoclip(Client player)
        {

        }

        /// <summary>
        /// Player has tried to suicide
        /// </summary>
        public void DoPlayerSuicide(Client player)
        {

        }

        #endregion
    }
}
