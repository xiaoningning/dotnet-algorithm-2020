public class Solution {
    public bool CanConstruct(string s, int k) {
        if (k > s.Length)  return false;
        var cnt = new int[26];
        int odd = 0;
        foreach (var c in s) cnt[c -'a']++;
        foreach (var n in cnt) { 
            if (n > 0 && n % 2 != 0) odd++;
        }
        return k >= odd;
    }
}
