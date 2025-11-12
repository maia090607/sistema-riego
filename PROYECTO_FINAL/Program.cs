using System;
using System.Windows.Forms;

namespace PROYECTO_RIEGO_AUTOMATICO
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MENUPRINCIPAL());
        }
    }
}
