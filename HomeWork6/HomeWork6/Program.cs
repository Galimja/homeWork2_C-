using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    public delegate double Fun(double x, double y);
    public delegate double Fun2(double x);

    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        // Создаем конструктор
        public Student(string firstName, string lastName, string university,
        string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }

    internal class Program
    {
        public static void Table(Fun F, double a, double b)
        {
            double x = a;
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        public static void SaveFunc(Fun2 F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double min, out int minid)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            minid = 0;
            int n = (int)(fs.Length / sizeof(double));
            double[] d = new double[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = bw.ReadDouble();
                if (d[i] < min)
                {
                    min = d[i];
                    minid = i;
                }
            }
            bw.Close();
            fs.Close();
            return d;
        }
        static void printList(List<Student> list)
        {
            Console.WriteLine("Имя|Фамилия|Возраст|Курс\n");
            foreach (Student x in list)
            {
                Console.WriteLine($"{x.firstName} {x.lastName} {x.age} {x.course}");
            }
            Console.WriteLine();
        }
        static void task3()
        {
            int cource56 = 0;
            List<Student> list = new List<Student>();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]),
                        int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    if (int.Parse(s[6]) == 5 || int.Parse(s[6]) == 6)
                        cource56++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    return;

                }
            }
            sr.Close();
            Console.WriteLine($"Количество студентов 5 и 6 курсов: {cource56}");
            int[] a = new int[6];
            foreach (Student x in list)
            {
                if (x.age >= 18 && x.age <= 20)
                    a[x.course - 1]++;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != 0)
                {
                    Console.WriteLine($"На {i + 1} курсе учатся {a[i]} студентов в возрасте от 18 до 20");
                }
            }
            Console.WriteLine("До сортировки:");
            printList(list);
            
            list.Sort(delegate (Student x, Student y)
            {
                if (x.age > y.age)
                    return 1;
                return -1;
            });
            Console.WriteLine("После сортировки по возрасту:");
            printList(list);

            list.Sort(delegate (Student x, Student y)
            {
                if (x.course > y.course)
                    return 1;
                else if (x.course == y.course)
                    if (x.age > y.age)
                        return 1;
                return -1;
            });
            Console.WriteLine("После сортировки по курсу и по возрасту:");
            printList(list);
        }
        static void task2()
        {
            Fun2[] function = new Fun2[]
            {
                x => x * x * x - 3 * x * x + 2,
                x => Math.Sqrt(Math.Abs(x)) * 5,
                x => Math.Log(x * x + 0.5, 2),
                x => Math.Exp(x * x),
                x => 1 / (x * x + 1)
            };
            double min;
            int minid;
            string filename = AppDomain.CurrentDomain.BaseDirectory + "data.txt";
            while (true)
            {
                Console.WriteLine("********************************");
                Console.WriteLine("Доступные Функции:");
                Console.WriteLine("1 -> x * x * x - 3 * x * x + 2");
                Console.WriteLine("2 -> 5 * √|x|");
                Console.WriteLine("3 -> log2(x * x + 0.5)");
                Console.WriteLine("4 -> exp(x * x)");
                Console.WriteLine("5 -> 1 / (x * x + 1)");
                Console.WriteLine("0 -> Закончить работу");
                Console.WriteLine("********************************");
                Console.Write("Выберите функцию: ");
                int n = int.Parse(Console.ReadLine());
                
                if (n == 0)
                {
                    break;
                } else
                {
                    Console.WriteLine("Введите отрезок [a, b] и количество точек n.");
                    Console.Write("Введите а: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Введите b: ");
                    double b = double.Parse(Console.ReadLine());
                    Console.Write("Введите n: ");
                    double N = double.Parse(Console.ReadLine());
                    
                    SaveFunc(function[n - 1], filename, a, b, (b - a) / (N - 1));
                    Load(filename, out min, out minid);
                    
                    Console.WriteLine($"Минимум функциина на отрезке [{a},{b}] достигается в точке {a + minid * (b - a) / (N - 1)} и равен: {min}\n");
                }
                
            }
        }
        static void task1()
        {
            Console.WriteLine("Таблица функции a*x^2:");
            Table(delegate (double x, double y) { return x * y * y; }, -2, 4);
            Console.WriteLine("Таблица функции а * Sin(x):");
            Table((x, y) => x * Math.Sin(y), -3, 3);

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
                Console.WriteLine("0 -> Закончить работу программы");
                Console.WriteLine("********************************");
                Console.Write("Выберите режим: ");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 3:
                        /*
                         Переделать программу Пример использования коллекций для решения следующих задач:
                        а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
                        б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
                        в) отсортировать список по возрасту студента;
                        г) *отсортировать список по курсу и возрасту студента;
                         */
                        task3();
                        Console.ReadKey();
                        break;
                    case 2:
                        /*
                         Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
                        а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке 
                        находить минимум. Использовать массив (или список) делегатов, в котором хранятся различные функции.
                        б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. 
                        Пусть она возвращает минимум через параметр (с использованием модификатора out).
                         */
                        task2();
                        break;
                    case 1:
                        /*
                         Изменить программу вывода таблицы функции так, чтобы можно было передавать функции
                        типа double (double, double). Продемонстрировать работу на функции с функцией a*x^2 и
                        функцией a*sin(x).
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
