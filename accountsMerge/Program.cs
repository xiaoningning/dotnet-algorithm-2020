using System;
using System.Collections.Generic;
using System.Linq;

namespace accountsMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> accounts = new List<List<string>>();
            accounts.Add(new List<string>(new string[]{"John", "johnsmith@mail.com", "john00@mail.com"}));
            accounts.Add(new List<string>(new string[]{"John", "johnnybravo@mail.com"}));
            accounts.Add(new List<string>(new string[]{"John", "johnsmith@mail.com", "john_newyork@mail.com"}));
            accounts.Add(new List<string>(new string[]{"Mary", "mary@mail.com"}));
            var merged = AccountsMergeUnion(accounts);
            foreach(var ac in merged){
                Console.WriteLine(string.Join(",", ac));
            }            
        }
        static IList<IList<string>> AccountsMerge(List<List<string>> accounts) {
            
            /*
            List<List<string>> accounts = new List<List<string>>();
            foreach(var acc in accs){
                List<string> t = new List<string>();
                foreach(var a in acc ){
                    t.Add(a);
                }
                accounts.Add(t);
            }
            */
            List<List<string>> res = new List<List<string>>();
            // email to account index mapping
            Dictionary<string, List<int>> emailsToAccounts = new Dictionary<string, List<int>>();
            
            for (int n = 0; n < accounts.Count; n++)
            {
                for(int i = 1; i < accounts[n].Count; i++){
                    if (emailsToAccounts.ContainsKey(accounts[n][i])){
                        emailsToAccounts[accounts[n][i]].Add(n);
                    }
                    else
                    {
                        emailsToAccounts.Add(accounts[n][i], new List<int>(){n});
                    }
                }                
            }

            // 0: not visited; 1: visited
            // key is the account index
            Dictionary<int, int> visited = new Dictionary<int, int>();
            for (int i = 0; i < accounts.Count; ++i){
                if( visited.ContainsKey(i) && visited[i] != 0) continue;
                SortedSet<string> setEmails = new SortedSet<string>();
                Queue<int> indexAccQueue = new Queue<int>();
                indexAccQueue.Enqueue(i);
                while (indexAccQueue.Count != 0)
                {
                    int indexAcc = indexAccQueue.Dequeue();
                    for (int e = 1; e < accounts[indexAcc].Count; e++ )
                    {                        
                        var email = accounts[indexAcc][e];                        
                        setEmails.Add(email);
                        foreach(var n in emailsToAccounts[email])
                        {
                            if( visited.ContainsKey(n) && visited[n] != 0) continue;
                            else 
                            {
                                visited[n] = 1;
                                indexAccQueue.Enqueue(n);
                            }
                        }           
                    }                    
                }
                List<string> newAcc = new List<string>();
                newAcc.Add(accounts[i][0]);
                newAcc.AddRange(setEmails);
                res.Add(newAcc);
            }
            IList<IList<string>> ires = new List<IList<string>>();
            foreach(var re in res){
                IList<string> t = new List<string>();
                foreach(var r in re){
                    t.Add(r);    
                }
                ires.Add(t);
            }
            return ires;
        }

        static List<List<string>> AccountsMerge1(List<List<string>> accounts) {
            
            List<List<string>> res = new List<List<string>>();
            // email to account index mapping
            Dictionary<string, List<int>> emailsToAccounts = new Dictionary<string, List<int>>();
            
            for (int n = 0; n < accounts.Count; n++)
            {
                for(int i = 1; i < accounts[n].Count; i++){
                    if (emailsToAccounts.ContainsKey(accounts[n][i])){
                        emailsToAccounts[accounts[n][i]].Add(n);
                    }
                    else
                    {
                        emailsToAccounts.Add(accounts[n][i], new List<int>(){n});
                    }
                }                
            }

            // 0: not visited; 1: visited
            // key is the account index
            Dictionary<int, int> visited = new Dictionary<int, int>();
            for (int i = 0; i < accounts.Count; ++i){
                if( visited.ContainsKey(i) && visited[i] != 0) continue;
                SortedSet<string> setEmails = new SortedSet<string>();
                Queue<int> indexAccQueue = new Queue<int>();
                indexAccQueue.Enqueue(i);
                while (indexAccQueue.Count != 0)
                {
                    int indexAcc = indexAccQueue.Dequeue();
                    foreach(var email in accounts[indexAcc].GetRange(1, accounts[indexAcc].Count - 1))
                    {                        
                        setEmails.Add(email);
                        foreach(var n in emailsToAccounts[email])
                        {
                            if( visited.ContainsKey(n) && visited[n] != 0) continue;
                            else 
                            {
                                visited[n] = 1;
                                indexAccQueue.Enqueue(n);
                            }
                        }           
                    }                    
                }
                List<string> newAcc = new List<string>();
                newAcc.Add(accounts[i][0]);
                newAcc.AddRange(setEmails);
                res.Add(newAcc);
            }
           
            return res;
        }

        static List<List<string>> AccountsMergeUnion(List<List<string>> acts){
            Dictionary<string, string> owner = new Dictionary<string, string>();
            Dictionary<string, string> parents = new Dictionary<string, string>();
            Dictionary<string, SortedSet<string>> unions = new Dictionary<string, SortedSet<string>>();

            foreach (List<String> a in acts) {
                for (int i = 1; i < a.Count; i++) {
                    parents[a[i]] = a[i];
                    owner[a[i]] = a[0];
                }
            }
            foreach (List<string> a in acts) {
                string p = find(a[1], parents);
                for (int i = 2; i < a.Count; i++)
                    parents[find(a[i], parents)] = p;
            }
            foreach (List<string> a in acts) {
                string p = find(a[1], parents);
                if (!unions.ContainsKey(p)) unions[p] = new SortedSet<string>();
                for (int i = 1; i < a.Count; i++)
                    unions[p].Add(a[i]);
            }
            List<List<string>> res = new List<List<string>>();
            foreach (string p in unions.Keys) {
                List<string> emails = unions[p].ToList();
                emails.Insert(0, owner[p]);
                res.Add(emails);
            }
            return res;
        }

        static string find(string s, Dictionary<string, string> p) {
            return p[s] == s ? s : find(p[s], p);
        }
    }
}

public class Solution {
    // union find
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        var res = new List<IList<string>>();
        var root = new Dictionary<string, string>();
        var owner = new Dictionary<string, string>();
        var m = new Dictionary<string, SortedSet<string>>();
        foreach (var account in accounts) {
            for (int i = 1; i < account.Count(); ++i) {
                root[account[i]] = account[i];
                owner[account[i]] = account[0];
            }
        }
        // update root
        foreach (var account in accounts) {
            string p = find(account[1], root);
            for (int i = 2; i < account.Count; ++i) {
                root[find(account[i], root)] = p;
            }
        }
        foreach (var account in accounts) {
            for (int i = 1; i < account.Count(); ++i) {
                var p = find(account[i], root);
                if (!m.ContainsKey(p)) m.Add(p, new SortedSet<string>());
                m[p].Add(account[i]);
            }
        }
        foreach (var a in m) {
            var t = a.Value.ToList();
            t.Insert(0, owner[a.Key]);
            res.Add(t);
        }
        return res;
    }
    
    string find(string s, Dictionary<string, string> root) {
        return root[s] == s ? s : find(root[s], root);
    }
    
    //DFS
    public IList<IList<string>> AccountsMerge1(IList<IList<string>> accs) {
        List<List<string>> accounts = new List<List<string>>();

        foreach(var acc in accs){
            List<string> t = new List<string>();
            foreach(var a in acc ){
                t.Add(a);
            }
            accounts.Add(t);
        }
        List<List<string>> res = new List<List<string>>();
        // email to account index mapping
        Dictionary<string, List<int>> emailsToAccounts = new Dictionary<string, List<int>>();

        for (int n = 0; n < accounts.Count; n++)
        {
            for(int i = 1; i < accounts[n].Count; i++){
                if (emailsToAccounts.ContainsKey(accounts[n][i])){
                    emailsToAccounts[accounts[n][i]].Add(n);
                }
                else
                {
                    emailsToAccounts.Add(accounts[n][i], new List<int>(){n});
                }
            }                
        }

        // 0: not visited; 1: visited
        // key is the account index
        Dictionary<int, int> visited = new Dictionary<int, int>();
        for (int i = 0; i < accounts.Count; ++i){
            if( visited.ContainsKey(i) && visited[i] != 0) continue;
            SortedSet<string> setEmails = new SortedSet<string>();
            Queue<int> indexAccQueue = new Queue<int>();
            indexAccQueue.Enqueue(i);
            while (indexAccQueue.Count != 0)
            {
                int indexAcc = indexAccQueue.Dequeue();
                for (int e = 1; e < accounts[indexAcc].Count; e++ )
                {                        
                    var email = accounts[indexAcc][e];
                    setEmails.Add(email);
                    foreach(var n in emailsToAccounts[email])
                    {
                        if( visited.ContainsKey(n) && visited[n] != 0) continue;
                        else 
                        {
                            visited[n] = 1;
                            indexAccQueue.Enqueue(n);
                        }
                    }           
                }                    
            }
            List<string> newAcc = new List<string>();
            newAcc.Add(accounts[i][0]);
            foreach(var eml in setEmails){
                newAcc.Add(eml);    
            }                
            res.Add(newAcc);
        }
        IList<IList<string>> ires = new List<IList<string>>();
        foreach(var re in res){
            IList<string> t = new List<string>();
            foreach(var r in re){
                t.Add(r);    
            }
            ires.Add(t);
        }
        return ires;
    }
}
