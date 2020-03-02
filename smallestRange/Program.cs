public class Solution {
    public int[] SmallestRange(IList<IList<int>> nums) {
        int k = nums.Count;
        List<List<int>> q = new List<List<int>>();            
        for (int i = 0; i < k; i++) {
            foreach (int n  in nums[i]) q.Add(new List<int>(){n, i});
        }
        q.Sort((a,b) => a[0].CompareTo(b[0]));
        int cnt = 0, left = 0, diff = Int32.MaxValue;
        int[] res = new int[2];
        int[] map = new int[k];
        for (int i = 0; i < q.Count; i++){
            if(map[q[i][1]]++ == 0) ++cnt;
            while (cnt == k && left <= i) {
                if (diff > q[i][0] - q[left][0]) {
                    diff = q[i][0] - q[left][0];
                    res = new int[]{q[left][0], q[i][0]};
                }
                if (--map[q[left++][1]] == 0) --cnt;
            }
        }
        return res;
    }
}
