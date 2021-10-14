using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Les_0910
{
    class Program
    {
        static string[] images =
           {
                @"folder\1.png",
                @"folder\1-копия.png",
                @"folder\2.png",
                @"folder\2-копия.png",
                @"folder\3.png",
                @"folder\3-копия.png",
                @"folder\4.png",
                @"folder\4-копия.png",
                @"folder\5.png",
                @"folder\5-копия.png",
                @"folder\6.png",
                @"folder\6-копия.png",
                @"folder\7.png",
                @"folder\7-копия.png",
                @"folder\8.png",
                @"folder\8-копия.png",
                @"folder\9.png",
                @"folder\9-копия.png",
                @"folder\10.png",
                @"folder\10-копия.png",
                @"folder\11.png",
                @"folder\11-копия.png",
                @"folder\12.png",
                @"folder\12-копия.png",
                @"folder\13.png",
                @"folder\13копия.png",
                @"folder\14.png",
                @"folder\14-копия.png",
                @"folder\15.png",
                @"folder\15-копия.png",
                @"folder\16.png",
                @"folder\16-копия.png",
                @"folder\17.png",
                @"folder\17-копия.png",
                @"folder\18.png",
                @"folder\18-копия.png",
                @"folder\19.png",
                @"folder\19-копия.png",
                @"folder\20.png",
                @"folder\20-копия.png",
                @"folder\21.png",
                @"folder\21-копия.png",
                @"folder\22.png",
                @"folder\22-копия.png",
                @"folder\23.png",
                @"folder\23-копия.png",
                @"folder\24.png",
                @"folder\24-копия.png",
                @"folder\25.png",
                @"folder\25-копия.png",
                @"folder\26.png",
                @"folder\26-копия.png",
                @"folder\27.png",
                @"folder\27-копия.png",
                @"folder\28.png",
                @"folder\28-копия.png",
                @"folder\29.png",
                @"folder\29-копия.png",
                @"folder\30.png",
                @"folder\30-копия.png",
                @"folder\31.png",
                @"folder\31-копия.png",
                @"folder\32.png",
                @"folder\32-копия.png",
            };
        static string path = "data.txt";
        struct Student
        {
            public string surname;
            public string name;
            public DateTime dateOfBirth;
            public Exam exam;
            public int score;
            public Student(string surname, string name, DateTime dateOfBirth, Exam exam, int score)
            {
                this.surname = surname;
                this.name = name;
                this.dateOfBirth = dateOfBirth;
                this.exam = exam;
                this.score = score;
            }
            public override string ToString()
            {
                return $"{surname} {name} {dateOfBirth:d} {exam} {score}";
            }
        }
        enum Exam
        {
            Physics,
            Informatics,
            ForeignLanguage
        }
        enum Post
        {
            Teacher,
            Сleaner,
            Manager
        }
        enum Color
        {
            Green,
            Red,
            Purple,
            Blue,
            Grey,
            White,
            Black,
            Brown,
            Pink
        }
        struct Worker
        {
            public string name;
            public Post post;
            public int cheek;
            public bool stupidity;

            public Worker(string name, Post post, int cheek, bool stupidity)
            {
                this.name = name;
                this.post = post;
                this.cheek = cheek;
                this.stupidity = stupidity;
            }
            public override string ToString()
            {
                return $"[{name}, {post}, {cheek}, {stupidity}]";
            }
        }
        class Table
        {
            public int serial;
            public Color color;
            public List<Worker> places = new List<Worker>();
            public Table(int serial, Color color, List<Worker> places)
            {
                this.serial = serial;
                this.color = color;
                this.places = places;
            }
            public override string ToString()
            {
                return $"{serial}-{color}: {String.Join(" ", places)}";
            }
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            /*
            Console.WriteLine("Задание 1.");
            Console.WriteLine(CompareTeams(new int[] { 1, 5, 6 }, new int[] { 5, 0, 6 }));

            Console.WriteLine("\nЗадание 2.");
            Console.WriteLine("Изначальный List:\n" + String.Join("\n", images));
            for(int i = 0; i < images.Length; i++)
            {
                if (rnd.Next(0, 8) != 0)
                {
                    int odd = rnd.Next(images.Length);
                    Swap(images, i, odd, images[i], images[odd]);
                }
            }
            Console.WriteLine("\nПеремешанный:\n" + String.Join("\n", images));

            Console.WriteLine("\nЗадание 3.");
            Dictionary<string, Student> students = new Dictionary<string, Student>();
            try
            {
                StreamReader sr = new StreamReader(path);
                string[] str_arr = sr.ReadToEnd().Split(Convert.ToChar("\n"));
                sr.Close();
                foreach(string str in str_arr)
                {
                    if (str != "")
                    {
                        string[] items = str.Split();
                        students.Add(items[0].ToLower(), new Student(items[0], items[1], Convert.ToDateTime(items[2]), (Exam)Convert.ToInt32(items[3]), Convert.ToInt32(items[4])));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                students.Clear();
                AddAll(students);
            }
            catch (IndexOutOfRangeException)
            {
                students.Clear();
                AddAll(students);
            }
            catch (FormatException)
            {
                students.Clear();
                AddAll(students);
            }
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Меню:\nНовый студент(new)***************Удалить(del)***************Сортировать(sort)***************Выйти(ex)");
                string input = Console.ReadLine();
                if (String.Equals(input.ToLower(), "новый студент") || String.Equals(input.ToLower(), "new"))
                {
                    Console.Write("Фамилия: ");
                    string item1 = Console.ReadLine();
                    Console.Write("Имя: ");
                    string item2 = Console.ReadLine();
                    bool tried = true;
                    DateTime item3 = new DateTime();
                    Console.Write("Дата рождения (_дд.мм.гггг_): ");
                    try
                    {
                        item3 = Convert.ToDateTime(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка ввода. Попробуйте ещё раз.");
                        tried = false;
                    }
                    if (tried)
                    {
                        Console.Write("Экзамен (0 - физика, 1 - информатика, 2 - иностранный язык): ");
                        int item4, item5;
                        if (int.TryParse(Console.ReadLine(), out item4))
                        {
                            if (item4 >= 0 && item4 <= 2)
                            {
                                Console.Write("Сумма баллов: ");
                                if (int.TryParse(Console.ReadLine(), out item5))
                                {
                                    students.Add(item1.ToLower(), new Student(item1, item2, item3, (Exam)item4, item5));
                                    WriteAllToPath(students);
                                    Console.WriteLine("Успешно добавлено.");
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка ввода. Попробуйте ещё раз.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка ввода. Попробуйте ещё раз.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка ввода. Попробуйте ещё раз.");
                        }
                    }
                }
                else if (String.Equals(input.ToLower(), "удалить") || String.Equals(input.ToLower(), "del"))
                {
                    Console.Write("Удалить (_фамилия_): ");
                    input = Console.ReadLine().ToLower();
                    if (students.ContainsKey(input))
                    {                      
                        students.Remove(input);
                        WriteAllToPath(students);
                        Console.WriteLine("Успешно удалено.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода. Попробуйте ещё раз.");
                    }
                }
                else if (String.Equals(input.ToLower(), "сортировать") || String.Equals(input.ToLower(), "sort"))
                {
                    List<int> scores = new List<int>();
                    string[] keys = new string[students.Count];
                    students.Keys.CopyTo(keys, 0);
                    foreach (Student student in students.Values)
                    {
                        scores.Add(student.score);
                    }
                    SortStep(scores, keys, 0, scores.Count - 1);
                    foreach (string key in keys)
                    {
                        Console.WriteLine(students[key]);
                    }
                    Console.WriteLine("Успешно отсортирвано.");
                }
                else if (String.Equals(input.ToLower(), "выйти") || String.Equals(input.ToLower(), "ex"))
                {
                    Console.WriteLine("Вы вышли.");
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Попробуйте ещё раз.");
                }                
            }
            */
            Console.WriteLine("\nЗадание 4.");
            Console.WriteLine("Количество работников и столов: ");
            int n, t;
            while (!int.TryParse(Console.ReadLine(), out n) || !int.TryParse(Console.ReadLine(), out t))
            {
                Console.WriteLine("Ошибка ввода. Попробуйте ещё раз.");
            }

            // создаю работников
            List<Worker> workers = new List<Worker>();
            Console.WriteLine("Порядок до обгонов:");
            for (int i = 0; i < n; i++)
            {
                workers.Add(new Worker($"_{rnd.Next(0, 1000)}_", (Post)rnd.Next(0, 3), rnd.Next(0, 11), Convert.ToBoolean(rnd.Next(0, 2))));
                Console.WriteLine(workers[i]);
            }

            // создаю столы
            Stack<Table> tables = new Stack<Table>();
            for (int i = t; i > 0; i--)
            {
                tables.Push(new Table(i, (Color)rnd.Next(0, 9), new List<Worker>()));
            }

            // создаю связи знакомств
            bool[,] mates = new bool[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        mates[i, j] = true;
                    }
                    else if (j < i)
                    {
                        mates[i, j] = mates[j, i];
                    }
                    else
                    {
                        mates[i, j] = Convert.ToBoolean(rnd.Next(0, 2));
                    }
                    Console.Write(Convert.ToInt32(mates[i, j]) + " ");
                }
                Console.WriteLine();
            }

            // расстановка в очереди, где i = 0 - её начало, i = n - конец
            for (int i = 0; i < n; i++)
            {
                if (workers[i].stupidity)
                {
                    if (workers[i].cheek == 0)
                    {
                        if (i >= 1)
                        {
                            workers.Insert(i - 1, workers[i]);
                            workers.RemoveAt(i + 1);
                        }
                    }
                    else
                    {
                        if (i >= workers[i].cheek)
                        {
                            workers.Insert(workers[i].cheek, workers[i]);
                            workers.RemoveAt(i + 1);
                        }
                        else
                        {
                            workers.Insert(0, workers[i]);
                            workers.RemoveAt(i + 1);
                        }
                    }
                }
            }
            Console.WriteLine($"После обгонов:\n{String.Join("\n", workers)}");

            // рассадка по столам
            for (int i = 0; i < n; i++) // перебираю всех работников
            {
                bool done = false;
                for (int j = 0; j < tables.Count; j++) // перебираю все столы
                {
                    foreach (Worker place in tables.ElementAt(j).places) // перебираю занятые места конкретного стола
                    {
                        if (mates[i, Array.IndexOf(workers.ToArray(), place)]
                            && (tables.ElementAt(j).places.Count < 3 || tables.ElementAt(j).places.Count == 3 && workers[i].cheek > 0)
                            && !workers[i].stupidity)
                            // если работники знакомы и если искомое условие верно
                        {
                            tables.ElementAt(j).places.Add(workers[i]); // то добавляю туда нового работника
                            done = true;
                            break; // простите
                        }
                    }
                    if (done) break; // простите ещё раз...(
                }
                if (!done) // если он всё же не сел
                {
                    for (int j = 0; j < tables.Count; j++) // снова перебираю столы
                    {
                        if (tables.ElementAt(j).places.Count == 0)
                        {
                            tables.ElementAt(j).places.Add(workers[i]);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"Что же получается в итоге:\n{String.Join("\n", tables)}");

            Console.ReadLine();
        }

        static string CompareTeams(int[] team1, int[] team2)
        {
            string team1_str = String.Join("", team1);
            string team2_str = String.Join("", team2);
            int n1 = team1_str.Length, n2 = team2_str.Length;
            team1_str.Replace("5", "");
            team2_str.Replace("5", "");
            if (n1 - team1_str.Length == n2 - team1_str.Length)
            {
                return "Drinks All Round! Free Beers on Bjorg!";
            }
            else
            {
                return "Ой, Бьорг - пончик! Ни для кого пива!";
            }
        }
        static void Swap(string[] array, int i1, int i2, string value1, string value2)
        {
            array[i1] = value2;
            array[i2] = value1;
        }
        static void Swap(List<int> array, int i1, int i2, int value1, int value2)
        {
            array[i1] = value2;
            array[i2] = value1;
        }
        static void Swap(Worker[] array, int i1, int i2, Worker value1, Worker value2)
        {
            array[i1] = value2;
            array[i2] = value1;
        }
        static void AddAll(Dictionary<string, Student> students)
        {
            Student new1 = new Student();
            new1.surname = "Арещенко";
            new1.name = "Мария";
            new1.score = 278;
            new1.dateOfBirth = new DateTime(2003, 9, 27);
            new1.exam = (Exam)1;
            Student new2 = new Student();
            new2.surname = "Шипило";
            new2.name = "Анна";
            new2.score = 270;
            new2.exam = (Exam)0;
            new2.dateOfBirth = new DateTime(2002, 12, 24);
            Student new3 = new Student();
            new3.surname = "Игуменов";
            new3.name = "Илья";
            new3.score = 263;
            new3.exam = (Exam)1;
            new3.dateOfBirth = new DateTime(2003, 10, 28);
            Student new4 = new Student();
            new4.surname = "Каримов";
            new4.name = "Ришат";
            new4.score = 262;
            new4.exam = (Exam)1;
            new4.dateOfBirth = new DateTime(2000, 4, 30);
            Student new5 = new Student();
            new5.surname = "Шакирова";
            new5.name = "Индира";
            new5.score = 259;
            new5.exam = (Exam)1;
            new5.dateOfBirth = new DateTime(2003, 7, 2);
            Student new6 = new Student();
            new6.surname = "Зиастинов";
            new6.name = "Алмаз";
            new6.score = 258;
            new6.exam = (Exam)0;
            new6.dateOfBirth = new DateTime(2003, 3, 10);
            Student new7 = new Student();
            new7.surname = "Зиннатуллина";
            new7.name = "Регина";
            new7.score = 257;
            new7.exam = (Exam)2;
            new7.dateOfBirth = new DateTime(2003, 6, 3);
            Student new8 = new Student();
            new8.surname = "Чернятов";
            new8.name = "Адель";
            new8.score = 252;
            new8.dateOfBirth = new DateTime(2003, 2, 16);
            new8.exam = (Exam)1;
            Student new9 = new Student();
            new9.surname = "Захарова";
            new9.name = "Диана";
            new9.score = 251;
            new9.dateOfBirth = new DateTime(2003, 5, 27);
            new9.exam = (Exam)0;
            Student new10 = new Student();
            new10.surname = "Тимофеева";
            new10.name = "Анастасия";
            new10.score = 250;
            new10.dateOfBirth = new DateTime(2003, 12, 14);
            new10.exam = (Exam)2;
            students.Add(new1.surname.ToLower(), new1);
            students.Add(new2.surname.ToLower(), new2);
            students.Add(new3.surname.ToLower(), new3);
            students.Add(new4.surname.ToLower(), new4);
            students.Add(new5.surname.ToLower(), new5);
            students.Add(new6.surname.ToLower(), new6);
            students.Add(new7.surname.ToLower(), new7);
            students.Add(new8.surname.ToLower(), new8);
            students.Add(new9.surname.ToLower(), new9);
            students.Add(new10.surname.ToLower(), new10);
            WriteAllToPath(students);
        }
        static void WriteAllToPath(Dictionary<string, Student> students)
        {
            string output = "";
            foreach (Student student in students.Values)
            {
                output += student + "\n";
            }
            StreamWriter sw = new StreamWriter(path);
            sw.Write(output);
            sw.Close();
        }
        static void SortStep(List<int> array, string[] array2, int start, int end)
        {
            int pivot = (start + end) / 2, start0 = start, end0 = end;
            while (start < end)
            {
                while (array[start] <= array[pivot] && start < pivot) start++;
                while (array[pivot] <= array[end] && pivot < end) end--;
                if (start == end) break;
                else
                {
                    Swap(array, start, end, array[start], array[end]);
                    Swap(array2, start, end, array2[start], array2[end]);
                    if (start == pivot) pivot = end;
                    else if (end == pivot) pivot = start;
                }
            }
            if (pivot - start0 > 1) SortStep(array, array2, start0, pivot - 1);
            if (end0 - pivot > 1) SortStep(array, array2, pivot + 1, end0);
        }
    }
}
