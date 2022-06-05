
namespace InheritanceAndComposition
{
    [Serializable]
    public partial class PresentationObject
    {
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;

        public void Copy()
        {
            Console.WriteLine("复制");
        }
        public void Paste()
        {
            Console.WriteLine("粘贴");
        }
    }
}
