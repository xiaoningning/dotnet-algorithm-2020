using System;

namespace rangeQuerySum_Mutable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{1, 3, 5};
            NumArray obj = new NumArray(nums);
            Console.WriteLine("sum range 0,2 :{0}", obj.SumRange(0, 2));
            obj.Update(1,2);
            Console.WriteLine("sum range 0,2 after update:{0}", obj.SumRange(0, 2));            
        }
    }
    public class NumArray {
        int[] d = new int[]{};
        int len = 0;
        int[] block = new int[]{};
        public NumArray(int[] nums) {
            d = nums;
            len = Math.Ceil(d.Length / Math.Sqrt(d.Length));
            block = new int[len];
            for (int i = 0; i < d.Length; ++i) {
                block[i / len] += d[i];
            }
        }
        public void Update(int i, int val) {
            int idx = i / len;
            block[idx] += val - d[i];
            d[i] = val;
        }
        public int SumRange(int i, int j) {
            int sum = 0;
            int start = i / len, end = j / len;
            if (start == end) {
                for (int k = i; k <= j; ++k) {
                    sum += d[k];
                }
                return sum;
            }
            for (int k = i; k < (start + 1) * len; ++k) {
                sum += d[k];
            }
            for (int k = start + 1; k < end; ++k) {
                sum += block[k];
            }
            for (int k = end * len; k <= j; ++k) {
                sum += d[k];
            }
            return sum;
        }
    }

    public class NumArray2 {
        int[] d = new int[]{};
        public void NumArray(int[] nums) {
            d = nums;
        }
        public void Update(int i, int val) {
            d[i] = val;
        }
        public int SumRange(int i, int j) {
            int sum = 0;
            for (int k = i; k <= j; ++k) {
                sum += d[k];
            }
            return sum;
        }
    }
    public class NumArray1 {
        /*
        * BIT[] as a binary index tree:
        *            ______________*
        *            ______*
        *            __*     __*
        *            *   *   *   *
        * indices: 0 1 2 3 4 5 6 7 8
        * B1 = A1
        * B2 = A1 + A2
        * B3 = A3
        * B4 = A1 + A2 + A3 + A4
        * B5 = A5
        * B6 = A5 + A6
        * B7 = A7
        * B8 = A1 + A2 + A3 + A4 + A5 + A6 + A7 + A8
        * 
        * BIT[1]=a[0], 
        * BIT[2]=a[1]+BIT[1]=a[1]+a[0], 
        * BIT[3]=a[2],
        * BIT[4]=a[3]+BIT[3]+BIT[2]=a[3]+a[2]+a[1]+a[0],
        * BIT[5]=a[4]
        * BIT[6]=a[5]+BIT[5]=a[5]+a[4],
        * BIT[7]=a[6]
        * BIT[8]=a[7]+BIT[7]+BIT[6]+BIT[4]=a[7]+a[6]+...+a[0],
        * 
        * The index needs to be updated as (i & (-i)) as the last bit of 1 of i.
        * Index           Bit           last bit of 1
        * 1               0001          1
        * 2               0010          2
        * 3               0011          1
        * 4               0100          4
        * 5               0101          1
        * 6               0110          2
        * 7               0111          1
        * 8               1000          8
        */
        
        int[] BIT;
        int n;
        int[] nums;
        public void NumArray(int[] nums) {
            this.nums = nums;
            n = nums.Length;
            BIT = new int[n+1];
            for (int i = 0; i < n; i++){
                initBIT(i, nums[i]);
            }
        }
        void initBIT(int i, int num){
            for(int j = i+1; j <= n; j += (j & (-j))){
                BIT[j] += num;
            }
        }
        
        public void Update(int i, int val) {
            int diff = val - this.nums[i];
            initBIT(i, diff);
            nums[i] = val;
        }
        public int getSum(int i) {
            int sum = 0;
            for(int j = i+1; j > 0; j -= (j & (-j))) {
                sum += BIT[j];
            }
            return sum;
        }
        public int SumRange(int i, int j) {
            return getSum(j) - getSum(i-1);
        }
    }
}
