using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVtoYAML
{
    public class Mcps
    {
        // fazer chave valor. Se M1 = 0x23 e etc
        string [] idcMcps = new string[] { "0x21", "0x24", "0x21", "0x26"}; // toda vez que detecta mudança em Mx ou _input_Ex, incrementa 1
        string [] oacMcps = new string[] { "0x20", "0x21", "0x22", "0x23", "0x24", "0x25", "0x26", "0x27"};
        public readonly string? mcp23xxx;
        static int idcCounter = 0;

        private static int inCounter  = 0;
        //private static int outCounter  = 0;
        //private static int generalCounter  = 0;

        public Mcps(string modEntrada)
        {
            if (modEntrada.Contains("E1") || modEntrada.Contains("M3") || modEntrada.Contains("M5"))
            {
                idcCounter++;
            }
            
            mcp23xxx = idcMcps[idcCounter];
        }


    }
}