using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static int i;
        static int[] _items;

        public static int Capacity
        {
            get
            {
                return _items.Length;
            }

            set
            {
                if (value < i)
                {
                    Console.WriteLine("123");
                    //ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_SmallCapacity);
                }
                if (value == _items.Length)
                {
                    return;
                }
                if (value > 0)
                {
                    int[] array = new int[value];
                    if (i > 0)
                    {
                        Array.Copy(_items, 0, array, 0, i);
                    }
                    _items = array;
                }
                else
                {
                    _items = _emptyArray;
                }
            }
        }
        private static readonly int[] _emptyArray = new int[0];
        static void Main(string[] args)
        {
            Func<int> func0;
            Func<string, int> func1;
            Func<string, string,int> func2;

            String str1 = "abc";
            String str2 = "abc";
            int a = 1;
            int b = 1;
            StringBuilder strb1 = new StringBuilder("abc");
            StringBuilder strb2 = new StringBuilder("abc");
            Console.WriteLine("Reference equal for string: " + Object.ReferenceEquals(str1, str2)); //结果true
            Console.WriteLine("Reference equal for int: " + Object.ReferenceEquals(a, b)); //结果false
            Console.WriteLine("Reference equal for StringBuilder: " + Object.ReferenceEquals(strb1, strb2)); //结果false
            Console.WriteLine("Value equal for string: " + str1.Equals(str2)); //结果true，类似于值类型
            Console.Read();


            string s1 = "123";
            string s2 = "456";
            string s3 = "789";
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            s1 = s3;
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);

            List<string> l1=new List<string>();
            List<string> l2 = new List<string>();
            l2 = l1;
            l1.Add("a");
            l1.GetEnumerator().MoveNext();
            foreach (var item in l1)
            {
                Console.WriteLine(item); 
            }

            Console.WriteLine(string.Join(",",l1));
            Console.WriteLine(string.Join(",", l2));
            List<string> l3 = new List<string>();
            l3.Add("b");
            l2 = l3;
            l1 = l3;
         
            Console.WriteLine(string.Join(",", l1));
            Console.WriteLine(string.Join(",", l2));
            Console.WriteLine(string.Join(",", l3));

            DateTime? dateTime = null;
            dateTime.GetValueOrDefault();
            List<int> lisy = new List<int>();
            Console.WriteLine($"count {lisy.Count} -- {lisy.Capacity }");
            lisy.Add(1);
            lisy.Insert (2, 2);
            Console.WriteLine($"count {lisy.Count} -- {lisy.Capacity}");
            Console.WriteLine($"item{string.Join("|",lisy)} count {lisy.Count} -- {lisy.Capacity}");

            //List<string> lisy2 = new List<string>();
            //foreach (var item in lisy2)
            //{
            //    item = "123";
            //}

            List<List<string>> lisy2 = new List<List<string>>();

            lisy2.Add(new List<string> { "1", "2" });
            _items = _emptyArray;
            int ip = 54;
            if (i == _items.Length)
            {
                EnsureCapacity(i + 1);
            }

            _items[i++] = 54;
            Console.WriteLine(_items[i]);
            //IEnumerable
            //IEnumerator
            Console.ReadKey();


        }

        private static string FileInfoCompare(string path)
        {
            return path;
        }

        private static void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int num = ((_items.Length == 0) ? 4 : (_items.Length * 2));
                if ((uint)num > 2146435071u)
                {
                    num = 2146435071;
                }
                if (num < min)
                {
                    num = min;
                }
                Capacity = num;
            }
        }
    }
}
