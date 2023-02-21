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
    public partial class JayaniAddSubjects : UserControl
    {
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;

        SqlDataReader dr;

        public JayaniAddSubjects()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (offSemCombo.SelectedIndex==-1 || ofYearCombo.SelectedIndex==-1 || txtSubjectCode.Text=="" || txtSubjectName.Text=="")
            {
                MessageBox.Show("Please insert Valid data !");
            }
            else if (lectureUpDown.Value==0)
            {
                MessageBox.Show("Number of Lectur hours must be filled");
            }
            else
            {
                //checking tag Table for new tagCode
                con.Open();
                String syntax4 = "SELECT count(subjectcode) FROM subjects WHERE subjectcode = '" + txtSubjectCode.Text + "' and campus='"+campusComboValue+"'";
                cmd = new SqlCommand(syntax4, con);
                int countSubCode = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (countSubCode == 0)
                {
                    con.Open();
                    String syntax = "Insert Into subjects values ('" + txtSubjectCode.Text + "','" + txtSubjectName.Text + "','" + offSemCombo.Text + "','" + ofYearCombo.Text + "','" + lectureUpDown.Value + "','" + tutorialUpDown.Value + "','" + laUpDown.Value + "','" + evaluationUpDown.Value + "','" + campusComboValue + "','')";
                    cmd = new SqlCommand(syntax, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data was Saved!", "Message For Timetable Generator");
                    con.Close();

                }
                else
                {
                    MessageBox.Show("This subject has been alredy added !. If you want to Edit Click on 'Edit Subjects' button.", "Message For Timetable Generator");
                }
            }
        }

        private void txtSubjectName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        
        }

        private void txtSubjectCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        
        }
    }
}
