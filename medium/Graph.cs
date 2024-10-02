// Definition for a GraphNode.
public class GraphNode
{
    public int val;
    public IList<GraphNode> neighbors;

    public GraphNode()
    {
        val = 0;
        neighbors = new List<GraphNode>();
    }

    public GraphNode(int _val)
    {
        val = _val;
        neighbors = new List<GraphNode>();
    }

    public GraphNode(int _val, List<GraphNode> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Graph
{
    public int NumIslands(char[][] grid)
    {
        int count = 0;
        void dfs(int r, int c)
        {
            if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == '0')
            {
                return;
            }
            grid[r][c] = '0';
            dfs(r + 1, c);
            dfs(r - 1, c);
            dfs(r, c + 1);
            dfs(r, c - 1);
        }
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    dfs(i, j);
                    count++;
                }
            }
        }
        return count;
    }

    public int MaxAreaOfIsland(int[][] grid)
    {
        int count = 0;
        int max = 0;
        void dfs(int r, int c)
        {
            if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == 0)
            {
                return;
            }
            grid[r][c] = 0;
            count++;
            dfs(r + 1, c);
            dfs(r - 1, c);
            dfs(r, c + 1);
            dfs(r, c - 1);
        }
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    count = 0;
                    dfs(i, j);
                    max = Math.Max(max, count);
                }
            }
        }
        return max;
    }

    public GraphNode CloneGraph(GraphNode node)
    {
        Dictionary<GraphNode, GraphNode> oldToNew = new Dictionary<GraphNode, GraphNode>();
        GraphNode dfs(GraphNode node, Dictionary<GraphNode, GraphNode> oldToNew)
        {
            if (node == null)
            {
                return null;
            }

            if (oldToNew.ContainsKey(node))
            {
                return oldToNew[node];
            }

            GraphNode copy = new GraphNode(node.val);
            oldToNew[node] = copy;

            foreach (GraphNode nei in node.neighbors)
            {
                copy.neighbors.Add(dfs(nei, oldToNew));
            }

            return copy;
        }

        return dfs(node, oldToNew);
    }

    public void islandsAndTreasure(int[][] grid)
    {
        Queue<(int, int)> q = new Queue<(int, int)>();
        int ROW = grid.Length;
        int COL = grid[0].Length;

        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {
                if (grid[i][j] == 0)
                {
                    q.Enqueue((i, j));
                }
            }
        }

        if (q.Count == 0)
        {
            return;
        }

        int[][] dirs =
        {
            new int[] { 1, 0 },
            new int[] { -1, 0 },
            new int[] { 0, 1 },
            new int[] { 0, -1 }
        };

        while (q.Count > 0)
        {
            (int, int) cur = q.Dequeue();
            int row = cur.Item1;
            int col = cur.Item2;
            foreach (int[] dir in dirs)
            {
                int x = row + dir[0];
                int y = col + dir[1];
                if (x < 0 || y < 0 || x >= ROW || y >= COL || grid[x][y] != int.MaxValue)
                {
                    continue;
                }
                q.Enqueue((x, y));
                grid[x][y] = grid[row][col] + 1;
            }
        }
    }

    public int OrangesRotting(int[][] grid)
    {
        Queue<(int, int)> q = new Queue<(int, int)>();
        int ROW = grid.Length;
        int COL = grid[0].Length;

        int fresh = 0;
        int ans = 0;

        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {
                if (grid[i][j] == 1)
                {
                    fresh++;
                }
                if (grid[i][j] == 2)
                {
                    q.Enqueue((i, j));
                }
            }
        }

        int[][] dirs =
        {
            new int[] { 1, 0 },
            new int[] { -1, 0 },
            new int[] { 0, 1 },
            new int[] { 0, -1 },
        };

        while (q.Count > 0 && fresh > 0)
        {
            int length = q.Count;
            for (int i = 0; i < length; i++)
            {
                (int, int) cur = q.Dequeue();
                int r = cur.Item1;
                int c = cur.Item2;
                foreach (int[] dir in dirs)
                {
                    int row = r + dir[0];
                    int col = c + dir[1];
                    if (row < 0 || col < 0 || row >= ROW || col >= COL || grid[row][col] != 1)
                    {
                        continue;
                    }
                    q.Enqueue((row, col));
                    grid[row][col] = 2;
                    fresh--;
                }
            }
            ans++;
        }
        return (fresh == 0) ? ans : -1;
    }

    public List<List<int>> PacificAtlantic(int[][] heights)
    {
        int ROWS = heights.Length;
        int COLS = heights[0].Length;

        HashSet<(int, int)> pac = new HashSet<(int, int)>();
        HashSet<(int, int)> atl = new HashSet<(int, int)>();

        void dfs(int r, int c, HashSet<(int, int)> visit, int prevHeight)
        {
            if (
                r < 0
                || c < 0
                || r >= ROWS
                || c >= COLS
                || heights[r][c] < prevHeight
                || visit.Contains((r, c))
            )
            {
                return;
            }
            visit.Add((r, c));
            dfs(r + 1, c, visit, heights[r][c]);
            dfs(r - 1, c, visit, heights[r][c]);
            dfs(r, c + 1, visit, heights[r][c]);
            dfs(r, c - 1, visit, heights[r][c]);
        }

        for (int i = 0; i < ROWS; i++)
        {
            dfs(i, 0, pac, heights[i][0]);
            dfs(i, COLS - 1, atl, heights[i][COLS - 1]);
        }

        for (int i = 0; i < COLS; i++)
        {
            dfs(0, i, pac, heights[0][i]);
            dfs(ROWS - 1, i, atl, heights[ROWS - 1][i]);
        }

        List<List<int>> res = new List<List<int>>();
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                if (pac.Contains((i, j)) && atl.Contains((i, j)))
                {
                    res.Add(new List<int> { i, j });
                }
            }
        }

        return res;
    }
}
