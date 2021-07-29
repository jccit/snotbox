using System;
using System.Collections.Generic;

namespace Sandbox
{
    public class Client
    {
        /// <summary>
        /// A list of all the clients connected to the server
        /// </summary>
        public static List<Client> All;

        public Player Pawn { get; set; }
        public string Name;

        public Client(string Name)
        {
            this.Name = Name;
            Console.WriteLine("[BASE CLIENT] New client");
        }
    }
}
