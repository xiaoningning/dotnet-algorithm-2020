public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        int res = 0;
        double cur = 0;
        var m = new SortedDictionary<int, double>();
        for (int i = 0; i < position.Length; i++) {
            if (!m.ContainsKey(position[i])) m.Add(-position[i], 0);
            m[-position[i]] = (double)(target - position[i]) / speed[i];
        }
        foreach (var kv in m) {
            if (kv.Value <= cur) continue;
            cur = kv.Value;
            res++;
        }
        return res;
    }
}
