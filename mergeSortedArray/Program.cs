using System;

namespace mergeSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n1 = new int[]{1,2,3,0,0,0};
            int[] n2 = new int[]{2,5,6};
            Console.WriteLine("merge sorted array");
            var obj = new Solution();
            obj.Merge(n1, 3, n2, 3);
            Console.WriteLine(string.Join(",", n1));
        }
    }
    public class Solution {
        public void Merge(int[] nums1, int m, int[] nums2, int n) {
            int cnt = m + n - 1;
            m--;
            n--;
            while (m >= 0 && n >= 0) nums1[cnt--] = nums1[m] > nums2[n] ? nums1[m--] : nums2[n--];
            while (n >= 0) nums1[cnt--] = nums2[n--];
        }
    }
}
