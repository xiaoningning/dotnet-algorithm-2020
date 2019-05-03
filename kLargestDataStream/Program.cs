public class KthLargest {
    SortedDictionary<int, List<int>> q;
    int size;
    int cnt; // avoid to repeat counting q size
    public KthLargest(int k, int[] nums) {
        size = k;
        q = new SortedDictionary<int, List<int>>();
        foreach(var n in nums) Add(n);
    }
    
    public int Add(int val) {
        if (!q.ContainsKey(val)) q.Add(val, new List<int>());
        q[val].Add(val);
        cnt++;
        if (cnt > size) {
            var kv = q.First();
            if (kv.Value.Count == 1) q.Remove(kv.Key);
            else kv.Value.RemoveAt(0);
            cnt--;
        }
        return q.First().Key;
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
