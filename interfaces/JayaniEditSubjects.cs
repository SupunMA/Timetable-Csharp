using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces
{
    public partial class JayaniEditSubjects : UserControl
    {
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;

        SqlDataReader dr;

        SqlDataAdapter adpt;
        DataTable dt;
        public JayaniEditSubjects()
        {
            InitializeComponent();
        }



        public void loadTable(String Query)
        {

            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter(Query, con);
                adpt.Fill(dt);
                dataGridView.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}