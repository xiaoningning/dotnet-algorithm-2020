public class Solution {
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
        Dictionary<int, int> m = new Dictionary<int, int>();
        int res = 0;
        foreach (int a in A) {
            foreach (int b in B) {
                if (!m.ContainsKey(a + b)) m.Add(a + b ,0);
                m[a+b]++;
            }
        }
        
        foreach (int c in C) {
            foreach (int d in D) {
                int t = -1 * (c + d);
                if (m.ContainsKey(t)) res += m[t];                
            }
        }
        return res;
    }
}
