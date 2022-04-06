using System;
namespace LeetCode.DataStructures.Heap
{    
    public class MaxHeap : Heap
    {
        public MaxHeap(int size, bool isHeapSort = false) : base(size, isHeapSort)
        {
        }

        protected override bool HeapElementToParentCheck(int elementIndex)
        {
            return Elements[elementIndex] < GetParent(elementIndex);
        }

        protected override void ReCalculateDown()
        {
            int currentIndex = 0;

            while (HasLeftChild(currentIndex))
            {
                int biggerIndex = GetLeftChildIndex(currentIndex);

                if (HasRightChild(currentIndex) && GetRightChild(currentIndex) > GetLeftChild(currentIndex))
                {
                    biggerIndex = GetRightChildIndex(currentIndex);
                }

                if (Elements[currentIndex] >= Elements[biggerIndex])
                    break;

                SwapElements(currentIndex, biggerIndex);
                currentIndex = biggerIndex;
            }
        }
    }
}
