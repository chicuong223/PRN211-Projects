using System;
using System.IO;

namespace BinaryWriterReaderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"E:\TestFile.bin";
            Console.WriteLine("***** Demo Binary Writer and Binary Reader *****");
            //open binary writer for a file
            FileInfo f = new FileInfo(fileName);
            using BinaryWriter bw = new BinaryWriter(f.OpenWrite());
            //Print out the type of BaseStream
            Console.WriteLine("Base stream is: {0}", bw.BaseStream);

            //Create some data to save into the file
            double aDouble = 9183.67;
            int anInt = 98321;
            string aString = "Tang Chi-Cuong";
            //write data
            bw.Write(aDouble);
            bw.Write(anInt);
            bw.Write(aString);
            bw.Close();
            Console.WriteLine("File was created");
            Console.WriteLine("Read the binary data from the stream");

            //open a file to read
            using BinaryReader br = new BinaryReader(f.OpenRead());
            //write what first, read it first
            Console.WriteLine(br.ReadDouble());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadString());
            Console.ReadLine();
        }
    }
}
