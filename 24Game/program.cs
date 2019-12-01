public class Solution {
    bool res = false;
    double eps = 0.001;
    public bool JudgePoint24(int[] nums) {
        var l = new List<double>();
        foreach (int n in nums) l.Add((double)n);
        helper(l);
        return res;
    }
    void helper(List<double> l) {
        if (res) return;
        if (l.Count == 1){
            if (Math.Abs(l[0] - 24.0) < eps)
                res = true;
            return;
        }
        for (int i = 0; i < l.Count; i++) {
            for (int j = 0; j < i; j++) { 
                double p1 = l[i], p2 = l[j];
                var n = new List<double>(){p1+p2, p1-p2, p2-p1, p1*p2};
                if (Math.Abs(p2) > eps)  n.Add(p1/p2);
                if (Math.Abs(p1) > eps)  n.Add(p2/p1);
                var nl = new List<double>();
                for (int k = 0; k < l.Count; ++k) {
                    if (k != i && k != j) nl.Add(l[k]);
                }
                foreach (var num in n) {
                    nl.Add(num);
                    helper(nl);
                    nl.RemoveAt(nl.Count - 1);
                }
            }
        }
    }
}
