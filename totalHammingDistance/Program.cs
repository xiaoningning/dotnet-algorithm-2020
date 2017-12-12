using System;

namespace totalHammingDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input numbers 0 <= n0, n1 ... nm <= 2^31" );
            string[] s_nums = args[0].Split(',');
            int[] nums = new int[s_nums.Length];
            for (int i = 0; i < s_nums.Length; i++)
            {
                nums[i] = (Int32.Parse(s_nums[i]));
            }
            Console.WriteLine("input numbers: {0}", args[0]);
            Console.WriteLine("Total Hamming Distance: {0}", TotalHammingDistance(nums));
        }

        static int TotalHammingDistance(int[] nums){
            int total = 0;
            for (int i = 0; i < 32; i++){
                int bitCount = 0;
                for (int j = 0; j < nums.Length; j++){
                    bitCount += (nums[j] >> i) & 1;
                }
                total += bitCount * (nums.Length -  bitCount);
            }

            return total;
        }
    }
}
