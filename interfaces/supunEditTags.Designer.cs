
namespace interfaces
{
    partial class supunEditTags
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.searchTabelCheck = new System.Windows.Forms.CheckBox();
            this.selectTagCombo = new System.Windows.Forms.ComboBox();
            this.delete = new System.Windows.Forms.Button();
            this.selectSubjectCombo = new System.Windows.Forms.ComboBox();
            this.selectSubject = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.tagCodeLabel = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTagCode = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.searchCloseBtn = new System.Windows.Forms.Label();
            this.searchBoxLable = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refresh = new System.Windows.Forms.Button();
            this.LoadDataTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(1, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 5);
            this.panel1.TabIndex = 17;
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
            this.AddTags.Size = new System.Drawing.Size(125, 29);
            this.AddTags.TabIndex = 15;
            this.AddTags.Text = "Edit Tags";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(42, 7);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(743, 256);
            this.dataGridView.TabIndex = 18;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.panel7.Controls.Add(this.searchTabelCheck);
            this.panel7.Controls.Add(this.selectTagCombo);
            this.panel7.Controls.Add(this.delete);
            this.panel7.Controls.Add(this.selectSubjectCombo);
            this.panel7.Controls.Add(this.selectSubject);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.update);
            this.panel7.Controls.Add(this.tagCodeLabel);
            this.panel7.Controls.Add(this.reset);
            this.panel7.Controls.Add(this.panel2);
            this.panel7.Controls.Add(this.txtTagCode);
            this.panel7.Controls.Add(this.panel5);
            this.panel7.Location = new System.Drawing.Point(13, 343);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(803, 290);
            this.panel7.TabIndex = 29;
            // 
            // searchTabelCheck
            // 
            this.searchTabelCheck.AutoSize = true;
            this.searchTabelCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTabelCheck.ForeColor = System.Drawing.Color.White;
            this.searchTabelCheck.Location = new System.Drawing.Point(425, 27);
            this.searchTabelCheck.Name = "searchTabelCheck";
            this.searchTabelCheck.Size = new System.Drawing.Size(151, 19);
            this.searchTabelCheck.TabIndex = 36;
            this.searchTabelCheck.Text = "Search in the Table";
            this.searchTabelCheck.UseVisualStyleBackColor = true;
            // 
            // selectTagCombo
            // 
            this.selectTagCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.selectTagCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectTagCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectTagCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTagCombo.ForeColor = System.Drawing.Color.White;
            this.selectTagCombo.FormattingEnabled = true;
            this.selectTagCombo.Location = new System.Drawing.Point(185, 152);
            this.selectTagCombo.Name = "selectTagCombo";
            this.selectTagCombo.Size = new System.Drawing.Size(234, 28);
            this.selectTagCombo.Sorted = true;
            this.selectTagCombo.TabIndex = 34;
            this.selectTagCombo.SelectedIndexChanged += new System.EventHandler(this.selectTagCombo_SelectedIndexChanged);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Red;
            this.delete.FlatAppearance.BorderSize = 0;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.Color.White;
            this.delete.Location = new System.Drawing.Point(324, 212);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(134, 35);
            this.delete.TabIndex = 29;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // selectSubjectCombo
            // 
            this.selectSubjectCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.selectSubjectCombo.DropDownHeight = 150;
            this.selectSubjectCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectSubjectCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectSubjectCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectSubjectCombo.ForeColor = System.Drawing.Color.White;
            this.selectSubjectCombo.FormattingEnabled = true;
            this.selectSubjectCombo.IntegralHeight = false;
            this.selectSubjectCombo.ItemHeight = 20;
            this.selectSubjectCombo.Location = new System.Drawing.Point(183, 83);
            this.selectSubjectCombo.MaxDropDownItems = 4;
            this.selectSubjectCombo.Name = "selectSubjectCombo";
            this.selectSubjectCombo.Size = new System.Drawing.Size(460, 28);
            this.selectSubjectCombo.Sorted = true;
            this.selectSubjectCombo.TabIndex = 35;
            this.selectSubjectCombo.SelectedIndexChanged += new System.EventHandler(this.selectSubjectCombo_SelectedIndexChanged);
            // 
            // selectSubject
            // 
            this.selectSubject.AutoSize = true;
            this.selectSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectSubject.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.selectSubject.Location = new System.Drawing.Point(22, 96);
            this.selectSubject.Name = "selectSubject";
            this.selectSubject.Size = new System.Drawing.Size(126, 20);
            this.selectSubject.TabIndex = 1;
            this.selectSubject.Text = "Select Subject";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tag Code";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Red;
            this.panel6.Location = new System.Drawing.Point(184, 182);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(220, 3);
            this.panel6.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(22, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Related Tag";
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.update.FlatAppearance.BorderSize = 0;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.ForeColor = System.Drawing.Color.White;
            this.update.Location = new System.Drawing.Point(184, 211);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(134, 35);
            this.update.TabIndex = 8;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // tagCodeLabel
            // 
            this.tagCodeLabel.AutoSize = true;
            this.tagCodeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.tagCodeLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tagCodeLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagCodeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tagCodeLabel.Location = new System.Drawing.Point(235, 26);
            this.tagCodeLabel.Name = "tagCodeLabel";
            this.tagCodeLabel.Size = new System.Drawing.Size(125, 17);
            this.tagCodeLabel.TabIndex = 22;
            this.tagCodeLabel.Text = "Type here to Search";
            this.tagCodeLabel.Click += new System.EventHandler(this.tagCodeLabel_Click);
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.reset.FlatAppearance.BorderSize = 0;
            this.reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.ForeColor = System.Drawing.Color.White;
            this.reset.Location = new System.Drawing.Point(464, 212);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(80, 35);
            this.reset.TabIndex = 9;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(184, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 3);
            this.panel2.TabIndex = 24;
            // 
            // txtTagCode
            // 
            this.txtTagCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.txtTagCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTagCode.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagCode.ForeColor = System.Drawing.Color.White;
            this.txtTagCode.Location = new System.Drawing.Point(184, 19);
            this.txtTagCode.Name = "txtTagCode";
            this.txtTagCode.Size = new System.Drawing.Size(220, 27);
            this.txtTagCode.TabIndex = 23;
            this.txtTagCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTagCode.Click += new System.EventHandler(this.txtTagCode_Click);
            this.txtTagCode.TextChanged += new System.EventHandler(this.txtTagCode_TextChanged);
            this.txtTagCode.Leave += new System.EventHandler(this.txtTagCode_Leave);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Location = new System.Drawing.Point(184, 113);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(445, 3);
            this.panel5.TabIndex = 21;
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
            this.searchCloseBtn.TabIndex = 30;
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
            this.searchBoxLable.TabIndex = 31;
            this.searchBoxLable.Text = "Type here to Search";
            this.searchBoxLable.Click += new System.EventHandler(this.searchBoxLable_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(391, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 3);
            this.panel3.TabIndex = 33;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.txtSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchBox.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBox.ForeColor = System.Drawing.Color.White;
            this.txtSearchBox.Location = new System.Drawing.Point(390, 15);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(220, 27);
            this.txtSearchBox.TabIndex = 32;
            this.txtSearchBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchBox.Click += new System.EventHandler(this.txtSearchBox_Click);
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            this.txtSearchBox.Leave += new System.EventHandler(this.txtSearchBox_Leave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.panel4.Controls.Add(this.dataGridView);
            this.panel4.Location = new System.Drawing.Point(13, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(836, 266);
            this.panel4.TabIndex = 34;
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.refresh.BackgroundImage = global::interfaces.Properties.Resources.refresh2;
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.refresh.FlatAppearance.BorderSize = 0;
            this.refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refresh.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.Location = new System.Drawing.Point(822, 346);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(27, 32);
            this.refresh.TabIndex = 30;
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // LoadDataTimer
            // 
            this.LoadDataTimer.Interval = 2000;
            // 
            // supunEditTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.searchCloseBtn);
            this.Controls.Add(this.searchBoxLable);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtSearchBox);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AddTags);
            this.Name = "supunEditTags";
            this.Size = new System.Drawing.Size(862, 634);
            this.Load += new System.EventHandler(this.supunEditTags_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label AddTags;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label selectSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label tagCodeLabel;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTagCode;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label searchCloseBtn;
        private System.Windows.Forms.Label searchBoxLable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.ComboBox selectTagCombo;
        private System.Windows.Forms.ComboBox selectSubjectCombo;
        private System.Windows.Forms.CheckBox searchTabelCheck;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer LoadDataTimer;
    }
}
