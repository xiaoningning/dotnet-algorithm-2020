using System;
using System.Collections.Generic;

namespace slidingWindowMax
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("sliding windows max : {0}", string.Join(",", obj.MaxSlidingWindow(new int[]{1,3,-1,-3,5,3,6,7}, 3)));
        }
    }
    public class Solution {
        public int[] MaxSlidingWindow(int[] nums, int k) {
            List<int> res = new List<int>();
            List<int> q = new List<int>();
            for (int i =0; i < nums.Length; i++) {
                // i shift to left more than k
                // remove the first index of k window
                if (q.Count != 0 && q[0] == i -k) q.RemoveAt(0);
                // remove index whose value < current i value
                // 
                while (q.Count != 0 && nums[q[q.Count -1 ]] < nums[i]) q.RemoveAt(q.Count - 1);
                q.Add(i);
                if (i >= k - 1) res.Add(nums[q[0]]);
            }
            return res.ToArray();
        }
    }
}
