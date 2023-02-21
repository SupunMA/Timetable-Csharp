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
    public partial class HasiniAddLocation : UserControl
    {
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;

        SqlDataReader dr;

        SqlDataAdapter adpt;
        DataTable dt;
        public HasiniAddLocation()
        {
            InitializeComponent();
        }

        public void loadBuildingTable()
        {

            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from buildings where campus ='"+campusComboValue+"'", con);
                adpt.Fill(dt);
                dataGridViewB.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadRoomTable()
        {

            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from roomtypes where campus ='" + campusComboValue + "'", con);
                adpt.Fill(dt);
                dataGridViewR.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void loadBnameCombo()
        {

            comboBuilding.Items.Clear();
            con.Open();
            SqlDataReader dataReadSubject = new SqlCommand("select letter from buildings where campus='" + campusComboValue + "'", con).ExecuteReader();
            while (dataReadSubject.Read())
            {
                comboBuilding.Items.Add(dataReadSubject.GetValue(0).ToString());
            }
            con.Close();

        }
        public String x;
        public void loadfloorCombo()
        {
            if (comboBuilding.SelectedIndex!=-1)
            {
               comboFloor.Items.Clear();
               con.Open();
               SqlDataReader dataReadSubject = new SqlCommand("select floors from buildings where letter='" + this.comboBuilding.SelectedItem.ToString() + "'", con).ExecuteReader();

               while (dataReadSubject.Read())
               {
                   x = dataReadSubject.GetValue(0).ToString();

                  // comboFloor.Items.Add();
               }

                for (int i = 1; i <= Convert.ToInt32(x); i++)
                {
                    comboFloor.Items.Add(i);
                }
                con.Close();
            }
            

        }

        public void loadRoomTypeCombo()
        {

            comboRoom.Items.Clear();
            con.Open();
            SqlDataReader dataReadSubject = new SqlCommand("select letter from roomtypes where campus='" + campusComboValue + "'", con).ExecuteReader();
            while (dataReadSubject.Read())
            {
                comboRoom.Items.Add(dataReadSubject.GetValue(0).ToString());
            }
            con.Close();

        }


        private void btnBuildingSave_Click(object sender, EventArgs e)
        {
            if (txtBuildingName.Text=="" || txtBuildingLetter.Text=="" )
            {
                MessageBox.Show("Invalid input !");
            }
            else
            {
                //checking building Table for new data
                con.Open();
                String syntax4 = "SELECT count(id) FROM buildings WHERE (bname = '" + txtBuildingName.Text + "' or letter ='"+txtBuildingLetter.Text+"') and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countBuildings = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (countBuildings == 0)
                {
                    con.Open();
                    String syntax = "Insert Into buildings values ('" + txtBuildingName.Text + "','" + txtBuildingLetter.Text + "','" + UpDownFloors.Value + "','" + campusComboValue + "')";
                    cmd = new SqlCommand(syntax, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data was Saved!", "Message For Timetable Generator");
                    con.Close();
                    loadBuildingTable();
                    loadBnameCombo();
                }
                else
                {
                    MessageBox.Show("This building name or letter has been alredy added !. If you want to Edit check the table.", "Message For Timetable Generator");
                }
            }
        }

        private void btnRoomSave_Click(object sender, EventArgs e)
        {
            if (txtRoomType.Text == "" || txtRoomLetter.Text == "")
            {
                MessageBox.Show("Invalid input !");
            }
            else
            {
                //checking building Table for new data
                con.Open();
                String syntax4 = "SELECT count(id) FROM roomtypes WHERE (rtype = '" + txtRoomType.Text + "' or letter ='" + txtRoomLetter.Text + "') and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countRoomTypes = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (countRoomTypes == 0)
                {
                    con.Open();
                    String syntax = "Insert Into roomtypes values ('" + txtRoomType.Text + "','" + txtRoomLetter.Text + "','" + campusComboValue + "')";
                    cmd = new SqlCommand(syntax, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data was Saved!", "Message For Timetable Generator");
                    con.Close();
                    loadRoomTable();
                    loadRoomTypeCombo();
                }
                else
                {
                    MessageBox.Show("This Room type name or letter has been alredy added !. If you want to Edit check the table.", "Message For Timetable Generator");
                }
            }
        }

        private void comboBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadfloorCombo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBuilding.SelectedIndex==-1 || comboFloor.SelectedIndex==-1 || comboRoom.SelectedIndex==-1 || txtLocName.Text=="" || txtcapacity.Text=="")
            {
                MessageBox.Show("Insert Valid Data !");
            }
            else
            {

                displayLocation.Text = comboBuilding.Text.Replace(" ", String.Empty)  + '.' + comboFloor.Text.Replace(" ", String.Empty)  + '.' + comboRoom.Text.Replace(" ", String.Empty) + '.' + txtLocName.Text.Replace(" ", String.Empty);


               
                 
                //checking location Table for new data
                con.Open();
                String syntax4 = "SELECT count(id) FROM locations WHERE dislocation = '" + displayLocation.Text + "'  and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countLocations = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (countLocations == 0)
                {
                    con.Open();
                    String syntax = "Insert Into locations values ('" + comboBuilding.Text + "','" + comboFloor.Text + "','" + comboRoom.Text + "','" + txtLocName.Text + "','" + txtcapacity.Text + "','" + displayLocation.Text + "','" + campusComboValue + "')";
                    cmd = new SqlCommand(syntax, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data was Saved!", "Message For Timetable Generator");
                    con.Close();
                    
                }
                else
                {
                    MessageBox.Show("This location has been alredy added !. If you want to Edit click on 'Edit locations' button.", "Message For Timetable Generator");
                }
            }
        }

        private void txtcapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtLocName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtBuildingName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtBuildingLetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtRoomType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtRoomLetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
