using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal class OperatorOverloading
    {
        /**********************************************************************
         * 연산자 재정의 (Operator Overloading)
         *
         * 사용자정의 자료형이나 클래스의 연산자를 재정의하여 여러 의미로 사용
         **********************************************************************/

        // <연산자 재정의>
        // 기본연산자의 연산을 함수로 재정의하여 기능을 구현
        // 기본연산자를 호환하지 않는 사용자정의 자료형에 기본연산자 사용을 구현함

        public struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            // 연산자 재정의를 통한 기본연산자 사용 구현
            public static Point operator +(Point left, Point right)
            {
                return new Point(left.x + right.x, left.y + right.y);
            }
        }


        void Main()
        {
            Point point = new Point(3, 3) + new Point(2, 5);        // point == (5, 8)
            // Point point = new Point(3, 3) - new Point(1, 2);     // error : - 기본연산자는 재정의되어 있지 않음
        }
    }
}
