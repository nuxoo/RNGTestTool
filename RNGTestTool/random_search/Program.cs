using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace random_search
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        ///
        [STAThread]
        static void Main()
        {

            if (System.IO.File.Exists("SFMT.dll"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(Form1.Instance);
            }
            else
            {
                MessageBox.Show("SFMT.dllがありません。");
            }
        }
    }
}
