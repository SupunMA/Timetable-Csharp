using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces
{
    public partial class loadForm : Form
    {//
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False;Connection Timeout=120");
        SqlCommand cmd;
        SqlDataReader dr;
        String connectNumber="";
        public loadForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void loadForm_Load(object sender, EventArgs e)
        {
            

            loader.Width = 0;
            loadTimer.Enabled = true; //on timer

           
        }


        
        Random rnd = new Random(); // created object to get random number
         

        private void loadTimer_Tick(object sender, EventArgs e)
        {
            loader.Width = loader.Width + rnd.Next(1, 10);
            if (connectNumber == "kandy" )
            {
                loader.Width = 528;
                
            }
            if (loader.Width >= 528)
            {
                System.Threading.Thread.Sleep(2000);
                
                Main mainForm = new Main();// created obj to call mainForm
                mainForm.Show();
                this.Hide();
                loadTimer.Enabled = false; // off timer
            }
            if (loader.Width >= 400 && connectNumber != "1")
            {
                
                con.Open();
                String syntax = "select * from campus where id = 2";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                //MessageBox.Show("Hi " + dr[0].ToString());
                loadingLable.Text = "Database Connected";
                connectNumber = (dr[1].ToString());
                con.Close();
            }

            if (loader.Width >= 200 && connectNumber != "1" && loader.Width < 399)
            {
                loadingLable.Text = "Database Connecting...";
                System.Threading.Thread.Sleep(20);
            }

        }

        private void loadingLable_Click(object sender, EventArgs e)
        {

        }



        /*protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.FromArgb(255, 255, 255),
                                                                       Color.FromArgb(20, 168, 201),
                                                                       90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }*/


    }
}
