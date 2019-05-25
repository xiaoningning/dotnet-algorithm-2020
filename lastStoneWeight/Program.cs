public class Solution {
    public int LastStoneWeight(int[] stones) {
        // 1 <= stones[i] <= 1000
        var m = new int [1001];
        foreach (var s in stones) m[s]++;
        int i = 1000, j;
        while (i > 0) {
            if (m[i] == 0) {
                i--;
                continue;
            }
            else {
                // several the same weights
                m[i] = m[i] % 2;
                if (m[i] == 0) continue;
                // only one m[i]
                j = i - 1;
                while (j > 0 && m[j] == 0) j--;
                if (j == 0) return i;
                m[i - j]++;
                m[j]--;
                m[i]--;
            }
        }
        return 0;
    }
}
