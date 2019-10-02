public class Solution {
    public bool CanMeasureWater(int x, int y, int z) {
        // z = m * x + n * y
        // z = k * d, d = gcd(x,y)
        // x = 3, y = 5, z = 4
        // 2 * 5 + (-2) * 3 = 4
        return z == 0 || (x + y >= z && z % gcd(x, y) == 0);
    }
    
    int gcd(int a, int b) {
        return a == 0 ? b : gcd(b % a, a);
    }
}
