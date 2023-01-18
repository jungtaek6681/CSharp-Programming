using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._Additional
{
	public class IndexClass
	{
		private int[] data = new int[10];

		// <인덱서 정의>
		// this[int index]를 속성으로 정의하여 클래스의 인스턴스에 배열방식의 접근 허용
		public int this[int index]
		{
			get
			{
				if (index < 0 || index >= data.Length)
					throw new IndexOutOfRangeException();
				else
					return data[index];
			}
			set
			{
				if (index < 0 || index >= data.Length)
					throw new IndexOutOfRangeException();
				else
					data[index] = value;
			}
		}
	}

	internal class Indexer
	{
		public void Test()
		{
			IndexClass instance = new IndexClass();

			// 인덱서를 통한 배열방식의 접근
			instance[5] = 20;       // set 접근
			int i = instance[5];    // get 접근
		}
	}
}
