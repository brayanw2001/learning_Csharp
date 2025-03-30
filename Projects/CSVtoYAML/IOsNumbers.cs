
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVtoYAML
{
    public class IOsNumbers
    {
        public static readonly Dictionary<string, string> inputNumbers = new Dictionary<string, string>
        {
            {"A1", "15"}, {"A2", "14"}, {"A3", "13"}, {"A4", "12"},
            {"B1", "11"}, {"B2", "10"}, {"B3", "9"},  {"B4", "8"},
            {"C1", "7"},  {"C2", "6"},  {"C3", "5"},  {"C4", "4"},
            {"D1", "3"},  {"D2", "2"},  {"D3", "1"},  {"D4", "0"},
            {"E1", "0"},  {"E2", "1"},  {"E3", "2"},  {"E4", "3"},
            {"F1", "4"},  {"F2", "5"},  {"F3", "6"},  {"F4", "7"},
            {"G1", "8"},  {"G2", "9"},  {"G3", "10"}, {"G4", "11"},
            {"H1", "12"}, {"H2", "13"}, {"H3", "14"}, {"H4", "15"}
        };

        public static readonly Dictionary<string, string> outputNumbers = new Dictionary<string, string>
        {
            {"A1", "0"}, {"A2", "1"}, {"A3", "2"}, {"A4", "3"},
            {"B1", "4"}, {"B2", "5"}, {"B3", "6"},  {"B4", "7"},
            {"C1", "8"},  {"C2", "9"},  {"C3", "10"},  {"C4", "11"},
            {"D1", "12"},  {"D2", "13"},  {"D3", "14"},  {"D4", "15"},
        };

        public string PinNumberInput (string modEntrada)
        {
            string[] borneTerminal = modEntrada.Split(' ');

            if (inputNumbers.TryGetValue(borneTerminal[borneTerminal.Length - 1], out string? pinNumber))
            {
                return pinNumber;
            }

            return "NULL";
        }

        public string PinNumberOutput(string modSaida)
        {
            string[] borneTerminal = modSaida.Split(' ');

            if (outputNumbers.TryGetValue(borneTerminal[borneTerminal.Length - 1], out string? pinNumber))
            {
                return pinNumber;
            }

            return "NULL";
        }
    }
}