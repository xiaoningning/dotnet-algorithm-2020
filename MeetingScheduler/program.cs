public class Solution {
    public IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration) {
        Array.Sort(slots1, (a,b) => a[0] - b[0]);
        Array.Sort(slots2, (a,b) => a[0] - b[0]);
        int i = 0,  j = 0, n1 = slots1.Length, n2 = slots2.Length;
        while (i < n1 && j < n2) {
            int start = Math.Max(slots1[i][0], slots2[j][0]);
            int end = Math.Min(slots1[i][1], slots2[j][1]);
            if (start + duration <= end) return new List<int>(){start, start+duration};
            if (slots1[i][1] < slots2[j][1]) i++;
            else j++;
        }
        return new List<int>();
    }
}
