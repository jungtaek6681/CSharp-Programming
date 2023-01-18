using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Event.Architecture
{
	// <Callback 방식>
	// 호출 당할 함수를 미리 보관한 후 필요로 하는 순간 보관한 함수들을 호출하여 진행

	// 클래스의 개방폐쇄 원칙이 잘 지켜졌으며,
	// 프레임마다 필요없는 연산이 낭비되지 않음

	// 개방폐쇄원칙 준수 O / 불필요한연산 제거 O

	public class EventPlayer
	{
		public delegate void OnChangeHPHandler(int hp);
		public event OnChangeHPHandler OnChangeHP;

		// 2. Event의 프로퍼티 응용
		public int HP { get; private set; } = 100;

		public void Hit(int damage)
		{
			Console.WriteLine("플레이어가 데미지를 받아 체력이 {0}이 되었습니다.", HP);
			HP -= damage;

			// 이벤트에 추가한 함수들을 호출
			OnChangeHP?.Invoke(HP);
		}

		public void Heal(int heal)
		{
			Console.WriteLine("플레이어가 힐을 받아 체력이 {0}이 되었습니다.", HP);
			HP += heal;

			// 이벤트에 추가한 함수들을 호출
			OnChangeHP?.Invoke(HP);
		}
	}

	public class EventUI
	{
		public void ChangeHP(int hp)
		{
			Console.WriteLine("UI의 체력을 {0}으로 변경합니다.", hp);
		}
	}
}
