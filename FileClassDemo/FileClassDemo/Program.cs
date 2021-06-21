using System;
using System.IO;

namespace FileClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {   
            //write using down here to close automatically
            string filePath = @"E:\MyFile.txt";
            if (!File.Exists(filePath))
            {
                //Create a text file
                using StreamWriter sw = File.CreateText(filePath);
                sw.WriteLine("Bonjour, je suis Cuong");
                sw.WriteLine("Hello. I am Cuong");
            }
            //open the file to read: open a text file
            using StreamReader sr = File.OpenText(filePath);
            string s;
            while((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
    }
}
