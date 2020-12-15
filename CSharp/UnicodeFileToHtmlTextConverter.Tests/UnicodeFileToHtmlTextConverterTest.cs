
using System.IO;
using Xunit;
namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class HikerTest
    {
        [Fact]
        public void test_convert_ampersand()
        {
            var fakeProvider = new FakeTextProvider("Lilo & Stitch");

            var target = new UnicodeFileToHtmlTextConverter(fakeProvider);
            string result = target.ConvertToHtml();

            Assert.Equal( "Lilo &amp; Stitch<br />", result);
        }
    }

    public class FakeTextProvider : IUnicodeTextProvider
    {
        private string _text;

        public FakeTextProvider(string input)
        {
            this._text = input;
        }
        public TextReader GetTextReader()
        {
            return new StringReader(_text);
        }

    }
}
