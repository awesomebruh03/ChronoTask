using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using ChronoTask;
using System.Security.RightsManagement;
using System.Net.Mail;
namespace ChronoTask
{
    public partial class SignIn : Window 
    {
        public string Email_Validation { get; set; } = "Enter a Valid Email";

        public SignIn()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            ResizeMode = ResizeMode.CanMinimize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = textEmail.Text;
            string password = passBox.Password;
            
            
                User user = DatabaseHelper.ValidateUser(email, password);
                if (user != null && IsValidEmail(email))
                {
                    MainWindow mainWindow = new MainWindow();
                    DatabaseHelper.currentUserId = user.userId; // Assuming MainWindow has a CurrentUserId property
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    
                    Email_Validation = "Invalid Email or Password";
                    EmailValidation.Text = Email_Validation;
                    Shake();

                }
            
            
            
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
    }
}
