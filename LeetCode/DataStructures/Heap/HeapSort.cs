using System;
namespace LeetCode.DataStructures.Heap
{
	public class HeapSort
	{
		public HeapSort()
		{
		}

		/// <summary>
        /// n logn + n log n = 2 * n * log n -> O(n log n)
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
		public int[] Sort(int[] inputArray, bool ascending = true)
		{
			IHeap heap;

			if (ascending)
				heap = new MaxHeap(inputArray.Length, true);
			else
				heap = new MinHeap(inputArray.Length, true);

			//total for insertion O(n log n)
			foreach (var element in inputArray)//O(n)
			{
				heap.Insert(element);//one insertion O(log n) - max comparisions is that of height of a complete binary tree
			}

			//total for deletion O(n log n)
			foreach (var element in inputArray)
			{
				heap.Pop();//log n
			}
			return heap.HeapSortResult;
		}
	}
}

