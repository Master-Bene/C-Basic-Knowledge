// See https://aka.ms/new-console-template for more information



int result = FindMax(1, 99);
Console.WriteLine(result);

int a = 1;
int b = 99;
FindeMax2(a, b);
FindeMax3(a, b);

Console.ReadKey();

static int FindMax(int num1, int num2)
{
    int result;
    if (num1 > num2)
        result = num1;
    else
        result = num2;
    return result;
}

static void FindeMax2(int num1, int num2) => Console.WriteLine(num1 > num2 ? num1 : num2);

static void FindeMax3(int num1, int num2)
{
    if (num1 > num2)
        Console.WriteLine(num1);
    else
        Console.WriteLine(num2);
}


//class Program
//{
//    static void Main(String[] args)
//    {
//        int result = FindMax(1, 99);
//        Console.WriteLine(result);

//        int a = 1;
//        int b = 99;
//        FindeMax2(a, b);
//        FindeMax3(a, b);



//        Console.ReadKey();
//    }

//    static int FindMax(int num1, int num2)
//    {
//        int result;
//        if (num1 > num2)
//            result = num1;
//        else
//            result = num2;
//        return result;
//    }
//    public static void FindeMax2(int num1, int num2) => Console.WriteLine(num1 > num2 ? num1 : num2);

//    public static void FindeMax3(int num1, int num2)
//    {
//        if (num1 > num2)
//            Console.WriteLine(num1);
//        else
//            Console.WriteLine(num2);
//    }


//}





