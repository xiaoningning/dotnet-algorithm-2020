public class Solution {
    public int PathSum(int[] nums) {
        if (!nums.Any()) return 0;
        int res = 0;
        var m = new Dictionary<int, int>();
        var q = new Queue<int>();
        q.Enqueue(nums[0] / 10);
        foreach (int num in nums) {
            m[num / 10] = num % 10;
        }
        while (q.Any()) {
            int t = q.Dequeue();
            int level = t / 10, pos = t % 10;
            int left = (level + 1) * 10 + 2 * pos - 1, right = left + 1;
            if (!m.ContainsKey(left) && !m.ContainsKey(right))
                res += m[t]; // leave
            if (m.ContainsKey(left)) {
                m[left] += m[t];
                q.Enqueue(left);
            }
            if (m.ContainsKey(right)) {
                m[right] += m[t];
                q.Enqueue(right);
            }   
        }
        return res;
    }
}
