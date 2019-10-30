public class Solution {
    public int SubarraysWithKDistinct(int[] A, int K) {
        int n = A.Length, res = 0;
        // 1 <= A[i] <= A.length
        // can use array for map
        // int[] m = new int[n+1];
        var m = new Dictionary<int, int>();
        // precnt is cnt of K when left is moving
        for (int i = 0, left = 0, precnt = 0; i < n; i++) {
            if (!m.ContainsKey(A[i])) m.Add(A[i],0);
            m[A[i]]++;
            if (m.Count > K) {
                if (--m[A[left]] == 0) m.Remove(A[left]);
                // reset precnt since cnt > K
                left++; precnt = 0;
            }
            // A[i] can be duplicate
            while (m[A[left]] > 1) {
                if (--m[A[left]] == 0) m.Remove(A[left]);
                left++; precnt++;
            }
            // precnt + itself
            if (m.Count == K) res += precnt + 1;
        }
        return res;
    }
}
