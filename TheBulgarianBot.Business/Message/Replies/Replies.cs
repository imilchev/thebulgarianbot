namespace TheBulgarianBot.Business.Message.Replies
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Telegram.Bot.Types.Enums;

    /// <summary>
    /// A static class containing the replies.
    /// </summary>
    internal static class Replies
    {
        private static IReadOnlyList<string> curses;

        /// <summary>
        /// Initializes static members of the <see cref="Replies"/> class.
        /// </summary>
        static Replies()
        {
            Replies.curses = new List<string>
            {
                "Майка ти те е събирала с лъжица от пода 😊",
                "Ти па си много убав!",
                "Еби си майката!",
                "Гол да го бараш!",
                "Да го духаш, педал!",
                "Майната ти!",
                "аре те хвана 1в1 уе",
                "тука мн знаеш ама навънка мълчиш кат пържена цаца",
                "майка ти е съжалила че не те е глътнала като си се родил",
                "баща ти ако знаеше къв боклук ще стане от теб, щеше да свърши в мивката",
                "да го хлопна на майка ти на челото",
                "я недей знай уе, лайнар",
                "Ти па си много убав!",
                "На майка ти путката",
                "Майка ти те е събирала с лъжица от пода 😊",
                "Еби си майката!",
                "Гол да го бараш!",
                "Да го духаш, педал!",
                "Майната ти!",
                "Нисхогъзест пърхопърдел",
                "Ако не занеш как се правят грозни деца-ПОПИТАЙ МАЙКА СИ!!!",
                "Отивай да ебеш мисирките на село!",
                "Задника ти е дебел като боилер бе, бидон разпльокан!",
                "Да лапаш задопашна жлеза на южно-американски скункс!",
                "Я се погледни че приличаш на млековарка на горнобански път бре!!!!!!",
                "Като те гледам какъв си се сещам, че понякога природата е много жестока.",
                "Родилен продукт на гадна, фригидна, беззъба пъпчива вешица с космати крака!!!",
                "Изчезни кат` падаща мазилка уе...",
                "Може да си грозен, но пък за сметка на това си тъп.",
                "Толкова си грозен, че майкати сигурно те е хранила с прашка?!",
                "Ей овцо миризлива , да се мъчиш на мек хуй.",
                "Кон да ебе cеcтра ти на гроба на майка ти, докато бащта ти гледа падайки от cамолет",
                "Триста метра бодлива тел да изсереш!",
                "Миньор да търси злато в гъза ти!"
            };

            // Default direct reply.
            Replies.DefaultDirectReply = new TextReply(
                message: "WTF are you talking about, kopele?",
                replyTo: new List<Regex>());

            // Default curse order reply.
            Replies.DefaultCurseOrderReply = new TextReply(
                message: "Я не ми задавай наклон на хуя!",
                replyTo: new List<Regex>());

            // Replies list.
            Replies.RepliesList = new List<Reply>
            {
                new TextReply(
                    message: "```triggered```",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bfree\b", RegexOptions.IgnoreCase)
                    },
                    parseMode: ParseMode.Markdown),
                new TextReply(
                    message: "SEAL THE DEAL AND LET'S BOOGIE!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bdiscounts?\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bsales?\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bevtino?\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bевтино?\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bcheap(er)?\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bразпродажб(а|и)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\brazprodajb(a|i)\b", RegexOptions.IgnoreCase)
                    }),
                new TextReply(
                    message: "Zdravei, uruspia",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bangelica\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bgirls?\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bwom(a|e)n\b", RegexOptions.IgnoreCase)
                    }),
                new TextReply(
                    message: "*Gas chamber!*",
                    replyTo: new List<Regex>().Concat(Regexes.BlackRegexes),
                    parseMode: ParseMode.Markdown),
                new TextReply(
                    message: "*All gipsies should die!*",
                    replyTo: new List<Regex>().Concat(Regexes.BlackRegexes),
                    parseMode: ParseMode.Markdown),
                new TextReply(
                    message: "*Na sapun!*",
                    replyTo: new List<Regex>().Concat(Regexes.BlackRegexes),
                    parseMode: ParseMode.Markdown),
                new PhotoReply(
                    fileName: "hitler.jpg",
                    replyTo: new List<Regex>().Concat(Regexes.BlackRegexes)),
                new StickerReply(
                    fileId: "CAADBAADiQAD6l5iBGTArnOBcFBlAg",
                    replyToText: new List<Regex>
                    {
                        new Regex(@"\bkifla\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bкифла\b", RegexOptions.IgnoreCase),
                    },
                    replyToFileId: new List<string>()),
                new StickerReply(
                    fileId: "CAADBAADjQAD6l5iBGBZ8bpO8yHZAg",
                    replyToText: new List<Regex>
                    {
                        new Regex(@"\bчехъл\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bchehal\b", RegexOptions.IgnoreCase),
                    },
                    replyToFileId: new List<string>()),
                new TextReply(
                    message: "Кифла си!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bне съм кифла\b", RegexOptions.IgnoreCase)
                    }),
                new TextReply(
                    message: "Пръскаммм!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bнапрао ги убивам\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bнаправо ги убивам\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bnaprao gi ubivam\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bnapravo gi ubivam\b", RegexOptions.IgnoreCase),
                    }),
                new TextReply(
                    message: "Заграждаййй, тигре!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bдай му\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bdai m(u|y)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bзадай\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bzadai\b", RegexOptions.IgnoreCase),
                    }),
                new TextReply(
                    message: "Пъхай уе!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bдай му\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bdai m(u|y)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bзадай\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bzadai\b", RegexOptions.IgnoreCase),
                    }),
                new TextReply(
                    message: "В ГAЗЪЪЪ",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bпатенце\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bмиличък\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bpatence\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bmilich(u|a)k\b", RegexOptions.IgnoreCase),
                    }),
                new TextReply(
                    message: "Наздраве",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bназдраве\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bnazdrave\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bcheers\b", RegexOptions.IgnoreCase),
                    }),
                new TextReply(
                    message: "Удрииии",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bназдраве\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bnazdrave\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bcheers\b", RegexOptions.IgnoreCase),
                    }),
                new TextReply(
                    message: "Наливаййййй!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bназдраве\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bnazdrave\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bcheers\b", RegexOptions.IgnoreCase),
                    }),
                new StickerReply(
                    fileId: "CAADBAADfwEAAmtfiwZX_aFaLIRcqwI",
                    replyToText: new List<Regex>
                    {
                        new Regex(@"\bдай му\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bdai m(u|y)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bзадай\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bzadai\b", RegexOptions.IgnoreCase),
                    },
                    replyToFileId: new List<string>()),
            };

            // Direct replies.
            Replies.DirectReplies = new List<Reply>
            {
                new StickerReply(
                    fileId: "CAADBAADfwEAAmtfiwZX_aFaLIRcqwI",
                    replyToText: new List<Regex>
                    {
                        new Regex(@"\bдай му\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bdai m(u|y)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bзадай\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bzadai\b", RegexOptions.IgnoreCase),
                    },
                    replyToFileId: new List<string> { "CAADBAADfwEAAmtfiwZX_aFaLIRcqwI" }),
                new TextReply(
                    message: "Every time is a good time for drinking!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bWhen (should|must) \w+ drink\b", RegexOptions.IgnoreCase)
                    }),
                new TextReply(
                    message: "По всяко време!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bKoga (triabva|trqbva) da (pia|piq)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bKoga sh(te)? (pia|piq|piem)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bKoga da (pia|piq)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bКога (трябва)? да пия\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bКога (ще)? да пия\b", RegexOptions.IgnoreCase),
                    }),
                new PhotoReply(
                    fileName: "rakia.png",
                    caption: "The best drink man can get - RAKIA! Mamka mu!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bWhat do Bulgarians drink\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bNational drink\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bWhat (to|should) \w+ drink\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bWhat to drink\b", RegexOptions.IgnoreCase)
                    }),
                new PhotoReply(
                    fileName: "rakia.png",
                    caption: "Rakia we, kvo moje da piem??",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bK(ak)?vo (sh(te)?)? piem\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bК(ак)?во (ще)? пием\b", RegexOptions.IgnoreCase)
                    }),
                new PhotoReply(
                    fileName: "bulgaria.jpg",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bshow \w+ bulgaria\b", RegexOptions.IgnoreCase),
                        new Regex(@"\btell \w+ bulgaria\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bshow bulgaria\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bпокажи \w+ българия\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bпокажи българия\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bpokaji \w+ b(u|a)lgari(a|q)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bpokaji b(u|a)lgari(a|q)\b", RegexOptions.IgnoreCase),
                    }),
                new TextReply(
                    message: "Ti si pedal we, kaltak!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bpedal\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bпедал\b", RegexOptions.IgnoreCase),
                    }),
                new TextReply(
                    message: "Mn qsno che sh piem we 😊",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bsh(te)? piem li\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bще пием ли\b", RegexOptions.IgnoreCase)
                    }),
                new TextReply(
                    message: "Extra sam, bepce 😊",
                    replyTo: new List<Regex>().Concat(Regexes.HowAreYouRegexes)),
                new TextReply(
                    message: "Беля краставицата",
                    replyTo: new List<Regex>().Concat(Regexes.HowAreYouRegexes)),
                new TextReply(
                    message: "Майка ти е кучка 😉",
                    replyTo: new List<Regex>().Concat(Regexes.CurseRegexes)),
                new TextReply(
                    message: "Здрасти",
                    replyTo: new List<Regex>().Concat(Regexes.HiRegexes)),
                new TextReply(
                    message: "Здравей",
                    replyTo: new List<Regex>().Concat(Regexes.HiRegexes)),
                new TextReply(
                    message: "Здр 😘",
                    replyTo: new List<Regex>().Concat(Regexes.HiRegexes)),
                new TextReply(
                    message: "Да ти еба майката, копеле!",
                    replyTo: new List<Regex>().Concat(Regexes.CurseRegexes)),
                new TextReply(
                    message: "❤️",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\braki(a|q)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bракия\b", RegexOptions.IgnoreCase)
                    }),
                new TextReply(
                    message: "@ivanmilchev",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bKoi (ti)? e ba(sh|6)ta\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bKoi te e? (napravil?|sazda(de|l))\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bКой (ти)? е баща\b"),
                        new Regex(@"\bКой те е? (направил?|създа(де|л))\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bWho (made|created?)\b", RegexOptions.IgnoreCase),
                    }),
                new TextReply(
                    message: "Aushwitz was such a wonderful place",
                    replyTo: new List<Regex>().Concat(Regexes.BlackRegexes)),
                new TextReply(
                    message: "Real men drink only rakia",
                    replyTo: new List<Regex>().Concat(Regexes.AlcoholRegexes)),
                new TextReply(
                    message: "ne si dorasal za da ocenish rakiata",
                    replyTo: new List<Regex>().Concat(Regexes.AlcoholRegexes)),
                new TextReply(
                    message: "I'M ALIIIIIIIIIIVE",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bumr(q|ia)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bумря\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bm(a|u)rtav\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bмъртъв\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bdead\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bri(p|b)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bжив ли си\b", RegexOptions.IgnoreCase)
                    }),
                new TextReply(
                    message: "I'm just a Bulgarian 😁",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\b(ko(i|y)|k(ak)?vo)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bкой си\b", RegexOptions.IgnoreCase),
                        new Regex(@"\b(who|what) are you\b", RegexOptions.IgnoreCase),
                    }),
                new TextReply(
                    message: "Задавам!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bdai m(u|y)\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bдай му\b", RegexOptions.IgnoreCase),
                    }),
                new StickerReply(
                    fileId: "CAADBAADiQAD6l5iBGTArnOBcFBlAg",
                    replyToText: new List<Regex>
                    {
                        new Regex(@"\bКакв(о|а) е Зори\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bКакв(о|а) е Зорница\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bKakv(o|a) e zori\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bKakv(o|a) e zornica\b", RegexOptions.IgnoreCase),
                    },
                    replyToFileId: new List<string>()),
                new TextReply(
                    message: "Не си ти човекът, който ще ми задава наклон на хуя!",
                    replyTo: new List<Regex>
                    {
                        new Regex(@"\bмлъквай\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bмълчи\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bml(a|u)kvai\b", RegexOptions.IgnoreCase),
                        new Regex(@"\bm(a|u)lchi\b", RegexOptions.IgnoreCase),
                    }),
            };

            Replies.DirectReplies = Replies.DirectReplies.Concat(
                    Replies.curses.Select(
                        x => new TextReply(
                            message: x,
                            replyTo: new List<Regex>().Concat(Regexes.CurseRegexes).ToList())))
                .ToList();

            // Mention replies.
            Replies.MentionReplies = Replies.curses.Select(
                x => new MentionReply(message: x, replyTo: new List<Regex>().Concat(Regexes.CurseRegexes))).ToList();
        }

        /// <summary>
        /// Gets the default direct reply that will be sent whenever the user directly addresses the bot, but there is
        /// no predefined reply.
        /// </summary>
        public static Reply DefaultDirectReply { get; }

        /// <summary>
        /// Gets the default curse order reply that will be sent whenever a user different from @ivanmilchev orders the
        /// bot to curse.
        /// </summary>
        public static Reply DefaultCurseOrderReply { get; }

        /// <summary>
        /// Gets the list with replies that are used for global chat messages.
        /// </summary>
        public static IReadOnlyList<Reply> RepliesList { get; }

        /// <summary>
        /// Gets the list with replies that are used when the bot is addressed directly.
        /// </summary>
        public static IReadOnlyList<Reply> DirectReplies { get; }

        /// <summary>
        /// Gets the list with replies that are used for mentioning users.
        /// </summary>
        public static IReadOnlyList<MentionReply> MentionReplies { get; }
    }
}
