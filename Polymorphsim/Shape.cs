namespace Polymorphsim
{
    public  class Shape
    {
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        public Position Position { get; set; }

        //public ShapeType ShapeType { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine("图形绘制");
        }
    }


    public class Circle : Shape
    {
        //重写基类中的方法
        public override void Draw()
        {
            //base.Draw();
            Console.WriteLine("画圆-绘制圆形图案");
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            //base.Draw();
            Console.WriteLine("画方-绘制方形图案");
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            //base.Draw();
            Console.WriteLine("画△-绘制三角图案");
        }

        public override string ToString()
        {
            return $"这个是Triangle三角形图标 宽：{Width}";
        }
    }

    public abstract class ShapeFC
    {
        public abstract void Test();
    }
}
