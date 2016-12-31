namespace TheBulgarianBot.Application
{
    using System;

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
            Console.WriteLine("Press any key to kill the bot...");
            Console.ReadLine();
        }
    }
}
