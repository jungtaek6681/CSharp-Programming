using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Event.DelegateBasic
{
	public static class IntSortMachine
	{
		public delegate int Compare(int left, int right);

		// 딜리게이트의 매개변수로 사용
		public static void Sort(int[] array, Compare compare)
		{
			// 알고리즘 Bubble Sort
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = i; j < array.Length; j++)
				{
					if (compare(array[i], array[j]) > 0)
					{
						int temp = array[i];
						array[i] = array[j];
						array[j] = temp;
					}
				}
			}
		}
	}
}
