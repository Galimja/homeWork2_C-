using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayLib;
// Кабылбеков Галымжан

namespace HomeWork4
{
    class StaticClass
    {
        public static int countTask1(int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length - 1; i++)
                count += a[i] % 3 == 0 ? (a[i + 1] % 3 == 0 ? 0 : 1) : (a[i + 1] % 3 == 0 ? 1 : 0);
            return count;
        }
        public static int[] ReadArr(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException();

            int[] buf = new int[1000];
            int counter;

            StreamReader streamReader = new StreamReader(file);
            for (counter = 0; !streamReader.EndOfStream; counter++)
            {
                buf[counter] = int.Parse(streamReader.ReadLine());
            }
            
            streamReader.Close();
            
            int[] arr = new int[counter];
            Array.Copy(buf, arr, counter);
            return arr;
        }
        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
    }  
    struct Account
    {
        public string login;
        public string password;

        public bool chekLP()
        {
            return login == "root" && password == "GeekBrains";
        }
        public override string ToString()
        {
            return $"Логин: {login}, пароль: {password}";
        }
    }
    internal class Program
    {
        static void task5()
        {
            do
            {
                Console.Write("Введите число строк: ");
                int n = int.Parse(Console.ReadLine());
                Console.Write("Введите число столбцов: ");
                int m = int.Parse(Console.ReadLine());
                My2dimArray arr = new My2dimArray(n, m);
                arr.PrintArr();
                Console.WriteLine($"Сумма всех элементов массива: {arr.SumOfElements()}");
                Console.WriteLine($"Сумма всех положительных элементов массива: {arr.SumOfElements(0)}");
                Console.WriteLine($"Максимальный элемент массива: {arr.MaxElement}");
                Console.WriteLine($"Минимальный элемент массива: {arr.MinElement}");
                int i, j;
                arr.NumMaxElement(out i, out j);
                Console.WriteLine($"Индексы максимального элемента: {i}, {j}\nМаксимальный элемент: {arr[i, j]}");
                Console.WriteLine("Массив считаный из файла Matrix.txt:");
                arr = new My2dimArray(AppDomain.CurrentDomain.BaseDirectory + "Matrix.txt");
                arr.PrintArr();
                Console.WriteLine("Записываем в файл Matrix2.txt наш массив и меняем знаки у элементов");
                arr.WriteToFileAsync(AppDomain.CurrentDomain.BaseDirectory + "Matrix2.txt");
                arr = new My2dimArray(AppDomain.CurrentDomain.BaseDirectory + "Matrix2.txt");
                arr.PrintArr();
                Console.WriteLine("Хотите сгенерировать новый массив?\n1 -> Yes\n2 -> No");
                int f = int.Parse(Console.ReadLine());
                if (f == 2)
                    break;
            } while (true);
        }
        static void task4()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "LoginPassword.txt";
            if (!File.Exists(fileName))
                throw new FileNotFoundException();

            string[,] logPass = new string[100, 2];
            int counter = 0;
            StreamReader streamReader = new StreamReader(fileName);

            while (!streamReader.EndOfStream)
            {
                logPass[counter, 0] = streamReader.ReadLine();
                logPass[counter, 1] = streamReader.ReadLine();
                counter++;
            }
            streamReader.Close();

            for (int i = 0; i < counter; i++)
            {
                Account account = new Account();
                account.login = logPass[i, 0];
                account.password = logPass[i, 1];
                Console.WriteLine($"{account}");
                if (account.chekLP())
                    Console.WriteLine("Правильный логин и пароль!");
                else
                    Console.WriteLine("Неправильный логин или пароль");
            }

        }
        static void task3()
        {
            do
            {
                Console.Write("Введите количество элементов массива: ");
                int n = int.Parse(Console.ReadLine());
                Console.Write("Введите начальный элемент массива: ");
                int m = int.Parse(Console.ReadLine());
                Console.Write("Введите шаг: ");
                int h = int.Parse(Console.ReadLine());
                MyArray arr = new MyArray(n, m, h);
                Console.WriteLine("Наш массив:");
                arr.PrintArray();
                Console.WriteLine($"Сумма всех элементов массива: {arr.Sum}");
                MyArray arr2 = arr.Inverse();
                Console.WriteLine("Массив с измененными знаками:");
                arr2.PrintArray();
                arr.Multi(-2);
                Console.WriteLine("Наш массив умноженный на -2:");
                arr.PrintArray();

                arr = new MyArray(AppDomain.CurrentDomain.BaseDirectory + "Array2.txt");
                Console.WriteLine("Считаный из файла массив.");
                arr.PrintArray();
                Console.WriteLine($"Количество максимальных элементов в массиве: {arr.MaxCount}");
                Dictionary<int, int> a = arr.Frequency();
                Console.WriteLine("Частота вхождения каждого элемента в массив");
                foreach (var x in a)
                {
                    Console.WriteLine($" Элемент: {x.Key}, его частота вхождения: {x.Value}");
                }
                Console.WriteLine("Хотите ввести новый массив?\n1 -> Yes\n2 -> No");
                int f = int.Parse(Console.ReadLine());
                if (f == 2)
                    break;
            } while (true);
        }
        static void task2()
        {
            int[] arr = new int[20];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-10000, 10001);
            }
            Console.WriteLine("\nСлучайно сгенерированный массив.");
            StaticClass.PrintArray(arr);
            Console.WriteLine($"Количество искомых пар: {StaticClass.countTask1(arr)}");
            arr = StaticClass.ReadArr(AppDomain.CurrentDomain.BaseDirectory + "ArrayList1.txt");
            Console.WriteLine("\nСчитаный из файла массив.");
            StaticClass.PrintArray(arr);
            Console.WriteLine($"Количество искомых пар: {StaticClass.countTask1(arr)}");

        }
        static int countTask1(int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length - 1; i++)
                count += a[i] % 3 == 0 ? (a[i + 1] % 3 == 0 ? 0 : 1) : (a[i + 1] % 3 == 0 ? 1 : 0);
            return count;
        }
        static void task1()
        {
            int[] arr = new int[20];
            Random rand = new Random();
            Console.WriteLine("Сгенерированный массив:");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-10000, 10001);
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine($"\nКоличество искомых пар: {countTask1(arr)}");

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("********************************");
                Console.WriteLine("Доступные режимы:");
                Console.WriteLine("1 -> 1 задача");
                Console.WriteLine("2 -> 2 задача");
                Console.WriteLine("3 -> 3 задача");
                Console.WriteLine("4 -> 4 задача");
                Console.WriteLine("5 -> 5 задача");
                Console.WriteLine("0 -> Закончить работу программы");
                Console.WriteLine("********************************");
                Console.Write("Выберите режим: ");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 5:
                        /*
                         а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать
                        конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают
                        сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство,
                        возвращающее минимальный элемент массива, свойство, возвращающее максимальный
                        элемент массива, метод, возвращающий номер максимального элемента массива (через
                        параметры, используя модификатор ref или out).
                        **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные
                        в файл.
                        **в) Обработать возможные исключительные ситуации при работе с файлами
                         */
                        task5();
                        break;
                    case 4:
                        /*
                         Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
                        Создайте структуру Account, содержащую Login и Password.
                         */
                        task4();
                        Console.ReadKey();
                        break;
                    case 3:
                        /*
                         а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий
                        массив определенного размера и заполняющий массив числами от начального значения с
                        заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива, метод
                        Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый
                        массив, остается без изменений), метод Multi, умножающий каждый элемент массива на
                        определённое число, свойство MaxCount, возвращающее количество максимальных элементов.
                        б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу
                        библиотеки
                        в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
                         */
                        task3();
                        break;
                    case 2:
                        /*
                         Реализуйте задачу 1 в виде статического класса StaticClass;
                        а) Класс должен содержать статический метод, который принимает на вход массив и решает
                        задачу 1;
                        б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен
                        возвращать массив целых чисел;
                        в)**Добавьте обработку ситуации отсутствия файла на диске.
                         */
                        task2();
                        Console.ReadKey();
                        break;
                    case 1:
                        /*
                         Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые
                        значения от –10 000 до 10 000 включительно. Заполнить случайными числами. Написать
                        программу, позволяющую найти и вывести количество пар элементов массива, в которых только
                        одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих
                        элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
                         */
                        task1();
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.WriteLine("Завершение программы");
                        Console.ReadKey();
                        return;
                }
                Console.Clear();
            }
        }
    }
    
}
