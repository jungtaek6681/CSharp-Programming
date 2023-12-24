using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._Delegate
{
    internal class Lambda
    {
        /*************************************************************************
         * 무명메서드와 람다식
         * 
         * 델리게이트 변수에 할당하기 위한 함수를 소스코드 구문에서 생성하여 전달
         * 전달하기 위한 함수가 간단하고 일회성으로 사용될 경우에 간단하게 작성
         *************************************************************************/

        void Main()
        {
            Func<string, int> func;

            // <함수를 통한 할당>
            // 클래스에 정의된 함수를 직접 할당
            // 클래스의 멤버함수로 연결하기 위한 기능이 있을 경우 적합
            func = CharCount;


            // <무명메서드>
            // 함수를 통한 연결은 함수가 직접적으로 선언되어 있어야 사용 가능
            // 할당하기 위한 함수가 간단하고 자주 사용될수록 비효율적
            // 간단한 표현식을 통해 함수를 즉시 작성하여 전달하는 방법
            func = delegate (string str) { return str.Length; };


            // <람다식>
            // 무명메서드의 간단한 표현식
            func = (str) => { return str.Length; };
            func = str => str.Length;
        }

        int CharCount(string str) { return str.Length; }
    }
}
