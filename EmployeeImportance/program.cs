/*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public IList<int> subordinates;
}
*/

class Solution {
    public int GetImportance(IList<Employee> employees, int id) {
        var res = 0;
        var m = new Dictionary<int, Employee>();
        foreach (var e in employees) m[e.id] = e;
        var q = new List<int>(){id};
        while (q.Any()) {
            var t = q.First();
            res += m[t].importance;
            q.RemoveAt(0);
            foreach (var eid in m[t].subordinates) q.Add(eid);
        }
        return res;
    }
}
