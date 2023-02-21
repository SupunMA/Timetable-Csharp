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
    public partial class supunEditStudent : UserControl
    {
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;
        SqlDataReader dr;
        public supunEditStudent()
        {

            InitializeComponent();
            //Load Table Table
            
        }

        private void supunEditStudent_Load(object sender, EventArgs e)
        {

            
            searchCloseBtn.Hide();

            toolTip1.SetToolTip(this.searchCloseBtn, "Clear Search Box");
            toolTip1.SetToolTip(this.refresh, "Refresh Table");
            toolTip1.SetToolTip(this.btnSave, "Update Row");
            toolTip1.SetToolTip(this.BtnReset, "Reset Data");
            toolTip1.SetToolTip(this.btnDelete, "Delete Row");
        }

        public void comboLoad()
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

            progPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            ysPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");


        }

        //get cell value from table method
        private string getCellValue(String query, int index) {
            con.Open();
            String q = query;
            cmd = new SqlCommand(q, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            string cellvalue = (dr[index].ToString());
            con.Close();
            return cellvalue;
        }

        private void supGroupIDDisplay_TextChanged(object sender, EventArgs e)
        {

        }
        
        //Table Loading method
        public void loadTable(String Query)
        {

            SqlCommand cmd = new SqlCommand(Query, con);

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

        private void refresh_Click(object sender, EventArgs e)
        {
            comboLoad();
            loadTable("select id as 'ID',batchtype as 'Batch Type',year+'.'+semester as 'Year and Semester',programme as 'Programme',mainid as 'Main Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2)) as 'Main Group ID',subid as 'Sub Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) as 'Main Group ID' from studentgroups where campus = '"+campusComboValue+"'");
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                searchBoxLable.Hide();
                searchCloseBtn.Show();
                int parsedValue;
                if (int.TryParse(txtsearch.Text, out parsedValue))
                {
                    loadTable("select id as 'ID',batchtype as 'Batch Type',year+'.'+semester as 'Year and Semester',programme as 'Programme',mainid as 'Main Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2)) as 'Main Group ID',subid as 'Sub Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) as 'Main Group ID' from studentgroups where (id like '" + txtsearch.Text + "%' or mainid like '" + txtsearch.Text + "%' or subid like '" + txtsearch.Text + "%') and campus ='"+campusComboValue+"'");

                }
                else
                {
                    loadTable("select id as 'ID',batchtype as 'Batch Type',year+'.'+semester as 'Year and Semester',programme as 'Programme',mainid as 'Main Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2)) as 'Main Group ID',subid as 'Sub Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) as 'Main Group ID' from studentgroups where (year like '" + txtsearch.Text + "%' or programme like '" + txtsearch.Text + "%' or semester like '" + txtsearch.Text + "%' or batchtype like '" + txtsearch.Text + "%' or year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) like '" + txtsearch.Text + "%') and campus = '"+campusComboValue+"'");

                    //SqlCommand cmd = new SqlCommand("SELECT tags.tagcode,subjects.subjectcode,subjects.subjectName,relatedtag.tagid,relatedtag.tagname,subjects.semester,subjects.offeredyear FROM tags INNER JOIN relatedtag ON relatedTag.tagID = tags.relatedTag INNER JOIN subjects ON subjects.subjectcode = tags.subject where subjects.subjectName Like '" + txtSearchBox.Text + "%' or relatedtag.tagname Like '" + txtSearchBox.Text + "%' or tags.tagcode Like '" + txtSearchBox.Text + "%' or subjects.subjectcode Like '" + txtSearchBox.Text + "%'  or subjects.semester Like '" + txtSearchBox.Text + "%' order by tagCode", con);


                }



            }
            else
            {
                panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                //searchBoxLable.Show();
                searchCloseBtn.Hide();


                loadTable("select id as 'ID',batchtype as 'Batch Type',year+'.'+semester as 'Year and Semester',programme as 'Programme',mainid as 'Main Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2)) as 'Main Group ID',subid as 'Sub Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) as 'Main Group ID' from studentgroups where campus = '"+campusComboValue+"'");
            }
        }

        private void sql_q(String qq)
        {
            con.Open();
            String syntax = qq;
            cmd = new SqlCommand(syntax, con);
            cmd.ExecuteNonQuery();

            con.Close();

        }

        private void searchCloseBtn_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            searchBoxLable.Show();
            txtsearch.Enabled = false;
            txtsearch.Enabled = true;

        }

        private void searchBoxLable_Click(object sender, EventArgs e)
        {
            searchBoxLable.Hide();
            txtsearch.Focus();
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            searchBoxLable.Show();
        }

        private void txtsearch_Click(object sender, EventArgs e)
        {
            searchBoxLable.Hide();
        }

       

        

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int cellindex = e.ColumnIndex;
            try
            {
                int rowindex = e.RowIndex;
                var value = dataGridView.Rows[rowindex].Cells[0].Value;


                var idvalue = dataGridView.Rows[rowindex].Cells[0].Value;
                var batchtypeval = dataGridView.Rows[rowindex].Cells[1].Value;
                var ys = dataGridView.Rows[rowindex].Cells[2].Value;
                var prog = dataGridView.Rows[rowindex].Cells[3].Value;
                var mainIDval = dataGridView.Rows[rowindex].Cells[4].Value;
                var maingIdval = dataGridView.Rows[rowindex].Cells[5].Value;
                var subidval = dataGridView.Rows[rowindex].Cells[6].Value;
                var subgid = dataGridView.Rows[rowindex].Cells[7].Value;


                id.Text = idvalue.ToString();

                if (batchtypeval.ToString() == "week days")
                {
                    radioWeek.Checked = true;
                    radioWeekend.Checked = false;
                }
                else if (batchtypeval.ToString() == "weekend days")
                {
                    radioWeekend.Checked = true;
                    radioWeek.Checked = false;
                }

                comboProg.Text = prog.ToString();
                comboYearSem.Text = ys.ToString();

                txtMainGroup.Text = mainIDval.ToString();
                txtSubGroup.Text = subidval.ToString();

                groupIDDisplay.Text = maingIdval.ToString();
                supGroupIDDisplay.Text = subgid.ToString();
            }
            catch (Exception sqlx)
            {

               // throw new Exception("Problem med att sätta in namnet i ditt på inlägg/n" + sqlx.Message);
                MessageBox.Show("Please Click on a Cell or on a Row! .\n "+sqlx.Message, "Message For Timetable Generator");
            }
            

           
            

        }
       

        private void BtnReset_Click(object sender, EventArgs e)
        {
            id.Text = "";
            radioWeek.Checked = false;
            radioWeekend.Checked = false;

            if (comboProg.Text != "")
            {
                comboProg.Items[comboProg.SelectedIndex] = string.Empty;
            }
            if (comboYearSem.Text != "")
            {
                comboYearSem.Items[comboYearSem.SelectedIndex] = string.Empty;
            }

            txtMainGroup.Text = "";
            txtSubGroup.Text = "";

            groupIDDisplay.Text = "";
            supGroupIDDisplay.Text = "";

            comboLoad();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id.Text!="" && txtMainGroup.Text != "" && txtSubGroup.Text != "" && comboProg.Text != "" && comboYearSem.Text != "" && (radioWeek.Checked || radioWeekend.Checked))
            {
                //ComboBox year and semester SPLIT
                string data = comboYearSem.Text;
                string[] YearSem = data.Split(new string[] { "." }, StringSplitOptions.None);
                //MessageBox.Show(YearSem[0] +" dfgfg "+ YearSem[1]);

                //checking tag Table for new tagCode
                con.Open();
                String syntax4 = "SELECT count(id) FROM studentgroups WHERE (year = '" + YearSem[0] + "' and semester = '" + YearSem[1] + "' and programme = '" + comboProg.Text + "' and mainid = '" + txtMainGroup.Text + "' and subid = '" + txtSubGroup.Text + "' and batchtype = '" + weekOrWeekend + "') and campus = '"+campusComboValue+"'";
                cmd = new SqlCommand(syntax4, con);
                int countGroups = Convert.ToInt32(cmd.ExecuteScalar());

                //MessageBox.Show(countGroups.ToString());

                con.Close();

                if (countGroups == 0)
                {
                    con.Open();
                    String syntaxid = "SELECT count(id) FROM studentgroups WHERE id = '" + id.Text + "' and campus = '"+campusComboValue+"'";
                    cmd = new SqlCommand(syntaxid, con);
                    int countid = Convert.ToInt32(cmd.ExecuteScalar());

                    //MessageBox.Show(countGroups.ToString());

                    con.Close();
                    if (countid == 1)
                    {
                            con.Open();
                            String syntax = "update studentgroups set batchtype='" + weekOrWeekend + "',year='" + YearSem[0] + "',semester='" + YearSem[1] + "',programme='" + comboProg.Text + "',mainid='" + txtMainGroup.Text + "',subid='" + txtSubGroup.Text + "',subgrp='" + supGroupIDDisplay.Text+"' where id='"+id.Text+"' and campus = '"+campusComboValue+"' ";
                    
                            cmd = new SqlCommand(syntax, con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data was updated successfully!", "Message For Timetable Generator");
                            con.Close();
                    }
                    else
                    {
                        MessageBox.Show("There is No Student Group under '" + id.Text + "' ID !.", "Message For Timetable Generator");
                    }
                    

                }
                
                else
                {
                    MessageBox.Show("This Student Group has been alredy added !.", "Message For Timetable Generator");
                }



            }
            else
            {
                MessageBox.Show("Please Fill the form correctly!. The system Could not catch data ");
            }

            loadTable("select id as 'ID',batchtype as 'Batch Type',year+'.'+semester as 'Year and Semester',programme as 'Programme',mainid as 'Main Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2)) as 'Main Group ID',subid as 'Sub Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) as 'Main Group ID' from studentgroups where campus = '"+campusComboValue+"'");
        }

        String weekOrWeekend;
       

        private void radioWeekend_CheckedChanged_1(object sender, EventArgs e)
        {
            weekOrWeekend = "weekend days";
        }

        private void radioWeek_CheckedChanged_1(object sender, EventArgs e)
        {
            weekOrWeekend = "week days";
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
                

            }
        }

        private void comboProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProg.Text != "")
            {
                progPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");

            }
            else
            {
                

            }
        }

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

        private void id_TextChanged(object sender, EventArgs e)
        {
            if (id.Text != "")
            {
                panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                idLabel.Hide();

            }
            else
            {
                panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                idLabel.Show();


            }
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMainGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSubGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (id.Text != "")
            {
                //checking tag Table for new tagCode
                con.Open();
                String syntax4 = "SELECT count(id) FROM studentgroups WHERE id = '" + id.Text + "' and campus = '"+campusComboValue+"'";
                cmd = new SqlCommand(syntax4, con);
                int countTagCode = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                if (countTagCode != 0)
                {
                    con.Open();
                    String query3 = "DELETE FROM studentgroups where id = '" + id.Text + "'";
                    cmd = new SqlCommand(query3, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Student Group was Deleted!", "Message For Timetable Generator");

                    loadTable("select id as 'ID',batchtype as 'Batch Type',year+'.'+semester as 'Year and Semester',programme as 'Programme',mainid as 'Main Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2)) as 'Main Group ID',subid as 'Sub Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) as 'Main Group ID' from studentgroups  where campus = '" + campusComboValue + "'");
                }
                else
                {
                    MessageBox.Show("There is NO Data to Delete under '" + id.Text + "' ID. !", "Message For Timetable Generator");
                }
            }
            else
            {
                MessageBox.Show("Add ID to Delete !.", "Message For Timetable Generator");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
