using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography.X509Certificates;
namespace CSVtoYAML;

class YamlConstructor
{
    public YamlConstructor(string path)
    {
        using (var StreamReader = new StreamReader($@"{path}"))
        {
            using (var csvReader = new CsvReader(StreamReader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<IOs>().ToList();

                
                //System.Console.WriteLine(mcp.ComponentMCP());
                Console.WriteLine("binary_sensor:");
                
                foreach (var record in records)
                {
                    BinarySensors binarySensor = new BinarySensors(record.modEntrada, record.areaEntrada);
                    Output output = new Output(record.modSaida);
                    Mcps mcp = new Mcps(record.modEntrada);
                    Console.WriteLine($"  - platform: gpio\r\n    name: {binarySensor.name}\r\n    id: {binarySensor.id}\r\n    pin:\r\n      mcp23xxx: IDC_{record.modEntrada.Split(" ")[0]}_{mcp.mcp23xxx}_I2CA_IN\r\n      number: {binarySensor.number}\r\n      mode: INPUT\r\n      inverted: {binarySensor.inverted}\r\n    on_multi_click:\r\n      - timing:\r\n        - ON for at least 100ms\r\n        then:\r\n          - light.toggle: {output.id} \n");
                }

                Console.WriteLine("output:");

                foreach (var record in records)
                {
                    Output output = new Output(record.modSaida, record.areaEntrada);
                    Console.WriteLine($"  - platform: gpio\r\n    id: {output.id}\r\n    pin:\r\n      mcp23xxx: XXXXXXX\r\n      number: {output.number}\r\n      mode: INPUT\r\n      inverted: {output.inverted}\r\n");
                }
            }
        }
    }
}
