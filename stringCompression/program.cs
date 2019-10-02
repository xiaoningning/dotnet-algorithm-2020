public class Solution {
    public int Compress(char[] chars) {
        int n = chars.Length, cur = 0;
        for (int i = 0, j = 0; i < n; i = j ) {
            while (j < n && chars[i] == chars[j]) j++;
            chars[cur++] = chars[i];
            if (j - i == 1) continue;
            foreach (char c in (j - i).ToString()) chars[cur++] = c;
        }
        return cur;
    }
}
