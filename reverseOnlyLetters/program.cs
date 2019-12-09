public class Solution {
    public string ReverseOnlyLetters(string S) {
        int n = S.Length, i = 0, j = n - 1;
        var arr = S.ToCharArray();
        while (i < j) {
            if (!Char.IsLetter(S[i])) ++i;
            else if (!Char.IsLetter(S[j])) --j;
            else {
                swap(arr, i, j);
                ++i; --j;
            }
        }
        return new string(arr);
    }
    void swap(char[] a, int i, int j) {
        var t = a[i]; a[i] = a[j]; a[j] = t;
    }
}
