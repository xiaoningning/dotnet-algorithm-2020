public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        var m = new Dictionary<int, int>();
        foreach (var n in arr) m[n] = m.GetValueOrDefault(n, 0) + 1;
        return new HashSet<int>(m.Values).Count == new HashSet<int>(m.Keys).Count;
    }
}
