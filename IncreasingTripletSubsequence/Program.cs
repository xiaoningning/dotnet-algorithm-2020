using System;

namespace IncreasingTripletSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{1,2,3,4,5};
            Console.WriteLine("IncreasingTriplet {0}", obj.IncreasingTriplet(nums));
            nums = new int[]{5,3,4,1};
            Console.WriteLine("IncreasingTriplet {0}", obj.IncreasingTriplet(nums));
        }
    }

    public class Solution {
        public bool IncreasingTriplet(int[] nums) {
            int n = nums.Length;
            int small = Int32.MaxValue;
            int big = Int32.MaxValue;
            for(int i = 0;  i < n; i++){
                // update small if n is smaller than both
                if (nums[i] <= small) small = nums[i];
                // update big only if greater than small but smaller than big
                else if (nums[i] <= big) big = nums[i];
                // find a number bigger than both
                else return true;            
            }        
            return false;
        }
        
        public bool IncreasingTriplet1(int[] nums) {
            int n = nums.Length;
            int[] forward = new int[n];
            int[] backward = new int[n];
            for(int i = 0;  i < n; i++){
                forward[i] = nums[0];
            }
            for(int i = 0; i < n; i++){
                backward[i] = nums[n-1];
            }
            for(int i = 1; i < n; i++){
                forward[i] = Math.Min(forward[i-1], nums[i]);
            }
            for(int i = n-2; i >= 0; i--){
                backward[i] = Math.Max(backward[i+1], nums[i]);;
            }
            for(int i = 0; i < n; i++){
                if( forward[i] < nums[i] && nums[i] < backward[i]) return true;
            }
            return false;
        }
    }
}
