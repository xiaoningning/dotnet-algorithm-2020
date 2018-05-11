using System;

namespace excelTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("Convert to Excel Title {0}", obj.ConvertToTitle(28));
        }
    }
    public class Solution {
        public string ConvertToTitle(int n) {
            string res = "";
            while( n > 0){
                if(n % 26 == 0){
                    res += 'Z';
                    n -= 26;
                }
                else{
                    // int to char
                    res += (char)('A' + (n % 26 - 1));
                    n -= n % 26;
                }
                n /= 26;
            }
            char[] array = res.ToCharArray();
            Array.Reverse(array);
            res = new string(array);
            return res;
        }
    }
}
