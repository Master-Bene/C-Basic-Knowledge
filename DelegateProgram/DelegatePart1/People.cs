using System;
using System.Collections.Generic;

namespace DelegateProgram.DelegatePart1
{
    public delegate void GreetingDelegate(string name);
    public partial class People
    {
        private readonly IGreetService greetService;
        private readonly List<IGreetService> greetingServices;
        //在类的内部声明委托变量greetingDelegate的字段。
        public GreetingDelegate greetingDelegate;
        private GreetingDelegate _greetingDelegate;
        //在类的内部声明一个事件，相当于声明了一个对委托类型变量的封装。
        public event GreetingDelegate MKGreetingDelegate;
        //{
        //    add
        //    {
        //        this._greetingDelegate += value;
        //    }
        //    remove
        //    {
        //        this.greetingDelegate -= value;
        //    }
        //}
        public People()
        {
            greetingServices = new List<IGreetService>();
        }
        public People(IGreetService greetService)
        {
            this.greetService = greetService;
        }

        public void RegesiterGreeting(IGreetService greetService)
        {
            greetingServices.Add(greetService);
        }

        public void GreetProcessing(string name, Language language)
        {
            switch (language)
            {
                case Language.Chinese:
                    new ChinesePeople().ChineseGreeting(name);
                    break;
                case Language.English:
                    new EnglishPeople().EnglishGreeting(name);
                    break;
                case Language.Japanese:
                    new JapanPeople().JapaneseGreeting(name);
                    break;
                case Language.Korean:
                    new SouthKoreaPeople().KoreanGreeting(name);
                    break;
                case Language.French:
                    new FrancePeople().FranchGreeting(name);
                    break;
                default:
                    break;
            }
        }

        public void GreetProcessing(string name)
        {
            greetService.Greeting(name);
        }
        public void GreetUpgradeProcessing(string name)
        {
            foreach (var greatService in greetingServices)
            {
                greetService.Greeting(name);
            }
        }

        public void GreetProcessing(string name, GreetingDelegate makeGreeting)
        {
            makeGreeting(name);
        }
        public void GreetProcessingWithDelegate(string name)
        {
                greetingDelegate?.Invoke(name);
        }

        public void GreetProcessingWithEvent(string name)
        {
            MKGreetingDelegate?.Invoke(name);
        }
    }
}
