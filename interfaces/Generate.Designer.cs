
namespace interfaces
{
    partial class Generate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddTags = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnPDFlecturer = new System.Windows.Forms.Button();
            this.btnGenLecturer = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.selectLecCombo = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSTDpdf = new System.Windows.Forms.Button();
            this.btnSTDGenerate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboStdGrp = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnPDFlocation = new System.Windows.Forms.Button();
            this.btnLocationGenerate = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboLocation = new System.Windows.Forms.ComboBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.sessionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseDataSet = new interfaces.DatabaseDataSet();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.sessionsTableAdapter = new interfaces.DatabaseDataSetTableAdapters.SessionsTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(-4, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 5);
            this.panel1.TabIndex = 16;
            // 
            // AddTags
            // 
            this.AddTags.AutoSize = true;
            this.AddTags.BackColor = System.Drawing.Color.Transparent;
            this.AddTags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTags.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddTags.Location = new System.Drawing.Point(3, 0);
            this.AddTags.Name = "AddTags";
            this.AddTags.Size = new System.Drawing.Size(259, 29);
            this.AddTags.TabIndex = 15;
            this.AddTags.Text = "Generate Timetables";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(19, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(817, 559);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.tabPage1.Controls.Add(this.btnPDFlecturer);
            this.tabPage1.Controls.Add(this.btnGenLecturer);
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.selectLecCombo);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(809, 528);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  Lecturer  ";
            // 
            // btnPDFlecturer
            // 
            this.btnPDFlecturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPDFlecturer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPDFlecturer.FlatAppearance.BorderSize = 0;
            this.btnPDFlecturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDFlecturer.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDFlecturer.ForeColor = System.Drawing.Color.White;
            this.btnPDFlecturer.Location = new System.Drawing.Point(600, 12);
            this.btnPDFlecturer.Name = "btnPDFlecturer";
            this.btnPDFlecturer.Size = new System.Drawing.Size(151, 35);
            this.btnPDFlecturer.TabIndex = 33;
            this.btnPDFlecturer.Text = "Export as PDF";
            this.btnPDFlecturer.UseVisualStyleBackColor = false;
            this.btnPDFlecturer.Click += new System.EventHandler(this.btnPDFlecturerClick);
            // 
            // btnGenLecturer
            // 
            this.btnGenLecturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(204)))), ((int)(((byte)(31)))));
            this.btnGenLecturer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGenLecturer.FlatAppearance.BorderSize = 0;
            this.btnGenLecturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenLecturer.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenLecturer.ForeColor = System.Drawing.Color.White;
            this.btnGenLecturer.Location = new System.Drawing.Point(447, 12);
            this.btnGenLecturer.Name = "btnGenLecturer";
            this.btnGenLecturer.Size = new System.Drawing.Size(134, 35);
            this.btnGenLecturer.TabIndex = 32;
            this.btnGenLecturer.Text = "Generate";
            this.btnGenLecturer.UseVisualStyleBackColor = false;
            this.btnGenLecturer.Click += new System.EventHandler(this.btnGenLecturer_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Red;
            this.panel6.Location = new System.Drawing.Point(163, 47);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(220, 3);
            this.panel6.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Select Lecturer";
            // 
            // selectLecCombo
            // 
            this.selectLecCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.selectLecCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectLecCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectLecCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectLecCombo.ForeColor = System.Drawing.Color.White;
            this.selectLecCombo.FormattingEnabled = true;
            this.selectLecCombo.Location = new System.Drawing.Point(164, 16);
            this.selectLecCombo.Name = "selectLecCombo";
            this.selectLecCombo.Size = new System.Drawing.Size(234, 28);
            this.selectLecCombo.Sorted = true;
            this.selectLecCombo.TabIndex = 31;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(6, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(797, 449);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.tabPage2.Controls.Add(this.btnSTDpdf);
            this.tabPage2.Controls.Add(this.btnSTDGenerate);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.comboStdGrp);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(809, 528);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "  Student  ";
            // 
            // btnSTDpdf
            // 
            this.btnSTDpdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSTDpdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSTDpdf.FlatAppearance.BorderSize = 0;
            this.btnSTDpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSTDpdf.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTDpdf.ForeColor = System.Drawing.Color.White;
            this.btnSTDpdf.Location = new System.Drawing.Point(600, 12);
            this.btnSTDpdf.Name = "btnSTDpdf";
            this.btnSTDpdf.Size = new System.Drawing.Size(151, 35);
            this.btnSTDpdf.TabIndex = 39;
            this.btnSTDpdf.Text = "Export as PDF";
            this.btnSTDpdf.UseVisualStyleBackColor = false;
            this.btnSTDpdf.Click += new System.EventHandler(this.btnSTDpdf_Click);
            // 
            // btnSTDGenerate
            // 
            this.btnSTDGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(204)))), ((int)(((byte)(31)))));
            this.btnSTDGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSTDGenerate.FlatAppearance.BorderSize = 0;
            this.btnSTDGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSTDGenerate.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTDGenerate.ForeColor = System.Drawing.Color.White;
            this.btnSTDGenerate.Location = new System.Drawing.Point(447, 12);
            this.btnSTDGenerate.Name = "btnSTDGenerate";
            this.btnSTDGenerate.Size = new System.Drawing.Size(134, 35);
            this.btnSTDGenerate.TabIndex = 38;
            this.btnSTDGenerate.Text = "Generate";
            this.btnSTDGenerate.UseVisualStyleBackColor = false;
            this.btnSTDGenerate.Click += new System.EventHandler(this.btnSTDGenerate_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(195, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 3);
            this.panel2.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Select Student Group";
            // 
            // comboStdGrp
            // 
            this.comboStdGrp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.comboStdGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStdGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboStdGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStdGrp.ForeColor = System.Drawing.Color.White;
            this.comboStdGrp.FormattingEnabled = true;
            this.comboStdGrp.Location = new System.Drawing.Point(196, 16);
            this.comboStdGrp.Name = "comboStdGrp";
            this.comboStdGrp.Size = new System.Drawing.Size(181, 28);
            this.comboStdGrp.Sorted = true;
            this.comboStdGrp.TabIndex = 37;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.ColumnHeadersHeight = 25;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Location = new System.Drawing.Point(6, 68);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 50;
            this.dataGridView2.Size = new System.Drawing.Size(797, 449);
            this.dataGridView2.TabIndex = 34;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.tabPage3.Controls.Add(this.btnPDFlocation);
            this.tabPage3.Controls.Add(this.btnLocationGenerate);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.comboLocation);
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(809, 528);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "  Location  ";
            // 
            // btnPDFlocation
            // 
            this.btnPDFlocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPDFlocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPDFlocation.FlatAppearance.BorderSize = 0;
            this.btnPDFlocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDFlocation.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDFlocation.ForeColor = System.Drawing.Color.White;
            this.btnPDFlocation.Location = new System.Drawing.Point(600, 12);
            this.btnPDFlocation.Name = "btnPDFlocation";
            this.btnPDFlocation.Size = new System.Drawing.Size(151, 35);
            this.btnPDFlocation.TabIndex = 39;
            this.btnPDFlocation.Text = "Export as PDF";
            this.btnPDFlocation.UseVisualStyleBackColor = false;
            this.btnPDFlocation.Click += new System.EventHandler(this.btnPDFlocation_Click);
            // 
            // btnLocationGenerate
            // 
            this.btnLocationGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(204)))), ((int)(((byte)(31)))));
            this.btnLocationGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLocationGenerate.FlatAppearance.BorderSize = 0;
            this.btnLocationGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocationGenerate.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocationGenerate.ForeColor = System.Drawing.Color.White;
            this.btnLocationGenerate.Location = new System.Drawing.Point(447, 12);
            this.btnLocationGenerate.Name = "btnLocationGenerate";
            this.btnLocationGenerate.Size = new System.Drawing.Size(134, 35);
            this.btnLocationGenerate.TabIndex = 38;
            this.btnLocationGenerate.Text = "Generate";
            this.btnLocationGenerate.UseVisualStyleBackColor = false;
            this.btnLocationGenerate.Click += new System.EventHandler(this.btnLocationGenerate_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(163, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 3);
            this.panel3.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Select Location";
            // 
            // comboLocation
            // 
            this.comboLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.comboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLocation.ForeColor = System.Drawing.Color.White;
            this.comboLocation.FormattingEnabled = true;
            this.comboLocation.Location = new System.Drawing.Point(164, 16);
            this.comboLocation.Name = "comboLocation";
            this.comboLocation.Size = new System.Drawing.Size(234, 28);
            this.comboLocation.Sorted = true;
            this.comboLocation.TabIndex = 37;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView3.Location = new System.Drawing.Point(6, 68);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(797, 449);
            this.dataGridView3.TabIndex = 34;
            // 
            // sessionsBindingSource
            // 
            this.sessionsBindingSource.DataMember = "Sessions";
            this.sessionsBindingSource.DataSource = this.databaseDataSet;
            // 
            // databaseDataSet
            // 
            this.databaseDataSet.DataSetName = "DatabaseDataSet";
            this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // sessionsTableAdapter
            // 
            this.sessionsTableAdapter.ClearBeforeFill = true;
            // 
            // Generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AddTags);
            this.Name = "Generate";
            this.Size = new System.Drawing.Size(862, 634);
            this.Load += new System.EventHandler(this.Generate_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label AddTags;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectLecCombo;
        private System.Windows.Forms.Button btnPDFlecturer;
        private System.Windows.Forms.Button btnGenLecturer;
        private System.Windows.Forms.Button btnSTDpdf;
        private System.Windows.Forms.Button btnSTDGenerate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboStdGrp;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnPDFlocation;
        private System.Windows.Forms.Button btnLocationGenerate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboLocation;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.BindingSource sessionsBindingSource;
        private DatabaseDataSet databaseDataSet;
        private System.Windows.Forms.PrintDialog printDialog1;
        private DatabaseDataSetTableAdapters.SessionsTableAdapter sessionsTableAdapter;
    }
}
