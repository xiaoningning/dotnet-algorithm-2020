public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        var res = new List<string>();
        var m = new Dictionary<string, List<string>>();
        foreach(var t in tickets) {
            if (!m.ContainsKey(t[0])) m.Add(t[0], new List<string>());
            m[t[0]].Add(t[1]);
        }
        foreach(var kv in m) kv.Value.Sort();
        var st = new Stack<string>();
        st.Push("JFK");
        while (st.Any()) {
            var t = st.Peek();
            if (m.ContainsKey(t) && m[t].Any()) {
                st.Push(m[t].First());
                m[t].RemoveAt(0);
            }
            else {
                res.Insert(0,t);
                st.Pop();
            }
        }
        return res;
    }
}
