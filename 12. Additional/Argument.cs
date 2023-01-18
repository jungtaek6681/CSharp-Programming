using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._Additional
{
	internal class Argument
	{
		// <Named Parameter>
		// 함수의 매개변수 순서와 무관하게 이름을 통해 호출
		public void Func1(int iParam, float fParam, string strParam) { }

		public void Test1()
		{
			// 함수 호출시 이름을 명명하고 순서와 상관없이 호출 가능
			Func1(strParam: "3", iParam: 1, fParam: 2f);
		}

		// <Optional Parameter>
		// 함수의 매개변수 초기값을 갖고 있다면, 함수호출시 생략하는 것을 허용하는 방법
		public void Func2(int param1, int param2 = 3, int param3 = 5) { }   // 초기값이 있는 경우 미리 할당
		// public void Func2(int param1 = 2, int param2) { }				// error : 초기값이 있는 매개변수는 마지막에 놓아야 함

		public void Test2()
		{
			Func2(3);           // Func2(3, 3, 5)
			Func2(3, 5);        // Func2(3, 5, 5)
			Func2(3, 5, 7);     // Func2(3, 5, 7)
		}

		// <Params Parameter>
		// 매개변수의 갯수가 정해지지 않은 경우, 매개변수의 갯수를 유동적으로 사용
		public void Func3(params int[] param) { }

		public void Test3()
		{
			Func3(1, 3, 5, 7, 9);
			Func3(3, 5, 7);
			Func3();
		}
	}
}
