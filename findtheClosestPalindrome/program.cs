public class Solution {
    public string NearestPalindromic(string n) {
        int len = n.Length; 
        // use long in case overflow
        long num = Int64.Parse(n), res = 0, minDiff = Int64.MaxValue;
        var s = new HashSet<long>();
        // if len is 3, range is [99, 1001]
        s.Add((long)Math.Pow(10, len) + 1);
        s.Add((long)Math.Pow(10, len - 1) - 1);
        // left half since closest integer
        long prefix = Int64.Parse(n.Substring(0, (len + 1) / 2));
        // i = 0 then it might be itself.
        for (long i = -1; i <= 1; ++i) {
            string pre = (prefix + i).ToString();
            // reverse left half for palindrome
            var t = pre.Substring(0, pre.Length - (len % 2)).ToCharArray();
            Array.Reverse(t);
            string str = pre + new string(t);
            s.Add(Int64.Parse(str));
        }
        s.Remove(num); // try to remove itself
        foreach (var a in s) {
            long diff = Math.Abs(a - num);
            if (diff < minDiff) {
                minDiff = diff;
                res = a;
            } else if (diff == minDiff) {
                res = Math.Min(res, a);
            }
        }
        return res.ToString();
    }
}
