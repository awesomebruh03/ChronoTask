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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChronoTask
{
    
    public partial class SignUp : Window
    {
        public string Email_Validation1 { get; set; } = "Enter A Valid Email";
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
                EmailValidation.Text = "Please fill all the fields.";
                Shake();
                return;
            }
            if (!IsValidEmail(email))
                {
                EmailValidation.Text = "Please enter a valid email.";
                Shake();
                return;
            }

            if (password != confirmPassword)
            {
                EmailValidation.Text = "Passwords do not match.";
                Shake();
                return;
            }

            if (DatabaseHelper.EmailExists(email))
            {
                EmailValidation.Text = "Email already exists.";
                Shake();
                return;
            }

            // Adding user to the database
            DatabaseHelper.AddUser(email,Name, password);
            MessageBox.Show("User registered successfully.");

            SignIn signIn = new SignIn();
            signIn.Show();

            this.Close();
        }
        private void Shake()
        {
            var animation = new DoubleAnimationUsingKeyFrames();
            animation.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
            animation.KeyFrames.Add(new EasingDoubleKeyFrame(-5, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(25))));
            animation.KeyFrames.Add(new EasingDoubleKeyFrame(5, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(50))));
            animation.KeyFrames.Add(new EasingDoubleKeyFrame(-5, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(75))));
            animation.KeyFrames.Add(new EasingDoubleKeyFrame(5, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(100))));
            animation.KeyFrames.Add(new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(125))));

            var transform = new TranslateTransform();
            EmailValidation.RenderTransform = transform;
            EmailValidation.RenderTransformOrigin = new Point(0.5, 0.5);
            transform.BeginAnimation(TranslateTransform.XProperty, animation);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SignIn signin = new SignIn();
            signin.Show();
            this.Close();
        }
    }
}
