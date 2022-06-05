// See https://aka.ms/new-console-template for more information

namespace InheritanceAndComposition
{
    public partial class Text : PresentationObject
    {
        public int FontSize { get; set; } = 0;
        public int FontWeight { get; set; } = 0;
        public string FontFamily { get; set; } = "";
        public string FontStyle { get; set; } = "";

        public void AddHyperLink()
        {
            Console.WriteLine("添加超链接");
        }
    }
}
