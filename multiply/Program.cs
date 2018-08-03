using System;
using System.Text;

namespace multiply
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("multiply : {0}", obj.Multiply("123", "45"));
        }
    }
    public class Solution {
        // num1[i] * num2[j] will be placed at indices [i + j, i + j + 1] 
        public string Multiply(string num1, string num2) {
            int n1 = num1.Length, n2 = num2.Length;
            int[] pos = new int[n1 + n2];
            for(int i = n1 - 1; i >= 0; i--) {
                for(int j = n2 - 1; j >= 0; j--) {
                    int mul = (num1[i] - '0') * (num2[j] - '0'); 
                    int p1 = i + j, p2 = i + j + 1;
                    int sum = mul + pos[p2];

                    pos[p1] += sum / 10;
                    pos[p2] = (sum) % 10;
                }
            }

            StringBuilder sb = new StringBuilder();  
            foreach(int p in pos){
                // ignore the first 0
                if (!(p == 0 && sb.Length == 0)) sb.Append(p.ToString());
            }
            return sb.Length == 0 ? "0" : sb.ToString();
        }
    }
}
