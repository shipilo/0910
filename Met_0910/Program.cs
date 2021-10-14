using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Met_0910
{
    class Program
    {
        static string vow = "aeiouyаеёиоуэюя", cons = "bcdfghjklmnpqrstvwxzбвгджзклмнпрстфхцчшщ";
        static string[] mounths = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        static void Main(string[] args)
        {
            Random rnd = new Random();
            /*
            Console.WriteLine("Упражнение 6.1");
            StreamReader sr = new StreamReader(args[0]);
            char[] text = sr.ReadToEnd().ToCharArray();
            sr.Close();            
            int vow_count, cons_count;
            CountVowCons(text, out vow_count, out cons_count);
            Console.WriteLine($"Гласные: {vow_count}, согласные: {cons_count}");

            Console.WriteLine("\nУпражнение 6.2");
            int w1 = 0, w2 = 0, h = 0;
            double[,] matrix1, matrix2;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Размер 1 матрицы (_высота_ширина_): ");
                if (int.TryParse(Console.ReadLine(), out h) && int.TryParse(Console.ReadLine(), out w1))
                {                    
                    Console.Write("Размер 2 матрицы (_ширина_): ");
                    if (int.TryParse(Console.ReadLine(), out w2))
                    {                        
                        loop = false;
                    }
                }
            }
            matrix1 = new double[h, w1];
            Console.WriteLine("Вводите числа через интер для 1 матрицы (строка <=> 0):");
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w1; j++)
                {
                    if (!Double.TryParse(Console.ReadLine(), out matrix1[i, j]))
                    {
                        matrix1[i, j] = 0;
                    }
                }
            }
            matrix2 = new double[w1, w2];
            Console.WriteLine("Вводите числа через интер для 2 матрицы (строка <=> 0):");
            for (int i = 0; i < w1; i++)
            {
                for (int j = 0; j < w2; j++)
                {
                    if (!Double.TryParse(Console.ReadLine(), out matrix2[i, j]))
                    {
                        matrix2[i, j] = 0;
                    }
                }
            }
            Console.WriteLine($"Результат:\n{PrintMatrix(MultiplyMatrix(matrix1, matrix2))}");

            Console.WriteLine("\nД/з 6.3");
            int[,] temperature = new int[12, 30];
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = rnd.Next(-30, 30);
                }
            }
            

            Console.WriteLine("Д/з 6.1");
            StreamReader sr = new StreamReader(args[0]);
            List<char> text = sr.ReadToEnd().ToCharArray().ToList();
            sr.Close();
            int vow_count, cons_count;
            CountVowCons(text, out vow_count, out cons_count);
            Console.WriteLine($"Гласные: {vow_count}, согласные: {cons_count}");
            */
            Console.WriteLine("\nД/з 6.2");
            int w1 = 0, w2 = 0, h = 0;
            LinkedList<LinkedList<double>> matrix1 = new LinkedList<LinkedList<double>>(), matrix2 = new LinkedList<LinkedList<double>>();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Размер 1 матрицы (_высота_ширина_): ");
                if (int.TryParse(Console.ReadLine(), out h) && int.TryParse(Console.ReadLine(), out w1))
                {
                    Console.Write("Размер 2 матрицы (_ширина_): ");
                    if (int.TryParse(Console.ReadLine(), out w2))
                    {
                        loop = false;
                    }
                }
            }
            Console.WriteLine("Вводите числа через пробел, а строки через интер для 1 матрицы:");
            for (int i = 0; i < h; i++)
            {
                try
                {
                    List<double> row = new List<double>();
                    Console.ReadLine().Split().ToList().ForEach(item => row.Add(Convert.ToDouble(item)));
                    if (row.Count != w1)
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                    else
                    {
                        matrix1.AddLast(new LinkedList<double>(row));
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода.");
                }
            }
            Console.WriteLine("Вводите числа через пробел, а строки через интер для 2 матрицы:");
            for (int i = 0; i < w1; i++)
            {
                try
                {
                    List<double> row = new List<double>();
                    Console.ReadLine().Split().ToList().ForEach(item => row.Add(Convert.ToDouble(item)));
                    if (row.Count != w2)
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }
                    else
                    {
                        matrix2.AddLast(new LinkedList<double>(row));
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода.");
                }
            }
            Console.WriteLine($"Результат:\n{PrintMatrix(MultiplyMatrix(matrix1, matrix2))}");


            Console.WriteLine("\nД/з 6.3");
            Dictionary<string, int[]> temperature = new Dictionary<string, int[]>();
            for (int i = 1; i <= 12; i++)
            {
                int[] degrees = new int[30];
                for (int j = 0; j < 30; j++)
                {
                    degrees[i] = rnd.Next(-30, 30);
                }
                switch (i) // либо через массив mounths
                {
                    case 1:
                        temperature.Add("Январь", degrees);
                        break;
                    case 2:
                        temperature.Add("Февраль", degrees);
                        break;
                    case 3:
                        temperature.Add("Март", degrees);
                        break;
                    case 4:
                        temperature.Add("Апрель", degrees);
                        break;
                    case 5:
                        temperature.Add("Май", degrees);
                        break;
                    case 6:
                        temperature.Add("Июнь", degrees);
                        break;
                    case 7:
                        temperature.Add("Июль", degrees);
                        break;
                    case 8:
                        temperature.Add("Август", degrees);
                        break;
                    case 9:
                        temperature.Add("Сентябрь", degrees);
                        break;
                    case 10:
                        temperature.Add("Октябрь", degrees);
                        break;
                    case 11:
                        temperature.Add("Ноябрь", degrees);
                        break;
                    case 12:
                        temperature.Add("Декабрь", degrees);
                        break;
                }
            }
            double[] means = MeansOfMounths(temperature);
            Array.Sort(means);
            Console.WriteLine($"Отсортированные средние значения равны: {String.Join(" ", means)}");


        }

        static void CountVowCons(char[] text, out int count1, out int count2)
        {
            count1 = 0;
            count2 = 0;            
            foreach (char letter in text)
            {
                if (vow.Contains(letter.ToString()))
                {
                    count1++;
                }
                else if (cons.Contains(letter.ToString()))
                {
                    count2++;
                }
            }
        }
        static void CountVowCons(List<char> text, out int count1, out int count2)
        {
            count1 = 0;
            count2 = 0;
            foreach (char letter in text)
            {
                if (vow.Contains(letter.ToString()))
                {
                    count1++;
                }
                else if (cons.Contains(letter.ToString()))
                {
                    count2++;
                }
            }
        }
        static double[,] MultiplyMatrix(double[,] matrix1, double[,] matrix2) 
        {
            double[,] matrix = new double[matrix1.GetLength(0), matrix2.GetLength(1)];

            for(int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    double sum = 0;
                    for(int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    matrix[i, j] = sum;
                }                
            }

            return matrix;
        }
        static LinkedList<LinkedList<double>> MultiplyMatrix(LinkedList<LinkedList<double>> matrix1, LinkedList<LinkedList<double>> matrix2)
        {
            LinkedList<LinkedList<double>> matrix = new LinkedList<LinkedList<double>>();
            for(int i = 0; i < matrix1.Count; i++)
            {
                matrix.AddLast(new LinkedListNode<LinkedList<double>>(new LinkedList<double>()));
            }
            LinkedListNode<LinkedList<double>> list = matrix.First;
            //list.Value.AddLast(0);
            LinkedListNode<double> num = list.Value.First;

            foreach (LinkedList<double> list1 in matrix1)
            {
                LinkedListNode<LinkedList<double>> list2 = matrix2.First;
                LinkedListNode<double> num2 = list2.Value.First;

                while (num2 != null)
                {
                    double sum = 0;
                    foreach (double num1 in list1)
                    {
                        if (list2 != null)
                        {
                            sum += num1 * num2.Value;
                            list2 = list2.Next;
                        }                                                
                    }
                    //num.Value = sum;
                    list.Value.AddLast(sum);
                    list = list.Next;
                    num2 = num2.Next;
                }
                num = num.Next;
            }

            return matrix;
        }
        static string PrintMatrix(double[,] matrix)
        {
            string print = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    print += matrix[i, j].ToString();
                    if (j != matrix.GetLength(1) - 1) print += " ";
                }
                if (i != matrix.GetLength(0) - 1) print += "\n";
            }
            return print;
        }
        static string PrintMatrix(LinkedList<LinkedList<double>> matrix)
        {
            string print = "";
            foreach(LinkedList<double> list in matrix)
            {
                print += String.Join(" ", list) + "\n";
            }
            return print;
        }
        static double[] MeansOfMounths(Dictionary<string, int[]> year)
        {
            double[] means = new double[year.Keys.Count];
            for (int i = 0; i < year.Keys.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < year.Values.Count; j++)
                {
                    sum += year[mounths[i]][j];
                }
                means[i] = Math.Round(sum / year.Values.Count, 1);
            }
            return means;
        }
    }
}
