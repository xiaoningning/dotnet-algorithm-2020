using System;
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
        public int LongestConsecutive1(int[] nums) {
            int res = 0;
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
            // O(n*n)
            return res;    
        }
        public int LongestConsecutive(int[] nums) {
            int res = 0;
            var m = new Dictionary<int, int>();
            foreach (int num in nums) {
                // skip duplicate
                if (m.ContainsKey(num)) continue;
                int pre = m.ContainsKey(num - 1) ? m[num - 1] : 0;
                int next = m.ContainsKey(num + 1) ? m[num + 1] : 0;
                int sum = pre + next + 1;
                m[num] = sum;
                res = Math.Max(res, sum);
                m[num - pre] = sum;
                m[num + next] = sum;
            }
            // O(n)
            return res; 
        }
    }
}
