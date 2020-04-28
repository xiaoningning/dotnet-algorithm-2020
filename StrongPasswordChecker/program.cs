public class Solution {
    public int StrongPasswordChecker(string s) {
        int res = 0, n = s.Length, lower = 1, upper = 1, digit = 1;
        var cnt = new int[n];
        for (int i = 0; i < n;) {
            if (s[i] >= 'a' && s[i] <= 'z') lower = 0;
            if (s[i] >= 'A' && s[i] <= 'Z') upper = 0;
            if (s[i] >= '0' && s[i] <= '9') digit = 0;
            int j = i;
            while (i < n && s[i] == s[j]) ++i;
            cnt[j] = i - j;
        }
        int missing = lower + upper + digit;
        if (n < 6) {
            int diff = 6 - n;
            res += diff + Math.Max(0, missing - diff);
        } 
        else { 
            int left = 0, over = Math.Max(0, n - 20);
            res += over;
            // if cnt[i] = 3m + 2, replace m => min change
            for (int k = 1; k < 3; ++k) {
                for (int i = 0; i < n && over > 0; ++i) {
                    if (cnt[i] < 3 || cnt[i] % 3 != (k - 1)) continue;
                    cnt[i] -= Math.Min(over, k);
                    over -=k;
                }
            }
            for (int i = 0; i < n; i++) {
                if (cnt[i] >= 3 && over > 0) {
                    int removed = cnt[i] - 2;
                    cnt[i] -= over;
                    over -= removed;
                }
                if (cnt[i] >= 3) left += cnt[i] / 3;
            }
            res += Math.Max(missing, left);
        }
        return res;
    }
}
