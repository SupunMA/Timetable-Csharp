
namespace interfaces
{
    partial class SumaliSettings
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
            this.addCapusLable = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.mainidPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.mainIDlabel = new System.Windows.Forms.Label();
            this.txtCampusName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addCapusLable
            // 
            this.addCapusLable.AutoSize = true;
            this.addCapusLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.addCapusLable.ForeColor = System.Drawing.Color.White;
            this.addCapusLable.Location = new System.Drawing.Point(324, 47);
            this.addCapusLable.Name = "addCapusLable";
            this.addCapusLable.Size = new System.Drawing.Size(161, 29);
            this.addCapusLable.TabIndex = 0;
            this.addCapusLable.Text = "Add Campus";
            this.addCapusLable.Click += new System.EventHandler(this.addCapusLable_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(71)))));
            this.panel1.Controls.Add(this.refresh);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.mainidPanel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Controls.Add(this.mainIDlabel);
            this.panel1.Controls.Add(this.txtCampusName);
            this.panel1.Location = new System.Drawing.Point(137, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 347);
            this.panel1.TabIndex = 1;
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(79)))), ((int)(((byte)(97)))));
            this.refresh.BackgroundImage = global::interfaces.Properties.Resources.refresh2;
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.refresh.FlatAppearance.BorderSize = 0;
            this.refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refresh.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.Location = new System.Drawing.Point(507, 315);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(32, 32);
            this.refresh.TabIndex = 114;
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(274, 291);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 35);
            this.btnDelete.TabIndex = 113;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // mainidPanel
            // 
            this.mainidPanel.BackColor = System.Drawing.Color.Red;
            this.mainidPanel.Location = new System.Drawing.Point(146, 261);
            this.mainidPanel.Name = "mainidPanel";
            this.mainidPanel.Size = new System.Drawing.Size(234, 3);
            this.mainidPanel.TabIndex = 53;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(204)))), ((int)(((byte)(31)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(114, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 35);
            this.btnSave.TabIndex = 112;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(71)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(146, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(260, 209);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // mainIDlabel
            // 
            this.mainIDlabel.AutoSize = true;
            this.mainIDlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(71)))));
            this.mainIDlabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mainIDlabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainIDlabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainIDlabel.Location = new System.Drawing.Point(72, 239);
            this.mainIDlabel.Name = "mainIDlabel";
            this.mainIDlabel.Size = new System.Drawing.Size(76, 17);
            this.mainIDlabel.TabIndex = 54;
            this.mainIDlabel.Text = "Type Here:-";
            // 
            // txtCampusName
            // 
            this.txtCampusName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(39)))), ((int)(((byte)(71)))));
            this.txtCampusName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCampusName.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCampusName.ForeColor = System.Drawing.Color.White;
            this.txtCampusName.Location = new System.Drawing.Point(146, 232);
            this.txtCampusName.MaxLength = 20;
            this.txtCampusName.Name = "txtCampusName";
            this.txtCampusName.Size = new System.Drawing.Size(234, 27);
            this.txtCampusName.TabIndex = 52;
            this.txtCampusName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SumaliSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addCapusLable);
            this.Name = "SumaliSettings";
            this.Size = new System.Drawing.Size(862, 634);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addCapusLable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel mainidPanel;
        private System.Windows.Forms.Label mainIDlabel;
        private System.Windows.Forms.TextBox txtCampusName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button refresh;
    }
}
