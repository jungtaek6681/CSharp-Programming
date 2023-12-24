namespace _12._Generic
{
    internal class Program
    {
        /********************************************************************************************
         * 일반화 (Generic)
         * 
         * 클래스 또는 함수가 코드에 의해 선언되고 인스턴스화될 때까지 형식의 사양을 연기하는 디자인
         * 기능을 구현한 뒤 자료형을 사용 당시에 지정해서 사용
         ********************************************************************************************/

        // <일반화 함수>
        // 일반화는 자료형의 형식을 지정하지 않고 함수를 정의
        // 기능을 구현한 뒤 사용 당시에 자료형의 형식을 지정해서 사용
        public static void ArrayCopy<T>(T[] source, T[] output)
        {
            for (int i = 0; i < source.Length; i++)
            {
                output[i] = source[i];
            }
        }

        void Main1()
        {
            int[] iSrc = { 1, 2, 3, 4, 5 };
            float[] fSrc = { 1f, 2f, 3f, 4f, 5f };
            double[] dSrc = { 1d, 2d, 3d, 4d, 5d };

            int[] iDst = new int[iSrc.Length];
            float[] fDst = new float[fSrc.Length];
            double[] dDst = new double[dSrc.Length];

            // 일반화된 함수로 자료형과 무관한 함수 구현
            ArrayCopy<int>(iSrc, iDst);         // 자료형을 함수 호출 당시 결정
            ArrayCopy<float>(fSrc, fDst);
            ArrayCopy<double>(dSrc, dDst);

            char[] cSrc = { 'a', 'b', 'c' };
            char[] cDst = new char[cSrc.Length];
            ArrayCopy(cSrc, cDst);              // 일반화 자료형을 매개변수를 통해 추측 가능한 경우 생략 가능
        }


        // <일반화 클래스>
        // 클래스에 필요한 자료형을 일반화하여 구현
        // 이후 클래스 인스턴스를 생성할 때 자료형을 지정하여 사용
        public class SafeArray<T>
        {
            T[] array;

            public SafeArray(int size)
            {
                array = new T[size];
            }

            public void Set(int index, T value)
            {
                if (index < 0 || index >= array.Length)
                    return;

                array[index] = value;
            }

            public T Get(int index)
            {
                if (index < 0 || index >= array.Length)
                    return default(T);      // default : T 자료형의 기본값

                return array[index];
            }
        }


        // <일반화 자료형 제약>
        // 일반화 자료형을 선언할 때 제약조건을 선언하여, 사용 당시 쓸 수 있는 자료형을 제한
        class StructT<T> where T : struct { }           // T는 구조체만 사용 가능
        class ClassT<T> where T : class { }             // T는 클래스만 사용 가능
        class NewT<T> where T : new() { }               // T는 매개변수 없는 생성자가 있는 자료형만 사용 가능

        class ParentT<T> where T : Parent { }           // T는 Parent 파생클래스만 사용 가능
        class InterfaceT<T> where T : IComparable { }   // T는 인터페이스를 포함한 자료형만 사용 가능

        class Parent { }
        class Child : Parent { }

        void Main2()
        {
            StructT<int> structT = new StructT<int>();          // int는 구조체이므로 struct 제약조건이 있는 일반화 자료형에 사용 가능
            // ClassT<int> classT = new ClassT<int>();          // error : int는 구조체이므로 class 제약조건이 있는 일반화 자료형에 사용 불가
            NewT<int> newT = new NewT<int>();                   // int는 new int() 생성자가 있으므로 사용 가능

            ParentT<Parent> parentT = new ParentT<Parent>();    // Parent는 Parent 파생클래스이므로 사용 가능
            ParentT<Child> childT = new ParentT<Child>();       // Child는 Parent 파생클래스이므로 사용 가능
            InterfaceT<int> interT = new InterfaceT<int>();     // int는 IComparable 인터페이스를 포함하므로 사용 가능
        }


        // <일반화 제약 용도>
        // 일반화 자료형에 제약조건이 있다면 포함가능한 자료형의 기능을 사용할 수 있음
        public T Bigger<T>(T left, T right) where T : IComparable<T>
        {
            if (left.CompareTo(right) > 0)
            {
                return left;
            }
            else
            {
                return right;
            }
        }


        static void Main(string[] args)
        {

        }
    }
}
