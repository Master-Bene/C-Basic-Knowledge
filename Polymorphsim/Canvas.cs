
namespace Polymorphsim
{
    public class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach (var item in shapes)
            {
                //switch (item.ShapeType)
                //{
                //    case ShapeType.Circle:
                //        Console.WriteLine("画圆");
                //        break;
                //    case ShapeType.Rectangle:
                //        Console.WriteLine("画方");
                //        break;
                //    case ShapeType.Triangle:
                //        Console.WriteLine("画△");
                //        break;
                //    default:
                //        break;
                //}
                item.Draw();
            }
        }

    }
}
