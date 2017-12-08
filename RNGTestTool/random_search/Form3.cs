using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            read_file();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            write_file();
            this.Hide();
        }

        private string frame_txt = "";
        private string config_file = Form1.config_path + "/Form3.ini";
        private void write_file()
        {
            string[] strs = new string[4];
            
            strs[0] = min_o.Value.ToString();
            strs[1] = max_o.Value.ToString();
            strs[2] = numericUpDown1.Value.ToString();
            strs[3] = numericUpDown2.Value.ToString();

            File.WriteAllLines(config_file, strs);
        }
        private void read_file()
        {
            if (File.Exists(config_file))
            {
                string[] strs = File.ReadAllLines(config_file);
                if (strs.Length >= 4)
                {
                    min_o.Value = Convert.ToInt32(strs[0]);
                    max_o.Value = Convert.ToInt32(strs[1]);
                    numericUpDown1.Value = Convert.ToInt32(strs[2]);
                    numericUpDown2.Value = Convert.ToInt32(strs[3]);
                }
            }
        }

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
            int min = (int)min_o.Value + field_frame;
            int max = (int)max_o.Value;

            if (max < min)
            {
                MessageBox.Show("minよりmaxの値が小さいです。");
                return;
            }

            int addframe = 0;
            frame_result result = new frame_result();

            for (int i = 0; result.yuyo == 0; i++)
            {
                Form1.sfmt_set_seed(seed);
                result = frame_clc(min + i, max, blinks);

                if (i > 0)
                    addframe++;
            }

            int frame = result.frame;
            int yuyo = result.yuyo;

            int sframe = frame - yuyo;

            string str2 = yuyo > 1 ? ((double)sframe / 30).ToString("F3") + "秒～" : "";
            string str3 = yuyo > 1 ? (sframe * 2) + "F～" : "";

            string str = (max - min) + "消費" + " " + frame + "F";
            str += "\r\n" + str2 + ((double)frame / 30).ToString("F3") + "秒";
            if (yuyo > 1) str += "\r\n" + "猶予:" + yuyo + "/30秒";
            str += "\r\n";
            if (addframe > 0) str += "\r\n" + "追加消費:" + addframe;
            str += "\r\n" + "EmTimer:" + str3 + (frame * 2) + "F";

            textBox1.Text = str;

            frame_txt = yuyo > 1 ? ((frame * 2 + sframe * 2) / 2) + "" : frame * 2 + "";
        }

        private frame_result frame_clc(int min, int max, int blinks)
        {
            int aim = min;
            int[] stop_frame = new int[blinks];
            bool[] flag = new bool[blinks];
            int aim_ = 0;
            frame_result result = new frame_result();

            if (min == max)
            {
                result.yuyo = 1;
                return result;
            }

            for (int i = 0; i < min; i++)
                Form1.sfmt_next();

            while (true)
            {
                aim_ = 0;
                for (int i = 0; i < blinks; i++)
                {
                    if (stop_frame[i] > 0)
                    {
                        stop_frame[i] -= 1;
                    }
                    else if (flag[i])
                    {
                        ulong rand = Form1.sfmt_next(); aim_++;
                        stop_frame[i] = rand % 3 == 0 ? 35 : 29;
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

                if (aim + aim_ > max)
                    break;

                aim += aim_;
                result.frame++;

                if (aim == max)
                    result.yuyo += 1;
            }

            return result;
        }
    }

    class frame_result
    {
        public int frame = 0;
        public int yuyo = 0;
    }
}
