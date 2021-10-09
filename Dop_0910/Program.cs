using System;
using System.Collections.Generic;

namespace Dop_0910
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<string> coloumn_0 = new List<string>() {
                "Это текст",
                "Это материал",
                "Это статья",
                "Это публикация",
                "Это данные",
                "Это информация",
                "Материал",
                "Текст",
                "Статья",
                "Публикация",
                "Данные",
                "Информация"
            };
            List<string> coloumn_1 = new List<string>() {
                "сайта",
                "книги",
                "библиотеки",
                "каталога",
                "системы"
            };
            List<string> coloumn_2 = new List<string>() {
                "Univer",
                "Univer.ququ",
                "Универ"
            };
            char separator = ' ';
            char[] lettersRussian = { 'a', 'е', 'о', 'р', 'с', 'у', 'х', 'А', 'Е', 'О', 'Р', 'С', 'Х', 'В', 'К', 'М', 'Т' };
            char[] lettersEnglish = { 'a', 'e', 'o', 'p', 'c', 'y', 'x', 'A', 'E', 'O', 'P', 'C', 'X', 'B', 'K', 'M', 'T' };

            string stringOut = coloumn_0[rnd.Next(coloumn_0.Count)] + separator + coloumn_1[rnd.Next(0, coloumn_1.Count)];
            Dictionary<int, int> letterIndexes = new Dictionary<int, int>();

            for (int i = 0; i < stringOut.Length; i++)
            {
                int index = Array.IndexOf(lettersRussian, stringOut[i]);
                if (index != -1)
                {
                    letterIndexes.Add(i, index);
                }
            }

            int indexRnd = -1, indexOfCharRnd = -1;
            while (indexRnd == -1)
            {
                foreach (int index in letterIndexes.Keys)
                {
                    if (rnd.Next(0, 2) == 0)
                    {
                        indexRnd = index;
                        indexOfCharRnd = letterIndexes[index];
                        break;
                    }
                }
            }
            stringOut = String.Concat(stringOut.Substring(0, indexRnd), lettersEnglish[indexOfCharRnd], stringOut.Substring(indexRnd + 1), separator, coloumn_2[rnd.Next(coloumn_2.Count)]);
            indexRnd = rnd.Next(stringOut.Length);
            stringOut = String.Concat(stringOut.Substring(0, indexRnd), separator, stringOut.Substring(indexRnd));
            Console.WriteLine(stringOut);

            Console.ReadLine();
        }
    }
}
