using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Interface
{
	/****************************************************************
	 * 인터페이스 (Interface)
	 * 
	 * 인터페이스는 맴버를 가질 수 있지만 직접 구현하지 않음 단지 정의만을 가짐
	 * 인터페이스를 가지는 클래스에서 반드시 인터페이스의 정의를 구현해야함
	 * 이를 반대로 표현하자면 인터페이스를 포함하는 클래스는
	 * 반드시 인터페이스의 구성 요소들을 구현했다는 것을 보장함
	 * Has-a 관계 : 클래스가 해당 행동을 할 수 있는 경우 적합함
	 ****************************************************************/

	// <인터페이스 정의>
	// 일반적으로 인터페이스의 이름은 I로 시작하도록 네이밍
	internal interface IInterfaceBasic1
	{
		void BasicFunc1();  // 직접 구현하지 않고 정의만 진행
	}

	internal interface IInterfaceBasic2
	{
		void BasicFunc2();
	}


	// <인터페이스 구현>
	// 상속처럼 정의한 인터페이스를 클래스 : 뒤에 선언하여 사용
	// 인터페이스는 여러개 포함 가능
	internal class InterfaceClass : IInterfaceBasic1, IInterfaceBasic2
	{
		// 반드시 인터페이스에서 정의한 요소를 구현해야함, 하지 않을 경우 오류
		public void BasicFunc1()
		{
			//
		}

		public void BasicFunc2()
		{
			//
		}
	}

	internal static class InterfaceUseClass
	{
		public static void Test()
		{
			// 1. 인터페이스 변수에 인터페이스를 포함한 인스턴스를 담을 수 있음
			IInterfaceBasic1 interfaceBasic1 = new InterfaceClass();
			IInterfaceBasic2 interfaceBasic2 = new InterfaceClass();

			InterfaceClass interfaceClass = new InterfaceClass();
			interfaceBasic1 = interfaceClass;
			interfaceBasic2 = interfaceClass;

			// 2. 인터페이스는 인스턴스화 할 수 없음
			// IInterfaceBasic1 interfaceInstance = new IInterfaceBasic1();	// error
			// IInterfaceBasic2 interfaceInstance = new IInterfaceBasic2();	// error

			// 3. 인터페이스의 정의만 되어 있는 요소들이 반드시 구현되어 있음이 보장되어 있기 때문에 사용 가능
			interfaceBasic1.BasicFunc1();
			interfaceBasic2.BasicFunc2();
		}
	}
}
