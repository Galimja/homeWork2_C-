using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 //Кабылбеков Галымжан

namespace HomeWork2
{
    internal class Program
    {
        /// <summary>
        /// Минимум из трех чисел
        /// </summary>
        /// <param name="a">1 число</param>
        /// <param name="b">2 число</param>
        /// <param name="c">3 число</param>
        /// <returns>минимальное значение</returns>
        static double Min_3(double a, double b, double c)
        {
            return a > b ? (b > c ? c : b) : (a < c ? a : c);
        }

        /// <summary>
        /// Подсчет количества цифр в числе
        /// </summary>
        /// <param name="n">число</param>
        /// <returns>количество цифр</returns>
        static int NumCount(long n)
        {
            if (n == 0) {
                return 0;
            }
            return NumCount(n / 10) + 1;
        }
        
        static bool chekLP(string login, string password)
        {
            return login == "root" && password == "GeekBrains";
        }

        /// <summary>
        /// Сумма цифр числа
        /// </summary>
        /// <param name="n">число</param>
        /// <returns>сумму цифр</returns>
        static long sumNumbers(long n)
        {
            if (n == 0)
                return 0;
            return sumNumbers(n / 10) + n % 10;
        }

        static bool isGoodNumber(long n)
        {
            return n % sumNumbers(n) == 0 ? true : false;
        }

        /// <summary>
        /// Сумма чисел от а до б
        /// </summary>
        /// <param name="a">число а</param>
        /// <param name="b">число б</param>
        /// <returns>сумму чисел</returns>
        static int SumOfNum(int a, int b)
        {
            if (a == b)
            {
                return b;
            }
            return SumOfNum(a + 1, b) + a;

        }
        
        /// <summary>
        /// вывод чисел от а до б
        /// </summary>
        /// <param name="a">число а</param>
        /// <param name="b">число б</param>
        static void outputNumbers(int a, int b)
        {
            Console.Write($"{a} ");
            if (a == b)
            {
                return;
            }
            outputNumbers(a + 1, b);
        }

        static void task7()
        {
            Console.Write("Введите чило а: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите чило b: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Вывод чисел от а до b:");
            outputNumbers(a, b);
            Console.WriteLine($"\nСумма чисел от а до b равна: {SumOfNum(a, b)}");
        }

        static void task6()
        {
            DateTime start = DateTime.Now;
            int cout = 0;
            for (long i = 1; i < 1e+9; i++)
            {
                if (isGoodNumber(i)) { 
                    cout++; 
                }
            }
            DateTime end = DateTime.Now;
            Console.WriteLine($"Количество хороших чисел {cout}\nВремя потораченное на расчеты {end - start}");
        }

        static void task5()
        {
            Console.WriteLine("Введите вес в кг:");
            double m = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост в метрах:");
            double h = Convert.ToDouble(Console.ReadLine());
            double I = m / (h * h);
            Console.WriteLine("Ваш индекс массы тела {0:F2}.", I);
            if (I > 18.5 && I < 25) {
                Console.WriteLine("ИМТ соответсвует норме!");
            } else if (I >= 25) {
                double ves = m - 25 * (h * h);
                Console.WriteLine("Вам нужно сбросить {0:F2} кг", ves);
            } else {
                double ves = 18.5 * (h * h) - m;
                Console.WriteLine("Вам нужно набрать {0:F2} кг", ves);
            }
        }
        
        static void task4()
        {
            int i = 3;
            string login, password;
            do {
                string ending = "попытки";
                if (i == 1) {
                    ending = "попытка";
                }
                Console.WriteLine($"Введите логин и пароль, у вас {i} {ending}.");
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();
                if (chekLP(login, password))
                {
                    Console.WriteLine("Авторизация прошла успешно!");
                    return;
                } else
                {
                    i--;
                    Console.WriteLine($"Вы ввели неверный логин или пароль");
                }
            } while (i > 0);
            Console.WriteLine("Вы потратили все попытки :(");
        }
        
        static void task3()
        {
            Console.WriteLine("Вводите числа (введите 0 чтобы завершить ввод чисел): ");
            int sum = 0;
            int a;
            do {
                a = int.Parse(Console.ReadLine());
                if (a % 2 == 1 && a > 0) {
                    sum += a;
                }
            } while (a != 0);
            Console.WriteLine($"Сумма всех нечетных положительных чилел равна {sum}");
        }

        static void task2()
        {
            Console.Write("Введите число");
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine($"Количество цифр в чиле {n} равно: {NumCount(n)}");
        }

        static void task1()
        {       
            Console.WriteLine("Введите 3 числа");
            Console.Write("Первое число: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Второе число: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Третье число: ");
            double c = double.Parse(Console.ReadLine());

            Console.WriteLine($"Минимум равен: {Min_3(a, b, c)}");
            
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
                Console.WriteLine("6 -> 6 задача");
                Console.WriteLine("7 -> 7 задача");
                Console.WriteLine("0 -> Закончить работу программы");
                Console.WriteLine("********************************");
                Console.Write("Выберите режим: ");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 7:
                        //a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
                        //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b
                        task7();
                        Console.ReadKey();
                        break;
                    case 6:
                        /*
                        *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000
                        000. «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать
                        подсчёт времени выполнения программы, используя структуру DateTime
                        */
                        task6();
                        Console.ReadKey();
                        break;
                    case 5:
                        /*
                        а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
                        массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
                        б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.*/
                        task5();
                        Console.ReadKey();
                        break;
                    case 4:
                        /*Реализовать метод проверки логина и пароля. 
                         * На вход метода подается логин и пароль. 
                         * На выходе истина, если прошел авторизацию, и ложь, 
                         * если не прошел (Логин: root, Password: GeekBrains). 
                         * Используя метод проверки логина и пароля, 
                         * написать программу: пользователь вводит логин и пароль, 
                         * программа пропускает его дальше или не пропускает. 
                         * С помощью цикла do while ограничить ввод пароля тремя попытками.*/
                        task4();
                        Console.ReadKey();
                        break;
                    case 3:
                        //С клавиатуры вводятся числа, пока не будет введен 0.
                        //Подсчитать сумму всех нечетных положительных чисел
                        task3();
                        Console.ReadKey();
                        break;
                    case 2:
                        //Написать метод подсчета количества цифр числа
                        task2();
                        Console.ReadKey();
                        break;
                    case 1:
                        //Написать метод, возвращающий минимальное из трёх чисел
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
