public class Solution {
    public int CharacterReplacement(string s, int k) {
        int[] m = new int[26];
        int res = 0, i = 0, cnt = 0;
        for (int j = 0; j < s.Length; j++) {
            cnt = Math.Max(cnt, ++m[s[j]-'A']);
            while (j - i + 1 - cnt > k) {
                m[s[i]-'A']--;
                i++;
            }
            res = Math.Max(res, j - i + 1);
        }
        return res;
    }
}
