public class Solution {
    public int NumSubarraysWithSum(int[] A, int S) {
        int res = 0, sum = 0, left = 0, n = A.Length;
        for (int i = 0; i < n; i++) {
            sum += A[i];
            while (left < i && sum > S) sum -= A[left++];
            if (sum == S) {
                res++;
                // lead 0 case
                for (int j = left; j < i && A[j] == 0; j++) {
                    res++;
                } 
            }
        }
        return res;
    }
    public int NumSubarraysWithSum1(int[] A, int S) {
        int res = 0, sum = 0;
        var m = new Dictionary<int,int>();
        m.Add(0,1); // init as 1 when first time sum == s
        foreach (var n in A) {
            sum += n;
            res += m.GetValueOrDefault(sum - S, 0);
            if (!m.ContainsKey(sum)) m.Add(sum,0);
            m[sum]++;
        }
        return res;
    }
}
