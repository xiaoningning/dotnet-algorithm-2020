public class Solution {
    public IList<string> WordSubsets(string[] A, string[] B) {
        var res = new List<string>();
        int[] charCnt = new int[26];
        foreach (var b in B) {
            var cnt = new int[26];
            foreach (var c in b) cnt[c - 'a']++;
            for (int i = 0; i < 26; i++) charCnt[i] = Math.Max(charCnt[i], cnt[i]);
        }
        foreach (var a in A) {
            var cnt = new int[26];
            foreach (var c in a) cnt[c - 'a']++;
            int i = 0;
            for (; i < 26; ++i) {
                // if cnt[i] >= charCnt[i]
                // c of a is in very b of B
                if (cnt[i] < charCnt[i]) break;
            }
            if (i == 26) res.Add(a);
        }
        return res;
    }
}
