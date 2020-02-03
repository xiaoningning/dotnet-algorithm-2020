public class Solution {
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) {
        var found = new int[status.Length];
        var q = new Queue<int>();
        foreach (var b in initialBoxes) {
            found[b] = 1;
            if (status[b] == 1) {
                q.Enqueue(b);
            }
        }
        int res = 0;
        while (q.Any()) {
            int b = q.Dequeue();
            res += candies[b];
            foreach (var k in keys[b]) {
                // only add previous found but no key box
                if (status[k] == 0 && found[k] == 1) q.Enqueue(k);
                status[k] = 1;
            }
            // contained boxes has no duplicated in box[b]
            foreach (var t in containedBoxes[b]) {
                found[t] = 1;
                if (status[t] == 1) {
                    q.Enqueue(t);
                }
            }
            
        }
        return res;
    }
}
