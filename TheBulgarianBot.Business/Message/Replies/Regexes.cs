namespace TheBulgarianBot.Business.Message.Replies
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A static class containing reusable regular expressions.
    /// </summary>
    internal static class Regexes
    {
        /// <summary>
        /// Initializes the static members of the <see cref="Regexes"/> class.
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
                new Regex(@"\bтъп\b", RegexOptions.IgnoreCase),
                new Regex(@"\bt(a|u)p\b", RegexOptions.IgnoreCase),
                new Regex(@"\bkopele\b", RegexOptions.IgnoreCase),
                new Regex(@"\bкопеле\b", RegexOptions.IgnoreCase),
                new Regex(@"\bg(ay|ei)\b", RegexOptions.IgnoreCase),
                new Regex(@"\bгей\b", RegexOptions.IgnoreCase),
                new Regex(@"\bt(a|u)pak\b", RegexOptions.IgnoreCase),
                new Regex(@"\bтъпак\b", RegexOptions.IgnoreCase),
                new Regex(@"\blainar\b", RegexOptions.IgnoreCase),
                new Regex(@"\bлайнар\b", RegexOptions.IgnoreCase),
                new Regex(@"\bprostak\b", RegexOptions.IgnoreCase),
                new Regex(@"\bпростак\b", RegexOptions.IgnoreCase),
                new Regex(@"\bху(й|я)\b", RegexOptions.IgnoreCase),
                new Regex(@"\bкурв(а|о)\b", RegexOptions.IgnoreCase),
                new Regex(@"\bгъз\b", RegexOptions.IgnoreCase),
                new Regex(@"\bпедофил\b", RegexOptions.IgnoreCase)
            };
            Regexes.HowAreYouRegexes = new List<Regex>
            {
                new Regex(@"\bkp\b", RegexOptions.IgnoreCase),
                new Regex(@"\bk(ak)?vo pra(i|vish)sh\b", RegexOptions.IgnoreCase),
                new Regex(@"\bkak si\b", RegexOptions.IgnoreCase),
                new Regex(@"\bкак си\b", RegexOptions.IgnoreCase),
                new Regex(@"\bк(ак)?во пра(в)?(и|й)ш\b", RegexOptions.IgnoreCase),
                new Regex(@"\bk(ak)?vo sta(v)?a\b", RegexOptions.IgnoreCase),
                new Regex(@"\bк(ак)?во ста(в)?а\b", RegexOptions.IgnoreCase),
                new Regex(@"\bhow are you\b", RegexOptions.IgnoreCase),
                new Regex(@"\bwhat (are)? you doing\b", RegexOptions.IgnoreCase),
            };
            Regexes.HiRegexes = new List<Regex>
            {
                new Regex(@"\bzdr(asti+|avei)?\b", RegexOptions.IgnoreCase),
                new Regex(@"\bздр(асти|авей)?\b", RegexOptions.IgnoreCase),
                new Regex(@"\bhi+\b", RegexOptions.IgnoreCase),
                new Regex(@"\bhello+\b", RegexOptions.IgnoreCase),
                new Regex(@"\beho+\b", RegexOptions.IgnoreCase),
                new Regex(@"\bехо+\b", RegexOptions.IgnoreCase)
            };
            Regexes.BlackRegexes = new List<Regex>
            {
                new Regex(@"\bnigg(a|er)s?\b", RegexOptions.IgnoreCase),
                new Regex(@"\bblacks?\b", RegexOptions.IgnoreCase),
                new Regex(@"\bgips(y|ies)\b", RegexOptions.IgnoreCase),
                new Regex(@"\bmangali?\b", RegexOptions.IgnoreCase),
                new Regex(@"\bмангали?\b", RegexOptions.IgnoreCase),
                new Regex(@"\bcigan(in?|ka)\b", RegexOptions.IgnoreCase),
                new Regex(@"\bциган(ин?|ка)\b", RegexOptions.IgnoreCase),
                new Regex(@"\bjews?\b", RegexOptions.IgnoreCase),
                new Regex(@"\bevrein?\b", RegexOptions.IgnoreCase),
                new Regex(@"\bевреин?\b", RegexOptions.IgnoreCase),
                new Regex(@"\bнегър?\b", RegexOptions.IgnoreCase),
                new Regex(@"\bвъглен?\b", RegexOptions.IgnoreCase),
            };
            Regexes.AlcoholRegexes = new List<Regex>
            {
                new Regex(@"\bwhiskey\b", RegexOptions.IgnoreCase),
                new Regex(@"\b(y|u)iski\b", RegexOptions.IgnoreCase),
                new Regex(@"\bуиски\b", RegexOptions.IgnoreCase),
                new Regex(@"\bводка\b", RegexOptions.IgnoreCase),
                new Regex(@"\bvodka\b", RegexOptions.IgnoreCase),
                new Regex(@"\br(u|o)m\b", RegexOptions.IgnoreCase),
                new Regex(@"\bром\b", RegexOptions.IgnoreCase),
            };
        }

        /// <summary>
        /// Gets the regexes that match curse words.
        /// </summary>
        public static IReadOnlyList<Regex> CurseRegexes { get; }

        /// <summary>
        /// Gets the regexes that match: "How are you?" type of questions.
        /// </summary>
        public static IReadOnlyList<Regex> HowAreYouRegexes { get; }

        /// <summary>
        /// Gets the regexes that match "Hi" and its variations.
        /// </summary>
        public static IReadOnlyList<Regex> HiRegexes { get; }

        /// <summary>
        /// Gets the regexes that trigger racism.
        /// </summary>
        public static IReadOnlyList<Regex> BlackRegexes { get; }

        /// <summary>
        /// Gets the regexes that match alcohol.
        /// </summary>
        public static IReadOnlyList<Regex> AlcoholRegexes { get; }
    }
}
