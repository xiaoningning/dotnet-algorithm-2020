public class Solution {
    public int ReachNumber(int target) {
        // step is the same for target or -target
        target = Math.Abs(target);
        int step = 0;
        int sum = 0;
        while (sum < target) {
            step++;
            sum += step;
        }
        /*
        For ith move, if we switch the right move to the left, 
        the change in summation will be 2*i less.
        the difference between sum and target has to be an even number 
        in order for the math to check out.
        */
        while ((sum - target) % 2 != 0) {
            step++;
            sum += step;
        }
        return step;
    }
}
