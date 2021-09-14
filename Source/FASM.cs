using System;
using System.IO;
using System.Collections.Generic;

namespace xasm
{
    class FASM
    {
        public static Dictionary<string, byte> Opcodes = new Dictionary<string, byte>()
        {
            { "brk", 0x00 }, { "add", 0x10 }, { "sub", 0x20 }, { "lam", 0x30 },
            { "lda", 0x40 }, { "zjp", 0x50 }, { "ldb", 0x60 }, { "lbm", 0x70 },
            { "jmp", 0x80 }, { "som", 0x90 }, { "and", 0xA0 }, { "or" , 0xB0 },
            { "xor", 0xC0 }, { "nnd", 0xD0 }, { "nor", 0xE0 }, { "xnr", 0xF0 }
        };

        public static byte[] Assemble(string[] Code)
        {
            Log.Send("Assembling...");

            // Create the ROM and zero it out
            byte[] ROM = new byte[16];
            for(int i = 0; i < ROM.Length; i++)
                ROM[i] = byte.MinValue;

            // Parse opcodes using the lookup table
            for(int i = 0; i < Code.Length; i++) {
                string Ins = Code[i].ToLower();
                foreach(string Opcode in Opcodes.Keys) {
                    if(Ins.StartsWith(Opcode)) {
                        // High and low nibbles respectively
                        byte Op = Opcodes.GetValueOrDefault(Opcode);
                        byte Lo = 0x0;

                        // If it is not a one nibble instruction. Kind of a quick and dirty solution to finding it but it works
                        if(Ins.Split(" ").Length > 1) {
                            int LoInt = int.Parse(Ins.Split(" ")[1], System.Globalization.NumberStyles.HexNumber);
                            Lo = (byte)LoInt;
                        }
                        // Write the merged bytes to ROM
                        ROM[i] = (byte)(Op + Lo); 
                        break;
                    }
                }
            }
            
            Log.Send("Assembled!");
            return ROM;
        }
    }
}