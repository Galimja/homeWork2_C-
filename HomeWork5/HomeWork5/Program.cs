using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
// Кабылбеков Галымжан

namespace HomeWork5
{
    public static class Message
    {
        private static string[] separators = { ",", ".", "!", "?", ";", ":", " ", "-", "\n", "\r"};

        public static void PrintWordsN(string message, int n)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length <= n)
                {
                    Console.WriteLine(words[i]);
                }
            }
        }
        public static string DeleteWords(string message, char c)
        {
            string newMessage = "";
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i][words[i].Length - 1] != c)
                {
                    newMessage += words[i] + " ";
                } 
            }
            return newMessage;
        }
        public static string maxLengthWord(string message)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int max = words[0].Length;
            int maxi = 0;
            for (int i = 1; i < words.Length; i++)
            {
                if (max < words[i].Length)
                {
                    max = words[i].Length;
                    maxi = i;
                }
            }
            return words[maxi];
        }
        public static int maxLength(string message)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int max = words[0].Length;
            for (int i = 1; i < words.Length; i++)
            {
                if (max < words[i].Length)
                {
                    max = words[i].Length;
                }
            }
            return max;
        }
        public static string maxLengthWords(string message)
        {
            StringBuilder str = new StringBuilder();
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int max = maxLength(message);
            for (int i = 0; i < words.Length; i++)
            {
                if (max == words[i].Length)
                {
                    str.Append(words[i] + " ");
                }
            }
            return str.ToString();
        }
        public static int Count(string s, string[] words)
        {
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (s == words[i])
                {
                    count++;
                }
            }
            return count;
        }
        public static Dictionary<string, int> FreqMessage(string[] words, string message)
        {
            
            Dictionary<string, int> d = new Dictionary<string, int>();
            string[] Mwords = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                d[words[i]] = Count(words[i], Mwords);
            }
            return d;
        }
    }
    internal class Program
    {
        static (int min1, int min2, int min3) Min3index(double[] d)
        {
            int m1 = 0, m2 = 0, m3 = 0;
            double min1 = 5, min2 = 5, min3 = 5;
            for (int j = 0; j < d.Length; j++)
            {
                if (d[j] <= min1)
                {
                    min3 = min2;
                    min2 = min1;
                    min1 = d[j];
                    m3 = m2;
                    m2 = m1;
                    m1 = j;
                } else if (d[j] <= min2)
                {
                    min3 = min2;
                    min2 = d[j];
                    m3 = m2;
                    m2 = j;
                } else if (d[j] <= min3)
                {
                    min3 = d[j];
                    m3 = j;
                }
            }
            return (m1, m2, m3);
        }
        static void task4()
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + "students.txt";
            if (!File.Exists(file))
                throw new FileNotFoundException();
            StreamReader streamReader = new StreamReader(file);
            int n = int.Parse(streamReader.ReadLine());
            string[] line = new string[n];
            int counter;
            Dictionary<string, double> d = new Dictionary<string, double>();
            double[] mean = new double[n];
            Console.WriteLine("Все школьники:\n");
            for (counter = 0; !streamReader.EndOfStream; counter++)
            {
                line[counter] = streamReader.ReadLine();
                Console.WriteLine(line[counter]);
                string[] words = line[counter].Split(' ');
                line[counter] = words[0] + " " + words[1];
                mean[counter] = (double.Parse(words[2]) + double.Parse(words[3]) + double.Parse(words[4])) / 3;
            }
            var res = Min3index(mean);
            d[line[res.min1]] = mean[res.min1];
            d[line[res.min2]] = mean[res.min2];
            d[line[res.min3]] = mean[res.min3];
            for (int i = 0; i < n; i++)
            {
                if (mean[i] == mean[res.min3] && i != res.min3 && i != res.min2 && i != res.min1)
                    d[line[i]] = mean[i];
            }
            Console.WriteLine("\nХудшие по среднему балу:\n");
            foreach (var x in d)
            {
                Console.WriteLine($"{x.Key} {x.Value}");
            }

        }
        static void task3()
        {
            Console.WriteLine("Введите первую строку:");
            string s1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string s2 = Console.ReadLine();
            int[] index = new int[s2.Length];
            for (int i = 0; i < index.Length; i++)
                index[i] = -1;
            int j;
            bool f = true;
            if (s1.Length == s2.Length)
                for (int i = 0; i < s1.Length; i++)
                {
                    for (j = 0; j < s2.Length; j++)
                    {
                        if (s1[i] == s2[j] && index[j] == -1)
                        {
                            index[j] = 0;
                            break;
                        }
                    }
                    if (j == s2.Length)
                    {
                        f = false;
                    }
                }
            else
                f = false;
            Console.WriteLine(f == true ? "Эти строки являются перестановками" : "Эти строки не перестановки");
            Console.WriteLine("Желаете ввести новые строки?");
            Console.WriteLine("1 -> Yes\n2 -> No");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
                task3();
        }
        static void task2()
        {
            string message = @"Какой-то бессмысленый текст. А что же ещё бессмысленно? Бессмысленна жизнь;
А же жизнь какой-такой
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;";
            Console.WriteLine(message);
            Console.WriteLine("Слова, содержащие не более 4 букв:");
            Message.PrintWordsN(message, 4);
            Console.WriteLine("Удалить из сообщения все слова, которые заканчиваются на заданный символ о:");
            Console.WriteLine(Message.DeleteWords(message, 'о'));
            Console.WriteLine($"Самое длинное слово: {Message.maxLengthWord(message)}");
            Console.WriteLine($"Строка из самых длинных слов: {Message.maxLengthWords(message)}");
            string[] words = new string[] 
            {
                "using",
                "System",
                "Какой", 
                "А",
                "жизнь",
                "такой",
                "же",
                "Но",
                "123",
                "Text"
            };
            Dictionary<string, int> d = Message.FreqMessage(words, message);
            foreach (var x in d)
            {
                Console.WriteLine($" Слово: {x.Key}, его частота вхождения: {x.Value}");
            }
        }
        static void task1_b()
        {
            Console.WriteLine("Проверка с использованием регулярных выражений");
            bool f = true;
            Regex regex = new Regex("^[A-Za-z][A-Za-z0-9]{1,9}$");
            while (f)
            {
                Console.Write("Введите логин: ");
                string log = Console.ReadLine();
                f = !regex.IsMatch(log);
                Console.WriteLine(f == false ? "Логин введен правильно!" : "Неверный логин!");
            }

        }
        static void task1_a()
        {
            Console.WriteLine("Проверка без использования регулярных выражений");
            bool f = true;
            while (f)
            {
                Console.Write("Введите логин: ");
                string log = Console.ReadLine();
                f = false;
                if (log.Length >= 2 && log.Length <= 10)
                {
                    if (char.IsLetter(log[0]))
                    {
                        for (int i = 1; i < log.Length; i++)
                        {
                            if (!char.IsLetterOrDigit(log[i]))
                            {
                                f = true;
                                break;
                            }
                        } 
                    }
                    else
                    {
                        f = true;
                    }
                }
                else
                {
                    f = true;
                }
                Console.WriteLine(f == false ? "Логин введен правильно!" : "Неверный логин!");
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
                Console.WriteLine("4 -> 4 задача");
                Console.WriteLine("0 -> Закончить работу программы");
                Console.WriteLine("********************************");
                Console.Write("Выберите режим: ");
                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    
                    case 4:
                        /*
                          *Задача ЕГЭ.
                        На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
                        школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не
                        превосходит 100, каждая из следующих N строк имеет следующий формат:
                        <Фамилия> <Имя> <оценки>,
                        где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
                        более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
                        пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
                        Пример входной строки:
                        Иванов Петр 4 5 3
                        Требуется написать как можно более эффективную программу, которая будет выводить на экран
                        фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
                        набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

                         */

                        task4();
                        Console.ReadKey();
                        break;
                    case 3:
                        /*
                         *Для двух строк написать метод, определяющий, является ли одна строка перестановкой
                        другой.
                        Например:
                        badc являются перестановкой abcd.
                         */
                        task3();
                        break;
                    case 2:
                        /*Разработать статический класс Message, содержащий следующие статические методы для
                        обработки текста:
                        а) Вывести только те слова сообщения, которые содержат не более n букв.
                        б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
                        в) Найти самое длинное слово сообщения.
                        г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
                        д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в
                        него передается массив слов и текст, в качестве результата метод возвращает сколько раз
                        каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.
                         */
                        task2();
                        Console.ReadKey();
                        break;
                    case 1:
                        /*
                         Создать программу, которая будет проверять корректность ввода логина. Корректным логином
                        будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры,
                        при этом цифра не может быть первой:
                        а) без использования регулярных выражений;
                        б) **с использованием регулярных выражений.
                         */
                        task1_a();
                        task1_b();
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
