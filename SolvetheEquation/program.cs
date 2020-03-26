public class Solution {
    public string SolveEquation(string equation) {
        int idx = equation.IndexOf('='), a = 0, b = 0;
        helper(equation.Substring(0, idx), false, ref a, ref b);
        helper(equation.Substring(idx + 1), true, ref a, ref b);
        if (a == 0 && a != b) return "No solution";
        if (a == 0 && a == b) return "Infinite solutions";
        return "x=" + (-b/a);
    }
    void helper(string e, bool isLeft, ref int a, ref int b) {
        int sign = 1, n = -1; // never -1 => -x;
        e += '+'; // for last num
        for (int i = 0; i < e.Length; i++) {
            if (e[i] == 'x') {
                n = (n == -1) ? sign : n * sign;
                a += isLeft ? -n : n;
                n = -1;
            }
            else if (e[i] == '+' || e[i] == '-') {
                n = (n == -1) ? 0 : n * sign;
                b += isLeft ? -n : n;
                n = -1;
                sign = e[i] == '+' ? 1 : -1;
            }
            else if (e[i] >= '0' || e[i] <= '9') { 
                n = n == -1 ? 0 : n;
                n = n * 10 + e[i] - '0';
            }
            // Console.WriteLine($"{a}, {b}");
        }
    }
}
