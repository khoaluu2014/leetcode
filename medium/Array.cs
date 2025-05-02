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
}
