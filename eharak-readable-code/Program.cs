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
            if (args.Length <= 0 || args.Length > 2)
            {
                PrintUsage();
                return;
            }

            try
            {
                var hasTargetId = (args.Length == 2);
                int targetId = hasTargetId ? int.Parse(args[1]) : 0;

                // 入力データファイルの登録順(行数)をIDとする
                int id = 0;
                foreach (var line in File.ReadLines(args[0]))
                {
                    ++id;

                    if (hasTargetId)
                    {
                        if (id != targetId)
                            continue;
                    }

                    Console.WriteLine($"{id}: {line}");
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

            Console.WriteLine("使い方 : ");
            Console.WriteLine($"すべての単語を出力する : {appFileName} データファイル名のフルパス");
            Console.WriteLine($"指定したIDの単語を出力する : {appFileName} データファイル名のフルパス 出力する単語のID");
        }
    }
}
