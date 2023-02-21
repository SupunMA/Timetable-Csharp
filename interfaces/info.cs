using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace interfaces
{
    public partial class info : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;
        SqlDataReader dr;
        public info()
        {
            InitializeComponent();
            
        }

        

        

        private void getData()
        {
            con.Open();
            String syntax = "select * from campus where id = 1";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            MessageBox.Show("Hi " + dr[1].ToString());
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }

       
    }
}
