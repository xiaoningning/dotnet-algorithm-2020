using System;
using System.Collections.Generic;

namespace CheckSubarraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("nums array: {0}", args[0]);
            int[] nums = Array.ConvertAll(args[0].Split(','), s => int.Parse(s));
            int k = int.Parse(args[1]);
            Console.WriteLine("target value: {0}", k);            
            Console.WriteLine("find the target: {0}", CheckSubarraySum(nums, k) );
        }

        static bool CheckSubarraySum(int[] nums, int k) {
            // put the modulus of k into set
            HashSet<int> st = new HashSet<int>();
            int sum = 0;
            int pre = 0; // at least two nums
            foreach (var n in nums)
            {   
                sum += n;
                int res = (k==0) ? sum : (sum % k);
                if(st.Contains(res)) return true;
                // at least two nums => add after if
                st.Add(pre);
                pre = res;
            }
            return false;
        }
    }
}
