using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal class Partial
    {
        // <Partial Type>
        // 클래스, 구조체, 인터페이스를 분할하여 구현하는 방법
        // 대규모 프로젝트에서 작업하는 경우 분산하여 구현에 유용

        // 전투담당자 Player 소스
        public partial class Player
        {
            private int hp;

            public void Attack() { }
            public void Defense() { }
        }

        // 아이템담당자 Player 소스
        public partial class Player
        {
            private int weight;

            public void GetItem() { }
            public void UseItem() { }
        }


        // <Partial Method>
        // Partial Type에서 Partial Method가 포함될 수 있음
        // 선언부와 구현부를 분리하여 구현함으로서 구현부를 숨길 수 있음

        // 선언부 : 함수가 있다는 것만 표시
        public partial class Monster
        {
            public partial void Attack();
        }

        // 구현부 : 함수를 실제로 구현
        public partial class Monster
        {
            public partial void Attack()
            {
                // method body
            }
        }
    }
}
