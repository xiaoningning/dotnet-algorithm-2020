public class Solution {
    int[] map = new int[26];
    public bool IsAlienSorted(string[] words, string order) {
        for (int i = 0; i < order.Length; i++) map[order[i] - 'a'] = i;
        for (int i = 1; i < words.Length; i++) {
            if (Compare(words[i-1], words[i]) > 0) return false;
        }
        return true;
    }
    int Compare(string x, string y) {
        int n = x.Length, m = y.Length, cmp = 0;
        for (int i = 0, j = 0; i < n && j < m && cmp == 0; i++, j++) {
            cmp = map[x[i] - 'a'] - map[y[j] - 'a'];
        }
        return cmp == 0 ? n - m : cmp;
    }
}
