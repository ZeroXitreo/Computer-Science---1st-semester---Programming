using Ex28.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28
{
    class Program
    {
        private static readonly string connectionString = string.Format("Server={0}; Database={1}; User Id={2}; Password={3};", Settings.Default.dbserver, Settings.Default.dbname, Settings.Default.dbuser, Settings.Default.dbpassword);

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    bool quit = false;

                    while (!quit)
                    {
                        Console.Clear();
                        Console.WriteLine("1. Insert Pet");
                        Console.WriteLine("2. Show all pets");
                        Console.WriteLine("3. Add a pet owner");
                        Console.WriteLine("4. Find owner by lastname");
                        Console.WriteLine("5. Find owner by email");
                        Console.WriteLine("0. Quit");

                        string choice = Console.ReadLine();
                        int.TryParse(choice, out int choiceInt);
                        switch (choiceInt)
                        {
                            case 1:
                                InsertPet(connection);
                                break;
                            case 2:
                                ShowAllPets(connection);
                                break;
                            case 3:
                                InsertPetOwner(connection);
                                break;
                            case 4:
                                FindOwnerByLastname(connection);
                                break;
                            case 5:
                                FindOwnerByEmail(connection);
                                break;
                            case 0:
                                quit = true;
                                break;
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void FindOwnerByLastname(SqlConnection connection)
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("GetOwnersByLastName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@LastName", RequestString("What's the owners lastname?")));

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["OwnerFirstName"] + " " + reader["OwnerLastName"]);
                }
            }
            reader.Close();
            Console.ReadKey();
        }

        private void FindOwnerByEmail(SqlConnection connection)
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("GetOwnersByEmail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@OwnerFirstName", RequestString("What's the owners firstname?")));
            cmd.Parameters.Add(new SqlParameter("@Email", RequestString("What's the owners email?")));

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["OwnerFirstName"] + " " + reader["OwnerLastName"]);
                }
            }
            reader.Close();
            Console.ReadKey();
        }

        private void InsertPet(SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("InsertPet", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PetName", RequestString("What's the pets name?")));
            cmd.Parameters.Add(new SqlParameter("@PetType", RequestString("What's the pet type?")));
            cmd.Parameters.Add(new SqlParameter("@PetBreed", RequestString("What's the pet breed?")));
            cmd.Parameters.Add(new SqlParameter("@PetWeight", RequestString("What's the pet weight?")));
            cmd.Parameters.Add(new SqlParameter("@OwnerId", RequestString("What's the pet owner id?")));

            cmd.ExecuteNonQuery();
        }

        private void InsertPetOwner(SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("InsertPetOwner", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@OwnerLastName", RequestString("What's the owners lastname?")));
            cmd.Parameters.Add(new SqlParameter("@OwnerFirstName", RequestString("What's the owners firstname?")));
            cmd.Parameters.Add(new SqlParameter("@OwnerPhone", RequestString("What's the owners phone number?")));
            cmd.Parameters.Add(new SqlParameter("@OwnerEmail", RequestString("What's the owners email?")));

            cmd.ExecuteNonQuery();
        }

        private void ShowAllPets(SqlConnection connection)
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("GetPets", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["PetName"]);
                }
            }
            reader.Close();
            Console.ReadKey();
        }

        private string RequestString(string requestString, bool acceptBlank = false)
        {
            string requested = string.Empty;
            do
            {
                Console.WriteLine(requestString);
                requested = Console.ReadLine();
            } while (requested == string.Empty && !acceptBlank);
            return requested;
        }
    }
}
