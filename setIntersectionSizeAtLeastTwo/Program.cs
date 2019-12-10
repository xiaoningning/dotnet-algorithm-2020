public class Solution {
    public int IntersectionSizeTwo(int[][] intervals) {
        // sorted by end, if end is same, reverse start sort
        // => reverse start sort to min S size
        Array.Sort(intervals, (a,b) => (a[1] == b[1] ? b[0] - a[0] : a[1] - b[1]));
        // intervals [1,3000]
        var v = new List<int>(){-1,-1}; // init for calculation
        foreach (var interval in intervals) {
            int len = v.Count;
            // overlap 2
            if (interval[0] <= v[len - 2]) continue;
            // no overlapping
            // min size of S with intersectin size 2 
            // => interval end - 1
            if (interval[0] > v.Last()) v.Add(interval[1] - 1);
            v.Add(interval[1]);
        }
        Console.WriteLine(string.Join(",",v));
        return v.Count - 2;   
    }
}
