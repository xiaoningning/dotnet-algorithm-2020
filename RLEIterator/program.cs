public class RLEIterator1 {
    int[] nums;
    int cur;
    public RLEIterator1(int[] A) {
        // use cur, no need to go through list every next call
        cur = 0; 
        nums = A;
    }
    
    public int Next1(int n) {
        while (cur < nums.Length && nums[cur] < n) {
            n -= nums[cur];
            cur += 2;
        }
        if (cur >= nums.Length) return -1;
        nums[cur] -= n;
        return nums[cur + 1];
    }
}

public class RLEIterator {
    List<int[]> seq = new List<int[]>();
    public RLEIterator(int[] A) {
        for (int i = 0; i < A.Length; i += 2)
            if (A[i] != 0) seq.Add(new int[]{A[i+1], A[i]});
    }
    
    public int Next(int n) {
        foreach (var p in seq) {
            if (p[1] == 0) continue;
            if (p[1] >= n) { 
                p[1] -= n;
                return p[0];
            }
            n -= p[1];
            p[1] = 0;
        }
        return -1;
    }
}

/**
 * Your RLEIterator object will be instantiated and called as such:
 * RLEIterator obj = new RLEIterator(A);
 * int param_1 = obj.Next(n);
 */
