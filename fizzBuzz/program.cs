public class Solution {
    public IList<string> FizzBuzz(int n) {
        var res = new List<string>();
        for (int i = 1; i <= n; i++) {
            // mod 15 first, since it can be mod 5 or 3
            if (i % 15 == 0) res.Add("FizzBuzz");
            else if (i % 3 == 0) res.Add("Fizz");
            else if (i % 5 == 0) res.Add("Buzz");
            else res.Add(i.ToString());
        }
        return res;
    }
}
