namespace ClinicApp.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string AppointmentDate { get; set; } // YYYY-MM-DD
        public string AppointmentTime { get; set; } // HH:MM
        public string Status { get; set; }
        public string Notes { get; set; }
        public string BookedBy { get; set; }

        // Helper properties for display
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}
