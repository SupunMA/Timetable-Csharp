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
using System.Configuration;
using System.IO;

namespace interfaces
{
    public partial class Main : Form
    {
        

        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;

        SqlDataReader dr;

        
        
        public void loadComboBox()
        {

                campusesCombo.Items.Clear();
                con.Open();
                SqlDataReader dataRead = new SqlCommand("select campusName from campus", con).ExecuteReader();
                while (dataRead.Read())
                {
                    campusesCombo.Items.Add(dataRead.GetValue(0).ToString());
                }
                con.Close();
           

        }

        public void selectCampusFromTemp() {
            con.Open();
            String syntax2 = "SELECT selectedCampus FROM TemporyData WHERE id = 1";
            cmd = new SqlCommand(syntax2, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            string tempCampus = (dr[0].ToString());
            con.Close();

            campusesCombo.Text = tempCampus;
        }
        //Add shadow to mainForm
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x25000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        ////////
        public Main()
        {
            InitializeComponent();
            loadComboBox();
            selectCampusFromTemp();

            createFolder();
            //MessageBox.Show(Environment.UserName);
        }

        public void createFolder()
        {
            
            string newFolder = "ITPM 2021 - Exported PDF";

            string path = System.IO.Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
               newFolder
            );

            if (!System.IO.Directory.Exists(path))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                catch (IOException ie)
                {
                    Console.WriteLine("IO Error: " + ie.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("General Error: " + e.Message);
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
            //clear other componenet from screen
            menu_foreColour_And_Line();
            //Dash button font colour change
            btnDash.ForeColor = System.Drawing.ColorTranslator.FromHtml("#22FF99");
            //Dash Button line
            line1.Visible = true;

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        //Draggin Code For Window
        private Point _mouseLoc;
        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLoc = e.Location;
        }

        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - _mouseLoc.X;
                int dy = e.Location.Y - _mouseLoc.Y;
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }
        ///////////////////////////

        //Minimize The Window
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
           
        }

        //Close The Window
        closeForm msgBoxForClose = new closeForm();
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.3;
            msgBoxForClose.ShowDialog();
            closeTimer.Enabled = true;
            

            /*DialogResult dialogResult = MessageBox.Show("Do you want to Exit?", "ABC Institute Timetable Generator", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }*/
            
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            if (closeForm.sendData == 1)//get Datafrom CloseForm
            {

                loadForm cloceLoadForm = new loadForm();
                cloceLoadForm.Dispose();
                closeForm closeCloseForm = new closeForm();
                closeCloseForm.Dispose();
                this.Dispose();
            }
            else if (closeForm.sendData == 2)
            {
                closeTimer.Enabled = false;
                this.Opacity = 1;
            }
            
        }
        ///////////////////////

        private void menu_foreColour_And_Line() {
            //Menu Font colour 
            btnDash.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
            btnDay.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
            btnLec.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
            btnSubj.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
            btnStu.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
            btnTag.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");
            btnLoca.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");

            //Menu Blue colour line
            line1.Visible = false;
            line2.Visible = false;
            line3.Visible = false;
            line4.Visible = false;
            line5.Visible = false;
            line6.Visible = false;
            line7.Visible = false;
            manageLine.Visible = false;
            geneLine.Visible = false;

            

            //Edit and Add buttons
            EditTagsBtn.Visible = false;
            addTagsBtn.Visible = false;

            btnAddGroups.Visible = false;
            btnEditGroups.Visible = false;

            addWorkdBtn.Visible = false;
            EditWorkingDBtn.Visible = false;

            addLecturerBtn.Visible = false;
            editLecturerBtn.Visible = false;

            addSubjectBtn.Visible = false;
            editSubjectBtn.Visible = false;

            addLocationBtn.Visible = false;
            editLocationBtn.Visible = false;

            info.Hide();
            sumaliSettings1.Hide();
            manageSessions1.Hide();
            generate1.Hide();

            supunAddTags1.Hide();
            supunEditTags1.Hide();

            supunAddStudent.Hide();
            supunEditStudent1.Hide();

            sumaliAddWorkingDaysHours1.Hide();
            sumaliEditWorkingDaysHours1.Hide();

            jayaniAddLecturers1.Hide();
            jayaniEditLecturers1.Hide();

            jayaniAddSubjects1.Hide();
            jayaniEditSubjects1.Hide();

            hasiniAddLocation1.Hide();
            hasiniEditLocations1.Hide();
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            menu_foreColour_And_Line();
            //changing font color when click on button
            btnDash.ForeColor = System.Drawing.ColorTranslator.FromHtml("#22FF99");
           
            //changing blue line when click on button
            line1.Visible = true;

            //mainPanel Showning and hiding


            mainActions();
        }

        private void btnDay_Click(object sender, EventArgs e)
        {

            menu_foreColour_And_Line();
            //changing font color when click on button
            btnDay.ForeColor = System.Drawing.ColorTranslator.FromHtml("#22FF99");
            //line
            line2.Visible = true;
            //mainPanel Showning and hiding
            sumaliAddWorkingDaysHours1.Show();
            addWorkdBtn.Visible = true;
            EditWorkingDBtn.Visible = true;
            addWorkdBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            EditWorkingDBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");

            mainActions();
        }

        private void btnLec_Click(object sender, EventArgs e)
        {
            menu_foreColour_And_Line();
            //changing font color when click on button

            
            btnLec.ForeColor = System.Drawing.ColorTranslator.FromHtml("#22FF99");
           
            line3.Visible = true;

            //mainPanel Showning and hiding
            jayaniAddLecturers1.Show();
            addLecturerBtn.Visible = true;
            editLecturerBtn.Visible = true;
            addLecturerBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            editLecturerBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");

            mainActions();
        }

        private void btnSubj_Click(object sender, EventArgs e)
        {
            menu_foreColour_And_Line();
            //changing font color when click on button

            
            btnSubj.ForeColor = System.Drawing.ColorTranslator.FromHtml("#22FF99");
           
            line4.Visible = true;

            //mainPanel Showning and hiding
            jayaniAddSubjects1.Show();
            addSubjectBtn.Visible = true;
            editSubjectBtn.Visible = true;
            addSubjectBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            editSubjectBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");

            mainActions();
        }

        private void btnStu_Click(object sender, EventArgs e)
        {
            menu_foreColour_And_Line();
            //changing font color when click on button

            btnStu.ForeColor = System.Drawing.ColorTranslator.FromHtml("#22FF99");
           
            line5.Visible = true;
           
            //mainPanel Showning and hiding
            
            supunAddStudent.Show();
            
            btnEditGroups.Visible = true;
            btnAddGroups.Visible = true;
            btnAddGroups.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            btnEditGroups.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");

            mainActions();
        }

        private void btnTag_Click(object sender, EventArgs e)
        {
            menu_foreColour_And_Line();
            //changing font color when click on button
            btnTag.ForeColor = System.Drawing.ColorTranslator.FromHtml("#22FF99");
            line6.Visible = true;
           
            //mainPanel Showning and hiding
            supunAddTags1.Show();
          
            EditTagsBtn.Visible = true;
            addTagsBtn.Visible = true;

            addTagsBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            EditTagsBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");

            mainActions();

        }

        private void btnLoca_Click(object sender, EventArgs e)
        {
            menu_foreColour_And_Line();
            //changing font color when click on button
            btnLoca.ForeColor = System.Drawing.ColorTranslator.FromHtml("#22FF99");
            line7.Visible = true;

            //mainPanel Showning and hiding
            hasiniAddLocation1.Show();
            addLocationBtn.Visible = true;
            editLocationBtn.Visible = true;

            addLocationBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            editLocationBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");

            mainActions();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        }
       
        private void btnInfo_Click(object sender, EventArgs e)
        {
            //changing font color when click on button
            menu_foreColour_And_Line();
            //mainPanel Showning and hiding
            info.Show();



            mainActions();
        }

        private void btnSett_Click(object sender, EventArgs e)
        {
            menu_foreColour_And_Line();
            //changing font color when click on button
            sumaliSettings1.Show();

            //mainPanel Showning and hiding


            mainActions();
        }

        private void btnMana_Click(object sender, EventArgs e)
        {
            //changing font color when click on button
            menu_foreColour_And_Line();
            manageSessions1.Show();
            manageLine.Visible = true;

            //mainPanel Showning and hiding

            mainActions();
        }

        private void btnGene_Click(object sender, EventArgs e)
        {
            //changing font color when click on button
            menu_foreColour_And_Line();
            generate1.Show();
            geneLine.Visible = true;
            //mainPanel Showning and hiding

            mainActions();
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCard1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void info_Load(object sender, EventArgs e)
        {

        }

        //Tags Control Buttons
        private void EditTagsBtn_Click(object sender, EventArgs e)
        {
            EditTagsBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            addTagsBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            supunEditTags1.Show();
            supunAddTags1.Hide();

            supunEditTags1.loadTable();
            supunEditTags1.loadDropDown();
        }

        private void addTagsBtn_Click(object sender, EventArgs e)
        {
            addTagsBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            EditTagsBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            supunAddTags1.Show();
            supunEditTags1.Hide();
        }

        //student Groups Control Buttons
        private void btnEditGroups_Click(object sender, EventArgs e)
        {
            btnEditGroups.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            btnAddGroups.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            supunEditStudent1.Show();
            supunAddStudent.Hide();

            supunEditStudent1.loadTable("select id as 'ID',batchtype as 'Batch Type',year+'.'+semester as 'Year and Semester',programme as 'Programme',mainid as 'Main Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2)) as 'Main Group ID',subid as 'Sub Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) as 'Main Group ID' from studentgroups  where campus = '" + this.campusesCombo.SelectedItem.ToString() + "'");
        }

        private void btnAddGroups_Click(object sender, EventArgs e)
        {
            btnAddGroups.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            btnEditGroups.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            supunAddStudent.Show();
            supunEditStudent1.Hide();
        }

        //Subjects Control Buttons
        private void addSubjectBtn_Click(object sender, EventArgs e)
        {
            addSubjectBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            editSubjectBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            jayaniAddSubjects1.Show();
            jayaniEditSubjects1.Hide();
        }
        private void editSubjectBtn_Click(object sender, EventArgs e)
        {
            editSubjectBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            addSubjectBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            jayaniAddSubjects1.Hide();
            jayaniEditSubjects1.Show();

            mainActions();
        }

        //Lecturers control Buttons
        private void addLecturerBtn_Click(object sender, EventArgs e)
        {
            addLecturerBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            editLecturerBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            jayaniAddLecturers1.Show();
            jayaniEditLecturers1.Hide();
        }

        private void editLecturerBtn_Click(object sender, EventArgs e)
        {
            editLecturerBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            addLecturerBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            jayaniAddLecturers1.Hide();
            jayaniEditLecturers1.Show();

            mainActions();
        }

        //Days control Buttons
        private void addWorkdBtn_Click(object sender, EventArgs e)
        {
            addWorkdBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            EditWorkingDBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            sumaliAddWorkingDaysHours1.Show();
            sumaliEditWorkingDaysHours1.Hide();
        }
        private void EditWorkingDBtn_Click(object sender, EventArgs e)
        {
            EditWorkingDBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            addWorkdBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            sumaliAddWorkingDaysHours1.Hide();
            sumaliEditWorkingDaysHours1.Show();

            mainActions();
        }

        //Location control Button
        private void addLocationBtn_Click(object sender, EventArgs e)
        {
            addLocationBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            editLocationBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            hasiniAddLocation1.Show();
            hasiniEditLocations1.Hide();
        }
        private void editLocationBtn_Click(object sender, EventArgs e)
        {
            editLocationBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#7e807e");
            addLocationBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E90FF");
            hasiniAddLocation1.Hide();
            hasiniEditLocations1.Show();

            mainActions();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        //
        private void supunAddTags_Load(object sender, EventArgs e)
        {

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            con.Open();
            String syntax = "update TemporyData set selectedCampus = '" + campusesCombo.SelectedItem.ToString() + "' where id = 1";
            cmd = new SqlCommand(syntax, con);
            cmd.ExecuteNonQuery();
            con.Close();

            mainActions();
            
        }

        private void campusesCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            
                
            
           
        }

        private void campusesCombo_DropDown(object sender, EventArgs e)
        {
            loadComboBox();
        }

        private void campusesCombo_Leave(object sender, EventArgs e)
        {
            selectCampusFromTemp();
        }

        public void mainActions()
        {
            //passing selcted campus name to controllers.
            //add tag
            supunAddTags1.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //edit tag
            supunEditTags1.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //add stuGroups
            supunAddStudent.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //edit stuGroups
            supunEditStudent1.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //Add workingDayss
            sumaliAddWorkingDaysHours1.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //edit workingDays
            sumaliEditWorkingDaysHours1.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //add lecturer
            jayaniAddLecturers1.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //edit lecturer
            jayaniEditLecturers1.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //add subject
            jayaniAddSubjects1.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //edit subject
            jayaniEditSubjects1.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //add location
            hasiniAddLocation1.campusComboValue = this.campusesCombo.SelectedItem.ToString();
            //edit location
            hasiniEditLocations1.campusComboValue = this.campusesCombo.SelectedItem.ToString();


            //SPRINT 2
            manageSessions1.campusComboValue = this.campusesCombo.SelectedItem.ToString();

            generate1.campusComboValue = this.campusesCombo.SelectedItem.ToString();


            //load add tags relatedtag table and loadCombobox
            supunAddTags1.loadTable("Select tagid as 'Tag ID',tagname as 'Tag Name' from RelatedTag where campus='" + this.campusesCombo.SelectedItem.ToString() + "'");
            supunAddTags1.loadComboBox();

            supunEditTags1.loadTable();
            supunEditTags1.loadDropDown();

            //load Edit student group table and loadCombobox
            supunEditStudent1.loadTable("select id as 'ID',batchtype as 'Batch Type',year+'.'+semester as 'Year and Semester',programme as 'Programme',mainid as 'Main Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2)) as 'Main Group ID',subid as 'Sub Group Number',year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) as 'Main Group ID' from studentgroups  where campus = '" + this.campusesCombo.SelectedItem.ToString() + "'");

            //settings campus load table
            sumaliSettings1.loadTable("Select id as 'Campus ID',campusName as 'Campus Name' from campus");

            //load edit workingdays
            sumaliEditWorkingDaysHours1.loadTable("select * from workDayshours where campus = '" + this.campusesCombo.SelectedItem.ToString() + "'");

            //load lecturer edit table
            jayaniEditLecturers1.loadTable("select * from lecturers where campus = '" + this.campusesCombo.SelectedItem.ToString() + "'");
            jayaniAddLecturers1.loadComboBox();
            //load subject table
            jayaniEditSubjects1.loadTable("select * from subjects where campus ='" + this.campusesCombo.SelectedItem.ToString() + "'");

            //load tables  add location
            hasiniAddLocation1.loadBuildingTable();
            hasiniAddLocation1.loadRoomTable();

            hasiniAddLocation1.loadBnameCombo();
            hasiniAddLocation1.loadRoomTypeCombo();
            hasiniAddLocation1.loadfloorCombo();

            //load table edit location
            hasiniEditLocations1.loadTable("select * from locations where campus = '" + this.campusesCombo.SelectedItem.ToString() + "'");

            //load AddSession
            manageSessions1.loadLecturerCheckLIST();
            manageSessions1.loadTagCombo();
            manageSessions1.loadTable("select id as 'Session ID',lecturers as 'Lecturers',subject as 'Subject',tag as 'Tag',stdgroup as 'Student Group',numofstudents as 'Student Amount',duration as 'Duration',locationname as 'Locations',consecutive as 'Consecutive ID',parallel as 'Parallel ID',nonover as 'Non Overlapping ID',locconsecutive as 'Location Consecutive ID',notday as 'Not Available Days' from sessions where campus = '" + this.campusesCombo.SelectedItem.ToString() + "'");
            manageSessions1.loadSumaliTable();

            //Generate Load Combo boxes
            generate1.loadComboBoxes();
        }
    }
}
