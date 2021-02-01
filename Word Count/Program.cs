using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string expectedResultPath = Path.Combine("..", "..", "..", "actualResults.txt");
            string[] words = File.ReadAllLines("words.txt");
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                wordCounts.Add(word.ToLower(), 0);
            }
            string text = File.ReadAllText("text.txt").ToLower();
            string[] textWords = text.Split(new string[] 
            { "-", ",", ".", "!", "?", " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in textWords)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
            }
            Dictionary<string, int> sortedWords = wordCounts.OrderByDescending(kvp => kvp.Value)
                .ToDictionary(kvp=>kvp.Key, kvp => kvp.Value);
            List<string> outputLines = sortedWords.Select(kvp => $"{kvp.Key} - {kvp.Value}").ToList();
            File.WriteAllLines(expectedResultPath, outputLines);
        }
    }
}
