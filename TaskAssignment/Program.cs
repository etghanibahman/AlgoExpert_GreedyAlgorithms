using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 3;
            List<int> tasks = new List<int> { 1, 3, 5, 3, 1, 4 };
            Console.WriteLine($"K = {k} , tasks = {String.Join<int>(',',tasks)} ");

            var results = TaskAssignment(k, tasks);
            foreach (var item in results)
            {
                Console.WriteLine($"{String.Join<int>(',',item)}");
            }
        }


        // O(nLog(n)) Time,  O(N) space
        public static List<List<int>> TaskAssignment(int k, List<int> tasks)
        {
            var result = new List<List<int>>();
            Dictionary<int, int> taskValueDic = new Dictionary<int, int>();

            for (int i = 0; i < tasks.Count; i++)
            {
                taskValueDic.Add(i,tasks[i]);
            }

            var sortedTaskValueDic = taskValueDic.OrderBy(a => a.Value).ToDictionary( a => a.Key , a => a.Value );

            for (int i = 0; i < k; i++)
            {
                var item = new List<int>() { sortedTaskValueDic.ElementAt(i).Key, sortedTaskValueDic.ElementAt((tasks.Count -1) - i).Key };
                result.Add(item);
            }

            return result;
        }
    }
}
