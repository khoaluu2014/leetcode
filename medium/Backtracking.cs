public class Backtracking
{
    public List<List<int>> Subsets(int[] nums)
    {
        List<int> subset = new List<int>();
        List<List<int>> res = new List<List<int>>();

        void dfs(int i)
        {
            if (i >= nums.Length)
            {
                res.Add(new List<int>(subset));
                return;
            }

            subset.Add(nums[i]);
            dfs(i + 1);
            subset.RemoveAt(subset.Count - 1);
            dfs(i + 1);
        }
        dfs(0);

        return res;
    }

    public List<List<int>> CombinationSum(int[] nums, int target)
    {
        List<List<int>> res = new List<List<int>>();
        void dfs(int i, List<int> cur, int total)
        {
            if (total == target)
            {
                res.Add(new List<int>(cur));
                return;
            }
            if (total > target || i >= nums.Length)
            {
                return;
            }
            cur.Add(nums[i]);
            dfs(i, cur, total + nums[i]);
            cur.Remove(cur.Last());
            dfs(i + 1, cur, total);
        }

        dfs(0, new List<int>(), 0);
        return res;
    }

    public List<List<int>> SubsetsWithDup(int[] nums)
    {
        List<int> subset = new List<int>();
        List<List<int>> res = new List<List<int>>();

        Array.Sort(nums);

        void dfs(int start)
        {
            res.Add(new List<int>(subset));
            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                {
                    continue;
                }
                subset.Add(nums[i]);
                dfs(i + 1);
                subset.RemoveAt(subset.Count - 1);
            }
        }

        dfs(0);
        return res;
    }

    public List<List<int>> CombinationSum2(int[] candidates, int target)
    {
        List<List<int>> res = new List<List<int>>();
        List<int> cur = new List<int>();
        Array.Sort(candidates);

        void dfs(int start, int total)
        {
            if (total == target)
            {
                res.Add(new List<int>(cur));
                return;
            }
            if (total > target)
            {
                return;
            }
            for (int i = start; i < candidates.Length; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1])
                {
                    continue;
                }
                cur.Add(candidates[i]);
                dfs(i + 1, total + candidates[i]);
                cur.RemoveAt(cur.Count - 1);
            }
        }

        dfs(0, 0);
        return res;
    }

    public bool Exist(char[][] board, string word)
    {
        int m = board.Length;
        int n = board[0].Length;

        bool dfs(int index, int i, int j)
        {
            if (i < 0 || j < 0 || i >= m || j >= n || board[i][j] != word[index])
            {
                return false;
            }
            if (index == word.Length - 1)
            {
                return true;
            }

            board[i][j] = '#';
            if (
                dfs(index + 1, i + 1, j)
                || dfs(index + 1, i - 1, j)
                || dfs(index + 1, i, j + 1)
                || dfs(index + 1, i, j - 1)
            )
            {
                return true;
            }

            board[i][j] = word[index];
            return false;
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == word[0])
                {
                    if (dfs(0, i, j))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
