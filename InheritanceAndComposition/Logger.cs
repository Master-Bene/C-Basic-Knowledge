// See https://aka.ms/new-console-template for more information


namespace InheritanceAndComposition
{
    public partial class Logger
    {
        public void Log(string msg)
        {
            Console.WriteLine($"日志：{DateTime.Now} - {msg} ");
        }
    }
}


