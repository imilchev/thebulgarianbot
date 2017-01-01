namespace TheBulgarianBot.Business.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A static class containing reusable regular expressions.
    /// </summary>
    internal static class Regexes
    {
        public static List<Regex> CurseRegexes;

        /// <summary>
        /// Initializes the static fields of the <see cref="Regexes"/> class.
        /// </summary>
        static Regexes()
        {
            Regexes.CurseRegexes = new List<Regex>
            {
                new Regex(@"\bmainata ti\b", RegexOptions.IgnoreCase),
                new Regex(@"\bмайната ти\b", RegexOptions.IgnoreCase),
                new Regex(@"\bda go duhash\b", RegexOptions.IgnoreCase),
                new Regex(@"\bда го духаш\b", RegexOptions.IgnoreCase),
                new Regex(@"\bfuck\b", RegexOptions.IgnoreCase),
                new Regex(@"\bblow me\b", RegexOptions.IgnoreCase),
                new Regex(@"\bgol da go barash\b", RegexOptions.IgnoreCase),
                new Regex(@"\bгол да го бараш\b", RegexOptions.IgnoreCase),
                new Regex(@"\btell me a curse word\b", RegexOptions.IgnoreCase),
            };
        }
    }
}
