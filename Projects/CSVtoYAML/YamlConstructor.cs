using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVtoYAML
{
    class YamlConstructor
    {
        private string modEntrada { get; }
        private string modSaida { get; }
        private string areaEntrada { get; }
        private string areaSaida { get; }
        private static int number = 16;

        public YamlConstructor(string modEntrada, string modSaida, string areaEntrada, string areaSaida)
        {
            // Console.WriteLine($"Entrada: {modEntrada}, Saída: {modSaida}, Area: {areaEntrada}");
            this.modEntrada = modEntrada;
            this.modSaida = modSaida;
            this.areaEntrada = areaEntrada;
            this.areaSaida = areaSaida;
        }

        public void BinarySensorGenerator()
        {
            IOsNumbers number = new IOsNumbers();
            Console.WriteLine($"  - platform: gpio\r\n    name: {areaEntrada}\r\n    id: {modEntrada.Replace(" ", "_INPUT_")}\r\n    pin:\r\n      mcp23xxx: IDC_M1_MCP4_I2CA_IN\r\n      number: {number.returnPinNumber(modEntradatem)}\r\n      mode: INPUT\r\n      inverted: True\r\n    on_multi_click:\r\n    - timing:\r\n       - ON for at least 100ms\r\n      then:\r\n        - light.toggle: {modSaida.Replace(" ", "_INPUT_")}\n");
        }
    }
}
