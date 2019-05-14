public class Solution {
    Dictionary<string, Dictionary<string,double>> m = new Dictionary<string, Dictionary<string,double>>();
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        List<double> res = new List<double>();
        for (int i = 0; i < equations.Count(); i++) {
            if (!m.ContainsKey(equations[i][0])) m.Add(equations[i][0], new Dictionary<string,double>());
            if (!m.ContainsKey(equations[i][1])) m.Add(equations[i][1], new Dictionary<string,double>());
            m[equations[i][0]].Add(equations[i][1], values[i]);
            m[equations[i][1]].Add(equations[i][0], 1 / values[i]);
        }
        foreach (var q in queries) {
            if (!m.ContainsKey(q[0]) || !m.ContainsKey(q[1])) {
                res.Add(-1);
                continue;
            }
            HashSet<string> visited = new HashSet<string>();
            double t = Helper(q, visited);
            res.Add(t);
        }
        return res.ToArray();
    }
    double Helper(IList<string> q, HashSet<string> visited){
        if (m.ContainsKey(q[0]) && m[q[0]].ContainsKey(q[1])) return m[q[0]][q[1]];
        foreach (var kv in m[q[0]]) {
            if (visited.Contains(kv.Key)) continue;
            visited.Add(kv.Key);
            double t = Helper(new List<string>(){kv.Key, q[1]}, visited);
            if (t > 0) return t * kv.Value;
        }
        return -1.0;
    } 
}
