namespace _11._Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*******************************************************************
             * 배열 (Array)
             * 
             * 동일한 자료형의 요소들로 구성된 데이터 집합
             * 인덱스를 통하여 배열요소(Element)에 접근할 수 있음
             * 배열의 처음 요소의 인덱스는 0부터 시작함
             *******************************************************************/

            // <배열 기본>
            // 배열을 만들기 위해 자료형과 크기를 정하여 생성
            // 배열의 요소에 접근하기 위해 [인덱스] 를 사용
            // 배열의 Length 를 통해 크기를 확인
            // 자료형[] 배열이름 = new 자료형[크기];
            int[] scores = new int[5];      // 크기 5의 배열 선언

            scores[0] = 10;                 // 0번째 요소 저장
            scores[1] = 20;                 // 1번째 요소 저장
            scores[2] = 30;                 // 2번째 요소 저장
            scores[3] = 40;                 // 3번째 요소 저장
            scores[4] = 50;                 // 4번째 요소 저장

            Console.WriteLine($"배열의 0번째 요소 : {scores[0]}");     // 0번째 요소 불러오기
            Console.WriteLine($"배열의 1번째 요소 : {scores[1]}");     // 1번째 요소 불러오기
            Console.WriteLine($"배열의 2번째 요소 : {scores[2]}");     // 2번째 요소 불러오기
            Console.WriteLine($"배열의 3번째 요소 : {scores[3]}");     // 3번째 요소 불러오기
            Console.WriteLine($"배열의 4번째 요소 : {scores[4]}");     // 4번째 요소 불러오기


            // <배열 선언 및 초기화>
            int[] array1;                           // 배열 변수 선언
            array1 = new int[3];                    // 데이터를 10개 가지는 배열 생성
            int[] array2 = new int[3] { 1, 2, 3 };  // 크기가 3인 배열을 선언하고 배열 요소들을 초기화
            int[] array3 = new int[] { 1, 2, 3 };   // 배열의 요소들을 초기화 하는 경우 배열의 크기를 생략 가능
            int[] array4 = { 1, 2, 3 };             // 배열의 요소들을 초기화 하는 경우 배열 생성을 생략 가능


            // <배열의 구현 원리>
            // C#의 배열은 Array 클래스를 통해 구현됨
            // 따라서 Array 클래스의 모든 특징을 가짐
            // Array 클래스의 정적 함수를 활용하여 다양한 기능 사용 가능
            int[] array = { 1, 3, 5, 4, 2 };

            int length = array.Length;   // 배열의 크기
            int max = array.Max();       // 배열의 최대값
            int min = array.Min();       // 배열의 최소값

            Array.Sort(array);                      // 배열 정렬
            Array.Reverse(array);                   // 배열 반전
            int index = Array.IndexOf(array, 3);    // 배열 탐색

            int[] shallow = array;                  // 배열의 얕은 복사 : 동일한 인스턴스를 참조
            int[] deep = new int[array.Length];     // 배열의 깊은 복사 : 새로운 인스턴스를 생성하고 복사
            Array.Copy(array, deep, array.Length);

            array[0] = 0;
            Console.WriteLine(array[0]);            // output : 0
            Console.WriteLine(shallow[0]);          // output : 0
            Console.WriteLine(deep[0]);             // output : 5


            // <인덱스>
            // 배열은 요소들을 메모리에 연속적으로 배치하는 원리로 구현
            // 이를 이용하여 배열의 특정요소의 메모리주소를 계산할 수 있음
            // i번째 배열요소 메모리주소 == 배열 시작 메모리주소 + (i * 자료형의 크기)
            // 이를 인덱스라고 표현함


            // <다차원 배열>
            // 배열의 []괄호 안에 차원수만큼 ','를 추가
            // 배열의 크기가 차원마다 동일함
            int[,] matrix = new int[3, 4];          // 2차원 배열 선언
            // [0,0] [0,1] [0,2] [0,3]
            // [1,0] [1,1] [1,2] [1,3]
            // [2,0] [2,1] [2,2] [2,3]
            matrix[2, 1] = 10;                      // 2차원 배열의 y:2 x:1 배열요소 저장
            Console.WriteLine(matrix[2, 1]);        // 2차원 배열의 y:2 x:1 배열요소 불러오기
            Console.WriteLine(matrix.GetLength(0)); // 2차원 배열의 y 크기
            Console.WriteLine(matrix.GetLength(1)); // 2차원 배열의 x 크기

            int[,,] cube = { { {1, 2}, {3, 4} }, { {5, 6}, {7, 8} } };      // 3차원 배열 선언 및 초기화


            // <가변 배열>
            // 배열의 []괄호를 배열 갯수만큼 추가
            // 배열의 크기를 각각 설정 가능
            int[][] jagged = new int[3][];          // 배열의 갯수 설정
            jagged[0] = new int[5];
            jagged[1] = new int[2];
            jagged[2] = new int[3];
            // [0][0] [0][1] [0][2] [0][3] [0][4]
            // [1][0] [1][1]
            // [2][0] [2][1] [2][2]


            // <배열과 반복>
            // 배열의 인덱스를 반복하여 증가시키며 사용하는 경우 배열의 모든 요소를 반복 수행하는데 용이함
            int[] ints = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(ints[i]);
            }

            int[,] tile = { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int y = 0; y < tile.GetLength(0); y++)
            {
                for (int x = 0; x < tile.GetLength(1); x++)
                {
                    Console.Write(tile[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
