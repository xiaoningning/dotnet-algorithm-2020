public class Solution {
    public string RemoveDuplicates1(string S) {
        var res = new Stack<char>();
        foreach (var c in S){  
            if (res.Any() && c == res.Peek()) res.Pop();
            else res.Push(c);
        }
        var a = res.ToArray();
        Array.Reverse(a);
        return new string(a);
    }
    public string RemoveDuplicates(string s) {
        int i = 0, n = s.Length;
        char[] res = s.ToCharArray();
        for (int j = 0; j < n; ++j, ++i) {
            res[i] = res[j];
            // count = 2, remove all adjacent
            if (i > 0 && res[i - 1] == res[i]) i -= 2;
        }
        return new string(res.ToArray(), 0, i);
     }
}
