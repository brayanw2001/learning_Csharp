using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVtoYAML;
public class Output
{
    public readonly string platform;
    public readonly string nome;
    public readonly string id;
    public readonly Mcps? mcp;
    public readonly string number;
    public readonly bool inverted;

    public Output(string modSaida, string areaSaida)
    {
        IOsNumbers outputNumber = new IOsNumbers();

        platform = "gpio";
        id = modSaida.Replace(" ", "_OUTPUT_");
        number = outputNumber.PinNumberOutput(modSaida);
        inverted = false;
    }

    public Output(string modSaida)
    {
        id = modSaida.Replace(" ", "_OUTPUT_");
    }

}
