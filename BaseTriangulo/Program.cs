using System;

namespace BaseTriangulo
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.Clear();
            Menu();
        }
    
        static void Menu()
        {
            Triangulo triangulo = new Triangulo ();
            
            Console.Clear();
            Console.Write("Insira o valor da base: ");
            triangulo.BaseTriangulo = float.Parse(Console.ReadLine());

            Console.Write("Insira a altura do triângulo: ");
            triangulo.AlturaTriangulo = float.Parse(Console.ReadLine());

            Console.Write($"Área: " + triangulo.area);

        }
    }

    public class Triangulo
    {
        public Triangulo ()
        {
            // valores padrão para caso o usuário não informe valores
            this._alturaTriangulo = 0
            this._baseTriangulo = 0
        }

        private float _baseTriangulo;
        public float BaseTriangulo          // value
        {
            get { return _baseTriangulo; }

            set 
            { 
                if (value >= 0) _baseTriangulo = value;

                else 
                {
                    Console.WriteLine("Foi inserido um valor negativo. A base será considerada nula.\n");
                    _baseTriangulo = 0;
                }
            }
        }

        private float _alturaTriangulo;
        public float AlturaTriangulo
        {
            get { return _alturaTriangulo; }

            set 
            { 
                if (value >= 0) _alturaTriangulo = value;
                else 
                {
                    Console.WriteLine("Foi inserido um valor negativo. A altura será considerada nula.\n");
                    _alturaTriangulo = 0;
                }
            }
        }
        public float area { get { return (_alturaTriangulo * _baseTriangulo) / 2; } }           // read only
             
    }
}