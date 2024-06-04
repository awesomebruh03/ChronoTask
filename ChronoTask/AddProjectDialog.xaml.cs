using Microsoft.Win32;
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
    /// <summary>
    /// Interaction logic for AddProjectDialog.xaml
    /// </summary>
    public partial class AddProjectDialog : Window
    {
        public string ProjectName { get; private set; }

        public AddProjectDialog()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectName = ProjectNameTextBox.Text;
            DialogResult = true;
        }

        private void ProjectNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            if(textbox.Text == "Name")
            {
                textbox.Text = string.Empty;
            }
        }

        private void ProjectNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            if(string.IsNullOrEmpty(textbox.Text))
            {
                textbox.Text = "Name";
            }
        }
    }


}
