using System;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        Stopwatch stopwatch = new Stopwatch(); // Create a stopwatch object to track the time
        int size = 10_000; // Try different array size of 10, 100, 1k, 10k, 100k, or even higher
        int[] arr1 = new int[size];
        int[] arr2 = new int[size];
        int[] arr3 = new int[size];
        int[] arr4 = new int[size];
        int[] arr5 = new int[size];
        int[] arr6 = new int[size];

        // Create arrays of random numbers
        for (int i = 0; i < size; i++)
            arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = rand.Next();

        // Create sorted arrays in ascending order
        //for (int i = 0; i < size; i++)
        //    arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = i;

        // Create sorted arrays in descending order
        //for (int i = 0; i < size; i++)
        //    arr1[i] = arr2[i] = arr3[i] = arr4[i] = arr5[i] = arr6[i] = size-1-i;

        Console.WriteLine($"Time (in milliseconds) to sort {size} numbers ...");
        stopwatch.Start();
        BubbleSort(arr1);
        stopwatch.Stop();
        Console.WriteLine($"Regular bubble sort: {stopwatch.Elapsed.TotalMilliseconds}");

        stopwatch.Restart();
        BubbleSortOptimized(arr2);
        stopwatch.Stop();
        Console.WriteLine($"Optimized bubble sort: {stopwatch.Elapsed.TotalMilliseconds}");

        stopwatch.Restart();
        QSort(arr2);
        stopwatch.Stop();
        Console.WriteLine($"Quick sort: {stopwatch.Elapsed.TotalMilliseconds}");

        // More testing of other sorting algorithms to be added here ...
    }

    static void BubbleSort(int[] arr)
    {
        int tmp;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1-i; j++)
            {
                if (arr[j] > arr[j + 1])
                { // swap two adjacent elements if they are not in the intended order
                    tmp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = tmp;
                }
            }
        }
    }
    static void BubbleSortOptimized(int[] arr)
    {
        int tmp;
        bool flag = false;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                { // swap two adjacent elements if they are not in the intended order
                    tmp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = tmp;
                    flag = true;
                }
            }
            if (!flag)
            {
                return; // the array is already sorted
            }
        }
    }

    static void QSort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length-1);
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        // return right way if there is only one element, i.e., left == right,
        // or there is none, i.e., left > right, 
        if (left < right)
        {
            int p = Partition(arr, left, right); // p is the index of pivot
            QuickSort(arr, left, p - 1);
            QuickSort(arr, p + 1, right);
        }
    }
    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right], tmp; //in this example we always pick the last element as pivot
        int l = left;
        int r = right - 1; //subtract one here because last element is pivot
        while (l < r)
        {
            while (arr[l] < pivot && l < r) { l++; }
            while (arr[r] > pivot && l < r) { r--; }
            if (l < r) // if the two elements pointed by l and r are out of order, swap them
            {
                tmp = arr[l]; arr[l] = arr[r]; arr[r] = tmp;
            }
        }
        tmp = arr[l]; arr[l] = arr[right]; arr[right] = tmp;
        return l; //l is the index of partition to be returned
    }
    // Add your own implementation of Selection-, Insertion-, Merge- and Quick-Sort
    // or use the existing ones below:
    // https://github.com/dsfiles/CSC340/tree/main/week02
}
