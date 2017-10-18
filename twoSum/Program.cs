using System;
using System.Collections.Generic;

namespace twoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s_array = args[0].Split(',');
            int[] nums = new int[s_array.Length];
            for (int i = 0; i <= nums.Length -1; i++)
            {
                nums[i] = Int32.Parse(s_array[i]);
            }
            Console.WriteLine("nums: [" + args[0] + "]");
            int target = Int32.Parse(args[1]);
            Console.WriteLine("target: " + target);

            int[] r = twoSum(nums, target);
            Console.WriteLine("find only one pair result in O(n): " + string.Join(",", r));
        }

        static int[] twoSum(int[] nums, int target)
        {
            int[] r = new int[2];
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i <= nums.Length - 1; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    r[1] = i;
                    r[0] = map[target - nums[i]];
                    return r;
                }
                if (!map.ContainsKey(nums[i])) map.Add(nums[i],i);
            }
            return r;
        }
    }
}
