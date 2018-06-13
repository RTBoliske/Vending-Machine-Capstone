using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("Find and replace a word or phrase...");
            Console.WriteLine();
            bool exists = false;
            string sourceFilePath = "";
            string destinationFilePath = "";

            do
            {
                Console.WriteLine("Please enter the file name: ");
                sourceFilePath = Console.ReadLine();
                ////string sourceFile = "alices_adventures_in_wonderland.txt";

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
                    Console.WriteLine("File path does not exist.");
                }
                if (File.Exists(destinationFilePath))
                {
                    return;
                }
            } while (!exists);

            Console.WriteLine("Please enter the file path: ");
            destinationFilePath = Console.ReadLine();
            destinationFilePath = Path.Combine(Environment.CurrentDirectory, destinationFilePath);
            //string filePath = @"C:\Workspace\Team\team1-c-week4-pair-exercises\file-io-part2-exercises-pair\";
            //Console.Clear();

            Console.WriteLine("Please enter a search word or phrase: ");
            string searchString = Console.ReadLine();
            //string wordUpper = searchString.ToUpper();
            //string wordLower = searchString.ToLower();
            Console.Clear();

            Console.WriteLine("Please enter a word or phrase to replace: ");
            string replaceString = Console.ReadLine();
            Console.Clear();

            // File path if not hard coded
            //string parentDirectory = Path.Combine(filePath, sourceFile);

            //hard coded file path
            //string parentDirectory = @"C:\Workspace\Team\team1-c-week4-pair-exercises\file-io-part2-exercises-pair\alices_adventures_in_wonderland.txt";

            //string outputFile = "alices_adventures_in_wonderland-FIXED.txt";
            //string outputPath = Path.Combine(filePath, outputFile);
            string fixedLine = "";
            
           
            try
            {
                using (StreamReader sr = new StreamReader(sourceFilePath))
                {
                    using (StreamWriter sw = new StreamWriter (destinationFilePath, false))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();

                            //if (line.Contains(searchString) || line.Contains(wordUpper) || line.Contains(wordLower))
                            //{
                            //    searchString = searchString.ToLower();
                            //}


                            fixedLine = line.Replace(searchString, replaceString);

                            sw.WriteLine(fixedLine);
                        }
                    }
                       
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

            Console.Write($"Successfully found and replaced your search term, new file will be called {destinationFilePath}");

            Console.ReadKey();
        }
    }
}
