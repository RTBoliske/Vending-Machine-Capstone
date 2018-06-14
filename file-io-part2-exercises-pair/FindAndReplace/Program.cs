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
            bool exists = false;
            string sourceFilePath = "";
            string destinationFilePath = "";

            Console.WriteLine("Find and replace a word or phrase...");
            Console.WriteLine();

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
                    Console.WriteLine("File path does not exist, please enter a valid path.");
                }
                if (File.Exists(destinationFilePath))
                {
                    return;
                }
            } while (!exists);

            Console.WriteLine("Please enter the copy file name: ");
            destinationFilePath = Console.ReadLine();
            destinationFilePath = Path.Combine(Environment.CurrentDirectory, destinationFilePath);
            //Console.Clear();

            Console.WriteLine("Please enter a search word or phrase: ");
            string searchString = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please enter a word or phrase to replace: ");
            string replaceString = Console.ReadLine();
            Console.Clear();

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
