// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");

//TODO 设置可空 两者是一样的 后者是语法糖
Nullable<DateTime> date = new DateTime(2099,1,1);
DateTime dateTime = date.GetValueOrDefault();
DateTime? dt = dateTime;
if (dt.HasValue)
{
    Console.WriteLine(dt.GetValueOrDefault());
}
else
{
    Console.WriteLine(DateTime.Now);
}

Console.WriteLine(dt ?? new DateTime(2022, 5, 5));

IEnumerable list = new List<int>();


