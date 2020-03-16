namespace TheBulgarianBot.Business.Logger
{
    using Serilog;

    /// <summary>
    /// Static class for logging messages.
    /// </summary>
    public static class Logger
    {
        public static Serilog.Core.Logger Instance { get; }

        static Logger()
        {
            Logger.Instance = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
