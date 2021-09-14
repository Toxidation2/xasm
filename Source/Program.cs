using System;
using System.IO;

namespace xasm
{
    class Program
    {
        static void Main(string[] args)
        {
            // File errors
            if(args.Length <= 0) {
                Log.Send("no input file specified\ntype `xasm -h` for help", Severity.Fatal);
                return;
            }
            else if(!File.Exists(args[0]) && args[0].ToLower() != "-h") {
                Log.Send("input file does not exist\ntype `xasm -h` for help", Severity.Fatal);
                return;
            }

            string OutputFile = "rom.bin";
            for(int i = 0; i < args.Length; i++) {
                string arg = args[i].ToLower();
                switch(arg) {
                    // Output argument
                    case "-o":
                        OutputFile = args[i+1];
                        i++;
                    break;

                    // Help argument
                    case "-h":
                    Console.WriteLine("usage: xasm [source file] [-o output file]");
                    break;
                }
            }
            try {
            File.WriteAllBytes(OutputFile, FASM.Assemble(File.ReadAllLines(args[0])));
            } catch(Exception Ex) {
                Log.Send($"{Ex.Message}", Severity.Error);
            }
        }
    }
}
