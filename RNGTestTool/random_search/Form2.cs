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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private static Form2 _instance;
        public static Form2 Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new Form2();
                }
                return _instance;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += new EventHandler(textBox_Changed);
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
            read_file();
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            write_file();
            this.Hide();
        }
        private void textBox_Changed(object sender, EventArgs e)
        {
            label3.Text = textBox1.Text.Length + "個";
        }

        private string config_file = "fox2.txt";
        private void write_file()
        {
            string[] strs = new string[4];

            strs[0] = textBox2.Text;
            strs[1] = step_o.Value.ToString();
            strs[2] = hos_o.Value.ToString();
            strs[3] = checkBox1.Checked.ToString();

            File.WriteAllLines(config_file, strs);
        }
        private void read_file()
        {
            if (File.Exists(config_file))
            {
                string[] strs = File.ReadAllLines(config_file);
                if (strs.Length >= 4)
                {
                    textBox2.Text = strs[0];
                    step_o.Value = Convert.ToInt32(strs[1]);
                    hos_o.Value = Convert.ToInt32(strs[2]);
                    checkBox1.Checked = strs[3] == "True";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string needle_txt = textBox1.Text.ToUpper();
            int needle_len = needle_txt.Length;
            int step = (int)step_o.Value;
            uint hos = (uint)hos_o.Value;
            bool zenh = checkBox1.Checked;
            string file_path = textBox2.Text;
            listBox1.Items.Clear();

            if (!Directory.Exists(file_path))
            {
                MessageBox.Show("「" + file_path + "」がありません。");
                return;
            }
            file_path += "\\";

            if (needle_len < 8)
            {
                label4.Text = "8個以上針を入力して下さい。";
                return;
            }

            if (zenh)
                for (uint i = 0; i < 17; i++)
                    Search(file_path, needle_txt, step, i);
            else
                Search(file_path, needle_txt, step, hos);

            if (result_needle()) return;

            if (needle_len > 8)
            {
                label4.Text = "1個の違いを検索します...";
                char[] needle_char = needle_txt.ToArray();
                char[] needle_char_copy = new char[needle_char.Length];

                for (int j = 0; j < 2; j++)
                    for (int k = 0; k < needle_char.Length; k++)
                    {
                        needle_char.CopyTo(needle_char_copy, 0);
                        needle_char_copy[k] = get_needle_char(needle_char_copy[k], j);
                        needle_txt = new String(needle_char_copy);
                        //MessageBox.Show("" + str);
                        Application.DoEvents();
                        if (zenh)
                            for (uint i = 0; i < 17; i++)
                                Search(file_path, needle_txt, step, i);
                        else
                            Search(file_path, needle_txt, step, hos);
                    }

                if (result_needle()) return;

                if (needle_len > 9)
                {
                    label4.Text = "2個の違いを検索します...";
                    for (int j = 0; j < 4; j++)
                        for (int k = 0; k < needle_char.Length - 1; k++)
                            for (int l = k + 1; l < needle_char.Length; l++)
                            {
                                needle_char.CopyTo(needle_char_copy, 0);
                                needle_char_copy[k] = get_needle_char(needle_char_copy[k], j & 1);
                                needle_char_copy[l] = get_needle_char(needle_char_copy[l], (j & 2) >> 1);
                                needle_txt = new String(needle_char_copy);
                                Application.DoEvents();
                                if (zenh)
                                    for (uint i = 0; i < 17; i++)
                                        Search(file_path, needle_txt, step, i);
                                else
                                    Search(file_path, needle_txt, step, hos);
                            }
                }

                if (result_needle()) return;
            }

            label4.Text = "候補が見つかりませんでした。";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int sel = listBox1.SelectedIndex;

            if (sel >= 0)
            {
                string[] strs = listBox1.Text.Split(',');
                Form1.Instance.seed_o.Text = strs[0];
            }
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "フォルダを指定してください。";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //fbd.SelectedPath = @"C:\Windows";
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int sel = listBox1.SelectedIndex;

            if (sel >= 0)
            {
                string[] strs = listBox1.Text.Split(',');
                Clipboard.SetText(strs[0]);
            }
        }

        private char get_needle_char(char needle_char, int p)
        {
            if (p == 0)
            {
                if (needle_char == '9')
                    needle_char = 'A';
                else if (needle_char == 'G')
                    needle_char = '0';
                else
                    needle_char++;
            }
            if (p == 1)
            {
                if (needle_char == 'A')
                    needle_char = '9';
                else if (needle_char == '0')
                    needle_char = 'G';
                else
                    needle_char--;
            }
            return needle_char;
        }
        private bool result_needle()
        {
            if (listBox1.Items.Count <= 0)
            {
                return false;
            }
            else
            {
                label4.Text = listBox1.Items.Count + "個候補が見つかりました。";
                return true;
            }
        }

        private void Search(string file_path, string needle_txt, int step, uint hos)
        {
            int needle_len = needle_txt.Length;
            uint[] rand = new uint[needle_len];

            for (int i = 0; i < needle_len; i++)
            {
                if (needle_txt[i] == 'G')
                    rand[i] = (16 + hos) % 17;
                else
                    rand[i] = (Convert.ToUInt32(needle_txt[i].ToString(), 16) + hos) % 17;
            }

            uint needls = encode_needle(rand);
            string filename = "QR" + (needls % 100).ToString("D2") + ".bin";
            FileStream fs = System.IO.File.OpenRead(file_path + filename);
            long sz = fs.Length / 4;

            uint pos = 0;
            for (int i = 31; i >= 0; i--)
            {
                uint nextPos = (uint)(pos + (1 << i));
                if (nextPos < sz)
                {
                    uint seed = get_seed(fs, nextPos);
                    if (get_needles(seed, step) <= needls)
                    {
                        pos = nextPos;
                    }
                }
            }

            while (true)
            {
                uint seed = get_seed(fs, pos);
                uint res = get_needles(seed, step);
                if (res == needls)
                {
                    if (seed_Matching(seed, rand, needle_len))
                    {
                        string[] n_txt = get_needle_txt(seed, needle_len, step, hos);
                        string n2_txt = hos == 0 ? "" : "+" + hos.ToString("D2");
                        listBox1.Items.Add(seed.ToString("X8") + "," + n_txt[0] + n2_txt + ",Next=" + n_txt[1]);
                    }
                }
                else
                {
                    break;
                }
                if (pos == 0) break;
                pos--;
            }

            fs.Close();
        }
        
        private uint encode_needle(uint[] rand)
        {
            uint r = 0;
            for (int i = 0; i < 7; i++)
            {
                r = r * 17 + rand[i];
            }

            return r;
        }
        private uint get_needles(uint seed, int step)
        {
            Form1.sfmt_set_seed(seed);

            for (int i = 0; i < step; i++)
                Form1.sfmt_next();

            uint[] rand = new uint[7];
            for (int i = 0; i < 7; i++)
            {
                rand[i] = (uint)(Form1.sfmt_next() % 17);
            }

            return encode_needle(rand);
        }
        private string[] get_needle_txt(uint seed, int needle_len, int step, uint hos)
        {
            string[] strs = new string[2];
            Form1.sfmt_set_seed(seed);

            for (int i = 0; i < step; i++)
                Form1.sfmt_next();

            for (int i = 0; i < needle_len + 3; i++)
            {
                uint rand = (uint)(Form1.sfmt_next() % 17);
                int j = i < needle_len ? 0 : 1;
                rand = (17 + rand - hos) % 17;

                if (rand == 16)
                    strs[j] += "G";
                else
                    strs[j] += rand.ToString("X");
            }

            return strs;
        }
        private uint get_seed(FileStream fs, long pos)
        {
            byte[] bs = new byte[4];
            fs.Seek(1 * pos * 4, SeekOrigin.Begin);
            fs.Read(bs, 0, bs.Length);

            return BitConverter.ToUInt32(bs, 0); ;
        }
        private bool seed_Matching(uint seed, uint[] rand, int needle_len)
        {
            Form1.sfmt_set_seed(seed);
            for (int i = 0; i < 417; i++)
                Form1.sfmt_next();

            for (int i = 0; i < needle_len; i++)
            {
                ulong r = Form1.sfmt_next();
                if (r % 17 != rand[i])
                    return false;
            }
            return true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool b = checkBox1.Checked;

            hos_o.Enabled = !b;
            label2.Enabled = !b;
        }
    }
}
