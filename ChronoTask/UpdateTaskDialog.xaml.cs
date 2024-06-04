using System;
using System.Windows;

namespace ChronoTask
{
    public partial class UpdateTaskDialog : Window
    {
        public string TaskName { get; private set; }
        public string TaskDescription { get; private set; }
        public DateTime? TaskStartDate { get; private set; }
        public DateTime? TaskStartTime { get; private set; }
        public DateTime? TaskEndDate { get; private set; }
        public DateTime? TaskEndTime { get; private set; }

        public UpdateTaskDialog(Task task)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            TaskNameTextBox.Text = task.Name;
            TaskDescriptionTextBox.Text = task.Description;
            TaskStartDatePicker.SelectedDate = task.StartTime.HasValue ? task.StartTime.Value.Date : (DateTime?)null;
            TaskStartTimePicker.HoursTextBox.Text = task.StartTime.HasValue ? task.StartTime.Value.ToString("HH") : "HH";
            TaskStartTimePicker.MinutesTextBox.Text = task.StartTime.HasValue ? task.StartTime.Value.ToString("mm") : "MM";
            TaskEndDatePicker.SelectedDate = task.EndTime.HasValue ? task.EndTime.Value.Date : (DateTime?)null;
            TaskEndTimePicker.HoursTextBox.Text = task.EndTime.HasValue ? task.EndTime.Value.ToString("HH") : "HH";
            TaskEndTimePicker.MinutesTextBox.Text = task.EndTime.HasValue ? task.EndTime.Value.ToString("mm") : "MM";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TaskName = TaskNameTextBox.Text;
            TaskDescription = TaskDescriptionTextBox.Text;
            TaskStartDate = TaskStartDatePicker.SelectedDate;
            TaskStartTime = CombineDateAndTime(TaskStartDate, TaskStartTimePicker.SelectedTime);
            TaskEndDate = TaskEndDatePicker.SelectedDate;
            TaskEndTime = CombineDateAndTime(TaskEndDate, TaskEndTimePicker.SelectedTime);
            DialogResult = true;
        }

        private DateTime? CombineDateAndTime(DateTime? date, DateTime? time)
        {
            if (!date.HasValue || !time.HasValue)
                return null;
            return new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Value.Hour, time.Value.Minute, 0);
        }
    }
}
