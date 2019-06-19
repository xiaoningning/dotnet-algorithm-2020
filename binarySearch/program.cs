public class Solution {
    /*
    第一处是right的初始化，可以写成 nums.size() 或者 nums.size() - 1
    第二处是left和right的关系，可以写成 left < right 或者 left <= right
    第三处是更新right的赋值，可以写成 right = mid 或者 right = mid - 1
    第四处是最后返回值，可以返回left，right，或right - 1
    但是这些不同的写法并不能随机的组合，像博主的那种写法，
    若right初始化为了nums.size()，那么就必须用left < right，而最后的right的赋值必须用 right = mid。
    但是如果我们right初始化为 nums.size() - 1，那么就必须用 left <= right，并且right的赋值要写成 right = mid - 1，不然就会出错。
    所以博主的建议是选择一套自己喜欢的写法，并且记住，实在不行就带简单的例子来一步一步执行，确定正确的写法也行。
    */
    public int BinarySearch(list<int> nums, int target) {
        int left = 0, right = nums.Count;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target) return mid;
            else if (nums[mid] < target) left = mid + 1;
            else right = mid;
        }
        return -1;
    }
}
