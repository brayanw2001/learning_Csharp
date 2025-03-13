using System;
using System.Globalization;
using Microsoft.Data.Sqlite;

namespace habit_tracker
{    
    class Program
    {
        static string connectionString = @"Data Source = HabitTracker.db";

        static void Main(string[] args)
        {
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

            GetUserInput();
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
                   // case "3":
                   //     Delete();
                   //     break;
                   // case "4":
                   //     Update();
                   //     break;
                    default:
                        Console.WriteLine("\nInvalid command. Please, type a number from 0 to 4.\n");
                        break;
                }
            }
        }

      
        private static void GetAllRecords()
        {
            Console.Clear();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    $"SELECT * FROM drinking_water";

                List<DrinkingWater> tableData = new();
                SqliteDataReader reader = tableCmd.ExecuteReader();         // ExecuteReadder -> lê resultado linha por linha

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(
                            new DrinkingWater
                            {
                                Id = reader.GetInt32(0),
                                Date = DateTime.ParseExact(reader.GetString(1), "dd-MM-yy", new CultureInfo("en-US")),
                                Quantity = reader.GetInt32(2)
                            });
                    }
                }
                else 
                {
                    Console.WriteLine("No rows found");
                }

                connection.Close();
                Console.WriteLine("--------------------\n");

                foreach (var dw in tableData)
                {
                    Console.WriteLine($"{dw.Id} - {dw.Date.ToString("dd-MMM-yyyy")} - Quantity: {dw.Quantity} glasses");
                }
                Console.WriteLine("--------------------\n");
            }
        }
        
        private static void Insert()
        {
            string date = GetDateInput();

            int quantity = GetNumberInput("Please insert number of glasses or other integer measure");
        
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = 
                $"INSERT INTO drinking_water(date, quantity) VALUES('{date}', '{quantity}')";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        private static string GetDateInput()
        {
            Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to main menu.");

            string dateInput = Console.ReadLine();

            if (dateInput == "0") GetUserInput();

            return dateInput;
        }

        internal static int GetNumberInput(string message)
        {
            System.Console.WriteLine(message);

            string numberInput = Console.ReadLine();
            
            if (numberInput == "0") GetUserInput();

            int finalInput = Convert.ToInt32(numberInput);

            return finalInput;          // 15:54
        }
    }
    public class DrinkingWater
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
    }
}
