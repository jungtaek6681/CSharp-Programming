using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._OOP
{
	/****************************************************************
	 * 추상화 (Abstraction)
	 * 
	 * 관련 특성 및 엔터티의 상호 작용을 클래스로 모델링하여 시스템의 추상적 표현을 정의
	 ****************************************************************/

	// <추상클래스(abstract class)>
	// 하나 이상의 추상함수를 포함하는 클래스
	// 클래스가 추상적인 표현을 정의하는 경우 자식에서 구체화시켜 구현할 것을 염두하고 추상화(abstract) 시킴
	// 추상클래스에서 내용을 구체화 할 수 없는 추상함수는 내용을 정의하지 않지 않음
	// 추상클래스를 상속하는 자식클래스가 추상화한 함수를 재정의하여 실체화한 경우 사용가능

	public abstract class Animal
	{
		// 추상적인 클래스에서 구체화 할 수 없는 함수는 추상함수로 선언하고 내용을 정의하지 않음
		public abstract void Cry();
	}

	public class Bird : Animal
	{
		// 추상함수를 재정의하여 실체화한 경우 사용 가능
		public override void Cry()
		{
			Console.WriteLine("짹짹");
		}
	}

	public class Dog : Animal
	{
		public override void Cry()
		{
			Console.WriteLine("멍멍");
		}
	}

	public static class Abstraction
	{
		public static void Test()
		{
			// Animal animal = new Animal();	// error : 추상클래스의 인스턴스는 생성불가
			Animal bird = new Bird();           // 추상클래스를 구체화시킨 자식클래스의 인스턴스는 생성가능
			Animal dog = new Dog();

			bird.Cry();
			dog.Cry();
		}
	}
}
