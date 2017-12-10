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

        private static Form1 _instance;
        public static Form1 Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new Form1();
                }
                return _instance;
            }
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
        int[] ret = { -1 };
        int[] p_table = { 20, 40, 50, 60, 70, 80, 90, 95, 99, 100};
        int[] gender_table = { 126, 0, 189, 63, 30 };
        int[] item_table = { 50, 55, 60, 80, 100 };
        string[][] item_txt;

        List<ComboBox> combo = new List<ComboBox>();
        List<ComboBox> combo2 = new List<ComboBox>();
        List<CheckBox> Check = new List<CheckBox>();
        string save_file = config_path + "/From1.ini";
        string config_file = config_path + "/tsv.txt";
        string mode_config = config_path + "/mode.ini";
        public static string config_path = "./config";
        public static bool input_mode17;
        string list_folder = "list";
        private bool cancel = false;
        plist p_list;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(Form_Closed);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            list_o.SelectedIndexChanged += new EventHandler(list_change);

            if (!Directory.Exists(config_path))
                Directory.CreateDirectory(config_path);

            item_txt = new string[3][];
            item_txt[0] = new string[] { "○", "●", "●", "-", "-" };
            item_txt[1] = new string[] { "-", "☆", "-", "★", "-" };
            item_txt[2] = new string[] { "○", "☆", "●", "★", "-" };

            string[] columns = { "消費", "乱数列", "針", "め", "H", "A", "B", "C", "D", "S", "性格", "技", "し", "ec", "pid", "性", "特", "psv", "個", "UB", "種族名", "Lv", "持", "消", "エ"};
            
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
            listView1.Columns.Add(columns[20], 100); r_no_list.Add(20);//種族名
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
            combo.Add(comboBox20);

            combo2.Add(comboBox8);
            combo2.Add(comboBox9);
            combo2.Add(comboBox10);
            combo2.Add(comboBox11);
            combo2.Add(comboBox12);
            combo2.Add(comboBox13);
            combo2.Add(comboBox14);
            combo2.Add(comboBox15);
            combo2.Add(comboBox16);
            combo2.Add(comboBox17);
            combo2.Add(comboBox18);
            combo2.Add(comboBox19);

            Check.Add(checkBox1);
            Check.Add(checkBox2);
            Check.Add(checkBox3);
            Check.Add(checkBox4);
            Check.Add(checkBox5);
            Check.Add(checkBox6);

            string iv_t = "0";
            for (int i = 1; i < 32; i++)
                iv_t += "\n" + i;

            string[] iv_ts = ("-\n偶\n奇\n" + iv_t).Split('\n');
            string[] iv_ts2 = iv_t.Split('\n');

            for (int i = 0; i < 6; i++)
            {
                combo[i].Items.AddRange(iv_ts);
                combo[i].SelectedIndex = 0;
            }

            for (int i = 0; i < 12; i++)
            {
                combo2[i].Items.AddRange(iv_ts2);
                combo2[i].SelectedIndex = i < 6 ? 0 : 31;
            }

            string[] nature_items = new string[nature_txt.Length];
            nature_txt.CopyTo(nature_items, 0);
            Array.Sort(nature_items);
            for (int i = 6; i <= 7; i++)
            {
                combo[i].Items.Add("-");
                combo[i].Items.AddRange(nature_items);
                combo[i].SelectedIndex = 0;
            }

            gender_o.SelectedIndex = 0;
            ability_o.SelectedIndex = 0;
            item_o.SelectedIndex = 0;

            read_file();
            config_read();
            read_list_file();

            if (!File.Exists(mode_config))
            {
                Form5 form5 = new Form5();
                form5.ShowDialog();
            }
            else
            {
                input_mode17 = File.ReadAllText(mode_config) == "True";
            }
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
            if (radioButton1.Checked)
            {
                int pm = (int)numericUpDown1.Value;
                maxrow = pm * 2 + 1;
                min = (int)max_o.Value - pm;
                max = (int)max_o.Value + pm;
            }
            else
            {
                maxrow = (int)numericUpDown2.Value;
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
            int[] iv_min = new int[6], iv_max = new int[6];
            int ii = 0;
            bool eye = false;
            bool eye_at = false, clc = true, eye_at_c = blink_c.Checked;
            bool iv_s = checkBox8.Checked;
            int eye1 = 33, eye2 = 39;
            int rowleng = r_no.Length;
            get_datas();

            if (maximum < 0)
            {
                MessageBox.Show("minよりmaxの値が小さいです。");
                return;
            }

            for (int i = 0; i < 7; i++)
                key[i] = combo[i].Text;
            for (int i = 0; i < 6; i++)
            {
                iv_min[i] = Convert.ToInt32(combo2[i].Text);
                iv_max[i] = Convert.ToInt32(combo2[i + 6].Text);
            }

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

                if (eye_at)
                {
                    clc = true;
                    eye_at = false;
                }
                else
                {
                    clc = false;
                }

                if (eye)
                {
                    if (random[0] % 3 == 0)
                    {
                        row[r_no[3]] = eye2.ToString();
                    }
                    else
                    {
                        row[r_no[3]] = eye1.ToString();
                    }

                    eye = false;
                    eye_at = true;
                }
                else
                {
                    if (random[0] % 128 == 0)
                    {
                        row[r_no[3]] = "★";
                        eye = true;
                    }
                    else row[r_no[3]] = "-";
                }
                
                if (!eye_at_c || clc)
                {
                    string[] list;
                    list = get_sta(random, clc, eye_at);

                    for (int k = 0; k < list.Length; k++)
                        row[r_no[k + 4]] = list[k];

                    bool k_s;
                    if (iv_s) k_s = k_Search(row, iv_min, iv_max, key[6]);
                    else k_s = k_Search(row, key);

                    if (k_s)
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

                if (cnt >= maxrow)
                    break;
            }
            Search.Text = "計算";

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

        bool[] checks_d = new bool[6];
        bool jun_d, ub_d, charm_d, syc_d, honey_d, yas_d, abl_d, enc_d, nazo60_d;
        bool only_shiny, only_ub, only_synchronize, only_enc, sync_nature, one_nazo;
        int nazo_d, nazo2_d, ubs_d, enct_d;
        int gender_d, ability_d, item_d;
        ulong lv_h;
        string nature_d, name_d, lv_d, itemt_d;
        CheckBox[] checks = new CheckBox[12];

        private void get_datas()
        {
            jun_d = jun_c.Checked;
            ub_d = ub_c.Checked;
            charm_d = charm_c.Checked;
            syc_d = syc_c.Checked;
            honey_d = honey_c.Checked;
            nazo_d = (int)nazo_o.Value;
            nazo2_d = (int)nazo2_o.Value;
            one_nazo = nazo2_d == 0 || nazo_d > nazo2_d;
            yas_d = yas_o.Checked;
            abl_d = abl_o.Checked;
            enc_d = yas_d || ub_d;
            ubs_d = (int)ubs_o.Value;
            enct_d = (int)enct_o.Value;
            nazo60_d = nazo60_c.Checked;

            for (int i = 0; i < 6; i++)
                checks_d[i] = Check[i].Checked;

            only_shiny = shiny_c.Checked;
            only_ub = ubs_c.Checked;
            only_synchronize = sycs_c.Checked;
            only_enc = enct_c.Checked;
            nature_d = combo[7].Text;
            sync_nature = nature_d != "-";
            name_d = name_o.Enabled ? name_o.Text : "-";
            lv_d = lv_o.Enabled ? lv_o.Text : "-";
            gender_d = gender_o.Enabled ? gender_o.SelectedIndex : 0;
            ability_d = ability_o.Enabled ? ability_o.SelectedIndex : 0;
            item_d = item_o.Enabled ? item_o.SelectedIndex : 0;
            itemt_d = item_o.Text;

            lv_h = (ulong)(p_list.lv_max - p_list.lv_min + 1);
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
        private string[] get_sta(List<ulong> random, bool blink, bool blink2)
        {
            string[] list = new string[20];
            int aim = 0;
            int[] ivs = new int[6];
            int cnt = 0;
            bool syc = false;
            int tsv = ret[0];
            int p_id = 0;

            if (!honey_d) //シンクロ
            {
                if (syc_d)
                {
                    syc = random[aim] % 100 >= 50;
                    list[7] = syc ? "○" : "×";
                }
                aim++;
            }
            if (!honey_d && enc_d) //エンカウント
            {
                if (enct_d == -1)
                    list[14] = (random[aim] % 100).ToString();
                else
                    list[14] = (int)(random[aim] % 100) < enct_d ? "○" : "×";
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
            if (honey_d) //シンクロ
            {
                if (syc_d)
                {
                    syc = random[aim] % 100 >= 50;
                    list[7] = syc ? "○" : "×";
                }
                aim++;
            }
            if (yas_d)
            {
                int ran = (int)(random[aim] % 100); aim++; //出現ポケモン
                for (int i = 0; i < 10; i++)
                    if (ran < p_table[i])
                    {
                        p_id = i;
                        break;
                    }
                
                list[16] = p_list.name[p_id];

                list[17] = (p_list.lv_min + (int)(random[aim] % lv_h)).ToString(); aim++;   //レベル
                aim++; //プレッシャー
            }
            if (!yas_d) //瞬き割り込み
            {
                if (blink2)
                {
                    aim += nazo_d > 4 ? 1 : 0;
                }
                else if (!blink)
                {
                    for (int i = 0; i < nazo_d; i++)
                    {
                        int ran = (int)(random[aim] & 127); aim++;
                        if (ran == 0)
                        {
                            aim += nazo_d - i > 4 ? 1 : 0;
                            break;
                        }
                    }
                }
            }

            if (nazo60_d)
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

            while (cnt < 3 && jun_d && !yas_d) //準伝V
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

            if (abl_d || yas_d) //特性
            {
                list[13] = (random[aim] % 2 + 1).ToString();
                aim++;
            }

            if (sync_nature && syc)
                list[6] = nature_d;
            else
                list[6] = nature_txt[random[aim] % 25];
            if (!syc) //性格
            {
                aim++;
            }
            if (!jun_d || yas_d)
            {
                int g_t = gender_table[p_list.gender[p_id]]; //性別
                if (g_t != 0)
                {
                    list[12] = (int)(random[aim] % 252) >= g_t ? "♂" : "♀"; aim++;
                }
                else list[12] = "-";

                int i_t = p_list.item[p_id]; //持ち物
                if (i_t == 0)
                    list[18] = "-";
                else
                {
                    int ran = (int)(random[aim] % 100); aim++;
                    for (int i = 0; i < 5; i++)
                        if (ran < item_table[i])
                        {
                            list[18] = item_txt[i_t - 1][i];
                            break;
                        }
                }
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

            return s_Search(row, key[6]);
        }
        private bool k_Search(string[] row, int[] min, int[] max, string nature)
        {
            for (int i = 0; i < 6; i++)
            {
                int iv = Convert.ToInt32(row[r_no[i + 4]]);
                if (min[i] <= max[i])
                {
                    if (iv < min[i])
                        return false;
                    if (iv > max[i])
                        return false;
                }
                else
                {
                    if (iv > min[i])
                        return false;
                    if (iv < max[i])
                        return false;
                }
            }

            return s_Search(row, nature);
        }
        private bool s_Search(string[] row, string nature)
        {
            if (row[r_no[10]] != nature && nature != "-") //性格
                return false;

            if (only_shiny && row[r_no[12]] != "★") //色違い
                return false;

            if (only_synchronize && row[r_no[11]] == "×") //シンクロ
                return false;

            if (only_ub && row[r_no[19]] == "×") //UB
                return false;

            if (only_enc && row[r_no[18]] == "×") //エンカウント
                return false;
            
            string str = row[r_no[16]]; //性別
            if (gender_d == 1 && str != "♂")
                return false;
            else if (gender_d == 2 && str != "♀")
                return false;

            if (ability_d != 0 && row[r_no[17]] != ability_d.ToString()) //特性
                return false;

            if (name_d != "-" && row[r_no[20]] != name_d) //種族
                return false;

            if (lv_d != "-" && row[r_no[21]] != lv_d) //Lv
                return false;
            
            if (item_d != 0) //持ち物
            {
                str = row[r_no[22]];
                if (item_d < 5)
                {
                    if (str != itemt_d)
                        return false;
                }
                else if (item_d == 5)
                {
                    if (str != "○" && str != "●")
                        return false;
                }
                else
                {
                    if (str != "☆" && str != "★")
                        return false;
                }
            }

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

        private void ub_c_CheckedChanged(object sender, EventArgs e)
        {
            bool b = ub_c.Checked;

            ubs_c.Enabled = b;
            ubs_o.Enabled = b;
            label12.Enabled = b;

            honey_c.Enabled = b || yas_o.Checked;
        }
        private void yas_o_CheckedChanged(object sender, EventArgs e)
        {
            bool b = yas_o.Checked;

            list_o.Enabled = b;
            enct_c.Enabled = b && !honey_c.Checked;
            enct_o.Enabled = b && !honey_c.Checked;
            name_o.Enabled = b;
            lv_o.Enabled = b;
            gender_o.Enabled = b;
            ability_o.Enabled = b;
            item_o.Enabled = b;
            label17.Enabled = b;
            label18.Enabled = b;
            label19.Enabled = b;
            label20.Enabled = b;
            label21.Enabled = b;
            label22.Enabled = b;

            jun_c.Enabled = !b;
            abl_o.Enabled = !b;
            nazo_o.Enabled = !b;
            nazo2_o.Enabled = !b;
            label13.Enabled = !b;
            honey_c.Enabled = b || ub_c.Checked;
        }
        private void syc_c_CheckedChanged(object sender, EventArgs e)
        {
            bool b = syc_c.Checked;

            sycs_c.Enabled = b;
            combo[7].Enabled = b;
            label16.Enabled = b;
        }
        private void honey_c_CheckedChanged(object sender, EventArgs e)
        {
            bool b = honey_c.Checked;
            enct_c.Enabled = yas_d && !b;
            enct_o.Enabled = yas_d && !b;
        }
        private void abl_o_CheckedChanged(object sender, EventArgs e)
        {
            bool b = abl_o.Checked;
            ability_o.Enabled = b;
            label19.Enabled = b;
        }
        private void blink_c_CheckedChanged(object sender, EventArgs e)
        {
            bool b = blink_c.Checked || yas_o.Checked;
            nazo_o.Enabled = !b;
            nazo2_o.Enabled = !b;
            label13.Enabled = !b;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bool b = radioButton1.Checked;
            numericUpDown1.Enabled = b;
            numericUpDown2.Enabled = !b;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bool b = radioButton2.Checked;
            numericUpDown1.Enabled = !b;
            numericUpDown2.Enabled = b;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            bool b = checkBox8.Checked;

            for (int i = 0; i < 6; i++)
            {
                Check[i].Visible = !b;
                combo[i].Visible = !b;
            }

            for (int i = 0; i < 12; i++)
            {
                combo2[i].Visible = b;
            }
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
                combo[7].SelectedIndex = 0;

                for (int i = 0; i < 6; i++)
                {
                    Check[i].Checked = false;
                }

                for (int i = 0; i < 12; i++)
                {
                    combo2[i].SelectedIndex = i < 6 ? 0 : 31;
                }
            }

            if (p == 34)
            {
                for (int i = 0; i < 12; i++)
                {
                    combo2[i].SelectedIndex = 31;
                }
            }
        }

        public string convert_needle(string key)
        {
            string str = "";
            if (key[key.Length - 1] == ',')
                key = key.Substring(0, key.Length - 1);

            string[] keys = key.Split(',');
            for (int i = 0; i < keys.Length; i++)
            {
                int j = 0;
                try
                {
                    j = Convert.ToInt32(keys[i]);
                }
                catch
                {
                    return "";
                }
                if (j >= 0 && j <= 9)
                    str += keys[i];
                else if (j >= 10 && j <= 16)
                {
                    char c = (char)(j + 55);
                    str += c;
                }
                else
                {
                    str += "?";
                }
            }

            return str;
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
            int min = Convert.ToInt32(min_o.Text);
            int max = Convert.ToInt32(max_o.Text);
            int maximum = max - min;
            int cnt = 0;
            string key = textBox1.Text;
            string str = "";
            string result = "";
            int resultcnt = 0;
            int nresult = 0;

            if (maximum < 0)
            {
                MessageBox.Show("minよりmaxの値が小さいです。");
                return;
            }

            if (key == "")
                return;

            if (!input_mode17)
            {
                key = convert_needle(key);
                if (key == "")
                {
                    MessageBox.Show("針の値が不正です。");
                    return;
                }
            }
            
            int ii = 0;
            int leng = key.Length;
            
            sfmt_set_seed(seed);
            for (int i = 0; i < min; i++, ii++)
                sfmt_next();

            for (int i = 0; i < leng; i++)
                str += get_sin(sfmt_next() % 17);

            for (int i = 0; i <= maximum; i++, ii++)
            {
                if (String.Compare(str, key, true) == 0)
                {
                    int iil = ii + key.Length;
                    if (resultcnt == 0)
                    {
                        result += iil;
                        Clipboard.SetText(iil.ToString());
                        nresult = iil;
                        resultcnt++;
                    }
                    else
                    {
                        result += ", " + iil;
                        resultcnt++;
                    }
                    cnt++;
                }

                str = str.Substring(1);
                str += get_sin(sfmt_next() % 17);
            }

            if (resultcnt == 1)
            {
                Form4.Instance.act = true;
                Form4.Instance.nresult = nresult;
                Form4.Instance.key_length = key.Length;
                Form4.Instance.Show();
                Form4.Instance.Activate();
            }
            else if (resultcnt > 1)
                MessageBox.Show("候補：" + result);
            else
                MessageBox.Show("候補が見つかりませんでした。");
        }

        private void set_cheks()
        {
            checks[0] = syc_c;
            checks[1] = honey_c;
            checks[2] = jun_c;
            checks[3] = abl_o;
            checks[4] = nazo60_c;
            checks[5] = sycs_c;
            checks[6] = ub_c;
            checks[7] = ubs_c;
            checks[8] = charm_c;
            checks[9] = shiny_c;
            checks[10] = yas_o;
            checks[11] = blink_c;
        }
        private void write_file()
        {
            string[] str = new string[22];
            str[0] = seed_o.Text;
            str[1] = min_o.Text;
            str[2] = max_o.Text;
            str[3] = textBox1.Text;
            str[4] = this.Width.ToString();
            str[5] = this.Height.ToString();
            str[6] = numericUpDown1.Text;
            str[7] = numericUpDown2.Text;
            str[8] = ubs_o.Text;
            str[9] = nazo_o.Text;
            for (int i = 0; i < 12; i++)
            {
                str[10 + i] = checks[i].Checked.ToString();
            }

            File.WriteAllLines(save_file, str);
        }
        private void read_file()
        {
            set_cheks();
            if (File.Exists(save_file))
            {
                string[] str = File.ReadAllLines(save_file);
                if (str.Length < 22)
                {
                    MessageBox.Show("デフォルトの設定で起動します。");
                    return;
                }

                seed_o.Text = str[0];
                min_o.Text = str[1];
                max_o.Text = str[2];
                textBox1.Text = str[3];
                this.Width = Convert.ToInt32(str[4]);
                this.Height = Convert.ToInt32(str[5]);
                numericUpDown1.Text = str[6];
                numericUpDown2.Text = str[7];
                ubs_o.Text = str[8];
                nazo_o.Text = str[9];

                for (int i = 0; i < 12; i++)
                {
                    checks[i].Checked = str[10 + i] == "True";
                }
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
            int def_x = 40, def_y = 230;
            Control c = (Control)sender;

            listView1.Width = c.Width - def_x;
            listView1.Height = c.Height - def_y;
        }

        private void read_list_file()
        {
            if (!Directory.Exists(list_folder))
            {
                Directory.CreateDirectory(list_folder);
                return;
            }
            
            string[] files = Directory.GetFiles(list_folder, "*.txt");

            foreach (string s in files)
            {
                list_o.Items.Add(Path.GetFileName(s));
            }

            plist list;
            if (list_o.Items.Count <= 0)
            {
                list_o.Items.Add("none");
                list = new plist();
            }
            else
            {
                list = new plist(files[0]);
                if (!list.success)
                    list = new plist();
            }
            list_o.SelectedIndex = 0;

            set_plist(list);
        }
        private void set_plist(plist list)
        {
            List<string> lstr = new List<string>();
            foreach (string s in list.name)
            {
                bool b = true;
                foreach (string s2 in lstr)
                    if (s == s2)
                    {
                        b = false;
                        break;
                    }
                if (b) lstr.Add(s);
            }
            name_o.Items.Clear();
            name_o.Items.Add("-");
            name_o.Items.AddRange(lstr.ToArray());
            name_o.SelectedIndex = 0;

            lv_o.Items.Clear();
            lv_o.Items.Add("-");
            for (int i = list.lv_min; i <= list.lv_max; i++)
                lv_o.Items.Add(i);

            lv_o.SelectedIndex = 0;

            p_list = list;
        }
        private void list_change(object sender, EventArgs e)
        {
            if (p_list != null)
            {
                plist list = new plist(list_folder + "/" + list_o.Text);

                if (list.success)
                    set_plist(list);
                else
                    set_plist(new plist());
            }
        }

        private void Seed_Search_Click(object sender, EventArgs e)
        {
            Form2.Instance.Show();
            Form2.Instance.Activate();
        }
        private void frame_search_Click(object sender, EventArgs e)
        {
            Form3.Instance.min_o.Value = min_o.Value;
            Form3.Instance.max_o.Value = max_o.Value;
            Form3.Instance.Show();
            Form3.Instance.Activate();
        }
    }

    class plist
    {
        public string[] name = new string[10];
        public int[] item = new int[10];
        public int[] gender = new int[10];
        public int lv_min, lv_max;
        public bool success;

        public plist()
        {
            lv_min = 0;
            lv_max = 4;
            for (int i = 0; i < 10; i++)
            {
                name[i] = "p" + (i + 1);
                item[i] = 3;
            }
            success = true;
        }
        public plist(string file)
        {
            try
            {
                string[] strs = File.ReadAllLines(file, Encoding.GetEncoding("shift-jis"));
                int cnt = -1;
                foreach (string str in strs)
                {
                    if (!str.StartsWith("//"))
                    {
                        string[] s = str.Split(',');
                        if (cnt == -1)
                        {
                            int lv1 = Convert.ToInt32(s[0]);
                            int lv2 = Convert.ToInt32(s[1]);

                            lv_min = lv1 < lv2 ? lv1 : lv2;
                            lv_max = lv1 >= lv2 ? lv1 : lv2;
                        }
                        else
                        {
                            name[cnt] = s[0];
                            if (s.Length >= 2 && s[1] != "")
                                item[cnt] = Convert.ToInt32(s[1]);
                            if (s.Length >= 3 && s[2] != "")
                                gender[cnt] = Convert.ToInt32(s[2]);
                        }
                        cnt++;
                    }

                    if (cnt >= 10)
                        break;
                }

                if (cnt == 10)
                    success = true;
            }
            catch
            {
                MessageBox.Show(file + "の読み込みに失敗しました。");
                success = false;
            }
        }
    }
}
