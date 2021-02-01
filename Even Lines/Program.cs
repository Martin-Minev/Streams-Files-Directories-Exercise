using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../text.txt";
            string pattern = @"[-.,!?]";
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                using StreamWriter writer = new StreamWriter("output.txt");
                int counter = 0;
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter++ % 2 == 0)
                    {
                        string replacedLine = Regex.Replace(line, pattern, "@");
                        string[] words = replacedLine.Split(new string[]{ " " }, StringSplitOptions.RemoveEmptyEntries);

                        writer.WriteLine(string.Join(" ", words.Reverse()));    
                    }
                }
            };
        }
    }
}
