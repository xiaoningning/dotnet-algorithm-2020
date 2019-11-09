public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if (!intervals.Any()) return 0;
        Array.Sort(intervals, (a,b) => (a[0] - b[0]));
        int res = 0, last = 0; 
        for (int i = 1; i < intervals.Length; i++) {
            if (intervals[i][0] < intervals[last][1]) {
                res++;
                // remove the larger end => remove less overall
                if (intervals[i][1] < intervals[last][1]) last = i;
            }
            else last = i;
        }
        return res;
    }
}
