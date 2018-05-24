using System;

namespace sortColors
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{0,1,2,1,0,1,2,0};
            obj.SortColors(nums);
            Console.WriteLine("sort colors {0}", string.Join(",", nums));
        }
    }
    public class Solution {
        public void SortColors(int[] nums) {
            int red = 0, blue = nums.Length - 1;
            for(int i = 0; i <= blue; i++){
                if(nums[i] == 0){
                    Swap(nums, i, red);
                    red++;
                }
                if(nums[i] == 2){
                    Swap(nums, i, blue);
                    // after swap, i could be 0
                    i--;
                    blue--;
                }
            }        
        }
        void Swap(int[] nums, int x, int y){
            int tmp = nums[x];
            nums[x] = nums[y];
            nums[y] = tmp;
        }
    }
}
