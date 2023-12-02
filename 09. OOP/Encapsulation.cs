using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._OOP
{
    internal class Encapsulation
    {
        /**********************************************************************
         * 캡슐화 (Encapsulation)
         *
         * 객체를 정보와 기능으로 묶는 것을 의미
         * 객체의 내부 정보와 기능을 숨기고, 허용한 정보와 기능만의 액세스 허용
         **********************************************************************/

        // <캡슐화>
        // 객체를 정보와 기능으로 묶는 것, 객체의 정보와 기능을 멤버라고 표현함
        // 현실세계의 객체를 표현하기 위해 객체가 가지는 정보와 행동을 묶어 구현하며 이를 통해 객체간 상호작용
        class Capsule
        {
            int variable;           // 멤버변수 : 객체의 정보를 표현
            void Function() { }     // 멤버함수 : 객체의 기능을 표현
        }


        // <접근제한자>
        // 외부에서 접근이 가능한 멤버변수와 멤버함수를 지정하는 기능
        // 접근제한자를 지정하지 않는 경우 기본접근제한자는 private
        // public    : 외부에서도 접근가능
        // private   : 내부에서만 접근가능
        // protected : 상속한 클래스에서 public, 그외에는 private
        class AccessSpecifier
        {
            public int publicValue;
            private int privateValue;

            void Function()
            {
                publicValue = 1;            // 접근가능
                privateValue = 2;           // 접근가능
            }
        }

        void Main1()
        {
            AccessSpecifier instance = new AccessSpecifier();
            instance.publicValue = 3;       // 접근가능
            // instance.privateValue = 4;   // 접근불가
        }


        // <정보은닉>
        // 객체 구성에 있어서 외부에서 사용하기 원하는 기능과 사용하기 원하지 않는 기능을 구분하기 위해 사용
        // 사용자가 객체를 사용하는데 있어서 필요한 기능만을 확인하기 위한 용도이며
        // 외부에 의해 영향을 받지 않길 원하는 기능을 감추기 위한 용도이기도 함
        class Bank
        {
            int balance;

            public void Save(int money)
            {
                balance += money;
            }

            public void Load(int money)
            {
                balance -= money;
            }
        }

        void Main2()
        {
            Bank bank = new Bank();

            // 외부에서 Bank의 balance를 직접적으로 접근불가
            // bank.balance = 0;

            // 외부에서는 Bank에서 의도한 Save와 Load를 통해 Bank를 다루게 유도
            bank.Save(20000);
            bank.Load(10000);
        }


        // <캡슐화 사용의미 1>
        // 캡슐화된 클래스는 외부에서 사용하기 위한 인터페이스만을 제공하여 복잡성 감소
        // 캡슐화된 클래스는 내부적으로 어떻게 구현되었는지 몰라도 사용가능
        class VeryComplicatedObject
        {
            // 캡슐화된 클래스의 private는 외부에서 접근불가하므로 사용할 수 없음
            int veryComplicatedValue1;
            int veryComplicatedValue2;
            int veryComplicatedValue3;

            void VeryComplicatedFunction1() { }
            void VeryComplicatedFunction2() { }
            void VeryComplicatedFunction3() { }

            // 캡슐화된 클래스의 public은 외부에서 접근가능하므로 사용을 권장하는 기능
            public void UseThisFunction() { }
        }


        // <캡슐화 사용의미 2>
        // 캡슐화된 클래스는 외부에서 원하지 않는 사용법으로부터 보호할 수 있어 오용된 사용을 방지
        class IntArray
        {
            int[] array = new int[10];

            public void SetValue(int index, int value)
            {
                if (index < 0 || index >= 10)
                    return;

                array[index] = value;
            }
        }
    }
}
