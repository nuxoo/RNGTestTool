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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private static Form4 _instance;
        public static Form4 Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new Form4();
                }
                return _instance;
            }
        }

        public int nresult;
        public int key_length;
        public bool act;
        private int[] res = new int[3];

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Activated += new EventHandler(Form4_Activated);
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
        }

        private void Form4_Activated(object sender, EventArgs e)
        {
            if (act)
            {
                res[0] = nresult - key_length - 1;
                res[1] = nresult;
                res[2] = nresult + 1;

                label1.Text = "開始：" + res[0];
                label2.Text = "現在：" + res[1];
                label3.Text = "終了：" + res[2];
                act = false;
            }
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(res[0].ToString());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(res[1].ToString());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(res[2].ToString());
        }
    }
}
