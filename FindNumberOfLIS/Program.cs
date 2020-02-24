public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        int res = 0, maxLength = 0;
        int length = nums.Length;
        int[] len = new int[length], cnt = new int[length];
        for (int i = 0; i < length; i++){
            len[i] = 1;
            cnt[i] = 1;
        }
        for (int i = 0; i < nums.Length; i++){
            for (int j = 0; j < i; j++){
                if (nums[i] > nums[j]){
                    // num[j] is part of seq with num[i]
                    if (len[i] == len[j] + 1) cnt[i] += cnt[j]; 
                    else if (len[i] < len[j] + 1) // new sequence
                    {
                       len[i] = len[j] + 1;
                       cnt[i] = cnt[j];
                    }
                }                    
            }
            maxLength = Math.Max(len[i], maxLength);
        }
        for (int i = 0; i <  nums.Length; ++i) {
            if (maxLength == len[i]) res += cnt[i];
        }
        return res;
    }
}
