public class Solution {
    public int FindSpecialInteger(int[] arr) {
        int n = arr.Length;
        var m = new Dictionary<int,int>();
        foreach (var a in arr) {
            m[a] = m.GetValueOrDefault(a,0) + 1;
            if (m[a] > n/4) return a;
        }
        return -1;
    }
    public int FindSpecialInteger1(int[] arr) {
        int n = arr.Length, g = n / 4;
        for (int i = g; i < n; i += g) {
            int first = FindFirst(arr, arr[i]);
            if (arr[i] == arr[first + g]) return arr[i];
        }
        return Int32.MinValue;
    }
    int FindFirst(int[] nums, int target) {
        int l = 0, r = nums.Length;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (nums[m] < target) l = m + 1;
            else r = m;
        }
        return l;
    }
}
