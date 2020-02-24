public class Solution {
    public int MakeArrayIncreasing(int[] arr1, int[] arr2) {
        Array.Sort(arr2);
        arr2 = new HashSet<int>(arr2).ToArray();
        int res = dfs(arr1, arr2, 0, 0, Int32.MinValue);
        return res > arr2.Length ? -1 : res;
    }
    int[,] dp = new int[2001,2001];
    int dfs(int[] a1, int[] a2, int i1, int i2, int prev) {
        if (i1 >= a1.Length) return 0;
        // If value is not found and value is 
        // less than one or more elements in array, 
        // the negative number returned is the bitwise complement of 
        // the index of the first element that is larger than value. 
        int idx = Array.BinarySearch(a2, prev);
        // binary serach upper bound
        i2 = idx < 0 ? ~idx : idx + 1;
        if (dp[i1, i2] != 0) return dp[i1,i2];
        int swap = i2 < a2.Length ? 1 + dfs(a1,a2, i1+1, i2, a2[i2]) : a2.Length + 1;
        int keep = prev < a1[i1] ? dfs(a1, a2, i1 + 1, i2, a1[i1]) : a2.Length + 1;
        return dp[i1, i2] = Math.Min(swap, keep);
    }
}
