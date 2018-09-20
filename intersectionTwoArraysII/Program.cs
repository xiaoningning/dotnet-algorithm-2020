using System;
using System.Collections.Generic;

namespace intersectionTwoArraysII
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();            
            var res = obj.Intersect(new int[]{1,2,3,2,2,3}, new int[]{2,2,3});
            Console.WriteLine("intersection Two Arrays II: {0}", string.Join(",", res));
        }
        public class Solution {
            public int[] Intersect(int[] nums1, int[] nums2) {
                Dictionary<int, int> map = new Dictionary<int, int>();
                List<int> res = new List<int>();
                foreach (int i in nums1) {
                    if (!map.ContainsKey(i)) map.Add(i, 0);
                    map[i]++;
                }
                foreach (int i in nums2) {
                    if (map.ContainsKey(i)) {
                        if (map[i]-- > 0) res.Add(i);                        
                    }
                }
                return res.ToArray();
            }

            public int[] Intersect1(int[] nums1, int[] nums2) {
                Array.Sort(nums1);
                Array.Sort(nums2);
                List<int> res = new List<int>();
                int i = 0, j = 0;
                while (i < nums1.Length && j < nums2.Length) {
                    if (nums1[i] == nums2[j]) {
                        res.Add(nums1[i]);
                        i++;
                        j++;
                    }
                    else if (nums1[i] > nums2[j]) j++;
                    else i++;                
                }
                return res.ToArray();
            }
        }
    }
}
