using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Event.Architecture
{
	// <폴링 방식>
	// 대상 인스턴스의 상황을 확인하기 위해 매 프레임마다 계속해서 확인함

	// 클래스의 개방폐쇄 원칙은 잘 지켜졌지만,
	// 확인되는 대상의 변경사항이 없는 상황에서도 확인을 진행하기 때문에
	// 프레임마다 필요없는 연산이 낭비될 수 있음
	// ex)  플레이어의 체력의 변경사항이 없을 때에도,
	//      UI에서는 확인하는 작업이 필요함

	// 개방폐쇄원칙 준수 O / 불필요한연산 제거 X

	public class PollingPlayer
	{
		public int _HP = 100;

		public int HP { get; private set; }

		public void Hit(int damage)
		{
			Console.WriteLine("플레이어가 데미지를 받아 체력이 {0}이 되었습니다.", HP);
			HP -= damage;
		}

		public void Heal(int heal)
		{
			Console.WriteLine("플레이어가 힐을 받아 체력이 {0}이 되었습니다.", HP);
			HP += heal;
		}
	}

	public class PollingUI
	{
		private PollingPlayer player;

		public void SetTarget(PollingPlayer player) { this.player = player; }

		public void Update()
		{
			if (player == null)
				return;

			// 플레이어의 체력을 갱신하기 위해 매프레임마다 작업을 진행
			Console.WriteLine("UI가 체력을 {0}으로 설정합니다.", player.HP);
		}
	}
}
