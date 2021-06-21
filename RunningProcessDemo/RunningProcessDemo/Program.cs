using System;
using System.Diagnostics;
using System.Linq;

namespace RunningProcessDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int no = 1;
            string info;
            //get all processes on the local machine, ordered by PID
            var runningProcs = from proc in Process.GetProcesses(".")
                               orderby proc.Id
                               select proc;
            //print out PID and Name of each process
            foreach(var p in runningProcs)
            {
                info = $"#{no++}. PID: {p.Id}\tName: {p.ProcessName}";
                Console.WriteLine(info);
            }
            Console.ReadLine();
        }
    }
}
