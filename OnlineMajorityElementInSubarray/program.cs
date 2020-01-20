public class MajorityChecker {
    Dictionary<int, List<int>> m = new Dictionary<int, List<int>>();
    public MajorityChecker(int[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            if (!m.ContainsKey(arr[i])) m.Add(arr[i], new List<int>());
            m[arr[i]].Add(i);
        }
    }
    
    public int Query(int left, int right, int threshold) {
        foreach (var kv in m) {
            if (kv.Value.Count < threshold) continue;
            int l = BinarySearchLowerBound(kv.Value.ToArray(), left);
            int r = BinarySearchUpperBound(kv.Value.ToArray(), right);
            if (r - l + 1 >= threshold) return kv.Key;
        }
        return -1;
    }
    
    int BinarySearchLowerBound(int[] a, int t) {
        int  l = 0, r = a.Length;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (a[m] < t) l = m + 1;
            else r = m;
        }
        return l;
    }
    
    int BinarySearchUpperBound(int[] a, int t) {
        int  l = 0, r = a.Length;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (a[m] <= t) l = m + 1;
            else r = m;
        }
        return l - 1;
    }
}

/**
 * Your MajorityChecker object will be instantiated and called as such:
 * MajorityChecker obj = new MajorityChecker(arr);
 * int param_1 = obj.Query(left,right,threshold);
 */
