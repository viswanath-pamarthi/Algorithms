using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/merge-sorted-array/discuss/
/// Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array. (In place)
///
///Note:
///You may assume that nums1 has enough space(size that is greater or equal to m + n) to hold additional elements from nums2.The number of elements initialized in nums1 and nums2 are m and n respectively.
/// </summary>
namespace LeetCode
{
    class MergeSortedArrays
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            //referred the discuss seciton, liked the idea of starting from last
            int i = m - 1; int j = n - 1;
            int k = m + n - 1;//keep track of index of insertion 

            //Similar to that of the merge routine in merge sort, but in place and first array has all the space required for the merged arrays
            while (i > -1 && j > -1)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                    k--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                    k--;
                }
            }

            while (j > -1)
            {
                nums1[k] = nums2[j];
                j--;
                k--;
            }
        }
    }
}
