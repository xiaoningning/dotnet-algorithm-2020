public class Solution {
    public string RemoveDuplicates(string s, int k) {
        int i = 0, n = s.Length;
        var count = new int[n];
        char[] stack = s.ToCharArray();
        for (int j = 0; j < n; ++j, ++i) {
            stack[i] = stack[j];
            count[i] = i > 0 && stack[i - 1] == stack[j] ? count[i - 1] + 1 : 1;
            if (count[i] == k) i -= k;
        }
        return new string(stack.ToArray(), 0, i);
    }
}
