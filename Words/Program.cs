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
            string filePath = null; 
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
            TxTWordFinder finder = new TxTWordFinder(filePath);
            WordCounter wordCounter = new WordCounter(filePath);

            while (true)
            {
                Console.WriteLine("Enter your word: ");

                word = Console.ReadLine();
                finder.Begin(word);

                Console.ReadKey();
                Console.WriteLine(new string('/', 50));
                //test
                wordCounter.Begin();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
