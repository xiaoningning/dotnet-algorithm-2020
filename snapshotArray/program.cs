public class SnapshotArray {
    List<Dictionary<int,int>> a;
    int sid;
    public SnapshotArray(int length) {
        sid = 0;
        a = new List<Dictionary<int,int>>();
        for (int i = 0; i < length; i++) {
            a.Add(new Dictionary<int,int>());
        }
    }
    
    public void Set(int index, int val) {
        if (a[index].Any() && a[index].ContainsKey(sid)) {
            a[index][sid] = val;
        }
        else a[index].Add(sid, val);
    }
    
    public int Snap() {
        return sid++;
    }
    
    public int Get(int index, int snap_id) {
        // lower bound idx of snap_id if it is not there.
        while (snap_id >= 0) {            
            if (a[index].ContainsKey(snap_id)) {
                return a[index][snap_id];
            } 
            snap_id--;
        } 
        return 0;        
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */
