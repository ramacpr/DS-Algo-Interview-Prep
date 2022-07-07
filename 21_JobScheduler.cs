using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    class Job
    {
        public int JobID;
        public int JobDeadline;
        public int Profit; 

        public Job(int id, int deadline, int profit)
        {
            JobID = id;
            JobDeadline = deadline;
            Profit = profit;
        }
    }
    static class JobScheduler
    {
        
        public static void PrintJobsScheduled()
        {
            Job[] arr = new Job[]
            {
                new Job(1, 4, 20),
                new Job(2, 3, 10),
                new Job(3, 2, 40),
                new Job(4, 5, 30)
            };

            Console.WriteLine($"Max profits are {GetMaxProfit(arr)}");
        }

        static int GetMaxProfit(Job[] arr)
        {
            int totalMaxProfit = 0;
            int MaxTime = 0;

            // 1. Sort wrt profits
            // and in this process get the max time available to scheduler
            SortProfits(ref arr, 0, arr.Length - 1, ref MaxTime);

            // 2. Schedule the max profit ones first. 
            int?[] jobArr = new int?[MaxTime];

            int j = 0;
            for(int t = 0; t < arr.Length; t++)
            {
                j = arr[t].JobDeadline - 1; 
                if(jobArr[j] == null)
                {
                    jobArr[j] = (int?)arr[t].Profit;
                    totalMaxProfit += arr[t].Profit;
                }
                else
                {
                    while (j >= 0 && jobArr[j] != null)
                        j -= 1;

                    if (j >= 0)
                    {
                        jobArr[j] = (int?)arr[t].Profit;
                        totalMaxProfit += arr[t].Profit; 
                    }
                }
            }
            return totalMaxProfit;
        }

        static void SortProfits(ref Job[] arr, int start, int end, ref int maxTime)
        {
            if(start < end)
            {
                int pIndex = Partition(ref arr, start, end, ref maxTime);
                SortProfits(ref arr, start, pIndex - 1, ref maxTime);
                SortProfits(ref arr, pIndex + 1, end, ref maxTime);
            }
        }

        static int Partition(ref Job[] arr, int start, int end, ref int maxTime)
        {
            int smallestIndex = start - 1;
            Job pivot = arr[end], tmp = null;

            for(int i = start; i < end; i++)
            {
                if (arr[i].JobDeadline > maxTime)
                    maxTime = arr[i].JobDeadline; 

                if(pivot.Profit < arr[i].Profit)
                {
                    smallestIndex += 1;

                    // swap
                    tmp = arr[i];
                    arr[i] = arr[smallestIndex];
                    arr[smallestIndex] = tmp;                    
                }
            }

            smallestIndex += 1;

            // swap
            if (arr[end].JobDeadline > maxTime)
                maxTime = arr[end].JobDeadline;
            tmp = arr[end];
            arr[end] = arr[smallestIndex];
            arr[smallestIndex] = tmp;

            return smallestIndex;
        }
    }
}
