using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding a file and reading the contents.");
            Console.WriteLine();
            

            //alice file path = C:\Workspace\Team\team1-c-week4-pair-exercises\file-io-part1-exercises-pair
           // string searchedFile = "";
            //string parentFilePath = "";

            Console.WriteLine("Please enter the file name and path: ");
            string parentDirectory = Console.ReadLine();
            Console.Clear();

            //searchedFile = Console.ReadLine();
            //string fullPath = Path.Combine(parentFilePath, searchedFile);
            //string fullPath = parentDirectory + searchedFile;
            //bool directoryExists = Directory.Exists(parentDirectory);
            //string parentDirectory = @"C:\Workspace\Team\team1-c-week4-pair-exercises\file-io-part1-exercises-pair\alices_adventures_in_wonderland.txt";

            char[] splitChar = { ' ' };
            char[] sentenceChar = { '.', '!', '?' };
            //int wordCount = 0;
            int sentenceCount = 0;

            List<string> AllWords = new List<string>();
            //List<string> AllSentences = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(parentDirectory))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        AllWords.AddRange(words);

                        string[] sentences = line.Split(sentenceChar);
                        sentenceCount += sentences.Length - 1;

                        // Read in the line
                        //string line = sr.ReadLine().Trim();
                        //string[] sentences = line.Split(sentenceChar);
                        //wordCount += line.Split(' ').Count();
                        //sentenceCount += sentences.Length - 1;
                    }
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

        Console.WriteLine($"There are {AllWords.Count} words in the file.");
        Console.WriteLine();
        Console.WriteLine($"There are {sentenceCount} sentences in the file.");

        Console.ReadKey();
        }
    }
}
