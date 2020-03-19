public class Solution {
    public string Convert(string s, int numRows) {
        int n = s.Length, i = 0;
        var arr = new string[numRows];
        Array.Fill(arr, "");
        string res = "";
        while (i < n) {
            for(int pos = 0; pos < numRows && i < n; pos++) {
                arr[pos] += s[i++];
            }
            for(int pos = numRows - 2; pos >= 1 && i < n; pos--) {
                arr[pos] += s[i++];
            }
        }
        foreach (var a in arr) res += a;
        return res;
    }
}
