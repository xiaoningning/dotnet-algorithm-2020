public class Solution {
    public IList<string> RemoveComments(string[] source) {
        var res = new List<string>();
        bool comment = false;
        string o = "";
        foreach (string line in source) {
            for (int i = 0; i < line.Length; i++) {
                if (!comment) {
                    if (i == line.Length - 1) o += line[i];
                    else {
                        string t = line.Substring(i, 2);
                        if (t == "/*") {
                            comment = true;
                            ++i; // 2 chars, ++ here
                        }
                        else if (t == "//") break;
                        else o += line[i];
                    }
                }
                else {
                    if (i < line.Length - 1) {
                        string t = line.Substring(i, 2);
                        if (t == "*/") { 
                            comment = false;
                            ++i; // 2 chars, ++ here
                        }
                    }
                }
            }
            if (!comment && o != "") {
                res.Add(o);
                o = "";
            }
        }
        return res;
    }
}
