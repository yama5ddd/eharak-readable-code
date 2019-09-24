using System;
using System.Diagnostics;
using System.IO;

namespace eharak_readable_code
{
    class Program
    {
        /// <summary>
        /// アプリケーションエントリーポイント
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                PrintUsage();
                return;
            }

            try
            {
                foreach (var line in File.ReadLines(args[0]))
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// プログラムの使い方を表示する
        /// TODO：将来的には切り出してユーティリティクラス化するのが良さそう
        /// TODO：文字列のリソース化
        /// </summary>
        private static void PrintUsage()
        {
            var appFilePath = Process.GetCurrentProcess().MainModule.FileName;
            var appFileName = Path.GetFileName(appFilePath);
            var errorMessage = string.Format("使い方 : {0} データファイル名のフルパス", appFileName);

            Console.WriteLine(errorMessage);
        }
    }
}
