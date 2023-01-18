using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Event.Delegate
{
	internal class Generic
	{
		// <일반화 딜리게이트>
		// 개발과정에서 많이 사용되는 딜리게이트의 경우 일반화된 딜리게이트를 사용

		// <Func 딜리게이트>
		// 반환형과 매개변수를 지정한 딜리게이트
		// Func<매개변수들..., 반환형>
		static Func<int, int, int> funcDelegate;
		static int Func1(int left, int right) { return left + right; }

		public static void Test1()
		{
			funcDelegate = Func1;
		}

		// <Action 딜리게이트>
		// 반환형이 void 이며 매개변수를 지정한 딜리게이트
		// Action<매개변수들...>
		static Action<string> actionDelegate;
		static void Func2(string str) { Console.WriteLine(str); }

		public static void Test2()
		{
			actionDelegate = Func2;
		}

		// <Predicate 딜리게이트>
		// 반환형이 bool, 매개변수가 하나인 딜리게이트
		// Func이 더욱 확장성 있기 때문에 잘 사용되지는 않음 (.Net 2.0에서 사용함)
		static Predicate<string> predicateDelegate;
		static bool Func3(string str) { return str.Contains(' '); }
		public static void Test3()
		{
			predicateDelegate = Func3;
		}
	}
}
