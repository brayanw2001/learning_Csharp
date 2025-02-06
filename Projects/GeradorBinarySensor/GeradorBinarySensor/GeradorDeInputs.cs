
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeradorBinarySensor
{
    public class GeradorDeInputs
    {

        List<string> user_input = new List<string>();

        public void PreencheIds()
        {
            bool opt = true;
            System.Console.WriteLine("Insira, em sequência, os nomes das entidades (!q para sair)\n");

            while (opt) 
            { 
                System.Console.Write("> ");
                string input = Console.ReadLine();

                if (input == "!q")
                {  
                    opt = false;
                    break;
                }

                user_input.Add(input);
            } 
        }

        public void ShowInputs()
        {
            int i = 0;
            int j = 16;
            int offset = -1;

            Console.Clear();
            Console.WriteLine("binary_sensor:");
            Data data = new Data(); 
                
            foreach (string input in user_input)
            {
                Console.WriteLine(
                    $"  - platform: gpio\n" +
                    $"    name: {input}\n"  +
                    $"    id: M1_INPUT_{data.idcInputs[i]}\n" +
                    $"    pin\n" +
                    $"      mcp23xxx:\n"+
                    $"      number: {j} \n" +
                    $"      mode: INPUT\n" +
                    $"      inverted: True\n"  
                );
                if (data.idcInputs[i].Contains("E1"))
                {
                    offset *= -1;
                }
                i++;
                j += offset;
            }
        }
    }
}
