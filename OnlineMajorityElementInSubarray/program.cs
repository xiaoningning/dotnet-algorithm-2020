public class MajorityChecker {
    Dictionary<int, List<int>> m = new Dictionary<int, List<int>>();
    int[] a;
    public MajorityChecker(int[] arr) {
        a = arr;
        for (int i = 0; i < arr.Length; i++) {
            if (!m.ContainsKey(arr[i])) m.Add(arr[i], new List<int>());
            m[arr[i]].Add(i);
        }
    }
    
    public int Query(int left, int right, int threshold) {
        foreach (var kv in m) {
            if (kv.Value.Count < threshold) continue;
            int cnt = 0;
            foreach (int i in kv.Value)  {
                if (i >= left && i <= right) cnt++;
            }
            if (cnt >= threshold) return kv.Key;
        }
        return -1;
    }
}

/**
 * Your MajorityChecker object will be instantiated and called as such:
 * MajorityChecker obj = new MajorityChecker(arr);
 * int param_1 = obj.Query(left,right,threshold);
 */
