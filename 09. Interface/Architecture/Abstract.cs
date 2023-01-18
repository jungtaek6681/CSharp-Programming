using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Interface.Architecture
{
	// 추상클래스와 인터페이스
	// 인터페이스는 추상클래스의 일종으로 특징이 동일함
	// 공통점 : 함수에 대한 선언만 정의하고 이를 포함하는 클래스에서 구체화하여 사용

	// 개발자는 인터페이스와 추상클래스 중 더욱 상황에 적합한 것으로 구현해야함
	// 추상클래스 (A Is B 관계) : 상속 관계인 경우, 자식클래스가 부모클래스의 하위분류인 경우
	// 인터페이스 (A Has B 관계) : 행동 포함인 경우, 클래스가 해당 행동을 할 수 있는 경우

	// 비유 설명으로 추상클래스는 설계도, 인터페이스는 계약서

	public interface IEnterable
	{
		void Enter();
		void Exit();
	}

	public interface IWindow
	{
		void OpenWindow();
		void CloseWindow();
	}

	public interface ILightable
	{
		void TurnOnLight();
		void TurnOffLight();
	}

	public abstract class Building : IEnterable, IWindow, ILightable
	{
		public void Enter()
		{
			Console.WriteLine("건물에 들어갑니다.");
		}
		public void Exit()
		{
			Console.WriteLine("건물에서 나갑니다.");
		}
		public abstract void OpenWindow();
		public abstract void CloseWindow();
		public abstract void TurnOnLight();
		public abstract void TurnOffLight();
	}

	// 은행은 건물이다 : Ok, 상속으로 구현
	// 만약 부모클래스인 건물을 수정할 경우, 자식클래스인 은행도 같이 수정됨
	public class Bank : Building
	{
		public override void OpenWindow() { }
		public override void CloseWindow() { }
		public override void TurnOnLight() { }
		public override void TurnOffLight() { }
	}

	// 기차는 건물이다 : No, 인터페이스로 구현
	// 기차가 창문이 없거나 불이 들어오지 않을 경우 인터페이스를 포함하지 않도록 수정
	public class Train : IEnterable, IWindow, ILightable
	{
		public void Enter() { }
		public void Exit() { }
		public void OpenWindow() { }
		public void CloseWindow() { }
		public void TurnOnLight() { }
		public void TurnOffLight() { }
	}
}
