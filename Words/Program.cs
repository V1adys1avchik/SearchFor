using System;
using System.IO;
using System.Net;

namespace Words
{
    class Program
    {
        // 1. найти заданое слово
        // 2. Найти колво вхождений слов в тексте
        // 3. Текст брать с файла
        // 4. Вывести
        //
        //
        //
        static void Main()
        {
            string word = null;
            string filePath = null; //  C:\Users\vladyslav.avramchuk\My.txt
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Enter path for your .txt file: ");
                filePath = Console.ReadLine();

                if (File.Exists(filePath))
                    check = true;
                else
                {
                    Console.WriteLine("Wrong path. Try again...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            while (true)
            {
                Console.WriteLine("Enter your word: ");

                word = Console.ReadLine();
                TxTWordFinder finder = new TxTWordFinder(filePath);
                finder.Begin(word);

                Console.ReadKey();
                Console.WriteLine(new string('/', 50));
                //test
                WordCounter wordCounter = new WordCounter(filePath);
                wordCounter.Begin();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
