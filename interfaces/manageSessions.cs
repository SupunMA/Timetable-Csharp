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
    public partial class manageSessions : UserControl
    {
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False;MultipleActiveResultSets=true");
        SqlCommand cmd;
        SqlCommand cmd2;

        SqlDataReader dr,dr2;
        public manageSessions()
        {
            InitializeComponent();
            //tabControlNotAvaLocation.RightToLeft = RightToLeft.Yes;
            // tabControlNotAvaLocation.RightToLeftLayout = true; 


            tabControlAddSession.Show();
            tabControlTimeAllocation.Hide();
            tabControlLocation.Hide();
            btnAddsession.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");

            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.ToolTipTitle = "Search Sessions";
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ShowAlways = true;
            buttonToolTip.AutoPopDelay = 8000;
            buttonToolTip.InitialDelay = 0;
            buttonToolTip.ReshowDelay = 500;
            buttonToolTip.SetToolTip(txtSearchBoxCreateConsecutive, "Type Session ID or Subject or Tag Name here!.");
            buttonToolTip.SetToolTip(txtSerachParallel, "Type Session ID or Subject or Tag Name here!.");
            buttonToolTip.SetToolTip(txtSearchNonOver, "Type Session ID or Subject or Tag Name here!.");

            buttonToolTip.SetToolTip(txtSearchBoxCreatedConsecutive, "Type Session ID or Subject or Tag Name here!.");
            buttonToolTip.SetToolTip(txtSerachParallelCreated, "Type Session ID or Subject or Tag Name here!.");
            buttonToolTip.SetToolTip(txtSearchNonOverCreated, "Type Session ID or Subject or Tag Name here!.");


        }

        /// <summary>
        /// Top Three Buttons  
        /// </summary>

        private void btnTimeAllocation_Click(object sender, EventArgs e)
        {
            tabControlAddSession.Hide();
            tabControlLocation.Hide();
            tabControlTimeAllocation.Show();
            btnTimeAllocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");

            btnAddsession.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            btnSessionLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");



            //btnViewCreatedConseSession.Text = "View List of Consecutive Sessions";
            LBLConsecutiveSession.Text = "Creatable Consecutive Sessions";
            btnCreateConsecutiveSession.Text = "Create Consecutive Session";
            btnCreateConsecutiveSession.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");

            loadConsecutiveSession();
            loadParallelSession();
            loadNonOverSession();
            loadSumaliLocationCombo();
            // notifyIcon1.Icon = SystemIcons.Application;
            //  notifyIcon1.Visible = true;
            // notifyIcon1.ShowBalloonTip(7000, "ABC Timetable Generator", "Generated PDF File \nClick Here to Open", ToolTipIcon.Info);
        }

        private void btnAddsession_Click(object sender, EventArgs e)
        {
            tabControlAddSession.Show();
            tabControlTimeAllocation.Hide();
            tabControlLocation.Hide();
            btnAddsession.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");

            btnTimeAllocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            btnSessionLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");

            loadTable("select id as 'Session ID',lecturers as 'Lecturers',subject as 'Subject',tag as 'Tag',stdgroup as 'Student Group',numofstudents as 'Student Amount',duration as 'Duration',locationname as 'Locations',consecutive as 'Consecutive ID',parallel as 'Parallel ID',nonover as 'Non Overlapping ID',locconsecutive as 'Location Consecutive ID',notday as 'Not Available Day' from sessions where campus = '" + campusComboValue + "'");
            // notifyIcon1.Icon = SystemIcons.Exclamation;
            // notifyIcon1.Visible = true;
            // notifyIcon1.ShowBalloonTip(7000, "ABC Timetable Generator", "Generated PDF File \nClick Here to Open", ToolTipIcon.Info);
        }

        private void btnSessionLocation_Click(object sender, EventArgs e)
        {
            tabControlAddSession.Hide();
            tabControlTimeAllocation.Hide();
            tabControlLocation.Show();
            btnSessionLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");

            btnAddsession.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            btnTimeAllocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");

            loadComboBoxesHasini();
            loadSumaliLocationCombo();
            loadConsecutiveSessionforHasini();
        }







        /// <summary>
        /// Jayani
        /// </summary>

        public void loadLecturerCheckLIST()              //Load Check List BOX  -Lecturers-  -Add Session-
        {
            displayLecturers.Clear();
            try
            {
                //checkedListBox1.Items.Remove(checkedListBox1.SelectedItem.Tostring());
                checkedListBoxAddLecturersAddSession.Items.Clear();
                checkedListBoxAddSessionLecturers.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select lecname from lecturers where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    checkedListBoxAddLecturersAddSession.Items.Add(dataReadSubject.GetValue(0).ToString());
                    checkedListBoxAddSessionLecturers.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            loadConsecutiveSession();
        }

        public void loadTagCombo()                             //Load Combo BOX  -Related Tags-  -Add sessions-
        {
            try
            {
                comboAddTag.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select tagName from relatedTag where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboAddTag.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {
                comboEditTagAddSession.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select tagName from relatedTag where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboEditTagAddSession.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        public void loadStudentgrpCombo()                   //Load Combo BOX According to lecturer  -Student Groups-  -Add sessions-
        {
            string data = displayLecturers.Text.ToString();
            string[] lecname = data.Split(new string[] { "," }, StringSplitOptions.None);

            con.Open();
            String syntax = "SELECT * FROM lecturers WHERE lecname = '" + lecname[0] + "' and campus='" + campusComboValue + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();

            String depart = (dr[4].ToString());
            con.Close();

            try
            {
                comboSelectGroup.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) from StudentGroups where programme='" + depart + "' and campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboSelectGroup.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();

               /* con.Open();
                SqlDataReader dataReadSubject2 = new SqlCommand("select year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.' from StudentGroups where programme='" + depart + "' and campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject2.Read())
                {
                    if (!comboSelectGroup.Items.Contains(dataReadSubject2.GetValue(0).ToString()))
                    {
                       
                        comboSelectGroup.Items.Add(dataReadSubject2.GetValue(0).ToString());
                    }
                    
                }
                con.Close();
               */
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        public int Year;
        public void loadSubjectCombo()                  //Load Combo BOX According to student group and tag -Subjects-  -Add sessions-
        {

            try
            {
                string data = comboSelectGroup.Text.ToString();
                string[] YandS = data.Split(new string[] { "." }, StringSplitOptions.None);


                if (YandS[0] == "Y1")
                {
                    Year = 1;
                }
                else if (YandS[0] == "Y1")
                {
                    Year = 2;
                }
                else if (YandS[0] == "Y1")
                {
                    Year = 3;
                }
                else
                {
                    Year = 4;
                }


                comboSelectSubject.Items.Clear();

                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select s.subjectname from tags as t INNER JOIN subjects as s ON t.subject = s.subjectcode INNER JOIN relatedtag as r ON t.relatedtag = r.tagid where s.semester ='" + YandS[1] + "' and s.offeredyear='" + Year + "' and r.tagname = '" + comboAddTag.Text + "' and s.campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboSelectSubject.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }


        private void checkedListBoxAddLecturersAddSession_SelectedIndexChanged(object sender, EventArgs e)     //Display Selected Lecturers in display Text Box
        {
            displayLecturers.Clear();
            foreach (String item in checkedListBoxAddLecturersAddSession.CheckedItems)
            {
                if (displayLecturers.Text != "")
                {
                    displayLecturers.Text = item + ',' + displayLecturers.Text;
                }
                else
                {
                    displayLecturers.Text = item + ',';
                }

            }
        }


        private void checkedListBoxAddLecturersAddSession_Leave(object sender, EventArgs e)                       //Display Selected Lecturers in display Text Box
        {
            displayLecturers.Clear();
            foreach (String item in checkedListBoxAddLecturersAddSession.CheckedItems)
            {
                if (displayLecturers.Text != "")
                {
                    displayLecturers.Text = item + ',' + displayLecturers.Text;
                }
                else
                {
                    displayLecturers.Text = item + ',';
                }
            }
        }


        private void SubmitBtnAddSession_Click(object sender, EventArgs e)                  //When Click on Submit button Save Data(Session) in DB
        {
            if (displayLecturers.Text == "" || comboAddTag.SelectedIndex == -1 || comboSelectGroup.SelectedIndex == -1 || comboSelectSubject.SelectedIndex == -1 || numUpDownStudentAdd.Value == 0 || numUpDownAddSessionHrs.Value == 0)
            {
                MessageBox.Show("Please Fill the Blanks !");
            }
            else
            {
                con.Open();
                String syntax4 = "SELECT count(id) FROM sessions WHERE tag = '" + comboAddTag.Text + "' and stdgroup = '" + comboSelectGroup.Text + "' and subject = '" + comboSelectSubject.Text + "' and campus = '" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countSessions = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();


                if (countSessions == 0)
                {
                    con.Open();
                    String syntax = "Insert Into sessions values ('" + displayLecturers.Text + "','" + comboAddTag.Text + "', '" + comboSelectGroup.Text + "' ,'" + comboSelectSubject.Text + "','" + numUpDownStudentAdd.Value + "','" + numUpDownAddSessionHrs.Value + "','" + campusComboValue + "','','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','','" + 0 + "','','" + 0 + "','" + 0 + "')";
                    cmd = new SqlCommand(syntax, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data was Saved!", "Message For Timetable Generator");
                    con.Close();

                }
                else
                {
                    MessageBox.Show("This Session has been alredy added !. If you want to Edit Click on 'Edit Days' button.", "Message For Timetable Generator");
                }
            }
        }

        private void tabControlAddSession_SelectedIndexChanged(object sender, EventArgs e)      //Load Session details to manage session tab Table
        {
            loadTable("select id as 'Session ID',lecturers as 'Lecturers',subject as 'Subject',tag as 'Tag',stdgroup as 'Student Group',numofstudents as 'Student Amount',duration as 'Duration',locationname as 'Locations',consecutive as 'Consecutive ID',parallel as 'Parallel ID',nonover as 'Non Overlapping ID',locconsecutive as 'Location Consecutive ID',notday as 'Not Available Days' from sessions where campus = '" + campusComboValue + "'");
        }

        public void loadTable(String Query)                             // Code for Load the Tables
        {
            try
            {
                SqlCommand cmd = new SqlCommand(Query, con);

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bsource = new BindingSource();

                bsource.DataSource = dt;

                dataGridViewAddSession.DataSource = bsource;

                dataGridViewAddSession.Columns[0].Width = 40;// The id column 
                dataGridViewAddSession.Columns[1].Width = 200;
                dataGridViewAddSession.Columns[7].Width = 200;// The abbrevation columln
                dataGridViewAddSession.RowTemplate.Height = 30;

                dataGridViewAddSession.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");
                dataGridViewAddSession.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
                dataGridViewAddSession.EnableHeadersVisualStyles = false;


            }
            catch (Exception ec)
            {

                MessageBox.Show(ec.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public int idJayani;
        private void dataGridViewAddSession_CellClick(object sender, DataGridViewCellEventArgs e)               //When click on cell get data to textboxes
        {
            try
            {
                int rowindex = e.RowIndex;

                var id = dataGridViewAddSession.Rows[rowindex].Cells[0].Value;
                var lecturers = dataGridViewAddSession.Rows[rowindex].Cells[1].Value;
                var subJ = dataGridViewAddSession.Rows[rowindex].Cells[2].Value;
                var tag = dataGridViewAddSession.Rows[rowindex].Cells[3].Value;
                var stdGr = dataGridViewAddSession.Rows[rowindex].Cells[4].Value;
                var stAmount = dataGridViewAddSession.Rows[rowindex].Cells[5].Value;
                var dura = dataGridViewAddSession.Rows[rowindex].Cells[6].Value;


                //Load Student Group According to lecturer
                string data = lecturers.ToString();
                string[] lecname = data.Split(new string[] { "," }, StringSplitOptions.None);

                foreach (string day in lecname)
                {
                    // MessageBox.Show(day + "/");
                }


                // using Length property
                //  MessageBox.Show(lecname.Length.ToString());

                con.Open();
                String syntax = "SELECT * FROM lecturers WHERE lecname = '" + lecname[0] + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                String depart = (dr[4].ToString());
                con.Close();

                try
                {
                    comboEditAddsessionStudentGrp.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) from StudentGroups where programme='" + depart + "' and campus='" + campusComboValue + "'", con).ExecuteReader();
                    while (dataReadSubject.Read())
                    {
                        comboEditAddsessionStudentGrp.Items.Add(dataReadSubject.GetValue(0).ToString());
                    }
                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }






                //Load Subject Combo

                try
                {
                    string data2 = stdGr.ToString();
                    string[] YandS = data2.Split(new string[] { "." }, StringSplitOptions.None);


                    if (YandS[0] == "Y1")
                    {
                        Year = 1;
                    }
                    else if (YandS[0] == "Y1")
                    {
                        Year = 2;
                    }
                    else if (YandS[0] == "Y1")
                    {
                        Year = 3;
                    }
                    else
                    {
                        Year = 4;
                    }


                    comboEditAddsessionSubject.Items.Clear();

                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select s.subjectname from tags as t INNER JOIN subjects as s ON t.subject = s.subjectcode INNER JOIN relatedtag as r ON t.relatedtag = r.tagid where s.semester ='" + YandS[1] + "' and s.offeredyear='" + Year + "' and r.tagname = '" + tag.ToString() + "' and s.campus='" + campusComboValue + "'", con).ExecuteReader();
                    while (dataReadSubject.Read())
                    {
                        comboEditAddsessionSubject.Items.Add(dataReadSubject.GetValue(0).ToString());
                    }
                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }






                //Set The selected values
                comboEditAddsessionStudentGrp.Text = stdGr.ToString();
                comboEditAddsessionSubject.Text = subJ.ToString();
                comboEditTagAddSession.Text = tag.ToString();

                idJayani = Convert.ToInt32(id.ToString());  //Get to Update the table

                numericUpDownEditAddSessionNoStudent.Value = Convert.ToInt32(stAmount.ToString());
                UpDownHrsEditAddSession.Value = Convert.ToInt32(dura.ToString());



            }
            catch (Exception sqlx)
            {

                // throw new Exception("Problem med att sätta in namnet i ditt på inlägg/n" + sqlx.Message);
                // MessageBox.Show("Please Click on a Cell or on a Row! .\n " + sqlx.Message, "Message For Timetable Generator");
            }
        }

        private void btnAddsessionUpdate_Click(object sender, EventArgs e)    // Update table
        {
            if (comboEditAddsessionStudentGrp.SelectedIndex != -1 || comboEditAddsessionSubject.SelectedIndex != -1 || comboEditTagAddSession.SelectedIndex != -1 || numericUpDownEditAddSessionNoStudent.Value != 0 || UpDownHrsEditAddSession.Value != 0)
            {
                con.Open();
                String syntax = "update sessions set stdgroup = '" + comboEditAddsessionStudentGrp.Text + "',subject = '" + comboEditAddsessionSubject.Text + "',tag = '" + comboEditTagAddSession.Text + "',duration = '" + UpDownHrsEditAddSession.Value + "',numofstudents = '" + numericUpDownEditAddSessionNoStudent.Value + "' where id ='" + idJayani + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Updated Session !");
                con.Close();

                loadTable("select id as 'Session ID',lecturers as 'Lecturers',subject as 'Subject',tag as 'Tag',stdgroup as 'Student Group',numofstudents as 'Student Amount',duration as 'Duration',locationname as 'Locations',consecutive as 'Consecutive ID',parallel as 'Parallel ID',nonover as 'Non Overlapping ID',locconsecutive as 'Location Consecutive ID',notday as 'Not Available Days' from sessions where campus = '" + campusComboValue + "'");
            }
            else
            {
                MessageBox.Show("Please Insert DAta !");
            }
        }

        private void btnDeleteAddSession_Click(object sender, EventArgs e)    // Delete Session
        {
            if (idJayani != 0)
            {
                con.Open();
                String syntax = "delete from sessions where id ='" + idJayani + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Deleted Session !");
                con.Close();

                loadTable("select id as 'Session ID',lecturers as 'Lecturers',subject as 'Subject',tag as 'Tag',stdgroup as 'Student Group',numofstudents as 'Student Amount',duration as 'Duration',locationname as 'Locations',consecutive as 'Consecutive ID',parallel as 'Parallel ID',nonover as 'Non Overlapping ID',locconsecutive as 'Location Consecutive ID',notday as 'Not Available Day' from sessions where campus = '" + campusComboValue + "'");

            }
            else
            {
                MessageBox.Show("Please Select a row to Delete !");
            }
        }



        private void comboSelectGroup_SelectedIndexChanged(object sender, EventArgs e)    // Subject Combo load When select student group  -- Jayani
        {
            if (comboSelectGroup.SelectedIndex != -1)
            {
                loadSubjectCombo();
            }

        }

        private void comboSelectGroup_Click(object sender, EventArgs e)   // Student group load when click on student group commbbo  --Jayani
        {
            if (displayLecturers.Text != "" && comboAddTag.SelectedIndex != -1)
            {

                loadStudentgrpCombo();
            }
            else
            {
                MessageBox.Show("Please Select Lecturer and Tag !");
            }
        }

        private void comboSelectSubject_SelectedIndexChanged(object sender, EventArgs e)   //Hide combo text when select subject  --Jayani
        {
            if (comboSelectGroup.SelectedIndex == -1)
            {
                comboSelectSubject.SelectedIndex = -1;
            }
        }

        private void comboAddTag_SelectedIndexChanged(object sender, EventArgs e)   //When change tag student group combo Selected value = NULL 
        {
            comboSelectGroup.SelectedIndex = -1;
        }


        private void btnResetJayani1_Click(object sender, EventArgs e)   // page one reset Button -- Add Session  --Jayani 
        {
            // checkedListBoxAddLecturersAddSession.ClearSelected();
            for (int i = 0; i < checkedListBoxAddLecturersAddSession.Items.Count; i++)
                checkedListBoxAddLecturersAddSession.SetItemCheckState(i, (false ? CheckState.Checked : CheckState.Unchecked));
            displayLecturers.Text = "";
            comboAddTag.SelectedIndex = -1;
        }

        private void btnResetJayani2_Click(object sender, EventArgs e)     // page two reset Button -- Add Session  --Jayani 
        {
            comboSelectGroup.SelectedIndex = -1;
            comboSelectSubject.SelectedIndex = -1;

            numUpDownStudentAdd.Value = 0;
            numUpDownAddSessionHrs.Value = 0;
        }




        private void checkedListBoxCreateConsecutiveSessions_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void checkedListBoxCreateConsecutiveSessions_SelectedValueChanged(object sender, EventArgs e)
        {
            /*
            foreach (object itemChecked in checkedListBoxCreateConsecutiveSessions.CheckedItems)
            {
                string data = itemChecked.ToString();
                string[] YearSem = data.Split(new string[] { ")" }, StringSplitOptions.None);

                SessionIDlist.Add(Convert.ToInt32(YearSem[0]).ToString());
                //MessageBox.Show(SessionIDlist[0]);
                MessageBox.Show(checkedListBoxCreateConsecutiveSessions.CheckedItems.Count.ToString());

            }
            */

        }

        /////////////////////////////////////////////////////////////////////////////////////////






        /// <summary>
        ///////////////////// //  Supun
        /// </summary>


        public void loadConsecutiveSession()           //Load Check List BOX  -Sessions-  -Time Allocation-   Consecutive
        {

            //Creatable Consecutive sessions load
            try
            {
                //checkedListBox1.Items.Remove(checkedListBox1.SelectedItem.Tostring());
                checkedListBoxCreatableConsecutiveSessions.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup  from sessions where campus='" + campusComboValue + "' and consecutive = '" + 0 + "'", con).ExecuteReader();

                while (dataReadSubject.Read())
                {
                    checkedListBoxCreatableConsecutiveSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //Created Consecutive sessions Load

            try
            {

                checkedListBoxCreatedConsecutiveSessions.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup+ ' | Conse ID :- '+CAST(consecutive AS varchar(5))  from sessions where campus='" + campusComboValue + "' and consecutive != '" + 0 + "' order by consecutive", con).ExecuteReader();

                while (dataReadSubject.Read())
                {
                    checkedListBoxCreatedConsecutiveSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //
        }
        public void loadParallelSession()           //Load Check List BOX  -Sessions-  -Time Allocation-  Parallel
        {

            // Creatable Parallel Sessions Load
            try
            {
                //checkedListBox1.Items.Remove(checkedListBox1.SelectedItem.Tostring());
                checkedListBoxCreatableParallelSessions.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup  from sessions where campus='" + campusComboValue + "' and parallel = '" + 0 + "'", con).ExecuteReader();

                while (dataReadSubject.Read())
                {
                    checkedListBoxCreatableParallelSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            // Created Parallel Session load
            try
            {
                //checkedListBox1.Items.Remove(checkedListBox1.SelectedItem.Tostring());
                checkedListBoxCreatedParallelSessions.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup+ ' | Para ID :- '+CAST(parallel AS varchar(5))  from sessions where campus='" + campusComboValue + "' and parallel != '" + 0 + "' order by parallel", con).ExecuteReader();

                while (dataReadSubject.Read())
                {
                    checkedListBoxCreatedParallelSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //
        }
        public void loadNonOverSession()           //Load Check List BOX  -Sessions-  -Time Allocation- NON OverLapping
        {

            // Creatable Parallel Sessions Load
            try
            {
                //checkedListBox1.Items.Remove(checkedListBox1.SelectedItem.Tostring());
                checkedListBoxCreatableNonOverSessions.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup  from sessions where campus='" + campusComboValue + "' and nonover = '" + 0 + "' ", con).ExecuteReader();

                while (dataReadSubject.Read())
                {
                    checkedListBoxCreatableNonOverSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            // Created Parallel Sessions Load
            try
            {
                //checkedListBox1.Items.Remove(checkedListBox1.SelectedItem.Tostring());
                checkedListBoxCreatedNonOverSessions.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup+ ' | Non ID :- '+CAST(nonover AS varchar(5))  from sessions where campus='" + campusComboValue + "' and nonover != '" + 0 + "' order by nonover", con).ExecuteReader();

                while (dataReadSubject.Read())
                {
                    checkedListBoxCreatedNonOverSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //
        }

        int GenNum;
        public int GenerateRandomNumberForConsecutive()       //GENERATE Consecutive ID
        {

            //check consecutive randomm number Avilability
            int countConsecutiveSessionNumber;

            do
            {
                Random rnd = new Random();
                GenNum = rnd.Next(10000);

                con.Open();
                String syntax = "SELECT count(id) FROM sessions WHERE consecutive = '" + GenNum + "'  and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                countConsecutiveSessionNumber = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            } while (countConsecutiveSessionNumber > 0);



            return GenNum;
        }
        
        

        String gotSessID;
        String gotSTDgrp;
        String gotSubject;
        String gotTag;

       
        int gotNonoverIDConse;
        private void btnCreateConsecutiveSession_Click(object sender, EventArgs e)          //When click on create consecutiv session buttion Create Consecutive Sessions.
        {

            if (checkedListBoxCreatableConsecutiveSessions.CheckedItems.Count == 2)
            {
                try
                {
                    int newConseID = GenerateRandomNumberForConsecutive();

                    int selectedItems = checkedListBoxCreatableConsecutiveSessions.CheckedItems.Count;

                    foreach (object itemChecked in checkedListBoxCreatableConsecutiveSessions.CheckedItems)
                    {

                        string data = itemChecked.ToString();
                        string[] YearSem = data.Split(new string[] { ")" }, StringSplitOptions.None);

                        //Convert.ToInt32(YearSem[0]).ToString();

                        //checking location Table for new data
                        con.Open();
                        String syntax4 = "SELECT count(id) FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'  and campus='" + campusComboValue + "'";
                        cmd = new SqlCommand(syntax4, con);
                        int countSessionIDs = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();


                        if (countSessionIDs == 1 && selectedItems == 2)
                        {
                            con.Open();
                            String syntax = "SELECT * FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "' and campus='" + campusComboValue + "'";
                            cmd = new SqlCommand(syntax, con);
                            dr = cmd.ExecuteReader();
                            dr.Read();

                            gotSessID = (dr[0].ToString());

                            gotSTDgrp = (dr[3].ToString());
                            gotSubject = (dr[4].ToString());
                            gotTag = (dr[2].ToString());

                           
                            gotNonoverIDConse = Convert.ToInt32(dr[13]);
                            con.Close();

                            selectedItems--;



                        }
                        else
                        {
                            con.Open();
                            String syntax = "SELECT * FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "' and campus='" + campusComboValue + "'";
                            cmd = new SqlCommand(syntax, con);
                            dr = cmd.ExecuteReader();
                            dr.Read();

                            String gotSTDgrp2 = (dr[3].ToString());
                            String gotSubject2 = (dr[4].ToString());
                            String gotTag2 = (dr[2].ToString());

                            
                            int gotNonoverIDConse2 = Convert.ToInt32(dr[13]);
                            con.Close();
                           

                            if ((gotSTDgrp == gotSTDgrp2) && (gotSubject == gotSubject2) && (gotTag != gotTag2) && ((gotNonoverIDConse != gotNonoverIDConse2) || gotNonoverIDConse==0))
                            {
                                con.Open();
                                String syntax2 = "update sessions set consecutive = '" + newConseID + "' where id ='" + Convert.ToInt32(YearSem[0]) + "' and campus='" + campusComboValue + "'";
                                cmd = new SqlCommand(syntax2, con);
                                cmd.ExecuteNonQuery();

                                con.Close();

                                con.Open();
                                String syntax3 = "update sessions set consecutive = '" + newConseID + "' where id ='" + gotSessID + "' and campus='" + campusComboValue + "'";
                                cmd = new SqlCommand(syntax3, con);
                                cmd.ExecuteNonQuery();

                                con.Close();
                                MessageBox.Show("Created Consecutive Session! ID is '" + newConseID + "'", "Message For Timetable Generator");
                                loadConsecutiveSession();
                            }
                            else
                            {
                                MessageBox.Show("Unable to create !. Student Groups or Subjects or Tag names are not Matched!", "Message For Timetable Generator");
                            }




                        }

                    }
                }
                catch (Exception ex)
                {

                    
                }
                





            }
            else
            {
                MessageBox.Show("Please.! select Two Sessions.");
            }
        }


        private void btnDeleteConsecutive_Click(object sender, EventArgs e)        //Delete Consecutive Sessions
        {
            foreach (object itemChecked in checkedListBoxCreatedConsecutiveSessions.CheckedItems)
            {
                string data = itemChecked.ToString();
                string[] YearSem = data.Split(new string[] { ")" }, StringSplitOptions.None);

                con.Open();
                String syntax4 = "SELECT count(id) FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'  and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countSessionIDs = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (countSessionIDs == 1)
                {
                    con.Open();
                    String syntax = "SELECT * FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'";
                    cmd = new SqlCommand(syntax, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    String cvc = (dr[11].ToString());
                    con.Close();




                    con.Open();
                    String syntax2 = "update sessions set consecutive = '" + 0 + "' where consecutive ='" + Convert.ToInt32(cvc) + "' and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax2, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Deleted Selected Consecutive Sessions! ");
                }
                else
                {
                    MessageBox.Show("Unable to create !.", "Message For Timetable Generator");
                }
            }

            loadConsecutiveSession();
           

            //MessageBox.Show("Deleted Selected Consecutive Sessions! ");
        }



        public int GenerateRandomNumberForParallel()        //GENERATE Parallel ID
        {
            //check parallel randomm number Avilability
            int countConsecutiveSessionNumber;

            do
            {
                Random rnd = new Random();
                GenNum = rnd.Next(10000);

                con.Open();
                String syntax = "SELECT count(id) FROM sessions WHERE parallel = '" + GenNum + "'  and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                countConsecutiveSessionNumber = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            } while (countConsecutiveSessionNumber > 0);
            return GenNum;
        }

       

        String[] gotParallelSessID = new string[10];
        String[] gotParallelTag = new string[10];
        String[] gotParallelYear = new string[10];
        int[] gotParallelDura = new int[10];

        int[] gotConseID = new int[10];
        int[] gotNonoverID = new int[10];

        private void btnCreateParallelSession_Click(object sender, EventArgs e)                             //Create parallel Session and delete Created parallel Sessions
        {


            int selectedItems = checkedListBoxCreatableParallelSessions.CheckedItems.Count;

            if (checkedListBoxCreatableParallelSessions.CheckedItems.Count <= 10 && checkedListBoxCreatableParallelSessions.CheckedItems.Count > 1)
            {

                int newParallelID = GenerateRandomNumberForParallel();

                foreach (object itemChecked in checkedListBoxCreatableParallelSessions.CheckedItems)
                {

                    string data = itemChecked.ToString();
                    string[] YearSem = data.Split(new string[] { ")" }, StringSplitOptions.None);

                    //Convert.ToInt32(YearSem[0]).ToString();

                    //checking location Table for new data
                    con.Open();
                    String syntax4 = "SELECT count(id) FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'  and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax4, con);
                    int countSessionIDs = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    if (countSessionIDs == 1 && selectedItems != 0)
                    {

                        con.Open();
                        String syntax = "SELECT * FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "' and campus='" + campusComboValue + "'";
                        cmd = new SqlCommand(syntax, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        gotParallelSessID[selectedItems] = (dr[0].ToString());

                        gotParallelTag[selectedItems] = (dr[2].ToString());

                        string data2 = (dr[3].ToString());
                        string[] Year = data2.Split(new string[] { "." }, StringSplitOptions.None);

                        gotParallelYear[selectedItems] = Year[0].ToString();

                        gotParallelDura[selectedItems] = Convert.ToInt32(dr[6]);
                        gotConseID[selectedItems] = Convert.ToInt32(dr[6]);
                        gotParallelDura[selectedItems] = Convert.ToInt32(dr[6]);

                        gotConseID[selectedItems] = Convert.ToInt32(dr[11]);
                        gotNonoverID[selectedItems] = Convert.ToInt32(dr[13]);
                        con.Close();

                        //  MessageBox.Show(gotParallelSessID[1]);
                        selectedItems--;


                    }
                    if (selectedItems == 0)
                    {
                        // MessageBox.Show(gotParallelSessID.Count(xx => xx != null).ToString());

                        bool x = true;

                        for (int amountSession = gotParallelSessID.Count(xx => xx != null); amountSession > 0; amountSession--)
                        {
                            if ((gotParallelTag[1] != gotParallelTag[amountSession]) || (gotParallelYear[1] != gotParallelYear[amountSession]) || (gotParallelDura[1] != gotParallelDura[amountSession]) || ((gotConseID[1] == gotConseID[amountSession]) && (gotConseID[1] != 0)) || ((gotNonoverID[1] == gotNonoverID[amountSession]) && (gotNonoverID[1] !=0)) )
                            {
                                x = false;
                                break;
                            }
                        }

                        if (x == true)
                        {
                            for (int amountSession = gotParallelSessID.Count(xx => xx != null); amountSession > 0; amountSession--)
                            {
                                con.Open();
                                String syntax = "update sessions set parallel = '" + newParallelID + "' where id ='" + gotParallelSessID[amountSession] + "' and campus='" + campusComboValue + "'";
                                cmd = new SqlCommand(syntax, con);
                                cmd.ExecuteNonQuery();

                                con.Close();
                            }

                           
                            MessageBox.Show("Created Parallel Session! Parallel ID is '" + newParallelID + "' ", "Message For Timetable Generator");
                        }
                        else
                        {
                            MessageBox.Show("Unable to create !. Tags and Years and Durations should be Same or Somthing went wrong !", "Message For Timetable Generator");
                        }
                    }

                }

                Array.Clear(gotParallelSessID, 0, gotParallelSessID.Length);
                Array.Clear(gotParallelTag, 0, gotParallelTag.Length);
                Array.Clear(gotParallelYear, 0, gotParallelYear.Length);
                Array.Clear(gotParallelDura, 0, gotParallelDura.Length);
                Array.Clear(gotConseID, 0, gotConseID.Length);
                Array.Clear(gotNonoverID, 0, gotNonoverID.Length);

                loadParallelSession();
                loadNonOverSession();

            }
            else
            {
                MessageBox.Show("Maximum. selectable Sessions are 10 and Min 2");
            }
        }

        private void btnDeleteParallel_Click(object sender, EventArgs e)    //Delete Parallel Sessions
        {
            try
            {
                foreach (object itemChecked in checkedListBoxCreatedParallelSessions.CheckedItems)
                {
                    string data = itemChecked.ToString();
                    string[] YearSem = data.Split(new string[] { ")" }, StringSplitOptions.None);

                    con.Open();
                    String syntax4 = "SELECT count(id) FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'  and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax4, con);
                    int countSessionIDs = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    if (countSessionIDs == 1)
                    {
                        con.Open();
                        String syntax = "SELECT * FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'";
                        cmd = new SqlCommand(syntax, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        String cvc = (dr[12].ToString());
                        con.Close();




                        con.Open();
                        String syntax2 = "update sessions set parallel = '" + 0 + "' where parallel ='" + Convert.ToInt32(cvc) + "' and campus='" + campusComboValue + "'";
                        cmd = new SqlCommand(syntax2, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        MessageBox.Show("Deleted Selected Consecutive Sessions! ");
                    }
                    else
                    {
                        MessageBox.Show("Unable to create !.", "Message For Timetable Generator");
                    }

                    loadParallelSession();

                }
            }
            catch (Exception vc)
            {

                
            }
           
        }





        public int GenerateRandomNumberForNonOverLapp()        //GENERATE Parallel ID
        {
            //check parallel randomm number Avilability
            int countConsecutiveSessionNumber;

            do
            {
                Random rnd = new Random();
                GenNum = rnd.Next(10000);

                con.Open();
                String syntax = "SELECT count(id) FROM sessions WHERE nonover = '" + GenNum + "'  and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                countConsecutiveSessionNumber = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            } while (countConsecutiveSessionNumber > 0);
            return GenNum;
        }

       
        
        
        private void btnCreateNonOverSession_Click(object sender, EventArgs e)                             //Create Non Over Session and delete Created Non Over Sessions
        {
            int selectedItems = checkedListBoxCreatableNonOverSessions.CheckedItems.Count;

            if (checkedListBoxCreatableNonOverSessions.CheckedItems.Count <= 10 && checkedListBoxCreatableNonOverSessions.CheckedItems.Count > 1)
            {

                int newParallelID = GenerateRandomNumberForNonOverLapp();

                foreach (object itemChecked in checkedListBoxCreatableNonOverSessions.CheckedItems)
                {

                    string data = itemChecked.ToString();
                    string[] YearSem = data.Split(new string[] { ")" }, StringSplitOptions.None);

                    //Convert.ToInt32(YearSem[0]).ToString();

                    //checking location Table for new data
                    con.Open();
                    String syntax4 = "SELECT count(id) FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'  and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax4, con);
                    int countSessionIDs = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    if (countSessionIDs == 1 && selectedItems != 0)
                    {

                        con.Open();
                        String syntax = "SELECT * FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "' and campus='" + campusComboValue + "'";
                        cmd = new SqlCommand(syntax, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        gotParallelSessID[selectedItems] = (dr[0].ToString());

                       

                        gotConseID[selectedItems] = Convert.ToInt32(dr[12]); //GotParallel ID
                        gotNonoverID[selectedItems] = Convert.ToInt32(dr[11]); // GotConse ID
                        con.Close();

                        //  MessageBox.Show(gotParallelSessID[1]);
                        selectedItems--;


                    }
                    if (selectedItems == 0)
                    {
                        // MessageBox.Show(gotParallelSessID.Count(xx => xx != null).ToString());

                        bool x = true;

                        for (int amountSession = gotParallelSessID.Count(xx => xx != null); amountSession > 0; amountSession--)
                        {
                            if (((gotConseID[1] == gotConseID[amountSession]) && (gotConseID[1] != 0)) || ((gotNonoverID[1] == gotNonoverID[amountSession]) && (gotNonoverID[1] != 0)) )
                            {
                                x = false;
                                break;
                            }
                        }

                        if (x == true)
                        {
                            for (int amountSession = gotParallelSessID.Count(xx => xx != null); amountSession > 0; amountSession--)
                            {
                                con.Open();
                                String syntax = "update sessions set nonover = '" + newParallelID + "' where id ='" + gotParallelSessID[amountSession] + "' and campus='" + campusComboValue + "'";
                                cmd = new SqlCommand(syntax, con);
                                cmd.ExecuteNonQuery();

                                con.Close();
                            }


                            MessageBox.Show("Created Non Overlapping Session! Non Lapping ID is '" + newParallelID + "' ", "Message For Timetable Generator");
                        }
                        else
                        {
                            MessageBox.Show("Unable to create !. You have selected Parallel Sessions.  or Somthing went wrong !", "Message For Timetable Generator");
                        }
                    }

                }

                Array.Clear(gotParallelSessID, 0, gotParallelSessID.Length);
                Array.Clear(gotParallelTag, 0, gotParallelTag.Length);
                Array.Clear(gotParallelYear, 0, gotParallelYear.Length);
                Array.Clear(gotParallelDura, 0, gotParallelDura.Length);
                Array.Clear(gotConseID, 0, gotConseID.Length);
                Array.Clear(gotNonoverID, 0, gotNonoverID.Length);

                loadParallelSession();
                loadNonOverSession();

            }
            else
            {
                MessageBox.Show("Maximum. selectable Sessions are 10 and Min 2");
            }







      
        }


        private void btnDeleteNonOver_Click(object sender, EventArgs e)  // Delete Non Over Lapping Session
        {


            foreach (object itemChecked in checkedListBoxCreatedNonOverSessions.CheckedItems)
            {
                string data = itemChecked.ToString();
                string[] YearSem = data.Split(new string[] { ")" }, StringSplitOptions.None);

                con.Open();
                String syntax4 = "SELECT count(id) FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'  and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countSessionIDs = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (countSessionIDs == 1)
                {
                    con.Open();
                    String syntax = "SELECT * FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'";
                    cmd = new SqlCommand(syntax, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    String cvc = (dr[13].ToString());
                    con.Close();

                    con.Open();
                    String syntax2 = "update sessions set nonover = '" + 0 + "' where nonover ='" + Convert.ToInt32(cvc) + "' and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax2, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Deleted Selected Consecutive Sessions! ");
                }
                else
                {
                    MessageBox.Show("Unable to create !.", "Message For Timetable Generator");
                }
            }

            loadParallelSession();
            loadNonOverSession();

        }

        


                                //Search Consecutive
        private void searchCloseBtnCreateConsecutive_Click(object sender, EventArgs e)
        {
            txtSearchBoxCreateConsecutive.Text = "";
        }

        private void txtSearchBoxCreateConsecutive_TextChanged(object sender, EventArgs e)                   //Search Creatable Consecutive Session  by Subject and Consecutive ID and Tag name
        {
            if (txtSearchBoxCreateConsecutive.Text != "")
            {


                int parsedValue;
                if (int.TryParse(txtSearchBoxCreateConsecutive.Text, out parsedValue))
                {



                    checkedListBoxCreatableConsecutiveSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup  from sessions where (id Like '" + txtSearchBoxCreateConsecutive.Text + "%' ) and campus='" + campusComboValue + "' and consecutive = '" + 0 + "' order by consecutive", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatableConsecutiveSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();
                }
                else
                {

                    checkedListBoxCreatableConsecutiveSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup from sessions where (subject Like '" + txtSearchBoxCreateConsecutive.Text + "%' or tag Like '" + txtSearchBoxCreateConsecutive.Text + "%') and campus='" + campusComboValue + "' and consecutive = '" + 0 + "' order by consecutive", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatableConsecutiveSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();

                }
            }
            else
            {
                loadConsecutiveSession();
            }


        }

        private void btnCloseConsecutiveTedSearch_Click(object sender, EventArgs e)
        {
            txtSearchBoxCreatedConsecutive.Text = "";
        }
        private void txtSearchBoxCreatedConsecutive_TextChanged(object sender, EventArgs e)                 //Search Created Consecutive Session  by Subject and Consecutive ID and Tag name
        {
            if (txtSearchBoxCreatedConsecutive.Text != "")
            {
                int parsedValue;
                if (int.TryParse(txtSearchBoxCreatedConsecutive.Text, out parsedValue))
                {
                    checkedListBoxCreatedConsecutiveSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup+ ' | Conse ID :- '+CAST(consecutive AS varchar(5))  from sessions where campus='" + campusComboValue + "' and (id Like '" + txtSearchBoxCreatedConsecutive.Text + "%') and consecutive != '" + 0 + "' order by consecutive", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatedConsecutiveSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();
                }
                else 
                {

                    checkedListBoxCreatedConsecutiveSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup+ ' | Conse ID :- '+CAST(consecutive AS varchar(5))  from sessions where campus='" + campusComboValue + "' and (subject Like '" + txtSearchBoxCreatedConsecutive.Text + "%' or tag Like '" + txtSearchBoxCreatedConsecutive.Text + "%') and consecutive != '" + 0 + "' order by consecutive", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatedConsecutiveSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();

                }
            }
            else
            {
                loadConsecutiveSession();
            }
        }

                            
                                  //Search Parallel
        private void btnCloseParallelBleSearch_Click(object sender, EventArgs e)
        {
            txtSerachParallel.Text = "";
        }

        private void txtSerachParallel_TextChanged(object sender, EventArgs e)                              //Search Creatable Parallel Session  by Subject and Consecutive ID and Tag name
        {
            if (txtSerachParallel.Text != "")
            {


                int parsedValue;
                if (int.TryParse(txtSerachParallel.Text, out parsedValue))
                {



                    checkedListBoxCreatableParallelSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup  from sessions where campus='" + campusComboValue + "' and id Like '" + txtSerachParallel.Text + "%' and parallel = '" + 0 + "'", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatableParallelSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();
                }
                else
                {

                    checkedListBoxCreatableParallelSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup+ ' | Para ID :- '+CAST(parallel AS varchar(5))  from sessions where campus='" + campusComboValue + "' and (subject Like '" + txtSerachParallel.Text + "%' or tag Like '" + txtSerachParallel.Text + "%') and parallel = '" + 0 + "'", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatableParallelSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();

                }
            }
            else
            {
                loadParallelSession();
            }
        }

        private void btnCloseParallelTedSearch_Click(object sender, EventArgs e)
        {
            txtSerachParallelCreated.Text = "";
        }

        private void txtSerachParallelCreated_TextChanged(object sender, EventArgs e)                       //Search Created Parallel Session  by Subject and Consecutive ID and Tag name
        {
            if (txtSerachParallelCreated.Text != "")
            {


                int parsedValue;
                if (int.TryParse(txtSerachParallelCreated.Text, out parsedValue))
                {



                    checkedListBoxCreatedParallelSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup  from sessions where campus='" + campusComboValue + "' and id Like '" + txtSerachParallelCreated.Text + "%' and parallel != '" + 0 + "' order by parallel", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatedParallelSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();
                }
                else
                {

                    checkedListBoxCreatedParallelSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup+ ' | Para ID :- '+CAST(parallel AS varchar(5))  from sessions where campus='" + campusComboValue + "' and (subject Like '" + txtSerachParallelCreated.Text + "%' or tag Like '" + txtSerachParallelCreated.Text + "%') and parallel != '" + 0 + "' order by parallel", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatedParallelSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();

                }
            }
            else
            {
                loadParallelSession();
            }
        }



                                    //Search Non Overlapping

        private void btnCloseNonOverBleSearch_Click(object sender, EventArgs e)
        {
            txtSearchNonOver.Text = "";
        }

        private void txtSearchNonOver_TextChanged(object sender, EventArgs e)                               //Search Creatable NON Overlapping Session  by Subject and Consecutive ID and Tag name
        {
            if (txtSearchNonOver.Text != "")
            {


                int parsedValue;
                if (int.TryParse(txtSearchNonOver.Text, out parsedValue))
                {



                    checkedListBoxCreatableNonOverSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup  from sessions where campus='" + campusComboValue + "' and id Like '" + txtSearchNonOver.Text + "%' and nonover = '" + 0 + "'", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatableNonOverSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();
                }
                else
                {

                    checkedListBoxCreatableNonOverSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup  from sessions where campus='" + campusComboValue + "' and (subject Like '" + txtSearchNonOver.Text + "%' or tag Like '" + txtSearchNonOver.Text + "%')  and nonover = '" + 0 + "'", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatableNonOverSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();

                }
            }
            else
            {
                loadNonOverSession();
            }
        }

        private void btnCloseNonOverTedSearch_Click(object sender, EventArgs e)
        {
            txtSearchNonOverCreated.Text = "";
        }

        private void txtSearchNonOverCreated_TextChanged(object sender, EventArgs e)                        //Search Creatabed NON Overlapping Session  by Subject and Consecutive ID and Tag name
        {
            if (txtSearchNonOverCreated.Text != "")
            {


                int parsedValue;
                if (int.TryParse(txtSearchNonOverCreated.Text, out parsedValue))
                {



                    checkedListBoxCreatedNonOverSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup+ ' | Non ID :- '+CAST(nonover AS varchar(5))  from sessions where campus='" + campusComboValue + "' and id Like '" + txtSearchNonOverCreated.Text + "%'  and nonover != '" + 0 + "' order by nonover", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatedNonOverSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();
                }
                else
                {

                    checkedListBoxCreatedNonOverSessions.Items.Clear();
                    con.Open();
                    SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Std Group :- '+stdgroup+ ' | Non ID :- '+CAST(nonover AS varchar(5))  from sessions where campus='" + campusComboValue + "' and (subject Like '" + txtSearchNonOverCreated.Text + "%' or tag Like '" + txtSearchNonOverCreated.Text + "%') and nonover != '" + 0 + "' order by nonover", con).ExecuteReader();

                    while (dataReadSubject.Read())
                    {
                        checkedListBoxCreatedNonOverSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                    }
                    con.Close();

                }
            }
            else
            {
                loadNonOverSession();
            }
        }


        
        ////////////////////////////////////////////////////////////////////////
        




        //////////////////////////Hasini

        public void loadComboBoxesHasini()
        {
            //Load Subject
            try
            {
                comboBoxSubjectHasini.Items.Clear();
                comboBoxSubjectHasiniPreferred.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select Subjectname from subjects where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboBoxSubjectHasini.Items.Add(dataReadSubject.GetValue(0).ToString());
                    comboBoxSubjectHasiniPreferred.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //Load Tag
            try
            {
                comboBoxTagHasini.Items.Clear();
                comboBoxTagHasiniPreferred.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select tagname from relatedtag where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboBoxTagHasini.Items.Add(dataReadSubject.GetValue(0).ToString());
                    comboBoxTagHasiniPreferred.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



            //Load Lecturer
            try
            {
                comboBoxLecturerHasini.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select lecname from lecturers where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboBoxLecturerHasini.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



            //Load Groups
            try
            {
                comboBoxGroupHasini.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) from StudentGroups where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboBoxGroupHasini.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



            //Load Session
            try
            {
                comboBoxSessionHasini.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+'/'+stdgroup+' / '+subject+' / '+lecturers  from sessions where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboBoxSessionHasini.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //Load Locations for All Hasini
            try
            {
                comboBoxLocationHasiniSubje.Items.Clear();
                comboBoxLocationHasiniTag.Items.Clear();
                comboBoxLocationHasiniLecturer.Items.Clear();
                comboBoxLocationHasiniGroup.Items.Clear();
                
                comboBoxLocationHasiniPreferred.Items.Clear();
                comboBoxLocationConsecutiveHasini.Items.Clear();

                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select dislocation from locations where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboBoxLocationHasiniSubje.Items.Add(dataReadSubject.GetValue(0).ToString());
                    comboBoxLocationHasiniTag.Items.Add(dataReadSubject.GetValue(0).ToString());
                    comboBoxLocationHasiniLecturer.Items.Add(dataReadSubject.GetValue(0).ToString());
                    comboBoxLocationHasiniGroup.Items.Add(dataReadSubject.GetValue(0).ToString());
                    
                    comboBoxLocationHasiniPreferred.Items.Add(dataReadSubject.GetValue(0).ToString());
                    comboBoxLocationConsecutiveHasini.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        

        String savedValueHasini;
        private void btnHasiSubject_Click(object sender, EventArgs e)
        {
            comboBoxSessionHasini.SelectedIndex = -1;
            if (comboBoxSubjectHasini.SelectedIndex != -1)
            {
                con.Open();
                String syntax = "SELECT locationname FROM subjects WHERE subjectname = '" + comboBoxSubjectHasini.Text + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                savedValueHasini = (dr[0].ToString());
                addNewDay = (dr[0].ToString()) + '/' + comboBoxLocationHasiniSubje.Text;

                con.Close();

            }

            if (comboBoxSubjectHasini.SelectedIndex != -1 && comboBoxLocationHasiniSubje.SelectedIndex != -1)
            {


                int count = 0;

                count = addNewDay.Count(c => c == '/');             //Can be Insert 5 Locations days

                if (count <= 5)
                {
                    con.Open();
                    String syntax2 = "update subjects set locationname = '" + addNewDay + "' where subjectname ='" + comboBoxSubjectHasini.Text + "' and campus='" + campusComboValue + "'";
                    cmd2 = new SqlCommand(syntax2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Updated Location for Subject !");
                    con.Close();

                    MessageBox.Show("Location   :- " + addNewDay + '\n', "'" + comboBoxSubjectHasini.Text + "' All Location Details");
                }
                else
                {
                    MessageBox.Show("Unable to Insert Data ! You have reached to Maximum Limit. ");

                    MessageBox.Show("Location   :- " + savedValueHasini + '\n', "'" + comboBoxSubjectHasini.Text + "' All Location Details");
                }


                
            }
            else
            {
                MessageBox.Show("Please Insert data !" + '\n' + '\n' + "Location   :- " + addNewDay + '\n', "'" + comboBoxSubjectHasini.Text + "' All Location Details");

            }
            addNewDay = "";
            savedValueHasini = "";



        }
        private void btnDeleteHasiSubject_Click(object sender, EventArgs e)
        {
            comboBoxSessionHasini.SelectedIndex = -1;
            if (comboBoxSubjectHasini.SelectedIndex != -1)
            {
                con.Open();
                String syntax2 = "update subjects set locationname='' where subjectname ='" + comboBoxSubjectHasini.Text + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax2, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Deleted Location Names!");
                con.Close();
            }
            else
            {
                MessageBox.Show("Select Lecturer to Delete!");
            }
            comboBoxSubjectHasini.SelectedIndex = -1;
            comboBoxLocationHasiniSubje.SelectedIndex = -1;

        }




        private void btnHasiTag_Click(object sender, EventArgs e)
        {
            comboBoxSessionHasini.SelectedIndex = -1;
            if (comboBoxTagHasini.SelectedIndex != -1)
            {
                con.Open();
                String syntax = "SELECT locationname FROM relatedtag WHERE tagname = '" + comboBoxTagHasini.Text + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                savedValueHasini = (dr[0].ToString());
                addNewDay = (dr[0].ToString()) + '/' + comboBoxLocationHasiniTag.Text;

                con.Close();

            }

            if (comboBoxTagHasini.SelectedIndex != -1 && comboBoxLocationHasiniTag.SelectedIndex != -1)
            {


                int count = 0;

                count = addNewDay.Count(c => c == '/');             //Can be Insert 5 Locations days

                if (count <= 5)
                {
                    con.Open();
                    String syntax2 = "update relatedtag set locationname = '" + addNewDay + "' where tagname ='" + comboBoxTagHasini.Text + "' and campus='" + campusComboValue + "'";
                    cmd2 = new SqlCommand(syntax2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Updated Location for Tag !");
                    con.Close();

                    MessageBox.Show("Location   :- " + addNewDay + '\n', "'" + comboBoxTagHasini.Text + "' All Location Details");
                }
                else
                {
                    MessageBox.Show("Unable to Insert Data ! You have reached to Maximum Limit. ");

                    MessageBox.Show("Location   :- " + savedValueHasini + '\n', "'" + comboBoxTagHasini.Text + "' All Location Details");
                }



            }
            else
            {
                MessageBox.Show("Please Insert data !" + '\n' + '\n' + "Location   :- " + addNewDay + '\n', "'" + comboBoxTagHasini.Text + "' All Location Details");

            }
            addNewDay = "";
            savedValueHasini = "";


        }
        private void btnRESETHasiTag_Click(object sender, EventArgs e)
        {
            comboBoxSessionHasini.SelectedIndex = -1;
            if (comboBoxTagHasini.SelectedIndex != -1)
            {
                con.Open();
                String syntax2 = "update relatedtag set locationname='' where tagname ='" + comboBoxTagHasini.Text + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax2, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Deleted Location Tag!");
                con.Close();
            }
            else
            {
                MessageBox.Show("Select Tag to Delete!");
            }
            comboBoxTagHasini.SelectedIndex = -1;
            comboBoxLocationHasiniTag.SelectedIndex = -1;
        }


        private void btnHasiLecturer_Click(object sender, EventArgs e)
        {
            comboBoxSessionHasini.SelectedIndex = -1;
            if (comboBoxLecturerHasini.SelectedIndex != -1)
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                try
                {
                    con.Open();
                    String syntax = "SELECT locationname FROM lecturers WHERE lecname = '" + comboBoxLecturerHasini.Text + "' and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    savedValueHasini = (dr[0].ToString());
                    addNewDay = (dr[0].ToString()) + '/' + comboBoxLocationHasiniLecturer.Text;

                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                

            }

            if (comboBoxLecturerHasini.SelectedIndex != -1 && comboBoxLocationHasiniLecturer.SelectedIndex != -1)
            {


                int count = 0;

                count = addNewDay.Count(c => c == '/');             //Can be Insert 5 Locations days

                if (count <= 5)
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    con.Open();
                    String syntax2 = "update lecturers set locationname = '" + addNewDay + "' where lecname ='" + comboBoxLecturerHasini.Text + "' and campus='" + campusComboValue + "'";
                    cmd2 = new SqlCommand(syntax2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Updated Location for Lecturer !");
                    con.Close();

                    MessageBox.Show("Location   :- " + addNewDay + '\n', "'" + comboBoxLecturerHasini.Text + "' All Location Details");
                }
                else
                {
                    MessageBox.Show("Unable to Insert Data ! You have reached to Maximum Limit. ");

                    MessageBox.Show("Location   :- " + savedValueHasini + '\n', "'" + comboBoxLecturerHasini.Text + "' All Location Details");
                }



            }
            else
            {
                MessageBox.Show("Please Insert data !" + '\n' + '\n' + "Location   :- " + addNewDay + '\n', "'" + comboBoxLecturerHasini.Text + "' All Location Details");

            }
            addNewDay = "";
            savedValueHasini = "";


        }
        private void btnRESETHasiLecturer_Click(object sender, EventArgs e)
        {
            comboBoxSessionHasini.SelectedIndex = -1;
            if (comboBoxLecturerHasini.SelectedIndex != -1)
            {
                con.Open();
                String syntax2 = "update lecturers set locationname='' where lecname ='" + comboBoxLecturerHasini.Text + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax2, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Deleted Location Lecturer!");
                con.Close();
            }
            else
            {
                MessageBox.Show("Select Tag to Delete!");
            }
            comboBoxLecturerHasini.SelectedIndex = -1;
            comboBoxLocationHasiniLecturer.SelectedIndex = -1;
        }


        private void btnHasiGroup_Click(object sender, EventArgs e)
        {
            comboBoxSessionHasini.SelectedIndex = -1;
            if (comboBoxGroupHasini.SelectedIndex != -1)
            {
                con.Open();
                String syntax = "SELECT locationname FROM studentgroups WHERE subgrp = '" + comboBoxGroupHasini.Text + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                savedValueHasini = (dr[0].ToString());
                addNewDay = (dr[0].ToString()) + '/' + comboBoxLocationHasiniGroup.Text;

                con.Close();

            }

            if (comboBoxGroupHasini.SelectedIndex != -1 && comboBoxLocationHasiniGroup.SelectedIndex != -1)
            {


                int count = 0;

                count = addNewDay.Count(c => c == '/');             //Can be Insert 5 Locations days

                if (count <= 5)
                {
                    con.Open();
                    String syntax2 = "update studentgroups set locationname = '" + addNewDay + "' where subgrp ='" + comboBoxGroupHasini.Text + "' and campus='" + campusComboValue + "'";
                    cmd2 = new SqlCommand(syntax2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Updated Location for Student Group !");
                    con.Close();

                    MessageBox.Show("Location   :- " + addNewDay + '\n', "'" + comboBoxGroupHasini.Text + "' All Location Details");
                }
                else
                {
                    MessageBox.Show("Unable to Insert Data ! You have reached to Maximum Limit. ");

                    MessageBox.Show("Location   :- " + savedValueHasini + '\n', "'" + comboBoxGroupHasini.Text + "' All Location Details");
                }



            }
            else
            {
                MessageBox.Show("Please Insert data !" + '\n' + '\n' + "Location   :- " + addNewDay + '\n', "'" + comboBoxLecturerHasini.Text + "' All Location Details");

            }
            addNewDay = "";
            savedValueHasini = "";




            
        }
        private void btnRESETHasiGroup_Click(object sender, EventArgs e)
        {
            comboBoxSessionHasini.SelectedIndex = -1;
            if (comboBoxGroupHasini.SelectedIndex != -1)
            {
                con.Open();
                String syntax2 = "update studentgroups set locationname='' where subgrp ='" + comboBoxGroupHasini.Text + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax2, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Deleted Location Lecturer!");
                con.Close();
            }
            else
            {
                MessageBox.Show("Select Tag to Delete!");
            }
            comboBoxGroupHasini.SelectedIndex = -1;
            comboBoxLocationHasiniGroup.SelectedIndex = -1;
        }


        private void btnHasiSession_Click(object sender, EventArgs e)
        {
           



            if (comboBoxSessionHasini.SelectedIndex != -1 || comboBoxLocationHasiniSession.SelectedIndex != -1)
            {


                string data = comboBoxSessionHasini.Text.ToString();
                string[] YearSem = data.Split(new string[] { "/" }, StringSplitOptions.None);

                try
                {
                    con.Open();
                    String syntax = "update sessions set LocationName = '" + comboBoxLocationHasiniSession.Text + "' where id ='" + Convert.ToInt32(YearSem[0]) + "' and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Location for The Session !");
                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Please Select Session Group and Location !");
            }
            comboBoxSessionHasini.SelectedIndex = -1;
        }


        private void btnRESETHasiSession_Click(object sender, EventArgs e)
        {
            comboBoxSessionHasini.SelectedIndex = -1;
            if (comboBoxSessionHasini.SelectedIndex != -1 )
            {


                string data = comboBoxSessionHasini.Text.ToString();
                string[] YearSem = data.Split(new string[] { "/" }, StringSplitOptions.None);

                try
                {

                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    con.Open();
                    String syntax = "update sessions set LocationName = '' where id ='" + Convert.ToInt32(YearSem[0]) + "' and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Location for The Session !");
                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Please Select Session Group to Delete !");
            }
        }


        public void loadLocationsForSessions()
        {
            string data = comboBoxSessionHasini.Text;
            string[] YearSem = data.Split(new string[] { "/" }, StringSplitOptions.None);

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            con.Open();
            String syntax = "SELECT * FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "' and campus='" + campusComboValue + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();

            String id = dr[0].ToString();
           

            string lecturers = dr[1].ToString();
            string[] lecturer = lecturers.Split(new string[] { "," }, StringSplitOptions.None);


            String tag = dr[2].ToString();
            String subject = dr[4].ToString();
            String stdgroup = dr[3].ToString();
           // MessageBox.Show(id+' '+lecturers+ ' ' + tag + ' ' + subject + ' ' + stdgroup);
            con.Close();
                                                    //Find Common Locations for lecturers
            String lecturersAllLocations="";
            String commonLocForLecturers = "";
            if (lecturer.Length >2)
            {
                try
                {
                    for (int i = 0; i < lecturer.Length - 1; i++)
                    {
                        if (cmd.Connection.State == ConnectionState.Open)
                        {
                            cmd.Connection.Close();
                        }
                        con.Open();
                        String syntax2 = "SELECT locationname FROM lecturers WHERE lecname = '" + lecturer[i] + "' and campus='" + campusComboValue + "'";
                        cmd = new SqlCommand(syntax2, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();


                        lecturersAllLocations = lecturersAllLocations + (dr[0].ToString());
                        con.Close();


                        string[] allLecturerOneByOne = lecturersAllLocations.Split(new string[] { "/" }, StringSplitOptions.None);
                        for (int y = 1; y < allLecturerOneByOne.Length; y++)
                        {
                            for (int j = y + 1; j < allLecturerOneByOne.Length; j++)
                            {
                                if (allLecturerOneByOne[y] == allLecturerOneByOne[j])
                                {
                                    commonLocForLecturers = commonLocForLecturers + allLecturerOneByOne[j];
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                con.Open();
                String syntax2 = "SELECT locationname FROM lecturers WHERE lecname = '" + lecturer[0] + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax2, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                commonLocForLecturers = (dr[0].ToString());
            }
            

            
            
           
           // MessageBox.Show("Lect : - "+commonLocForLecturers);  ////////////////////////////////////////////////////////////

            
            //Find All Locations for Subject
            String commonLocForSubject="";
            try
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                con.Open();
                String syntax3 = "SELECT locationname FROM subjects WHERE subjectname = '" + subject + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax3, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                commonLocForSubject = dr[0].ToString();

                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }





            // MessageBox.Show("Subject :- "+commonLocForSubject);  ////////////////////////////////////////////////////////////

            


            //Find All Locations for Tag
            String commonLocForTag="";
            try
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                con.Open();
                String syntax4 = "SELECT locationname FROM relatedtag WHERE tagname = '" + tag + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                commonLocForTag = dr[0].ToString();

                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }





          //  MessageBox.Show("Tag:- "+commonLocForTag);  ////////////////////////////////////////////////////////////



            //Find All Locations for Student Group
            String commonLocForStuGrp="";
            try
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                con.Open();
                String syntax5 = "SELECT locationname FROM studentgroups WHERE subgrp = '" + stdgroup + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax5, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                commonLocForStuGrp = dr[0].ToString();

                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            


            

           // MessageBox.Show("StuGroup:-  "+commonLocForStuGrp);  ////////////////////////////////////////////////////////////

            String allConsiderableLocations = commonLocForLecturers + commonLocForSubject+ commonLocForTag+ commonLocForStuGrp;

            
           // MessageBox.Show(allConsiderableLocations);

            string[] allLocrOneByOne = allConsiderableLocations.Split(new string[] { "/" }, StringSplitOptions.None);
           // string[] allLocLec = commonLocForLecturers.Split(new string[] { "/" }, StringSplitOptions.None);
           // string[] allLocSub = commonLocForSubject.Split(new string[] { "/" }, StringSplitOptions.None);
           // string[] allLocTag = commonLocForTag.Split(new string[] { "/" }, StringSplitOptions.None);
           // string[] allLocStu = commonLocForStuGrp.Split(new string[] { "/" }, StringSplitOptions.None);


            comboBoxLocationHasiniSession.Items.Clear();

           

            

            for (int y = 1; y < allLocrOneByOne.Length; y++)
            {
                for (int j = y + 1; j < allLocrOneByOne.Length; j++)
                {
                    if (allLocrOneByOne[y] == allLocrOneByOne[j])
                    {
                        if (!comboBoxLocationHasiniSession.Items.Contains(allLocrOneByOne[j].ToString()))
                        {
                            comboBoxLocationHasiniSession.Items.Add(allLocrOneByOne[j].ToString());
                        }
                    }
                }
            }



            



            /*
            for (int y = 1; y < allLocLec.Length; y++)
            {
                
                for (int j = y + 1; j < allLocLec.Length; j++)
                {
                    if (allLocLec[y] == allLocLec[j])
                    {
                        MessageBox.Show(allLocLec[y]);
                        for (int y1 = 1; y1 < allLocSub.Length; y1++)
                        {
                            for (int j1 = y1 + 1; j1 < allLocSub.Length; j1++)
                            {
                                if (allLocSub[y1] == allLocSub[j1])
                                {
                                    MessageBox.Show(allLocSub[y1]);
                                    for (int y2 = 1; y2 < allLocTag.Length; y2++)
                                    {
                                        for (int j2 = y2 + 1; j2 < allLocTag.Length; j2++)
                                        {
                                            if (allLocTag[y2] == allLocTag[j2])
                                            {
                                                MessageBox.Show(allLocTag[y2]);
                                                for (int y3 = 1; y3 < allLocStu.Length; y3++)
                                                {
                                                    for (int j3 = y3 + 1; j3 < allLocStu.Length; j3++)
                                                    {
                                                        if (allLocStu[y3] == allLocStu[j3])
                                                        {
                                                            MessageBox.Show(allLocStu[y3]);
                                                            if (!comboBoxLocationHasiniSession.Items.Contains(allLocStu[j3].ToString()))
                                                            {
                                                                comboBoxLocationHasiniSession.Items.Add(allLocStu[j3].ToString());
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            */



        }










        private void comboBoxSessionHasini_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSessionHasini.SelectedIndex != -1)
            {
                loadLocationsForSessions();
            }
        }




        //  Add Preferred Location 
        private void btnSaveHasiniPreferredLocation_Click(object sender, EventArgs e)
        {
            if (comboBoxSubjectHasiniPreferred.SelectedIndex != -1 || comboBoxTagHasiniPreferred.SelectedIndex != -1 || comboBoxLocationHasiniPreferred.SelectedIndex != -1)
            {
                con.Open();
                String synta = "select * from subjects where subjectname =  '" + comboBoxSubjectHasiniPreferred.Text + "'";
                cmd = new SqlCommand(synta, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                String subCod = (dr[1].ToString());
                con.Close();


                con.Open();
                String synt = "select * from relatedtag where tagname =  '" + comboBoxSubjectHasiniPreferred.Text + "'";
                cmd = new SqlCommand(synta, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                String tagCode = (dr[0].ToString());
                con.Close();


                con.Open();
                String syntax = "update Tags set LocationName = '" + comboBoxLocationHasiniPreferred.Text + "' where subject ='" + subCod + "' and relatedtag ='" + tagCode + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Location for The Subject and Tag !");
                con.Close();
            }
            else
            {
                MessageBox.Show("Please Select Subject , Tag and Location !");
            }
        }

        private void btnRESETHasiniPreferredLocation_Click(object sender, EventArgs e)
        {
            if (comboBoxSubjectHasiniPreferred.SelectedIndex != -1 || comboBoxTagHasiniPreferred.SelectedIndex != -1 )
            {
                con.Open();
                String synta = "select * from subjects where subjectname =  '" + comboBoxSubjectHasiniPreferred.Text + "'";
                cmd = new SqlCommand(synta, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                String subCod = (dr[1].ToString());
                con.Close();


                con.Open();
                String synt = "select * from relatedtag where tagname =  '" + comboBoxSubjectHasiniPreferred.Text + "'";
                cmd = new SqlCommand(synta, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                String tagCode = (dr[0].ToString());
                con.Close();


                con.Open();
                String syntax = "update Tags set LocationName = '' where subject ='" + subCod + "' and relatedtag ='" + tagCode + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Location  !");
                con.Close();
            }
            else
            {
                MessageBox.Show("Please Select Subject and Tag to Delete Location! !");
            }
        }






        public void loadConsecutiveSessionforHasini()           //Load Check List BOX  -Sessions-  -Time Allocation-   Consecutive
        {


            try
            {
                //checkedListBox1.Items.Remove(checkedListBox1.SelectedItem.Tostring());

                //if (cmd.Connection.State == ConnectionState.Open)
                //{
                //    cmd.Connection.Close();
                //}
                checkedListHasiniConsecutiveSessions.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Student Group :- '+stdgroup  from sessions where campus='" + campusComboValue + "' and Locconsecutive = '" + 0 + "' and locationname != ''", con).ExecuteReader();

                while (dataReadSubject.Read())
                {
                    checkedListHasiniConsecutiveSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {
                //checkedListBox1.Items.Remove(checkedListBox1.SelectedItem.Tostring());
               
                checkedListHasiniCreatedConsecutiveSessions.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Student Group :- '+stdgroup+' Location :-'+locationname from sessions where campus='" + campusComboValue + "' and Locconsecutive != '" + 0 + "'", con).ExecuteReader();

                while (dataReadSubject.Read())
                {
                    checkedListHasiniCreatedConsecutiveSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //
        }
       
        
        private void btnCreateConsecutiveLocationSessionHasini_Click(object sender, EventArgs e)
        {
            
            Random rnd = new Random();
            int num = rnd.Next(1000);

            //check consecutive randomm number Avilability
            con.Open();
            String syntax2 = "SELECT count(id) FROM sessions WHERE locconsecutive = '" + num + "'  and campus='" + campusComboValue + "'";
            cmd = new SqlCommand(syntax2, con);
            int countConsecutiveSessionNumber = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if ((checkedListHasiniConsecutiveSessions.CheckedItems.Count > 1) && comboBoxLocationConsecutiveHasini.SelectedIndex!=-1)
            {
                if (countConsecutiveSessionNumber == 0)
                {
                    foreach (object itemChecked in checkedListHasiniConsecutiveSessions.CheckedItems)
                    {

                        string data = itemChecked.ToString();
                        string[] YearSem = data.Split(new string[] { ")" }, StringSplitOptions.None);

                        //Convert.ToInt32(YearSem[0]).ToString();

                        //checking location Table for new data
                        con.Open();
                        String syntax4 = "SELECT count(id) FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'  and campus='" + campusComboValue + "'";
                        cmd = new SqlCommand(syntax4, con);
                        int countSessionIDs = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        if (countSessionIDs == 1)
                        {
                            con.Open();
                            String syntax = "update sessions set locconsecutive = '" + num + "',locationname='"+ comboBoxLocationConsecutiveHasini.Text+ "' where id ='" + Convert.ToInt32(YearSem[0]) + "' and campus='" + campusComboValue + "'";
                            cmd = new SqlCommand(syntax, con);
                            cmd.ExecuteNonQuery();

                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Unable to create !.", "Message For Timetable Generator");
                        }

                    }

                    MessageBox.Show("Created Consecutive Session! ID is '" + num + "'", "Message For Timetable Generator");
                    loadConsecutiveSession();

                }
                else
                {
                    MessageBox.Show("Please Click again!");
                }
            }
            else
            {
                MessageBox.Show("Please.! select at least Two Sessions and Select Location.");
            }
        }


        private void btndeleteHasiniSession_Click(object sender, EventArgs e)
        {
            foreach (object itemChecked in checkedListHasiniCreatedConsecutiveSessions.CheckedItems)
            {
                string data = itemChecked.ToString();
                string[] YearSem = data.Split(new string[] { ")" }, StringSplitOptions.None);

                con.Open();
                String syntax4 = "SELECT count(id) FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'  and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countSessionIDs = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (countSessionIDs == 1)
                {
                    con.Open();
                    String syntax = "SELECT * FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "'";
                    cmd = new SqlCommand(syntax, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    String cvc = (dr[15].ToString());
                    con.Close();




                    con.Open();
                    String syntax2 = "update sessions set locConsecutive = '" + 0 + "', locationname='' where locconsecutive ='" + Convert.ToInt32(cvc) + "' and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax2, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Deleted Selected Consecutive Sessions! ");
                }
                else
                {
                    MessageBox.Show("Unable to create !.", "Message For Timetable Generator");
                }
            }

            checkedListHasiniCreatedConsecutiveSessions.Items.Clear();
            con.Open();
            SqlDataReader dataReadSubject = new SqlCommand("select CAST(id AS varchar(2))+') Lecturers :- '+lecturers + ' | Subject :- ' + subject +' | Tag :- '+tag+ ' | Student Group :- '+stdgroup+' Location :-'+locationname from sessions where campus='" + campusComboValue + "' and Locconsecutive != '" + 0 + "' order by locconsecutive", con).ExecuteReader();

            while (dataReadSubject.Read())
            {
                checkedListHasiniCreatedConsecutiveSessions.Items.Add(dataReadSubject.GetValue(0).ToString());

            }
            con.Close();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadConsecutiveSessionforHasini();
        }
        
        /// /////////////////////////////////////////////////////////////////////////////////
        


        //////////////////Sumali Not Available Time
        public void loadSumaliLocationCombo()        //Load combo boxes
        {
            //Not Available Locations Load
            try
            {
                comboSumaliNotAvailableLocations.Items.Clear();
                comboSumaliLocationEdit.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select dislocation from locations where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboSumaliLocationEdit.Items.Add(dataReadSubject.GetValue(0).ToString());
                    comboSumaliNotAvailableLocations.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            //lecturer
            try
            {

                comboBoxSumaliNotLecturer.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select lecname from lecturers where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboBoxSumaliNotLecturer.Items.Add(dataReadSubject.GetValue(0).ToString());
                   
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //session id
            try
            {

                comboSumaliNotSessionID.Items.Clear();
                con.Open();
                SqlDataReader dataReadSubject = new SqlCommand("select id from sessions where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboSumaliNotSessionID.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //Group ID
            try
            {

                comboSumaliNotGroup.Items.Clear();
                con.Open();
                // SqlDataReader dataReadSubject = new SqlCommand("select year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) from StudentGroups where campus='" + campusComboValue + "'", con).ExecuteReader();
                 SqlDataReader dataReadSubject = new SqlCommand("select subgrp from StudentGroups where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataReadSubject.Read())
                {
                    comboSumaliNotGroup.Items.Add(dataReadSubject.GetValue(0).ToString());

                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSumaliLocNotAvailableSave_Click(object sender, EventArgs e)     //Save Not Available Location
        {
            if (comboSumaliNotAvailableLocations.SelectedIndex==-1 || comboSumaliNotAvaiableLocDays.SelectedIndex==-1 || UpDownSumaliStartHrs.Value==0 || UpDownSumaliEndHrs.Value==0)
            {
                MessageBox.Show("Fill boxes Correctly !");
            }
            else
            {
                con.Open();
                String syntax4 = "SELECT count(id) FROM notavailablelocations WHERE locationname = '" + comboSumaliNotAvailableLocations.Text + "' and day = '" + comboSumaliNotAvaiableLocDays.Text + "' and starthrs = '" + UpDownSumaliStartHrs.Value + "' and campus = '" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countNotAvailableLocations = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();


                if (countNotAvailableLocations == 0)
                {
                    con.Open();
                    String syntax = "Insert Into notavailablelocations values ('" + comboSumaliNotAvailableLocations.Text + "','" + comboSumaliNotAvaiableLocDays.Text + "', '" + UpDownSumaliStartHrs.Value + "' ,'" + UpDownSumaliStartMins.Value + "','" + UpDownSumaliEndHrs.Value + "','" + UpDownSumaliEndMins.Value + "','" + campusComboValue + "')";
                    cmd = new SqlCommand(syntax, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data was Saved!", "Message For Timetable Generator");
                    con.Close();

                }
                else
                {
                    MessageBox.Show("This Not Available Time has been alredy added !.", "Message For Timetable Generator");
                }
            }
        }

        private void tabControlNotAvaLocation_SelectedIndexChanged(object sender, EventArgs e)   //load Table
        {
            loadSumaliLocationCombo();
            loadSumaliTable();
        }

        public void loadSumaliTable()
        {
            SqlCommand cmd = new SqlCommand("select * from notavailablelocations where campus='" + campusComboValue + "'", con);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);

            BindingSource bsource = new BindingSource();

            bsource.DataSource = dt;

            dataGridViewNotAvailableSumali.DataSource = bsource;

            dataGridViewNotAvailableSumali.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");
            dataGridViewNotAvailableSumali.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
            dataGridViewNotAvailableSumali.EnableHeadersVisualStyles = false;
        }


        private void dataGridViewNotAvailableSumali_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                int rowindex = e.RowIndex;
                

                var loc = dataGridViewNotAvailableSumali.Rows[rowindex].Cells[1].Value;

                var day = dataGridViewNotAvailableSumali.Rows[rowindex].Cells[2].Value;

                var Sh = dataGridViewNotAvailableSumali.Rows[rowindex].Cells[3].Value;
                var Sm = dataGridViewNotAvailableSumali.Rows[rowindex].Cells[4].Value;

                var Eh = dataGridViewNotAvailableSumali.Rows[rowindex].Cells[5].Value;
                var Em = dataGridViewNotAvailableSumali.Rows[rowindex].Cells[6].Value;

                

                

                comboSumaliLocationEdit.Text = loc.ToString();
                comboSumaliDayEdit.Text = day.ToString();

                UpDownSumaliStartHrsEdit.Value = Convert.ToInt32(Sh.ToString());
                UpDownSumaliStartMinsEdit.Value = Convert.ToInt32(Sm.ToString());
                UpDownSumaliEndHrsEdit.Value = Convert.ToInt32(Eh.ToString());
                UpDownSumaliEndMinsEdit.Value = Convert.ToInt32(Em.ToString());

            }
            catch (Exception sqlx)
            {

                // throw new Exception("Problem med att sätta in namnet i ditt på inlägg/n" + sqlx.Message);
                MessageBox.Show("Please Click on a Cell or on a Row! .\n " + sqlx.Message, "Message For Timetable Generator");
            }
        }

        private void btnSubmitSumaliEdit_Click(object sender, EventArgs e)     //Update Not available location
        {
            if (comboSumaliLocationEdit.SelectedIndex!=-1)
            {
                con.Open();
                String syntax = "update notavailablelocations set day = '" + comboSumaliDayEdit.Text + "',starthrs = '" + UpDownSumaliStartHrsEdit.Value + "',startMins = '" + UpDownSumaliStartMinsEdit.Value + "',endhrs = '" + UpDownSumaliEndHrsEdit.Value + "',endMins = '" + UpDownSumaliEndMinsEdit.Value + "' where locationname ='" + comboSumaliLocationEdit.Text + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Updated Not Available Location !");
                con.Close();

                SqlCommand cmd = new SqlCommand("select * from notavailablelocations", con);

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bsource = new BindingSource();

                bsource.DataSource = dt;

                dataGridViewNotAvailableSumali.DataSource = bsource;

                dataGridViewNotAvailableSumali.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");
                dataGridViewNotAvailableSumali.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
                dataGridViewNotAvailableSumali.EnableHeadersVisualStyles = false;
            }
            else
            {
                MessageBox.Show("Please Select Location !");
            }
        }

        private void btnDeleteSumaliEdit_Click(object sender, EventArgs e)  //Delete Not Available Locations
        {
            if (comboSumaliLocationEdit.SelectedIndex != -1)
            {
                con.Open();
                String syntax = "delete from notavailablelocations where locationname ='" + comboSumaliLocationEdit.Text + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Deleted Not Available Location !");
                con.Close();

                SqlCommand cmd = new SqlCommand("select * from notavailablelocations", con);

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bsource = new BindingSource();

                bsource.DataSource = dt;

                dataGridViewNotAvailableSumali.DataSource = bsource;

                dataGridViewNotAvailableSumali.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");
                dataGridViewNotAvailableSumali.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
                dataGridViewNotAvailableSumali.EnableHeadersVisualStyles = false;
            }
            else
            {
                MessageBox.Show("Please Select Location !");
            }
        }

        private void btnSumaliLocNotAvailableReset_Click(object sender, EventArgs e)
        {
            comboSumaliNotAvailableLocations.SelectedIndex = -1;
            comboSumaliNotAvaiableLocDays.SelectedIndex = -1;
            UpDownSumaliStartHrs.Value = 0;
            UpDownSumaliStartMins.Value = 0;
            UpDownSumaliEndHrs.Value = 0;
            UpDownSumaliEndMins.Value = 0;

        }


        String addNewDay;
        String addNewStart;
        String addNewEnd;

        private void btnSumaliNotLecturer_Click(object sender, EventArgs e)         //Add not available day and time for lecturer 
        {
            if (comboBoxSumaliNotLecturer.SelectedIndex != -1)
            {
                con.Open();
                String syntax = "SELECT notday,notstart,notend FROM lecturers WHERE lecname = '" + comboBoxSumaliNotLecturer.Text + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                addNewDay = (dr[0].ToString()) + '/' + comboBoxSumaliNotLecturerDay.Text;
                addNewStart = (dr[1].ToString()) + '/' + UpDownSumaliNotLecSHrs.Value + '.' + UpDownSumaliNotLecSMin.Value;
                addNewEnd = (dr[2].ToString()) + '/' + UpDownSumaliNotLecEHrs.Value + '.' + UpDownSumaliNotLecEMin.Value;

                con.Close();
            }
            
            if (comboBoxSumaliNotLecturer.SelectedIndex != -1 && comboBoxSumaliNotLecturerDay.SelectedIndex != -1 && UpDownSumaliNotLecSHrs.Value != 0 && UpDownSumaliNotLecEHrs.Value != 0)
            {
                

                int count = 0;
               
                count = addNewDay.Count(c => c == '/');             //Can be Insert 7 Not available days

                if (count <= 7 )
                {
                    con.Open();
                    String syntax2 = "update lecturers set Notday = '" + addNewDay + "',Notstart = '" + addNewStart + "',Notend = '" + addNewEnd + "' where lecname ='" + comboBoxSumaliNotLecturer.Text + "' and campus='" + campusComboValue + "'";
                    cmd2 = new SqlCommand(syntax2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Updated Not Available Day and Time for Lecturer !");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Unable to Insert Data ! You have reached to Maximum Limit. ");
                }

                
                MessageBox.Show("Days                 :- "+addNewDay +'\n'+ "Starting Times :- "  + addNewStart + '\n'+"Ending Times  :- " + addNewEnd, "'"+comboBoxSumaliNotLecturer.Text+"' All Not Available Details");
            }
            else
            {
                MessageBox.Show("Please Insert data !"+'\n'+'\n'+"Days                 :- " + addNewDay + '\n' + "Starting Times :- " + addNewStart + '\n' + "Ending Times  :- " + addNewEnd, "'" + comboBoxSumaliNotLecturer.Text + "' All Not Available Details");
                
            }
            addNewDay = "";
            addNewStart = "";
            addNewEnd = "";
        }

        private void btnDeleteSumaliNotLecturer_Click(object sender, EventArgs e)       //Delete not avaiable day and timme for lecturer
        {
            if (comboBoxSumaliNotLecturer.SelectedIndex!=-1)
            {
                con.Open();
                String syntax2 = "update lecturers set Notday = '',Notstart = '',Notend = '' where lecname ='" + comboBoxSumaliNotLecturer.Text + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax2, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Deleted Not Available Days and Times for Lecturer !");
                con.Close();
            }
            else
            {
                MessageBox.Show("Select Lecturer !");
            }
            comboBoxSumaliNotLecturerDay.SelectedIndex = -1;
            UpDownSumaliNotLecSHrs.Value = 0;
            UpDownSumaliNotLecEHrs.Value = 0;
            UpDownSumaliNotLecSMin.Value = 0;
            UpDownSumaliNotLecEMin.Value = 0;
        }



        private void btnSaveSumaliNotSession_Click(object sender, EventArgs e)          //Add not available day and time for session
        {
            if (comboSumaliNotSessionID.SelectedIndex != -1)
            {
                con.Open();
                String syntax = "SELECT notday,notstart,notend FROM sessions WHERE id = '" + comboSumaliNotSessionID.Text + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                addNewDay = (dr[0].ToString()) + '/' + comboSumaliNotSessionIDDay.Text;
                addNewStart = (dr[1].ToString()) + '/' + UpDownSumaliNotSessionSHrs.Value + '.' + UpDownSumaliNotSessionSMin.Value;
                addNewEnd = (dr[2].ToString()) + '/' + UpDownSumaliNotSessionEHrs.Value + '.' + UpDownSumaliNotSessionEMin.Value;

                con.Close();
            }

            if (comboSumaliNotSessionID.SelectedIndex != -1 && comboSumaliNotSessionIDDay.SelectedIndex != -1 && UpDownSumaliNotSessionSHrs.Value != 0 && UpDownSumaliNotSessionEHrs.Value != 0)
            {


                int count = 0;

                count = addNewDay.Count(c => c == '/');             //Can be Insert 7 or more Not available days

                if (count <= 7)
                {
                    con.Open();
                    String syntax2 = "update sessions set Notday = '" + addNewDay + "',Notstart = '" + addNewStart + "',Notend = '" + addNewEnd + "' where id ='" + comboSumaliNotSessionID.Text + "' and campus='" + campusComboValue + "'";
                    cmd2 = new SqlCommand(syntax2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Updated Not Available Day and Time for Session !");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Unable to Insert Data ! You have reached to Maximum Limit. ");
                }


                MessageBox.Show("Days                 :- " + addNewDay + '\n' + "Starting Times :- " + addNewStart + '\n' + "Ending Times  :- " + addNewEnd, "'" + comboSumaliNotSessionID.Text + "' All Not Available Details");
            }
            else
            {
                MessageBox.Show("Please Insert data !" + '\n' + '\n' + "Days                 :- " + addNewDay + '\n' + "Starting Times :- " + addNewStart + '\n' + "Ending Times  :- " + addNewEnd, "'" + comboSumaliNotSessionID.Text + "' All Not Available Details");

            }
            addNewDay = "";
            addNewStart = "";
            addNewEnd = "";
        }

        private void btnDeleteSumaliNotSession_Click(object sender, EventArgs e)        //Delete not avaiable day and timme for Session
        {
            if (comboSumaliNotSessionID.SelectedIndex != -1)
            {
                con.Open();
                String syntax2 = "update sessions set Notday = '',Notstart = '',Notend = '' where id ='" + comboSumaliNotSessionID.Text + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax2, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Deleted Not Available Days and Times for Session !");
                con.Close();
            }
            else
            {
                MessageBox.Show("Select Lecturer !");
            }
            comboSumaliNotSessionIDDay.SelectedIndex = -1;
            UpDownSumaliNotSessionEHrs.Value = 0;
            UpDownSumaliNotSessionSHrs.Value = 0;
            UpDownSumaliNotSessionEMin.Value = 0;
            UpDownSumaliNotSessionSMin.Value = 0;
        }


        private void btnSaveSumaliNotGroup_Click(object sender, EventArgs e)        //Add not available day and time for Student Group
        {
            if (comboSumaliNotGroup.SelectedIndex != -1)
            {
                con.Open();
                String syntax = "SELECT notday,notstart,notend FROM studentgroups WHERE subgrp = '" + comboSumaliNotGroup.Text + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                addNewDay = (dr[0].ToString()) + '/' + comboSumaliNotGroupDay.Text;
                addNewStart = (dr[1].ToString()) + '/' + UpDownSumaliNotGroupSHrs.Value + '.' + UpDownSumaliNotGroupSMin.Value;
                addNewEnd = (dr[2].ToString()) + '/' + UpDownSumaliNotGroupEHrs.Value + '.' + UpDownSumaliNotGroupEMin.Value;

                con.Close();
            }

            if (comboSumaliNotGroup.SelectedIndex != -1 && comboSumaliNotGroupDay.SelectedIndex != -1 && UpDownSumaliNotGroupSHrs.Value != 0 && UpDownSumaliNotGroupEHrs.Value != 0)
            {


                int count = 0;

                count = addNewDay.Count(c => c == '/');             //Can be Insert 7 or more Not available days

                if (count <= 7)
                {
                    con.Open();
                    String syntax2 = "update studentgroups set Notday = '" + addNewDay + "',Notstart = '" + addNewStart + "',Notend = '" + addNewEnd + "' where subgrp ='" + comboSumaliNotGroup.Text + "' and campus='" + campusComboValue + "'";
                    cmd2 = new SqlCommand(syntax2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Updated Not Available Day and Time for Studnt Group !");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Unable to Insert Data ! You have reached to Maximum Limit. ");
                }


                MessageBox.Show("Days                 :- " + addNewDay + '\n' + "Starting Times :- " + addNewStart + '\n' + "Ending Times  :- " + addNewEnd, "'" + comboSumaliNotGroup.Text + "' All Not Available Details");
            }
            else
            {
                MessageBox.Show("Please Insert data !" + '\n' + '\n' + "Days                 :- " + addNewDay + '\n' + "Starting Times :- " + addNewStart + '\n' + "Ending Times  :- " + addNewEnd, "'" + comboSumaliNotGroup.Text + "' All Not Available Details");

            }
            addNewDay = "";
            addNewStart = "";
            addNewEnd = "";
        }

        private void btnDeleteSumaliNotGroup_Click(object sender, EventArgs e)         ////Delete not avaiable day and timme for Student Groups
        {
            if (comboSumaliNotGroup.SelectedIndex != -1)
            {
                con.Open();
                String syntax2 = "update studentgroups set Notday = '',Notstart = '',Notend = '' where subgrp ='" + comboSumaliNotGroup.Text + "' and campus='" + campusComboValue + "'";
                cmd2 = new SqlCommand(syntax2, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Deleted Not Available Days and Times for Student Group !");
                con.Close();
            }
            else
            {
                MessageBox.Show("Select Lecturer !");
            }
            comboSumaliNotGroupDay.SelectedIndex = -1;
            UpDownSumaliNotGroupSHrs.Value = 0;
            UpDownSumaliNotGroupEHrs.Value = 0;
            UpDownSumaliNotGroupSMin.Value = 0;
            UpDownSumaliNotGroupEMin.Value = 0;
        }
        





        private void comboBoxSumaliNotLecturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSumaliNotLecturerDay.Items.Clear();
            if (comboBoxSumaliNotLecturer.SelectedIndex!=-1)
            {
                String [] days = new String[10];
                days[0]= "Sun";days[1] = "Mon"; days[2] = "Tue"; days[3] = "Wed"; days[4] = "Thu"; days[5] = "Fri"; days[6] = "Sat";

                for (int i = 0; i < 7; i++)
                {

                    con.Open();
                    String syntax = "SELECT ["+days[i]+"] FROM lecturers WHERE lecname = '" + comboBoxSumaliNotLecturer.Text + "' and campus='" + campusComboValue + "'";
                    cmd = new SqlCommand(syntax, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    int dayHours = Convert.ToInt32( dr[0]);
                    con.Close();

                   // MessageBox.Show(depart);
                    if (dayHours!=0)
                    {
                        comboBoxSumaliNotLecturerDay.Items.Add(days[i].ToString());
                    }
                    //comboSumaliNotSessionID.Items.Add(dataReadSubject.GetValue(0).ToString());
                }
            }
        }

        private void comboSumaliNotSessionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboSumaliNotSessionIDDay.Items.Clear();
            if (comboSumaliNotSessionID.SelectedIndex!=-1)
            {
                con.Open();
                String syntax = "SELECT stdgroup FROM sessions WHERE id = '" + comboSumaliNotSessionID.Text + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                String stdGroupFromSessionTBL = (dr[0].ToString());
                con.Close();



                con.Open();
                String syntax2 = "SELECT batchtype FROM studentgroups WHERE subgrp = '" + stdGroupFromSessionTBL + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax2, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                String batchTypeFromGroupTable = (dr[0].ToString());
                con.Close();


                con.Open();
                String syntax3 = "SELECT days FROM workdayshours WHERE batchtype = '" + batchTypeFromGroupTable + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax3, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                String groupDays = (dr[0].ToString());
                con.Close();


                string data = groupDays;
                string[] batchdays = groupDays.Split(new string[] { "." }, StringSplitOptions.None);

                //MessageBox.Show( YearSem.Length.ToString());
                for (int i = 0; i < Convert.ToInt32(batchdays.Length)-1; i++)
                {
                    comboSumaliNotSessionIDDay.Items.Add(batchdays[i]);
                }
            }
        }

        private void tabControlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadConsecutiveSessionforHasini();
            loadSumaliLocationCombo();
        }

        private void comboSumaliNotGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboSumaliNotGroupDay.Items.Clear();
            if (comboSumaliNotGroup.SelectedIndex!=-1)
            {
                con.Open();
                String syntax2 = "SELECT batchtype FROM studentgroups WHERE subgrp = '" + comboSumaliNotGroup.Text + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax2, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                String batchTypeFromGroupTable = (dr[0].ToString());
                con.Close();


                con.Open();
                String syntax3 = "SELECT days FROM workdayshours WHERE batchtype = '" + batchTypeFromGroupTable + "' and campus='" + campusComboValue + "'";
                cmd = new SqlCommand(syntax3, con);
                dr = cmd.ExecuteReader();
                dr.Read();

                String groupDays = (dr[0].ToString());
                con.Close();


                string data = groupDays;
                string[] batchdays = groupDays.Split(new string[] { "." }, StringSplitOptions.None);

                //MessageBox.Show( YearSem.Length.ToString());
                for (int i = 0; i < Convert.ToInt32(batchdays.Length) - 1; i++)
                {
                    comboSumaliNotGroupDay.Items.Add(batchdays[i]);
                }
            }
        }

        











        ///////////////////////////////////////////////////////////////////////
    }
 }

