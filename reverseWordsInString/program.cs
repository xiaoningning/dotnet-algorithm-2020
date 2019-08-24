public class Solution {
    public string ReverseWords(string s) {
        var c = s.ToCharArray();
        int left = 0, n = c.Length;
        Reverse(c, 0, n - 1);
        for (int i = 0; i <= n; ++i) {
            if (i == n || c[i] == ' ') {
                Reverse(c, left, i - 1);
                left = i + 1;
            }
        }
        // start and end can have space
        // only a single space inbetween words is ok
        return CleanSpaces(c, n);
    }
    void Reverse(char[] str, int l, int r) {
        while (l < r) {
            var t = str[l];
            str[l] = str[r];
            str[r] = t;
            l++;
            r--;
        }
    }
    
    // trim leading, trailing and multiple spaces
    string CleanSpaces(char[] a, int n) {
        int i = 0, j = 0;
        while (j < n) {
          while (j < n && a[j] == ' ') j++;             // skip spaces
          while (j < n && a[j] != ' ') a[i++] = a[j++]; // keep non spaces
          while (j < n && a[j] == ' ') j++;             // skip spaces
          if (j < n) a[i++] = ' ';                      // keep only one space
        }
        return new string(a).Substring(0, i);
    }
}
