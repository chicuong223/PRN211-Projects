using System;
using System.IO;

namespace FileInfoClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //get current directory
            string sourceDirectory = Directory.GetCurrentDirectory();
            try
            {
                //Get all files
                var files = Directory.EnumerateFiles(sourceDirectory, "*.*");
                foreach(string currentFile in files)
                {
                    Console.WriteLine(currentFile);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

            string filePath = @"E:\MyFile.txt";
            //read file context
            Console.WriteLine("Read File: ");
            string content = File.ReadAllText(filePath);
            Console.WriteLine(content);
            Console.WriteLine("File info: ");
            //Get file info
            FileInfo testFile = new FileInfo(filePath);
            Console.WriteLine($"Name: {testFile.Name}");
            //Creation time
            Console.WriteLine($"Creation time: {testFile.CreationTime}");
            //Last write time
            Console.WriteLine($"Last Write Time: {testFile.LastWriteTime}");
            //Name of parent Directory
            Console.WriteLine($"Directory: {testFile.DirectoryName}");
            Console.ReadLine();

            /* DIRECTORY INFO */
            DirectoryInfo di = new DirectoryInfo(".");
            foreach (var fi in di.GetDirectories("ref"))
            {
                Console.WriteLine("Found directory: {0}", fi.Name);
            }
            Console.WriteLine();

            //search files
            Console.WriteLine("TopDirectory: ");    //don't search in sub-directory
            foreach (var fi in di.GetFiles("*.dll", SearchOption.TopDirectoryOnly))
            {
                Console.WriteLine(fi.Name);
            }
            Console.ReadLine();
        }
    }
}
