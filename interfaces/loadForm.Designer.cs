
namespace interfaces
{
    partial class loadForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.loader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loadTimer = new System.Windows.Forms.Timer(this.components);
            this.loadingLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loader
            // 
            this.loader.BackColor = System.Drawing.Color.White;
            this.loader.Location = new System.Drawing.Point(0, 272);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(528, 18);
            this.loader.TabIndex = 0;
            this.loader.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(174, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 73);
            this.label1.TabIndex = 1;
            this.label1.Text = "ABC";
            this.label1.UseWaitCursor = true;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(113, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Timetable Generator";
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(187, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "Institute";
            this.label3.UseWaitCursor = true;
            // 
            // loadTimer
            // 
            this.loadTimer.Interval = 10;
            this.loadTimer.Tick += new System.EventHandler(this.loadTimer_Tick);
            // 
            // loadingLable
            // 
            this.loadingLable.AutoSize = true;
            this.loadingLable.BackColor = System.Drawing.Color.Transparent;
            this.loadingLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadingLable.Location = new System.Drawing.Point(6, 255);
            this.loadingLable.Name = "loadingLable";
            this.loadingLable.Size = new System.Drawing.Size(61, 15);
            this.loadingLable.TabIndex = 4;
            this.loadingLable.Text = "Loading...";
            this.loadingLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadingLable.UseWaitCursor = true;
            this.loadingLable.Click += new System.EventHandler(this.loadingLable_Click);
            // 
            // loadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::interfaces.Properties.Resources.BuildAndRun1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 277);
            this.Controls.Add(this.loadingLable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loadForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "loadForm";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.loadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel loader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer loadTimer;
        private System.Windows.Forms.Label loadingLable;
    }
}