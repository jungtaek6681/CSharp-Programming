using System;

namespace _05._Function
{
	internal class Program
	{
		// ! 주의사항 ! //
		// 지금 당장은 static에 대해 알지 못하고 함수 앞에 static이 반드시 붙여져야 하는 것이 아니지만,
		// static을 배우기 전까지는 함수 앞에 static을 붙여주도록 함

		/****************************************************************
		 * 함수 (Function)
		 * 
		 * 미리 정해진 동작을 수행하는 코드 묶음
		 * 어떤 처리를 미리 함수로 만들어 두면 다시 반복적으로 사용 가능
		 ****************************************************************/

		// <함수 구성>
		// 반환형 함수이름(매개변수들) { 함수내용 }
		static int Add1(int x, int y) { return x + y; }
		static void Func1() { }     // 매개변수가 없는 경우 빈괄호

		// <함수 사용>
		// 작성한 함수의 이름에 괄호를 붙이며, 괄호안에 매개변수들을 넣어 사용
		static void Main1()
		{
			Add1(1, 2);
			Add1(3, 4);

			Func1();
		}

		// <반환형 (Return Type)>
		// 함수의 결과(출력) 데이터의 자료형
		// 함수의 결과 데이터가 없는 경우 반환형은 void
		// <return>
		// 함수가 끝나기 전까지 반드시 return으로 반환형에 맞는 데이터를 return 해야함
		// 함수 진행 중 return을 만났을 경우 그 결과 데이터를 반환하고 함수를 탈출함
		// void 반환형 함수의 return은 생략 가능
		static int IntReturnFunc2()
		{
			Console.WriteLine("return 전");
			return 10;                          // return 을 통해 10 값을 가지고 함수가 종료됨
			Console.WriteLine("return 후");     // return 에서 함수가 완료되므로 실행되지 않음
		}

		static void VoidReturnFunc2()
		{
			return;                             // void 반환형은 return 데이터가 없음
			// return;							// void 반환형은 함수 내용 중 return을 생략 가능하나 함수를 종료하고 싶을때도 사용가능
		}

		static void Main2()
		{
			int value = IntReturnFunc2();       // IntReturnFunc2 함수가 10 값을 반환하므로 value는 10이 됨
												// bool value = IntReturnFunc2();	// error : IntReturnFunc2 함수가 int 반환형이므로 다른 자료형에 넣을 수 없음
			VoidReturnFunc2();                  // 반환값이 없는 void 함수는 일반적으로 함수내에서 행동이 의미 있음
		}

		// <매개변수 (Parameter)>
		// 함수에 추가(입력)할 데이터의 자료형과 변수명
		// 같은 함수에서도 매개변수 입력이 다름에 따라 다른 처리가 가능
		// params 를 통해 매개변수의 갯수를 유동적으로 사용가능
		static int Add3(int x, int y)
		{
			// 함수의 입력으로 넣어준 매개변수 x, y 따라 함수가 동작
			return x + y;
		}

		static void Main3()
		{
			int value1 = Add3(10, 20);          // 매개변수 10, 20이 들어간 Add3 함수의 반환은 30
			int value2 = Add3(10, 10);          // 매개변수 10, 10이 들어간 Add3 함수의 반환은 20
			// int Value3 = Add3(2.1f, 3.4f);	// error : int 매개변수에는 int 자료형만 사용 가능
		}

		// <함수 호출스택>
		// 함수는 호출되었을 때 해당 함수블록으로 제어가 전송되며 완료되었을 때 원위치로 전송됨
		// 이를 관리하기 위해 호출스택을 활용함
		// 함수가 순환구조로 무한히 호출되어 더이상 스택에 빈공간이 없는 경우 StackOverflow가 발생
		static void Func4_1()
		{                                   // (1)
			Console.WriteLine("Func4_1");   // (2)
		}                                   // (3)

		static void Func4_2()
		{                                   // (4)
			Console.WriteLine("Func4_2");   // (5)
			Func4_1();                      // (6)
		}                                   // (7)

		static void Main4()
		{                                   // (8)
			Func4_2();                      // (9)
		}                                   // (10)
		// 호출 순서 : (8) -> (9) -> (4) -> (5) -> (6) -> (1) -> (2) -> (3) -> (7) -> (10)


		// <오버로딩>
		// 같은 이름의 함수를 매개변수를 달리하여 다른 함수로 재정의하는 기술
		static int Minus(int left, int right) { return left - right; }
		static float Minus(float left, float right) { return left - right; }
		static double Minus(double left, double right) { return left - right; }

		static void Main5()
		{
			Console.WriteLine(Minus(5, 3));         // Minus(int, int) 가 호출됨
			Console.WriteLine(Minus(5.0f, 3.0f));   // Minus(float, float) 가 호출됨
			Console.WriteLine(Minus(5.0d, 3.0d));   // Minus(double, double) 가 호출됨
		}


		static void Main(string[] args)
		{
			Main1();
			Main2();
			Main3();
			Main4();
			Main5();
		}
	}
}