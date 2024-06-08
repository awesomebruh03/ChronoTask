using System.Windows;


namespace ChronoTask
{
   
    public partial class UpdateProjectDialog : Window
    {
        public string ProjectName { get; private set; }

        public UpdateProjectDialog(Project project)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            ProjectNameTextBox.Text = project.Name;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectName = ProjectNameTextBox.Text;
            DialogResult = true;
        }
    }

}
