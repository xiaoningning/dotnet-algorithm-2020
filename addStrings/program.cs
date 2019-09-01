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
            res += (x + y + carry) % 10;
            carry = (x + y + carry) / 10;
        }
        var arr = res.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
