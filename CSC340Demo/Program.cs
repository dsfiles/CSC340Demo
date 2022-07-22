// bug in sorting
/*
 * An array-based list implementation by Alex M. 
 * Version 1.0 without generic programming feature
 */

using System;

namespace MyArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create an instance
            MyArrayList list = new MyArrayList();
            //check count and capacity
            Console.WriteLine($"A newly created list: count={list.Count}, capacity={list.Capacity}");
            //add to this list
            list.Add(3);
            Console.WriteLine($"Operation: Add(3), Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(1);
            Console.WriteLine($"Operation: Add(1), Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(2);
            Console.WriteLine($"Operation: Add(2), Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(5);
            Console.WriteLine($"Operation: Add(5), Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(0);
            Console.WriteLine($"Operation: Add(0), Count: {list.Count}, Capacity: {list.Capacity}");
            //for (int i = 0; i < 2; i++)
            //{
            //    list.Add(3);
            //}
            Console.WriteLine("List before sorting:");
            list.DisplayList();
            list.Sort();
            Console.WriteLine("List after sorting:");
            list.DisplayList();
            //check indexer
            Console.WriteLine("element at index 1: " + list[1]);
            list.Clear();
            Console.WriteLine($"Operation: Clear(), Count: {list.Count}, Capacity: {list.Capacity}");
        }
    }

    class MyArrayList
    {
        int[] values; //data stored in an array
        public int Count { get; private set; }
        public int Capacity
        {
            get { return values.Length; }
            set { Capacity = value; }
        }

        public MyArrayList(int Capacity=4) //constructor
        {   //allocate an array of size = Capacity or 4 by default 
            values = new int[Capacity];
            Count = 0; //initially count is set to 0;
        }

        public void Add(int newValue)
        {
            //check if array is full
            if (Count == Capacity)
            {
                Resize();
            }
            //put newValue into the array at position count
            values[Count] = newValue;
            Count++;
        }

        public void Resize()
        {
            //create a new array of double capacity
            int[] tmp = new int[2 * Capacity];
            //copy over the old value
            for (int pos = 0; pos < Capacity; pos++)
            {
                tmp[pos] = values[pos];
            }
            //reference values array to the new tmp array
            values = tmp;
        }

        public void AddLast(int newValue)
        {
            Add(newValue);
            //Insert(newValue, Count)
        }

        public void AddFirst(int newValue)
        {
            Insert(newValue, 0);
        }

        public void Insert(int newValue, int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException($"index should be between {0} and {Count}");
            //check if the array is full, double its capacity if needed
            if (Count == Capacity)
                Resize();
            //shift everything from position i thru Count-1 to the right by one position
            for (int i = Count; i > index; i--)
            {
                values[i] = values[i - 1];
            }
            //insert the new value
            values[index] = newValue;
            Count++;
        }

        public void DeleteLast()
        {
            if (Count == 0) //you CAN't delete last from an empty list
                throw new IndexOutOfRangeException("You CAN't delete last from an empty list");
            Count--;
        }
        public void DeleteFirst()
        {
            Delete(0);
        }
        public void Delete(int index)
        {
            //validate index
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException($"index should be between {0} and {Count - 1}");
            //shift everything (that is past index i) to the left one position
            for (int i = index; i < Count - 1; i++)
                values[i] = values[i + 1];
            Count--;
        }
        public void Clear()
        {
            Count = 0; // too simple?
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void DisplayList()
        {
            if (IsEmpty())
                Console.WriteLine("Empty list!");
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.Write((values[i]) + " ");
                }
                Console.WriteLine();
            }
        }

        public void Sort()
        {
            Console.WriteLine("count=" + Count);
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
            QuickSort(values, 0, Count - 1);
        }
        static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int p = Partition(arr, left, right);
                QuickSort(arr, left, p - 1);
                QuickSort(arr, p + 1, right);
            }
        }
        static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right], tmp;
            int l = left;
            int r = right - 1;
            while (l < r)
            {
                while (arr[l] < pivot && l < r)
                {
                    l++;
                }
                while (arr[r] > pivot && l < r)
                {
                    r--;
                }
                if (l < r)
                {
                    tmp = arr[l]; arr[l] = arr[r]; arr[r] = tmp;
                }
            }
            tmp = arr[l]; arr[l] = arr[right]; arr[right] = tmp;
            return l;
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public int this[int i] //indexer
        {
            get { return values[i]; }
            set { values[i] = value; }
        }
    }
}