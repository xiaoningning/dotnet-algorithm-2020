public class Solution {
    // chunk split i = max of elements of chunk
    public int MaxChunksToSorted1(int[] arr) {
        int res = 0, mx = 0, n = arr.Length;
        for (int i = 0; i < n; i++) {
            mx = Math.Max(mx, arr[i]);
            if (i == mx) res++;
        }
        return res;
    }
    
    public int MaxChunksToSorted(int[] arr) {
        int res = 0, mx = 0, n = arr.Length;
        for (int i = 0; i < n; i++) {
            int cur = arr[i], j = i + 1;
            for (; j <= cur; j++) {
                cur = Math.Max(cur, arr[j]);
                if (cur >= arr.Last()) return res + 1;
            }
            i = j - 1; // remove extra j++
            res++;
        }
        return res;
    }
}
