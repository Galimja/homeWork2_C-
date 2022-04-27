using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace HomeWork3
{
    internal class Program
    {
        static void task3()
        {
            Fraction d1, d2;
            Console.WriteLine("Первая дробь.");
            Console.Write("Введите числитель: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Введите знаменатель: ");
            int q = int.Parse(Console.ReadLine());
            d1 = new Fraction(p, q);

            Console.WriteLine("Вторая дробь.");
            Console.Write("Введите числитель: ");
            p = int.Parse(Console.ReadLine());
            Console.Write("Введите знаменатель: ");
            q = int.Parse(Console.ReadLine());
            d2 = new Fraction();
            d2.P = p;
            d2.Q = q;

            bool f = true;
            while (f)
            {
                Console.WriteLine("Выберете режим: \n1 -> сумма\n2 -> разность");
                Console.WriteLine("3 -> произведение\n4 -> деление\n5 -> дроби в десятичной форме");
                Console.WriteLine("0 -> вернуться в предидущее меню");
                Console.WriteLine("-1 -> ввести новые дроби");
                int r = int.Parse(Console.ReadLine());
                switch (r)
                {
                    case 5:
                        Console.WriteLine($"{d1} в десятичной форме: {d1.Decim}");
                        Console.WriteLine($"{d2} в десятичной форме: {d2.Decim}");
                        break;
                    case 4:
                        Console.WriteLine($"Отношение дробей: ({d1}) / ({d2}) = {d1 / d2}");
                        break;
                    case 3:
                        Console.WriteLine($"Произведение дробей: ({d1}) * ({d2}) = {d1 * d2}");
                        break;
                    case 2:
                        Console.WriteLine($"Разность дробей: ({d1}) - ({d2}) = {d1 - d2}");
                        break;
                    case 1:
                        Console.WriteLine($"Сумма дробей: ({d1}) + ({d2}) = {d1 + d2}");
                        break;
                    case 0:
                        f = false;
                        break;
                    case -1:
                        task3();
                        f = false;
                        break;
                }
            }
        }
        static void task2()
        {
            int n;
            bool b;
            Console.WriteLine("Вводите числа (введите 0, чтобы закончить).");
            int sum = 0;
            do
            {
                b = int.TryParse(Console.ReadLine(), out n);
                if (b)
                {
                    if (n % 2 == 1 && n > 0)
                    {
                        sum += n;
                    }
                }
                else
                {
                    n = -1;
                }
            } while (n != 0);
            Console.WriteLine($"Сумма нечетных положительных натуральных чисел = {sum}");

        }
        static void task1_a()
        {
            Complex z1, z2;
            Console.WriteLine("Первое комплексное число.");
            Console.Write("Введите действительную часть: ");
            z1.re = double.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть: ");
            z1.im = double.Parse(Console.ReadLine());
            Console.WriteLine("Второе комплексное число.");
            Console.Write("Введите действительную часть: ");
            z2.re = double.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть: ");
            z2.im = double.Parse(Console.ReadLine());
            bool f = true;
            while (f)
            {
                Console.WriteLine("Выберете режим: \n1 -> сумма\n2 -> разность");
                Console.WriteLine("0 -> вернуться в предидущее меню");
                Console.WriteLine("-1 -> ввести новые комплексные числа");
                int r = int.Parse(Console.ReadLine());
                switch (r)
                {
                    case 2:
                        Console.WriteLine($"Разность комплексных чисел: ({z1}) - ({z2}) = {z1.Minus(z2)}");
                        break;
                    case 1:
                        Console.WriteLine($"Сумма комплексных чисел: ({z1}) + ({z2}) = {z1.Plus(z2)}");
                        break;
                    case 0:
                        f = false;
                        break;
                    case -1:
                        task1_a();
                        f = false;
                        break;
                }
            }

        }
        static void task1_b()
        {
            ComplexClass z1, z2;
            Console.WriteLine("Первое комплексное число.");
            Console.Write("Введите действительную часть: ");
            double re = double.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть: ");
            double im = double.Parse(Console.ReadLine());
            z1 = new ComplexClass(re, im);
            Console.WriteLine("Второе комплексное число.");
            Console.Write("Введите действительную часть: ");
            re = double.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть: ");
            im = double.Parse(Console.ReadLine());
            z2 = new ComplexClass(re, im);
            bool f = true;
            while (f)
            {
                Console.WriteLine("Выберете режим: \n1 -> сумма\n2 -> разность");
                Console.WriteLine("3 -> произведение\n4 -> деление");
                Console.WriteLine("0 -> вернуться в предидущее меню");
                Console.WriteLine("-1 -> ввести новые комплексные числа");
                int r = int.Parse(Console.ReadLine());
                switch (r)
                {
                    case 4:
                        Console.WriteLine($"Отношение комплексных чисел: ({z1}) / ({z2}) = {z1 / z2}");
                        break;
                    case 3:
                        Console.WriteLine($"Произведение комплексных чисел: ({z1}) * ({z2}) = {z1 * z2}");
                        break;
                    case 2:
                        Console.WriteLine($"Разность комплексных чисел: ({z1}) - ({z2}) = {z1 - z2}");
                        break;
                    case 1:
                        Console.WriteLine($"Сумма комплексных чисел: ({z1}) + ({z2}) = {z1 + z2}");
                        break;
                    case 0:
                        f = false;
                        break;
                    case -1:
                        task1_b();
                        f = false;
                        break;
                }
            }
        }
        static void task1()
        {
            while (true)
            {
                Console.WriteLine("Выберете режим: \n1 -> работа со структурой\n2 -> работа с классом");
                Console.WriteLine("0 -> вернуться в предидущее меню");
                int r = int.Parse(Console.ReadLine());
                switch (r)
                {
                    case 1:
                        task1_a();
                        break;
                    case 2:
                        task1_b();
                        break;
                    case 0:
                        return;
                }
            }
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
                         *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
                        Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать
                        программу, демонстрирующую все разработанные элементы класса.
                        * Добавить свойства типа int для доступа к числителю и знаменателю;
                        * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
                        ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
                        ArgumentException("Знаменатель не может быть равен 0");
                        *** Добавить упрощение дробей.
                        */
                        task3();
                        //Console.ReadKey();
                        break;
                    case 2:
                        //а) С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
                        //Требуется подсчитать сумму всех нечётных положительных чисел.Сами числа и сумму
                        //вывести на экран, используя tryParse
                        task2();
                        Console.ReadKey();
                        break;
                    case 1:
                        /*
                         а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.
                            Продемонстрировать работу структуры.
                         б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить
                            работу класса.
                         в) Добавить диалог с использованием switch демонстрирующий работу класса.
                         */
                        task1();
                        //Console.ReadKey();
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
