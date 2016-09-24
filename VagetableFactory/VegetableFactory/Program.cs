using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegetableFactory
{
    

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmUserLogin formLogin = new FrmUserLogin();
            formLogin.ShowDialog();

            Application.Run(new FrmMain());
        }
    }
}
