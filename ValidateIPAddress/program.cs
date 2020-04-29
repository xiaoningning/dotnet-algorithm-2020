public class Solution {
    public string ValidIPAddress(string IP) {
        int cnt = 0;
        if (IP.IndexOf(":") == -1) {
            foreach (var t in IP.Split(".")) {
                cnt++;
                if (cnt > 4 || t.Length > 3 || (t.Length > 1 && t[0] == '0') || t == "") return "Neither";
                foreach (char c in t) if (c < '0' || c > '9') return "Neither";
                var val = Int32.Parse(t);
                if (val < 0 || val > 255) return "Neither";
            }
            return (cnt == 4 && IP.Last() != '.') ? "IPv4" : "Neither";
        }
        else {
            foreach (var t in IP.Split(":")) {
                cnt++;
                if (cnt > 8 || t.Length > 4 || t == "") return "Neither";
                foreach (char c in t) 
                    if (!(c >= '0' && c <= '9') 
                        && !(c >= 'a' && c <= 'f') 
                        && !(c >= 'A' && c <= 'F')) return "Neither";
            }
            return (cnt == 8 && IP.Last() != ':') ? "IPv6" : "Neither";
        }
    }
}
