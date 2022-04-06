using System;
namespace LeetCode.DataStructures.Heap
{
    /// <summary>
    /// Heap is a complete binary tree
    /// Height of a complete binary tree is Log n
    /// </summary>
    public abstract class Heap : IHeap
    {
        private readonly bool _isHeapSort;        
        protected readonly int[] Elements;
        protected int _size;

        protected Heap(int size, bool isHeapSort = false)
        {
            Elements = new int[size];
            _isHeapSort = isHeapSort;
        }

        protected void SwapElements(int firstindex, int secondIndex)
        {
            if (firstindex >= Elements.Length ||
                secondIndex >= Elements.Length ||
                firstindex < 0 ||
                secondIndex < 0)
                throw new IndexOutOfRangeException();

            int temp = Elements[firstindex];
            Elements[firstindex] = Elements[secondIndex];
            Elements[secondIndex] = temp;
        }

        protected int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        protected int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        protected int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;//floor value

        protected int GetLeftChild(int parentIndex) => Elements[GetLeftChildIndex(parentIndex)];
        protected int GetRightChild(int parentIndex) => Elements[GetRightChildIndex(parentIndex)];
        protected int GetParent(int elementIndex) => Elements[GetParentIndex(elementIndex)];

        protected bool HasLeftChild(int parentIndex) => GetLeftChildIndex(parentIndex) < _size;
        protected bool HasRightChild(int parentIndex) => GetRightChildIndex(parentIndex) < _size;
        protected bool IsRoot(int elementindex) => elementindex == 0;

        protected abstract bool HeapElementToParentCheck(int elementIndex);

        protected bool HeapParentToElementCheck(int parentIndex, bool leftElement = true)
        {
            int elementIndex = GetLeftChildIndex(parentIndex);

            if (!leftElement)
                elementIndex = GetRightChildIndex(parentIndex);

            return HeapElementToParentCheck(elementIndex);
        }

        protected void ReCalculateUp()
        {
            int index = _size - 1;

            //start from the last node/where the new node is inserted and check
            while (!IsRoot(index) && !HeapElementToParentCheck(index))//till index greater than root and till element is greater than its parent, which is opposite of Min heap
            {
                int parentIndex = GetParentIndex(index);
                SwapElements(index, parentIndex);
                index = parentIndex;
            }
        }

        protected abstract void ReCalculateDown();

        /// <summary>
        /// Time complexity to create a Heap is O(n log n)
        /// Time complexity to insert in a Heap is O(log n)
        /// </summary>
        /// <param name="element"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Insert(int element)
        {
            if (_size == Elements.Length)
                throw new IndexOutOfRangeException();

            Elements[_size] = element;//inserted in the last position from left to right in the leaf node level
            _size++;
            //Check if the heap properties are satisfied - min/max, bottom up
            ReCalculateUp();
        }

        /// <summary>
        /// Time complexity to delete an element in a Heap is O(log n)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int Pop()
        {
            if (_size <= 0)
                throw new IndexOutOfRangeException();

            var elementToPop = Elements[0];
            _size--;

            if (_size >= 1)
            {
                Elements[0] = Elements[_size];
                //Verify if Heap property is satisfied from top to bottom and move the root element to appropriate position downwards
                ReCalculateDown();

                if (_isHeapSort)
                    Elements[_size] = elementToPop;
            }

            return elementToPop;
        }

        public int Peek()
        {
            if (_size <= 0)
                throw new IndexOutOfRangeException();

            return Elements[0];
        }

        public int Count => _size;

        public bool IsEmpty => _size == 0;

        public int[] HeapSortResult
        {
            get
            {
                if (!_isHeapSort)
                    throw new Exception("Instantiate by sending HeapSort parameter as true");

                return Elements;
            }
        }
    }

}

