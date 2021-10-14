using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Home_0910
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Проверка пароля");
            string password = "";
            string[] pass_decode = { "password123", "admin", "admin1" };
            string pass_possible = "01110000 01100001 01110011 01110011 01110111 01101111 01110010 01100100 00110001 00110010 00110011";
            foreach (string pass in pass_decode)
            {
                string str = "";
                byte[] pass_bytes = Encoding.Unicode.GetBytes(pass);
                foreach (byte bytes in pass_bytes)
                {
                    str += (bytes == 0) ? " " : Convert.ToString(bytes, 2).PadLeft(8, '0');
                }
                if (str[str.Length - 1] == ' ') str = str.Substring(0, str.Length - 1);
                if (Equals(str, pass_possible))
                {
                    password = pass;
                    break;
                }
                Console.WriteLine(pass_possible.Length);
                Console.WriteLine(str.Length);
            }
            Console.WriteLine(!(password == "") ? password : "false");

            Console.WriteLine("\n2. Адская кухня");
            List<string> sentence = Console.ReadLine().Split().ToList<string>();
            for (int i = 0; i < sentence.Count; i++)
            {
                if (sentence[i] != "")
                {
                    if (sentence[i][0] != Char.ToUpper(sentence[i][0]))
                    {
                        sentence[i] = Char.ToUpper(sentence[i][0]) + sentence[i].Substring(1);
                    }
                    sentence[i] += "!!!!";
                }
            }
            Regex regex1 = new Regex("a|а", RegexOptions.IgnoreCase);
            var sentence_new = from word in sentence select regex1.Replace(word, "@");
            Regex regex2 = new Regex("e|i|o|u|y|е|ё|и|о|у|э|ю|я", RegexOptions.IgnoreCase);
            sentence_new = from word in sentence_new select regex2.Replace(word, "*");
            Console.WriteLine(String.Join(" ", sentence_new));

            Console.ReadLine();
        }    
    }
}
