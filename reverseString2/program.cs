public class Solution {
    public string ReverseStr(string s, int k) {
        var arr = s.ToCharArray();
        int i = 0, n = arr.Length;
        while (i < n) {
            int j = Math.Min(i + k - 1, n-1);
            swap(arr, i, j);
            i += 2*k;
        }
        return new string(arr);
    }
    void swap(char[] arr, int l, int r) {
        while (l < r) {
            char temp = arr[l];
            arr[l++] = arr[r];
            arr[r--] = temp;
        }
    }
}
