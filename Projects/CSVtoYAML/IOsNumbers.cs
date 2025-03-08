using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVtoYAML
{
    public class IOsNumbers
    {
        public static readonly Dictionary<string, string> numbers = new Dictionary<string, string>
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

        public string returnPinNumber(string modEntrada)
        {
            foreach (var number in numbers)
            {
                if (modEntrada.Contains(number.Key))
                    return number.Value;
            }
            return "NULL";
        }
    }
}