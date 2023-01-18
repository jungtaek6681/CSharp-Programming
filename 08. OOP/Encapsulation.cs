using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._OOP
{
	/****************************************************************
	 * 캡슐화 (Encapsulation)
	 * 
	 * 객체를 상태와 기능으로 묶는 것을 의미
	 * 정보은닉 : 객체의 내부 상태와 기능을 숨기고, 허용한 상태와 기능만의 액세스 허용
	 ****************************************************************/

	// <캡슐화>
	// 객체를 상태와 기능으로 묶는 것, 객체의 상태와 기능을 맴버라고 표현함
	// 현실세계의 객체를 표현하기 위해 객체가 가지는 정보와 행동을 묶어 구현하며 이를 통해 객체간 상호작용
	// C# 의 맴버로는 맴버변수(필드), 맴버함수(메서드), 상수, 속성(프로퍼티), 생성자, 이벤트, 연산자, 인덱서 등이 있음

	class Capsule
	{
		int variable;           // 맴버변수 : 객체의 상태를 표현
		void Function() { }     // 맴버함수 : 객체의 기능를 표현
	}

	// <접근제한자>
	// 객체의 접근의 허용범위를 설정
	// 외부에서 사용해주기 원하는 기능과 내부에서만 사용하기 원하는 기능을 구분하기 위해 사용
	// 지정하지 않는 경우 기본 접근제한자는 private
	// public		: 모두 접근 가능
	// private		: 클래스 내부에서만 접근 가능
	// protected	: 상속한 자식은 접근 가능
	// internal		: 같은 어셈블리(프로젝트, Lib, Dll, 등)에서 접근 가능

	public class Player
	{
		public int hp;      // 외부에서 접근 가능
		int mp;             // 접근제한자를 지정하지 않은 경우 기본접근제한자 private

		public Player(int hp, int mp)
		{
			this.hp = hp;
			this.mp = mp;
		}

		public void TakeDamage(int damage)
		{
			hp -= damage;
		}

		public void UseMagic(int cost)
		{
			mp -= cost;
		}
	}

	public static class Encapsulation
	{
		public static void Test()
		{
			Player player = new Player(100, 20);

			player.TakeDamage(20);
			player.UseMagic(10);

			player.hp = 0;      // public으로 선언한 경우 외부에서 접근 가능(의도에 벗어날 수 있음)
			// player.mp = 0;	// private로 선언한 경우 외부에서 접근 불가(public으로 의도한 사용만 허용)
		}
	}
}
