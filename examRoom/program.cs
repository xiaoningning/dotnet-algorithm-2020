public class ExamRoom {
    int n;
    HashSet<int> spots;
    public ExamRoom(int N) {
        n = N; spots = new HashSet<int>();
    }
    
    public int Seat() {
        // check 0 spot
        int idx = 0, pre = 0, mx = 0;
        // sorted seats and check
        foreach (int i in spots.OrderBy(s => s)) {
            if (pre == 0) {
                if (mx < i - pre) {
                    mx = i - pre;
                    idx = 0;
                }
            } else {
                if (mx < (i - pre + 1) / 2) {
                    mx = (i - pre + 1) / 2;
                    idx = pre + mx - 1;
                }
            }
            pre = i + 1;
        }
        // check n-1 spot
        if (pre > 0 && mx < n - pre) {
            mx = n - pre;
            idx = n - 1;
        }
        spots.Add(idx);
        return idx;
    }
    
    public void Leave(int p) {
        spots.Remove(p);
    }
}

/**
 * Your ExamRoom object will be instantiated and called as such:
 * ExamRoom obj = new ExamRoom(N);
 * int param_1 = obj.Seat();
 * obj.Leave(p);
 */
