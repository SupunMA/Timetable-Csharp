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
    public partial class supunEditTags : UserControl
    {
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;
        SqlDataReader dr;
        public supunEditTags()
        {
            InitializeComponent();

            
            searchCloseBtn.Hide();
        }



        private void refresh_Click(object sender, EventArgs e)
        {
            loadTable();
            loadDropDown();
           

        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBox.Text != "")
            {
                panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                searchBoxLable.Hide();
                searchCloseBtn.Show();
                int parsedValue;
                if (int.TryParse(txtSearchBox.Text, out parsedValue))
                {
                    SqlCommand cmd = new SqlCommand("SELECT tags.tagcode as 'Tag Code',subjects.subjectcode as 'Subject Code',subjects.subjectName as 'Subject Name',relatedtag.tagid as 'Related Tag ID',relatedtag.tagname 'Related Tag Name',subjects.semester as 'Semester',subjects.offeredyear as 'Offered Year' FROM tags INNER JOIN relatedtag ON relatedTag.tagID = tags.relatedTag INNER JOIN subjects ON subjects.subjectcode = tags.subject where (tags.tagcode like '"+txtSearchBox.Text+"%' or subjects.offeredyear Like '" + txtSearchBox.Text + "%' or relatedtag.tagid Like '" + txtSearchBox.Text + "%') and Tags.Campus = '"+campusComboValue+"' order by tagCode", con);

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = cmd;

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dt;

                    dataGridView.DataSource = bsource;

                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
                    dataGridView.EnableHeadersVisualStyles = false;


                }
                else
                {


                    SqlCommand cmd = new SqlCommand("SELECT tags.tagcode as 'Tag Code',subjects.subjectcode as 'Subject Code',subjects.subjectName as 'Subject Name',relatedtag.tagid as 'Related Tag ID',relatedtag.tagname 'Related Tag Name',subjects.semester as 'Semester',subjects.offeredyear as 'Offered Year' FROM tags INNER JOIN relatedtag ON relatedTag.tagID = tags.relatedTag INNER JOIN subjects ON subjects.subjectcode = tags.subject where (subjects.subjectName Like '" + txtSearchBox.Text + "%' or relatedtag.tagname Like '" + txtSearchBox.Text + "%' or tags.tagcode Like '" + txtSearchBox.Text + "%' or subjects.subjectcode Like '" + txtSearchBox.Text + "%'  or subjects.semester Like '" + txtSearchBox.Text + "%') and Tags.Campus = '" + campusComboValue + "' order by tagCode", con);

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = cmd;

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dt;

                    dataGridView.DataSource = bsource;

                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
                    dataGridView.EnableHeadersVisualStyles = false;
                }



            }
            else
            {
                panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                //searchBoxLable.Show();
                searchCloseBtn.Hide();


                loadTable();
            }
        }

        public void loadTable()
        { //Table Loading method
            
                SqlCommand cmd = new SqlCommand("SELECT tags.tagcode as 'Tag Code',subjects.subjectcode as 'Subject Code',subjects.subjectName as 'Subject Name',relatedtag.tagid as 'Related Tag ID',relatedtag.tagname 'Related Tag Name',subjects.semester as 'Semester',subjects.offeredyear as 'Offered Year' FROM tags INNER JOIN relatedtag ON relatedTag.tagID = tags.relatedTag INNER JOIN subjects ON subjects.subjectcode = tags.subject and tags.Campus = '" + campusComboValue + "'  order by tagCode ", con);

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bsource = new BindingSource();

                bsource.DataSource = dt;

                dataGridView.DataSource = bsource;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
            dataGridView.EnableHeadersVisualStyles = false;



        }
        public void loadDropDown()
        { // DropDown Loading Method
            selectTagCombo.Items.Clear();
            con.Open();
            SqlDataReader dataRead = new SqlCommand("select tagName from relatedTag where campus='" + campusComboValue + "'", con).ExecuteReader();
            while (dataRead.Read())
            {
                selectTagCombo.Items.Add(dataRead.GetValue(0).ToString());
            }
            con.Close();

            selectSubjectCombo.Items.Clear();
            con.Open();
            SqlDataReader dataReadSubject = new SqlCommand("select subjectName from Subjects where campus='" + campusComboValue + "'", con).ExecuteReader();
            while (dataReadSubject.Read())
            {
                selectSubjectCombo.Items.Add(dataReadSubject.GetValue(0).ToString());
            }
            con.Close();

            panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

        }

        private void txtSearchBox_Click(object sender, EventArgs e)
        {
            searchBoxLable.Hide();
        }

        private void searchBoxLable_Click(object sender, EventArgs e)
        {
            searchBoxLable.Hide();
            txtSearchBox.Focus();
        }

        private void txtSearchBox_Leave(object sender, EventArgs e)
        {
            if (txtSearchBox.Text == "")
            {
                searchBoxLable.Show();
            }

        }

        private void searchCloseBtn_Click(object sender, EventArgs e)
        {
            txtSearchBox.Text = "";
        }

        private void tagCodeLabel_Click(object sender, EventArgs e)
        {
            tagCodeLabel.Hide();
            txtTagCode.Focus();
        }

        private void txtTagCode_TextChanged(object sender, EventArgs e)
        {
            if (txtTagCode.Text != "")
            {
                panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                tagCodeLabel.Hide();
            }
            else
            {
                panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                tagCodeLabel.Hide();

            }

            if (searchTabelCheck.Checked)
            {


                int parsedValue;
                if (int.TryParse(txtTagCode.Text, out parsedValue))
                {
                    int i = int.Parse(txtTagCode.Text);

                    SqlCommand cmd = new SqlCommand("SELECT tags.tagcode as 'Tag Code',subjects.subjectcode as 'Subject Code',subjects.subjectName as 'Subject Name',relatedtag.tagid as 'Related Tag ID',relatedtag.tagname 'Related Tag Name',subjects.semester as 'Semester',subjects.offeredyear as 'Offered Year' FROM tags INNER JOIN relatedtag ON relatedTag.tagID = tags.relatedTag INNER JOIN subjects ON subjects.subjectcode = tags.subject where tags.tagcode Like '" + i + "%' and tags.campus='" + campusComboValue + "'", con);    //

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = cmd;

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dt;

                    dataGridView.DataSource = bsource;

                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
                    dataGridView.EnableHeadersVisualStyles = false;


                }
                else
                {


                    SqlCommand cmd = new SqlCommand("SELECT tags.tagcode as 'Tag Code',subjects.subjectcode as 'Subject Code',subjects.subjectName as 'Subject Name',relatedtag.tagid as 'Related Tag ID',relatedtag.tagname 'Related Tag Name',subjects.semester as 'Semester',subjects.offeredyear as 'Offered Year' FROM tags INNER JOIN relatedtag ON relatedTag.tagID = tags.relatedTag INNER JOIN subjects ON subjects.subjectcode = tags.subject where tags.tagcode Like '" + txtTagCode.Text + "%' and tags.campus='" + campusComboValue + "'", con);    // 

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = cmd;

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dt;

                    dataGridView.DataSource = bsource;

                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
                    dataGridView.EnableHeadersVisualStyles = false;
                }
            }
        }

        private void txtTagCode_Click(object sender, EventArgs e)
        {
            tagCodeLabel.Hide();
            txtTagCode.Focus();
        }

        private void txtTagCode_Leave(object sender, EventArgs e)
        {
            if (txtTagCode.Text != "")
            {
                tagCodeLabel.Hide();
                //searchCloseBtn.Show();
            }
            else
            {
                tagCodeLabel.Show();
                //searchCloseBtn.Hide();
            }

        }

        private void reset_Click(object sender, EventArgs e)
        {
            if (selectTagCombo.Text != "")
            {
                selectTagCombo.Items[selectTagCombo.SelectedIndex] = string.Empty;
                panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            }
            if (selectSubjectCombo.Text != "")
            {
                selectSubjectCombo.Items[selectSubjectCombo.SelectedIndex] = string.Empty;
                panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            }

            loadDropDown();

            txtTagCode.Text = "";

            tagCodeLabel.Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (txtTagCode.Text != "" && selectSubjectCombo.Text != "" && selectTagCombo.Text != "")
            {
                //Check table for tagcode availability

                con.Open();
                String syntax4 = "SELECT count(tagcode) FROM tags WHERE tagcode = '" + txtTagCode.Text + "'and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int tagcount = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();



                if (tagcount != 0)
                {    //Get Related TagId from Related tagName
               
                     con.Open();
                     String syntax3 = "SELECT TagID FROM relatedTag WHERE tagname = '" + selectTagCombo.Text + "' and campus='" + campusComboValue + "'";
                     cmd = new SqlCommand(syntax3, con);
                     int tagid = Convert.ToInt32(cmd.ExecuteScalar());
                     con.Close();

                    //Get subjectCode from subjectName
                    con.Open();
                    String syntax2 = "SELECT subjectCode FROM subjects WHERE subjectName = '" + selectSubjectCombo.Text + "' and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax2, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string subCode = (dr[0].ToString());
                    con.Close();

                    //Update table
                    con.Open();
                    String syntax = "update tags set relatedTag='" + tagid + "',subject='" + subCode + "' where tagcode='" + txtTagCode.Text + "' and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated!");
                    con.Close();

                    loadTable();
                }
                else
                {
                    MessageBox.Show("There is no Valied Tag CCode to Update !.", "Message For Timetable Generator");
                }
                
            }
            else
            {
                MessageBox.Show("There is no Valied Data to Insert !.", "Message For Timetable Generator");

            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (txtTagCode.Text != "")
            {
                //checking tag Table for new tagCode
                con.Open();
                String syntax4 = "SELECT count(tagcode) FROM tags WHERE tagcode = '" + txtTagCode.Text + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countTagCode = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                if (countTagCode != 0)
                {
                    con.Open();
                    String query3 = "DELETE FROM tags where tagcode = '" + txtTagCode.Text + "' and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(query3, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Tag Deleted!");

                    loadTable();
                }
                else
                {
                    MessageBox.Show("There is NO Data to Delete under '" + txtTagCode.Text + "' Tag Code. !", "Message For Timetable Generator");
                }
            }
            else
            {
                MessageBox.Show("Add TagCode to Delete !.", "Message For Timetable Generator");
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            try
            {
                int rowindex = e.RowIndex;
                var value = dataGridView.Rows[rowindex].Cells[0].Value;


                var tagcodeVar = dataGridView.Rows[rowindex].Cells[0].Value;
                
                var subN = dataGridView.Rows[rowindex].Cells[2].Value;
                
                var relaTag = dataGridView.Rows[rowindex].Cells[4].Value;
               


                txtTagCode.Text = tagcodeVar.ToString();

                selectSubjectCombo.Text = subN.ToString();
                selectTagCombo.Text = relaTag.ToString();

              
            }
            catch (Exception sqlx)
            {

                // throw new Exception("Problem med att sätta in namnet i ditt på inlägg/n" + sqlx.Message);
                MessageBox.Show("Please Click on a Cell or on a Row! .\n " + sqlx.Message, "Message For Timetable Generator");
            }
        }


        private void selectSubjectCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectSubjectCombo.Text != "")
            {
                panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
            }
            else
            {
                
            }
        }

        private void selectTagCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectTagCombo.Text != "")
            {
                panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");

            }
            else
            {
                panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

            }
        }

        private void supunEditTags_Load(object sender, EventArgs e)
        {

        }
    }
}
