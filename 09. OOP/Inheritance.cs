using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._OOP
{
    internal class Inheritance
    {
        /**********************************************************************************
         * 상속 (Inheritance)
         *
         * 부모클래스의 모든 기능을 가지는 자식클래스를 설계하는 방법
         * is-a 관계 : 부모클래스가 자식클래스를 포함하는 상위개념일 경우 상속관계가 적합함
         **********************************************************************************/

        // <상속>
        // 부모클래스를 상속하는 자식클래스에게 부모클래스의 모든 기능을 부여
        // class 자식클래스 : 부모클래스
        class Monster
        {
            protected string name;
            protected int hp;

            public void Move()
            {
                Console.WriteLine($"{name} 이/가 움직입니다.");
            }

            public void TakeHit(int damage)
            {
                hp -= damage;
                Console.WriteLine($"{name} 이/가 {damage} 를 받아 체력이 {hp} 이 되었습니다.");
            }
        }

        class Dragon : Monster
        {
            public Dragon()
            {
                name = "드래곤";
                hp = 100;
            }

            public void Breath()
            {
                Console.WriteLine($"{name} 이/가 브레스를 뿜습니다.");
            }
        }

        class Slime : Monster
        {
            public Slime()
            {
                name = "슬라임";
                hp = 5;
            }

            public void Split()
            {
                Console.WriteLine($"{name} 이/가 분열합니다.");
            }
        }

        class Hero
        {
            int damage = 3;
            
            public void Attack(Monster monster)
            {
                monster.TakeHit(damage);
            }
        }

        void Main1()
        {
            Dragon dragon = new Dragon();
            Slime slime = new Slime();

            // 부모클래스 Monster를 상속한 자식클래스는 모두 부모클래스의 기능을 가지고 있음
            dragon.Move();
            slime.Move();

            // 자식클래스는 부모클래스의 기능에 자식만의 기능을 더욱 추가하여 구현 가능
            dragon.Breath();
            slime.Split();

            // 업캐스팅 : 자식클래스는 부모클래스 자료형으로 묵시적 형변환 가능
            Hero hero = new Hero();
            hero.Attack(dragon);
            hero.Attack(slime);

            Monster monster = new Dragon();
            hero.Attack(monster);

            // 다운캐스팅 : 부모클래스는 자식클래스 자료형으로 명시적 형변환 가능 (단, 가능할 경우)
            Dragon d = (Dragon)monster;     
            // Slime s = (Slime)monster;            // error : 인스턴스가 Slime이 아니기 때문에 변환시 오류

            if (monster is Dragon)                  // 형변환이 가능한지 확인
            {
                Dragon isDraong = (Dragon)monster;
            }

            Dragon asDragon = monster as Dragon;    // 형변환이 가능하다면 형변환
        }


        // <상속 사용의미 1>
        // 상속을 진행하는 경우 부모클래스의 소스가 자식클래스에서 모두 적용됨
        // 부모클래스와 자식클래스의 상속관계가 적합한 경우 부모클래스에서의 기능 구현이 자식클래스에서도 어울림
        class Building
        {
            // 부모클래스에서 기능을 구현할 경우 모든 부모를 상속하는 자식클래스에 기능을 구현하는 효과
        }

        class Home : Building
        {
            // 자식클래스에서 자식클래스만의 기능을 구현
        }

        class School : Building
        {
            // 자식클래스에서 자식클래스만의 기능을 구현
        }


        // <상속 사용의미 2>
        // 업캐스팅을 통해 자식클래스는 부모클래스로 형변환이 가능함
        // 자식클래스는 부모클래스를 요구하는 곳에서 동일한 기능을 수행할 수 있음
        class Parent
        {
            public void Func() { }
        }
        class Child1 : Parent { }
        class Child2 : Parent { }
        class Child3 : Parent { }

        void UseParent(Parent parent) { parent.Func(); }
        void Main2()
        {
            Child1 child1 = new Child1();
            Child2 child2 = new Child2();
            Child3 child3 = new Child3();

            UseParent(child1);
            UseParent(child2);
            UseParent(child3);
        }
    }
}
