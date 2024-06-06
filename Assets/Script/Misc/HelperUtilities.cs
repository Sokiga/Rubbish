using System.Collections.Generic;
using System.Linq;

public static class HelperUtilities
{
    public static List<T> GetRandomElements<T>(List<T> list, int n)
    {
        if (n > list.Count)
        {
            return null;
        }

        System.Random rand = new System.Random();
        List<T> result = new List<T>();
        List<int> indices = Enumerable.Range(0, list.Count).ToList();

        for (int i = 0; i < n; i++)
        {
            int randomIndex = rand.Next(indices.Count);
            result.Add(list[indices[randomIndex]]);
            indices.RemoveAt(randomIndex); // 确保不重复
        }

        return result;
    }

}
