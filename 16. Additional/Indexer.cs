using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal class Indexer
    {
        // <인덱서 정의>
        // this[]를 속성으로 정의하여 클래스의 인스턴스에 인덱스 방식으로 접근 허용
        public class IndexerArray
        {
            private int[] array = new int[10];

            public int this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    array[index] = value;
                }
            }
        }

        void Main1()
        {
            IndexerArray array = new IndexerArray();

            // 인덱서를 통한 인덱스 접근
            array[5] = 20;      // this[] set 접근
            int i = array[5];   // this[] get 접근
        }


        // <인덱서 자료형>
        // 인덱서는 다른 자료형 사용도 가능
        // 열거형을 통해 인덱서를 사용하는 경우도 빈번
        public enum Parts { Head, Body, Feet, Hand, SIZE }
        public class Equipment
        {
            string[] parts = new string[(int)Parts.SIZE];

            public string this[Parts type]
            {
                get
                {
                    return parts[(int)type];
                }
                set
                {
                    parts[(int)type] = value;
                }
            }
        }

        void Main2()
        {
            Equipment equipment = new Equipment();

            equipment[Parts.Head] = "낡은 헬멧";
            equipment[Parts.Feet] = "가죽 장화";

            Console.WriteLine($"착용하고 있는 신발 : {equipment[Parts.Feet]}");
        }
    }
}
