using System.Collections.Generic;

namespace ConsoleApp1
{
    class packNumbersBooking
    {
        static void Test()
        {
            packNumbers(new List<int>() { 8, 5, 5, 5, 7, 7, 3, 4, 7 });

        }

        static List<string> packNumbers(List<int> arr)
        {
            var result = new List<string>();
            var counter = 1;
            for (var i = 0; i < arr.Count; i++)
            {
                if (i + 1 < arr.Count && arr[i] == arr[i + 1])
                {
                    counter++;
                }
                else
                {
                    if (counter > 1)
                    {
                        result.Add($"{arr[i]}:{counter}");

                    }
                    else
                    {
                        result.Add(arr[i].ToString());

                    }
                    counter = 1;
                }
            }
            return result;

        }




        //var result = new List<string>();
        //foreach (var item in arr.GroupBy(x => x))
        //{

        //    if (item.Count() > 1)
        //    {
        //        result.Add($"{item.Key.ToString()}:{item.Count()}");
        //    }
        //    else
        //    {
        //        result.Add(item.Key.ToString());
        //    }
        //}
        //return result;
    }
}
