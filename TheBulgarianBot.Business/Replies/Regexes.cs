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
        public static List<Regex> HowAreYouRegexes;

        // TODO: add 'hi' regexes

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
                new Regex(@"\blaino\b", RegexOptions.IgnoreCase),
                new Regex(@"\bлайно\b", RegexOptions.IgnoreCase),
                new Regex(@"\bmaika ti\b", RegexOptions.IgnoreCase),
                new Regex(@"\bmaikati\b", RegexOptions.IgnoreCase),
                new Regex(@"\bмайка ти\b", RegexOptions.IgnoreCase),
                new Regex(@"\bмайкати\b", RegexOptions.IgnoreCase),
                new Regex(@"\bneshtastnik\b", RegexOptions.IgnoreCase),
                new Regex(@"\bнещастник\b", RegexOptions.IgnoreCase),
                new Regex(@"\bkaltak\b", RegexOptions.IgnoreCase),
                new Regex(@"\bкалтак\b", RegexOptions.IgnoreCase),
                new Regex(@"\bkurwa\b", RegexOptions.IgnoreCase),
                new Regex(@"\bкурва\b", RegexOptions.IgnoreCase),
                new Regex(@"\bkurva\b", RegexOptions.IgnoreCase),
                new Regex(@"\bkuchka\b", RegexOptions.IgnoreCase),
                new Regex(@"\bкучка\b", RegexOptions.IgnoreCase),
            };
            Regexes.HowAreYouRegexes = new List<Regex>
            {
                new Regex(@"\bkp\b", RegexOptions.IgnoreCase),
                new Regex(@"\bk(ak)?vo pra(i|vish)sh\b", RegexOptions.IgnoreCase),
                new Regex(@"\bkak si\b", RegexOptions.IgnoreCase),
                new Regex(@"\bк(ак)?во пра(в)?(и|й)ш\b", RegexOptions.IgnoreCase),
                new Regex(@"\bhow are you\b", RegexOptions.IgnoreCase),
                new Regex(@"\bwhat (are)? you doing\b", RegexOptions.IgnoreCase),
            };
        }
    }
}
