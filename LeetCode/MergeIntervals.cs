using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Given a collection of intervals, merge all overlapping intervals.
///https://leetcode.com/problems/merge-intervals/description/
///For example,
///Given[1, 3],[2, 6],[8, 10],[15, 18],
///return [1,6],[8,10],[15,18].
/// </summary>
namespace LeetCode
{
    // Definition for an interval.
    public class Interval
     {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    class MergeIntervals
    {
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            int j = 0, i = j + 1;
            int lengthIntervals = intervals.Count;

            List<Interval> temp = intervals.ToList();
            temp.Sort((a, b) => a.start.CompareTo(b.start));//referred discussion section to get the idea of performing sort, there is no clarity on how the input order would look like

            if (lengthIntervals <= 1)
            {
                return intervals;
            }

            while (i < lengthIntervals)
            {
                //overlaping interval
                if (((temp[i].start - temp[j].end) <= 0))
                {
                    if (temp[i].end > temp[j].end)
                        temp[j].end = temp[i].end;

                    if (temp[i].start < temp[j].start)
                        temp[j].start = temp[i].start;

                    temp.Remove(temp[i]);
                    lengthIntervals--;
                }
                else
                {
                    i++;
                    j++;
                }

            }

            return temp;
        }
    }
}
