using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateProgram.Publish_Subscriber
{
    //定义委托
    public delegate void NumberChangeEventHandler(int count);
    public delegate string NumberChangeEventHandler2();
    public delegate string NumberChangeEventHandler3(int count);
    public delegate void NumberChangeEventHandler4();
    public class Publish
    {
        private int count;
        //声明委托变量
        //public NumberChangeEventHandler NumberChange;
        //使用预定义委托Action声明委托变量
        //public Action<int> ActionNumberChange;

        //声明事件
        public event NumberChangeEventHandler NumberChange;
        //使用预定义委托Action声明事件
        public event Action<int> ActionNumberChange;

        //默认
        public event NumberChangeEventHandler2 NumberChange2;


        private NumberChangeEventHandler2 _numberchange3;
        //事件访问器，不写默认会有一个事件访问器类似自动属性，如果有特殊需要就在get set中写内容，没有就用使用自动属性。
        public event NumberChangeEventHandler2 NumberChange3
        {
            add { _numberchange3 = value; }
            remove { _numberchange3 -= value; }
        }

        public List<string> ReturnMsg { get; set; } = new List<string>();
        public event NumberChangeEventHandler3 NumberChange4;

        public void DoSomething()
        {
            //在这里完成一些工作

            if (NumberChange != null)
            {
                this.count++;
                NumberChange(this.count);
            }
            if (ActionNumberChange != null)
            {
                this.count++;
                ActionNumberChange(this.count);
            }
            if (NumberChange2 != null)
            {
                this.count++;
                Console.WriteLine(NumberChange2());
            }
            if (_numberchange3 != null)
            {
                this.count++;
                Console.WriteLine("Return=" + _numberchange3());
            }
            if (NumberChange4 != null)
            {
                //1.尽管我们捕获了异常，使得程序没有异常结束，但是却影响到了后面的订阅者，因为Subscriber3也订阅了事件，但是却没有收到事件通知（它的方法没有被调用）
                //try
                //{
                //    this.count++;
                //    NumberChange4(count);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Exception:" + ex.Message);
                //}

                //2.此时，我们可以采用 先获得委托链表，然后在遍历这个链表，通过环链表中的每个委托对象来调用方法，这样可以分别获得每个方法的返回值或异常处理，而不至于返回值被覆盖或异常中断，而影响到后续订阅者的方法调用：
                //Delegate[] delArr = NumberChange4.GetInvocationList();
                //foreach (Delegate item in delArr)
                //{
                //    this.count++;
                //    try
                //    {
                //        // 进行一个向下转换
                //        NumberChangeEventHandler3 method = (NumberChangeEventHandler3)item;
                //        string msg = method(count);
                //        ReturnMsg.Add(msg);
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine($"Exception:{ex.InnerException?.Message ?? ex.Message}");
                //    }
                //}

                //3.注意到Delegate是NumberChangeEventHandler3的基类，所以为了触发事件，先要进行一个向下的强制转换，之后才能在其上触发事件，调用所有注册对象的方法。除了使用这种方式以外，还有一种更灵活方式可以调用方法，它是定义在Delegate基类中的DynamicInvoke()方法
                Delegate[] delArr2 = NumberChange4.GetInvocationList();
                foreach (Delegate item2 in delArr2)
                {
                    this.count++;
                    try
                    {
                        // 使用DynamicInvoke方法触发事件
                        var msg = item2.DynamicInvoke(this.count);
                        ReturnMsg.Add(msg.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception:" + (ex.InnerException?.Message ?? ex.Message));
                    }
                }
            }
        }


        public (string msg, bool isok) DoSomethings(NumberChangeEventHandler4 numberChangeEventHandler4)
        {
            numberChangeEventHandler4();
            return ("test", true);
        }

    }
}
