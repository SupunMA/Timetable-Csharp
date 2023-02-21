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
    public partial class supunAddStudent : UserControl
    {
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;
        //SqlDataReader dr;

        public supunAddStudent()
        {
            InitializeComponent();
            comboLoad();
        }

        



    private void comboLoad()
        {
            comboYearSem.Items.Clear();
            comboYearSem.Items.Insert(0, "Y1.S1");
            comboYearSem.Items.Insert(1, "Y1.S2");
            comboYearSem.Items.Insert(2, "Y2.S1");
            comboYearSem.Items.Insert(3, "Y2.S2");
            comboYearSem.Items.Insert(4, "Y3.S1");
            comboYearSem.Items.Insert(5, "Y3.S2");
            comboYearSem.Items.Insert(6, "Y4.S1");
            comboYearSem.Items.Insert(7, "Y4.S2");

            comboProg.Items.Clear();
            comboProg.Items.Insert(0, "IT  ");
            comboProg.Items.Insert(1, "CSSE");
            comboProg.Items.Insert(2, "CSE ");
            comboProg.Items.Insert(3, "IM  ");


        }

        //Only Interger
        private void txtMainGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSubGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //Auto Generate GroupID
        private void txtMainGroup_TextChanged(object sender, EventArgs e)
        {
            groupIDDisplay.Text = comboYearSem.Text + "." + txtMainGroup.Text;

            if (txtMainGroup.Text != "")
            {
                mainidPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                mainIDlabel.Hide();

            }
            else
            {
                mainidPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                mainIDlabel.Show();


            }

        }

        private void comboYearSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupIDDisplay.Text = comboYearSem.Text + "." + txtMainGroup.Text;

            if (comboYearSem.Text != "")
            {
                ysPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");

            }
            else
            {
                ysPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

            }
        }


        //Auto Generate SubGroupID
        private void txtSubGroup_TextChanged(object sender, EventArgs e)
        {
            supGroupIDDisplay.Text = groupIDDisplay.Text + "." + txtSubGroup.Text;

            groupIDDisplay.Text = comboYearSem.Text + "." + txtMainGroup.Text;

            if (txtSubGroup.Text != "")
            {
                subIDpanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                subIDlabel.Hide();

            }
            else
            {
                subIDpanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                subIDlabel.Show();


            }
        }

        private void groupIDDisplay_TextChanged(object sender, EventArgs e)
        {
            supGroupIDDisplay.Text = groupIDDisplay.Text + "." + txtSubGroup.Text;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtSubGroup.Text = "";
            txtMainGroup.Text = "";

            if (comboProg.Text != "")
            {
                comboProg.Items[comboProg.SelectedIndex] = string.Empty;
            }
            if (comboYearSem.Text != "")
            {
                comboYearSem.Items[comboYearSem.SelectedIndex] = string.Empty;
            }
            comboLoad();
            groupIDDisplay.Text = "";
            supGroupIDDisplay.Text = "";

            radioWeek.Checked = false;
            radioWeekend.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            if (txtMainGroup.Text != "" && txtSubGroup.Text != "" && comboProg.Text != "" && comboYearSem.Text != "" && (radioWeek.Checked || radioWeekend.Checked))
            {
                //ComboBox year and semester SPLIT
                string data = comboYearSem.Text;
                string[] YearSem = data.Split(new string[] { "." }, StringSplitOptions.None);
                //MessageBox.Show(YearSem[0] +" dfgfg "+ YearSem[1]);

                //checking tag Table for new tagCode
                con.Open();
                String syntax4 = "SELECT count(id) FROM studentgroups WHERE year = '" + YearSem[0] + "' and semester = '" + YearSem[1] + "' and programme = '" + comboProg.Text + "' and mainid = '" + txtMainGroup.Text + "' and subid = '" + txtSubGroup.Text + "' and batchtype = '" + weekOrWeekend + "' and campus = '"+campusComboValue+"'";
                cmd = new SqlCommand(syntax4, con);
                int countGroups = Convert.ToInt32(cmd.ExecuteScalar());
                 
                //MessageBox.Show(countTagCode.ToString());

                con.Close();

                if (countGroups == 0)
                {
                    con.Open();
                    String syntax = "Insert Into studentgroups(batchtype,year,semester,programme,mainid,subid,campus,LocationName,notday,notstart,notend,subgrp) values ('" + weekOrWeekend + "','" + YearSem[0] + "','" + YearSem[1] + "','" + comboProg.Text + "','" + txtMainGroup.Text + "','" + txtSubGroup.Text + "','"+campusComboValue+ "','','','" + 0 + "','" + 0 + "','"+supGroupIDDisplay.Text+"')";
                    cmd = new SqlCommand(syntax, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data was saved successfully!", "Message For Timetable Generator");
                    con.Close();

                }
                else
                {
                    MessageBox.Show("This Student Group has been alredy added !.", "Message For Timetable Generator");
                }



            }
            else
            {
                MessageBox.Show("Please Fill the form correctly!. The system Could not catch data ", "Message For Timetable Generator");
            }

        }
        String weekOrWeekend;
        private void radioWeek_CheckedChanged(object sender, EventArgs e)
        {
            weekOrWeekend = "week days";

        }
     
        private void radioWeekend_CheckedChanged(object sender, EventArgs e)
        {
            weekOrWeekend = "weekend days";

        }

        private void subIDlabel_Click(object sender, EventArgs e)
        {
            subIDlabel.Hide();
            txtSubGroup.Focus();
        }

        private void mainIDlabel_Click(object sender, EventArgs e)
        {
            mainIDlabel.Hide();
            txtMainGroup.Focus();
        }

        private void comboProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProg.Text != "")
            {
                progPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");

            }
            else
            {
                progPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

            }
        }

        private void supunAddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
