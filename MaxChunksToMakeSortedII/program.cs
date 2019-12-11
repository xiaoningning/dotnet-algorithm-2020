public class Solution {
    // similar to partition Disjoint
    public int MaxChunksToSorted(int[] arr) {
        int res = 1, n = arr.Length;
        int[] f = new int[n], b = new int[n];
        Array.Copy(arr, f, n);
        Array.Copy(arr, b, n);
        for (int i = 1; i < n; ++i) f[i] = Math.Max(arr[i], f[i - 1]);   
        for (int i = n - 2; i >= 0; --i) b[i] = Math.Min(arr[i], b[i + 1]);
        for (int i = 0; i < n - 1; ++i) {
            if (f[i] <= b[i + 1]) ++res;
        }
        return res;
    }
    
    public int MaxChunksToSorted1(int[] arr) {
        var st = new Stack<int>();
        for (int i = 0; i < arr.Length; ++i) {
            if (!st.Any() || st.Peek() <= arr[i]) {
                st.Push(arr[i]);
            } else {
                int curMax = st.Pop();
                while (st.Any() && st.Peek() > arr[i]) st.Pop();
                st.Push(curMax);
            }
        }
        // st stores all divide element
        return st.Count;
    }
}
