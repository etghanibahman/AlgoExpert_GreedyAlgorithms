using System;
using System.Linq;

namespace MinimumWaitingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 2, 1, 2, 6 };
            Console.WriteLine($"Input Array is: {String.Join<int>(',', array)} ");
            Console.WriteLine($"Minimum Waiting Time is: { MinimumWaitingTime(array) } ");
        }

        //public static int MinimumWaitingTime(int[] queries)
        //{
        //    return queries.OrderByDescending(q => q).Select((q, i) => q * i).Sum();
        //}


        #region MySolution

        public static int MinimumWaitingTime(int[] queries)
        {
            int minimumSum = 0;
            Array.Sort(queries);
            for (int i = 0; i < queries.Length - 1; i++)
            {
                minimumSum += (queries.Length - (i + 1)) * queries[i];
            }
            return minimumSum;
        }
        //public static int MinimumWaitingTime(int[] queries)
        //{
        //    int minimumSum = 0;
        //    Array.Sort(queries);
        //    int[] waitingTimes = new int[queries.Length - 1];
        //    for (int i = 0; i < queries.Length-1; i++)
        //    {
        //        minimumSum += queries[i];
        //        waitingTimes[i] = minimumSum;
        //    }
        //    return waitingTimes.Sum();
        //}
        #endregion

    }


}
