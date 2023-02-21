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
    public partial class SumaliSettings : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;

        public SumaliSettings()
        {
            InitializeComponent();
        }

        private void addCapusLable_Click(object sender, EventArgs e)
        {

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

        private void refresh_Click(object sender, EventArgs e)
        {
            loadTable("Select id as 'Campus ID',campusName as 'Campus Name' from campus");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCampusName.Text!="")
            {
                con.Open();
                String syntax = "Insert Into campus values ('" + txtCampusName.Text + "')";
                cmd = new SqlCommand(syntax, con);
                cmd.ExecuteNonQuery();

                //MessageBox.Show("Data Added!");
                con.Close();
                loadTable("Select id as 'Campus ID',campusName as 'Campus Name' from campus");
            }
            else
            {
                MessageBox.Show("There is no Valied Data to Insert !.", "Message For Timetable Generator");
            }
            
        }
        int parsedValue;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCampusName.Text != "")
            {
                if (int.TryParse(txtCampusName.Text, out parsedValue))
                {
                    con.Open();
                    String query3 = "DELETE FROM campus where id = '" + txtCampusName.Text + "'";
                    cmd = new SqlCommand(query3, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("If is there Campus Data under '"+txtCampusName.Text+"' Id, \n The Data will be deleted !", "Message For Timetable Generator");
                    loadTable("Select id as 'Campus ID',campusName as 'Campus Name' from campus");
                }
                else
                {
                    MessageBox.Show("Please Type Campus ID to Delete !.", "Message For Timetable Generator");
                }
                
            }
            else
            {
                MessageBox.Show("There is no Valied Data to Delete !.", "Message For Timetable Generator");

            }
           
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                txtCampusName.Text = row.Cells[0].Value.ToString();
                
                //...
            }
            
        }
    }
}
