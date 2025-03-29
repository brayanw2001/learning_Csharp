using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVtoYAML;
    public class BinarySensors
    {
        public readonly string platform;
        public readonly string name;
        public readonly string id;
        public readonly Mcps? mcp;
        public readonly string number;
        public readonly bool inverted;
    
    public BinarySensors(string modEntrada, string areaEntrada)
    {
        IOsNumbers inputNumber = new IOsNumbers();
        
        platform = "gpio";
        name = "Tecla" + " " + areaEntrada;
        id = modEntrada.Replace(" ", "_INPUT_");
        number = inputNumber.PinNumber(modEntrada);
        inverted = false;
    }

}
