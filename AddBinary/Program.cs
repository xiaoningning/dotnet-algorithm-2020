using System;

namespace AddBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("add binary {0}", obj.AddBinary("1101", "11"));
        }
    }
    public class Solution {
        public string AddBinary(string a, string b) {
            string res = "";
            int m = a.Length - 1, n = b.Length - 1, carry = 0;
            while (m >= 0 || n >= 0) {
                int p = m >= 0 ? a[m--] - '0' : 0;
                int q = n >= 0 ? b[n--] - '0' : 0;
                int sum = p + q + carry;
                //sum is higher bit, res is lower bit
                res = sum % 2 + res; 
                carry = sum / 2;
            }
            return carry == 1 ? "1" + res : res;
        }
    }
}
