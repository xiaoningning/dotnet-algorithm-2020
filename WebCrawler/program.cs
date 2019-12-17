/**
 * // This is the HtmlParser's API interface.
 * // You should not implement it, or speculate about its implementation
 * class HtmlParser {
 *     public List<String> GetUrls(String url) {}
 * }
 */
class Solution {
    public IList<string> Crawl(string startUrl, HtmlParser htmlParser) {
        var st = new HashSet<string>();
        var q = new Queue<string>();
        var hostname = startUrl.Split("/")[2];
        st.Add(startUrl);
        q.Enqueue(startUrl);
        //BFS
        while (q.Any()) {
            var n = q.Dequeue();
            foreach (string url in htmlParser.GetUrls(n)) {
                if (url.Contains(hostname) && !st.Contains(url)) {
                    q.Enqueue(url);
                    st.Add(url);
                }
            }
        }
        return st.ToList();
    }
}
