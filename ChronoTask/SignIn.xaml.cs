using System.Windows;
using ChronoTask;


namespace ChronoTask
{
    public partial class SignIn : Window
    {
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
            if (user != null)
            {
                MainWindow mainWindow = new MainWindow();
                DatabaseHelper.currentUserId = user.userId; // Assuming MainWindow has a CurrentUserId property
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}