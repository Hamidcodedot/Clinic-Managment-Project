using System;
using System.Windows.Forms;
using ClinicApp.Database;
using ClinicApp.Forms;

namespace ClinicApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseHelper.InitializeDatabase();
                
                // Diagnostic check
                var repo = new ClinicApp.Repositories.DoctorRepository();
                var docs = repo.GetAll();
                string docNames = "";
                foreach (var d in docs)
                {
                    docNames += $"{d.DoctorID}: {d.Name} ({d.Specialization})\n";
                }
                MessageBox.Show("Diagnostics - Doctors in Repo:\n" + (string.IsNullOrEmpty(docNames) ? "NONE" : docNames), "Diagnostics");

                Application.Run(new RoleSelectForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical error occurred during startup:\n" + ex.Message, 
                                "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
