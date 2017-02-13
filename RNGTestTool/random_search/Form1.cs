using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace random_search
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //SFMTを使えるようにする
        [DllImport("SFMT.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void sfmt_set_seed(uint seed);

        [DllImport("SFMT.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static ulong sfmt_next();

        int[] r_no;
        string[] nature_txt = { "がんばりや", "さみしがり", "ゆうかん", "いじっぱり",
            "やんちゃ", "ずぶとい", "すなお", "のんき", "わんぱく", "のうてんき",
            "おくびょう", "せっかち", "まじめ", "ようき", "むじゃき", "ひかえめ",
            "おっとり", "れいせい", "てれや", "うっかりや", "おだやか", "おとなしい",
            "なまいき", "しんちょう", "きまぐれ" };
        char[] kos = { 'H', 'A', 'B', 'C', 'D', 'S' };
        int[] kosi = { 0, 1, 2, 5, 3, 4 };

        int[] ret = { -1, 33, 39, 0, 0 };

        List<ComboBox> combo = new List<ComboBox>();
        List<CheckBox> Check = new List<CheckBox>();
        string save_file = "fox.txt";
        string config_file = "config.txt";
        private bool cancel = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(Form_Closed);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);

            string[] columns = { "消費", "乱数列", "針", "め", "H", "A", "B", "C", "D", "S", "性格", "技", "し", "en", "pid", "性", "特", "sv", "個", "UB", "種", "Lv", "持", "消", "エ"};
            
            listView1.GridLines = true;
            List<int> r_no_list = new List<int>();
            listView1.Columns.Add(columns[0], 66); r_no_list.Add(0); //消費
            listView1.Columns.Add(columns[1], 140);r_no_list.Add(1); //乱数列
            listView1.Columns.Add(columns[2], 30); r_no_list.Add(2); //針
            listView1.Columns.Add(columns[3], 30); r_no_list.Add(3); //まばたき

            for (int i = 0; i < 6; i++)
            {
                listView1.Columns.Add(columns[i + 4], 30); //H~S
                r_no_list.Add(4 + i);
            }

            listView1.Columns.Add(columns[10], 96); r_no_list.Add(10);//特性
            listView1.Columns.Add(columns[12], 36); r_no_list.Add(11);//シンクロ
            listView1.Columns.Add(columns[17], 50); r_no_list.Add(12);//SV
            listView1.Columns.Add(columns[18], 30); r_no_list.Add(13);//個性
            listView1.Columns.Add(columns[13], 76); r_no_list.Add(14);//PID
            listView1.Columns.Add(columns[14], 76); r_no_list.Add(15);//暗号化定数
            listView1.Columns.Add(columns[15], 36); r_no_list.Add(16);//性別
            listView1.Columns.Add(columns[16], 30); r_no_list.Add(17);//特性
            listView1.Columns.Add(columns[24], 36); r_no_list.Add(18);//エンカウント
            listView1.Columns.Add(columns[19], 36); r_no_list.Add(19);//UB
            listView1.Columns.Add(columns[20], 36); r_no_list.Add(20);//出現ポケモン
            listView1.Columns.Add(columns[21], 36); r_no_list.Add(21);//Lv
            listView1.Columns.Add(columns[22], 30); r_no_list.Add(22);//持ち物
            listView1.Columns.Add(columns[23], 30); r_no_list.Add(23);//消費数

            int c = r_no_list.Count;
            r_no = new int[c];
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (i == r_no_list[j])
                    {
                        r_no[i] = j;
                        break;
                    }
                }
            }

            combo.Add(comboBox1);
            combo.Add(comboBox2);
            combo.Add(comboBox3);
            combo.Add(comboBox4);
            combo.Add(comboBox5);
            combo.Add(comboBox6);
            combo.Add(comboBox7);

            Check.Add(checkBox1);
            Check.Add(checkBox2);
            Check.Add(checkBox3);
            Check.Add(checkBox4);
            Check.Add(checkBox5);
            Check.Add(checkBox6);

            string abl_t = "-\n偶\n奇";
            for (int i = 0; i < 32; i++)
                abl_t += "\n" + i;

            for (int i = 0; i < 6; i++)
            {
                combo[i].Items.AddRange(abl_t.Split('\n'));
                combo[i].SelectedIndex = 0;
            }

            string[] nature_items = new string[nature_txt.Length];
            nature_txt.CopyTo(nature_items, 0);
            Array.Sort(nature_items);
            comboBox7.Items.Add("‐");
            comboBox7.Items.AddRange(nature_items);
            comboBox7.SelectedIndex = 0;
            read_file();
            config_read();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            uint seed;
            try
            {
                seed = Convert.ToUInt32(seed_o.Text, 16);
            }
            catch
            {
                MessageBox.Show("seed値が不正です。");
                return;
            }
            int maxrow;
            int min;
            int max;
            if (checkBox9.Checked)
            {
                maxrow = 201;
                min = (int)max_o.Value - 100;
                max = (int)max_o.Value + 100;
            }
            else
            {
                maxrow = checkBox7.Checked ? 100 : 10000;
                min = (int)min_o.Value;
                max = (int)max_o.Value;
            }
            int maximum = max - min;
            int cnt = 0;
            sfmt_set_seed(seed);
            List<ListViewItem> rows = new List<ListViewItem>();
            List<ulong> random = new List<ulong>();
            listView1.Items.Clear();
            string[] key = new string[7];
            int ii = 0;
            bool eye = false;
            bool eye_at = false, clc = true, eye_at_c = blink_c.Checked;
            int eye_cnt1 = 0;
            int eye_cnt2 = 0;
            int eye1 = ret[1], eye2 = ret[2];
            int met = ret[3], hos = ret[4];
            int rowleng = r_no.Length;
            get_datas();

            if (maximum < 0)
                return;

            for (int i = 0; i < 7; i++)
                key[i] = combo[i].Text;
            
            for (int i = 0; i < min; i++, ii++)
                sfmt_next();

            for (int i = 0; i < 100; i++)
                random.Add(sfmt_next());
            
            cancel = Search.Text == "キャンセル";
            if (cancel)
            {
                Search.Text = "計算";
                return;
            }
            else
            {
                Search.Text = "キャンセル";
            }

            for (int i = 0; i <= maximum; i++, ii++)
            {
                if (cancel)
                {
                    label10.Text = "キャンセルされました。";
                    return;
                }

                random.Add(sfmt_next());
                string[] row = new string[rowleng];

                row[r_no[0]] = ii.ToString();
                row[r_no[1]] = random[0].ToString("X16");
                row[r_no[2]] = get_sin(random[0] % 17);

                if (eye_at_c)
                {
                    if (eye_at)
                    {
                        clc = true;
                        eye_at = false;
                    }
                    else
                    {
                        clc = false;
                    }
                }

                if (eye)
                {
                    if (random[0] % 3 == 0)
                    {
                        row[r_no[3]] = eye2.ToString();
                        eye_cnt2++;
                    }
                    else
                    {
                        row[r_no[3]] = eye1.ToString();
                        eye_cnt1++;
                    }

                    eye = false;
                    eye_at = true;
                }
                else
                {
                    if (random[0] % 128 == 0 && i != 0 && i + met <= maximum)
                    {
                        row[r_no[3]] = "★";
                        eye = true;
                    }
                    else row[r_no[3]] = "-";
                }
                
                if (cnt < maxrow && clc)
                {
                    string[] list;
                    list = get_sta(random);

                    for (int k = 0; k < list.Length; k++)
                        row[r_no[k + 4]] = list[k];

                    if (k_Search(row, key))
                    {
                        rows.Add(new ListViewItem(row));
                        cnt++;
                    }
                }

                random.RemoveAt(0);

                if (i != 0 && i % 10000 == 0 || i == maximum)
                {
                    label10.Text = i + " / " + maximum;
                    Application.DoEvents();
                }
            }
            Search.Text = "計算";

            int br = eye_cnt1 * eye1 + eye_cnt2 * eye2;
            string frame = "目的まで：" + (maximum + br + hos) + "F";
            label12.Text = "め考慮+" + br + "F : " + frame;

            if (cnt > 0)
            {
                label10.Text = "リスト数：" + cnt;
                Application.DoEvents();
                listView1.Items.AddRange(rows.ToArray());
            }
            else
            {
                label10.Text = "ないよ。";
            }
        }

        bool jun_d, ub_d, charm_d, syc_d, honey_d, yas_d;
        int nazo_d, ubs_d;
        bool[] checks_d = new bool[6];
        bool only_shiny, only_ub, only_synchronize;
        private void get_datas()
        {
            jun_d = jun_c.Checked;
            ub_d = ub_c.Checked;
            charm_d = charm_c.Checked;
            syc_d = syc_c.Checked;
            honey_d = honey_c.Checked;
            nazo_d = (int)nazo_o.Value;
            yas_d = (ub_d && jun_d) || !jun_d;
            ubs_d = (int)ubs_o.Value;

            for (int i = 0; i < 6; i++)
                checks_d[i] = Check[i].Checked;

            only_shiny = shiny_c.Checked;
            only_ub = ubs_c.Checked;
            only_synchronize = sycs_c.Checked;
        }

        private string get_sin(ulong sin)
        {
            string str;
            if (sin >= 16)
                str = "G";
            else
                str = sin.ToString("X");

            return str;
        }
        private string[] get_sta(List<ulong> random)
        {
            string[] list = new string[20];
            int aim = 0;
            int[] ivs = new int[6];
            int cnt = 0;
            bool syc = false;
            int tsv = ret[0];

            if (syc_d && (!honey_d || !ub_d)) //シンクロ
            {
                syc = random[aim] % 100 >= 50;
                list[7] = syc ? "○" : "×";
                aim++;
            }
            if (!honey_d && yas_d) //エンカウント
            {
                list[14] = (random[aim] % 100).ToString();
                aim++;
            }
            if (ub_d) //UB
            {
                if (ubs_d == -1)
                    list[15] = (random[aim] % 100).ToString();
                else
                    list[15] = (int)(random[aim] % 100) < ubs_d ? "○" : "×";
                aim++;
            }
            if (syc_d && honey_d && ub_d) //シンクロ
            {
                syc = random[aim] % 100 >= 50;
                list[7] = syc ? "○" : "×";
                aim++;
            }
            if (!jun_d)
            {
                list[16] = (random[aim] % 100).ToString(); aim++; //出現ポケモン
                list[17] = (random[aim] % 4).ToString(); aim++;   //レベル
                aim++; //不明
            }
            if (jun_d) //謎の消費
            {
                aim += nazo_d;
            }

            aim += 60; //謎の消費

            ulong an = random[aim] & 0xFFFFFFFF; //暗号化定数
            list[10] = an.ToString("X8"); aim++;
            int ank = (int)(an % 6);

            int sv = 0;
            ulong pid = 0;
            for (int i = (charm_d) ? 0 : 2; i < 3; i++) //pid
            {
                pid = random[aim] & 0xFFFFFFFF; aim++;
                sv = ((int)(pid >> 16) ^ (int)(pid & 0xFFFF)) >> 4;
                if (sv == tsv)
                {
                    list[8] = "★";
                    break;
                }
            }
            if (sv != tsv) list[8] = sv.ToString();
            list[11] = pid.ToString("X8");

            while (cnt < 3 && jun_d) //準伝V
            {
                int ran = (int)(random[aim] % 6);
                if (ivs[ran] != 32)
                {
                    ivs[ran] = 32;
                    cnt++;
                }
                aim++;
            }
            
            for (int i = 0; i < 6; i++) //IV
            {
                if (ivs[i] == 32)
                {
                    ivs[i] = 31;
                }
                else
                {
                    ivs[i] = (int)(random[aim] % 32);
                    aim++;
                }
            }
            
            int max_iv = 0;
            for (int i = 0; i < 6; i++) //IV
            {
                int ii = kosi[(i + ank) % 6];
                list[ii] = ivs[ii].ToString();

                if (max_iv < ivs[ii]) //個性
                {
                    list[9] = kos[ii].ToString();
                    max_iv = ivs[ii];
                }
            }

            if (!jun_d) //特性
            {
                list[13] = (random[aim] % 2 + 1).ToString();
                aim++;
            }
            list[6] = nature_txt[random[aim] % 25];
            if (!syc) //性格
            {
                aim++;
            }
            if (!jun_d) //性別
            {
                list[12] = (random[aim] % 252).ToString(); aim++; //性別
                list[18] = (random[aim] % 100).ToString();　aim++;//持ち物
            }

            list[19] = aim.ToString(); //消費数

            return list;
        }
        private bool k_Search(string[] row, string[] key)
        {
            for (int i = 0; i < 6; i++)
            {
                string ab = key[i];
                if (ab == "-")
                    continue;

                int iv = Convert.ToInt32(row[r_no[i + 4]]);
                if (ab == "偶")
                {
                    if (iv % 2 != 0)
                        return false;
                }
                else if (ab == "奇")
                {
                    if (iv % 2 != 1)
                        return false;
                }
                else if (checks_d[i])
                {
                    int ivk = Convert.ToInt32(ab);
                    if (ivk - 1 > iv || ivk + 1 < iv)
                        return false;
                }
                else if (row[r_no[i + 4]] != ab)
                        return false;
            }
            
            if (row[r_no[10]] != key[6] && key[6] != "‐")
                return false;

            if (only_shiny && row[r_no[12]]  != "★")
                return false;

            if (only_synchronize && syc_d && row[r_no[11]] != "○")
                return false;

            if (only_ub && ub_d && ubs_d != -1 && row[r_no[19]] != "○")
                return false;

            return true;
        }

        private void copy_ran_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem item = new ListViewItem();
            item = listView1.SelectedItems[0];

            string res = item.SubItems[1].Text;
            Clipboard.SetText(res);
        }
        private void copy_all_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem item = new ListViewItem();
            item = listView1.SelectedItems[0];

            string res = item.SubItems[0].Text;

            for (int i = 1; i <= item.SubItems.Count - 1; i++)
            {
                res += "," + item.SubItems[i].Text;
            }

            Clipboard.SetText(res);
        }
        private void set_Goal_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem item = new ListViewItem();
            item = listView1.SelectedItems[0];

            max_o.Value = Convert.ToDecimal(item.SubItems[0].Text);
        }

        private void b_6v_Click(object sender, EventArgs e)
        {
            set_combo(34);
        }
        private void b_reset_Click(object sender, EventArgs e)
        {
            set_combo(0);
        }
        private void set_combo(int p)
        {
            for(int i = 0; i < 6; i++)
            {
                combo[i].SelectedIndex = p;
            }

            if (p == 0)
            {
                combo[6].SelectedIndex = 0;

                for (int i = 0; i < 6; i++)
                {
                    Check[i].Checked = false;
                }
            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            uint seed;
            try
            {
                seed = Convert.ToUInt32(seed_o.Text, 16);
            }
            catch
            {
                MessageBox.Show("seed値が不正です。");
                return;
            }
            uint min = Convert.ToUInt32(min_o.Text);
            uint max = Convert.ToUInt32(max_o.Text);
            long maximum = max - min;
            int cnt = 0;
            string key = textBox1.Text;
            string str = "";
            string result = "";

            if (key == "")
                return;

            sfmt_set_seed(seed);

            int ii = 0;
            int leng = key.Length;

            for (int i = 0; i < min; i++, ii++)
                sfmt_next();

            for (int i = 0; i < leng; i++)
                str += get_sin(sfmt_next() % 17);

            for (int i = 0; i <= maximum; i++, ii++)
            {
                if (String.Compare(str, key, true) == 0)
                {
                    int iil = ii + key.Length + 1;
                    if (result == "")
                    {
                        result += "消費:" + iil;
                        Clipboard.SetText(iil.ToString());
                    }
                    else
                        result += ", " + iil;
                    cnt++;
                }

                str = str.Substring(1);
                str += get_sin(sfmt_next() % 17);
            }

            if (result != "")
                MessageBox.Show(result);
            else
                MessageBox.Show("候補が見つかりませんでした。");
        }

        private void write_file()
        {
            string[] str = new string[6];
            str[0] = seed_o.Text;
            str[1] = min_o.Text;
            str[2] = max_o.Text;
            str[3] = textBox1.Text;
            str[4] = this.Width.ToString();
            str[5] = this.Height.ToString();

            File.WriteAllLines(save_file, str);
        }
        private void read_file()
        {
            if (File.Exists(save_file))
            {
                string[] str = File.ReadAllLines(save_file);
                seed_o.Text = str[0];
                min_o.Text = str[1];
                max_o.Text = str[2];
                textBox1.Text = str[3];
                this.Width = Convert.ToInt32(str[4]);
                this.Height = Convert.ToInt32(str[5]);
            }
        }
        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            write_file();
        }
        private void config_read()
        {
            if (File.Exists(config_file))
            {
                string[] str = File.ReadAllLines(config_file);
                int cnt = 0;
                for(int i = 0; i < str.Length; i++)
                {
                    if (!str[i].StartsWith("//"))
                    {
                        try
                        {
                            ret[cnt] = Convert.ToInt32(str[i]);
                        }
                        catch {}
                        cnt++;
                    }

                    if (cnt > ret.Length)
                        break;
                }
            }
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int def_x = 40, def_y = 202;
            Control c = (Control)sender;

            listView1.Width = c.Width - def_x;
            listView1.Height = c.Height - def_y;
        }
    }
}
