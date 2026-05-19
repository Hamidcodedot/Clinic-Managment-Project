using System;
using System.Collections.Generic;
using System.Data.SQLite;
using ClinicApp.Models;

namespace ClinicApp.Database
{
    public class PatientRepository
    {
        public int Add(Patient patient)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand(@"INSERT INTO Patients (Name, Age, Gender, Phone, Address, Password) 
                                                   VALUES (@name, @age, @gender, @phone, @address, @password); SELECT last_insert_rowid();", conn))
                {
                    cmd.Parameters.AddWithValue("@name", patient.Name);
                    cmd.Parameters.AddWithValue("@age", patient.Age);
                    cmd.Parameters.AddWithValue("@gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@phone", patient.Phone);
                    cmd.Parameters.AddWithValue("@address", patient.Address);
                    cmd.Parameters.AddWithValue("@password", patient.Password);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public List<Patient> GetAll()
        {
            var patients = new List<Patient>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT * FROM Patients", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(MapPatient(reader));
                        }
                    }
                }
            }
            return patients;
        }

        public void Update(Patient patient)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand(@"UPDATE Patients SET Name=@name, Age=@age, Gender=@gender, 
                                                   Phone=@phone, Address=@address, Password=@password WHERE PatientID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", patient.PatientID);
                    cmd.Parameters.AddWithValue("@name", patient.Name);
                    cmd.Parameters.AddWithValue("@age", patient.Age);
                    cmd.Parameters.AddWithValue("@gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@phone", patient.Phone);
                    cmd.Parameters.AddWithValue("@address", patient.Address);
                    cmd.Parameters.AddWithValue("@password", patient.Password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("DELETE FROM Patients WHERE PatientID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Patient> Search(string query)
        {
            var patients = new List<Patient>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT * FROM Patients WHERE Name LIKE @query OR Phone LIKE @query", conn))
                {
                    cmd.Parameters.AddWithValue("@query", $"%{query}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(MapPatient(reader));
                        }
                    }
                }
            }
            return patients;
        }

        public Patient Login(string phone, string password)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT * FROM Patients WHERE Phone = @phone AND Password = @pass", conn))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@pass", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapPatient(reader);
                        }
                    }
                }
            }
            return null;
        }

        public Patient GetByPhone(string phone)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT * FROM Patients WHERE Phone = @phone", conn))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapPatient(reader);
                        }
                    }
                }
            }
            return null;
        }

        private static Patient MapPatient(SQLiteDataReader reader)
        {
            return new Patient
            {
                PatientID = Convert.ToInt32(reader["PatientID"]),
                Name = reader["Name"].ToString(),
                Age = Convert.ToInt32(reader["Age"]),
                Gender = reader["Gender"].ToString(),
                Phone = reader["Phone"].ToString(),
                Address = reader["Address"].ToString(),
                Password = reader["Password"].ToString()
            };
        }
    }
}
