namespace TheBulgarianBot.Business.Message.TypicalCommand
{
    using System.Collections.Generic;

    public static class Text
    {
        public static List<TypicalText> typicalTexts;

        static Text()
        {
            Text.typicalTexts = new List<TypicalText>
            {
                new TypicalText("КРУШКАТА В СТАЯТА МУ ИЗГОРИ", "СВИВА ТАЯ ОТ ХОЛА"),
                new TypicalText("ЩЕ ПРАВИ ERASMUS", "ОТИВА В СОФИЙСКИ"),
                new TypicalText("ГУБИШ ВРЕМЕ ДА МУ ПРАВИШ CMS", "- СТРАХ МЕ Е ДА ПИПАМ"),
                new TypicalText("ПУСНЕ ОБЯВА В MARKPLAATS.NL", "ДАВАМ 10 ЕВРО ЗА КРАДЕНО КОЛЕЛО"),
                new TypicalText("12 ГОДИНИ УЧИЛИЩЕ, УНИВЕРСИТЕТ ПОЧНА", "И ПАК ВСЕКИ ДЕН SORRY DO YOU HAVE A PEN"),
                new TypicalText("КАЦА В АЙНДХОВЕН", "БИЛЕТЪТ МУ ЗА ВЛАКА ПО-СКЪП ОТ САМОЛЕТНИЯ"),
                new TypicalText("ДОКАТО КАРА КОЛЕЛО КЪМ УНИВЕРСИТЕТА", "СМЯТА КОЛКО ЩЕ МУ ИЗЛЕЗЕ ДА СИ ДОКАРА КОРСАТА"),
                new TypicalText("ОТИДЕ В ХОЛАНДИЯ", "ПРАЩА ЗЕЛЕНИ \"СУВЕНИРИ\" ПО ПОЩАТА"),
                new TypicalText("ПОДСТРИГВАНЕ 10 ЕВРО", "КУПИ СИ МАШИНКА И СЕ ПОДСТРИГВА САМ"),
                new TypicalText("СПУКА СИ ГУМАТА НА КОЛЕЛОТО", "СЛАГА СИ ГУМАТА ОТ КОЛЕЛОТО НА СЪКВАРТИРАНТА")
            };
        }
    }
}
