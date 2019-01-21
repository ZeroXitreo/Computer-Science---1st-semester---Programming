using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PetRepo
    {
        private Dictionary<int, Owner> ownerDict = new Dictionary<int, Owner>();

        public void InsertPet(string name, string type, string breed, string weight, string ownerId)
        {
            using (SqlConnection connection = new SqlConnection(DB.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("InsertPet", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PetName", name));
                cmd.Parameters.Add(new SqlParameter("@PetType", type));
                cmd.Parameters.Add(new SqlParameter("@PetBreed", breed));
                cmd.Parameters.Add(new SqlParameter("@PetWeight", weight));
                cmd.Parameters.Add(new SqlParameter("@OwnerId", ownerId));

                cmd.ExecuteNonQuery();
            }
        }

        public List<Pet> GetAllPets()
        {
            List<Pet> pets = new List<Pet>();

            using (SqlConnection connection = new SqlConnection(DB.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetPets", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["PetID"].ToString());
                        string name = reader["PetName"].ToString();
                        string type = reader["PetType"].ToString();
                        string breed = reader["PetBreed"].ToString();
                        string DOB = reader["PetDOB"].ToString();
                        string weight = reader["PetWeight"].ToString();
                        string ownerId = reader["OwnerId"].ToString();


                        pets.Add(new Pet(id, name, type, breed, DOB, weight, ownerId));
                    }
                }
                reader.Close();
            }

            return pets;
        }
    }
}
