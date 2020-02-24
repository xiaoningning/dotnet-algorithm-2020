public class Solution {
    public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people) {
        int n = req_skills.Length, m = people.Count;
        int target = 0;
        for (int i = 0; i < n; i++) target |= 1 << i;
        var dp = new Dictionary<int, List<int>>(); 
        dp.Add(0, new List<int>());
        for (int i = 0; i < m; i++) {
            int his_skill = 0;
            foreach (var s in people[i]) his_skill |= 1 << Array.IndexOf(req_skills, s);
            var keys = dp.Keys.ToList();
            foreach (var k in keys) {
                int with_skill = k | his_skill;
                if (with_skill == k) continue;
                if (!dp.ContainsKey(with_skill) || dp[with_skill].Count > dp[k].Count + 1) {
                    var nteam = dp[k].ToList();  // ToList create a new obj
                    nteam.Add(i);
                    dp[with_skill] = nteam; 
                }
            }
        }
        // O(people * 2^skill)
        return dp[target].ToArray();
    }
}
