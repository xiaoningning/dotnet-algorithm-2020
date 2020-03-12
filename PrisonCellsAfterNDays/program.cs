public class Solution {
    public int[] PrisonAfterNDays(int[] cells, int N) {
        var m = new Dictionary<string, int>();
        while (N > 0) {
            var c2 = new int[cells.Length];
            string stat = string.Join(",", cells);
            m[stat] = N--;
            for (int i = 1; i < cells.Length - 1; i++) 
                c2[i] = cells[i-1] == cells[i+1] ? 1 : 0;
            Array.Copy(c2, 0, cells, 0, c2.Length);
            stat = string.Join(",", cells);
            // keep state, it will be looped back;
            if (m.ContainsKey(stat)) N %= m[stat] - N;
        }
        return cells;
    }
}
