namespace _00._Program
{
	/* 주석 : 코드에 영향을 주지 않는 텍스트 */

	// 기본 주석
	// 한줄 주석 : 한 줄의 텍스트를 주석으로 취급
	/* 범위 주석 : 시작(/*)과 끝(* /)까지의 텍스트를 주석으로 취급 */

	// 응용 주석
	/*
	 * 여러줄 주석 :
	 * 시작(/*) 후 줄바꿈을 할 경우
	 * 자동으로 여러줄 주석으로 입력됨
	 */
	/// 자동완성 주석 : 
	/// 클래스 또는 함수 앞에서 /// 입력으로 자동완성됨
	/// 주석의 내용을 입력할 경우 

	/// <summary>
	/// 클래스의 설명
	/// </summary>
	internal class Comment
	{
		/// <summary>
		/// 함수의 설명
		/// </summary>
		/// <param name="param1">매개변수1의 설명</param>
		/// <param name="param2">매개변수2의 설명</param>
		/// <returns>반환 값의 설명</returns>
		public int CommentFunc(int param1, float param2)
		{
			return 0;
		}
	}
}
