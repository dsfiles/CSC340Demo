using System;
public class Program
{
    public static void Main()
    {
        int[] arr = { 1, 2, 5, 8, 11, 13, 13, 13, 18, 20 }; // a sorted array
        Console.WriteLine("Sorted array: { 1, 2, 5, 8, 11, 13, 13, 13, 18, 20 }");
        Console.WriteLine("Index of 5: " + SequentialSearch(arr, 5));
        Console.WriteLine("Index of 13: " + SequentialSearch(arr, 13));
        Console.WriteLine("Index of 28: " + SequentialSearch(arr, 28));
        Console.WriteLine("Index of 5: " + BinarySearch(arr, 5));
        Console.WriteLine("Index of 13: " + BinarySearch(arr, 13));
        Console.WriteLine("Index of 28: " + BinarySearch(arr, 28));
    }

    static int BinarySearch(int[] arr, int num) //
    {
        int left = 0;
        int right = arr.Length - 1;
        int middle;
        while (left <= right)
        {
            middle = (left + right) / 2;
            if (num == arr[middle])
            {
                return middle;
            }
            else if (num < arr[middle])
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }
        return -1;
    }

    static int SequentialSearch(int[] arr, int key)
    {
        int ret = -1;
        for (int index = 0; index < arr.Length && ret == -1; index++)
            if (arr[index] == key)
                ret = index;
        return ret;
    }
}
