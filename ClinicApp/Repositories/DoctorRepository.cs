using System;
using System.Collections.Generic;
using System.Data.SQLite;
using ClinicApp.Database;
using ClinicApp.Models;

namespace ClinicApp.Repositories
{
    public class DoctorRepository
    {
        public void Add(Doctor doctor)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand(@"INSERT INTO Doctors (Name, Specialization, Phone, AvailableDays, AvailableSlots, RoomNumber, Fee) 
                                                   VALUES (@name, @spec, @phone, @days, @slots, @room, @fee)", conn))
                {
                    cmd.Parameters.AddWithValue("@name", doctor.Name);
                    cmd.Parameters.AddWithValue("@spec", doctor.Specialization);
                    cmd.Parameters.AddWithValue("@phone", doctor.Phone);
                    cmd.Parameters.AddWithValue("@days", doctor.AvailableDays);
                    cmd.Parameters.AddWithValue("@slots", doctor.AvailableSlots);
                    cmd.Parameters.AddWithValue("@room", doctor.RoomNumber);
                    cmd.Parameters.AddWithValue("@fee", doctor.Fee);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Doctor> GetAll()
        {
            var doctors = new List<Doctor>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT * FROM Doctors", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doctors.Add(new Doctor
                            {
                                DoctorID = Convert.ToInt32(reader["DoctorID"]),
                                Name = reader["Name"].ToString(),
                                Specialization = reader["Specialization"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                AvailableDays = reader["AvailableDays"]?.ToString() ?? "",
                                AvailableSlots = reader["AvailableSlots"]?.ToString() ?? "",
                                RoomNumber = reader["RoomNumber"]?.ToString() ?? "",
                                Fee = Convert.ToDouble(reader["Fee"])
                            });
                        }
                    }
                }
            }
            return doctors;
        }

        public void Update(Doctor doctor)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand(@"UPDATE Doctors SET Name=@name, Specialization=@spec, Phone=@phone, 
                                                   AvailableDays=@days, AvailableSlots=@slots, RoomNumber=@room, Fee=@fee WHERE DoctorID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", doctor.DoctorID);
                    cmd.Parameters.AddWithValue("@name", doctor.Name);
                    cmd.Parameters.AddWithValue("@spec", doctor.Specialization);
                    cmd.Parameters.AddWithValue("@phone", doctor.Phone);
                    cmd.Parameters.AddWithValue("@days", doctor.AvailableDays);
                    cmd.Parameters.AddWithValue("@slots", doctor.AvailableSlots);
                    cmd.Parameters.AddWithValue("@room", doctor.RoomNumber);
                    cmd.Parameters.AddWithValue("@fee", doctor.Fee);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("DELETE FROM Doctors WHERE DoctorID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Doctor> Search(string query)
        {
            var doctors = new List<Doctor>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT * FROM Doctors WHERE Name LIKE @query OR Specialization LIKE @query", conn))
                {
                    cmd.Parameters.AddWithValue("@query", $"%{query}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doctors.Add(new Doctor
                            {
                                DoctorID = Convert.ToInt32(reader["DoctorID"]),
                                Name = reader["Name"].ToString(),
                                Specialization = reader["Specialization"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                AvailableDays = reader["AvailableDays"]?.ToString() ?? "",
                                AvailableSlots = reader["AvailableSlots"]?.ToString() ?? "",
                                RoomNumber = reader["RoomNumber"]?.ToString() ?? "",
                                Fee = Convert.ToDouble(reader["Fee"])
                            });
                        }
                    }
                }
            }
            return doctors;
        }
    }
}
