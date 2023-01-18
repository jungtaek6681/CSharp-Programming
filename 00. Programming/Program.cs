using System;

namespace _00._Program
{
	internal class Program
	{
		/* Main 함수
		 * 
		 * 프로그램의 처음시작 지점이 되는 함수
		 * 모든 C# 프로그램은 Main이라는 시작 함수가 단 1개만 있어야 함
		 */
		static void Main(string[] args)
		{
			// 프로그램은 Main 함수를 시작으로 순서대로 처리됨

			/* Console 클래스
			 * 
			 * 콘솔 프로그램을 다루기 위해 사용하는 클래스
			 * Console.WriteLine : 콘솔에 출력하고 줄 바꿈
			 * Console.Write : 콘솔에 출력하고 줄을 바꾸지 않음
			 * Console.ReadLine : 콘솔을 통해 한줄 입력받음
			 * Console.Read : 콘솔을 통해 한글자 입력받음
			 * Console.ReadKey : 콘솔을 통해 키 입력받음
			 */
			Console.WriteLine("Hello, World!");

			Console.Write("콘솔을 통해 한줄 입력 : ");
			Console.ReadLine();
			Console.WriteLine("입력이 완료되었습니다.");

			Console.Write("콘솔을 통해 한글자 입력 : ");
			Console.Read();
			Console.WriteLine("입력이 완료되었습니다.");

			Console.Write("콘솔을 통해 키 입력 : ");
			Console.ReadKey();
			Console.WriteLine("입력이 완료되었습니다.");
		}
	}
}