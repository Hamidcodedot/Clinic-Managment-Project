namespace ClinicApp.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Phone { get; set; }
        public string AvailableDays { get; set; }
        public string AvailableSlots { get; set; }
        public string RoomNumber { get; set; }
        public double Fee { get; set; }

        public override string ToString()
        {
            return $"{Name} — {Specialization} — Rs.{Fee}";
        }
    }
}
