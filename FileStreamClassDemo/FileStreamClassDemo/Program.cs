using System;
using System.IO;
using System.Text;

namespace FileStreamClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a file to write into
            using FileStream fStream = File.Open("MyFile.dat", FileMode.Create);
            //Encode a string as an array of bytes
            string msg = "ABCDEFG";
            byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
            //Write bytes into file: write what, from where, how many bytes
            fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
            //Reset internal position of stream
            fStream.Position = 0;

            //Read the types from file
            Console.WriteLine("Print message as an array of bytes:");
            byte[] bytesFromFile = new byte[msgAsByteArray.Length];
            for(int i=0; i<msgAsByteArray.Length; i++)
            {
                bytesFromFile[i] = (byte)fStream.ReadByte();
                Console.Write($"{bytesFromFile[i], 5}");
            }
            //Display decoded message
            Console.Write("\nDecoded Message: ");
            Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            Console.ReadLine();
        }
    }
}
