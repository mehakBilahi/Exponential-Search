using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exponential_Search
{
    class Program
    {
        public static void WriteFile(int[] arr, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    writer.WriteLine(arr[i]);

                }

            }
        }
        public static int[] ReadFile(string filename)
        {
            int lines = File.ReadAllLines(filename).Length;
            int[] arr = new int[lines];
            try
            {
                using (StreamReader readarray = new StreamReader(filename))
                {
                    for (int i = 0; i < lines; i++)
                    {
                        string array = readarray.ReadLine();
                        arr[i] = int.Parse(array);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return arr;
        }
        static int BinarySearch(int[] array, int l, int r, int k)
        {
            int mid = (l + r) / 2;
            if (l > r)
                return -1;
            if (k == array[mid])
                return mid;
            if (k > array[mid])
            {
                l = mid + 1;
                return BinarySearch(array, l, r, k);
            }
            else
            {
                r = mid - 1;
                return BinarySearch(array, l, r, k);
            }
        }
        static int exponentialSearch(int[] array, int l, int r, int k)
        {
            int pos = 1;
            if (l > r)
                return -1;
            if (k == array[l])
                return l;
            else
            {
                for (int i = 0; i < r / 2; i++)
                {
                    pos = pos * 2;
                    if (k < array[pos] || k == array[pos])
                    {
                        r = pos;
                        l = pos / 2;
                        return BinarySearch(array, l, r, k);
                    }
                }


            }

            return pos;

        }
        static void Main(string[] args)
        {
            string filename = @"E:\uit 3sem\Data Structures\exponential search/arrayCxpoSearch.txt";
            int[] array = ReadFile(filename);
            int left = 0;
            int right = array.Length - 1;
            int key = int.Parse(Console.ReadLine());
            int postion = 0;
            postion = exponentialSearch(array, left, right, key);
            using (StreamWriter output_file = new StreamWriter(@"C:\Users\Cmax\Desktop\exponential"))
                if (postion == -1)
                {

                    output_file.WriteLine("Value not Found");
                }
                else
                {

                    output_file.WriteLine("The index at which {0} is found is {1}", key, postion);
                }

        }
    }
}
