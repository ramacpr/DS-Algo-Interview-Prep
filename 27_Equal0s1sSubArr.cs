using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    static class Equal0s1sSubArr
    {
        public static void PrintResult()
        {
            var subArrList = GetCountOfSubArr(new int[] { 1, 0, 0, 1, 0, 1, 1 });
            foreach (var pair in subArrList)
                Console.WriteLine($"{pair.Item1} - {pair.Item2}");
            Console.WriteLine($"{subArrList.Count}");
        }

        static List<Tuple<int, int>> GetCountOfSubArr(int[] arr)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            int sum = 0;
            int hashedIndex = -1;
            List<Tuple<int, int>> subArrList = new List<Tuple<int, int>>(); 

            for(int i = 0; i < arr.Length; i++)
            {
                sum += (arr[i] == 0 ? -1 : arr[i]);
                if (sum == 0)
                    subArrList.Add(new Tuple<int, int>(0, i)); 
                    
                if (!hash.TryGetValue(sum, out hashedIndex))
                    hash[sum] = i;
                else
                    subArrList.Add(new Tuple<int, int>(hashedIndex + 1, i));
            }

            return subArrList;
        }
    }
}
