public class Solution {
    public string AddStrings(string num1, string num2) {
        string res = "";
        int carry = 0;
        // carry == 1 for the last bit result
        for (int i = num1.Length - 1, j = num2.Length - 1; 
            i >= 0 || j >= 0 || carry == 1; 
            i--,j--) {
            int x = i < 0 ? 0 : num1[i] - '0';
            int y = j < 0 ? 0 : num2[j] - '0';
            res = (x + y + carry) % 10 + res;
            carry = (x + y + carry) / 10;
        }
        return res;
    }
    public string AddStrings1(string num1, string num2) {
        string res = "";
        int carry = 0, i = num1.Length - 1, j = num2.Length - 1;
        while (i >= 0 || j >= 0) {
            int a = i >= 0 ? num1[i--] - '0' : 0;
            int b = j >= 0 ? num2[j--] - '0' : 0;
            int sum = a + b + carry;
            res = res.Insert(0, (sum % 10).ToString());
            carry = sum / 10;
        }
        return carry == 1 ? "1" + res : res;
    }
}
