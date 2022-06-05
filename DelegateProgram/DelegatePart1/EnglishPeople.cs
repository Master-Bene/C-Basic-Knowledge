using System;

namespace DelegateProgram.DelegatePart1
{
    public class EnglishPeople: IGreetService
    {
        public void EnglishGreeting(string name)
        {
            Console.WriteLine($"Moring,{name}");
        }

        public void Greeting(string name)
        {
            Console.WriteLine($"Moring,{name}");
        }
    }



}
