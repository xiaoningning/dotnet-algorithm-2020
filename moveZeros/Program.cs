using System;
using System.Collections.Generic;
using System.Linq;

namespace moveZeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input num list: {0}", args[0]);
            int[] nums = Array.ConvertAll(args[0].Split(','), s => int.Parse(s)); 
            MoveZeroes(nums);
            Console.WriteLine("output: {0}",  string.Join(",", nums.Select(i => i.ToString()).ToArray()));
        }

        static void MoveZeroes(int[] nums) {
            for (int lastNonZero = 0, i = 0; i < nums.Length; i++){
                if(nums[i] != 0){
                    swapArray(nums, lastNonZero, i);
                    lastNonZero++;
                }
            }        
        }
        static void swapArray(int[] arr, int i, int j){
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
