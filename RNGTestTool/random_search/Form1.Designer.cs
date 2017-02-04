namespace random_search
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.seed_o = new System.Windows.Forms.TextBox();
            this.min_o = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.max_o = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Search = new System.Windows.Forms.Button();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copy_all = new System.Windows.Forms.ToolStripMenuItem();
            this.copy_ran = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.b_6v = new System.Windows.Forms.Button();
            this.b_reset = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.b_search = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.jun_c = new System.Windows.Forms.CheckBox();
            this.shiny_c = new System.Windows.Forms.CheckBox();
            this.charm_c = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.ub_c = new System.Windows.Forms.CheckBox();
            this.b_moves = new System.Windows.Forms.Button();
            this.honey_c = new System.Windows.Forms.CheckBox();
            this.syc_c = new System.Windows.Forms.CheckBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.min_o)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_o)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seed :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "消費数 :";
            // 
            // seed_o
            // 
            this.seed_o.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.seed_o.Location = new System.Drawing.Point(55, 12);
            this.seed_o.MaxLength = 8;
            this.seed_o.Name = "seed_o";
            this.seed_o.Size = new System.Drawing.Size(90, 22);
            this.seed_o.TabIndex = 3;
            this.seed_o.Text = "0";
            // 
            // min_o
            // 
            this.min_o.Location = new System.Drawing.Point(238, 15);
            this.min_o.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.min_o.Name = "min_o";
            this.min_o.Size = new System.Drawing.Size(80, 19);
            this.min_o.TabIndex = 4;
            this.min_o.Value = new decimal(new int[] {
            417,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "～";
            // 
            // max_o
            // 
            this.max_o.Location = new System.Drawing.Point(347, 15);
            this.max_o.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.max_o.Name = "max_o";
            this.max_o.Size = new System.Drawing.Size(80, 19);
            this.max_o.TabIndex = 6;
            this.max_o.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(50, 23);
            this.comboBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "HP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "攻撃";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(71, 63);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(50, 23);
            this.comboBox2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "防御";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(127, 63);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(50, 23);
            this.comboBox3.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "素早さ";
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(183, 63);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(50, 23);
            this.comboBox4.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "特防";
            // 
            // comboBox5
            // 
            this.comboBox5.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(239, 63);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(50, 23);
            this.comboBox5.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(195, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "特攻";
            // 
            // comboBox6
            // 
            this.comboBox6.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(295, 63);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(50, 23);
            this.comboBox6.TabIndex = 13;
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 153);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(704, 238);
            this.listView1.TabIndex = 19;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(337, 124);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(60, 23);
            this.Search.TabIndex = 20;
            this.Search.Text = "計算";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // comboBox7
            // 
            this.comboBox7.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(394, 48);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(100, 23);
            this.comboBox7.TabIndex = 21;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copy_all,
            this.copy_ran});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 48);
            // 
            // copy_all
            // 
            this.copy_all.Name = "copy_all";
            this.copy_all.Size = new System.Drawing.Size(160, 22);
            this.copy_all.Text = "列のコピー";
            this.copy_all.Click += new System.EventHandler(this.copy_all_Click);
            // 
            // copy_ran
            // 
            this.copy_ran.Name = "copy_ran";
            this.copy_ran.Size = new System.Drawing.Size(160, 22);
            this.copy_ran.Text = "乱数列のコピー";
            this.copy_ran.Click += new System.EventHandler(this.copy_ran_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(403, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "。";
            // 
            // b_6v
            // 
            this.b_6v.Location = new System.Drawing.Point(356, 85);
            this.b_6v.Name = "b_6v";
            this.b_6v.Size = new System.Drawing.Size(60, 23);
            this.b_6v.TabIndex = 24;
            this.b_6v.Text = "6V";
            this.b_6v.UseVisualStyleBackColor = true;
            this.b_6v.Click += new System.EventHandler(this.b_6v_Click);
            // 
            // b_reset
            // 
            this.b_reset.Location = new System.Drawing.Point(422, 85);
            this.b_reset.Name = "b_reset";
            this.b_reset.Size = new System.Drawing.Size(60, 23);
            this.b_reset.TabIndex = 25;
            this.b_reset.Text = "リセット";
            this.b_reset.UseVisualStyleBackColor = true;
            this.b_reset.Click += new System.EventHandler(this.b_reset_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(353, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "性格 :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.textBox1.Location = new System.Drawing.Point(447, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 22);
            this.textBox1.TabIndex = 27;
            // 
            // b_search
            // 
            this.b_search.Location = new System.Drawing.Point(656, 12);
            this.b_search.Name = "b_search";
            this.b_search.Size = new System.Drawing.Size(60, 23);
            this.b_search.TabIndex = 28;
            this.b_search.Text = "検索";
            this.b_search.UseVisualStyleBackColor = true;
            this.b_search.Click += new System.EventHandler(this.b_search_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(523, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "。";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 92);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 16);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "±1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(74, 92);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(42, 16);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.Text = "±1";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(130, 92);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(42, 16);
            this.checkBox3.TabIndex = 32;
            this.checkBox3.Text = "±1";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(186, 92);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(42, 16);
            this.checkBox4.TabIndex = 33;
            this.checkBox4.Text = "±1";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(242, 92);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(42, 16);
            this.checkBox5.TabIndex = 34;
            this.checkBox5.Text = "±1";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(298, 92);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(42, 16);
            this.checkBox6.TabIndex = 35;
            this.checkBox6.Text = "±1";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // jun_c
            // 
            this.jun_c.AutoSize = true;
            this.jun_c.Checked = true;
            this.jun_c.CheckState = System.Windows.Forms.CheckState.Checked;
            this.jun_c.Location = new System.Drawing.Point(499, 89);
            this.jun_c.Name = "jun_c";
            this.jun_c.Size = new System.Drawing.Size(48, 16);
            this.jun_c.TabIndex = 36;
            this.jun_c.Text = "準伝";
            this.jun_c.UseVisualStyleBackColor = true;
            // 
            // shiny_c
            // 
            this.shiny_c.AutoSize = true;
            this.shiny_c.Location = new System.Drawing.Point(499, 60);
            this.shiny_c.Name = "shiny_c";
            this.shiny_c.Size = new System.Drawing.Size(36, 16);
            this.shiny_c.TabIndex = 37;
            this.shiny_c.Text = "色";
            this.shiny_c.UseVisualStyleBackColor = true;
            // 
            // charm_c
            // 
            this.charm_c.AutoSize = true;
            this.charm_c.Location = new System.Drawing.Point(553, 60);
            this.charm_c.Name = "charm_c";
            this.charm_c.Size = new System.Drawing.Size(48, 16);
            this.charm_c.TabIndex = 38;
            this.charm_c.Text = "光守";
            this.charm_c.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(271, 128);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(60, 16);
            this.checkBox7.TabIndex = 39;
            this.checkBox7.Text = "列出力";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // ub_c
            // 
            this.ub_c.AutoSize = true;
            this.ub_c.Location = new System.Drawing.Point(553, 89);
            this.ub_c.Name = "ub_c";
            this.ub_c.Size = new System.Drawing.Size(40, 16);
            this.ub_c.TabIndex = 40;
            this.ub_c.Text = "UB";
            this.ub_c.UseVisualStyleBackColor = true;
            // 
            // b_moves
            // 
            this.b_moves.Location = new System.Drawing.Point(681, 43);
            this.b_moves.Name = "b_moves";
            this.b_moves.Size = new System.Drawing.Size(35, 23);
            this.b_moves.TabIndex = 41;
            this.b_moves.Text = "技";
            this.b_moves.UseVisualStyleBackColor = true;
            this.b_moves.Click += new System.EventHandler(this.b_moves_Click);
            // 
            // honey_c
            // 
            this.honey_c.AutoSize = true;
            this.honey_c.Location = new System.Drawing.Point(607, 89);
            this.honey_c.Name = "honey_c";
            this.honey_c.Size = new System.Drawing.Size(36, 16);
            this.honey_c.TabIndex = 42;
            this.honey_c.Text = "蜜";
            this.honey_c.UseVisualStyleBackColor = true;
            // 
            // syc_c
            // 
            this.syc_c.AutoSize = true;
            this.syc_c.Location = new System.Drawing.Point(607, 59);
            this.syc_c.Name = "syc_c";
            this.syc_c.Size = new System.Drawing.Size(60, 16);
            this.syc_c.TabIndex = 43;
            this.syc_c.Text = "シンクロ";
            this.syc_c.UseVisualStyleBackColor = true;
            // 
            // comboBox8
            // 
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox8.Location = new System.Drawing.Point(686, 85);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(30, 20);
            this.comboBox8.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(657, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 45;
            this.label13.Text = "謎 :";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(117, 128);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(94, 16);
            this.checkBox8.TabIndex = 46;
            this.checkBox8.Text = "まばたきあたっく";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 402);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboBox8);
            this.Controls.Add(this.syc_c);
            this.Controls.Add(this.honey_c);
            this.Controls.Add(this.b_moves);
            this.Controls.Add(this.ub_c);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.charm_c);
            this.Controls.Add(this.shiny_c);
            this.Controls.Add(this.jun_c);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.b_search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.b_reset);
            this.Controls.Add(this.b_6v);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.max_o);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.min_o);
            this.Controls.Add(this.seed_o);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(744, 426);
            this.Name = "Form1";
            this.Text = "こたいけいさん（べーた）";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.min_o)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_o)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox seed_o;
        private System.Windows.Forms.NumericUpDown min_o;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown max_o;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copy_all;
        private System.Windows.Forms.ToolStripMenuItem copy_ran;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button b_6v;
        private System.Windows.Forms.Button b_reset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button b_search;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox jun_c;
        private System.Windows.Forms.CheckBox shiny_c;
        private System.Windows.Forms.CheckBox charm_c;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox ub_c;
        private System.Windows.Forms.Button b_moves;
        private System.Windows.Forms.CheckBox honey_c;
        private System.Windows.Forms.CheckBox syc_c;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox8;
    }
}

