public class Solution {
    public string Multiply(string num1, string num2) {
        int m = num1.Length;
        int n = num2.Length;
        int[] res = new int[m + n];
        for (int i = m - 1; i >= 0; --i) {
            for (int j = n - 1; j >= 0; --j) {
                int mul = (num1[i] - '0') * (num2[j] - '0');
                int p1 = i + j, p2 = i + j + 1;
                int sum = mul + res[p2];
                res [p1] += sum / 10;
                res [p2] = sum % 10;
               
            }
        }
        string resStr = "";
        foreach (var v in res) {
            if (resStr != ""  || v != 0) resStr += v.ToString();
        }
        return resStr == "" ? "0" : resStr;
    }
}
