// See https://aka.ms/new-console-template for more information




using InheritanceAndComposition;

Console.WriteLine("Hello, World!");

PresentationObject presentationObject = new PresentationObject();

presentationObject.Height = 100;

//继承了父类/基类
Text text = new Text();
text.Height = 50;
text.FontWeight = 400;
text.Copy();
text.AddHyperLink();

Console.WriteLine("================");
//类复合的方式  使用一个通用logger组件，完成了日志系统在数据迁移和安装系统中的代码复用和使用 
Logger logger = new Logger();
Install install = new Install(logger);
DbMigrator dbMigrator = new DbMigrator(logger);
install.install();
dbMigrator.Migrate();


//base关键字操作派生类初始化时如何选择调用哪个基类构造函数
Console.WriteLine("================");
Manager manager = new Manager(123);
Console.WriteLine(manager.Number);

Console.WriteLine("================");
//里氏转换法                           
//向上转换：将一个派生类类型赋值（转换）给他的基类。这个转换过程是隐式的
//向下转换：将一个基类赋值（强转换）给他的派生类。（前提：基类中装的是一个派生类对象，那么可以将这个基类强转为他的派生类对象。）这个转换过程是显式的

//派生类对象可以调用基类中的成员，但是基类对象永远只能调用自己的成员

//is—表示类型转换，如果转换成功就返回true否则就是false
//as—表示类型转换，如果转换成功就返回该对象 否则就是null

Image image = new Image { Width = 100, Height = 50, X = 10, Y = 20, Name = "1.jpg", Description = "北京" };
image.Draw();
image.Show();
Shape shape = image;
shape.Draw();


Shape shape1 = new Shape() { Width = 200, Height = 10, X = 20, Y = 30, };
shape1.Draw();


Image image2;
//基类中装的不是派生类对象，向下转换会报错
//image2 = (Image)shape1;
//基类中装的不是派生类对象，向下转换不会报错，但是返回得是null
image2 = shape1 as Image;
//image2 = shape1 is Image ? shape1 as Image : null;
if (shape1 is Image)
{
    image2 = (Image)shape1;
}
//基类中是派生类对象，向下转换不会报错
image2 = (Image)shape;

image2.Draw();
image2.Show();


Console.ReadKey();



