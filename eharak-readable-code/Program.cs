using System;
using System.IO;

namespace eharak_readable_code
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                Console.WriteLine(line);
            }
        }
    }
}
