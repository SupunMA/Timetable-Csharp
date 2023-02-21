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
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace interfaces
{
    public partial class Generate : UserControl
    {
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False;MultipleActiveResultSets=true");
        SqlCommand cmd;
        SqlDataReader dr;

        public Generate()
        {
            InitializeComponent();
        }

        public void loadComboBoxes()
        {
            //Lecturer Names
            try
            {
                selectLecCombo.Items.Clear();
                con.Open();
                SqlDataReader dataRead = new SqlCommand("select lecname from lecturers where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataRead.Read())
                {
                    selectLecCombo.Items.Add(dataRead.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //Student Groups
            try
            {
                comboStdGrp.Items.Clear();
                con.Open();
                SqlDataReader dataRead = new SqlCommand("select year+'.'+semester+'.'+CAST(mainid AS varchar(2))+'.'+CAST(subid AS varchar(2)) from StudentGroups where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataRead.Read())
                {
                    comboStdGrp.Items.Add(dataRead.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //Student Location
            try
            {
                comboLocation.Items.Clear();
                con.Open();
                SqlDataReader dataRead = new SqlCommand("select dislocation from locations where campus='" + campusComboValue + "'", con).ExecuteReader();
                while (dataRead.Read())
                {
                    comboLocation.Items.Add(dataRead.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Generate_Load(object sender, EventArgs e)
        {
            loadComboBoxes();
        }

        
        string filepath;
        private void btnGenLecturer_Click(object sender, EventArgs e)       //LECTURERs
        {
            if (selectLecCombo.SelectedIndex != -1)
            {
                con.Open();
                String syntax4 = "SELECT count(id) FROM sessions WHERE lecturers!=' ' and campus = '" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countSessions = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                //  MessageBox.Show(countSessions.ToString());
                if (countSessions != 0)
                {
                    MessageBox.Show("There are No Sessions Under This Student Group!", "No Sessions To Generate!");

                }
                else
                {
                    RefreshTimeTable();
                    GenLECtable();
                }
            }
            else
            {
                MessageBox.Show("Select Lecturer To Generate Timetable!", "ABC Timetable Generator");
            }



            /*  string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
              filepath = path + "\\myfile.pdf";


             // String x = "X:\\asd.pdf";
              float myWidth = 597.6F;
              float myHeight = 842.4F;  //inches Muliply by 72
              var pgSize = new iTextSharp.text.Rectangle(myWidth, myHeight);
              Document pdc = new Document(pgSize.Rotate(), 10f, 10f, 20f, 20f);
             // Document pdc = new Document(PageSize.A4.Rotate(), 10f, 10f, 20f, 20f);



              PdfWriter pWriter = PdfWriter.GetInstance(pdc, new FileStream(filepath, FileMode.Create));

              pdc.Open();

              Paragraph p1 = new Paragraph("Suupuunn");
              pdc.Add(p1);

              pdc.Close();

              notifyIcon1.Icon = SystemIcons.Application;
              notifyIcon1.Visible = true;
              notifyIcon1.ShowBalloonTip(7000, "ABC Timetable Generator", "Generated PDF File \nClick Here to Open", ToolTipIcon.Info);

              */
            
        }


        /// ///////////////////////////////////


        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            /*ProcessStartInfo startInfo = new ProcessStartInfo(filepath);
            Process.Start(startInfo);
            */
        }
        

        private void btnSTDGenerate_Click(object sender, EventArgs e)        //STUDENT Group
        {

            if (comboStdGrp.SelectedIndex != -1)
            {
                con.Open();
                String syntax4 = "SELECT count(id) FROM sessions WHERE stdgroup='" + comboStdGrp.Text + "' and campus = '" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countSessions = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                //  MessageBox.Show(countSessions.ToString());
                if (countSessions != 0)
                {
                    MessageBox.Show("There are No Sessions Under This Student Group!", "No Sessions To Generate!");

                }
                else
                {

                    RefreshTimeTable();
                    GenSTDtable();

                    for (int i = 1; i <= countSessions; i++)
                    {
                        try
                        {

                            con.Open();
                            String syntax = "SELECT * FROM sessions WHERE locationname = '" + comboLocation.Text + "'and id='" + i + "' and campus='" + campusComboValue + "'";
                            cmd = new SqlCommand(syntax, con);
                            dr = cmd.ExecuteReader();
                            dr.Read();

                            String lecturers = (dr[1].ToString());
                            String stdgrp = (dr[3]).ToString();
                            String subANDtag = (dr[4].ToString()) + '-' + (dr[2].ToString());
                            int dura = Convert.ToInt32(dr[6]);
                            con.Close();
                            int sun = 0;
                            int mon = 0;
                            int tue = 0;
                            int wed = 0;
                            int thu = 0;
                            int fri = 0;
                            int sat = 0;
                            try
                            {
                                string[] firatLecturer = lecturers.Split(new string[] { "," }, StringSplitOptions.None);

                                con.Open();
                                String syntax2 = "SELECT * FROM lecturers WHERE lecname = '" + firatLecturer[0] + "' and campus='" + campusComboValue + "'";
                                cmd = new SqlCommand(syntax2, con);
                                dr = cmd.ExecuteReader();
                                dr.Read();

                                sun = Convert.ToInt32(dr[8]);
                                mon = Convert.ToInt32(dr[9]);
                                tue = Convert.ToInt32(dr[10]);
                                wed = Convert.ToInt32(dr[11]);
                                thu = Convert.ToInt32(dr[12]);
                                fri = Convert.ToInt32(dr[13]);
                                sat = Convert.ToInt32(dr[14]);
                                MessageBox.Show(sun.ToString() + mon.ToString() + tue.ToString() + wed.ToString() + thu.ToString() + fri.ToString() + sat.ToString() + sun.ToString());
                                con.Close();
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }

                            try
                            {
                                con.Open();
                                String syntax3 = "SELECT batchtype FROM studentgroups WHERE subgrp = '" + stdgrp + "' and campus='" + campusComboValue + "'";
                                cmd = new SqlCommand(syntax3, con);
                                dr = cmd.ExecuteReader();
                                dr.Read();
                                String batchType = dr[0].ToString();

                                con.Close();
                                if (batchType == "Week days")
                                {

                                    try
                                    {
                                        con.Open();
                                        String syntax6 = "SELECT count(id) FROM notavailablelocations WHERE locationname = '" + stdgrp + "' and campus='" + campusComboValue + "'";
                                        cmd = new SqlCommand(syntax6, con);
                                        int countNotAvailableLocations = Convert.ToInt32(cmd.ExecuteScalar());
                                        con.Close();

                                        if (countNotAvailableLocations > 0)
                                        {
                                            try
                                            {
                                                con.Open();
                                                String syntax5 = "SELECT day FROM notavailablelocations WHERE locationname = '" + stdgrp + "' and campus='" + campusComboValue + "'";
                                                cmd = new SqlCommand(syntax5, con);
                                                dr = cmd.ExecuteReader();
                                                dr.Read();
                                                dr[0].ToString();


                                                if (dr[0].ToString() != "Mon")
                                                {
                                                    if (mon >= dura)
                                                    {
                                                        MessageBox.Show("mom");
                                                    }
                                                }
                                                else if (dr[0].ToString() != "Tue")
                                                {
                                                    if (tue >= dura)
                                                    {
                                                        MessageBox.Show("mom1");
                                                    }
                                                }
                                                else if (dr[0].ToString() != "Wed")
                                                {
                                                    if (wed >= dura)
                                                    {
                                                        MessageBox.Show("mom2");
                                                    }
                                                }
                                                else if (dr[0].ToString() != "Thu")
                                                {
                                                    if (thu >= dura)
                                                    {
                                                        MessageBox.Show("mom3");
                                                    }
                                                }
                                                else if (dr[0].ToString() != "Fri")
                                                {
                                                    if (fri >= dura)
                                                    {
                                                        MessageBox.Show("mom4");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("HOi");
                                                }

                                                ////////////////////////////// Notavailable location check


                                            }
                                            catch (Exception ex)
                                            {

                                                MessageBox.Show(ex.Message);
                                            }
                                            finally
                                            {
                                                con.Close();
                                            }
                                        }
                                        else
                                        {
                                            if (mon >= dura)
                                            {



                                                con.Open();
                                                String syntax7 = "update genStudentTimeTable set monday = '" + "-" + lecturers + "\n" + "-" + stdgrp + "\n" + "-" + subANDtag + "' where id =1 ";
                                                cmd = new SqlCommand(syntax7, con);
                                                cmd.ExecuteNonQuery();

                                                con.Close();
                                            }
                                            else if (tue >= dura)
                                            {
                                                con.Open();
                                                String syntax7 = "update genStudentTimeTable set tuesday = '" + "-" + lecturers + "\n" + "-" + stdgrp + "\n" + "-" + subANDtag + "' where id =2 ";
                                                cmd = new SqlCommand(syntax7, con);
                                                cmd.ExecuteNonQuery();

                                                con.Close();
                                            }
                                            else if (wed >= dura)
                                            {
                                                con.Open();
                                                String syntax7 = "update genStudentTimeTable set wednesday = '" + "-" + lecturers + "\n" + "-" + stdgrp + "\n" + "-" + subANDtag + "' where id =3";
                                                cmd = new SqlCommand(syntax7, con);
                                                cmd.ExecuteNonQuery();

                                                con.Close();
                                            }
                                            else if (thu >= dura)
                                            {
                                                con.Open();
                                                String syntax7 = "update genStudentTimeTable set thuresday = '" + "-" + lecturers + "\n" + "-" + stdgrp + "\n" + "-" + subANDtag + "' where id =4";
                                                cmd = new SqlCommand(syntax7, con);
                                                cmd.ExecuteNonQuery();

                                                con.Close();
                                            }
                                            else if (fri >= dura)
                                            {
                                                con.Open();
                                                String syntax7 = "update genStudentTimeTable set friday = '" + "-" + lecturers + "\n" + "-" + stdgrp + "\n" + "-" + subANDtag + "' where id =5";
                                                cmd = new SqlCommand(syntax7, con);
                                                cmd.ExecuteNonQuery();

                                                con.Close();
                                            }


                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        con.Close();
                                    }














                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }


                            /*   con.Open();
                               String syntax3 = "update sessions set stdgroup = '" + comboEditAddsessionStudentGrp.Text + "',subject = '" + comboEditAddsessionSubject.Text + "',tag = '" + comboEditTagAddSession.Text + "',duration = '" + UpDownHrsEditAddSession.Value + "',numofstudents = '" + numericUpDownEditAddSessionNoStudent.Value + "' where id ='" + idJayani + "' and campus='" + campusComboValue + "'";
                               cmd2 = new SqlCommand(syntax, con);
                               cmd2.ExecuteNonQuery();
                               MessageBox.Show("Updated Session !");
                               con.Close();
                            */




                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }

                    }













                    /*

                    for (int i = 1; i < countSessions; i++)
                    {
                        con.Open();
                        String syntax = "SELECT * FROM sessions WHERE id = '" + Convert.ToInt32(YearSem[0]) + "' and campus='" + campusComboValue + "'";
                        cmd = new SqlCommand(syntax, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        MessageBox.Show(dr[0].ToString());
                        con.Close();


                        con.Open();
                        String syntax2 = "insert into genStudentTimeTable(time,monday) values('8.30','ITPM - Amal - MB.14.LB.A01')";
                        cmd = new SqlCommand(syntax2, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated Session !");
                        con.Close();
                    }
                    
                    */

                }


            }
            else
            {
                MessageBox.Show("Select Student Group To Generate Timetable!", "ABC Timetable Generator");
            }




        }



        private void GenSTDtable()              //Show Table Student Group
        {

            dataGridView2.RowTemplate.Height = 100;

            SqlCommand cmd = new SqlCommand("Select time as 'Time',monday as 'Monday',tuesday as 'Tuesday',wednesday as 'Wednesday',thuresday as 'Thuresday',friday as 'Friday',saturday as 'Saturday',sunday as 'Sunday' from genStudentTimeTable", con);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);

            BindingSource bsource = new BindingSource();

            bsource.DataSource = dt;

            dataGridView2.DataSource = bsource;




            dataGridView2.Columns[0].Width = 80;// The Time column 


            dataGridView2.Columns[1].Width = 150;//Monday
            dataGridView2.Columns[2].Width = 150;
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Width = 150;
            dataGridView2.Columns[6].Width = 150;
            dataGridView2.Columns[7].Width = 150;//Sunday




            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");//HeaderBackGroundColor
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");//HeaderFontGroundColor
            dataGridView2.EnableHeadersVisualStyles = false;
        }

        private void GenLECtable()              //Show Table Lecturer
        {

            dataGridView1.RowTemplate.Height = 100;

            SqlCommand cmd = new SqlCommand("Select time as 'Time',monday as 'Monday',tuesday as 'Tuesday',wednesday as 'Wednesday',thuresday as 'Thuresday',friday as 'Friday',saturday as 'Saturday',sunday as 'Sunday' from genStudentTimeTable", con);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);

            BindingSource bsource = new BindingSource();

            bsource.DataSource = dt;

            dataGridView1.DataSource = bsource;




            dataGridView1.Columns[0].Width = 80;// The Time column 


            dataGridView1.Columns[1].Width = 150;//Monday
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 150;//Sunday




            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");//HeaderBackGroundColor
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");//HeaderFontGroundColor
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void GenLOCATIONtable()         //Show Table Location
        {

            dataGridView3.RowTemplate.Height = 100;

            SqlCommand cmd = new SqlCommand("Select time as 'Time',monday as 'Monday',tuesday as 'Tuesday',wednesday as 'Wednesday',thuresday as 'Thuresday',friday as 'Friday',saturday as 'Saturday',sunday as 'Sunday' from genStudentTimeTable", con);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);

            BindingSource bsource = new BindingSource();

            bsource.DataSource = dt;

            dataGridView3.DataSource = bsource;




            dataGridView3.Columns[0].Width = 80;// The Time column 


            dataGridView3.Columns[1].Width = 150;//Monday
            dataGridView3.Columns[2].Width = 150;
            dataGridView3.Columns[3].Width = 150;
            dataGridView3.Columns[4].Width = 150;
            dataGridView3.Columns[5].Width = 150;
            dataGridView3.Columns[6].Width = 150;
            dataGridView3.Columns[7].Width = 150;//Sunday




            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("22, 39, 71");//HeaderBackGroundColor
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f8f8ff");//HeaderFontGroundColor
            dataGridView3.EnableHeadersVisualStyles = false;
        }

        private void RefreshTimeTable()         //REFRESH TABLES
        {
            con.Open();
            String syntax5 = "delete from genStudentTimeTable";
            cmd = new SqlCommand(syntax5, con);
            cmd.ExecuteNonQuery();

            con.Close();


            int hours = 11;
            int i = 1;

            for (float y = 8.30F; i <= hours; y++)
            {

                con.Open();
                String syntax2 = "insert into genStudentTimeTable(time) values('" + y + "'+'0')";
                cmd = new SqlCommand(syntax2, con);
                cmd.ExecuteNonQuery();
                // MessageBox.Show("Updated Session !");
                con.Close();
                i++;

            }
        }
        
        private void btnLocationGenerate_Click(object sender, EventArgs e)       //Button Generate Location
        {
            if (comboLocation.SelectedIndex != -1)
            {
                con.Open();
                String syntax4 = "SELECT count(id) FROM sessions WHERE locationname='" + comboLocation.Text + "' and campus = '" + campusComboValue + "'";
                cmd = new SqlCommand(syntax4, con);
                int countSessions = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                //  MessageBox.Show(countSessions.ToString());
                if (countSessions == 0)
                {
                    MessageBox.Show("There are No Sessions Under This Student Group!", "No Sessions To Generate!");

                }
                else
                {

                    RefreshTimeTable();
                    GenLOCATIONtable();
                    for (int i = 1; i <= countSessions; i++)
                    {
                        try
                        {

                            con.Open();
                            String syntax = "SELECT * FROM sessions WHERE locationname = '" + comboLocation.Text + "'and id='" + i + "' and campus='" + campusComboValue + "'";
                            cmd = new SqlCommand(syntax, con);
                            dr = cmd.ExecuteReader();
                            dr.Read();

                            String lecturers = (dr[1].ToString());
                            String stdgrp = (dr[3]).ToString();
                            String subANDtag = (dr[4].ToString())+'-'+(dr[2].ToString());
                            int dura = Convert.ToInt32(dr[6]);
                            con.Close();
                            int sun=0;
                            int mon=0;
                            int tue=0;
                            int wed=0;
                            int thu=0;
                            int fri=0;
                            int sat=0;
                            try
                            {
                                string[] firatLecturer = lecturers.Split(new string[] { "," }, StringSplitOptions.None);

                                con.Open();
                                String syntax2 = "SELECT * FROM lecturers WHERE lecname = '" + firatLecturer[0] + "' and campus='" + campusComboValue + "'";
                                cmd = new SqlCommand(syntax2, con);
                                dr = cmd.ExecuteReader();
                                dr.Read();

                                sun = Convert.ToInt32(dr[8]);
                                mon = Convert.ToInt32(dr[9]);
                               tue = Convert.ToInt32(dr[10]);
                                wed = Convert.ToInt32(dr[11]);
                                thu = Convert.ToInt32(dr[12]);
                                fri = Convert.ToInt32(dr[13]);
                                sat = Convert.ToInt32(dr[14]);
                                MessageBox.Show(sun.ToString() + mon.ToString() + tue.ToString() + wed.ToString() + thu.ToString() + fri.ToString() + sat.ToString() + sun.ToString());
                                con.Close();
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }

                            try
                            {
                                con.Open();
                                String syntax3 = "SELECT batchtype FROM studentgroups WHERE subgrp = '" + stdgrp + "' and campus='" + campusComboValue + "'";
                                cmd = new SqlCommand(syntax3, con);
                                dr = cmd.ExecuteReader();
                                dr.Read();
                                String batchType=dr[0].ToString();

                                con.Close();
                                if (batchType == "Week days")
                                {

                                    try
                                    {
                                        con.Open();
                                        String syntax6 = "SELECT count(id) FROM notavailablelocations WHERE locationname = '" + stdgrp + "' and campus='" + campusComboValue + "'";
                                        cmd = new SqlCommand(syntax6, con);
                                        int countNotAvailableLocations = Convert.ToInt32(cmd.ExecuteScalar());
                                        con.Close();

                                        if (countNotAvailableLocations > 0)
                                        {
                                            try
                                            {
                                                con.Open();
                                                String syntax5 = "SELECT day FROM notavailablelocations WHERE locationname = '" + stdgrp + "' and campus='" + campusComboValue + "'";
                                                cmd = new SqlCommand(syntax5, con);
                                                dr = cmd.ExecuteReader();
                                                dr.Read();
                                                dr[0].ToString();


                                                if (dr[0].ToString() != "Mon")
                                                {
                                                    if (mon >= dura)
                                                    {
                                                        MessageBox.Show("mom");
                                                    }
                                                }
                                                else if (dr[0].ToString() != "Tue")
                                                {
                                                    if (tue >= dura)
                                                    {
                                                        MessageBox.Show("mom1");
                                                    }
                                                }
                                                else if (dr[0].ToString() != "Wed")
                                                {
                                                    if (wed >= dura)
                                                    {
                                                        MessageBox.Show("mom2");
                                                    }
                                                }
                                                else if (dr[0].ToString() != "Thu")
                                                {
                                                    if (thu >= dura)
                                                    {
                                                        MessageBox.Show("mom3");
                                                    }
                                                }
                                                else if (dr[0].ToString() != "Fri")
                                                {
                                                    if (fri >= dura)
                                                    {
                                                        MessageBox.Show("mom4");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("HOi");
                                                }

                                                ////////////////////////////// Notavailable location check


                                            }
                                            catch (Exception ex)
                                            {

                                                MessageBox.Show(ex.Message);
                                            }
                                            finally
                                            {
                                                con.Close();
                                            }
                                        }
                                        else
                                        {
                                            if (mon >= dura)
                                            {



                                                con.Open();
                                                String syntax7 = "update genStudentTimeTable set monday = '"+"-"+lecturers+"\n" + "-" + stdgrp + "\n" + "-" + subANDtag + "' where id =1 ";
                                                cmd = new SqlCommand(syntax7, con);
                                                cmd.ExecuteNonQuery();
                                               
                                                con.Close();
                                            }
                                            else if (tue >= dura)
                                            {
                                                con.Open();
                                                String syntax7 = "update genStudentTimeTable set tuesday = '" + "-" + lecturers + "\n" + "-" + stdgrp + "\n" + "-" + subANDtag + "' where id =2 ";
                                                cmd = new SqlCommand(syntax7, con);
                                                cmd.ExecuteNonQuery();

                                                con.Close();
                                            }
                                            else if (wed >= dura)
                                            {
                                                con.Open();
                                                String syntax7 = "update genStudentTimeTable set wednesday = '" + "-" + lecturers + "\n" + "-" + stdgrp + "\n" + "-" + subANDtag + "' where id =3";
                                                cmd = new SqlCommand(syntax7, con);
                                                cmd.ExecuteNonQuery();

                                                con.Close();
                                            }
                                            else if (thu >= dura)
                                            {
                                                con.Open();
                                                String syntax7 = "update genStudentTimeTable set thuresday = '" + "-" + lecturers + "\n" + "-" + stdgrp + "\n" + "-" + subANDtag + "' where id =4";
                                                cmd = new SqlCommand(syntax7, con);
                                                cmd.ExecuteNonQuery();

                                                con.Close();
                                            }
                                            else if (fri >= dura)
                                            {
                                                con.Open();
                                                String syntax7 = "update genStudentTimeTable set friday = '" + "-" + lecturers + "\n" + "-" + stdgrp + "\n" + "-" + subANDtag + "' where id =5";
                                                cmd = new SqlCommand(syntax7, con);
                                                cmd.ExecuteNonQuery();

                                                con.Close();
                                            }


                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        con.Close();
                                    }














                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }


                            /*   con.Open();
                               String syntax3 = "update sessions set stdgroup = '" + comboEditAddsessionStudentGrp.Text + "',subject = '" + comboEditAddsessionSubject.Text + "',tag = '" + comboEditTagAddSession.Text + "',duration = '" + UpDownHrsEditAddSession.Value + "',numofstudents = '" + numericUpDownEditAddSessionNoStudent.Value + "' where id ='" + idJayani + "' and campus='" + campusComboValue + "'";
                               cmd2 = new SqlCommand(syntax, con);
                               cmd2.ExecuteNonQuery();
                               MessageBox.Show("Updated Session !");
                               con.Close();
                            */




                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                        
                    }
                    



                }
            }
            else
            {
                MessageBox.Show("Select Location To Generate Timetable!","ABC Timetable Generator");
            }

            GenLOCATIONtable();
        }

        
        
        
        
        private void btnSTDpdf_Click(object sender, EventArgs e)            //STD PDF EXPORT
        {
            if (dataGridView2.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "STD_GROUP-'" + comboStdGrp.Text + "'.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to write data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dataGridView2.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_CENTER;

                            foreach (DataGridViewColumn col in dataGridView2.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in dataGridView2.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4.Rotate(), 8f, 16f, 16f, 8f);
                                Paragraph p1 = new Paragraph();
                                
                                PdfWriter.GetInstance(document, fileStream);
                                /* Chunk chunk = new Chunk("Setting the Font", FontFactory.GetFont("dax-black"));

                                 chunk.SetUnderline(0.5f, -1.5f);  */
                                Chunk underline = new Chunk("Timetable For Student Group:- '" + comboStdGrp.Text + "'");
                                underline.SetUnderline(0.1f, -2f); //0.1 thick, -2 y-location
                                
                                Phrase phrase = new Phrase();
                                phrase.Add(underline);
                               

                                Paragraph para = new Paragraph();
                                para.Add(phrase);
                                para.Alignment=Element.ALIGN_CENTER;
                               

                                document.Open();

                                document.Add(para);
                                document.Add(new Paragraph(" "));
                                document.Add(pTable);
                                document.Add(new Paragraph("Generated:- " + DateTime.Now.ToString("yyyy - MM - dd")));
                                document.Close();

                                fileStream.Close();

                            }

                            //MessageBox.Show("Data Export Successfully", "info");
                            notifyIcon1.Icon = SystemIcons.Application;
                            notifyIcon1.Visible = true;
                            notifyIcon1.ShowBalloonTip(7000, "ABC Timetable Generator", "Generated PDF File \nfor '" + comboStdGrp.Text + "'", ToolTipIcon.Info);

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }

        private void btnPDFlecturerClick(object sender, EventArgs e)            //LECTURER PDF EXPORT
        {
            if (dataGridView1.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "LECTURER-'" + selectLecCombo.Text + "'.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to write data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_CENTER;

                            foreach (DataGridViewColumn col in dataGridView1.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4.Rotate(), 8f, 16f, 16f, 8f);
                                Paragraph p1 = new Paragraph();

                                PdfWriter.GetInstance(document, fileStream);
                                /* Chunk chunk = new Chunk("Setting the Font", FontFactory.GetFont("dax-black"));

                                 chunk.SetUnderline(0.5f, -1.5f);  */
                                Chunk underline = new Chunk("Timetable For LECTURER:- '" + selectLecCombo.Text + "'");
                                underline.SetUnderline(0.1f, -2f); //0.1 thick, -2 y-location

                                Phrase phrase = new Phrase();
                                phrase.Add(underline);


                                Paragraph para = new Paragraph();
                                para.Add(phrase);
                                para.Alignment = Element.ALIGN_CENTER;


                                document.Open();

                                document.Add(para);
                                document.Add(new Paragraph(" "));
                                document.Add(pTable);
                                document.Add(new Paragraph("Generated:- " + DateTime.Now.ToString("yyyy - MM - dd")));
                                document.Close();

                                fileStream.Close();

                            }

                            notifyIcon1.Icon = SystemIcons.Application;
                            notifyIcon1.Visible = true;
                            notifyIcon1.ShowBalloonTip(7000, "ABC Timetable Generator", "Generated PDF File \nfor '" + selectLecCombo.Text + "'", ToolTipIcon.Info);

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }

        private void btnPDFlocation_Click(object sender, EventArgs e)           //LOCATION PDF EXPORT
        {
            if (dataGridView3.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "LOCATION-'" + comboLocation.Text + "'.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to write data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dataGridView3.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_CENTER;

                            foreach (DataGridViewColumn col in dataGridView3.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in dataGridView3.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4.Rotate(), 8f, 16f, 16f, 8f);
                                Paragraph p1 = new Paragraph();

                                PdfWriter.GetInstance(document, fileStream);
                                /* Chunk chunk = new Chunk("Setting the Font", FontFactory.GetFont("dax-black"));

                                 chunk.SetUnderline(0.5f, -1.5f);  */
                                Chunk underline = new Chunk("Timetable For Location:- '" + comboLocation.Text + "'");
                                underline.SetUnderline(0.1f, -2f); //0.1 thick, -2 y-location

                                Phrase phrase = new Phrase();
                                phrase.Add(underline);


                                Paragraph para = new Paragraph();
                                para.Add(phrase);
                                para.Alignment = Element.ALIGN_CENTER;


                                document.Open();

                                document.Add(para);
                                document.Add(new Paragraph(" "));
                                document.Add(pTable);
                                document.Add(new Paragraph("Generated:- " + DateTime.Now.ToString("yyyy - MM - dd")));
                                document.Close();

                                fileStream.Close();

                            }

                            notifyIcon1.Icon = SystemIcons.Application;
                            notifyIcon1.Visible = true;
                            notifyIcon1.ShowBalloonTip(7000, "ABC Timetable Generator", "Generated PDF File \nfor '" + comboLocation.Text + "'", ToolTipIcon.Info);


                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }
    }
}
