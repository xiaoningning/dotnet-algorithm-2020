using System;
using System.Collections.Generic;
using System.Linq;

namespace topKFrequent
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{1,1,1,2,2,3};
            var res = obj.TopKFrequent(nums, 2);
            Console.WriteLine("Top Kth Frequent Elements: ", string.Join(",", res));
        }
    }
    public class Solution {
        public IList<int> TopKFrequent(int[] nums, int k) {
            int n = nums.Length;
            Dictionary<int, int> m = new Dictionary<int, int>();
            Dictionary<int, List<int>> bucket = new Dictionary<int, List<int>>();
            List<int> res = new List<int>();

            // initialize bucket with possible # of element
            for(int i = 1; i <= n; i++) bucket.Add(i, new List<int>());
            foreach( var i in nums) {
                if (!m.ContainsKey(i)) m.Add(i, 0);
                m[i]++;
            }
            
            foreach(var kv in m) {
                bucket[kv.Value].Add(kv.Key);
            }
            
            for(int i = n; i >= 1; i--){
                if (bucket[i].Any()) res.AddRange(bucket[i]);                
                if (res.Count == k) return res;
            }
            return res;    
        }
    }
}
