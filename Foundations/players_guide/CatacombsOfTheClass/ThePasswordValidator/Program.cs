namespace ThePasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Insira uma senha: ");
                string password = Console.ReadLine();

                PasswordValidator validatesPassowrd = new PasswordValidator(password);
            }
        }
    }
}
