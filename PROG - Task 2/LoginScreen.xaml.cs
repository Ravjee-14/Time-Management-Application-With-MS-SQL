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
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Threading;

namespace PROG___Task_2
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        //Login class declared into Login.XAML
        Login myLogin = new Login();

        public LoginScreen()
        {
            InitializeComponent();
        }

        //Class used to Encyrpt or Convert Password to MD5
        static string Encrypt(string value)
        {
            //used to encrypt password
            using(MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = MD5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Delcare textboxes are class values
            myLogin.Username = txtUsername.Text;
            myLogin.Password = txtPassword.Password;

            Thread th = Thread.CurrentThread;

            SqlConnection con = new SqlConnection(@"Data Source=ravjee;Initial Catalog=Time_Management_App;Integrated Security=True");
            string encryptedPassword = Encrypt(myLogin.Password);

            con.Open();
            //SQL Query to login
            String query = "SELECT COUNT(1) FROM Login WHERE Student_ID=@Student_ID AND Student_Password=@Student_Password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Student_ID", myLogin.Username);
            cmd.Parameters.AddWithValue("@Student_Password", encryptedPassword);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            //Loops used to perform certain actions like grant access or give an error message
            if(count == 1)
            {
                //used to open new window and close login screen
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Username and Password Combination");
            }

            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string encryptedPassword = Encrypt(txtPassword.Password);
                SqlConnection con = new SqlConnection("Data Source=ravjee;Initial Catalog=Time_Management_App;Integrated Security=True");

                con.Open();
                //SQL Query to create a new user
                SqlCommand cmd2 = new SqlCommand(@"INSERT INTO [dbo].[Login]
                                                         ([Student_ID]
                                                         ,[Student_Password])
                                                    VALUES
                                                         ('" + txtUsername.Text + "', '" + encryptedPassword + "');", con);
                SqlDataReader dr = cmd2.ExecuteReader();
                con.Close();

                //Message displayed to show user their username or password
                MessageBox.Show("Username: " + txtUsername.Text + "\nPassword: " + txtPassword.Password);
                MessageBox.Show("Account Successfully Created");

                //textboxes cleared to user can log in again
                txtUsername.Clear();
                txtPassword.Clear();
            }
            catch
            {
                MessageBox.Show("Username is Already Taken");
            }

        }

        //multi threading used
        private void MultiThread()
        {
            Thread.Sleep(2000);
        }
    }
}
