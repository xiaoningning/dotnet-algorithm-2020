public class Solution {
    public int LongestPalindrome(string s) {
        HashSet<char> m = new HashSet<char>();
        foreach (char c in s) {
            if (!m.Contains(c)) m.Add(c);
            else m.Remove(c);
        }
        // allow max of 1 odd char
        return s.Length - Math.Max(0, m.Count() -1);
    }
}
