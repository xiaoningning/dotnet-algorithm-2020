public class Solution {
    public int MyAtoi(string str) {
        int i = 0, sign = 1;
        while (i < str.Length && str[i] == ' ') i++;
        if (i < str.Length && (str[i] == '-' || str[i] == '+'))
            sign = str[i++] == '-' ? -1 : 1;
        int total = 0;
        while (i < str.Length && (str[i] >= '0' && str[i] <= '9')) {
            int d = str[i++] - '0';
            if (total > Int32.MaxValue / 10 
                || total == Int32.MaxValue / 10 && d > Int32.MaxValue % 10) 
                return sign == 1 ? Int32.MaxValue : Int32.MinValue;
            total = total * 10 + d;
            
        }
        return total * sign;
    }
}
