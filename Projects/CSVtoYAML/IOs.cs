using System;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace CSVtoYAML
{
    public class IOs
    {
        [Name("Mod Entrada")]
        public string modEntrada { get; set; }
        [Name("Area Entrada")]
        public string areaEntrada { get; set; }

        [Name("Mod Saida")]
        public string modSaida { get; set; }
        [Name("Area Saida")]
        public string areaSaida { get; set; }
        [Name("Circuito")]
        public string circuito { get; set; }
    }
}
