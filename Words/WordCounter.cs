using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words
{
    class WordCounter
    {
        private static string filePath = null;

        public WordCounter(string path)
        {
            filePath = path;
        }

        public WordCounter() {}

        public void Begin()
        {
            var strs = File.ReadAllLines(filePath);
            GetAmountOfWords(strs);
        }
        private void GetAmountOfWords(string[] st)
        {
            //List<string> tempList = new List<string>();
            Dictionary<string, int> tempDictionary = new Dictionary<string, int>();
            foreach (var str in st)
            {

                var tempStr = str.ToLower()
                                        .Replace(",",String.Empty)
                                        .Replace("\"",String.Empty)
                                        .Replace(";",String.Empty)
                                        .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in tempStr)
                {
                    string correctword = word.EndsWith('.') ? word.Replace(".", String.Empty) : word; // убарть слова по типу: framework. set. the.    
                    if (!tempDictionary.ContainsKey(correctword))                                                   // но не трогать .net  3.0  2.0  asp.net
                    {
                        tempDictionary.TryAdd(correctword, 1);
                    }
                    else
                    {
                        tempDictionary[correctword] = tempDictionary[correctword] + 1;  // можно  и через +=
                    }
                    //tempList.Add(correctword);
                }
            }

            

            foreach (KeyValuePair<string, int> keyValue in tempDictionary.OrderByDescending(key => key.Value))
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }
    }
}
