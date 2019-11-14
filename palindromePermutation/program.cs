public class Solution {
    public bool CanPermutePalindrome(string s) {
        var st = new HashSet<char>();
        foreach (var c in s) {
            if (!st.Contains(c)) st.Add(c);
            else st.Remove(c);
        }
        return st.Count == 0 || st.Count == 1;
    }
}
