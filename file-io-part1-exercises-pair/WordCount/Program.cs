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
            bool exists = false;
            string sourceFilePath = "";

            char[] splitChar = { ' ' };
            char[] sentenceChar = { '.', '!', '?' };
            int sentenceCount = 0;

            List<string> AllWords = new List<string>();

            Console.WriteLine("Finding a file and reading the contents.");
            Console.WriteLine();

            //string parentDirectory = @"C:\Workspace\Team\team1-c-week4-pair-exercises\file-io-part1-exercises-pair\alices_adventures_in_wonderland.txt";

            do
            {
                Console.WriteLine("Please enter the file name and path: ");
                sourceFilePath = Console.ReadLine();

                if (!Path.IsPathRooted(sourceFilePath))
                {
                    sourceFilePath = Path.Combine(Environment.CurrentDirectory, sourceFilePath);
                }

                if (File.Exists(sourceFilePath))
                {
                    exists = true;
                }
                else
                {
                    Console.WriteLine("File path does not exist, please enter a valid path.");
                }
            } while (!exists);

            try
            {
                using (StreamReader sr = new StreamReader(sourceFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        AllWords.AddRange(words);

                        string[] sentences = line.Split(sentenceChar);
                        sentenceCount += sentences.Length - 1;
                    }
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine($"There are {AllWords.Count} words in the file.");
            Console.WriteLine();
            Console.WriteLine($"There are {sentenceCount} sentences in the file.");

            Console.ReadKey();
        }
    }
}
