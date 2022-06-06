using System;
using System.Diagnostics;
using DelegateProgram.DelegatePart1;
using DelegateProgram.Observer;
using DelegateProgram.Publish_Subscriber;

namespace DelegateProgram
{
    public class Program
    {
        static void Main(string[] args)
        {


            #region 最开始设计只有中国人使用，所以只有中文语言可以进行问候。

            //ChinesePeople chinesePeople = new ChinesePeople();
            //chinesePeople.ChineseGreeting("小杰");

            #endregion

            #region 后来升级需要增加英语问候。为了省事升级方式：通过枚举作为判断依据，添加英语的问候。

            //TODO：用英文和中文分别打招呼，需要调用两个对象两个方法，封装太差。
            //ChinesePeople chinesePeople1 = new ChinesePeople();
            //chinesePeople1.ChineseGreeting("小杰");
            //EnglishPeople englishPeople1 = new EnglishPeople();
            //englishPeople1.EnglishGreeting("小杰");

            //TODO：创建一个专门用来打招呼的人类包含了打招呼的处理流程。只需要告诉处理程序跟谁打招呼，用那种语言就可以了。
            //People people = new People();
            //people.GreetProcessing("小杰", Language.Chinese);
            //people.GreetProcessing("小杰", Language.English);

            #endregion

            #region 在后来要走向国际化除了之前增加的英语外还需要增加日语、汉语、法语等等一些列语言。需要每次在枚举和处理程序中增加相应的代码，才能完善多国语言需求。

            //People people1 = new People();
            //people1.GreetProcessing("小杰", Language.Chinese);
            //people1.GreetProcessing("小杰", Language.English);
            //people1.GreetProcessing("小杰", Language.Japanese);
            //people1.GreetProcessing("小杰", Language.Korean);
            //people1.GreetProcessing("小杰", Language.French);
            #endregion

            #region 上面的扩展性也太差了，以后再多几个国家的语言都要这样维护枚举和处理程序中代码，简直要累死。那就在进行升级：使用接口+多态提取问候操作。

            //People people2 = new People(new ChinesePeople());
            //people2.GreetProcessing("小杰");

            //People people3 = new People(new EnglishPeople());
            //people3.GreetProcessing("小杰");

            //People people4 = new People(new JapanPeople());
            //people4.GreetProcessing("小杰");

            //People people5 = new People(new SouthKoreaPeople());
            //people5.GreetProcessing("小杰");

            //People people6 = new People(new FrancePeople());
            //people6.GreetProcessing("小杰");

            #endregion

            #region 使用了接口+多态确实减少了维护枚举和处理程序代码，扩展性也得到了一定提升每次只需要扩展不同国家语言的类和实现问候的接口。但也仅限于一个人使用一个语言问候。但凡一个人要使用多个语言问候就要向上面一样多次实例化People.那就再次升级：添加一个注册问候的方式，将问候语言添加进来。

            //People people7 = new People();
            //people7.RegesiterGreeting(new ChinesePeople());
            //people7.RegesiterGreeting(new EnglishPeople());
            //people7.RegesiterGreeting(new JapanPeople());
            //people7.RegesiterGreeting(new SouthKoreaPeople());
            //people7.RegesiterGreeting(new FrancePeople());
            //people7.GreetUpgradeProcessing("小杰");

            #endregion

            #region 上面已经解决了大部分问题，可以做到不用维护枚举和处理程序的同时，也可以使用一次实例化注册多个问候。但是还是有点问题，对于一个简单的问候需要每次都创建一个国家类同时实现问候接口。国家越多类也就越多维护成本也会越高，而且每次要实例化各个国家才能注册不同语言的问候方式。如何能只使用简单问候而不用实例化这些国家。就像传递小杰这个问候人一样，通过传递参数形式来处理不同的问候。

            People people8 = new People();
            //people8.GreetProcessing("小杰", DiffLanguageGreeting.ChineseGreeting);
            //people8.GreetProcessing("小杰", DiffLanguageGreeting.EnglishGreeting);
            //people8.GreetProcessing("小杰", delegate (string name) { Console.WriteLine($"德语-Guten Morgen,{name}"); });
            //people8.GreetProcessing("小杰", (name) => { Console.WriteLine("俄罗斯-Добрай раніцы" + name); });

            //TODO:不一定直接在GreetProcessing方法中给name参数赋值。可以声明变量然后再给方法赋值。
            //string name1, name2;
            //name1 = "小王";
            //name2 = "小张";
            //people8.GreetProcessing(name1, DiffLanguageGreeting.FranchGreeting);
            //people8.GreetProcessing(name2, DiffLanguageGreeting.FranchGreeting);

            //TODO:而委托GreetingDelegate类型和Sting类型地位一样，都是可以定义一种参数类型。那么 我们是不是也可以这样使用委托？

            //string name3, name4;
            //name3 = "小王";
            //name4 = "小张";

            //GreetingDelegate greetingDelegate1, greetingDelegate2, greetingDelegate3;
            //greetingDelegate1 = DiffLanguageGreeting.KoreanGreeting;
            //greetingDelegate2 = DiffLanguageGreeting.JapaneseGreeting;
            ////自定义
            //greetingDelegate3 = delegate (string name) { Console.WriteLine($"我的委托方法,{name}"); };

            //people8.GreetProcessing(name3, greetingDelegate1);
            //people8.GreetProcessing(name4, greetingDelegate2);
            //people8.GreetProcessing(name4, greetingDelegate3);

            //TODO:如你所料，这样是没有问题的，程序如预料的那样输出。
            //TODO:这里，我想说的是委托不同于string的一个特性：可以将多个方法赋给同一个委托，或者叫将多个方法绑定到同一个委托，当调用这个委托的时候，将依次调用所绑定的方法。
            //TODO:可以解决上面每次不同的问候都要调用一次GreetProcessing 方法。对于一个会多国语言的人来说优点反锁。

            string name5;
            name5 = "小刘";

            //GreetingDelegate greetingDelegate4;
            ////可以将多个方法赋给同一个委托，或者叫将多个方法绑定到同一个委托
            //greetingDelegate4 = DiffLanguageGreeting.ChineseGreeting;
            //greetingDelegate4 += DiffLanguageGreeting.EnglishGreeting;
            //greetingDelegate4 += DiffLanguageGreeting.JapaneseGreeting;

            ////当调用这个委托的时候，将依次调用所绑定的方法  （先调用：ChineseGreeting 再调用：EnglishGreeting 最后调用：JapaneseGreeting）
            //people8.GreetProcessing(name5, greetingDelegate4);

            ////TODO:实际上，我们可以也可以绕过GreetPeople方法，通过委托来直接调用ChineseGreeting、EnglishGreeting、JapaneseGreeting：
            ////这在本例中是没有问题的，但回头看下上面GreetProcessing的定义，在它之中可以做一些对于EnglshihGreeting和ChineseGreeting来说都需要进行的工作，为了简便我做了省略。
            //greetingDelegate4(name5);


            ////TODO: 注意上面这里，第一次用的“=”，是赋值的语法；第二次，用的是“+=”，是绑定的语法。如果第一次就使用“+=”，将出现“使用了未赋值的局部变量”的编译错误。
            ////TODO: 我们也可以使用下面的代码来这样简化这一过程：
            //GreetingDelegate greetingDelegate5 = new GreetingDelegate(DiffLanguageGreeting.ChineseGreeting);  //GreetingDelegate greetingDelegate6 = DiffLanguageGreeting.ChineseGreeting;
            //greetingDelegate5 += DiffLanguageGreeting.EnglishGreeting;
            ////看到这里，应该注意到，这段代码第一条语句与实例化一个类是何其的相似，你不禁想到：上面第一次绑定委托时不可以使用“+=”的编译错误。
            ////或许可以用下面这样的方法来避免：但实际上，这样会出现编译错误： “GreetingDelegate”方法不包含采用“0”个参数的构造方法。尽管这样的结果让我们觉得有点沮丧，但是编译的提示：“没有0个参数的重载”再次让我们联想到了类的构造函数。我知道你一定按捺不住想探个究竟，但再此之前，我们需要先把基础知识和应用介绍完。
            ////GreetingDelegate greetingDelegate6 = new GreetingDelegate();
            ////greetingDelegate6 += DiffLanguageGreeting.ChineseGreeting;
            ////greetingDelegate6 += DiffLanguageGreeting.EnglishGreeting;

            //people8.GreetProcessing(name5, greetingDelegate5);

            ////TODO: 既然给委托可以绑定一个方法，那么也应该有办法取消对方法的绑定，很容易想到，这个语法是“-=”：
            //greetingDelegate5 -= DiffLanguageGreeting.ChineseGreeting;

            //people8.GreetProcessing(name5, greetingDelegate5);

            #endregion


            #region 上面讲述了【将方法作为方法的参数】和【将方法绑定到委托】，接下来讲述【事件的由来】
            //TODO:到这里，不禁想想到：面向对象设计，讲究的是对象的封装，既然可以声明委托类型的变量(例如上面的greetingDelegate4,greetingDelegate5等)，我们何不将这个变量装到People类中？在这个类的客户端（实例化）中 使用不是更方便吗？再次升级
            People people9 = new People
            {
                greetingDelegate = DiffLanguageGreeting.ChineseGreeting
            };
            people9.greetingDelegate += DiffLanguageGreeting.EnglishGreeting;

            //people9.GreetProcessing("小李", people9.greetingDelegate);
            //尽管这样做没有任何问题，但我们发现这条语句很奇怪。在调用people9.GreetProcessing，再次传递了greetingDelegate字段.既然如此，我们何不修改People类成这样：
            //people9.GreetProcessingWithDelegate("小李");
            //客户端可以直接调用委托变量
            //people9.greetingDelegate("小杰");

            //尽管这样达到了我们要的效果，但是还是存在着问题:
            //    1.它进行随意的赋值等操作，严重破坏对象的封装性
            //    2.第一个方法注册用“=”，是赋值语法，因为要进行实例化，第二个方法注册则用的是“+=”,是绑定操作。但是，不管是赋值还是注册，都是将方法绑定到委托上，除了调用时先后顺序不同，再没有任何的分别，这样不是让人觉得很别扭么？ 
            //现在我们想想，如果_greetingDelegate不是一个委托类型，而是一个string类型，你会怎么做？答案是使用属性对字段进行封装。
            //于是，Event出场了，它封装了委托类型的变量，使得：在类的内部，不管你声明它是public还是protected，它总是private的。在类的外部，注册“+=”和注销“-=”的访问限定符与你在声明事件时，使用的访问符相同。
            //声明一个事件,类似于声明一个进行了封装的委托类型的变量而已
            people9.MKGreetingDelegate += DiffLanguageGreeting.ChineseGreeting;
            people9.MKGreetingDelegate += DiffLanguageGreeting.EnglishGreeting;
            //people9.GreetProcessingWithEvent("小李");

            people9.MKGreetingDelegate -= DiffLanguageGreeting.ChineseGreeting;
            //people9.GreetProcessingWithEvent("小李");

            #endregion

            #region 委托、事件与Observer设计模式
            //Heater heater = new Heater();
            //heater.BoilWater();

            //AssembleHeater heater2 = new AssembleHeater();
            //Alarm alarm = new Alarm();
            //heater2.OnBoild += alarm.MakeAlert; //注册方法
            //heater2.OnBoild += new Alarm().MakeAlert;   //给匿名对象注册方法
            //heater2.OnBoild += Display.ShowMsg; //注册静态方法

            //heater2.BoilWater();

            #endregion

            #region 发布者(publish)-订阅者(subscriber)-客户端(client)模式  | 主题(subject)-观察者(observer) Observer模式 （客户端通常是包含Main方法的Program类）
            //当前在客户端
            Publish publish = new Publish();
            Subscriber subscriber = new Subscriber();
            publish.NumberChange += new NumberChangeEventHandler(subscriber.OnNumberChange);
            publish.ActionNumberChange += subscriber.OnNumberChange;

            //publish.DoSomething();      // 事件应该由事件发布者触发，
            //publish.NumberChange(99);   // 而不应该由客户端来触发
            //publish.ActionNumberChange(100); //但可以被这样直接调用，对委托变量的不恰当使用。

            //这时候就引入了事件 通过添加Event关键字来发布事件，事件的发布者的封装性更好。事件仅仅是提供其他类型来注册的，而客户端不能直接触发事件。
            //可以尝试将委托变量的声明代码注释掉。然后取消事件声明的注释。此时  publish.NumberChange(99)和publish.ActionNumberChange(100) 无法通过编译。正好说明了事件只能在事件发布者的内部触发，比如DoSomething中，而客户端是不能直接调用的。

            //多个订阅者方法都会向发布者返回数值，结果就是后面一个返回的方法值将前面的返回值覆盖掉了，只返回最后一个订阅者的方法。
            Publish publish2 = new Publish();
            Subscriber subscriber1 = new Subscriber();
            Subscriber2 subscriber2 = new Subscriber2();
            Subscriber3 subscriber3 = new Subscriber3();

            //publish2.NumberChange2 += subscriber1.OnNumberChange;
            //publish2.NumberChange2 += subscriber2.OnNumberChange;
            //publish2.NumberChange2 += subscriber3.OnNumberChange;
            //publish2.DoSomething();


            //事件只允许一个客户订阅
            Publish publish3 = new Publish();
            Subscriber subscriber4 = new Subscriber();
            Subscriber2 subscriber5 = new Subscriber2();

            publish3.NumberChange3 -= subscriber4.OnNumberChange;
            publish3.NumberChange3 += subscriber5.OnNumberChange;
            publish3.NumberChange3 += subscriber4.OnNumberChange;
            //publish3.DoSomething();


            //就想获得多个返回值与异常处理
            Publish publish4 = new Publish();
            Subscriber subscriber6 = new Subscriber();
            Subscriber2 subscriber7 = new Subscriber2();
            Subscriber3 subscriber8 = new Subscriber3();

            publish4.NumberChange4 += subscriber6.OnNumberChange1;
            publish4.NumberChange4 += subscriber7.OnNumberChange1;
            publish4.NumberChange4 += subscriber8.OnNumberChange1;
            //publish4.DoSomething();

            //var ret = publish4.DoSomethings(delegate () { Console.WriteLine("123"); });
            //publish4.DoSomethings(() => { Console.WriteLine("123"); });
            publish4.ReturnMsg?.ForEach(f => Console.WriteLine(f));


            #endregion

            #region 委托中订阅者方法超时的处理
            Publish publish5 = new Publish();
            Subscriber subscriber9 = new Subscriber();
            Subscriber2 subscriber10 = new Subscriber2();
            Subscriber3 subscriber11 = new Subscriber3();

            publish5.NumberChange5 += subscriber9.OnInvoke;
            publish5.NumberChange5 += subscriber10.OnInvoke;
            publish5.NumberChange5 += subscriber11.OnInvoke;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            publish5.DoSomething();
            //subscriber9.OnInvoke();
            //subscriber10.OnInvoke();
            //subscriber11.OnInvoke();
            sw.Stop();
            Console.WriteLine($"\n{sw.ElapsedMilliseconds}毫秒 Control back to client!"); // 返回控制权

            #endregion

            Console.ReadKey();
        }
    }
}
