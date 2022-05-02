using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ArrayLib
{
    public class MyArray
    {

        #region Fields

        private int[] arr;

        #endregion

        #region Properties

        public int this[int index]
        {
            get => arr[index];

            set => arr[index] = value;
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (int x in arr)
                {
                    sum += x;
                }
                return sum;
            }
        }

        public int MaxCount
        {
            get
            {
                int count = 1;
                int max = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > max) {
                        max = arr[i];
                        count = 1;
                    } 
                    else if (arr[i] == max)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        #endregion

        #region Constructors


        public MyArray(int count, int a, int h)
        {
            
            this.arr = new int[count];

            for (int i = 0; i < count; i++)
            {
                this.arr[i] = a + h * i;
            }

        }

        public MyArray(int[] arr)
        {
            this.arr = new int[arr.Length];
            Array.Copy(arr, this.arr, arr.Length);

        }

        public MyArray(string fileName)
        {
            this.arr = LoadArrayFromFile(fileName);
        }

        #endregion

        #region Methods

        public Dictionary<int, int> Frequency()
        {
            int max = this.Max();
            int min = this.Min();
            int n = max - min + 1;
            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                mas[i] = 0;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                mas[arr[i] - min]++;
            }

            Dictionary<int, int> freq = new Dictionary<int, int>();
            
            for (int i = 0; i < n; i++)
            {
                if (mas[i] != 0)
                    freq[i + min] = mas[i]; 
            }

            return freq;
        }

        public int Max()
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max) 
                    max = arr[i];
            return max;
        }
        public int Min()
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] < min)
                    min = arr[i];
            return min;
        }
        public MyArray Inverse()
        {
            int[] invarr = new int[this.arr.Length];
            for (int i = 0; i < invarr.Length; i++)
            {
                invarr[i] = -this.arr[i];
            }
            return new MyArray(invarr);
        }

        public void Multi(int value)
        {
            for (int i = 0; i < this.arr.Length; i++)
                this.arr[i] *= value;
        }

        private int[] LoadArrayFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();

            int[] buf = new int[1000];
            int counter = 0;
            StreamReader streamReader = new StreamReader(fileName);

            while (!streamReader.EndOfStream)
            {
                buf[counter] = int.Parse(streamReader.ReadLine());
                counter++;
            }

            streamReader.Close();

            int[] arr = new int[counter];
            Array.Copy(buf, arr, counter);
            return arr;
        }

        public void PrintArray()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}\t");
            }
            Console.WriteLine();
        }

        #endregion

    }
    public class My2dimArray
    {
        private int[,] arr;
        #region Properties
        public int this[int i, int j]
        {
            get => arr[i, j];

            set => arr[i, j] = value;
        }
        public int MaxElement
        {
            get
            {
                int max = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] > max)
                            max = arr[i, j];
                return max;
            }
        }
        public int MinElement
        {
            get
            {
                int min = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] < min)
                            min = arr[i, j];
                return min;
            }
        }
        #endregion

        #region constructors
        public My2dimArray(int n, int m)
        {
            this.arr = new int[n, m];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    this.arr[i, j] = r.Next(-100, 101);
                }
            }
        }
        public My2dimArray(string FileName)
        {
            this.arr = LoadFromFile(FileName);
        }
        #endregion

        #region Metods
        private int[,] LoadFromFile(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                    throw new FileNotFoundException();

                int[,] buf = new int[1000, 1000];

                string[] ss = File.ReadAllLines(fileName);
                string[] sub_ss;
                int row = 0;
                for (int i = 0; i < ss.Length; i++)
                {
                    sub_ss = ss[i].Split(' ');
                    if (sub_ss.Length > row)
                        row = sub_ss.Length;
                    for (int j = 0; j < sub_ss.Length; j++)
                    {
                        buf[i, j] = int.Parse(sub_ss[j]);
                    }
                }
                arr = new int[ss.Length, row];
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        arr[i, j] = buf[i, j];

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return arr;
        }
        public void WriteToFileAsync(string fileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName);
                string text = "";
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1) - 1; j++)
                    {
                        text += $"{-arr[i, j]} ";
                    }
                    
                    text += i != arr.GetLength(0) - 1 ? $"{-arr[i, arr.GetLength(1) - 1]}\n" : $"{-arr[i, arr.GetLength(1) - 1]}";
                }
                sw.WriteLine(text);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public int SumOfElements()
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    sum += arr[i, j];
            return sum;
        }
        public int SumOfElements(int val)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    sum += arr[i, j] > val ? arr[i, j] : 0;
            return sum;
        }
        public void NumMaxElement(out int imax, out int jmax)
        {
            imax = 0;
            jmax = 0;
            int max = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        imax = i;
                        jmax = j;
                    }
        }
        public void PrintArr()
        {
            for (int i = 0; i < arr.GetLength(0); i++) {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write($"{arr[i, j]}  ");
                Console.WriteLine();
            }
        }
        #endregion
    }
}
