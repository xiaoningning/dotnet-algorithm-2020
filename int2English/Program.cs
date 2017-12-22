using System;
// using System.Collections.Generic;

namespace int2English
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input num: {0}", args[0]);
            int num = Int32.Parse(args[0]); 
            Console.WriteLine("result: {0}", NumberToWords(num));
        }
        
        static string[] s1 = new string[]{"Thousand", "Million", "Billion"};
        static string[] s2 = new string[]{"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        static string[] s3 = new string[]{"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
        
        static string NumberToWords(int num) {
            string res = ConvertHundred(num % 1000);
            for (int i = 0; i < 3; ++i) {
                num /= 1000;
                res = num % 1000 > 0 ? ConvertHundred(num % 1000) + " " + s1[i] + " " + res : res;
            }
            return string.IsNullOrEmpty(res) ? "Zero" : res.Trim();
        }

        static string ConvertHundred(int num) {
            string res;
            int a = num / 100, b = num % 100, c = num % 10;
            res = b < 20 ? s2[b] : s3[b / 10] + (c > 0 ? " " + s2[c] : "");
            
            if (a > 0) {
                res = s2[a] + " Hundred" + (b > 0 ? " " + res : "");
            }
            
            return res;
        }
    }
}
