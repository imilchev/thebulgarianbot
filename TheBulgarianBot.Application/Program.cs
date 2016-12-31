using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBulgarianBot.Application
{
    public class Program
    {
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
