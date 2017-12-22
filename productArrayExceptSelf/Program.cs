using System;
using System.Linq;

namespace productArrayExceptSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input num list: {0}", args[0]);
            int[] nums = Array.ConvertAll(args[0].Split(','), s => int.Parse(s)); 
            int[] res = ProductExceptSelf1(nums);
            Console.WriteLine("output: {0}",  string.Join(",", res.Select(i => i.ToString()).ToArray()));
        }

        static int[] ProductExceptSelf(int[] nums) {
            int n = nums.Length;
            int[] res = new int[n];
            int[] forwardProd = new int[n], backwardPRod = new int[n];
            forwardProd[0] = 1; backwardPRod[n-1] = 1;
            for (int i = 1; i < n; i++){
                forwardProd[i] = forwardProd[i-1] * nums[i-1];
            }
            for (int i = n-2; i >=0 ; i--){
                backwardPRod[i] = backwardPRod[i+1] * nums[i+1];
            }
            for (int i = 0; i < n; i++){
                res[i] = forwardProd[i] * backwardPRod[i];
            }
            return res;
        }

        // save extra space
        static int[] ProductExceptSelf1(int[] nums) {
            int n = nums.Length;
            int[] res = new int[n];            
            res[0] = 1;
            for (int i = 1; i < n; i++){
                res[i] = res[i-1] * nums[i-1];
            }
            int right = 1;
            for (int i = n-1; i >=0 ; i--){
                res[i] *= nums[i];
                right *= nums[i];
            }
            
            return res;
        }
    }
}
