using System;

namespace _11._Generic
{
	internal class Program
	{
		/****************************************************************
		 * 일반화 (Generic)
		 * 
		 * 클래스 또는 함수가 코드에 의해 선언되고 인스턴스화될 때까지 형식의 사양을 연기하는 디자인
		 * 거의 모든 부분이 동일하지만 일부 자료형만이 다른 경우 사용
		 ****************************************************************/

		// <일반화>
		// 일반화가 없는 경우 자료형마다 함수를 작성
		public static void ArrayCopy(int[] source, out int[] output)
		{
			output = new int[source.Length];
			for (int i = 0; i < source.Length; i++) { output[i] = source[i]; }
		}

		public static void ArrayCopy(float[] source, out float[] output)
		{
			output = new float[source.Length];
			for (int i = 0; i < source.Length; i++) { output[i] = source[i]; }
		}

		public static void ArrayCopy(double[] source, out double[] output)
		{
			output = new double[source.Length];
			for (int i = 0; i < source.Length; i++) { output[i] = source[i]; }
		}

		// 일반화를 이용하면 위 함수들과 다른 자료형의 함수 또한 호환할 수 있음
		public static void ArrayCopy<T>(T[] src, out T[] dst)
		{
			dst = new T[src.Length];
			for (int i = 0; i < src.Length; i++) { dst[i] = src[i]; }
		}

		public void Test1()
		{
			int[] iSrc = { 1, 2, 3, 4, 5 };
			float[] fSrc = { 1f, 2f, 3f, 4f, 5f };
			double[] dSrc = { 1d, 2d, 3d, 4d, 5d };

			int[] iDst;
			float[] fDst;
			double[] dDst;
			// 일반화가 없는 경우 자료형마다 함수 구현
			ArrayCopy(iSrc, out iDst);
			ArrayCopy(fSrc, out fDst);
			ArrayCopy(dSrc, out dDst);

			// 일반화된 함수로 자료형과 무관한 함수 구현
			ArrayCopy<int>(iSrc, out iDst);         // 자료형을 함수 호출당시 결정
			ArrayCopy<float>(fSrc, out fDst);
			ArrayCopy<double>(dSrc, out dDst);

			char[] cSrc = { 'a', 'b', 'c' };
			char[] cDst;
			ArrayCopy<char>(cSrc, out cDst);
		}

		// <일반화 자료형 제약>
		// 일반화 자료형을 선언할 때 제약조건을 선언하여, 일반화가 가능한 자료형을 제한

		class StructClass<T> where T : struct { }			// T는 Value 타입
		class ClassClass<T> where T : class { }				// T는 Reference 타입
		class ParentClass { }                           
		class ChildClass<T> where T : ParentClass { }		// T는 파생클래스이어야 함
		class InterfaceClass<T> where T : IComparable { }   // T는 IComparable 인터페이스를 가져야 함

		public void Test2()
		{
			StructClass<int> structClass = new StructClass<int>();  // int는 구조체이므로 struct 제약조건이 있는 일반화 가능
																	// ClassClass<int> classClass = new ClassClass<int>();	// error : int는 구조체이므로 class 제약조건이 있는 일반화 불가
		}

		// <일반화 제약 용도>
		// 일반화 자료형에 제약조건이 있다면 포함가능한 자료형의 기능을 사용할 수 있음

		public class MyBase
		{
			public void Start()
			{
				Console.WriteLine("Start");
			}
		}

		public void Test3<T>(T param) where T : MyBase
		{
			param.Start();      // 일반화 자료형의 제약조건이 MyBase 클래스이므로, MyBase의 기능을 사용 가능
		}

		public static void Main(string[] args)
		{

		}
	}
}