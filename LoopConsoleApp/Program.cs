// See https://aka.ms/new-console-template for more information
using LoopConsoleApp;
using System.Diagnostics;

public class Program
{

    static void Main(String[] args)
    {
        //Stopwatch sw = Stopwatch.StartNew();
        Console.WriteLine("test");

        //每个对象都是某个类的一个实例
        //通过new关键字实例化Program类，实例化的产物是一个对象或者实例，名字叫pr
        Program pr = new Program();
        pr.Name = "0";

        //对象初始化器 简化对象的初始化 
        Program program1 = new Program
        {
            Name = "1"
        };

        Program program2 = new Program("1");
        Program program3 = new("2") { Name = "2" };

        Point p = new Point();
        Console.WriteLine(p.propg);
        p.sets = 15;
        Console.WriteLine(Point.π);

        string[] gama = new string[] { "I", "A", "M", "S", "J", "M", "Y" };

        Console.WriteLine(gama[gama.Length - 1]);
        Console.WriteLine(gama[^1]);
        Index _index = ^2;
        Console.WriteLine(gama[_index]);

        Range range = 2..4;
        var list = gama[range];
        for (int i = 0; i < list.Length; i++)
        {
            Console.WriteLine(list[i]);
        }

        Console.WriteLine(p[0]);
        p[0] = "hello";
        Console.WriteLine(p[0]);
        Console.WriteLine(p["J"]);


    }
    public Program()
    {
    }
    public Program(string desc)
    {

    }
    /// <summary>
    /// 私有成员变量 字段
    /// </summary>
    private string name;
    /// <summary>
    /// 属性
    /// </summary>
    public string Name
    {
        get => name;
        set => name = value;
    }
    public string Descriptiron { get => descriptiron; set => descriptiron = value; }

    private string descriptiron;

    /// <summary>
    ///  自动属性
    /// </summary>
    public string Year { get; set; }
}
