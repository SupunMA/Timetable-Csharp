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
    public partial class supunAddTags : UserControl
    {
        
        
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;
       
        SqlDataReader dr;

        SqlDataAdapter adpt;
        DataTable dt;

        public supunAddTags()
        {
            
            InitializeComponent();
           
            
        }

        public void loadComboBox() {

            try
            {
                selectTagCombo.Items.Clear();
                con.Open();
                SqlDataReader dataRead = new SqlCommand("select tagName from relatedTag where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataRead.Read())
                {
                    selectTagCombo.Items.Add(dataRead.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

            loadSubjectCombo();
        }

        private void loadSubjectCombo()
        {
            try
            {
                selectSubjectCombo.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select subjectName from Subjects where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    selectSubjectCombo.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        public void loadTable(String Query) {

            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter(Query, con);
                adpt.Fill(dt);
                dataGridView.DataSource = dt;
                con.Close();

                dataGridView.RowTemplate.Height = 30;

                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");
                dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
                dataGridView.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


           /* SqlCommand cmd = new SqlCommand(Query, con);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);

            BindingSource bsource = new BindingSource();

            bsource.DataSource = dt;

            dataGridView.DataSource = bsource;*/

        }

        private void supunAddTags_Load(object sender, EventArgs e)
        {
            
            //loadDataTimer.Enabled = true;
            //inisial
            searchCloseBtn.Hide();
            closeBtnTag.Hide();
            TagIDClose.Hide();
            NewTagNameClose.Hide();

            //checked add new related radio button and hide updte textbox panel when load screen
            radioButtonAddNew.Checked=true;
            UpdatePanel.Hide();


            UpdatePanel.Location = new Point(25, 80);

           // loadComboBox();
           
            toolTip1.SetToolTip(this.searchCloseBtn, "Clear");
            toolTip1.SetToolTip(this.closeBtnTag, "Clear");
            toolTip1.SetToolTip(this.button1, "Save Data");
            toolTip1.SetToolTip(this.relatedTagSave, "Save Data");
            toolTip1.SetToolTip(this.button2, "Clear Data");
            toolTip1.SetToolTip(this.button5, "Delete Data");

          

           
           

            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            if (txtTagCode.Text != "")
            {
                panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
            }
            else
            {
                panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchBox.Text != "")
                {
                    panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                    searchBoxLable.Hide();
                    searchCloseBtn.Show();
                    int parsedValue;
                    if (int.TryParse(txtSearchBox.Text, out parsedValue))
                    {
                        loadTable("Select tagid as 'Tag ID',tagname as 'Tag Name' from RelatedTag where tagid Like '" + txtSearchBox.Text + "%' and campus ='" + campusComboValue + "'");

                    }
                    else
                    {

                        loadTable("Select tagid as 'Tag ID',tagname as 'Tag Name' from RelatedTag where tagname Like '" + txtSearchBox.Text + "%' and campus ='" + campusComboValue + "'");

                    }



                }
                else
                {
                    panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                    //searchBoxLable.Show();
                    searchCloseBtn.Hide();

                    loadTable("Select tagid as 'Tag ID',tagname as 'Tag Name' from RelatedTag where campus='" + campusComboValue + "'");


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void searchBoxLable_Click(object sender, EventArgs e)
        {
            searchBoxLable.Hide();

            txtSearchBox.Focus();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            searchBoxLable.Hide();

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtSearchBox.Text != "")
            {
                searchCloseBtn.Show();
            }
            else
            {
                searchBoxLable.Show();
                searchCloseBtn.Hide();
            }

        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //loadTable();
           

            if (checkBox1.Checked == true)
            {
                panel8.Show();
                addRelatedTagPanel.Show();
            }
            else
            {
                panel8.Hide();
                addRelatedTagPanel.Hide();
            }
            
        }

        private void addRelatedTagPanel_Paint(object sender, PaintEventArgs e)
        {
            //adding border to panel
            //ControlPaint.DrawBorder(e.Graphics, this.addRelatedTagPanel.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void EditagsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTagCode.Text != "" && selectTagCombo.Text != "" && selectSubjectCombo.Text != "")
                {
                    //Get subjectCode from subjectName
                    con.Open();
                    String syntax2 = "SELECT subjectCode FROM subjects WHERE subjectName = '" + selectSubjectCombo.Text + "'";
                    cmd = new SqlCommand(syntax2, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string subCode = (dr[0].ToString());
                    con.Close();

                    //Get Related TagId from Related tagName
                    con.Open();
                    String syntax3 = "SELECT TagID FROM relatedTag WHERE tagname = '" + selectTagCombo.Text + "'";
                    cmd = new SqlCommand(syntax3, con);
                    int tagid = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    //checking tag Table for new tagCode
                    con.Open();
                    String syntax4 = "SELECT count(tagcode) FROM tags WHERE tagcode = '" + txtTagCode.Text + "'";
                    cmd = new SqlCommand(syntax4, con);
                    int countTagCode = Convert.ToInt32(cmd.ExecuteScalar());

                    //MessageBox.Show(countTagCode.ToString());

                    con.Close();

                    if (countTagCode == 0)
                    {
                        con.Open();
                        String syntax = "Insert Into Tags values ('" + txtTagCode.Text + "','" + tagid + "','" + subCode + "','" + campusComboValue + "','')";
                        cmd = new SqlCommand(syntax, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data was Saved!", "Message For Timetable Generator");
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("TagCode has been alredy added !. \n If you want to edit, Click on \"Edit Tag\" buttton", "Message For Timetable Generator");
                    }



                }
                else
                {
                    MessageBox.Show("Please fill the Textboxes correctly!", "Message For Timetable Generator");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
            

           
        }

        private void searchCloseBtn_Click_1(object sender, EventArgs e)
        {
            txtSearchBox.Text = "";
            txtSearchBox.Focus();
        }

        private void addRelatedTagLabel_Click(object sender, EventArgs e)
        {
            addRelatedTagLabel.Hide();

            txtAddRelatedTag.Focus();
        }

        private void txtAddRelatedTag_TextChanged(object sender, EventArgs e)
        {
            if (txtAddRelatedTag.Text != "")
            {
                panel4.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                addRelatedTagLabel.Hide();
                closeBtnTag.Show();
            }
            else
            {
                panel4.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                //searchBoxLable.Show();
                closeBtnTag.Hide();
            }

            int parsedValue;
            if (!int.TryParse(txtAddRelatedTag.Text, out parsedValue) && txtAddRelatedTag.Text != "")
            {
                button5.Enabled = false;
            }
            else
            {
                if (radioButtonUpdate.Checked)
                {
                     button5.Enabled = false;
                }
                else
                {
                    button5.Enabled = true;
                }
            }
        }

        private void closeBtnTag_Click(object sender, EventArgs e)
        {
            txtAddRelatedTag.Text = "";
            txtAddRelatedTag.Focus();
        }

        private void txtAddRelatedTag_Click(object sender, EventArgs e)
        {
            addRelatedTagLabel.Hide();
        }

        private void txtAddRelatedTag_Leave(object sender, EventArgs e)
        {
            if (txtAddRelatedTag.Text != "")
            {
                closeBtnTag.Show();
            }
            else
            {
                addRelatedTagLabel.Show();
                closeBtnTag.Hide();
            }
        }



       

        private void labelTagcode_Click(object sender, EventArgs e)
        {
           labelTagcode.Hide();
            txtTagCode.Focus();
        }

       

        private void button2_Click(object sender, EventArgs e)//Reset Btn
        {
           
            //mm.aa();
            MessageBox.Show(campusComboValue);
            //selectTagCombo.ResetText();
            //selectSubjectCombo.ResetText();
            if (selectTagCombo.Text!="")
            {
                selectTagCombo.Items[selectTagCombo.SelectedIndex] = string.Empty;
                
            }
            if(selectSubjectCombo.Text!="")
            {
                selectSubjectCombo.Items[selectSubjectCombo.SelectedIndex] = string.Empty;
                
            }
            
            loadComboBox();

            txtTagCode.Text = "";

            labelTagcode.Show();
            panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
        }




        private void txtTagCode_TextChanged(object sender, EventArgs e)
        {
            if (txtTagCode.Text != "")
            {
                panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                labelTagcode.Hide();

            }
            else
            {
                panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                labelTagcode.Show();


            }
        }

        private void txtTagCode_Click(object sender, EventArgs e)
        {
            labelTagcode.Hide();
        }

        private void txtTagCode_Leave(object sender, EventArgs e)
        {
            if (txtTagCode.Text != "")
            {
                labelTagcode.Hide();
                //searchCloseBtn.Show();
            }
            else
            {
                labelTagcode.Show();
                //searchCloseBtn.Hide();
            }
        }



        private void relatedTagSave_Click(object sender, EventArgs e)
        {
            if (radioButtonAddNew.Checked==true)
            {
                if (txtAddRelatedTag.Text != "")
                {
                    try
                    {
                        con.Open();
                        String syntax = "Insert Into RelatedTag values ('" + txtAddRelatedTag.Text + "','" + campusComboValue + "','')";
                        cmd = new SqlCommand(syntax, con);
                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("Data Added!");
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    

                }
                else
                {
                    MessageBox.Show("There is no Valied Data to Insert !.", "Message For Timetable Generator");

                }
            }
            else if (radioButtonUpdate.Checked == true)
            {
                if (txtupdateRelatedTagID.Text != "" && txtUpdateRelatedTagName.Text != "")
                {
                    try
                    {
                        con.Open();
                        String syntax = "update RelatedTag set tagname= '" + txtUpdateRelatedTagName.Text + "' where tagid='" + txtupdateRelatedTagID.Text + "' and campus = '" + campusComboValue + "'";
                        cmd = new SqlCommand(syntax, con);
                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("Data Added!");
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    

                }
                else
                {
                    MessageBox.Show("There is no Valied Data to Update !.", "Message For Timetable Generator");

                }
            }




            //When Click Save Btn Retriev Data From Table 
            loadTable("Select tagid as 'Tag ID',tagname as 'Tag Name' from RelatedTag where campus='" + campusComboValue + "'");
           
            

            loadComboBox();
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddRelatedTag.Text != "")
                {//checking retated tag row is using in tag table
                    con.Open();
                    String query1 = "SELECT relatedTag.tagID FROM relatedTag INNER JOIN tags ON relatedTag.tagID = tags.relatedTag WHERE relatedTag.tagID = '" + txtAddRelatedTag.Text + "'";
                    cmd = new SqlCommand(query1, con);
                    int value1 = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    if (value1 == 0)
                    {//Checking whether data is in related tag table
                        con.Open();
                        String query2 = "SELECT tagid FROM relatedTag WHERE tagID = '" + txtAddRelatedTag.Text + "'";
                        cmd = new SqlCommand(query2, con);
                        int value2 = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        //Show message if the data is not in the Related Tag Table 
                        if (value2 == 0)
                        {
                            MessageBox.Show("Wrong Input !.There is No entered 'TagID' in Relaed Tag Table");
                        }
                        //DELETE RELATED TAG
                        else
                        {
                            con.Open();
                            String query3 = "DELETE FROM relatedtag where tagID = '" + txtAddRelatedTag.Text + "'";
                            cmd = new SqlCommand(query3, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Related Tag was Deleted!", "Message For Timetable Generator");
                        }

                    }//Show message If Tag is using
                    else
                    {
                        MessageBox.Show("The Related Tag is used by a tag!", "Message For Timetable Generator");
                    }



                    //retrieve relatedtag table data to grid view
                    loadTable("Select tagid as 'Tag ID',tagname as 'Tag Name' from RelatedTag");

                    //Delete select tag combobox items
                    //selectTagCombo.Items.Clear();
                    loadComboBox();

                }
                else
                {
                    MessageBox.Show("Please Add TagID to Delete!", "Message For Timetable Generator");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
                panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
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

        //add radio button action
        private void radioButtonAddNew_CheckedChanged(object sender, EventArgs e)
        {
            AddnewPanel.Show();
            UpdatePanel.Hide();
            relatedTagSave.Text = "Save";
        }
        private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePanel.Show();
            AddnewPanel.Hide();
            relatedTagSave.Text = "Update";
        }





        //Update TagID text box interface Actions
        private void TagIDLabel_Click(object sender, EventArgs e)
        {
            TagIDLabel.Hide();
            txtupdateRelatedTagID.Focus();
        }

        private void txtupdateRelatedTagID_Click(object sender, EventArgs e)
        {
            TagIDLabel.Hide();
        }

        private void txtupdateRelatedTagID_Leave(object sender, EventArgs e)
        {
            if (txtupdateRelatedTagID.Text=="")
            {
                TagIDLabel.Show();
            }
            
        }




        //Update TagName text box interface Actions
        private void NewrelatedTagNameLabel_Click(object sender, EventArgs e)
        {
            NewrelatedTagNameLabel.Hide();
            txtUpdateRelatedTagName.Focus();
        }

        private void txtUpdateRelatedTagName_Click(object sender, EventArgs e)
        {
            NewrelatedTagNameLabel.Hide();
        }

        private void txtUpdateRelatedTagName_Leave(object sender, EventArgs e)
        {
            if (txtUpdateRelatedTagName.Text=="")
            {
                NewrelatedTagNameLabel.Show();
            }
            
        }



        //in tagId updating textbox only integer
        private void txtupdateRelatedTagID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void txtupdateRelatedTagID_TextChanged(object sender, EventArgs e)
        {
            if (txtupdateRelatedTagID.Text != "")
            {
                panel10.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                TagIDLabel.Hide();
                TagIDClose.Show();
            }
            else
            {
                panel10.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                //searchBoxLable.Show();
                TagIDClose.Hide();
            }
        }

        

        private void txtUpdateRelatedTagName_TextChanged(object sender, EventArgs e)
        {
            if (txtUpdateRelatedTagName.Text != "")
            {
                panel11.BackColor = System.Drawing.ColorTranslator.FromHtml("#37eb34");
                NewrelatedTagNameLabel.Hide();
                NewTagNameClose.Show();
            }
            else
            {
                panel11.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                //searchBoxLable.Show();
                NewTagNameClose.Hide();
            }
        }

        private void NewTagNameClose_Click(object sender, EventArgs e)
        {
            txtUpdateRelatedTagName.Text = "";
            txtUpdateRelatedTagName.Focus();
        }

        private void TagIDClose_Click(object sender, EventArgs e)
        {
            txtupdateRelatedTagID.Text = "";
            txtupdateRelatedTagID.Focus();
        }

        //when click on row / cell add/delete text box display value
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentCell.ColumnIndex.Equals(0) || dataGridView.CurrentCell.ColumnIndex.Equals(1) && e.RowIndex != -1)
                {
                    if (dataGridView.CurrentCell != null && dataGridView.CurrentCell.Value != null)
                    {

                        txtAddRelatedTag.Text = dataGridView.CurrentCell.Value.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        //When Click on table Row Update RelatedTag textboxes Display values
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    txtupdateRelatedTagID.Text = row.Cells[0].Value.ToString();
                    txtUpdateRelatedTagName.Text = row.Cells[1].Value.ToString();
                    //...
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void loadDataTimer_Tick(object sender, EventArgs e)
        {
           
            //loadDataTimer.Enabled = false;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            loadTable("Select tagid as 'Tag ID',tagname as 'Tag Name' from RelatedTag where campus='"+campusComboValue+"'");
            loadComboBox();
            panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
        }

        private void selectSubjectCombo_Click(object sender, EventArgs e)
        {
            loadSubjectCombo();
        }

        private void txtTagCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtAddRelatedTag_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtUpdateRelatedTagName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
