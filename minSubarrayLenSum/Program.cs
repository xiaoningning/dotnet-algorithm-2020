public class Solution {
    
    public int MinSubArrayLen(int s, int[] nums) {
        int n = nums.Length;
        int[] sums = new int[n+1];
        int res = Int32.MaxValue;
        for(int i = 1; i < n+1 ; i++){
            sums[i] = sums[i-1] + nums[i-1];            
        }
        // all nums must be positive for this approach
        for(int i = 0; i < n; i++){
            int left = i + 1, right = n;
            while(left <= right){
                int mid = left + (right - left) / 2;
                if (sums[mid] - sums[i] < s) left = mid + 1;
                else right = mid - 1;
            }
            if (left == n + 1) break;
            // for min, as left as possible
            res = Math.Min(res, left - i);
        }
        return res == Int32.MaxValue ? 0 : res;
    }
    
    public int MinSubArrayLen1(int s, int[] nums) {
        int sum = 0, left = 0;
        int res = Int32.MaxValue;
        // check 862 
        // s must be all positive for slide window 
        for(int i = 0; i< nums.Length; i++){
            sum += nums[i];
            while(left <= i && sum >= s){
                res = Math.Min(res, i - left + 1);
                sum -= nums[left++];
            }
        }
        return res == Int32.MaxValue ? 0 : res;
    }
}
