public class ZigzagIterator {
    int i = 0;
    List<int> c = new List<int>();
    public ZigzagIterator(IList<int> v1, IList<int> v2) {
        int n1 = v1.Count, n2 = v2.Count, n = Math.Max(n1, n2);
        for (int j = 0; j < n; j++) {
            if (j < n1) c.Add(v1[j]);
            if (j < n2) c.Add(v2[j]);
        }
    }

    public bool HasNext() {
        return i < c.Count;
    }

    public int Next() {
        return c[i++];
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */
