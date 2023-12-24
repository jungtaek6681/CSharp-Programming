using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._Delegate
{
    internal class Specifier
    {
        /*******************************************************************
         * 지정자 (Specifier)
         * 
         * 델리게이트를 사용하여 미완성 상태의 함수를 구성
         * 매개변수로 전달한 지정자를 기준으로 함수를 완성하여 동작시킴
         * 기준을 정해주는 것으로 다양한 결과가 나올 수 있는 함수를 구성가능
         ********************************************************************/

        // <델리게이트를 지정자로 사용>
        // 매개변수로 함수에 필요한 기준을 전달
        // 전달한 기준을 통해 결과를 도출
        void Main()
        {
            int[] array = { 3, -2, 1, -4, 9, -8, 7, -6, 5 };

            int index1 = CountIf(array, IsPositive);            // 배열 중 값이 양수인 데이터 갯수
            int index2 = CountIf(array, IsNagative);            // 배열 중 값이 음수인 데이터 갯수
            int index3 = CountIf(array, value => value > 5);    // 배열 중 값이 5보다 큰 데이터 갯수
        }

        public static int CountIf(int[] array, Predicate<int> predicate)
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    return count++;
                }
            }

            return count;
        }

        public static bool IsPositive(int value)
        {
            return value > 0;
        }

        public static bool IsNagative(int value)
        {
            return value < 0;
        }
    }
}
