public class Solution 
{
    // mod is used to restrict the hash to fit 32 bit
    long mod = (long) 1 << 32;
    int b = 26; // lower case base
    int n;
    int[] nums;
     public string LongestDupSubstring(string S)
    {
        n = S.Length;
        nums = new int[n];
		// ASCII codes of characters in string are used to create rolling hash
        for (int i = 0; i < n; i++) nums[i] = S[i] - 'a';
        
        int l = 1;
        int r = n;        
        int[] ans = new int[2] {-1, -1};
        // binary search by length of the substring     
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            int res = search(m);
            if (res != -1) 
            {
                ans[0] = res;
                ans[1] = m;
                l = m + 1;
            }
            else r = m - 1;                
        }
        return ans[0] != -1 ? S.Substring(ans[0], ans[1]) : "";
    }
    int search(int L)
    {
        long hash = 0;
        for (int i = 0; i < L; i++) hash = (hash * b + nums[i]) % mod;
        var seen = new HashSet<long>();
        seen.Add(hash);
        long bL = 1;
        for (int i = 1; i < L; i++) bL = (bL * b) % mod;
        // start from the 1th of nums
        for (int start = 1; start < n - L + 1; start++)
        {
            // update hash to remove the first character
            hash -= nums[start - 1] * bL;
            // update hash to add new character to the end
            hash = (hash * b + nums[start + L - 1]) % mod;
            if (seen.Contains(hash)) return start;
            else seen.Add(hash);
        }
        return -1;
    }    
}

public class Solution1 {
    int n;
    int[] A;
    int b = 26; // only low char
    long mod = 1 << 63 - 1; // 64 bit
    public string LongestDupSubstring(string S) {
        n = S.Length;
        A = new int[n];
        for (int i = 0; i < n; i++) A[i] = S[i] -'a';
        int res = -1, l = 1, r = n, k = 0;
        // binary search len
        while (l <= r) {
            int mid = l + (r - l) / 2;
            int pos = TestDup(mid);
            if (pos >= 0) {
                l = mid + 1;
                k = mid;
                res = pos;
            }
            else r = mid - 1;
        }
        // O(NlogN)
        return res >= 0 ? S.Substring(res, k) : "";
    }
    int TestDup(int len) {
        var seen = new HashSet<long>();
        long p = (long)Math.Pow(26, len) % mod; // prime number
        long hash = 0;
        for (int i = 0; i < len; i++) hash = (hash * b + A[i]) % mod;
        long bL = 1;
        for (int i = 1; i < len; i++) bL = (bL * b) % mod;
        seen.Add(hash);
        for (int i = len; i < n; i++) {
            hash -= (A[i - len] * bL) % mod;
            hash = (hash * b + A[i]) % mod;
            if (seen.Contains(hash)) return i - len + 1;
            else seen.Add(hash);
        }
        return -1;
    }
}
