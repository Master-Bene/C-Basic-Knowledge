// See https://aka.ms/new-console-template for more information
using Polymorphsim;
//编译时多态（静态绑定）：方法重载（overload）
//运行时多态（动态绑定）：方法重写（override 覆盖 重写）：一个接口多个实现或继承父类，并重写父类方法
Console.WriteLine("Hello, World!");
                                                                                                              
//重构历史代码将原先通过枚举值来创建不同的图形。
List<Shape> shapes = new List<Shape>();
//shapes.Add(new Shape() { Height = 100, Width = 50, Position = new() { X = 1, Y = 2 }, ShapeType = ShapeType.Circle });
//shapes.Add(new Shape() { Height = 100, Width = 50, Position = new() { X = 1, Y = 2 }, ShapeType = ShapeType.Rectangle });

//用到里氏转换 向上转换 
shapes.Add(new Circle() { Height = 100, Width = 50, Position = new() { X = 1, Y = 2 } });
shapes.Add(new Rectangle() { Height = 100, Width = 50, Position = new() { X = 1, Y = 2 } });
var t = new Triangle() { Height = 100, Width = 50, Position = new() { X = 1, Y = 2 } };
shapes.Add(t);
Console.WriteLine(t.ToString());

Canvas canvas = new Canvas();
canvas.DrawShapes(shapes);

Console.ReadKey();

                                                                                                 