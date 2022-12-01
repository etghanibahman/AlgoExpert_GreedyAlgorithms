using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassPhotos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> redShirtHeights = new List<int> { 5, 8, 1, 3, 4 };
            List<int> blueShirtHeights = new List<int> { 6, 9, 2, 4, 5 };

            Console.WriteLine($"Placing of studdents is possible? {ClassPhotos(redShirtHeights, blueShirtHeights)}");
        }

        public static bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
        {
            int[] backRow;
            int[] frontRow;
            if (redShirtHeights.Max() > blueShirtHeights.Max())
            {
                backRow = redShirtHeights.ToArray();
                frontRow = blueShirtHeights.ToArray();
            }
            else
            {
                frontRow = redShirtHeights.ToArray();
                backRow = blueShirtHeights.ToArray();
            }

            Array.Sort(frontRow);
            Array.Sort(backRow);

            for (int i = frontRow.Length - 1; i >= 0; i--)
            {
                if (frontRow[i] >= backRow[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
