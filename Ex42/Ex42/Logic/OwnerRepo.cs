using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class OwnerRepo
    {
        private Dictionary<int, Owner> ownerDict = new Dictionary<int, Owner>();

        public Owner FindOwnerByLastname(string lastName)
        {
            using (SqlConnection connection = DB.Connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("GetOwnersByLastName", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@LastName", lastName));

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["OwnerId"].ToString());
                        string ownerLastName = reader["OwnerLastName"].ToString();
                        string firstName = reader["OwnerFirstName"].ToString();
                        string phone = reader["OwnerPhone"].ToString();
                        string email = reader["OwnerEmail"].ToString();

                        return new Owner(id, ownerLastName, firstName, phone, email);
                    }
                }
                reader.Close();
            }

            return null;
        }

        public Owner FindOwnerByEmail(string firstName, string email)
        {
            using (SqlConnection connection = DB.Connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("GetOwnersByEmail", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OwnerFirstName", firstName));
                cmd.Parameters.Add(new SqlParameter("@Email", email));

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["OwnerId"].ToString());
                        string ownerLastName = reader["OwnerLastName"].ToString();
                        string ownerFirstName = reader["OwnerFirstName"].ToString();
                        string phone = reader["OwnerPhone"].ToString();
                        string ownerEmail = reader["OwnerEmail"].ToString();

                        return new Owner(id, ownerLastName, ownerFirstName, phone, ownerEmail);
                    }
                }
                reader.Close();
            }

            return null;
        }

        public void InsertPetOwner(string lastName, string firstName, string phoneNumber, string email)
        {
            using (SqlConnection connection = DB.Connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("InsertPetOwner", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OwnerLastName", lastName));
                cmd.Parameters.Add(new SqlParameter("@OwnerFirstName", firstName));
                cmd.Parameters.Add(new SqlParameter("@OwnerPhone", phoneNumber));
                cmd.Parameters.Add(new SqlParameter("@OwnerEmail", email));

                cmd.ExecuteNonQuery();
            }
        }
    }
}
