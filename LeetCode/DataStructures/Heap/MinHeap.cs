using System;
namespace LeetCode.DataStructures.Heap
{
    public class MinHeap : Heap
    {
        public MinHeap(int size, bool isHeapSort = false) : base(size, isHeapSort)
        {
        }

        protected override bool HeapElementToParentCheck(int elementIndex)
        {
            return Elements[elementIndex] > GetParent(elementIndex);//Min heap 
        }

        protected override void ReCalculateDown()
        {
            int index = 0;

            while (HasLeftChild(index))//Heap is a complete binary tree, so if there is no left child then there won't be right child
            {
                var smallerIndex = GetLeftChildIndex(index);

                //Check the smallest of the child nodes and then compare it with parent
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (Elements[smallerIndex] >= Elements[index])
                {
                    break;
                }
                SwapElements(index, smallerIndex);
                index = smallerIndex;
            }
        }
    }
}
