using System;
using System.Windows.Forms;
using CareBridgeClinic.Database;
using CareBridgeClinic.Forms;

namespace CareBridgeClinic
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
