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
using System.Windows.Shapes;

namespace ChronoTask
{
    
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            ResizeMode = ResizeMode.CanMinimize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = Email.Text.Trim();
            string Name = UserName.Text.Trim();
            string password = pass.Password.Trim();
            string confirmPassword =conPass.Password.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (DatabaseHelper.EmailExists(email))
            {
                MessageBox.Show("E-mail already exists in the database.");
                return;
            }

            // Adding user to the database
            DatabaseHelper.AddUser(email,Name, password);
            MessageBox.Show("User registered successfully.");

            SignIn signIn = new SignIn();
            signIn.Show();

            this.Close();
        }
        
    }
}
