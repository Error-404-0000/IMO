using Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testlib;
// Entry point for the command line interface. It expects a `.sc` script path
// as the first argument and passes the file contents to `Lexer.Run`.
// The executable performs no additional processing – it merely loads the file
// and hands control to the interpreter.
namespace test43
{
    internal class Program
    {
        // Main simply validates arguments then forwards the script contents to
        // the lexer. It returns 0 on success or a non-zero value on failure.
        static int Main(string[] args)
        {
         
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: Lexer.exe <file path>");
                return 1;
            }
            var filePath = args[0];
            if (filePath == null)
            {
                Console.WriteLine("File path is null");
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {

                }
                if (File.Exists(filePath))
                {
                    string file = File.ReadAllText(filePath);
                    Lexer.Lexer.Run(file,Path: Path.GetDirectoryName(filePath));
                }
                else
                {
                    // File not found
                    Console.WriteLine("File not found");
                }
                
            }
            return 0;
        }
     
    }
   
}
