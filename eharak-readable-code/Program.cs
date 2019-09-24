using System;
using System.Diagnostics;
using System.IO;

namespace eharak_readable_code
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                var appFilePath = Process.GetCurrentProcess().MainModule.FileName;
                var appFileName = Path.GetFileName(appFilePath);
                var errorMessage = string.Format("使い方 : {0} データファイル名のフルパス", appFileName);

                Console.WriteLine(errorMessage);
                return;
            }

            foreach (var line in File.ReadLines(args[0]))
            {
                Console.WriteLine(line);
            }
        }
    }
}
