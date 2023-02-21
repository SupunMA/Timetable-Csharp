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
    public partial class SumaliAddWorkingDaysHours : UserControl
    {
        public String campusComboValue;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Asynchronous Processing=True;User Instance=False;Context Connection=False");
        SqlCommand cmd;

        SqlDataReader dr;
        public SumaliAddWorkingDaysHours()
        {
            InitializeComponent();
        }



         private void btnSave_Click(object sender, EventArgs e)
         {
             if (upDownWorkinDays.Text != "" && (radioWeek.Checked  || radioWeekend.Checked) && (checkSun.Checked || checkMon.Checked || checkTues.Checked || checkWed.Checked || checkThurs.Checked || checkFrid.Checked || checkSat.Checked) && (UpDownWorkingHours.Value!=0 || UpDownWorkingMinutes.Value!=0) && (UpDownIntervalHours.Value!=0 || UpDownIntervalMinutes.Value!=0) )
             {
                int wDays = Convert.ToInt32(upDownWorkinDays.Value);
                int wHours = Convert.ToInt32(UpDownWorkingHours.Value);
                int wMinutes = Convert.ToInt32(UpDownWorkingMinutes.Value);
                int wIh = Convert.ToInt32(UpDownIntervalHours.Value);
                int wIm = Convert.ToInt32(UpDownIntervalMinutes.Value);

                
                if (radioWeek.Checked)
               {
                   //checking workDaysHours Table for new 
                   con.Open();
                   String syntax4 = "SELECT count(BatchType) FROM workDaysHours WHERE BatchType = 'week days'";
                   cmd = new SqlCommand(syntax4, con);
                   int countBatchType = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    selectDays();
                    if (countBatchType == 0)
                    {
                        con.Open();
                        String syntax = "Insert Into workDayshours values ('week days','" + wDays + "', '"+ dayCollection +"' ,'"+ wHours + "','" + wMinutes+ "','" + wIh + "','" + wIm + "','" + campusComboValue + "')";
                        cmd = new SqlCommand(syntax, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data was Saved!", "Message For Timetable Generator");
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Batch Type has been alredy added !. If you want to Edit Click on 'Edit Days' button.", "Message For Timetable Generator");
                    }
                   
                }



                if (radioWeekend.Checked)
                {
                    //checking workDaysHours Table for new 
                    con.Open();
                    String syntax4 = "SELECT count(BatchType) FROM workDaysHours WHERE BatchType = 'weekend days'";
                    cmd = new SqlCommand(syntax4, con);
                    int countBatchType = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    selectDays();

                    if (countBatchType == 0)
                    {
                        try
                        {
                            con.Open();
                            String syntax = "Insert Into workDayshours values ('weekend days','" + wDays + "', '" + dayCollection + "' ,'" + wHours + "','" + wMinutes + "','" + wIh + "','" + wIm + "','" + campusComboValue + "')";
                            cmd = new SqlCommand(syntax, con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data was Saved!", "Message For Timetable Generator");
                            con.Close();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                        

                    }
                    else
                    {
                        MessageBox.Show("Batch Type has been alredy added !.  If you want to Edit Click on 'Edit Days' button.", "Message For Timetable Generator");
                    }

                }



             }
             else
             {
                 MessageBox.Show("Please fill the Textboxes correctly!", "Message For Timetable Generator");
             }
       
  
         }

        public String dayCollection;
        private void selectDays()
        {
            if (checkMon.Checked)
            {
                dayCollection = dayCollection + "Mon.";
            }
            if (checkTues.Checked)
            {
                dayCollection = dayCollection + "Tue.";
            }
            if (checkWed.Checked)
            {
                dayCollection = dayCollection + "Wed.";
            }
            if (checkThurs.Checked)
            {
                dayCollection = dayCollection + "Thu.";
            }
            if (checkFrid.Checked)
            {
                dayCollection = dayCollection + "Fri.";
            }
            if (checkSat.Checked)
            {
                dayCollection = dayCollection + "Sat.";
            }
            if (checkSun.Checked)
            {
                dayCollection = dayCollection + "Sun.";
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            radioWeek.Checked = false;
            radioWeekend.Checked = false;
            upDownWorkinDays.Value = 0;
            UpDownIntervalHours.Value = 0;
            UpDownIntervalMinutes.Value = 0;
            UpDownWorkingHours.Value = 0;
            UpDownWorkingMinutes.Value = 0;

            checkFrid.Checked = false;
            checkMon.Checked = false;
            checkSat.Checked = false;
            checkSun.Checked = false;
            checkThurs.Checked = false;
            checkTues.Checked = false;
            checkWed.Checked = false;

        }
    }
}
