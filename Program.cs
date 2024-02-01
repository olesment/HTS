using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string scrambledWordsFilePath = ""; 
        string wordListFilePath = ""; 

        string[] scrambledWords = File.ReadAllLines(scrambledWordsFilePath);
        string[] wordList = File.ReadAllLines(wordListFilePath);

        string[] matchedWords = FindMatchingWords(scrambledWords, wordList);

        string csvOutput = string.Join(",", matchedWords);
        Console.WriteLine(csvOutput);
    }

    static string[] FindMatchingWords(string[] scrambledWords, string[] wordList)
    {
        string[] matchedWords = new string[scrambledWords.Length];
        int matchCount = 0;

        foreach (string scrambledWord in scrambledWords)
        {
            foreach (string word in wordList)
            {
                if (IsWordMatch(scrambledWord, word))
                {
                    matchedWords[matchCount++] = word;
                    break; // Found a match, no need to check other words
                }
            }
        }

        // Resize the array to the number of matches found
        Array.Resize(ref matchedWords, matchCount);
        return matchedWords;
    }

    static bool IsWordMatch(string scrambledWord, string word)
    {
        char[] scrambledArray = scrambledWord.ToCharArray();
        char[] wordArray = word.ToCharArray();

        Array.Sort(scrambledArray);
        Array.Sort(wordArray);

        return new string(scrambledArray) == new string(wordArray);
    }
}


