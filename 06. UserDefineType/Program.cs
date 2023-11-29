namespace _06._UserDefineType
{
    internal class Program
    {
        /********************************************************************
         * 열거형 (Enum)
         * 
         * 기본 정수 숫자의 형식의 명명된 상수 집합에 의해 정의되는 값 형식
         * 열거형 멤버의 이름으로 관리되어 코드의 가독성적인 측면에 도움이 됨
         ********************************************************************/

        // <열거형 기본사용>
        // enum 열거형이름 { 멤버이름, 멤버이름, ... }
        enum Direction { Up, Down, Left, Right }    // 열거형 정의 : 열거형이름과 멤버이름 작성
        void Main1()
        {
            Direction dir = Direction.Up;           // 열거형 변수 : 열거형의 값을 가지는 변수
            switch (dir)
            {
                case Direction.Up:                  // 정수자료형보다 코드 가독성이 좋음
                    Console.WriteLine("위쪽 방향으로 이동");
                    break;
                case Direction.Down:
                    Console.WriteLine("아래쪽 방향으로 이동");
                    break;
                case Direction.Left:
                    Console.WriteLine("왼쪽 방향으로 이동");
                    break;
                case Direction.Right:
                    Console.WriteLine("오른쪽 방향으로 이동");
                    break;
            }
        }


        // <열거형 변환>
        enum Season
        {
            Spring, // 0    // 열거형 멤버에 정수값을 지정하지 않을 경우 0부터 시작
            Summer, // 1    // 열거형 멤버에 정수값을 지정하지 않을 경우 이전 맴버 +1 값을 가짐
            Autumn = 20,    // 정수값을 직접 할당 가능
            Winter  // 21   // 정수값을 직접 할당한 경우에도 이전 멤버 +1 값을 가짐
        }

        void Main2()
        {
            Season season1 = Season.Autumn;
            Console.WriteLine($"{season1}의 정수값은 {(int)season1} 입니다.");  // 열거형변수를 int로 형변환

            Season season2 = (Season)0;     // 정수에서 열거형변수로 형변환
            Console.WriteLine(season2);     // Spring
        }



        /**************************************************
         * 구조체 (Struct)
         * 
         * 데이터와 관련 기능을 캡슐화할 수 있는 값 형식
         * 데이터를 저장하기 보관하기 위한 단위용도로 사용
         **************************************************/

        // <구조체 구성>
        // struct 구조체이름 { 구조체내용 }
        // 구조체 내용으로는 변수와 함수가 포함 가능
        struct StudentInfo
        {
            public string name;
            public int math;
            public int english;
            public int science;

            public float Average()
            {
                return (math + english + science) / 3f;
            }
        }


        void Main3()
        {
            StudentInfo info;            // 구조체 변수 선언
            info.name = "Kim";           // 구조체내 변수에 접근하기 위해 구조체에 .을 붙여 사용
            info.math = 10;
            info.english = 20;
            info.science = 100;

            float average = info.Average();   // 구조체내 함수에 접근하기 위해 구조체에 .을 붙여 사용
        }


        // <구조체 초기화>
        // 반환형이 없는 구조체이름의 함수를 초기화라 하며 구조체 변수들의 초기화를 진행하는 역할로 사용
        // 매개변수가 있는 초기화를 정의하여 구조체 변수의 값을 설정하기 위한 용도로 사용
        // 구조체의 초기화는 new 키워드를 통해서 사용
        struct Point
        {
            public int x;
            public int y;

            // C#  9.0 이전 버전 : 기본 초기화는 자동으로 생성되며 변경할 수 없음
            // C# 10.0 이후 버전 : 기본 초기화를 추가하지 않는 경우 자동으로 생성되며 추가하여 변경 가능
            /*public Point()
            {
                this.x = 0;
                this.y = 0;
            }*/

            public Point(int x, int y)
            {
                // 초기화에서 모든 구조체 변수를 초기화하지 않으면 error 발생
                this.x = x;     // this : 자기 자신을 가리킴
                this.y = y;
            }
        }

        void Main4()
        {
            Point point1;
            point1.x = 1;
            Console.WriteLine($"{point1.x}");
            // Console.WriteLine($"{point1.y}");            // error : 초기화하지 않은 변수 사용

            Point point2 = new Point();                     // 기본 초기화 사용
            Console.WriteLine($"{point2.x}, {point2.y}");   // output : 0, 0

            Point point3 = new Point(1, 2);                 // 추가로 구현한 초기화 사용
            Console.WriteLine($"{point3.x}, {point3.y}");   // output : 1, 2

            Point point4 = new Point() { x = 3, y = 4 };    // 초기화 및 값대입
            Console.WriteLine($"{point4.x}, {point4.y}");   // output : 3, 4
        }


        // <구조체 깊은복사>
        // 구조체에 대입연산자(=)를 통해 구조체 내 모든 변수들의 값이 복사됨
        struct MyStruct
        {
            public int value1;
            public int value2;
        }

        void Main5()
        {
            MyStruct s;
            s.value1 = 1;
            s.value2 = 2;

            MyStruct t = s;     // 구조체 내 모든 변수들의 값이 복사됨
            t.value1 = 3;

            Console.WriteLine(s.value1);    // 1
            Console.WriteLine(s.value2);    // 2

            Console.WriteLine(t.value1);    // 3
            Console.WriteLine(t.value2);    // 2
        }


        static void Main(string[] args)
        {
            
        }
    }
}
