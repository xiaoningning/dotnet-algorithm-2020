public class Solution {
    public string RemoveDuplicates(string S) {
        var res = new Stack<char>();
        foreach (var c in S){  
            if (res.Any() && c == res.Peek())
                res.Pop();
            else
                res.Push(c);
        }
        var a = res.ToArray();
        Array.Reverse(a);
        return new string(a);
    }
}
