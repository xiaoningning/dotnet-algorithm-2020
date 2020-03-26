public class Solution {
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) {
        Array.Sort(arr2);
        int res  = 0;
        foreach (var n in arr1) {
            if (isValid(n, arr2, d)) res++;
        }
        // O(nlogn)
        return res;
    }
    bool isValid(int n, int[] arr, int d) {
        int l = 0, r = arr.Length;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (Math.Abs(n - arr[m]) <= d) return false;
            if (arr[m] < n) l = m + 1;
            else r = m;
        }
        return true;
    }
}
