public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        int s1 = numerator >= 0 ? 1 : -1;
        int s2 = denominator >= 0 ? 1 : -1;
        var num = (ulong) Math.Abs((long)numerator);
        var den = (ulong) Math.Abs((long)denominator);
        var res = num / den;
        var rem = num % den;
        var str = res.ToString();
        if (s1 * s2 == -1 && (res > 0 || rem > 0)) str = "-" + str;
        if (rem == 0) return str;
        str += ".";
        var s = "";
        var m = new Dictionary<ulong, int>();
        int p = 0;
        while (rem > 0) {
            if (m.ContainsKey(rem)) {
                s = s.Insert(m[rem], "(");
                s += ")";
                return str + s;
            }
            m[rem] = p;
            s += (rem * 10 / den).ToString();
            rem = rem * 10 % den;
            p++;
        }
        return str + s;
    }
}
