using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Array
{
    internal class StringClass
    {
        // <string>
        // string은 문자들의 집합으로 표현됨
        // 내부적으로 문자 배열을 통해서 구현됨
        // 문자열은 텍스트를 나타내는 데 사용되는 char의 순차적 집합

        void Main1()
        {
            // string 사용
            string str = "abcde";
            Console.WriteLine(str);     // output : abcde

            // string은 char의 순차적 집합으로 표현 : 배열처럼 한글자에 접근가능
            Console.WriteLine(str[1]);  // output : b
            Console.WriteLine(str[3]);  // output : d

            // 단, 배열식으로 접근하여 문자를 변경 불가
            // str1[1] = 'a';           // error : 문자열의 배열접근은 읽기전용


            // char 배열로 문자열을 표현
            char[] array = new char[5]{ 'a', 'b', 'c', 'd', 'e' };
            Console.WriteLine(array);

            foreach (char c in array)
            {
                Console.Write($"{c}");
            }
        }


        // <string의 불변성(Immutable)>
        // string은 특징상 다른 기본자료형과 다르게 크기가 정해져 있지 않은 기본자료형
        // 이유는 string은 char의 집합이므로 char의 갯수에 따라 크기가 유동적
        // 따라서, string은 런타임 당시에 크기가 결정되며 그 크기가 일정하지 않음
        // 이에 string은 다른 기본자료형과 다르게 구조체가 아닌 클래스로 구현되어 있음 (런타임시 크기를 정할 수 있는 메모리는 힙영역을 사용)
        // 단, 기본자료형과 같이 값형식을 구현하기 위해 string 클래스에 처리를 값형식처럼 동작하도록 구현
        // 이를 구현하기 위해 string 간의 대입이 있을 경우 참조에 의한 주소값 복사가 아닌 깊은 복사를 진행
        // 결과적으로 데이터 자체를 복사하는 값형식으로 사용하지만 힙영역을 사용하기 때문에 string이 설정되면 변경할 수 없도록하는 '불변성'을 가짐

        void Main2()
        {
            string str1 = "abced";      // 힙영역에 abced 문자열을 저장하며 이를 str이 참조함
            str1 = "abc";               // 새로운 힙영역에 abc 문자열을 저장하며 이름 str이 참조함
            str1 = str1 + "123";        // 새로운 힙영역에 abc123 문자열을 저장하며 이를 str이 참조함

            string str2 = str1;         // class 이지만 string은 값형식처럼 사용되어야 하기 때문에
                                        // 힙영역에 abc123 문자열을 복사하여 str2가 참조하도록 함
        }


        // <메모리 파편화>
        // string 이 불변성 특징을 가지므로 새로운 데이터를 string에 할당할 때마다 기존 데이터는 버려짐
        // 이 버려지는 힙영역의 데이터는 가비지컬렉터의 대상이 되며, 이를 반복적으로 진행할 경우 가비지컬렉터에 부담이 됨
        // 여러 string의 할당을 반복적으로 변경하는 경우를 주의해야 프로그램의 안정성을 높일 수 있음
        void Main3()
        {
            // 문자열 붙이기 연산자 사용
            // +연산 : 권장하지 않는 방법, 가비지컬렉터에 부담이 됨
            // "abc123def456" 문자열을 얻어내기 위해 "abc", "def", "abc123", "abc123def" 이 가비지 발생
            string str = "abc" + 123 + "def" + 456;
        }


        // <String.Format>
        // 가비지컬렉터에 부담되지 않도록 설계된 문자열 사용방법
        // 프로그램 동작 중 각 항목이 매개변수 목록의 값으로 표현을 바꿈
        void Main4()
        {
            string str = string.Format("abc{0}def{1}", 123, 456);
        }


        // <문자열 보간>
        // String.Format의 간략한 표현
        // 문자열 형식을 지정하는 더욱 읽기 쉽고 편리한 구문을 제공
        void Main5()
        {
            string str = $"abc{123}def{456}";
        }


        // <문자열 간격 및 형식>
        // 문자열 형식을 표현하는데 값의 간격과 형식을 정함
        void Main6()
        {
            // 문자열 간격
            Console.WriteLine($"{"ABC",-5}!");              // output : ABC  !
            Console.WriteLine($"{"ABC",+5}!");              // output :   DEF!
            Console.WriteLine($"{"ABC",-5}!{"DEF",+5}!");   // output : ABC  !  DEF!
            Console.WriteLine($"{"ABC",+5}!{"DEF",-5}!");   // output :   ABC!DEF  !


            // 문자열 형식
            // - 10진수 형식 -
            Console.WriteLine($"{255:D5}");                 // output : 00255
            Console.WriteLine($"{0xFF:D5}");                // output : 00255

            // - 16진수 형식 -
            Console.WriteLine($"{255:X5}");                 // output : 000FF
            Console.WriteLine($"{0xFF:X5}");                // output : 000FF

            // - 숫자 형식 -
            Console.WriteLine($"{123456789:N2}");           // output : 123,456,789.00

            // - 고정소수점 형식 -
            Console.WriteLine($"{0.555:F2}, {0.554:F2}");   // output : 0.56, 0.55

            // - 부동소수점 형식 -
            Console.WriteLine($"{123.4567:E3}");            // output : 1.235E+002


            // 문자열 간격과 형식
            Console.WriteLine($"Text:{123.456,+8:F2}");    // output : Text:  123.46
        }


        // <StringBuilder>
        // 일정 버퍼를 사용하는 방식으로 가비지컬레터에 부담되지 않도록 설계됨
        void Main7()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append((char)65 + i);
                sb.Append(":");
                sb.Append(65 + i);
                sb.AppendLine();
            }
            string str = sb.ToString();
        }
    }
}
