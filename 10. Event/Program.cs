using _10._Event.DelegateBasic;
using _10._Event.EventBasic;
using System;

namespace _10._Event
{
	internal class Program
	{
		public static int AscendingOrder(int left, int right)
		{
			if (left > right)
				return 1;
			else if (left < right)
				return -1;
			else
				return 0;
		}

		public static int DescendingOrder(int left, int right)
		{
			if (left < right)
				return 1;
			else if (left > right)
				return -1;
			else
				return 0;
		}

		public static int AbsoluteOrder(int left, int right)
		{
			if (Math.Abs(left) < Math.Abs(right))
				return 1;
			else if (Math.Abs(left) > Math.Abs(right))
				return -1;
			else
				return 0;
		}

		static void Main(string[] args)
		{
			// <딜리게이트 사용>
			int[] ascend = new int[] { -3, 5, 1, -2, 4 };       // 오름차순 정렬
			int[] descend = new int[] { -3, 5, 1, -2, 4 };      // 내림차순 정렬
			int[] absolute = new int[] { -3, 5, 1, -2, 4 };     // 절대값 정렬

			// 정렬 기준을 매개변수에 함수를 전달
			IntSortMachine.Sort(ascend, AscendingOrder);        // { -3, -2,  1,  4,  5 }
			IntSortMachine.Sort(descend, DescendingOrder);      // {  5,  4,  1, -2, -3 }
			IntSortMachine.Sort(absolute, AbsoluteOrder);       // {  1, -2, -3,  4,  5 }

			ascend = new int[] { -3, 5, 1, -2, 4 };             // 오름차순 정렬
			descend = new int[] { -3, 5, 1, -2, 4 };            // 내림차순 정렬
			absolute = new int[] { -3, 5, 1, -2, 4 };           // 절대값 정렬

			// C# Array를 이용한 정렬
			Array.Sort<int>(ascend, AscendingOrder);            // { -3, -2,  1,  4,  5 }
			Array.Sort<int>(descend, AscendingOrder);           // {  5,  4,  1, -2, -3 }
			Array.Sort<int>(absolute, AscendingOrder);          // {  1, -2, -3,  4,  5 }

			//////////////////////////////////////////////////////////////////////////////

			// <이벤트 사용>
			Player player = new Player();
			SFX sfx = new SFX();
			UI ui = new UI();

			player.OnGetCoin += sfx.CoinSound;
			player.OnGetCoin += ui.UpdateUI;

			player.GetCoin();
			// 플레이어가 코인을 얻음
			// 코인을 얻는 음악 재생
			// UI를 갱신

			// 효과 추가
			player.OnGetCoin += () => Console.WriteLine("코인을 얻어 반짝거리는 효과");

			player.GetCoin();
			// 플레이어가 코인을 얻음
			// 코인을 얻는 음악 재생
			// UI를 갱신
			// 코인을 얻어 반짝거리는 효과
		}
	}
}