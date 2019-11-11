public class Solution {
    public int LengthLongestPath(string input) {
        int res = 0; 
        // +1 borader case input "a"
        int[] m = new int[input.Length+1];
        foreach (string s in input.Split('\n')) {
            // dirs idx of \t : -1
            int idx = s.LastIndexOf('\t') + 1;
            int len = s.Substring(idx).Length;
            if (s.Contains('.')) res = Math.Max(res, m[idx] + len);
            // pre \t idx length
            else m[idx+1] = m[idx] + len + 1;
        }
        return res;
    }
}
