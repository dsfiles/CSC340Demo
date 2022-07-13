// Bubble sort example
using System;
class Program
{
    static void Main(string[] args)
    {
        int[] a = { 3, 2, 5, 1, 0 };
        Console.WriteLine("The original array: 3 2 5 1 0");
        BubbleSort(a);
        Console.Write("The sorted array:   ");
        foreach (int i in a)
            Console.Write(i + " ");
    }

    static void BubbleSort(int[] a)
    {
        int tmp;
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = 0; j < a.Length - 1 - i; j++)
            {
                if (a[j] > a[j + 1])
                {
                    tmp = a[j + 1];
                    a[j + 1] = a[j];
                    a[j] = tmp;
                }
            }
        }
    } //end of BubbleSort
}
