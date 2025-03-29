using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVtoYAML
{
    public class Mcps
    {
        string [] oacMcps = new string[] { "0x20", "0x21", "0x22", "0x23", "0x24", "0x25", "0x26", "0x27"};
        string [] idcMcps = new string[] { "0x21", "0x24", "0x21", "0x26"};
        private static int inCounter  = 0;
        //private static int outCounter  = 0;
        //private static int generalCounter  = 0;

        public string ComponentMCP ()
        {
            inCounter++;
            return ($"\n  - id: IDC_M{inCounter/2}_MCPx_I2CA_IN\r\n    i2c_id: I2C_BUS_A\r\n    address: {idcMcps[inCounter-1]}\r\n");
        }

        //public string ReturnMCPInputID ()
        //{
        //    return $"IDC_M{intCounter+1}_MCPX_I2CA_IN";
        //}
//
        //public string ReturnMCPOutputID ()
        //{
        //    return mcps[outCounter++];
        //}
    }
}