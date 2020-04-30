public class Solution {
    public bool IsRectangleCover(int[][] rectangles) {
        var st = new HashSet<string>();
        int mnx = Int32.MaxValue, mny = Int32.MaxValue, mxx = Int32.MinValue, mxy = Int32.MinValue, area = 0;
        foreach (var r in rectangles) {
            mnx = Math.Min(mnx, r[0]);
            mny = Math.Min(mny, r[1]);
            mxx = Math.Max(mxx, r[2]);
            mxy = Math.Max(mxy, r[3]);
            area += (r[2] - r[0]) * (r[3] - r[1]);
            string s1 = r[0]+","+r[1]; // bottom left
            string s2 = r[0]+","+r[3]; // top left
            string s3 = r[2]+","+r[3]; // top right
            string s4 = r[2]+","+r[1]; // bottm right
            // remove overlapped point
            if (!st.Add(s1)) st.Remove(s1);
            if (!st.Add(s2)) st.Remove(s2);
            if (!st.Add(s3)) st.Remove(s3);
            if (!st.Add(s4)) st.Remove(s4);
        }
        string t1 = mnx+","+mny; // bottom left
        string t2 = mnx+","+mxy; // top left
        string t3 = mxx+","+mxy; // top right
        string t4 = mxx+","+mny; // bottm right
        if (!st.Contains(t1) 
            || !st.Contains(t2) 
            || !st.Contains(t3) 
            || !st.Contains(t4) 
            || st.Count != 4)
            return false;
        return area == (mxx - mnx) * (mxy - mny);
    }
}
