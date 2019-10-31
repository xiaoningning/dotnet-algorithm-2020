public class Solution {
    public int SubarraysWithKDistinct(int[] A, int K) {
        // exactly k
        return atMostK(A, K) - atMostK(A, K - 1);
    }
    // LC340
    int atMostK(int[] s, int k) {
        var m = new Dictionary<int, int>();
        int res = 0, left = 0;
        for (int i = 0; i < s.Length; i++) {
            if (!m.ContainsKey(s[i])) m.Add(s[i],0);
            m[s[i]]++;
            while (m.Count() > k) {
                if (--m[s[left]] == 0) m.Remove(s[left]);
                ++left;
            }
            res += i - left + 1;
        }
        return res;
    }
    public int SubarraysWithKDistinct1(int[] A, int K) {
        int n = A.Length, res = 0;
        // 1 <= A[i] <= A.length
        // can use array for map
        // int[] m = new int[n+1];
        var m = new Dictionary<int, int>();
        // precnt is cnt of K when left is moving
        for (int i = 0, left = 0, precnt = 0; i < n; i++) {
            if (!m.ContainsKey(A[i])) m.Add(A[i],0);
            m[A[i]]++;
            while (m.Count > K) {
                if (--m[A[left]] == 0) m.Remove(A[left]);
                // reset precnt since cnt > K
                left++; precnt = 0;
            }
            // A[i] can be duplicate
            while (m[A[left]] > 1) {
                --m[A[left++]];
                precnt++;
            }
            // precnt + itself
            if (m.Count == K) res += precnt + 1;
        }
        return res;
    }
}
