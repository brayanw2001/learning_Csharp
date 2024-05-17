using System;

namespace Payments
{
    class Program
    {
        static void Main (string[] args)
        {
            var PagamentoBoleto = new PagamentoBoleto
            PagamentoBoleto.Pa
        }
    }

    class Pagamento
    {
        // Propriedades
        DateTime Vencimento;

        // Métodos
        public virtual void Pagar () {}
    }

    class PagamentoBoleto : Pagamento   
    {
        public string NumeroBoleto;

        public override void Pagar()
        {
            // Regra do Boleto
        }
        public int MyProperty { get; set; }

        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public int MyProperty { get; private set; }
        
    }
}