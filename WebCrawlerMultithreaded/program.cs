/**
 * // This is the HtmlParser's API interface.
 * // You should not implement it, or speculate about its implementation
 * class HtmlParser {
 *     public List<String> GetUrls(String url) {}
 * }
 */
    
class Solution {
    public IList<string> Crawl(string startUrl, HtmlParser htmlParser) {
        var hostname = startUrl.Split("/")[2];
        var current = new List<string> { startUrl };
        var visited = new HashSet<string> { startUrl };
        while (current.Any()) {
            var next = new List<string>();
            System.Threading.Tasks.Parallel.ForEach(current, 
                x => {
                var urls = htmlParser.GetUrls(x).Where(u => u.Contains(hostname)).ToList(); 
                lock(next) {
                    foreach (string url in urls) {
                        if (!visited.Contains(url)) {
                            visited.Add(url);
                            next.Add(url);
                        }
                    }
                }
            });
            current = next;
        }
        return visited.ToList();
    }
}
