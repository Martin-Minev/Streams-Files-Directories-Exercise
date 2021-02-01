using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputFilePath = Path.Combine("..", "..", "..", "output.txt");
            string[] lines = File.ReadAllLines("text.txt");
            List<char> punctuationMarks = new List<char>() { '-', ',', '.', '!', '?', '\'' };
            List<string> newLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int lettersCount = 0;
                int marksCount = 0;
                foreach (char item in line)
                {
                    if (char.IsLetter(item))
                    {
                        lettersCount++;
                    }
                    else if (punctuationMarks.Contains(item))
                    {
                        marksCount++;
                    }
                }
                string newLine = $"Line {i + 1}: {line} ({lettersCount})({marksCount})";
                newLines.Add(newLine);
                Console.WriteLine(newLine);
               // File.AppendAllText(outputFilePath, newLine + Environment.NewLine);
            }
            File.WriteAllLines(outputFilePath, newLines);
        }
    }
}
