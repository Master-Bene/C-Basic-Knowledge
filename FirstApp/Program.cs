// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

//字符串格式化
string name = "sj";
int age = 30;
Console.WriteLine("My name is {0}. I am {1} year old.", name, age);

string message = "My name is {0}. I am {1} year old.";
string output = string.Format(message, name, age);
Console.WriteLine(output);

//字符串内嵌（内插）
string message2 = $"My name is {name}. I am {age} year old.";
Console.WriteLine(message2);

//原义字符串
string message3 = @"My name is {0}.\n 
I am {1} year old.\n
";
Console.WriteLine(message3);
Console.WriteLine(string.Format(message3, name, age));


Console.ReadKey();


