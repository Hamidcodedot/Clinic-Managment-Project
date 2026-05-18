using System;
using System.Collections.Generic;
using System.Data.SQLite;
using ClinicApp.Database;
using ClinicApp.Models;

namespace ClinicApp.Repositories
{
    public class AppointmentRepository
    {
        public int Add(Appointment app)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand(@"INSERT INTO Appointments (PatientID, DoctorID, AppointmentDate, AppointmentTime, Status, Notes, BookedBy) 
                                                   VALUES (@pid, @did, @date, @time, @status, @notes, @bookedBy); SELECT last_insert_rowid();", conn))
                {
                    cmd.Parameters.AddWithValue("@pid", app.PatientID);
                    cmd.Parameters.AddWithValue("@did", app.DoctorID);
                    cmd.Parameters.AddWithValue("@date", app.AppointmentDate);
                    cmd.Parameters.AddWithValue("@time", app.AppointmentTime);
                    cmd.Parameters.AddWithValue("@status", app.Status);
                    cmd.Parameters.AddWithValue("@notes", app.Notes);
                    cmd.Parameters.AddWithValue("@bookedBy", app.BookedBy);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public List<Appointment> GetAll(string dateFilter = null, string statusFilter = "All")
        {
            var list = new List<Appointment>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT a.*, p.Name as PatientName, d.Name as DoctorName 
                               FROM Appointments a 
                               JOIN Patients p ON a.PatientID = p.PatientID 
                               JOIN Doctors d ON a.DoctorID = d.DoctorID 
                               WHERE 1=1";
                
                if (!string.IsNullOrEmpty(dateFilter)) sql += " AND a.AppointmentDate = @date";
                if (statusFilter != "All") sql += " AND a.Status = @status";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(dateFilter)) cmd.Parameters.AddWithValue("@date", dateFilter);
                    if (statusFilter != "All") cmd.Parameters.AddWithValue("@status", statusFilter);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Appointment
                            {
                                AppointmentID = Convert.ToInt32(reader["AppointmentID"]),
                                PatientID = Convert.ToInt32(reader["PatientID"]),
                                DoctorID = Convert.ToInt32(reader["DoctorID"]),
                                AppointmentDate = reader["AppointmentDate"].ToString(),
                                AppointmentTime = reader["AppointmentTime"].ToString(),
                                Status = reader["Status"].ToString(),
                                Notes = reader["Notes"].ToString(),
                                BookedBy = reader["BookedBy"].ToString(),
                                PatientName = reader["PatientName"].ToString(),
                                DoctorName = reader["DoctorName"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<Appointment> GetByPatientId(int patientId)
        {
            var list = new List<Appointment>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT a.*, d.Name as DoctorName 
                               FROM Appointments a 
                               JOIN Doctors d ON a.DoctorID = d.DoctorID 
                               WHERE a.PatientID = @pid";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", patientId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Appointment
                            {
                                AppointmentID = Convert.ToInt32(reader["AppointmentID"]),
                                DoctorName = reader["DoctorName"].ToString(),
                                AppointmentDate = reader["AppointmentDate"].ToString(),
                                AppointmentTime = reader["AppointmentTime"].ToString(),
                                Status = reader["Status"].ToString(),
                                Notes = reader["Notes"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<string> GetBookedSlots(int doctorId, string date)
        {
            var booked = new List<string>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT AppointmentTime FROM Appointments WHERE DoctorID = @did AND AppointmentDate = @date AND Status != 'Cancelled'", conn))
                {
                    cmd.Parameters.AddWithValue("@did", doctorId);
                    cmd.Parameters.AddWithValue("@date", date);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            booked.Add(reader["AppointmentTime"].ToString());
                        }
                    }
                }
            }
            return booked;
        }

        public void UpdateStatus(int id, string status)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("UPDATE Appointments SET Status=@status WHERE AppointmentID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("DELETE FROM Appointments WHERE AppointmentID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int GetTodayAppointmentCount()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                string today = DateTime.Now.ToString("yyyy-MM-dd");
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Appointments WHERE AppointmentDate = @today", conn))
                {
                    cmd.Parameters.AddWithValue("@today", today);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int GetPendingAppointmentsCount()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Appointments WHERE Status = 'Pending'", conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
