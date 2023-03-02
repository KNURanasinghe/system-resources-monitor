namespace system_resources_monitor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            getRes();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    
        static void getRes()
        {
            try
            {
                System.Management.ManagementObjectSearcher searcher =
                    new System.Management.ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DesktopMonitor");

                foreach (System.Management.ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_DesktopMonitor instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Description: {0}", queryObj["Description"]);
                }
            }
            catch (System.Management.ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }
    
    }
}