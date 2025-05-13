using System.Text
public class Array
{
    public List<List<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

        foreach (string str in strs)
        {
            int[] counts = new int[26];
            foreach (char c in str)
            {
                counts[c - 'a']++;
            }
            StringBuilder keyBuilder = new StringBuilder();
            for (int i = 0; i < 26; i++)
            {
                keyBuilder.Append('#');
                keyBuilder.Append(counts[i]);
            }

            string key = keyBuilder.ToString();

            if (!dict.ContainsKey(key))
            {
                dict[key] = new List<string>();
            }
            dict[key].Add(str);
        }

        return new List<List<string>>(dict.Values);
    }

    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (!dict.ContainsKey(num))
            {
                dict[num] = 0;
            }
            dict[num]++;
        }

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        foreach (KeyValuePair<int, int> pair in dict)
        {
            minHeap.Enqueue(pair.Key, pair.Value);
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        List<int> result = new List<int>();
        for (int i = 0; i < k; i++)
        {
            result.Add(minHeap.Dequeue());
        }
        return result.ToArray();
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        int[] res = new int[n];

        res[0] = 1;
        for (int i = 1; i < n; i++)
        {
            res[i] = res[i - 1] * nums[i - 1];
        }

        int postfix = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            res[i] *= postfix;
            postfix *= nums[i];
        }
        return res;
    }

    public bool IsValidSudoku(char[][] board)
    {
        Dictionary<int, HashSet<char>> hashRow = new Dictionary<int, HashSet<char>>();
        Dictionary<int, HashSet<char>> hashCol = new Dictionary<int, HashSet<char>>();
        Dictionary<int, HashSet<char>> hashGrid = new Dictionary<int, HashSet<char>>();

        for (int i = 0; i < board.Length; i++)
        {
            hashRow[i] = new HashSet<char>();
            hashCol[i] = new HashSet<char>();
            hashGrid[i] = new HashSet<char>();
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board.Length; j++)
            {
                if (board[i][j] == '.')
                {
                    continue;
                }
                if (!hashRow[i].Contains(board[i][j]))
                {
                    hashRow[i].Add(board[i][j]);
                }
                else
                {
                    return false;
                }
                if (!hashCol[j].Contains(board[i][j]))
                {
                    hashCol[j].Add(board[i][j]);
                }
                else
                {
                    return false;
                }
                int gridIndex = (i / 3) * 3 + (j / 3);
                if (!hashGrid[gridIndex].Contains(board[i][j]))
                {
                    hashGrid[gridIndex].Add(board[i][j]);
                }
                else
                {
                    return false;
                }
            }
        }
        return true;
    }
}
