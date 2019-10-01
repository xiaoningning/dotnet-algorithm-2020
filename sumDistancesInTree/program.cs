public class Solution {
    int[] res; // # of distance of subtree of i
    int[] cnt; // cnt of nodes of subtree of i
    List<HashSet<int>> tree;
    public int[] SumOfDistancesInTree(int N, int[][] edges) {
        res = new int[N]; cnt = new int[N];
        tree = new List<HashSet<int>>();
        for (int i = 0; i < N ; ++i)
            tree.Add(new HashSet<int>());
        for (int i = 0; i < edges.Length; i++) {
            tree[edges[i][0]].Add(edges[i][1]);
            tree[edges[i][1]].Add(edges[i][0]);
        }
        dfs(0, -1);
        dfs2(0, -1);
        return res;
    }
    void dfs(int root, int pre) {
        foreach (int i in tree[root]) {
            if (i == pre) continue;
            dfs(i, root);
            cnt[root] += cnt[i];
            res[root] += res[i] + cnt[i];
        }
        cnt[root]++;
    }  
    // all distances of outside subtree of i
    void dfs2(int root, int pre) {
        foreach (int i in tree[root]) {
            if (i == pre) continue;
            res[i] = res[root] - cnt[i] + cnt.Length - cnt[i];
            dfs2(i, root);
        }
    }
}
