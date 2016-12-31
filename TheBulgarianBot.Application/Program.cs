namespace TheBulgarianBot.Application
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Entry point for the console application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point for the console application.
        /// </summary>
        /// <param name="args">The launch arguments.</param>
        public static void Main(string[] args)
        {
            var theBulgarianBot = new Business.TheBulgarianBot();
            theBulgarianBot.StartReceiving();
            Console.WriteLine("The bot is started.");

            Console.WriteLine();

            var assembly = Assembly.GetEntryAssembly();
            var resourceName = "TheBulgarianBot.Application.rakia.png";

            foreach (var i in Assembly.Load(new AssemblyName("TheBulgarianBot.Business")).GetManifestResourceNames())
            {
                Console.WriteLine(i);   
            }

            Console.WriteLine("Press any key to kill the bot...");
            Console.ReadLine();
        }
    }
}
