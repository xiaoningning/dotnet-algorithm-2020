public class Solution {
    public int NumJewelsInStones(string J, string S) {
        int res = 0;
        HashSet<char> m = new HashSet<char>();
        foreach (var c in J) m.Add(c);
        foreach (var c in S) if (m.Contains(c)) res++;
        return res;
    }
}
