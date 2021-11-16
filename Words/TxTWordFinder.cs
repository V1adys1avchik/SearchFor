using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Words
{
    class TxTWordFinder
    {
        //
        private static string filePath = null;

        public TxTWordFinder(string path)
        {
            filePath = path;
        }

        public TxTWordFinder(){}

        public void Begin(string _word)
        {
            int counter = 0;
            foreach (var line in File.ReadLines(filePath))
            {
                counter++;

                var indexes = AllIndexesOf(line, _word).ToList();
                if (indexes.Count > 0)
                {
                    foreach (var index in indexes)
                    {
                        Console.WriteLine($"Word {_word} was found: line - {counter} | position - {index + 1}");
                    }
                }
                else
                {
                    Console.WriteLine($"Word {_word} wasn't found in line - {counter}");
                    //break;
                }
            }
        }

        private IEnumerable<int> AllIndexesOf(string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string value to find may not be empty");
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    break;
                yield return index;
            }
        }
    }
}
