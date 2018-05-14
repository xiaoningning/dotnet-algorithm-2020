﻿using System;
using System.Collections.Generic;

namespace longestConsecutive
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{1,3,100,2,300,4};
            Console.WriteLine("longest consecutive sequence");
            Console.WriteLine("{0}", string.Join(",", obj.LongestConsecutive(nums)));
        }
    }
    public class Solution {
        public int LongestConsecutive(int[] nums) {
            int res = 0;
            // it is Set. then, O(n);
            HashSet<int> s = new HashSet<int>();
            foreach (int num in nums) s.Add(num);
            foreach (int num in nums) {
                if (s.Remove(num)) {
                    int pre = num - 1, next = num + 1;
                    while (s.Remove(pre)) --pre;
                    while (s.Remove(next)) ++next;
                    res = Math.Max(res, next - pre - 1);
                }
            }
            return res;    
        }
    }
}
