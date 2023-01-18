using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Event.Event
{
	internal class Lambda
	{
		public static Action<string> OnAction;
		public static void Func(string str) { Console.WriteLine(str); }

		public static void Test()
		{
			// <함수를 통한 연결>
			// 클래스에 정의된 함수를 직접 연결
			// 클래스의 맴버함수로 연결하기 위한 기능이 있을 경우 적합
			OnAction += Func;

			// <무명메서드>
			// delegate (매개변수들) {함수내용}
			// 함수를 통한 연결은 함수가 직접적으로 선언되어 있어야 사용 가능
			// 전달하기 위해 작성하는 함수가 간단하고 자주 사용될수록 비효율적
			// 간단한 표현식을 통해 미리 정의하지 않아도 되는 이름 없는 함수를 사용
			OnAction += delegate (string str) { Console.WriteLine(str); };

			// <람다식>
			// 무명메서드의 간단한 표현식
			// (매개변수들의 이름) => {함수내용}
			OnAction += (str) => { Console.WriteLine(str); };
			OnAction += str => Console.WriteLine(str);			// 매개변수나 함수내용이 하나만 있을 경우 괄호 생략 가능
		}
	}
}
