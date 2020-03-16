namespace TheBulgarianBot.Business.Logger
{
    using Serilog;

    /// <summary>
    /// Static class for logging messages.
    /// </summary>
    public static class Logger
    {
        static Logger()
        {
            Logger.Instance = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
        }

        /// <summary>
        /// Gets the logger instance.
        /// </summary>
        public static Serilog.Core.Logger Instance { get; }
    }
}
