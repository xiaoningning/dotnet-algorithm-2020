public class Solution {
    public string ShortestPalindrome(string s) {
        int i = 0, end = s.Length - 1, j = end;
        char[] arr = s.ToCharArray();
        while (i < j) {
            if (arr[i] == arr[j]) {
                ++i; --j;
            } 
            else {
                i = 0; --end; j = end;
            }
        }
        var t = s.Substring(end+1).ToCharArray();
        Array.Reverse(t);
        return new string(t) + s;
    }
}
