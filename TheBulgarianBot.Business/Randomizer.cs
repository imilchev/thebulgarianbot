namespace TheBulgarianBot.Business
{
    using System;

    /// <summary>
    /// Contains the instance of <see cref="Random"/> for the bot.
    /// </summary>
    internal static class Randomizer
    {
        private static readonly Random Rand;

        /// <summary>
        /// Initializes static members of the <see cref="Randomizer"/> class.
        /// </summary>
        static Randomizer()
        {
            Randomizer.Rand = new Random();
        }

        /// <summary>
        /// Gets the instance of <see cref="Random"/>.
        /// </summary>
        public static Random Random => Randomizer.Rand;
    }
}
