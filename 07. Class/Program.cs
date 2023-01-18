using System;

namespace _07._Class
{
	internal class Program
	{
		/****************************************************************
		 * 클래스 (class)
		 * 
		 * 데이터와 관련 기능을 캡슐화할 수 있는 참조 형식
		 * 객체지향 프로그래밍에 객체를 만들기 위한 설계도
		 * 클래스는 객체를 만들기 위한 설계도이며, 만들어진 객체는 인스턴스라 함
		 * 참조 : 원본을 가리키고 있음 == 원본의 주소를 가지고 있음
		 ****************************************************************/

		// <클래스 구성>
		// class 클래스이름 {클래스내용}
		// 클래스 내용으로는 변수와 함수 등이 포함 가능
		class Student
		{
			public string name;
			public int math;
			public int english;
			public int programming;

			public float GetAverage()
			{
				return (math + english + programming) / 3f;
			}
		}

		static void Main1()
		{
			Student kim = null;             // 지역변수를 생성하고 null(아무것도 없음) 참조
			kim = new Student();            // 클래스 인스턴스 생성하고 지역변수가 인스턴스를 참조함
			kim.name = "Kim";               // 인스턴스의 변수에 접근하기 위해 참조한 변수에 . 을 붙여 사용
			kim.math = 10;
			kim.english = 10;
			kim.programming = 100;

			Console.Write("{0}의 평균 점수는 ", kim.name);
			Console.WriteLine(kim.GetAverage());    // 클래스내 함수에 접근하기 위해 참조한 변수에 . 을 붙여 사용
		}

		// <생성자>
		// 반환형이 없는 클래스이름의 함수를 생성자라 하며 클래스의 인스턴스를 만들 때 호출되는 역할로 사용
		// 생성자를 포함하지 않아도 기본 생성자(매개변수가 없는 생성자)는 자동으로 생성됨
		// 기본 생성자 외 매개변수가 있는 생성자를 포함한 경우 기본 생성자는 자동으로 생성되지 않음

		class Player
		{
			public string name;
			public int hp;
			public int mp;

			// 기본 생성자는 다른 생성자를 포함하지 않은 경우만 기본 생성됨
			/*public Player()
			{

			}*/

			public Player(string name, int hp)
			{
				// 생성자에서 초기화 하지 않은 맴버 변수는 기본값으로 초기화됨
				this.name = name;
				this.hp = hp;
			}
		}

		/****************************************************************
		 * 값형식 참조형식
		 * 
		 * 값형식 : 스택영역에 저장, 정적으로 메모리에 할당
		 *			복사할 때 실제값이 복사됨, 블록이 끝날때 소멸
		 *			구조체는 값형식
		 * 참조형식 : 힙영역에 저장, 동적으로 메모리에 할당
		 *			복사할 때 원본주소가 복사됨, 사용하지 않을때 가비지 컬렉터에 의해 소멸
		 *			클래스는 참조형식
		 ****************************************************************/

		// <값형식과 참조형식의 차이>
		// 값형식 : 데이터가 중요, 값이 복사됨
		// 참조형식 : 원본이 중요, 원본 주소가 복사됨
		struct ValueType
		{
			public int value;
		}

		class RefType
		{
			public int value;
		}

		static void Main2()
		{
			ValueType valueType1 = new ValueType() { value = 10 };
			ValueType valueType2 = valueType1;      // 값에 의한 복사
			valueType2.value = 20;
			Console.WriteLine(valueType1.value);    // output : 10

			RefType refType1 = new RefType() { value = 10 };
			RefType refType2 = refType1;            // 원본주소 복사
			refType2.value = 20;
			Console.WriteLine(refType1.value);      // output : 20
		}

		// <값형식의 참조전달>
		// C# 7.0 이상 버전에서 지원
		// ref 키워드를 통해 값형식 또한 원본을 참조할 수 있음
		static void Main3()
		{
			int leftValue = 10;
			ref int rightValue = ref leftValue;     // 값형식의 참조를 전달하기 위해 ref 사용
			leftValue = 20;

			Console.WriteLine(rightValue);          // output : 20
		}

		// <매개변수 키워드>
		// ref 매개변수 : 참조형식으로 매개변수를 넣어 원본을 수정가능
		// out 매개변수 : 출력전용 참조형식으로 매개변수를 넣을 경우 원본이 함수에서 변경한 데이터로 수정됨
		static void Swap(int left, int right)
		{
			int temp = left;
			left = right;
			right = temp;
		}

		static void Swap(ref int left, ref int right)
		{
			int temp = left;
			left = right;
			right = temp;
		}

		static void OutFunc(out int value)  // 출력 전용 매개변수, 참조형식으로 원본이 변경됨
		{
			// 출력 전용 매개변수에 값을 넣지 않고 함수가 종료되는 경우 오류
			value = 10;
		}

		static void Main4()
		{
			int left = 10;
			int right = 20;

			// Call by Value / Call by Reference
			Swap(left, right);              // 값에 의한 호출은 데이터의 복사본이 함수로 들어가기 때문에 원본이 바뀌지 않음
			Swap(ref left, ref right);      // 참조에 의한 호출은 원본의 주소가 함수로 들어가기 때문에 원본이 바뀜

			int outValue;
			OutFunc(out outValue);          // outValue : 10으로 원본이 변경됨
		}

		/****************************************************************
		 * 메모리 구조
		 * 
		 * 코드		영역 : 실행할 프로그램의 코드가 저장되는 영역, CPU가 코드영역에 저장된 명령어를 하나씩 처리
		 * 데이터	영역 : 전역(global), 정적(static) 변수가 저장되는 영역, 프로그램의 시작과 함께 할당, 프로그램 종료시 소멸
		 * 스택		영역 : 지역(local), 매개(parameter) 변수가 저장되는 영역, 블록의 시작과 함께 할당 블록 완료시 소멸, 컴파일 당시에 크기가 결정
		 * 힙		영역 : 인스턴스가 저장되는 영역, 사용하지 않을때 가비지 컬렉터에 의해 소멸, 런타임 당시에 크기가 결정
		 ****************************************************************/
		struct StackStruct { }
		class HeapClass { }

		static void Main5()
		{
			// 컴파일 당시 지역변수 stackStruck, heapClass 가 필요한 크기가 결정되어 있음

			// 함수 시작시
			// 스택 영역에 필요한 메모리 크기가 할당됨
			// 지역변수 stackStruct	스택 영역에 저장됨
			// 지역변수 heapClass	스택 영역에 저장됨

			StackStruct stackStruct;                // 함수 시작시에 이미 메모리가 할당되어 있음
			stackStruct = new StackStruct();        // 지역변수 stackStruct에 구조체 초기값이 저장됨
			HeapClass heapClass;                    // 함수 시작시에 이미 메모리가 할당되어 있음
			heapClass = new HeapClass();            // 런타임 당시에 인스턴스가 힙 영역에 저장되고 그 주소값이 지역변수 heapClass에 저장됨

			// 함수 종료시
			// 지역변수 stackStruct	함수 종료와 즉시 소멸됨
			// 지역변수 heapClass	함수 종료와 즉시 소멸됨
			// 인스턴스 new HeapClass()는 함수 종료와 함께 더 이상 사용되지 않음(인스턴스에 접근할수 있는 heapClass가 소멸됨)
			// 인스턴스 new HeapClass()는 가비지가 되며 가비지 컬렉터가 동작할 때에 소멸됨
		}

		// <정적(static)>
		// 프로그램의 시작과 함께 할당, 프로그램 종료시에 소멸하는 단 하나의 요소
		// 프로그램 전역에서 클래스의 이름을 통해 접근 가능
		class StaticClass1
		{
			public static int staticInt;
			public int nonStaticInt;

			public static void StaticFunc()
			{
				Console.WriteLine("StaticFunc");

				Console.WriteLine(StaticClass1.staticInt);
				// Console.WriteLine(nonStaticInt);			// error : 정적함수에서 맴버변수를 사용할 수 없음
			}

			public void NonStaticFunc()
			{
				Console.WriteLine("NonStaticFunc");

				Console.WriteLine(staticInt);
				Console.WriteLine(nonStaticInt);
			}
		}

		static class StaticClass2
		{
			// public int nonStaticInt;						// error : 정적클래스는 맴버변수를 포함할 수 없음
			// public void NonStaticFunc() { }				// error : 정적클래스는 맴버함수를 포함할 수 없음

			public static int staticInt;
			public static void StaticFunc() { }
		}

		static void Main6()
		{
			StaticClass1.staticInt = 10;                    // 정적변수는 전역적으로 접근 가능
			StaticClass1.StaticFunc();                      // 정적함수는 전역적으로 접근 가능
			// StaticClass.nonStaticInt = 10;				// error : 맴버변수는 인스턴스가 있어야 사용가능
			// StaticClass.NonStaticFunc();					// error : 맴버함수는 인스턴스가 있어야 사용가능

			StaticClass1 instance = new StaticClass1();
			instance.nonStaticInt = 20;                     // 맴버변수는 인스턴스가 각자 가지고 있으며 인스턴스를 통해 접근
			instance.NonStaticFunc();                       // 맴버함수는 인스턴스가 각자 가지고 있으며 인스턴스를 통해 접근
			// instance.staticInt = 20;						// error : 정적변수는 인스턴스가 아닌 클래스이름을 통해서 접근
			// instance.StaticFunc();						// error : 정적함수는 인스턴스가 아닌 클래스이름을 통해서 접근

			// StaticClass2 instance = new StaticClass2();	// error : 정적클래스는 인스턴스를 만들 수 없음
			StaticClass2.staticInt = 30;
			StaticClass2.StaticFunc();
		}

		static void Main(string[] args)
		{
			Main1();
			Main2();
			Main3();
			Main4();
			Main5();
			Main6();
		}
	}
}