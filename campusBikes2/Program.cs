public class Solution {
    int res = Int32.MaxValue;
    public int AssignBikes(int[][] workers, int[][] bikes) {
        dfs(0, workers, 0, bikes, 0);
        return res;
    }
    
    void dfs(int taken, int[][] workers, int i, int[][] bikes, int dis) {
        if (i == workers.Length) {
            res = Math.Min(res, dis);
            return;
        }
        if (dis > res) return;
        for (int j = 0; j < bikes.Length; j++) {
            // bitmask taken used as visted[]
            if ((taken & 1 << j) == 1 << j) continue;
            taken |= 1 << j;
            dfs(taken, workers, i + 1, bikes, dis + GetDis(bikes[j], workers[i]));
            taken &= ~(1 << j);
        }
    }
        
    int GetDis(int[] p1, int[] p2) {
        return Math.Abs(p1[0] - p2[0]) + Math.Abs(p1[1] - p2[1]);
    }
}
