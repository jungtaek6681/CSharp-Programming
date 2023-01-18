using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Interface.Architecture
{
	// <인터페이스 분리의 원칙 (Interface Segregation Priciple)>
	// 1. 인터페이스는 하나의 큰 인터페이스로 구현하기보다 작은 단위들로 분리시켜 구성함

	// 잘못된 인터페이스 사용 예제
	public interface IGameObject
	{
		void DropItem();
		void Move();
		void TakeDamage(int damage);
	}

	public class WrongGhost : IGameObject
	{
		public void DropItem()
		{
			Console.WriteLine("유령이 아이템을 떨어뜨립니다.");
		}
		public void Move()
		{
			Console.WriteLine("유령이 움직입니다.");
		}
		public void TakeDamage(int damage)  // 하나의 큰 인터페이스일 경우 불필요한 함수 또한 포함할 수 밖에 없음
		{
			// 데미지를 받지 않는 몬스터이지만 TakeDamage가 포함된 상태
			Console.WriteLine("유령은 데미지를 받지 않습니다.");
		}
	}

	public class WrongBox : IGameObject
	{
		public void DropItem()
		{
			Console.WriteLine("박스가 아이템을 떨어뜨립니다.");
		}

		public void Move()    // 하나의 큰 인터페이스일 경우 불필요한 함수 또한 포함할 수 밖에 없음
		{
			// 움직일 수 없는 물체이지만 Move가 포함된 상태
			Console.WriteLine("박스는 움직일 수 없습니다.");
		}

		public void TakeDamage(int damage)
		{
			Console.WriteLine("박스가 데미지를 받아 부서집니다.");
		}
	}


	// 인터페이스 분리 원칙을 지킨 경우
	public interface IDropable
	{
		void DropItem();
	}

	public interface IMovable
	{
		void Move();
	}

	public interface IDamagable
	{
		void TakeDamage(int damage);
	}

	public class Ghost : IDropable, IMovable    // 클래스가 동작 가능한 인터페이스만 포함
	{
		public void DropItem()
		{
			Console.WriteLine("유령이 아이템을 떨어뜨립니다.");
		}

		public void Move()
		{
			Console.WriteLine("유령이 움직입니다.");
		}
	}

	public class Box : IDropable, IDamagable       // 클래스가 동작 가능한 인터페이스만 포함
	{
		public void DropItem()
		{
			Console.WriteLine("박스가 아이템을 떨어뜨립니다.");
		}

		public void TakeDamage(int damage)
		{
			Console.WriteLine("박스가 데미지를 받아 부서집니다.");
		}
	}


	// <인터페이스 분리의 원칙 (Interface Segregation Priciple)>
	// 2. 사용하지 않을 인터페이스를 포함하지 않음

	public class WrongGround : IDamagable, IMovable
	{
		// 인터페이스를 포함하지만 사용하지 않을 경우 포함하지 않도록 함
		// 개발자 입장에서 인터페이스를 포함하는 경우 해당 기능이 구현되었다고 파악하게 됨
		// ex. 지형이 이동하지 않는다면 인터페이스를 포함하지 않는 것이 가독성과 의미가 정확함
		public void Move()
		{
			// 포함하지 않아야하는 인터페이스
		}

		public void TakeDamage(int damage)
		{
			Console.WriteLine("땅이 데미지를 받아 부서집니다.");
		}
	}

	public class Ground : IDamagable
	{
		public void TakeDamage(int damage)
		{
			Console.WriteLine("땅이 데미지를 받아 부서집니다.");
		}
	}
}
