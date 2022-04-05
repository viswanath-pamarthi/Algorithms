using System;
namespace LeetCode.DataStructures.Heap
{
    public interface IHeap
    {
        //Insert
        void Insert(int element);

        //Pop
        int Pop();

        //Peek
        int Peek();
        //Count
        int Count { get; }

        //IsEmpty
        bool IsEmpty { get; }
    }
}
