using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorBinarySensor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeradorDeInputs gerador = new GeradorDeInputs();
            gerador.PreencheIds();
            gerador.ShowInputs();
        }
    }
}
