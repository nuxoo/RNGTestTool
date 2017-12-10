using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace random_search
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private bool close_check = true;
        private string mode_config = Form1.config_path + "/mode.ini";
        private void Form5_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (close_check)
                Form1.Instance.Close();
            else
                System.IO.File.WriteAllText(mode_config, Form1.input_mode17.ToString());
        }

        private void d_result(DialogResult result, bool b)
        {
            if (result == DialogResult.Yes)
            {
                Form1.input_mode17 = b;
                close_check = false;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("10進数でよろしいですか？", "", MessageBoxButtons.YesNo);
            d_result(result, false);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("17進数でよろしいですか？", "", MessageBoxButtons.YesNo);
            d_result(result, true);
        }
    }
}
