public class Solution {
    int[] roots = new int[128];
    public bool EquationsPossible(string[] equations) {
        for (int i = 0; i < 128; i++) roots[i] = i;
        foreach (var e in equations)
            if (e[1] == '=') roots[FindRoot(e[0])] = FindRoot(e[3]);
        foreach (var e in equations)
            if (e[1] == '!' 
                && FindRoot(roots[e[0]]) == FindRoot(roots[e[3]])) 
                return false;
        return true;
    }
    int FindRoot(int x) {
        return x == roots[x] ? x : FindRoot(roots[x]);
    }
}
