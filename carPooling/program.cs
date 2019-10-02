public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        // meeting room
        var m = new SortedDictionary<int, int>();
        foreach (var t in trips) {
            if (!m.ContainsKey(t[1])) m.Add(t[1], 0);
            if (!m.ContainsKey(t[2])) m.Add(t[2], 0);
            m[t[1]] += t[0];
            m[t[2]] -= t[0];
        }
        foreach (var kv in m){
            capacity -= kv.Value;
            if (capacity < 0) return false;
        }
        return true;
    }
}
