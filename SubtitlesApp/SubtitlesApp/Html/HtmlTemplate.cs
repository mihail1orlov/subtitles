namespace SubtitlesApp.Html
{
    public class HtmlTemplate
    {
        public static string Template { get; } =
            "<!DOCTYPE html>\n" +
            "<html lang=\"en\"xmlns=\"http://www.w3.org/1999/xhtml\">\n" +
            "<head><meta charset=\"utf-8\"/>\n" +
            "\t<title>{0}</title>\n" +
            "</head>\n" +
            "<body>\n{1}</body>\n" +
            "</html>";
    }
}