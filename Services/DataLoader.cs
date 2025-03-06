using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLeditor.Models;
using Serilog;
using System.Diagnostics;
using System.Linq;
using SQLeditor.Services;
using System.Data.SQLite;

namespace SQLeditor.Services
{
    public class DataLoader
    {
        private DatabaseService databaseService;
        private readonly Form1 form;

        public DataLoader(Form1 _form)
        {
            _form = form;
        }

        // tasks to control data saving loading deleting and Exporting Describer through name of the task
        public static async Task LoadCoursesAsync(Form1 form, DatabaseService databaseService)
        {
            var courses = await databaseService.GetCoursesAsync();
            form.CourseListView.SetObjects(courses);
            form.CourseListView.Refresh();
        }

        public static async Task LoadEditorDataAsync(Form1 form, DatabaseService databaseService)
        {
            var courses = await databaseService.GetCoursesAsync();
            form.dataGridViewCoursesEditor.DataSource = courses;
            var assignments = await databaseService.GetAllAssignmentsAsync();
            form.dataGridViewAssignmentsEditor.DataSource = assignments;
            var responses = await databaseService.GetAllResponsesAsync();
            form.dataGridViewResponsesEditor.DataSource = responses;
        }

        public static async Task LoadAssignmentsAsync(Form1 form, DatabaseService databaseService, int courseId, bool isAscendingOrder = true)
        {
            Debug.WriteLine($"Loading assignments for CourseID: {courseId}");

            var assignments = await databaseService.GetAssignmentsAsync(courseId);

            // Sort assignments based on the current order
            assignments = isAscendingOrder
                ? assignments.OrderBy(a => a.AssignmentPosition).ToList()
                : assignments.OrderByDescending(a => a.AssignmentPosition).ToList();

            if (form.AssignmentListView == null)
            {
                Debug.WriteLine("⚠️ AssignmentListView is NULL! Reinitializing...");

                // ✅ Reinitialize all ObjectListViews if not already set
                UIHelper.InitializeObjectListViews(form);
            }

            // ✅ Assign data to the AssignmentListView
            form.AssignmentListView.SetObjects(assignments);
            form.AssignmentListView.Refresh();
        }

        public static async Task LoadResponsesAsync(Form1 form, DatabaseService databaseService, int assignmentId)
        {
            var responses = await databaseService.GetResponsesAsync(assignmentId);
            form.ResponseListView.SetObjects(responses);
            form.ResponseListView.Refresh();
        }

        public static async Task SaveChangesAsync(Form1 form, DatabaseService databaseService)
        {
            Log.Information("Saving changes...");
            bool isSuccess = false;

            try
            {
                switch (form.TablesTabControl.SelectedTab.Name)
                {
                    case "tabPageCourses":
                        isSuccess = await SaveCoursesAsync(form, databaseService);
                        break;
                    case "tabPageAssignments":
                        isSuccess = await SaveAssignmentsAsync(form, databaseService);
                        break;
                    case "tabPageResponses":
                        isSuccess = await SaveResponsesAsync(form, databaseService);
                        break;
                }

                if (isSuccess)
                {
                    MessageBox.Show("Save operation completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Save operation failed. No changes were made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during the save operation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task DeleteChangesAsync(Form1 form, DatabaseService databaseService)
        {
            Log.Information("Deleting selected row...");
            bool isSuccess = false;

            try
            {
                switch (form.TablesTabControl.SelectedTab.Name)
                {
                    case "tabPageCourses":
                        isSuccess = await DeleteCourseAsync(form, databaseService);
                        break;
                    case "tabPageAssignments":
                        isSuccess = await DeleteAssignmentAsync(form, databaseService);
                        break;
                    case "tabPageResponses":
                        isSuccess = await DeleteResponseAsync(form, databaseService);
                        break;
                }

                if (isSuccess)
                {
                    MessageBox.Show("Delete operation completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Delete operation failed. No item was selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during the delete operation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task<bool> DeleteCourseAsync(Form1 form, DatabaseService databaseService)
        {
            // Get the selected course from the DataGridView
            var selectedCourse = form.dataGridViewCoursesEditor.CurrentRow?.DataBoundItem as Course;
            if (selectedCourse != null)
            {
                // Delete the course from the database
                await databaseService.DeleteCourseAsync(selectedCourse.Id);

                // Refresh the courses tab
                await LoadCoursesAsync(form, databaseService);

                // Explicitly refresh the dataGridView
                form.dataGridViewCoursesEditor.DataSource = null;
                form.dataGridViewCoursesEditor.DataSource = await databaseService.GetCoursesAsync();
                form.dataGridViewCoursesEditor.Refresh();

                return true; // Success
            }
            else
            {
                return false; // No course selected
            }
        }

        private static async Task<bool> DeleteAssignmentAsync(Form1 form, DatabaseService databaseService)
        {
            // Get the selected assignment from the DataGridView
            var selectedAssignment = form.dataGridViewAssignmentsEditor.CurrentRow?.DataBoundItem as Assignment;
            if (selectedAssignment != null)
            {
                // Delete the assignment from the database
                await databaseService.DeleteAssignmentAsync(selectedAssignment.Id);

                // Refresh the assignments tab
                await LoadAssignmentsAsync(form, databaseService, selectedAssignment.CourseId);

                // Explicitly refresh the dataGridView
                form.dataGridViewAssignmentsEditor.DataSource = null;
                form.dataGridViewAssignmentsEditor.DataSource = await databaseService.GetAllAssignmentsAsync();
                form.dataGridViewAssignmentsEditor.Refresh();

                return true; // Success
            }
            else
            {
                return false; // No assignment selected
            }
        }

        private static async Task<bool> DeleteResponseAsync(Form1 form, DatabaseService databaseService)
        {
            // Get the selected response from the DataGridView
            var selectedResponse = form.dataGridViewResponsesEditor.CurrentRow?.DataBoundItem as Response;
            if (selectedResponse != null)
            {
                // Delete the response from the database
                await databaseService.DeleteResponseAsync(selectedResponse.Id);

                // Refresh the responses tab
                await LoadResponsesAsync(form, databaseService, selectedResponse.AssignmentId);

                // Explicitly refresh the dataGridView
                form.dataGridViewResponsesEditor.DataSource = null;
                form.dataGridViewResponsesEditor.DataSource = await databaseService.GetAllResponsesAsync();
                form.dataGridViewResponsesEditor.Refresh();

                return true; // Success
            }
            else
            {
                return false; // No response selected
            }
        }

        private static async Task<bool> SaveCoursesAsync(Form1 form, DatabaseService databaseService)
        {
            var courses = (System.Collections.Generic.List<Course>)form.dataGridViewCoursesEditor.DataSource;
            if (courses == null || courses.Count == 0)
            {
                return false; // No courses to save
            }

            foreach (var course in courses)
            {
                if (course.Id == 0)
                    await databaseService.AddCourseAsync(course.CourseName, course.CourseDescription);
                else
                    await databaseService.UpdateCourseAsync(course.Id, course.CourseName, course.CourseDescription);
            }

            // Refresh the courses tab
            await LoadCoursesAsync(form, databaseService);

            // Explicitly refresh the dataGridView
            form.dataGridViewCoursesEditor.DataSource = null;
            form.dataGridViewCoursesEditor.DataSource = await databaseService.GetCoursesAsync();
            form.dataGridViewCoursesEditor.Refresh();

            return true; // Success
        }

        private static async Task<bool> SaveAssignmentsAsync(Form1 form, DatabaseService databaseService)
        {
            var assignments = (System.Collections.Generic.List<Assignment>)form.dataGridViewAssignmentsEditor.DataSource;
            if (assignments == null || assignments.Count == 0)
            {
                return false; // No assignments to save
            }

            foreach (var assignment in assignments)
            {
                if (assignment.Id == 0)
                    await databaseService.AddAssignmentAsync(assignment.CourseId, assignment.AssignmentTitle, assignment.AssignmentDescription, assignment.AssignmentPosition);
                else
                    await databaseService.UpdateAssignmentAsync(assignment.Id, assignment.AssignmentTitle, assignment.AssignmentDescription, assignment.AssignmentPosition);
            }

            // Refresh the assignments tab
            await LoadAssignmentsAsync(form, databaseService, form.SelectedCourseId);

            // Explicitly refresh the dataGridView
            form.dataGridViewAssignmentsEditor.DataSource = null;
            form.dataGridViewAssignmentsEditor.DataSource = await databaseService.GetAllAssignmentsAsync();
            form.dataGridViewAssignmentsEditor.Refresh();

            return true; // Success
        }

        private static async Task<bool> SaveResponsesAsync(Form1 form, DatabaseService databaseService)
        {
            var responses = (System.Collections.Generic.List<Response>)form.dataGridViewResponsesEditor.DataSource;
            if (responses == null || responses.Count == 0)
            {
                return false; // No responses to save
            }

            foreach (var response in responses)
            {
                if (response.Id == 0)
                    await databaseService.AddResponseAsync(response.AssignmentId, response.ResponseTitle, response.ResponseText);
                else
                    await databaseService.UpdateResponseAsync(response.Id, response.ResponseTitle, response.ResponseText);
            }

            // Get the AssignmentId from the currently selected response
            var selectedResponse = form.dataGridViewResponsesEditor.CurrentRow?.DataBoundItem as Response;
            if (selectedResponse != null)
            {
                // Refresh the responses tab
                await LoadResponsesAsync(form, databaseService, selectedResponse.AssignmentId);

                // Explicitly refresh the dataGridView
                form.dataGridViewResponsesEditor.DataSource = null;
                form.dataGridViewResponsesEditor.DataSource = await databaseService.GetAllResponsesAsync();
                form.dataGridViewResponsesEditor.Refresh();

                return true; // Success
            }
            else
            {
                MessageBox.Show("No response selected. Cannot refresh responses.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // No response selected
            }
        }

        public static async Task ExportCourseAsync(SQLiteConnection connection, Course course)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Courses (Id, CourseName, CourseDescription)
                VALUES ($Id, $CourseName, $CourseDescription)";

            command.Parameters.AddWithValue("$Id", course.Id);
            command.Parameters.AddWithValue("$CourseName", course.CourseName);
            command.Parameters.AddWithValue("$CourseDescription", course.CourseDescription);

            await command.ExecuteNonQueryAsync();
        }

        public static async Task ExportAssignmentAsync(SQLiteConnection connection, Assignment assignment)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Assignments (Id, CourseId, AssignmentTitle, AssignmentDescription, AssignmentPosition)
                VALUES ($Id, $CourseId, $AssignmentTitle, $AssignmentDescription, $AssignmentPosition)";

            command.Parameters.AddWithValue("$Id", assignment.Id);
            command.Parameters.AddWithValue("$CourseId", assignment.CourseId);
            command.Parameters.AddWithValue("$AssignmentTitle", assignment.AssignmentTitle);
            command.Parameters.AddWithValue("$AssignmentDescription", assignment.AssignmentDescription);
            command.Parameters.AddWithValue("$AssignmentPosition", assignment.AssignmentPosition);

            await command.ExecuteNonQueryAsync();
        }

        public static async Task ExportResponseAsync(SQLiteConnection connection, Response response)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Responses (Id, AssignmentId, ResponseTitle, ResponseText)
                VALUES ($Id, $AssignmentId, $ResponseTitle, $ResponseText)";

            command.Parameters.AddWithValue("$Id", response.Id);
            command.Parameters.AddWithValue("$AssignmentId", response.AssignmentId);
            command.Parameters.AddWithValue("$ResponseTitle", response.ResponseTitle);
            command.Parameters.AddWithValue("$ResponseText", response.ResponseText);

            await command.ExecuteNonQueryAsync();
        }

        public static async Task CreateDatabaseSchemaAsync(SQLiteConnection connection)
        {
            var createTablesCommand = connection.CreateCommand();
            createTablesCommand.CommandText = @"
                CREATE TABLE IF NOT EXISTS Courses (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    CourseName TEXT NOT NULL,
                    CourseDescription TEXT
                );

                CREATE TABLE IF NOT EXISTS Assignments (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    CourseId INTEGER NOT NULL,
                    AssignmentTitle TEXT NOT NULL,
                    AssignmentDescription TEXT,
                    AssignmentPosition INTEGER,
                    FOREIGN KEY (CourseId) REFERENCES Courses (Id)
                );

                CREATE TABLE IF NOT EXISTS Responses (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    AssignmentId INTEGER NOT NULL,
                    ResponseTitle TEXT NOT NULL,
                    ResponseText TEXT,
                    FOREIGN KEY (AssignmentId) REFERENCES Assignments (Id)
                );";
            await createTablesCommand.ExecuteNonQueryAsync();
        }
    }
}