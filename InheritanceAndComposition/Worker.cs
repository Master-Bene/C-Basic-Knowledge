using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndComposition
{
    /// <summary>
    /// 员工类
    /// </summary>
    public class Staff
    {
        public int Number { get; set; }
        public Staff()
        {
            Console.WriteLine("员工类初始化-默认无参构造函数");
        }

        public Staff(int number)
        {
            Number = number;
            Console.WriteLine("员工类初始化-有参数构造函数");
        }
    }

    public class Manager : Staff
    {
        public Manager()
        {
            Console.WriteLine("经理类初始化-默认无参构造函数");
        }

        /// <summary>
        /// 使用base关键字选择基类中的构造函数作为初始化。否则使用默认无参数构造函数
        /// </summary>
        /// <param name="number"></param>
        public Manager(int number) : base(number)
        {
            Console.WriteLine($"经理类初始化- 有参构造函数 - {number}");
        }
    }
}
