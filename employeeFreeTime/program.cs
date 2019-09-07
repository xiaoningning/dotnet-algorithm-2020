/*
// Definition for an Interval.
public class Interval {
    public int start;
    public int end;

    public Interval(){}
    public Interval(int _start,int _end) {
        start = _start;
        end = _end;
}
*/
public class Solution {
    public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule) {
        var res = new List<Interval>();
        var v = new List<Interval>();
        foreach (var s in schedule) v.AddRange(s);
        v.Sort((a,b) => a.start - b.start);
        var t = v[0];
        foreach (var i in v) {
            // free > 1, so it can not be <=
            if (t.end < i.start) {
                res.Add(new Interval(t.end, i.start));
                t = i;
            }    
            else {
                t = (t.end > i.end) ? t : i;
            }
        }
        
        return res;
    }
}
