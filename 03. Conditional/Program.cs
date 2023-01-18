using System;

namespace _03._Conditional
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/****************************************************************
			 * 조건문 (Conditional)
			 * 
			 * 조건에 따라 실행이 달라지게 할 때 사용하는 문장
			 ****************************************************************/

			/****************************************************************
			 * if 조건문
			 * 
			 * 조건식의 true, false에 따라 실행할 블록을 결정하는 조건문
			 ****************************************************************/

			// <if 조건문 기본>
			if (true)   // 조건이 true인 경우 바로 아래의 블록이 실행됨
			{
				Console.WriteLine("실행되는 블록");
			}
			else
			{
				Console.WriteLine("실행되지 않는 블록");
			}

			if (false)  // 조건이 false인 경우 else 블록이 있다면 실행됨
			{
				Console.WriteLine("실행되지 않는 블록");
			}
			else
			{
				Console.WriteLine("실행되는 블록");
			}

			// else 블록은 선택사항으로 필요없을 경우 추가하지 않아도 됨
			int studentCount = 30;
			if (studentCount > 20)
			{
				Console.WriteLine("책상을 추가함");
			}
			/* else
			{
				// 아무것도 하지 않음;
			} */

			// else 블록에 if 문을 추가함으로 여러 조건을 확인할 수 있음
			if (studentCount < 10)
			{
				Console.WriteLine("작은 크기의 교실을 준비함");
			}
			else
			{
				if (studentCount < 20)
				{
					Console.WriteLine("중간 크기의 교실을 준비함");
				}
				else
				{
					Console.WriteLine("큰 크기의 교실을 준비함");
				}
			}

			// else 블록에 if 문이 있다면 블록을 생략해도 동일한 효과
			// else if 키워드가 따로 있는 것이 아닌 else + if
			if (studentCount < 10)
			{
				Console.WriteLine("작은 크기의 교실을 준비함");
			}
			else if (studentCount < 20)
			{
				Console.WriteLine("중간 크기의 교실을 준비함");
			}
			else
			{
				Console.WriteLine("큰 크기의 교실을 준비함");
			}


			/****************************************************************
			 * switch 조건문
			 * 
			 * 조건값에 따라 실행할 시작지점을 결정하는 조건문
			 ****************************************************************/

			// <switch 조건문 기본>
			string command = "환경설정";
			switch (command)            // 조건값 지정								
			{
				case "게임시작":        // 조건값이 일치하지 않아 넘어감
					Console.WriteLine("게임을 시작함");
					break;
				case "환경설정":     // 조건값이 일치하는 case 부터 시작함
					Console.WriteLine("환경설정창을 띄움");
					break;          // break가 있는 지점에서 switch 블록을 빠져나감
				case "게임종료":
					Console.WriteLine("게임을 종료함");
					break;
			}

			// 조건값이 일치하는 case가 없는 경우 default 가 실행지점이 됨
			int value = 7;
			switch (value)
			{
				case 1:
					Console.WriteLine("값은 1");
					break;
				case 3:
					Console.WriteLine("값은 3");
					break;
				default:        // 조건값이 case에 일치한 적이 없으니 default가 실행지점이 됨
					Console.WriteLine("값은 그 외");
					break;
			}

			// 조건값에 따라 동일한 실행이 필요한 경우 묶어서 사용 가능
			char key = 'w';
			switch (key)
			{
				case 'w':
				case 'W':
				case 'ㅈ':
					Console.WriteLine("위쪽으로 이동");
					break;
				case 'a':
				case 'A':
				case 'ㅁ':
					Console.WriteLine("왼쪽으로 이동");
					break;
				case 's':
				case 'S':
				case 'ㄴ':
					Console.WriteLine("아래쪽으로 이동");
					break;
				case 'd':
				case 'D':
				case 'ㅇ':
					Console.WriteLine("오른쪽으로 이동");
					break;
				default:
					Console.WriteLine("이동하지 않음");
					break;
			}


			/****************************************************************
			 * 삼항연산자
			 * 
			 * 간단한 조건문을 빠르게 작성
			 ****************************************************************/

			// <삼항 연산자 기본>
			// 조건식 ? true인 경우 값 : false인 경우 값
			int leftValue = 20;
			int rightValue = 10;
			int bigger = leftValue > rightValue ? leftValue : rightValue;
		}
	}
}