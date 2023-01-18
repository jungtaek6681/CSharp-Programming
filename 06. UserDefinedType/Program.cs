using System;
using System.Linq;

namespace _06._UserDefinedType
{
	internal class Program
	{
		// ! 주의사항 ! //
		// 지금 당장은 public에 대해 알지 못하고 구조체 요소를 접근하기 위해서는 public을 붙여줘야 하지만,
		// public에 배우기 전까지는 구조체 요소 앞에 public에 붙여주도록 함

		/****************************************************************
		 * 열거형 (Enum)
		 * 
		 * 기본 정수 숫자의 형식의 명명된 상수 집합에 의해 정의되는 값 형식
		 * 열거형 멤버의 이름으로 관리되어 코드의 가독성적인 측면에 도움이 됨
		 ****************************************************************/

		// <열거형 기본사용>
		// enum 열거형이름 { 멤버이름, 멤버이름, ... }
		enum MoveKey { Up, Down, Left, Right }      // 열거형 정의 : 열거형이름과 멤버이름 작성
		static void Main1()
		{
			MoveKey key = MoveKey.Up;               // 열거형 변수 : 열거형의 값을 가지는 변수
			switch (key)
			{
				case MoveKey.Up:                    // 정수자료형을 쓰는 것보다 가독성이 좋음
					Console.WriteLine("위쪽으로 이동");
					break;
				case MoveKey.Down:
					Console.WriteLine("아래쪽으로 이동");
					break;
				case MoveKey.Left:
					Console.WriteLine("왼쪽으로 이동");
					break;
				case MoveKey.Right:
					Console.WriteLine("오른쪽으로 이동");
					break;
			}
		}

		// <열거형 변환>
		enum Season
		{
			Spring, // 0		// 열거형 멤버에 정수값을 지정하지 않을 경우 0부터 시작
			Summer = 20,        // 열거형 멤버에 직접 정수값을 할당가능
			Autumn, // 21		// 정수값을 할당하지 않을 경우 이전 멤버 + 1 값을 가짐
			Winter  // 22
		}

		static void Main2()
		{
			Season season1 = Season.Autumn;
			Console.WriteLine("{0}의 정수값은 {1}", season1, (int)season1);  // 열거형변수를 int로 형변환

			Season season2 = (Season)0;     // 정수에서 열거형변수로 변환
			Console.WriteLine(season2);     // Spring

			Season season3 = (Season)10;    // 열거형에 없는 정수값을 변환할 경우 정수로 사용
			Console.WriteLine(season3);     // 10
		}

		// <열거형 비트플래그 사용>
		[Flags]         // 열거형을 비트플래그로 사용
		enum Day
		{
			None = 0b_0000_0000,        // 0
			Monday = 0b_0000_0001,      // 1
			Tuesday = 0b_0000_0010,     // 2 
			Wednesday = 0b_0000_0100,       // 4
			Thursday = 0b_0000_1000,        // 8
			Friday = 0b_0001_0000,      // 16
			Saturday = 0b_0010_0000,        // 32
			Sunday = 0b_0100_0000,      // 64
			Weekend = Saturday | Sunday
		}

		static void Main3()
		{
			Day meetingDays = Day.Monday | Day.Wednesday;
			Console.WriteLine(meetingDays);     // Monday, Wednesday

			meetingDays |= Day.Friday;          // 비트마스킹을 이용한 추가
			Console.WriteLine(meetingDays);     // Monday, Wednesday, Friday

			meetingDays &= ~Day.Wednesday;      // 비트마스킹을 이용한 제거
			Console.WriteLine(meetingDays);     // Monday, Friday

			bool isMeetingOnMonday = (meetingDays & Day.Monday) != Day.None;    // 비트마스킹을 이용한 확인
			Console.WriteLine(isMeetingOnMonday);   // true
		}

		/****************************************************************
		 * 튜플 (Tuple)
		 * 
		 * 간단한 데이터 구조에서 여러 데이터 요소를 그룹화하는 간결한 구문을 제공
		 ****************************************************************/

		// <튜플 사용>
		static void Main4()
		{
			// 이름을 지정하지 않은 경우 Item1, Item2, ... 으로 초기화
			(double, int) t1 = (4.5, 3);
			Console.WriteLine("튜플의 첫번째 데이터 {0}, 두번째 데이터 {1}", t1.Item1, t1.Item2);
			t1.Item1 = 9.9;

			// 튜플에 이름을 지정한 경우 지정한 이름으로 사용
			(double A1, int B2) t2 = (4.5, 3);
			Console.WriteLine("튜플의 첫번째 데이터 {0}, 두번째 데이터 {1}", t2.A1, t2.B2);

			// 튜플의 비교는 같은 이름의 데이터끼리 비교
			(int a, double b) left1 = (5, 10);
			(double a, int b) right1 = (5, 10);
			Console.WriteLine(left1 == right1);		// output : false

			(int a, double b) left2 = (5, 10);
			(double a, int b) right2 = (5, 10);
			Console.WriteLine(left2 == right2);		// output : true 
		}

		// 함수의 반환형으로 여러 데이터를 한꺼번에 전달 가능
		(int min, int max) FindMinMax(int[] input)
		{
			return (input.Min(), input.Max());
		}

		/****************************************************************
		 * 구조체 (Struct)
		 * 
		 * 데이터와 관련 기능을 캡슐화할 수 있는 값 형식
		 * 데이터를 저장하기 보관하기 위한 단위용도로 사용
		 ****************************************************************/

		// <구조체 구성>
		// struct 구조체 이름 {구조체 내용}
		// 구조체 내용으로는 변수와 함수가 포함 가능
		struct Student
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

		static void Main5()
		{
			Student kim;            // 구조체 선언
			kim.name = "Kim";       // 구조체내 변수에 접근하기 위해 구조체에 . 을 붙여 사용
			kim.math = 10;
			kim.english = 10;
			kim.programming = 100;

			Console.Write("{0}의 평균 점수는 ", kim.name);
			Console.WriteLine(kim.GetAverage());    // 구조체내 함수에 접근하기 위해 . 을 붙여 사용
		}

		// <구조체 초기화 및 기본값>
		// 반환형이 없는 구조체이름의 함수를 초기화라 하며 구조체 변수들의 초기화를 진행하는 역할로 사용
		// 구조체의 초기화는 new 키워드를 통해서 사용
		// 초기화 기능을 포함하지 않아도 기본 초기화(매개변수가 없는 초기화)는 자동으로 생성됨
		// 기본 초기화는 구조체 변수들의 기본 초기화를 진행
		struct Player
		{
			public string name;
			public int hp;
			public int mp;

			// C#  9.0 이전 버전 : 기본 초기화는 자동으로 생성되며 변경할 수 없음
			// C# 10.0 이후 버전 : 기본 초기화를 추가하지 않는 경우 기본 초기화는 자동으로 생성됨
			/*public Point()
			{
				// 변수를 기본값으로 초기화
			}*/

			public Player(string name, int hp)
			{
				// 초기화에서 모든 구조체 변수를 초기화하지 않으면 error 발생
				this.name = name;
				this.hp = hp;       // this : 자기 자신을 가리킴
				this.mp = 0;
			}

			public Player(string name, int hp, int mp) : this(name, hp) // 이전 초기화를 이용하여 초기화 간소화
			{
				this.mp = mp;
			}
		}

		static void Main6()
		{
			Player player1;
			player1.name = "마법사";
			player1.hp = 5;
			// Console.WriteLine("{0}", player1.mp);									// error : 초기화 되지 않은 변수

			Player player2 = new Player();                                              // 기본초기화
			Console.WriteLine("{0}, {1}, {2}", player2.name, player2.hp, player2.mp);   // output : "", 0, 0

			Player player3 = new Player() { name = "전사", hp = 30 };                 // 초기화 및 값대입
			Console.WriteLine("{0}, {1}, {2}", player3.name, player3.hp, player3.mp);   // output : "전사", 30, 0

			Player player4 = new Player("궁수", 20, 10);                                  // 구현한 초기화를 사용
			Console.WriteLine("{0}, {1}, {2}", player4.name, player4.hp, player4.mp);   // output : "궁수", 20, 10

			// Player player5 = new Player(10);											// error : 구현하지 않은 초기화
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