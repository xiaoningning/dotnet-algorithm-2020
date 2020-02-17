public class Solution {
    Dictionary<string, List<int>> m = new Dictionary<string, List<int>>();
    public IList<int> DiffWaysToCompute(string input) {
        if (m.ContainsKey(input)) return m[input];
        var res = new List<int>();
        for (int i = 0; i < input.Length; i++) {
            if (input[i] == '+' || input[i] == '-' || input[i] == '*') {
                var left = DiffWaysToCompute(input.Substring(0,i));
                var right = DiffWaysToCompute(input.Substring(i+1));
                for (int l = 0; l < left.Count; l++) {
                    for (int r = 0; r < right.Count; r++) {
                        if (input[i] == '+') res.Add(left[l] + right[r]);
                        if (input[i] == '-') res.Add(left[l] - right[r]);
                        if (input[i] == '*') res.Add(left[l] * right[r]);
                    }
                }
            }
        }
        if (!res.Any()) res.Add(Int32.Parse(input));
        m[input] = res;
        return res;
    }
}
