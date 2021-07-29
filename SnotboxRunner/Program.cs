using System;
using System.IO;
using System.Threading.Tasks;
using Sandbox;

namespace SnotboxRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            string addonPath = Path.Combine(Environment.CurrentDirectory, "example");
            var addon = new Addon(addonPath);

            Console.WriteLine("Printing all types found in addon");
            addon.PrintTypes();

            var gameClass = addon.GetGameClassType();
            Sandbox.Game game = (Sandbox.Game)addon.CreateInstance(gameClass);

            game.Dev_AddPlayer("player");

            var task = Task.Run(async () => {
                while (true)
                {
                    game.Dev_Simulate();
                    await Task.Delay(16);
                }
            });

            task.Wait();
        }
    }
}
