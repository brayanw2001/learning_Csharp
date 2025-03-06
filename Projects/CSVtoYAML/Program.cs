using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
namespace CSVtoYAML;

class Program
{
    static void Main(string[] args)
    {
        //using (var StreamReader = new StreamReader(@"/home/brayan/Documentos/CSVs_mapeamentos/101.csv"))
        using (var StreamReader = new StreamReader(@"C:\Users\braya\OneDrive\Documentos\Projects\UNISEC\Empreendimentos\Chateau Meirelles\101 (2).csv"))
        {
            using (var csvReader = new CsvReader(StreamReader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<IOs>().ToList();

                foreach (var record in records)
                {
                    YamlConstructor yamlConstructor = new YamlConstructor(record.modEntrada, record.modSaida, record.areaEntrada, record.areaSaida);
                    yamlConstructor.BinarySensorGenerator();
                }
            }
        }
    }
}
