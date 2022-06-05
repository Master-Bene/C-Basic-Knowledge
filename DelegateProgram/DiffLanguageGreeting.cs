using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateProgram
{
    public static class DiffLanguageGreeting
    {
        public static void ChineseGreeting(string name)
        {
            Console.WriteLine($"早上好,{name}");
        }

        public static void EnglishGreeting(string name)
        {
            Console.WriteLine($"Moring,{name}");
        }
        public static void JapaneseGreeting(string name)
        {
            Console.WriteLine($"おはよう,{name}");
        }

        public static void KoreanGreeting(string name)
        {
            Console.WriteLine($"좋은 아침，{name}");
        }

        public static void FranchGreeting(string name)
        {
            Console.WriteLine($"Bonjour,{name}");
        }
    }
}
