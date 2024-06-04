using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChronoTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            this.ResizeMode = ResizeMode.NoResize;
            this.ResizeMode = ResizeMode.CanMinimize;
            LoadProjects();
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            var addProjectDialog = new AddProjectDialog();
            if (addProjectDialog.ShowDialog() == true)
            {
                string projectName = addProjectDialog.ProjectName;
                DatabaseHelper.AddProject(projectName);
                LoadProjects(); // Refresh the project list
            }
        }


        private void UpdateProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectList.SelectedItem != null)
            {
                var selectedProject = (Project)ProjectList.SelectedItem;
                var updateProjectDialog = new UpdateProjectDialog(selectedProject);
                if (updateProjectDialog.ShowDialog() == true)
                {
                    DatabaseHelper.UpdateProject(selectedProject.ProjectId, updateProjectDialog.ProjectName);
                    LoadProjects();
                }
            }
        }

        private void DeleteProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectList.SelectedItem != null)
            {
                var selectedProject = (Project)ProjectList.SelectedItem;
                DatabaseHelper.DeleteProject(selectedProject.ProjectId);
                LoadProjects();
                TaskList.ItemsSource = null;
            }
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectList.SelectedItem is Project selectedProject)
            {
                var addTaskDialog = new AddTaskDialog();
                if (addTaskDialog.ShowDialog() == true)
                {
                    string taskName = addTaskDialog.TaskName;
                    string taskDescription = addTaskDialog.TaskDescription;
                    DateTime? startTime = addTaskDialog.StartTime;
                    DateTime? endTime = addTaskDialog.EndTime;
                    DatabaseHelper.AddTask(selectedProject.ProjectId, taskName, taskDescription, startTime, endTime);
                    LoadTasks(selectedProject.ProjectId); // Refresh the task list
                }
                
            }

        }



        private void UpdateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                var selectedTask = (Task)TaskList.SelectedItem;
                var updateTaskDialog = new UpdateTaskDialog(selectedTask);
                if (updateTaskDialog.ShowDialog() == true)
                {
                    DatabaseHelper.UpdateTask(selectedTask.TaskId, updateTaskDialog.TaskName, updateTaskDialog.TaskDescription, updateTaskDialog.TaskStartTime, updateTaskDialog.TaskEndTime);
                    LoadTasks(selectedTask.ProjectId);
                }
            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                var selectedTask = (Task)TaskList.SelectedItem;
                DatabaseHelper.DeleteTask(selectedTask.TaskId);
                LoadTasks(selectedTask.ProjectId);
            }
        }

        private void LoadProjects()
        {
            ProjectList.ItemsSource = DatabaseHelper.GetProjects();
        }

        private void LoadTasks(int projectId)
        {
            TaskList.ItemsSource = DatabaseHelper.GetTasks(projectId);
        }

        private void ProjectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProjectList.SelectedItem != null)
            {
                int projectId = ((Project)ProjectList.SelectedItem).ProjectId;
                LoadTasks(projectId);
            }
            
        }

       
    }



}