using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Event.EventBasic
{
	internal class Player
	{
		public Action OnGetCoin;

		public void GetCoin()
		{
			Console.WriteLine("플레이어가 코인을 얻음");
			if (OnGetCoin != null) OnGetCoin();
		}
	}
}
