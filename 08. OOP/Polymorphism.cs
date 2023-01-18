using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._OOP
{
	/****************************************************************
	 * 다형성 (Polymorphism)
	 * 
	 * 부모클래스의 함수를 자식클래스에서 재정의하여 자식클래스의 서로 다른 반응을 구현
	 ****************************************************************/

	// <다형성>
	// 하이딩(hiding)			: 부모클래스의 함수를 자식클래스에서 같은 이름, 매개변수로 재정의하여 자식클래스가 우선되도록 함
	// 오버라이딩(overriding)	: 부모클래스의 가상함수를 자식클래스에서 override를 통해 재정의, 부모함수가 자식함수로 대체됨

	public class Monster
	{
		public string name;

		public Monster(string name)
		{
			this.name = name;
		}

		public void Move()
		{
			Console.WriteLine("{0}이 움직입니다.", name);
		}

		public virtual void TakeDamage()    // 가상함수(virtual) : 자식에서 재정의할 경우 부모의 함수가 대체됨
		{
			Console.WriteLine("{0}가 데미지를 받습니다.", name);
		}
	}

	public class Slime : Monster
	{
		public Slime(string name) : base(name)
		{
		}

		public override void TakeDamage()   // override : 부모클래스의 가상함수를 재정의하여 대체함
		{
			Console.WriteLine("{0}이 분열합니다.", name);
		}
	}

	public class Dragon : Monster
	{
		public Dragon(string name) : base(name)
		{
		}

		// 하이딩 : 부모클래스의 함수를 자식클래스에서 같은 이름, 매개변수로 재정의하여 자식클래스가 우선되도록 함
		public new void Move()  // 부모클래스의 기능을 숨기는 것을 의도한 경우 new 키워드(없어도 동작하나 의도했다는 것을 명확하게 함)
		{
			Console.WriteLine("{0}이 날아서 움직입니다.", name);
		}

		public override void TakeDamage()
		{
			base.TakeDamage();      // base : 부모클래스의 this를 자식클래스에서 가져옴
			Console.WriteLine("{0}이 분노합니다", name);
		}
	}

	public class Knight
	{
		public void Attack(Monster monster)
		{
			Console.WriteLine("기사가 {0}을 공격합니다.", monster.name);
			monster.TakeDamage();
		}
	}

	public static class Polymorphism
	{
		public static void Test()
		{
			Monster monster = new Monster("몬스터");
			Slime slime = new Slime("슬라임");
			Dragon dragon = new Dragon("드래곤");

			// 같은 이름의 함수를 호출하여도 각각의 다른 반응을 진행함
			monster.Move();             // Monster에 담긴 인스턴스는 Monster의 Move 호출
			slime.Move();               // Slime에 담긴 인스턴스는 Move가 없으므로 부모클래스 Monster의 Move 호출
			dragon.Move();              // Drangon에 담긴 인스턴스는 Dragon의 Move 호출

			// 자식클래스에 동일한 이름의 함수가 있다하더라도 부모클래스에 담은 경우 부모클래스의 함수가 호출
			Monster dragonInMonster = new Dragon("드래곤");
			dragonInMonster.Move();     // Monster에 담긴 인스턴스는 Monster의 Move 호출

			// virtual 함수를 재정의하여 구현한 경우 부모클래스에 담아 있는 경우에도 자식클래스에서 재정의한 함수가 호출
			Knight knight = new Knight();
			knight.Attack(monster);
			knight.Attack(slime);
			knight.Attack(dragon);
		}
	}
}
