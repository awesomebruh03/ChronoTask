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
    /// Interaction logic for AddTaskDialog.xaml
    /// </summary>
    public partial class AddTaskDialog : Window
    {
        public string TaskName { get; private set; }
        public string TaskDescription { get; private set; }
        public DateTime? StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }

        public AddTaskDialog()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TaskName = TaskNameTextBox.Text;
            TaskDescription = TaskDescriptionTextBox.Text;

            if (StartTimePicker.SelectedDate.HasValue && StartTimeTimePicker.SelectedTime.HasValue)
            {
                StartTime = new DateTime(StartTimePicker.SelectedDate.Value.Year, StartTimePicker.SelectedDate.Value.Month,
                                         StartTimePicker.SelectedDate.Value.Day, StartTimeTimePicker.SelectedTime.Value.Hour,
                                         StartTimeTimePicker.SelectedTime.Value.Minute, 0);
            }

            if (EndTimePicker.SelectedDate.HasValue && EndTimeTimePicker.SelectedTime.HasValue)
            {
                EndTime = new DateTime(EndTimePicker.SelectedDate.Value.Year, EndTimePicker.SelectedDate.Value.Month,
                                       EndTimePicker.SelectedDate.Value.Day, EndTimeTimePicker.SelectedTime.Value.Hour,
                                       EndTimeTimePicker.SelectedTime.Value.Minute, 0);
            }

            DialogResult = true;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Task Name" || textBox.Text == "Task Description")
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox == TaskNameTextBox ? "Task Name" : "Task Description";
            }
        }
    }



}
