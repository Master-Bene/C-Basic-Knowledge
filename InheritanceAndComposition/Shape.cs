// See https://aka.ms/new-console-template for more information

namespace InheritanceAndComposition
{
    public partial class Shape
    {
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public void Draw()
        {
            Console.WriteLine($"图形属性 Width:{Width},Height:{Height},Postion {X},{Y}");
        }
    }

    public partial class Image : Shape
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public void Show()
        {
            Console.WriteLine($"显示图形 图片名称:{Name},图片描述:{Description}");
        }

    }
}