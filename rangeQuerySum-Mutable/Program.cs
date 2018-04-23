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
    public NumArray(int[] nums) {
        this.nums = nums;
        n = this.nums.Length;
        BIT = new int[n+1];
        for (int i = 0; i < n; i++){
            initBIT(i, this.nums[i]);
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
        this.nums[i] = val;
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

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(i,val);
 * int param_2 = obj.SumRange(i,j);
 */
}
