public class Solution {
    public int[] AssignBikes(int[][] workers, int[][] bikes) {
        var disMap = new SortedDictionary<int, List<int[]>>();
        int n = workers.Length, m = bikes.Length;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                int dis = Math.Abs(workers[i][0]-bikes[j][0]) + Math.Abs(workers[i][1]-bikes[j][1]);
                if (!disMap.ContainsKey(dis)) disMap.Add(dis, new List<int[]>());
                disMap[dis].Add(new int[]{i, j});
            }
        }
        var res = new int[n];
        Array.Fill(res, -1);
        var bikeUsed = new bool[m];
        foreach (var d in disMap) {
            for (int k = 0; k < d.Value.Count; k++) {
                if (res[d.Value[k][0]] == -1 && !bikeUsed[d.Value[k][1]]) {
                    bikeUsed[d.Value[k][1]] = true;
                    res[d.Value[k][0]] = d.Value[k][1];
                }
            }
        }
        return res;
    }
}
