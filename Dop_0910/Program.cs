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

            string stringOut = coloumn_0[rnd.Next(0, coloumn_0.Count)] + separator + coloumn_1[rnd.Next(0, coloumn_1.Count)];

        }
    }
}
