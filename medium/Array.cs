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

}
