using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._Delegate
{
    internal class Generic
    {
        /**************************************************************************
         * 일반화 델리게이트
         * 
         * 개발과정에서 많이 사용되는 델리게이트의 경우 일반화된 델리게이트를 사용
         **************************************************************************/

        // <Func 델리게이트>
        // 반환형과 매개변수를 지정한 델리게이트
        // Func<매개변수1, 매개변수2, ..., 반환형>
        int Plus(int left, int right) { return left + right; }
        int Minus(int left, int right) { return left - right; }

        void Main1()
        {
            Func<int, int, int> func;
            func = Plus;
            func = Minus;
        }


        // <Action 델리게이트>
        // 반환형이 void 이며 매개변수를 지정한 델리게이트
        // Action<매개변수1, 매개변수2, ...>
        void Message(string message) { Console.WriteLine(message); }

        void Main2()
        {
            Action<string> action;
            action = Message;
        }


        // <Predicate 델리게이트>
        // 반환형이 bool, 매개변수가 하나인 델리게이트
        bool IsSentence(string str) { return str.Contains(' '); }

        void Main3()
        {
            Predicate<string> predicate;
            predicate = IsSentence;
        }
    }
}
