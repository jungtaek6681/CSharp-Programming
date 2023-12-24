namespace _16._Additional
{
    internal class Program
    {
        // C#에는 많은 기능이 있으며 있는 기능을 사용해 주는 것이 베스트
        // C#에서 제공되는 기능들은 훨씬 최적화가 잘 되어 있는 경우가 많음

        void Main()
        {
            // 기본자료형의 함수
            // 기본자료형은 구조체 또는 클래스로 구성됨
            // 이 구조체와 클래스 안에 유용한 기능이 구현되어 있음
            string str = "abc def";
            str.ToLower();                  // 소문자 변환
            str.ToUpper();                  // 대문자 변환
            str.Split(' ');                 // 문자열 나누기
            str.Replace('a', 'z');          // 문자 교체

            int[] array = { 1, 2, 3, 4, 5 };
            array.Max();                    // 최대값
            array.Min();                    // 최소값
            array.Average();                // 평균값


            // 기본자료형의 static 함수
            // 기본자료형의 인스턴스 없이 사용가능한 함수들이 구현되어 있음
            int.Parse("12");                // int 형변환
            int value = int.MaxValue;       // int 최대값

            string.Compare("abc", "abd");   // 문자열 비교

            int[] values = { 5, 2, 1, 4, 3 };
            Array.Sort(values);             // 배열 정렬
            Array.Reverse(values);          // 배열 반전
        }



        static void Main(string[] args)
        {

        }
    }
}
