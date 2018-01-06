using System;

namespace maxSwap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("num array: {0}", args[0]);
            int num = Int32.Parse(args[0]);
            Console.WriteLine("max swap: {0}", MaximumSwap(num));
        }

        static int MaximumSwap(int num) {
            string numString = num.ToString();
            int length = numString.Length;
            int[] pos = new int[10];
            for (int i = 0; i < length; i++)
            {   
                pos[numString[i] -'0'] = i;
            }

            for (int i = 0; i < length; i++)
            {   
                for (int k = 9; k > numString[i] - '0'; --k) {
                    if (pos[k] > i) {
                        return Int32.Parse(swapString(numString, i, pos[k]));                        
                    }                    
                }
            }
            return num;
        }

        static string swapString(string str, int i, int j){
            char[] arr = str.ToCharArray();
            char t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
            return new string(arr);
        }
    }

}
