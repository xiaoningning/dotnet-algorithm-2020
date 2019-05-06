public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        var res = new List<string>();
        int n = nums.Length;
        int i = 0;
        while (i < n) {
            int j = 1;
            while (i + j < n && nums[i+j] - nums[i] == j) j++;
            string range = (j <= 1) ? nums[i].ToString() : nums[i].ToString() + "->"+ nums[i+j-1].ToString();
            res.Add(range);
            i += j;
        }
        return res;
    }
}
