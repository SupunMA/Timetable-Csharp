
namespace interfaces
{
    partial class supunEditStudent
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddTags = new System.Windows.Forms.Label();
            this.searchCloseBtn = new System.Windows.Forms.Label();
            this.searchBoxLable = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.supGroupIDDisplay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupIDDisplay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.subIDlabel = new System.Windows.Forms.Label();
            this.subIDpanel = new System.Windows.Forms.Panel();
            this.txtSubGroup = new System.Windows.Forms.TextBox();
            this.radioWeekend = new System.Windows.Forms.RadioButton();
            this.radioWeek = new System.Windows.Forms.RadioButton();
            this.progPanel = new System.Windows.Forms.Panel();
            this.comboProg = new System.Windows.Forms.ComboBox();
            this.ysPanel = new System.Windows.Forms.Panel();
            this.comboYearSem = new System.Windows.Forms.ComboBox();
            this.mainIDlabel = new System.Windows.Forms.Label();
            this.mainidPanel = new System.Windows.Forms.Panel();
            this.txtMainGroup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectSubject = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.refresh = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(1, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 5);
            this.panel1.TabIndex = 21;
            // 
            // AddTags
            // 
            this.AddTags.AutoSize = true;
            this.AddTags.BackColor = System.Drawing.Color.Transparent;
            this.AddTags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTags.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddTags.Location = new System.Drawing.Point(8, 3);
            this.AddTags.Name = "AddTags";
            this.AddTags.Size = new System.Drawing.Size(247, 29);
            this.AddTags.TabIndex = 20;
            this.AddTags.Text = "Edit Student Groups";
            // 
            // searchCloseBtn
            // 
            this.searchCloseBtn.AutoSize = true;
            this.searchCloseBtn.BackColor = System.Drawing.Color.Red;
            this.searchCloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchCloseBtn.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.searchCloseBtn.Location = new System.Drawing.Point(615, 15);
            this.searchCloseBtn.Name = "searchCloseBtn";
            this.searchCloseBtn.Size = new System.Drawing.Size(27, 25);
            this.searchCloseBtn.TabIndex = 35;
            this.searchCloseBtn.Text = "X";
            this.searchCloseBtn.Click += new System.EventHandler(this.searchCloseBtn_Click);
            // 
            // searchBoxLable
            // 
            this.searchBoxLable.AutoSize = true;
            this.searchBoxLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.searchBoxLable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBoxLable.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBoxLable.ForeColor = System.Drawing.Color.White;
            this.searchBoxLable.Location = new System.Drawing.Point(447, 22);
            this.searchBoxLable.Name = "searchBoxLable";
            this.searchBoxLable.Size = new System.Drawing.Size(111, 16);
            this.searchBoxLable.TabIndex = 36;
            this.searchBoxLable.Text = "Type here to Search";
            this.searchBoxLable.Click += new System.EventHandler(this.searchBoxLable_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(390, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 3);
            this.panel3.TabIndex = 38;
            // 
            // txtsearch
            // 
            this.txtsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.ForeColor = System.Drawing.Color.White;
            this.txtsearch.Location = new System.Drawing.Point(390, 15);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(220, 27);
            this.txtsearch.TabIndex = 37;
            this.txtsearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsearch.Click += new System.EventHandler(this.txtsearch_Click);
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            this.txtsearch.Leave += new System.EventHandler(this.txtsearch_Leave);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 61);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(843, 270);
            this.dataGridView.TabIndex = 34;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.idLabel);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.BtnReset);
            this.panel2.Controls.Add(this.subIDlabel);
            this.panel2.Controls.Add(this.subIDpanel);
            this.panel2.Controls.Add(this.txtSubGroup);
            this.panel2.Controls.Add(this.radioWeekend);
            this.panel2.Controls.Add(this.radioWeek);
            this.panel2.Controls.Add(this.progPanel);
            this.panel2.Controls.Add(this.comboProg);
            this.panel2.Controls.Add(this.ysPanel);
            this.panel2.Controls.Add(this.comboYearSem);
            this.panel2.Controls.Add(this.mainIDlabel);
            this.panel2.Controls.Add(this.mainidPanel);
            this.panel2.Controls.Add(this.txtMainGroup);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.selectSubject);
            this.panel2.Controls.Add(this.id);
            this.panel2.Location = new System.Drawing.Point(13, 337);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 287);
            this.panel2.TabIndex = 39;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(185, 245);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 35);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.idLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.idLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.idLabel.Location = new System.Drawing.Point(212, 19);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(75, 17);
            this.idLabel.TabIndex = 44;
            this.idLabel.Text = "Ex: 1 / 2 / 3";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Location = new System.Drawing.Point(211, 42);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(172, 3);
            this.panel5.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(8, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "ID Number";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.supGroupIDDisplay);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.groupIDDisplay);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(437, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(285, 160);
            this.panel4.TabIndex = 40;
            // 
            // supGroupIDDisplay
            // 
            this.supGroupIDDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.supGroupIDDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.supGroupIDDisplay.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supGroupIDDisplay.ForeColor = System.Drawing.Color.White;
            this.supGroupIDDisplay.Location = new System.Drawing.Point(13, 118);
            this.supGroupIDDisplay.MaxLength = 10;
            this.supGroupIDDisplay.Name = "supGroupIDDisplay";
            this.supGroupIDDisplay.ReadOnly = true;
            this.supGroupIDDisplay.Size = new System.Drawing.Size(259, 27);
            this.supGroupIDDisplay.TabIndex = 39;
            this.supGroupIDDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.supGroupIDDisplay.TextChanged += new System.EventHandler(this.supGroupIDDisplay_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(2, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Sub Group ID";
            // 
            // groupIDDisplay
            // 
            this.groupIDDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.groupIDDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.groupIDDisplay.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupIDDisplay.ForeColor = System.Drawing.Color.White;
            this.groupIDDisplay.Location = new System.Drawing.Point(13, 46);
            this.groupIDDisplay.MaxLength = 10;
            this.groupIDDisplay.Name = "groupIDDisplay";
            this.groupIDDisplay.ReadOnly = true;
            this.groupIDDisplay.Size = new System.Drawing.Size(259, 27);
            this.groupIDDisplay.TabIndex = 38;
            this.groupIDDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.groupIDDisplay.TextChanged += new System.EventHandler(this.groupIDDisplay_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(2, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Group ID";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(204)))), ((int)(((byte)(31)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(41, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 35);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Update";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BtnReset.FlatAppearance.BorderSize = 0;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.White;
            this.BtnReset.Location = new System.Drawing.Point(325, 244);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(80, 35);
            this.BtnReset.TabIndex = 39;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // subIDlabel
            // 
            this.subIDlabel.AutoSize = true;
            this.subIDlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.subIDlabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.subIDlabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subIDlabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.subIDlabel.Location = new System.Drawing.Point(212, 199);
            this.subIDlabel.Name = "subIDlabel";
            this.subIDlabel.Size = new System.Drawing.Size(75, 17);
            this.subIDlabel.TabIndex = 35;
            this.subIDlabel.Text = "Ex: 1 / 2 / 3";
            // 
            // subIDpanel
            // 
            this.subIDpanel.BackColor = System.Drawing.Color.Red;
            this.subIDpanel.Location = new System.Drawing.Point(209, 221);
            this.subIDpanel.Name = "subIDpanel";
            this.subIDpanel.Size = new System.Drawing.Size(172, 3);
            this.subIDpanel.TabIndex = 37;
            // 
            // txtSubGroup
            // 
            this.txtSubGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.txtSubGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubGroup.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubGroup.ForeColor = System.Drawing.Color.White;
            this.txtSubGroup.Location = new System.Drawing.Point(209, 192);
            this.txtSubGroup.MaxLength = 2;
            this.txtSubGroup.Name = "txtSubGroup";
            this.txtSubGroup.Size = new System.Drawing.Size(172, 27);
            this.txtSubGroup.TabIndex = 36;
            this.txtSubGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSubGroup.TextChanged += new System.EventHandler(this.txtSubGroup_TextChanged);
            this.txtSubGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSubGroup_KeyPress);
            // 
            // radioWeekend
            // 
            this.radioWeekend.AutoSize = true;
            this.radioWeekend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.radioWeekend.ForeColor = System.Drawing.Color.White;
            this.radioWeekend.Location = new System.Drawing.Point(583, 32);
            this.radioWeekend.Name = "radioWeekend";
            this.radioWeekend.Size = new System.Drawing.Size(139, 22);
            this.radioWeekend.TabIndex = 34;
            this.radioWeekend.TabStop = true;
            this.radioWeekend.Text = "Weekend Days";
            this.radioWeekend.UseVisualStyleBackColor = true;
            this.radioWeekend.CheckedChanged += new System.EventHandler(this.radioWeekend_CheckedChanged_1);
            // 
            // radioWeek
            // 
            this.radioWeek.AutoSize = true;
            this.radioWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.radioWeek.ForeColor = System.Drawing.Color.White;
            this.radioWeek.Location = new System.Drawing.Point(465, 32);
            this.radioWeek.Name = "radioWeek";
            this.radioWeek.Size = new System.Drawing.Size(112, 22);
            this.radioWeek.TabIndex = 33;
            this.radioWeek.TabStop = true;
            this.radioWeek.Text = "Week Days";
            this.radioWeek.UseVisualStyleBackColor = true;
            this.radioWeek.CheckedChanged += new System.EventHandler(this.radioWeek_CheckedChanged_1);
            // 
            // progPanel
            // 
            this.progPanel.BackColor = System.Drawing.Color.Red;
            this.progPanel.Location = new System.Drawing.Point(208, 137);
            this.progPanel.Name = "progPanel";
            this.progPanel.Size = new System.Drawing.Size(156, 3);
            this.progPanel.TabIndex = 31;
            // 
            // comboProg
            // 
            this.comboProg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.comboProg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboProg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProg.ForeColor = System.Drawing.SystemColors.Window;
            this.comboProg.FormattingEnabled = true;
            this.comboProg.Items.AddRange(new object[] {
            "CSE ",
            "CSSE",
            "IM  ",
            "IT  "});
            this.comboProg.Location = new System.Drawing.Point(209, 106);
            this.comboProg.Name = "comboProg";
            this.comboProg.Size = new System.Drawing.Size(172, 28);
            this.comboProg.Sorted = true;
            this.comboProg.TabIndex = 32;
            this.comboProg.SelectedIndexChanged += new System.EventHandler(this.comboProg_SelectedIndexChanged);
            // 
            // ysPanel
            // 
            this.ysPanel.BackColor = System.Drawing.Color.Red;
            this.ysPanel.Location = new System.Drawing.Point(208, 90);
            this.ysPanel.Name = "ysPanel";
            this.ysPanel.Size = new System.Drawing.Size(157, 3);
            this.ysPanel.TabIndex = 29;
            // 
            // comboYearSem
            // 
            this.comboYearSem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.comboYearSem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboYearSem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboYearSem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboYearSem.ForeColor = System.Drawing.SystemColors.Window;
            this.comboYearSem.FormattingEnabled = true;
            this.comboYearSem.Items.AddRange(new object[] {
            "Y1.S1",
            "Y1.S2",
            "Y2.S1",
            "Y2.S2",
            "Y3.S1",
            "Y3.S2",
            "Y4.S1",
            "Y4.S2"});
            this.comboYearSem.Location = new System.Drawing.Point(209, 59);
            this.comboYearSem.Name = "comboYearSem";
            this.comboYearSem.Size = new System.Drawing.Size(172, 28);
            this.comboYearSem.Sorted = true;
            this.comboYearSem.TabIndex = 30;
            this.comboYearSem.SelectedIndexChanged += new System.EventHandler(this.comboYearSem_SelectedIndexChanged);
            // 
            // mainIDlabel
            // 
            this.mainIDlabel.AutoSize = true;
            this.mainIDlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.mainIDlabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mainIDlabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainIDlabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainIDlabel.Location = new System.Drawing.Point(212, 158);
            this.mainIDlabel.Name = "mainIDlabel";
            this.mainIDlabel.Size = new System.Drawing.Size(75, 17);
            this.mainIDlabel.TabIndex = 25;
            this.mainIDlabel.Text = "Ex: 1 / 2 / 3";
            // 
            // mainidPanel
            // 
            this.mainidPanel.BackColor = System.Drawing.Color.Red;
            this.mainidPanel.Location = new System.Drawing.Point(209, 180);
            this.mainidPanel.Name = "mainidPanel";
            this.mainidPanel.Size = new System.Drawing.Size(172, 3);
            this.mainidPanel.TabIndex = 27;
            // 
            // txtMainGroup
            // 
            this.txtMainGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.txtMainGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMainGroup.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMainGroup.ForeColor = System.Drawing.Color.White;
            this.txtMainGroup.Location = new System.Drawing.Point(209, 151);
            this.txtMainGroup.MaxLength = 2;
            this.txtMainGroup.Name = "txtMainGroup";
            this.txtMainGroup.Size = new System.Drawing.Size(172, 27);
            this.txtMainGroup.TabIndex = 26;
            this.txtMainGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMainGroup.TextChanged += new System.EventHandler(this.txtMainGroup_TextChanged);
            this.txtMainGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMainGroup_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(6, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sub Group Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(6, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Main Group Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(6, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Programme";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year and Semester";
            // 
            // selectSubject
            // 
            this.selectSubject.AutoSize = true;
            this.selectSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectSubject.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.selectSubject.Location = new System.Drawing.Point(501, 2);
            this.selectSubject.Name = "selectSubject";
            this.selectSubject.Size = new System.Drawing.Size(155, 20);
            this.selectSubject.TabIndex = 2;
            this.selectSubject.Text = "Select Batch Type";
            // 
            // id
            // 
            this.id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.id.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.ForeColor = System.Drawing.Color.White;
            this.id.Location = new System.Drawing.Point(211, 13);
            this.id.MaxLength = 10;
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(172, 27);
            this.id.TabIndex = 42;
            this.id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.id.TextChanged += new System.EventHandler(this.id_TextChanged);
            this.id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.id_KeyPress);
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.refresh.BackgroundImage = global::interfaces.Properties.Resources.refresh2;
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.refresh.FlatAppearance.BorderSize = 0;
            this.refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refresh.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.Location = new System.Drawing.Point(817, 337);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(32, 32);
            this.refresh.TabIndex = 40;
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // supunEditStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.searchCloseBtn);
            this.Controls.Add(this.searchBoxLable);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AddTags);
            this.Controls.Add(this.panel2);
            this.Name = "supunEditStudent";
            this.Size = new System.Drawing.Size(862, 634);
            this.Load += new System.EventHandler(this.supunEditStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label AddTags;
        private System.Windows.Forms.Label searchCloseBtn;
        private System.Windows.Forms.Label searchBoxLable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Label subIDlabel;
        private System.Windows.Forms.Panel subIDpanel;
        private System.Windows.Forms.TextBox txtSubGroup;
        private System.Windows.Forms.RadioButton radioWeekend;
        private System.Windows.Forms.RadioButton radioWeek;
        private System.Windows.Forms.Panel progPanel;
        private System.Windows.Forms.ComboBox comboProg;
        private System.Windows.Forms.Panel ysPanel;
        private System.Windows.Forms.ComboBox comboYearSem;
        private System.Windows.Forms.Label mainIDlabel;
        private System.Windows.Forms.Panel mainidPanel;
        private System.Windows.Forms.TextBox txtMainGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label selectSubject;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox supGroupIDDisplay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox groupIDDisplay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDelete;
    }
}
