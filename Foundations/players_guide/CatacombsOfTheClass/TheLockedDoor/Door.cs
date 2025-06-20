using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Locked_Door
{
    class Door
    {
        private int password;
        internal States state { get; private set; }

        public Door()
        {
            PasswordRegister();
        }

        internal void PasswordRegister()
        {
            bool aux = true;

            while (aux)
            {
                Console.WriteLine("Insira uma senha de 4 a 8 digitos: ");
                int userPassword = int.Parse(Console.ReadLine());

                if (userPassword.ToString().Length >= 4 && userPassword.ToString().Length <= 8)
                {
                    password = userPassword;
                    aux = false;
                }
                else
                {
                    Console.WriteLine("Número inválido de digitos. Tente novamente");
                }
            }
        }

        internal void ToClose()
        {  
            if (state == States.open)
            {
                state = States.closed;
            }
            else
            {
                Console.WriteLine("Operação inválida.");
                state = state;
            }
        }

        internal void ToOpen()
        {
            if (state == States.closed)
                state = States.open;
            else
                Console.WriteLine("Operação inválida.");
        }

        internal void ToLock()
        {
            if (state == States.closed)
                state = States.locked;
            else
                Console.WriteLine("Operação inválida.");
        }

        internal void ToUnlock()
        {
            int userPassword;

            if (state == States.locked)
            {
                Console.WriteLine("Insira a senha cadastrada: ");
                userPassword = int.Parse(Console.ReadLine());

                if (userPassword == password)
                {
                    state = States.open;
                }
                else
                {
                    Console.WriteLine("Senha incorreta!");
                    state = States.locked;
                }
            }
            else
            {
                Console.WriteLine("Operação inválida.");
            }
        }

        internal void ChangePassword()
        {
            Console.WriteLine("Insira a senha atual: ");
            int userPassword = int.Parse(Console.ReadLine());

            if (userPassword == password)
                PasswordRegister();
            else
                Console.WriteLine("Senha inválida. Tente novamente.");
        }

    }
}
