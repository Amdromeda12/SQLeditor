using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLeditor.Models;
using Serilog;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Data;
using System.IO;

namespace SQLeditor.Services
{
    public class EventHandlers
    {
        private readonly Form1 _form;
        private DatabaseService _databaseService;
        private bool _isAscendingOrder = true;

        public EventHandlers(Form1 form, DatabaseService databaseService)
        {
            _form = form;
            _databaseService = databaseService;

            _form.btnSortAssignments.Text = "↑";
        }

        //🔹Control toolstripe buttons
        public async void OpenDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQLite Database (*.db)|*.db|All files (*.*)|*.*";
                openFileDialog.Title = "Select SQLite Database";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedDatabasePath = openFileDialog.FileName;
                    if (!string.IsNullOrWhiteSpace(selectedDatabasePath))
                    {
                        Debug.WriteLine($"🔹 Selected Database Path: {selectedDatabasePath}");

                        // ✅ Clear all existing data before loading the new database
                        _form.CourseListView.ClearObjects();
                        _form.AssignmentListView.ClearObjects();
                        _form.ResponseListView.ClearObjects();
                        _form.RMessageBox.Text = ""; // Clear the response message box

                        // ✅ Update the DatabaseService with the new path
                        _databaseService = new DatabaseService(selectedDatabasePath);

                        _form.DatabaseService = _databaseService; // Ensure the form uses the updated service
                        _form.DatabasePath = selectedDatabasePath; // Update the form's DatabasePath property

                        _form.Text = $"SQL Editor | Current Database: {selectedDatabasePath}";
                        UIHelper.SetDatabaseState(_form, true);

                        await DataLoader.LoadCoursesAsync(_form, _form.DatabaseService);
                        await DataLoader.LoadEditorDataAsync(_form, _form.DatabaseService);
                    }
                    else
                    {
                        MessageBox.Show("Invalid database file. Please select a valid SQLite database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 🔹 Saving or delete info from the current tab
        public async void SaveBtn_Click(object sender, EventArgs e)
        {
            Log.Information($"Saving changes in tab: {_form.TablesTabControl.SelectedTab.Name}");  
            await DataLoader.SaveChangesAsync(_form, _databaseService);
        }

        public async void DeleteBtn_Click(object sender, EventArgs e)
        {
            Log.Information($"Deleting selected row in tab: {_form.TablesTabControl.SelectedTab.Name}");
            await DataLoader.DeleteChangesAsync(_form, _databaseService);
            _form.RMessageBox.Text = "";
        }

        // 🔹 Copy Text to clipboard
        public void CopyBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_form.RMessageBox.Text))
            {
                Clipboard.SetText(_form.RMessageBox.Text);
                MessageBox.Show("Text copied to clipboard!");
            }
            else
            {
                MessageBox.Show("No text to copy.");
            }
        }

        // 🔹 Buttons To handel create edit and delete course or assignments or responses or exporting them
        public async void NewCourseBtn_Click(object sender, EventArgs e)
        {
            // Define the fields for the course
            List<string> fields = new List<string> { "Course Name", "Course Description" };

            // Store the user's previous input
            Dictionary<string, string> previousInput = new Dictionary<string, string>();

            // Loop until valid input is provided or the user cancels
            while (true)
            {
                // Show the prompt and get the results, pre-filling with previous input
                var results = Prompt.ShowDialog("New Course", fields, previousInput);

                // If the user cancels the dialog, exit the loop
                if (results == null)
                {
                    return; // User canceled, exit the method
                }

                string courseName = results["Course Name"];
                string courseDescription = results["Course Description"];

                // Validate the input
                bool isValid = true;

                if (string.IsNullOrEmpty(courseName))
                {
                    MessageBox.Show("Course Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }

                // If input is valid, proceed with adding the course
                if (isValid)
                {
                    await _databaseService.AddCourseAsync(courseName, courseDescription);
                    await DataLoader.LoadCoursesAsync(_form, _databaseService);
                    return; // Exit the loop and method after successful operation
                }

                // If input is invalid, save the current input for the next iteration
                previousInput["Course Name"] = courseName;
                previousInput["Course Description"] = courseDescription;

                // The loop will repeat, showing the prompt again with the previous input
            }
        }

        public async void EditCourseBtn_Click(object sender, EventArgs e)
        {
            if (_form.CourseListView.SelectedObject is Course selectedCourse)
            {
                // Define the fields for the course
                List<string> fields = new List<string> { "Course Name", "Course Description" };

                // Provide default values for editing
                Dictionary<string, string> defaultValues = new Dictionary<string, string>
                {
                    { "Course Name", selectedCourse.CourseName },
                    { "Course Description", selectedCourse.CourseDescription }
                };

                // Show the prompt and get the results
                var results = Prompt.ShowDialog("Edit Course", fields, defaultValues);

                if (results != null)
                {
                    string newCourseName = results["Course Name"];
                    string newCourseDescription = results["Course Description"];

                    if (!string.IsNullOrEmpty(newCourseName) && !string.IsNullOrEmpty(newCourseDescription))
                    {
                        await _databaseService.UpdateCourseAsync(selectedCourse.Id, newCourseName, newCourseDescription);
                        await DataLoader.LoadCoursesAsync(_form, _databaseService);
                    }
                }
            }
        }

        public async void DeleteCourseBtn_Click(object sender, EventArgs e)
        {
            if (_form.CourseListView.SelectedObject is Course selectedCourse)
            {
                DialogResult result = MessageBox.Show($"Delete {selectedCourse.CourseName}?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _databaseService.DeleteCourseAsync(selectedCourse.Id);
                    await DataLoader.LoadCoursesAsync(_form, _databaseService);
                    _form.AssignmentListView.ClearObjects();
                    _form.ResponseListView.ClearObjects();
                    _form.RMessageBox.Text = "";
                }
            }
        }

        public async void NewAssigmBtn_Click(object sender, EventArgs e)
        {
            if (_form.CourseListView.SelectedObject is Course selectedCourse)
            {
                // Define the fields for the assignment
                List<string> fields = new List<string> { "Assignment Title", "Assignment Description", "Assignment Position" };

                // Store the user's previous input
                Dictionary<string, string> previousInput = new Dictionary<string, string>();

                // Loop until valid input is provided or the user cancels
                while (true)
                {
                    // Show the prompt and get the results, pre-filling with previous input
                    var results = Prompt.ShowDialog("New Assignment", fields, previousInput);

                    // If the user cancels the dialog, exit the loop
                    if (results == null)
                    {
                        return; // User canceled, exit the method
                    }

                    string assignmentTitle = results["Assignment Title"];
                    string assignmentDescription = results["Assignment Description"];
                    string assignmentPositionStr = results["Assignment Position"];

                    // Validate the input
                    bool isValid = true;

                    if (string.IsNullOrEmpty(assignmentTitle))
                    {
                        MessageBox.Show("Assignment Title is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                    }

                    if (!int.TryParse(assignmentPositionStr, out int assignmentPosition))
                    {
                        MessageBox.Show("Assignment Position must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                    }

                    // If input is valid, proceed with adding the assignment
                    if (isValid)
                    {
                        await _databaseService.AddAssignmentAsync(selectedCourse.Id, assignmentTitle, assignmentDescription, assignmentPosition);
                        await DataLoader.LoadAssignmentsAsync(_form, _databaseService, selectedCourse.Id);
                        return; // Exit the loop and method after successful operation
                    }

                    // If input is invalid, save the current input for the next iteration
                    previousInput["Assignment Title"] = assignmentTitle;
                    previousInput["Assignment Description"] = assignmentDescription;
                    previousInput["Assignment Position"] = assignmentPositionStr;

                    // The loop will repeat, showing the prompt again with the previous input
                }
            }
        }

        public async void EditAssignmentBtn_Click(object sender, EventArgs e)
        {
            if (_form.AssignmentListView.SelectedObject is Assignment selectedAssignment)
            {
                // Define the fields for the assignment
                List<string> fields = new List<string> { "Assignment Title", "Assignment Description", "Assignment Position" };

                // Provide default values for editing
                Dictionary<string, string> defaultValues = new Dictionary<string, string>
                {
                    { "Assignment Title", selectedAssignment.AssignmentTitle },
                    { "Assignment Description", selectedAssignment.AssignmentDescription },
                    { "Assignment Position", selectedAssignment.AssignmentPosition.ToString() }
                };

                // Show the prompt and get the results
                var results = Prompt.ShowDialog("Edit Assignment", fields, defaultValues);

                if (results != null)
                {
                    string newAssignmentTitle = results["Assignment Title"];
                    string newAssignmentDescription = results["Assignment Description"];
                    string newAssignmentPositionStr = results["Assignment Position"];

                    if (!string.IsNullOrEmpty(newAssignmentTitle) && !string.IsNullOrEmpty(newAssignmentDescription) &&
                        int.TryParse(newAssignmentPositionStr, out int newAssignmentPosition))
                    {
                        // Update the assignment in the database
                        await _databaseService.UpdateAssignmentAsync(selectedAssignment.Id, newAssignmentTitle, newAssignmentDescription, newAssignmentPosition);

                        // Refresh the assignment list view
                        await DataLoader.LoadAssignmentsAsync(_form, _databaseService, selectedAssignment.CourseId);

                        // Select the updated assignment in the list view
                        var updatedAssignment = _form.AssignmentListView.Objects.Cast<Assignment>()
                            .FirstOrDefault(a => a.Id == selectedAssignment.Id);

                        if (updatedAssignment != null)
                        {
                            _form.AssignmentListView.SelectedObject = updatedAssignment;
                            _form.AssignmentListView.RefreshObject(updatedAssignment);
                        }
                    }
                }
            }
        }

        public async void DeleteAssigmBtn_Click(object sender, EventArgs e)
        {
            if (_form.AssignmentListView.SelectedObject is Assignment selectedAssignment)
            {
                DialogResult result = MessageBox.Show($"Delete {selectedAssignment.AssignmentTitle}?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _databaseService.DeleteAssignmentAsync(selectedAssignment.Id);
                    await DataLoader.LoadAssignmentsAsync(_form, _databaseService, selectedAssignment.CourseId);

                    _form.ResponseListView.ClearObjects();
                    _form.RMessageBox.Text = "";
                }
            }
        }

        public async void NewRespBtn_Click(object sender, EventArgs e)
        {
            if (_form.AssignmentListView.SelectedObject is Assignment selectedAssignment)
            {
                // Define the fields for the response
                List<string> fields = new List<string> { "Response Title", "Response Text" };

                // Store the user's previous input
                Dictionary<string, string> previousInput = new Dictionary<string, string>();

                // Loop until valid input is provided or the user cancels
                while (true)
                {
                    // Show the prompt and get the results, pre-filling with previous input
                    var results = Prompt.ShowDialog("New Response", fields, previousInput);

                    // If the user cancels the dialog, exit the loop
                    if (results == null)
                    {
                        return; // User canceled, exit the method
                    }

                    string responseTitle = results["Response Title"];
                    string responseText = results["Response Text"];

                    // Validate the input
                    bool isValid = true;

                    if (string.IsNullOrEmpty(responseTitle))
                    {
                        MessageBox.Show("Response Title is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                    }

                    // If input is valid, proceed with adding the response
                    if (isValid)
                    {
                        await _databaseService.AddResponseAsync(selectedAssignment.Id, responseTitle, responseText);
                        await DataLoader.LoadResponsesAsync(_form, _databaseService, selectedAssignment.Id);
                        return; // Exit the loop and method after successful operation
                    }

                    // If input is invalid, save the current input for the next iteration
                    previousInput["Response Title"] = responseTitle;
                    previousInput["Response Text"] = responseText;

                    // The loop will repeat, showing the prompt again with the previous input
                }
            }
        }

        public async void EditResponseBtn_Click(object sender, EventArgs e)
        {
            if (_form.ResponseListView.SelectedObject is Response selectedResponse)
            {
                // Define the fields for the response
                List<string> fields = new List<string> { "Response Title", "Response Text" };

                // Provide default values for editing
                Dictionary<string, string> defaultValues = new Dictionary<string, string>
                {
                    { "Response Title", selectedResponse.ResponseTitle },
                    { "Response Text", selectedResponse.ResponseText }
                };

                // Show the prompt and get the results
                var results = Prompt.ShowDialog("Edit Response", fields, defaultValues);

                if (results != null)
                {
                    string newResponseTitle = results["Response Title"];
                    string newResponseText = results["Response Text"];

                    if (!string.IsNullOrEmpty(newResponseTitle) && !string.IsNullOrEmpty(newResponseText))
                    {
                        // Update the response in the database
                        await _databaseService.UpdateResponseAsync(selectedResponse.Id, newResponseTitle, newResponseText);

                        // Refresh the response list view
                        await DataLoader.LoadResponsesAsync(_form, _databaseService, selectedResponse.AssignmentId);

                        // Select the updated response in the list view
                        var updatedResponse = _form.ResponseListView.Objects.Cast<Response>()
                            .FirstOrDefault(r => r.Id == selectedResponse.Id);

                        if (updatedResponse != null)
                        {
                            _form.ResponseListView.SelectedObject = updatedResponse;
                            _form.ResponseListView.RefreshObject(updatedResponse);
                        }
                    }
                }
            }
        }

        public async void DeleteRespBtn_Click(object sender, EventArgs e)
        {
            if (_form.ResponseListView.SelectedObject is Response selectedResponse)
            {
                DialogResult result = MessageBox.Show($"Delete {selectedResponse.ResponseTitle}?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _databaseService.DeleteResponseAsync(selectedResponse.Id);
                    await DataLoader.LoadResponsesAsync(_form, _databaseService, selectedResponse.Id);
                    _form.RMessageBox.Text = "";
                }
            }
        }

        public void ExportCourseBtn_Click(object sender, EventArgs e)
        {
            if (_form.CourseListView.SelectedObject is Course selectedCourse)
            {
                ExportCourseToDatabase(selectedCourse);
            }
            else
            {
                MessageBox.Show("Please select a course to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportAssignmentBtn_Click(object sender, EventArgs e)
        {
            if (_form.AssignmentListView.SelectedObject is Assignment selectedAssignment)
            {
                ExportAssignmentToDatabase(selectedAssignment);
            }
            else
            {
                MessageBox.Show("Please select an assignment to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Handles Course Selection
        public async void CourseListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_form.CourseListView.SelectedObject is Course selectedCourse)
            {
                Debug.WriteLine($"Course Selected: {selectedCourse.CourseName} (ID: {selectedCourse.Id})");

                _form.SelectedCourseId = selectedCourse.Id;

                _isAscendingOrder = true;
                _form.btnSortAssignments.Text = "↑";

                // ✅ Load assignments for the selected course
                await DataLoader.LoadAssignmentsAsync(_form, _databaseService, _form.SelectedCourseId, _isAscendingOrder);
            }
            else
            {
                Debug.WriteLine("No course selected, clearing assignments and responses.");
                _form.AssignmentListView.ClearObjects();
                _form.ResponseListView.ClearObjects();
            }

            // ✅ Clear response message box
            _form.RMessageBox.Text = "";
        }

        // 🔹 Handles Assignment Selection
        public async void AssignmentListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_form.AssignmentListView.SelectedObject is Assignment selectedAssignment)
            {
                Log.Information($"Assignment Selected: {selectedAssignment.AssignmentTitle}");
                await DataLoader.LoadResponsesAsync(_form, _databaseService, selectedAssignment.Id);
            }
            else
            {
                _form.ResponseListView.ClearObjects(); // Clears responses when no assignment is selected
            }
        }

        // 🔹 Handles Response Selection
        public void ResponseListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_form.ResponseListView.SelectedObject is Response selectedResponse)
            {
                Debug.WriteLine($"Response Selected: {selectedResponse.ResponseTitle}");

                // ✅ Display response text in message box
                _form.RMessageBox.Text = selectedResponse.ResponseText;
            }
            else
            {
                _form.RMessageBox.Text = "";
            }
        }

        // 🔹 Sorting assignments from higher to lower or opposite
        public async void BtnSortAssignments_Click(object sender, EventArgs e, int selectedCourseId)
        {
            // Store the currently selected assignment
            var selectedAssignment = _form.AssignmentListView.SelectedObject as Assignment;

            // Toggle the sorting order
            _isAscendingOrder = !_isAscendingOrder;

            // Reload assignments with the new sorting order
            await DataLoader.LoadAssignmentsAsync(_form, _databaseService, selectedCourseId, _isAscendingOrder);

            // Restore the selected assignment
            if (selectedAssignment != null)
            {
                _form.AssignmentListView.SelectObject(selectedAssignment);
            }

            // Update the button icon
            _form.btnSortAssignments.Text = _isAscendingOrder ? "↑" : "↓";
        }

        // 🔹 Exporting Course with everything related to it
        public async void ExportCourseToDatabase(Course course)
        {
            try
            {
                // Prompt the user to choose a file location
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "SQLite files (*.db)|*.db|All files (*.*)|*.*";
                    saveFileDialog.FileName = $"Course_{course.Id}_Export.db";
                    saveFileDialog.Title = "Save Course Export";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string newDbPath = saveFileDialog.FileName;

                        // Create a new SQLite database file
                        using (var connection = new SQLiteConnection($"Data Source={newDbPath};Version=3;"))
                        {
                            await connection.OpenAsync();

                            // Create tables
                            await DataLoader.CreateDatabaseSchemaAsync(connection);

                            // Export the course
                            await DataLoader.ExportCourseAsync(connection, course);

                            // Export assignments for the course
                            var assignments = await _databaseService.GetAssignmentsByCourseIdAsync(course.Id);
                            foreach (var assignment in assignments)
                            {
                                await DataLoader.ExportAssignmentAsync(connection, assignment);

                                // Export responses for the assignment
                                var responses = await _databaseService.GetResponsesByAssignmentIdAsync(assignment.Id);
                                foreach (var response in responses)
                                {
                                    await DataLoader.ExportResponseAsync(connection, response);
                                }
                            }
                        }

                        MessageBox.Show("Course exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exporting the course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Exporting Assignment with everything related to it
        public async void ExportAssignmentToDatabase(Assignment assignment)
        {
            try
            {
                // Prompt the user to choose a file location
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "SQLite files (*.db)|*.db|All files (*.*)|*.*";
                    saveFileDialog.FileName = $"Assignment_{assignment.Id}_Export.db";
                    saveFileDialog.Title = "Save Assignment Export";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string newDbPath = saveFileDialog.FileName;

                        // Create a new SQLite database file
                        using (var connection = new SQLiteConnection($"Data Source={newDbPath};Version=3;"))
                        {
                            await connection.OpenAsync();

                            // Create tables
                            await DataLoader.CreateDatabaseSchemaAsync(connection);

                            // Export the course for the assignment
                            var course = await _databaseService.GetCourseByIdAsync(assignment.CourseId);
                            await DataLoader.ExportCourseAsync(connection, course);

                            // Export the assignment
                            await DataLoader.ExportAssignmentAsync(connection, assignment);

                            // Export responses for the assignment
                            var responses = await _databaseService.GetResponsesByAssignmentIdAsync(assignment.Id);
                            foreach (var response in responses)
                            {
                                await DataLoader.ExportResponseAsync(connection, response);
                            }
                        }

                        MessageBox.Show("Assignment exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exporting the assignment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}