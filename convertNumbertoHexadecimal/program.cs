public class Solution {
    string map = "0123456789abcdef";
    public string ToHex(int num) {
        if(num == 0) return "0";
        int cnt = 0;
        String res = "";
        // cnt not over int32 boundary
        while(num != 0 && cnt++ < 8){
            res = map[(num & 15)] + res; 
            num = (num >> 4);
        }
        return res == "" ? "0" : res;;
    }
}
