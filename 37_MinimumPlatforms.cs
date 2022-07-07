using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    enum Type
    {
        Arrival, 
        Departure
    }

    class TrainInfo
    {
        public Type type;
        public int time; 

        public TrainInfo(int time, Type type)
        {
            this.type = type;
            this.time = time;
        }
    }

    // use min heap to sort
    class TrainMinHeap
    {
        TrainInfo[] root = null;

        public void AddItem(int time, Type type)
        {
            if (root == null)
                root = new TrainInfo[1];
            else if (root[root.Length - 1] != null)
                Array.Resize(ref root, root.Length + 1);
            root[root.Length - 1] = new TrainInfo(time, type);

            for (int i = (root.Length - 1) / 2; i >= 0; i--)
                Heapify(i);
        }

        public TrainInfo ExtractMin()
        {
            if (root.Length == 0)
                return null;

            TrainInfo min = new TrainInfo(root[0].time, root[0].type);

            root[0] = new TrainInfo(root[root.Length - 1].time, root[root.Length - 1].type);
            Array.Resize(ref root, root.Length - 1);
            Heapify(0);

            return min;
        }

        void Heapify(int index)
        {
            if (index < 0)
                return;

            var leftChild = (2 * index) + 1;
            var rightChild = leftChild + 1;
            var smallesIndex = leftChild;

            if (leftChild < root.Length && rightChild < root.Length &&
                root[leftChild].time < root[rightChild].time)
                smallesIndex = leftChild;
            else if (leftChild < root.Length && rightChild < root.Length &&
                root[leftChild].time > root[rightChild].time)
                smallesIndex = rightChild;

            if (leftChild < root.Length &&
                root[index].time < root[smallesIndex].time)
                smallesIndex = index;

            // swap smallestIndex with index
            if (smallesIndex < root.Length && index < root.Length && smallesIndex != index)
            {
                var tmp = root[index];
                root[index] = root[smallesIndex];
                root[smallesIndex] = tmp;
                if (smallesIndex >= (root.Length - 1) / 2)
                    Heapify(smallesIndex);
            }
        }
    }

    static class MinimumPlatforms
    {
        static TrainMinHeap minHeap = new TrainMinHeap();

        static public void PrintResult()
        {
            int[] arrival = new int[] { 900, 940, 950, 1100, 1500, 1800 };
            int[] departure = new int[] { 910, 1200, 1120, 1130, 1900, 2000 };

            Console.WriteLine($"Need {GetPlatformCount(arrival, departure)} platforms.");
        }

        static int GetPlatformCount(int[] arrival, int[] departure)
        {
            int pCount = 1, count = 1;

            if (arrival.Length != departure.Length)
                return -1;

            for (int ai = 0; ai < arrival.Length; ai++)
                minHeap.AddItem(arrival[ai], Type.Arrival);
            for (int di = 0; di < departure.Length; di++)
                minHeap.AddItem(departure[di], Type.Departure);

            var trainItem = minHeap.ExtractMin(); 
            while(trainItem != null)
            {
                if (trainItem.type == Type.Arrival)
                    count++;
                else
                    count--;

                if (count > pCount)
                    pCount = count;

                trainItem = minHeap.ExtractMin();
            }

            return pCount;
        }
    }
}
