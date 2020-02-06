public class Solution {
    public int MakeConnected(int n, int[][] connections) {
        // not enough connections
        if (connections.Length < n - 1) return -1;
        int[] roots = new int[n];
        for (int i = 0; i < n; i++) roots[i] = i;
        foreach(var c in connections)
            roots[FindRoot(roots, c[0])] = FindRoot(roots, c[1]);
        var commonRoots = new HashSet<int>();
        for (int i = 0; i < n; i++) commonRoots.Add(FindRoot(roots, i));
        // The number of operations = the number of connected networks - 1
        return commonRoots.Count - 1;
    }
    int FindRoot(int[] roots, int x) {
        return roots[x] == x ? x : FindRoot(roots, roots[x]); 
    }
}
