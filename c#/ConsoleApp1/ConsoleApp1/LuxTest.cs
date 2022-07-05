using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class LuxTest
    {
        public static List<int> FrequencySort(List<int> arr)
        {
            // Write your code here...
            var groupedResult = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            var result = new List<int>();
            foreach (var gr in groupedResult)
            {
                for (var i = 0; i < gr.Count(); i++)
                {
                    result.Add(gr.Key);
                }
            }
            return result;
        }

        public static void RunCode()
        {
            // Entrypoint to debug your function
            FrequencySort(new List<int>() { 4, 10, 3, 6, 4, 4, 8, 8, 6 });
        }
    }
}
