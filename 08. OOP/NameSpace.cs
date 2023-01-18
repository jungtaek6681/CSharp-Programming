using System;       // 이 파일의 이후 코드부터 네임스페이스에서 정의된 식별자를 사용

// <네임스페이스>
// 내부 식별자(형식, 함수, 변수 등의 이름)에 범위를 제공하는 선언적 영역
// 같은 이름의 식별자라 하더라도 다른 네임스페이스에 있다면 다른 클래스로 인식
// 여러 라이브러리가 포함된 경우, 협업하는 과정에서 네이밍룰 등으로 이름 충돌을 방지하는데 사용

using ACompany;
using BCompany;

namespace _08._OOP
{
	internal class NameSpace
	{
		void Func()
		{
			// SameNameClass name = new SameNameClass();	// error : 모호한 참조, 같은 이름의 클래스가 여러개 있음
			ACompany.SameNameClass nameA = new ACompany.SameNameClass();
			BCompany.SameNameClass nameB = new BCompany.SameNameClass();
		}
	}
}

// 네임스페이스가 구분된 경우 동일한 클래스 이름이 있지만 충돌하지 않음
namespace ACompany
{
	public class SameNameClass
	{
		public void Func() { }
	}
}

namespace BCompany
{
	public class SameNameClass
	{
		public void Func() { }
	}
}