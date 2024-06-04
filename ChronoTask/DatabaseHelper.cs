using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;

public static class DatabaseHelper
{
    private const string ConnectionString = "Data Source=chronotask.db;Version=3;";

    public static void InitializeDatabase()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string createProjectsTableQuery = @"
                CREATE TABLE IF NOT EXISTS Projects (
                    ProjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                )";
            string createTasksTableQuery = @"
                CREATE TABLE IF NOT EXISTS Tasks (
                    TaskId INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProjectId INTEGER NOT NULL,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    StartTime TEXT,
                    EndTime TEXT,
                    FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId)
                )";
            string createUserTableQuery = @"
            CREATE TABLE IF NOT EXISTS Users (
                UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                Email TEXT NOT NULL,
                UserName TEXT NOT NULL,
                UserPassword TEXT NOT NULL
            )";
            using (var command = new SQLiteCommand(createProjectsTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand(createTasksTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
            using(var command = new SQLiteCommand(createUserTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }


    public static void AddUser(string Email, string userName, string userPassword)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "INSERT INTO Users (Email, UserName, UserPassword) VALUES (@Email, @UserName, @UserPassword)";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@UserPassword", userPassword);
                command.ExecuteNonQuery();
            }
        }
    }

    public static bool ValidateUser(string Email, string password)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND UserPassword = @UserPassword";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@UserPassword", password);
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }
    }

    public static bool EmailExists(string email)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }
    }

    public static void AddProject(string name)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "INSERT INTO Projects (Name) VALUES (@Name)";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
        }
    }


    public static void AddTask(int projectId, string name, string description, DateTime? startTime, DateTime? endTime)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "INSERT INTO Tasks (ProjectId, Name, Description, StartTime, EndTime) VALUES (@ProjectId, @Name, @Description, @StartTime, @EndTime)";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProjectId", projectId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@StartTime", startTime?.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@EndTime", endTime?.ToString("yyyy-MM-dd HH:mm:ss"));
                command.ExecuteNonQuery();
            }
        }
    }



    public static List<Project> GetProjects()
    {
        var projects = new List<Project>();
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Projects";
            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    projects.Add(new Project
                    {
                        ProjectId = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }
        }
        return projects;
    }


    public static List<Task> GetTasks(int projectId)
    {
        var tasks = new List<Task>();
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Tasks WHERE ProjectId = @ProjectId";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProjectId", projectId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task
                        {
                            TaskId = reader.GetInt32(0),
                            ProjectId = reader.GetInt32(1),
                            Name = reader.GetString(2),
                            Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                            StartTime = reader.IsDBNull(4) ? (DateTime?)null : DateTime.Parse(reader.GetString(4)),
                            EndTime = reader.IsDBNull(5) ? (DateTime?)null : DateTime.Parse(reader.GetString(5))
                        });
                    }
                }
            }
        }
        return tasks;
    }

    // Add methods to update and delete projects and tasks

    public static void UpdateProject(int projectId, string name)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "UPDATE Projects SET Name = @Name WHERE ProjectId = @ProjectId";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProjectId", projectId);
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void DeleteProject(int projectId)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "DELETE FROM Projects WHERE ProjectId = @ProjectId";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProjectId", projectId);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void UpdateTask(int taskId, string name, string description, DateTime? startTime, DateTime? endTime)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "UPDATE Tasks SET Name = @Name, Description = @Description, StartTime = @StartTime, EndTime = @EndTime WHERE TaskId = @TaskId";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TaskId", taskId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@StartTime", startTime.HasValue ? startTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : DBNull.Value);
                command.Parameters.AddWithValue("@EndTime", endTime.HasValue ? endTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : DBNull.Value);
                command.ExecuteNonQuery();
            }
        }
    }


    public static void DeleteTask(int taskId)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = "DELETE FROM Tasks WHERE TaskId = @TaskId";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TaskId", taskId);
                command.ExecuteNonQuery();
            }
        }
    }
}
