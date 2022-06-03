using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Threading;
using System.IO;


namespace PROG___Task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //classes are declared into main window
        Module myModule = new Module();
        Working myWorking = new Working();
        Semester mySemester = new Semester();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=ravjee;Initial Catalog=Time_Management_App;Integrated Security=True");

                //class values are populated by textboxes
                myModule.ID = txtStudent_ID.Text;
                myModule.Code = txtModuleCode.Text;
                myModule.Name = txtModuleName.Text;
                myModule.Credits = double.Parse(txtCredits.Text);
                myModule.HoursWeekly = double.Parse(txtClassHours.Text);

                con.Open();

                //sql command used to input moule information
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Modules]
                                                            ([Student_ID]
                                                           ,[Module_Code]
                                                           ,[Module_Name]
                                                        ,[Module_Credits]
                                                     ,[Module_ClassHours])
                                   VALUES('" + txtStudent_ID.Text + "', '" + myModule.Code + "','" + myModule.Name + "'," +
                                                myModule.Credits + "," + myModule.HoursWeekly + ");", con);

                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Module Information Recorded successfully");
            }
            catch(Exception)
            {
                MessageBox.Show("Missing or Incorrect Values");
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=ravjee;Initial Catalog=Time_Management_App;Integrated Security=True");

                //class values are populated using textbox values
                myWorking.WorkingModuleCode = txtWorkingModuleCode.Text;
                myWorking.HoursWorked = double.Parse(txtHoursSpent.Text);
                myWorking.DateWorking = dpWorking.Text;

                con.Open();

                //sql command used to insert working hours
                SqlCommand cmd2 = new SqlCommand(@"INSERT INTO [dbo].[Working]
                                                          ([Working_Hours]
                                                            ,[Module_Code]
                                                           ,[Working_Date]
                                                             ,[Student_ID])
                                VALUES(" + myWorking.HoursWorked + ", '" + txtWorkingModuleCode.Text + "', '" +
                                               myWorking.DateWorking + "', '" + txtStudent_ID.Text + "');", con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                con.Close();

                MessageBox.Show("Hours Worked Recorded successfully");
            }
            catch(Exception)
            {
                MessageBox.Show("Missing or Incorrect Values");
            }

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //class values are populated using textbox values
                mySemester.DateSemester = dpSemester.Text;
                mySemester.NumWeeks = double.Parse(txtNumWeeks.Text);

                SqlConnection con = new SqlConnection("Data Source=ravjee;Initial Catalog=Time_Management_App;Integrated Security=True");

                con.Open();

                //SQL command used to input semester info like start date and number of weeks
                SqlCommand cmd3 = new SqlCommand(@"INSERT INTO [dbo].[Semester]
                                                                  ([Student_ID]
                                                           ,[Semester_NumWeeks]
                                                          ,[Semester_StartDate])
                                        VALUES('" + txtStudent_ID.Text + "', " + mySemester.NumWeeks + ", '" +
                                                    mySemester.DateSemester + "');", con);
                SqlDataReader dr3 = cmd3.ExecuteReader();
                con.Close();
                MessageBox.Show("Semester Information Correctly Recorded");
            }
            catch(Exception)
            {
                MessageBox.Show("Missing or Incorrect Input");
            }
            
        }

        //used to display remaining ours to work
        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            View view = new View();
            view.Show();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //try statement to tell user if a value has not been inputted
            try
            {
                // try statement to tell user if the file cannot be written
                try
                {

                    SqlConnection con = new SqlConnection("Data Source=ravjee;Initial Catalog=Time_Management_App;Integrated Security=True");

                    con.Open();

                    //SQL command used to display values as well as do calculations
                    SqlCommand cmd4 = new SqlCommand(@"SELECT Login.Student_ID, Modules.Module_Name, Modules.Module_Code, Modules.Module_Credits, Semester.Semester_StartDate, 
                                             Semester.Semester_NumWeeks, Working.Working_Date, Working.Working_Hours, 
			                                (Modules.Module_Credits * 10 / Semester.Semester_NumWeeks - Modules.Module_ClassHours) AS Self_Study_Hours_Per_Week
	                                                FROM Login
	                                                INNER JOIN Modules ON Modules.Student_ID = Login.Student_ID
	                                                INNER JOIN Semester ON Semester.Student_ID = Login.Student_ID
	                                                INNER JOIN Working ON Working.Module_Code = Modules.Module_Code
		                                                WHERE Login.Student_ID = '" + txtStudent_ID.Text + "';", con);

                    SqlDataReader dt4 = cmd4.ExecuteReader();

                    //destination to save file
                    //please enter save destination before starting the program
                    StreamWriter tw = new StreamWriter(@"C:\Users\prash\OneDrive\Desktop\Prashil\SaveFile.txt");

                    //what will be written in the file
                    tw.Write(dt4);
                    tw.Close();

                    con.Close();

                    MessageBox.Show("File has successfully been written");
                }
                //catch expception to display what went wrong
                catch (Exception)
                {
                    MessageBox.Show("Unable to Save to file" +
                                    "\nReason - Access Denied from System Firewall");
                }
            }
            //catch statment to tell user what is wrong
            catch (Exception)
            {
                MessageBox.Show("Please enter a value in all fields" +
                                "\nNo Special characters are allowed");
            }
        }

        //used to clear textboxes
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtClassHours.Clear();
            txtCredits.Clear();
            txtHoursSpent.Clear();
            txtModuleCode.Clear();
            txtModuleName.Clear();
            txtStudent_ID.Clear();
            txtWorkingModuleCode.Clear();
            txtNumWeeks.Clear();
        }

        //multithreading used 
        private void MultiThread()
        {
            Thread.Sleep(2000);
        }
    }
}
