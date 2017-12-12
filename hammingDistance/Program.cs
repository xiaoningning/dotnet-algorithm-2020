using System;

namespace hammingDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input numbers 0 <= x, y <= 2^31" );
            Console.WriteLine("input numbers: {0}, {1}", args[0], args[1] );
            Console.WriteLine("Hamming Distance: {0}", 
                            HammingDistance(Int32.Parse(args[0]), Int32.Parse(args[1])));
        }

        public static int HammingDistance(int x, int y) {
            int dist = 0;
            
            for (int i = 0; i < 32; i++){
                dist += ((x >> i) ^ (y >> i)) & 1;
            }

            return dist;
        }
        public static int HammingDistance1(int x, int y) {
            int dist = 0;
            int xor = x ^ y;
            
            while(xor > 0){
                dist += xor & 1;
                xor = xor >> 1 ;
            }
            return dist;
        }
    }
}
