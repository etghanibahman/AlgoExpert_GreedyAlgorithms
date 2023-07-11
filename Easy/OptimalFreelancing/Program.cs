// See https://aka.ms/new-console-template for more information

using System.Linq;

Dictionary<string, int>[] jobs = new Dictionary<string, int>[]
    {
        new Dictionary<string, int>() { { "deadline", 1},{ "payment", 1}},
        new Dictionary<string, int>() { { "deadline", 2}, { "payment", 2}},
        new Dictionary<string, int>() { { "deadline", 2},{"payment", 1}}
    };

Console.WriteLine($"the optimal value is : {OptimalFreelancing(jobs)} ");
int OptimalFreelancing(Dictionary<string, int>[] jobs)
{
    int[] payment = new int[7];
    for (int i = 0; i < jobs.Length; i++)
    {
        int deadline = jobs[i]["deadline"];
        if (deadline > 7)
            deadline = 7;
        int currentPayment = jobs[i]["payment"];
        for (int j = deadline - 1; j >= 0; j--)
        {
            if (payment[j] < currentPayment && currentPayment != 0)
            {
                int tmp = payment[j];
                payment[j] = currentPayment;
                currentPayment = tmp;
            }
        }
    }

    return payment.Sum();
}

#region My_Solution
//Dictionary<string, int>[] GetNormalInput(Dictionary<string, int>[] jobs)
//{
//    List<Dictionary<string, int>> normalizedJobs = new List<Dictionary<string, int>>();
//    for (int i = 0; i < jobs.Length; i++)
//    {
//        int deadline = jobs[i]["deadline"];
//        int currentPayment = jobs[i]["payment"];
//        normalizedJobs.Add(new Dictionary<string, int>() { { deadline.ToString(), currentPayment } });
//    }
//    return normalizedJobs.ToArray();
//}

//Console.WriteLine($"the optimal value is : {OptimalFreelancing(jobs)} ");


//int OptimalFreelancing(Dictionary<string, int>[] jobs)
//{
//    int optimalValue = -1;
//    var normalizedJobs = GetNormalInput(jobs);


//    for (int i = 7; i > 0; i--)
//    {
//        var validJobs = GetValidJobs(normalizedJobs, i);
//        if (validJobs.Any())
//        {
//            var maxValue = validJobs.Select(a => a.Values.ElementAt(0)).Max();
//            var items = normalizedJobs.Where(a => a.Values.ElementAt(0) == maxValue).ToList();
//            var itemToBeRemoved = items.OrderByDescending(a => a.Keys).FirstOrDefault();
//            if (itemToBeRemoved != null)
//            {
//                normalizedJobs.ToList().Remove(itemToBeRemoved);
//                normalizedJobs = normalizedJobs.ToArray();
//            }
//            optimalValue += maxValue;
//        }

//    }

//    return optimalValue;
//}

//List<Dictionary<string, int>> GetValidJobs(Dictionary<string, int>[] jobs, int validDay)
//{
//    List<Dictionary<string, int>> lstValidJobs = new List<Dictionary<string, int>>();

//    for (int i = 7; i >= validDay; i--)
//    {
//        var validJobs = jobs.Where(a => a.Keys.Contains(i.ToString())).ToList();
//        lstValidJobs.AddRange(validJobs);
//    }
//    return lstValidJobs;
//}
#endregion
