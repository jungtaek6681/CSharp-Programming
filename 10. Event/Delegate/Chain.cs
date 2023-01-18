using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Event.Delegate
{
	internal class Chain
	{
		public delegate void DelegateChain();

		public static void Func1() { Console.WriteLine("Func1"); }
		public static void Func2() { Console.WriteLine("Func2"); }
		public static void Func3() { Console.WriteLine("Func3"); }

		public static void Test()
		{
			// <딜리게이트 체인>
			// 하나의 딜리게이트 변수에 여러 개의 함수를 할당하는 것이 가능
			// +=, -= 연산자를 통해 할당을 추가하고 제거할 수 있음
			// = 연산자를 통해 할당할 경우 이전의 다른 함수들을 할당한 상황이 사라짐

			DelegateChain delegateVar;
			delegateVar = Func2;		// 딜리게이트 인스턴스를 Func2 로 초기화
			delegateVar += Func1;		// 딜리게이트 인스턴스에 Func1 추가 할당
			delegateVar += Func3;       // 딜리게이트 인스턴스에 Func3 추가 할당
			delegateVar();              // Func2, Func1, Func3이 순서대로 호출됨

			delegateVar -= Func1;		// 딜리게이트 인스턴스에 Func1 할당 제거
			if (delegateVar != null)	// 딜리게이트 인스턴스에서 할당을 제거할 경우 null을 조심해야 함
				delegateVar();          // Func2, Func3이 순서대로 호출됨

			delegateVar += Func2;		
			delegateVar += Func2;       // 같은 함수를 여러번 할당한 경우 여러번 호출됨
			delegateVar();              // Func2, Func3, Func2, Func2이 순서대로 호출됨

			delegateVar -= Func1;       // 딜리게이트 인스턴스에 할당되지 않은 함수를 제거하는 경우 문제 없음

			delegateVar = Func1;        // 딜리게이트 인스턴스에 = 을 통해 할당할 경우 이전의 할당된 상황이 사라짐
			delegateVar();				// Func1이 호출됨
		}
	}
}
