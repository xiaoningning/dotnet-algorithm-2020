public class Solution {
    public bool CanTransform1(string start, string end) {
        int n = start.Length, i = 0, j = 0;
        while (i < n && j < n) {
            while (i < n && start[i] == 'X') ++i;
            while (j < n && end[j] == 'X') ++j;
            if (i == n && j == n) return true;
            if (i == n || j == n) return false;
            if (start[i] != end[j]) return false;
            // L can only move left
            // R can only moe right
            if ((start[i] == 'L' && i < j) || (start[i] == 'R' && i > j)) return false;
            ++i; ++j;
        }
        return true;
    }
    public bool CanTransform(string start, string end) {
        int n = start.Length, cntr = 0, cntl = 0;
        for (int i = 0; i < n; i++) {
            if (start[i] == 'R') cntr++;
            if (end[i] == 'L') cntl++;
            if (end[i] == 'R') cntr--;
            if (start[i] == 'L') cntl--;
            if (cntl < 0 || cntr < 0 || cntl * cntr != 0) return false;
        }
        return cntr == 0 && cntl == 0;
    }
}
