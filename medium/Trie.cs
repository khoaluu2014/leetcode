public class TrieNode
{
    public TrieNode()
    {
        childrenMap = new Dictionary<char, TrieNode>();
    }

    public void AddWords(string word)
    {
        TrieNode cur = this;

        foreach (char c in word)
        {
            if (!cur.childrenMap.ContainsKey(c))
            {
                cur.childrenMap[c] = new TrieNode();
            }
            cur = cur.childrenMap[c];
        }

        cur.isWord = true;
    }

    public Dictionary<char, TrieNode> childrenMap { get; set; }
    public bool isWord { get; set; }
}

public class PrefixTree
{
    private TrieNode root;

    public PrefixTree()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode cur = root;

        foreach (char c in word)
        {
            if (!cur.childrenMap.ContainsKey(c))
            {
                cur.childrenMap[c] = new TrieNode();
            }
            cur = cur.childrenMap[c];
        }
        cur.isWord = true;
    }

    public bool Search(string word)
    {
        TrieNode cur = root;

        foreach (char c in word)
        {
            if (!cur.childrenMap.ContainsKey(c))
            {
                return false;
            }
            cur = cur.childrenMap[c];
        }

        return cur.isWord;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode cur = root;

        foreach (char c in prefix)
        {
            if (!cur.childrenMap.ContainsKey(c))
            {
                return false;
            }
            cur = cur.childrenMap[c];
        }
        return true;
    }
}

public class WordDictionary
{
    private TrieNode root;

    public WordDictionary()
    {
        root = new TrieNode();
    }

    public void AddWord(string word)
    {
        TrieNode cur = root;

        foreach (char c in word)
        {
            if (!cur.childrenMap.ContainsKey(c))
            {
                cur.childrenMap[c] = new TrieNode();
            }
            cur = cur.childrenMap[c];
        }
        cur.isWord = true;
    }

    public bool Search(string word)
    {
        bool dfs(int j, TrieNode root)
        {
            TrieNode cur = root;
            for (int i = j; i < word.Length; i++)
            {
                char c = word[i];
                if (c == '.')
                {
                    foreach (TrieNode child in cur.childrenMap.Values)
                    {
                        if (dfs(i + 1, child))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    if (!cur.childrenMap.ContainsKey(c))
                    {
                        return false;
                    }
                    cur = cur.childrenMap[c];
                }
            }
            return cur.isWord;
        }
        return dfs(0, root);
    }
}

public class Find_Words
{
    TrieNode root = new TrieNode();

    public List<string> FindWords(char[][] board, string[] words)
    {
        HashSet<string> res = new HashSet<string>();
        HashSet<(int, int)> visit = new HashSet<(int, int)>();
        foreach (string w in words)
        {
            root.AddWords(w);
        }

        int ROWS = board.Length;
        int COLS = board[0].Length;

        void dfs(int r, int c, TrieNode node, string word)
        {
            if (
                r < 0
                || c < 0
                || r == ROWS
                || c == COLS
                || visit.Contains((r, c))
                || !node.childrenMap.ContainsKey(board[r][c])
            )
            {
                return;
            }
            visit.Add((r, c));
            node = node.childrenMap[board[r][c]];
            word += board[r][c];
            if (node.isWord)
            {
                res.Add(word);
            }

            dfs(r + 1, c, node, word);
            dfs(r - 1, c, node, word);
            dfs(r, c + 1, node, word);
            dfs(r, c - 1, node, word);

            visit.Remove((r, c));
        }

        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                dfs(i, j, root, "");
            }
        }

        return new List<string>(res);
    }
}
