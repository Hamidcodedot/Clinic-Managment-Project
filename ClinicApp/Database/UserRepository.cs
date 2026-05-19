using System;
using System.Data.SQLite;
using ClinicApp.Models;

namespace ClinicApp.Database
{
    public class UserRepository
    {
        public User Login(string username, string password)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT * FROM Users WHERE Username=@u AND Password=@p", conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                FullName = reader["FullName"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
