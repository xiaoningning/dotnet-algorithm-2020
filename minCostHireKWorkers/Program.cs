public class Solution {
    public double MincostToHireWorkers(int[] q, int[] w, int K) {
        var workers = new List<List<double>>();
        for (int i = 0; i < q.Length; ++i)
            workers.Add(new List<double>(){(double)(w[i]) / q[i], (double)q[i]});
        workers.Sort((a, b) => a[0].CompareTo(b[0]));
        double res = Double.MaxValue, qsum = 0;
        var pq = new List<Double>();
        foreach (var worker in workers) {
            qsum += worker[1];
            pq.Add(-worker[1]); // reverse order
            pq.Sort();
            if (pq.Count > K) {
                qsum += pq.First(); // -worker[1]
                pq.RemoveAt(0);
            }
            if (pq.Count == K) res = Math.Min(res, qsum * worker[0]);
        }
        return res;
    }
}
