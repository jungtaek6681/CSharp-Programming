using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._OOP
{
    internal class Polymorphism
    {
        /***************************************************************************
         * 다형성 (Polymorphism)
         *
         * 객체의 속성이나 기능이 상황에 따라 여러가지 형태를 가질 수 있는 성질
         ****************************************************************************/

        // <다형성>
        // 부모클래스의 멤버를 자식클래스가 상황에 따라 여러가지 형태를 가질 수 있는 성질
        class Car
        {
            protected string name;
            protected int speed;

            public void Move()
            {
                Console.WriteLine($"{name} 이/가 {speed} 의 속도로 이동합니다.");
            }
        }

        class Truck : Car
        {
            public Truck()
            {
                name = "트럭";
                speed = 30;
            }
        }

        class SportCar : Car
        {
            public SportCar()
            {
                name = "스포츠카";
                speed = 100;
            }
        }

        void Main1()
        {
            Car car1 = new Truck(); 
            Car car2 = new SportCar();

            car1.Move();    // 트럭 이/가 30 의 속도로 이동합니다.
            car2.Move();    // 스포츠카 이/가 100 의 속도로 이동합니다.
        }


        // <가상함수와 오버라이딩>
        // 가상함수   : 부모클래스의 함수 중 자식클래스에 의해 재정의 할 수 있는 함수를 지정
        // 오버라이딩 : 부모클래스의 가상함수를 같은 함수이름과 같은매개변수로 재정의하여 자식만의 반응을 구현
        class Skill
        {
            public virtual void Execute()       // 가상함수
            {
                Console.WriteLine("스킬 재사용 대기시간을 진행시킴");
            }
        }

        class FireBall : Skill
        {
            public override void Execute()      // 오버라이딩
            {
                base.Execute();      // base : 부모클래스를 가리킴
                Console.WriteLine("전방에 화염구를 날림");
            }
        }

        class Dash : Skill
        {
            public override void Execute()
            {
                Console.WriteLine("전방에 근거리를 빠르게 이동");
            }
        }

        void Main2()
        {
            Skill fireBall = new FireBall();
            fireBall.Execute();     // 자식클래스의 함수가 호출됨
            // 스킬 재사용 대기시간을 진행시킴
            // 전방에 화명구를 날림

            Skill dash = new Dash();
            dash.Execute();         // 자식클래스의 함수가 호출됨
            // 전방에 근거리를 빠르게 이동
        }


        // <다형성 사용의미 1>
        // 새로운 클래스를 추가하거나 확장할 때 기존 코드에 영향을 최소화함
        // 새로운 클래스를 만들 때 기존의 소스를 수정하지 않아도 됨
        class Player
        {
            Skill skill;

            public void SetSkill(Skill skill)
            {
                this.skill = skill;
            }

            public void UseSkill()
            {
                skill.Execute();    // skill 클래스의 다형성을 확보한 결과 진행
            }
        }


        // <다형성 사용의미 2>
        // 클래스 간의 의존성을 줄여 확장성은 높임
        class SkillContents : Skill
        {
            public override void Execute()
            {
                base.Execute();
                // 프로그램의 확장을 위해 상위클래스를 상속하는 클래스를 개발
            }
        }
    }
}
