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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        private static Form3 _instance;
        public static Form3 Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new Form3();
                }
                return _instance;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        string frame_txt = "";
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (frame_txt != "")
                Clipboard.SetText(frame_txt);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            uint seed;
            try
            {
                seed = Convert.ToUInt32(Form1.Instance.seed_o.Text, 16);
            }
            catch
            {
                MessageBox.Show("seed値が不正です。");
                return;
            }
            int blinks = (int)numericUpDown1.Value + 1;
            int field_frame = (int)numericUpDown2.Value;
            int honey_frame = (int)numericUpDown3.Value;
            int min = (int)Form1.Instance.min_o.Value + field_frame + 1;
            int max = (int)Form1.Instance.max_o.Value;
            int maximum = max - min;
            Form1.sfmt_set_seed(seed);

            if (maximum < 0)
            {
                MessageBox.Show("minよりmaxの値が小さいです。");
                return;
            }

            int aim = 0, frame = 0, yuyo = 0;
            int[] stop_frame = new int[blinks];
            bool[] flag = new bool[blinks];

            for (int i = 0; i < min; i++)
                Form1.sfmt_next();

            while (true)
            {
                int i = 0;
                int aim_ = 0;
                for (; i < blinks; i++)
                {
                    if (stop_frame[i] > 0)
                    {
                        stop_frame[i] -= 1;
                    }
                    else if (flag[i])
                    {
                        ulong rand = Form1.sfmt_next(); aim_++;
                        stop_frame[i] = rand % 3 == 2 ? 35 : 29;
                        flag[i] = false;
                    }
                    else
                    {
                        ulong rand = Form1.sfmt_next(); aim_++;
                        if ((rand & 127) == 0)
                        {
                            flag[i] = true;
                            stop_frame[i] = 4;
                        }
                    }
                }
                if (aim + aim_ > maximum)
                    break;

                aim += aim_;
                frame += i;

                if (aim == maximum)
                    yuyo += 1;
            }

            int addframe = maximum - aim;
            int sframe = frame / blinks, sframe2 = (frame - yuyo) / blinks;

            string str2 = yuyo > 1 ? ((double)sframe2 / 30).ToString("F3") + "秒～" : "";
            string str3 = yuyo > 1 ? (sframe2 * 2) + "F～" : "";

            string str = maximum + "消費" + " " + sframe + "F";
            str += "\r\n" + str2 + ((double)sframe / 30).ToString("F3") + "秒";
            if (yuyo > 1) str += "\r\n" + "猶予:" + yuyo + "/30秒";
            str += "\r\n";
            if (addframe > 0) str += "\r\n" + "追加消費:" + addframe;
            str += "\r\n" + "EmTimer:" + str3 + (sframe * 2) + "F";

            textBox1.Text = str;

            frame_txt = yuyo > 1 ? ((sframe * 2 + sframe2 * 2) / 2) + "" : sframe * 2 + "";
        }
    }
}
