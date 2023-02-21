using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaces
{
    public partial class JayaniAddLecturers : UserControl
    {
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;

        SqlDataReader dr;
        public JayaniAddLecturers()
        {
            InitializeComponent();
        }

        public void loadComboBox()
        {

            comboBuild.Items.Clear();
            con.Open();
            SqlDataReader dataRead = new SqlCommand("select bname from buildings where campus='" + campusComboValue + "'", con).ExecuteReader();
            while (dataRead.Read())
            {
                comboBuild.Items.Add(dataRead.GetValue(0).ToString());
            }
            con.Close();

        }

        public int id;
        private void GenRankBtn_Click(object sender, EventArgs e)
        {
            if (!comboLevel.SelectedIndex.Equals(-1))
            {
                if (comboLevel.SelectedItem.Equals("Professor"))
                {
                    id = 1;

                }
                else if (comboLevel.SelectedItem.Equals("Assistant Professor"))
                {
                    id = 2;
                }
                else if (comboLevel.SelectedItem.Equals("Senior Lecturer(HG)"))
                {
                    id = 3;
                }
                else if (comboLevel.SelectedItem.Equals("Senior Lecturer"))
                {
                    id = 4;
                }
                else if (comboLevel.SelectedItem.Equals("Lecturer"))
                {
                    id = 5;
                }
                else if (comboLevel.SelectedItem.Equals("Assistant Lecturer"))
                {
                    id = 6;
                }


                
                if ( lecID.TextLength > 0)
                {
                    if (!(Convert.ToInt32(lecID.Text) == 0))
                    {
                        // MessageBox.Show(zeros.ToString());

                        // String a = lecID.Text;
                        int a = Convert.ToInt32(lecID.Text);
                        //a.ToString("0000");
                        lecID.Text = a.ToString().PadLeft(6, '0');
                        // lecID.Text.PadLeft(zeros, '0');
                        rankDisplay.Text = id.ToString() + '.' + lecID.Text;
                    }
                    else
                    {
                        MessageBox.Show("Insert Valid Lecturer ID !");
                        lecID.Text = "";
                        rankDisplay.Text = "";

                    }
                   

                }
                else
                {
                    MessageBox.Show("Invalid Input !");
                    rankDisplay.Text = "";
                }
                

            }
        }
        private void lecID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lecID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private int checkDays()
        {
            int x=0;
            if (SunUpDown.Value==0 && MonUpDown.Value == 0 && TueUpDown.Value == 0 && WedUpDown.Value == 0 && ThuUpDown.Value == 0 && FriUpDown.Value == 0 && SatUpDown.Value == 0 )
            {
                x = 0;
            }
            else
            {
                x = 1;
            }


            return x;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lecName.Text=="" || lecID.Text=="" || comboFac.SelectedIndex==-1 || comboDep.SelectedIndex==-1 || comboLevel.SelectedIndex==-1 || comboBuild.SelectedIndex==-1 )
            {
                MessageBox.Show("Please insert Lecturer's details correctly !");
            }
            else
            {
                if (checkDays()==0)
                {
                    MessageBox.Show("This lecturer's available time is not enough ! \n (Add at least one hour)");
                }
                else if (rankDisplay.Text=="")
                {
                    MessageBox.Show("Please generate the rank! \n (Click on Generate Rank Button)");
                }
                else
                {
                    //Rank Generate again
                    int a = Convert.ToInt32(lecID.Text);
                    lecID.Text = a.ToString().PadLeft(6, '0');
                    rankDisplay.Text = id.ToString() + '.' + lecID.Text;

                    //get bulding name from buiding table
                    con.Open();
                    String syntax2 = "SELECT bname FROM buildings WHERE bname = '" + comboBuild.Text + "'";
                    cmd = new SqlCommand(syntax2, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string buiName = (dr[0].ToString());
                    con.Close();
                    

                    //checking workDaysHours Table for new 
                    con.Open();
                    String syntax4 = "SELECT count(id) FROM lecturers WHERE lecid = '"+lecID.Text+"' and campus='"+campusComboValue+"'";
                    cmd = new SqlCommand(syntax4, con);
                    int countlecturers = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    
                    if (countlecturers == 0)
                    {

                        if (true)
                        {

                        }
                        con.Open();
                        String syntax = "Insert Into lecturers values ('"+lecName.Text+"','"+lecID.Text+"','"+comboFac.Text+"','"+comboDep.Text+"','"+buiName+"','"+comboLevel.Text+"','"+rankDisplay.Text+"','"+SunUpDown.Value+ "','" + MonUpDown.Value + "','" + TueUpDown.Value + "','" + WedUpDown.Value + "','" + ThuUpDown.Value + "','" + FriUpDown.Value + "','" + SatUpDown.Value + "','"+ campusComboValue + "','','','"+0+ "','" + 0 + "')";
                        cmd = new SqlCommand(syntax, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data was Saved!", "Message For Timetable Generator");
                        con.Close();
                     

                    }
                    else
                    {
                        MessageBox.Show("Lecturer ID has been alredy added !. If you want to Edit Click on 'Edit Lecurers' button.", "Message For Timetable Generator");
                    }
                }

                
            }
        }

        private void comboBuild_Click(object sender, EventArgs e)
        {
            loadComboBox();
        }

        private void lecName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
 }

