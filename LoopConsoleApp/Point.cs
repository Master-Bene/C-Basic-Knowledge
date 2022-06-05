using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopConsoleApp
{
    public partial class Point
    {
        //常量 一单运行程序是不会放生变化的 
        public const double π = 3.1415;
        private int x;
        private int y;
        public Point()
        {
            this.y = 10;
        }
        // 自己写属性(方法的形式)
        //public void SetX(int x)
        //{
        //    this.x = x;
        //}
        public void SetX(int x) => this.x = x;   //方法表达式
        public int Getx() => this.x;

        //属性
        //public int Y { 
        //    get { return y; } 
        //    set { this.y = value; } 
        //}
        public int Y { get => y; set => y = value; }

        /// <summary>
        /// 自动属性    public int Z{get;} //编译不通过 。 必须同时声明get 和set 访问器。若要创建readonly 自动实现属性，请给予它 private set 访问器   public int Z{ get; private set;} 
        /// </summary>
        public int Z { get; set; }

        public int prop { get; set; }

        private int myVar;

        public int propfull
        {
            get { return myVar; }
            set { myVar = value; }
        }
        //readonly
        public int propg { get; private set; } = 5;
        //writeonly
        public int sets { private get; set; } = 12;

        public string[] gama = new string[] { "I", "A", "M", "S", "J", "M", "Y" };
        //类级别索引 可以快速访问类中数组的某一项
        public string this[int index]
        {
            get => gama[index]; set => gama[index] = value;
        }
        public int this[string str]
        {
            get => Array.IndexOf(gama,str);
        }
    }

    public partial class Point { 
    
    }
}
