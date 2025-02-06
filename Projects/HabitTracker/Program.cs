using System;
using Microsoft.Data.Sqlite;

namespace habit_tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = HabitTracker.db";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = 
                @"CREATE TABLE IF NOT EXISTS drinking_water (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Quantity INTEGER
                    )";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;
            
            while (!closeApp)
            {
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to close application");
                Console.WriteLine("Type 1 to view all record");
                Console.WriteLine("Type 2 to insert record");
                Console.WriteLine("Type 3 to delete record");
                Console.WriteLine("Type 4 to update record");
                Console.WriteLine("----------------------------------------\n");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "0":
                        Console.WriteLine("\nGoodbye!\n");
                        closeApp = true;
                        break;
                    case "1":
                        GetAllRecords();
                        break;
                    case "2":
                        Insert();
                        break;
                    case "3":
                        Delete();
                        break;
                    case "4":
                        Update();
                        break;
                    default:
                        Console.WriteLine("\nInvalid command. Please, type a number from 0 to 4.\n");
                        break;
                }
            }
        }

        private static void Insert()
        {
            string date = GetDateInput();

            int quantity = GetNumberInput("Please insert number of glasses or other integer measure")
        }

        private static string GetDateInput()
        {
            Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to main menu.");

            string dateInput = Console.ReadLine();

            if (dateInput == '0') GetUserInput();

            return dateInput;
        }

        internal static int GetNumberInput(string message)
        {
            int numberInput = int.Parse(Console.ReadLine());
            
            if (numberInput == 0) GetUserInput();

            return finalInput;          // 15:54
        }
    }
}
