using _1.DAL.Models;
using _3.PL.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NRAiBiAaIQQuGjN/V0Z+X09EaFpEVmJWf1ZpR2NbfE51flFPalhWVAciSV9jS3xSdERlWXpbcnVVR2VeUQ==");
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
        //Tần bị bịp
    }
}
    