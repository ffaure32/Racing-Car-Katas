using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        private IUnicodeTextProvider _textProvider;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath) : this(new UnicodeTextProviderFromFileSystem(fullFilenameWithPath))
        {
        }

        public UnicodeFileToHtmlTextConverter(IUnicodeTextProvider textProvider)
        {
            _textProvider = textProvider;
        }

        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = _textProvider.GetTextReader())
            {
                string html = string.Empty;

                string line = unicodeFileStream.ReadLine();
                while (line != null)
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = unicodeFileStream.ReadLine();
                }

                return html;
            }
        }
    }

    public class UnicodeTextProviderFromFileSystem : IUnicodeTextProvider
    {
        private readonly string _fullFilenameWithPath;

        public UnicodeTextProviderFromFileSystem(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public TextReader GetTextReader()
        {
            return File.OpenText(_fullFilenameWithPath);
        }
    }

    public interface IUnicodeTextProvider
    {
        TextReader GetTextReader();
    }

    class HttpUtility
    {
        public static string HtmlEncode(string line)
        {
            line = line.Replace("<", "&lt;");
            line = line.Replace(">", "&gt;");
            line = line.Replace("&", "&amp;");
            line = line.Replace("\"", "&quot;");
            line = line.Replace("\'", "&quot;");
            return line;
        }
    }
}
