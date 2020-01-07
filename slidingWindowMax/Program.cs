public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        List<int> res = new List<int>();
        // store the index of max value
        // in the oder of max to smaller
        List<int> q = new List<int>();
        for (int i =0; i < nums.Length; i++) {
            // i shift to left more than k. out of k window
            // remove the first index of k window
            if (q.Any() && q[0] == i - k) q.RemoveAt(0);
            // remove index whose value < current i value
            while (q.Any() && nums[q.Last()] < nums[i]) q.RemoveAt(q.Count - 1);
            q.Add(i);
            if (i >= k - 1) res.Add(nums[q[0]]);
        }
        return res.ToArray();
    }
}
