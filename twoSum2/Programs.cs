using System;

namespace twoSum2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("two sum 2: {0}", obj.TwoSum(new int[]{1,2,3,5}, "7"));
        }
    }
    
    public class Solution {
      public int[] TwoSum(int[] numbers, int target) {
          int l = 0, r = numbers.Length - 1;
          while (l < r) {
              int sum = numbers[l] + numbers[r];
              if (sum == target) return new int[]{l + 1, r + 1};
              else if (sum < target) ++l;
              else --r;
          }
          return new int[]{};
      }
  }
}
