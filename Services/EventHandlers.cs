using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLeditor.Models;
using Serilog;
using System.Diagnostics;
using System.Collections.Generic;

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

        public async void SaveBtn_Click(object sender, EventArgs e)
        {
            Log.Information($"Saving changes in tab: {_form.TablesTabControl.SelectedTab.Name}");
            await DataLoader.SaveChangesAsync(_form, _databaseService);
        }

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

        public async void NewCourseBtn_Click(object sender, EventArgs e)
        {
            // Define the fields for the course
            List<string> fields = new List<string> { "Course Name", "Course Description" };

            // Show the prompt and get the results
            var results = Prompt.ShowDialog("New Course", fields);

            if (results != null)
            {
                string courseName = results["Course Name"];
                string courseDescription = results["Course Description"];

                if (!string.IsNullOrEmpty(courseName) && !string.IsNullOrEmpty(courseDescription))
                {
                    await _databaseService.AddCourseAsync(courseName, courseDescription);
                    await DataLoader.LoadCoursesAsync(_form, _databaseService);
                }
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

                // Show the prompt and get the results
                var results = Prompt.ShowDialog("New Assignment", fields);

                if (results != null)
                {
                    string assignmentTitle = results["Assignment Title"];
                    string assignmentDescription = results["Assignment Description"];
                    string assignmentPositionStr = results["Assignment Position"];

                    if (!string.IsNullOrEmpty(assignmentTitle) && !string.IsNullOrEmpty(assignmentDescription) &&
                    int.TryParse(assignmentPositionStr, out int assignmentPosition))
                    {
                        await _databaseService.AddAssignmentAsync(selectedCourse.Id, assignmentTitle, assignmentDescription, assignmentPosition);
                        await DataLoader.LoadAssignmentsAsync(_form, _databaseService, selectedCourse.Id);
                    }
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
                        await _databaseService.UpdateAssignmentAsync(selectedAssignment.Id, newAssignmentTitle, newAssignmentDescription, newAssignmentPosition);
                        await DataLoader.LoadAssignmentsAsync(_form, _databaseService, selectedAssignment.Id);
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

                // Show the prompt and get the results
                var results = Prompt.ShowDialog("New Response", fields);

                if (results != null)
                {
                    string responseTitle = results["Response Title"];
                    string responseText = results["Response Text"];

                    if (!string.IsNullOrEmpty(responseTitle))
                    {
                        await _databaseService.AddResponseAsync(selectedAssignment.Id, responseTitle, responseText);
                        await DataLoader.LoadResponsesAsync(_form, _databaseService, selectedAssignment.Id);
                    }
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
                        await _databaseService.UpdateResponseAsync(selectedResponse.Id, newResponseTitle, newResponseText);
                        await DataLoader.LoadResponsesAsync(_form, _databaseService, selectedResponse.Id);
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

    }
}