using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePasswordValidator
{
    class PasswordValidator
    {
        private string password;

        public PasswordValidator(string password)
        {
            this.password = password;

            if (LengthValidator() && CaseAndNumberValidator() && NotContainAmpersandOrT())
            {
                Console.WriteLine("Válido!");
            }
            else
            {
                Console.WriteLine("Senha inválida");
            }
        }

        private bool LengthValidator ()
        {
            if (password.Length >= 6 && password.Length <= 13)
                return true;
            else
                return false;
        }

        private bool CaseAndNumberValidator()
        {
            bool isUpper = false;
            bool isLower = false;
            bool isNumber = false;

            foreach (char character in password)
            {
                if (char.IsUpper(character)) isUpper = true;
                else if (char.IsLower(character)) isLower = true;
                else if (char.IsNumber(character)) isNumber = true;

                if (isUpper && isLower && isNumber) return true;
            }
            return false;
        }

        private bool NotContainAmpersandOrT ()
        {         
            foreach (char character in password)
            {
                if (character == 'T') return false;
                else if (character == '&') return false;
            }

            return true;
        }
    }
}
