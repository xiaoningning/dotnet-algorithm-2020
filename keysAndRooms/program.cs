public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var dfs = new Stack<int>(); dfs.Push(0);
        var seen = new HashSet<int>(){0};
        while (dfs.Any()) {
            int i = dfs.Pop();
            foreach (int j in rooms[i])
                if (!seen.Contains(j)) {
                    dfs.Push(j);
                    seen.Add(j);
                    if (rooms.Count == seen.Count) return true;
                }
        }
        return rooms.Count == seen.Count;
    }
}
