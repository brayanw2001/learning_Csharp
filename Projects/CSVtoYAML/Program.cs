using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
namespace CSVtoYAML;

class Program
{
    static void Main(string[] args)
    {
        using (var StreamReader = new StreamReader(@"/home/brayan/Documentos/CSVs_mapeamentos/101.csv"))
        {
            using (var csvReader = new CsvReader(StreamReader, CultureInfo.InvariantCulture))
            {

            }
        }

    }
}
