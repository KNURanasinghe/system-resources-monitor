using MetroFramework.Controls;

namespace system_resources_monitor
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getRes();
        }

        void getRes()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();
            MetroProgressBarCPU.Value = (int)fcpu;
            MetroProgressBarRAM.Value = (int)fram;
            lblCPU.Text = string.Format("{0:0.00}%", fcpu);
            lblRAM.Text = string.Format("{0:0.00}%", fram);
        }
    }
}