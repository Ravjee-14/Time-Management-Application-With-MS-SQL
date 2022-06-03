using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace PROG___Task_2
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            InitializeComponent();
        }
        

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection("Data Source=ravjee;Initial Catalog=Time_Management_App;Integrated Security=True");

                con.Open();

                //SQL command used to display values as well as do calculations
                SqlCommand cmd = new SqlCommand(@"SELECT Login.Student_ID, Modules.Module_Name, Modules.Module_Code, Modules.Module_Credits, Semester.Semester_StartDate, 
                                             Semester.Semester_NumWeeks, Working.Working_Date, Working.Working_Hours, 
			                                (Modules.Module_Credits * 10 / Semester.Semester_NumWeeks - Modules.Module_ClassHours) AS Self_Study_Hours_Per_Week
	                                                FROM Login
	                                                INNER JOIN Modules ON Modules.Student_ID = Login.Student_ID
	                                                INNER JOIN Semester ON Semester.Student_ID = Login.Student_ID
	                                                INNER JOIN Working ON Working.Module_Code = Modules.Module_Code
		                                                WHERE Login.Student_ID = '" + txtStudent_ID.Text + "';", con);
                cmd.ExecuteNonQuery();

                //used to fill values into datatable
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Modules");
                dataAdp.Fill(dt);
                DataGrid1.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Student ID" + "\n\nRemember Student ID Is Same As Username");
            }
        }

        //multithreading used
        private void MultiThread()
        {
            Thread.Sleep(2000);
        }
    }
}
