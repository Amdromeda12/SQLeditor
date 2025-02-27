using SQLeditor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLeditor
{
    public partial class Form1 : Form
    {
        // Existing fields for your main editing functionality…
        private DatabaseService _databaseService;
        private string databasePath = "";

        private bool IsDatabaseOpen(bool showMessage = true)
        {
            if (string.IsNullOrWhiteSpace(databasePath) || _databaseService == null)
            {
                if (showMessage)
                {
                    MessageBox.Show("Please open a database first.", "Database Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        public Form1(DatabaseService databaseService)
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService), "DatabaseService cannot be null.");
            InitializeComponent();

            CourseListView = new BrightIdeasSoftware.ObjectListView();
            AssignmentListView = new BrightIdeasSoftware.ObjectListView();
            ResponseListView = new BrightIdeasSoftware.ObjectListView();

            InitializeObjectListViews();
            InitializeEventHandlers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Disable everything initially if no valid database is set
            SetDatabaseState(!string.IsNullOrEmpty(_databaseService?.DatabasePath));
        }

        private void InitializeObjectListViews()
        {
            // Ensure ObjectListViews are initialized before modifying them
            CourseListView = new BrightIdeasSoftware.ObjectListView();
            AssignmentListView = new BrightIdeasSoftware.ObjectListView();
            ResponseListView = new BrightIdeasSoftware.ObjectListView();

            // Define a better font (e.g., Segoe UI, 12pt for readability)
            Font customFont = new Font("Segoe UI", 12, FontStyle.Regular);

            foreach (var olv in new[] { CourseListView, AssignmentListView, ResponseListView })
            {
                olv.FullRowSelect = true;
                olv.HideSelection = false;
                olv.UseFiltering = true;
                olv.View = View.Details;
                olv.MultiSelect = false; // Allow only one selection
                olv.Dock = DockStyle.Fill; // Fit to panel size
                olv.ShowGroups = false; // Disable grouping for cleaner UI
                olv.HeaderStyle = ColumnHeaderStyle.None; // Hide column titles
                olv.Font = customFont; // Apply custom font
            }

            // Add Columns to each OLV
            CourseListView.AllColumns.Add(new BrightIdeasSoftware.OLVColumn { AspectName = "CourseName", FillsFreeSpace = true });
            AssignmentListView.AllColumns.Add(new BrightIdeasSoftware.OLVColumn { AspectName = "AssignmentTitle", FillsFreeSpace = true });
            ResponseListView.AllColumns.Add(new BrightIdeasSoftware.OLVColumn { AspectName = "ResponseTitle", FillsFreeSpace = true });

            // Apply the column configuration
            CourseListView.RebuildColumns();
            AssignmentListView.RebuildColumns();
            ResponseListView.RebuildColumns();

            // Add OLVs to the existing UI panels in the "Use" tab
            panelCourses.Controls.Add(CourseListView);
            panelAssignments.Controls.Add(AssignmentListView);
            panelResponses.Controls.Add(ResponseListView);
        }

        private void InitializeEventHandlers()
        {
            // ObjectListView selection events
            CourseListView.SelectedIndexChanged += CourseListView_SelectedIndexChanged;
            AssignmentListView.SelectedIndexChanged += AssignmentListView_SelectedIndexChanged;
            ResponseListView.SelectedIndexChanged += ResponseListView_SelectedIndexChanged;

            // Buttons
            NewCourseBtn.Click += NewCourseBtn_Click;
            DeleteCourseBtn.Click += DeleteCourseBtn_Click;
            EditCourseBtn.Click += EditCourseBtn_Click;

            NewAssigmBtn.Click += NewAssigmBtn_Click;
            DeleteAssigmBtn.Click += DeleteAssigmBtn_Click;
            EditAssignmentBtn.Click += EditAssignmentBtn_Click;

            NewRespBtn.Click += NewRespBtn_Click;
            DeleteRespBtn.Click += DeleteRespBtn_Click;
            EditResponseBtn.Click += EditResponseBtn_Click;

            //to prevent tab navigation if no database is open
            TablesTabControl.Selecting += TablesTabControl_Selecting;
        }

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridView dgv = sender as DataGridView;
                dgv?.EndEdit();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Opens a SQLite database file and initializes the connection.
        /// Updates the UI title and loads the courses into the ObjectListView.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data.</param>
        private async void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQLite Database (*.db)|*.db|All files (*.*)|*.*";
                openFileDialog.Title = "Select SQLite Database";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedDatabasePath = openFileDialog.FileName; // ✅ Ensure variable is in scope

                    if (!string.IsNullOrWhiteSpace(selectedDatabasePath))
                    {
                        _databaseService = new DatabaseService(selectedDatabasePath);
                        databasePath = selectedDatabasePath;

                        // ✅ Set the form title to show the selected database path
                        this.Text = $"SQL Editor | Current Database: {databasePath}";



                        SetDatabaseState(true);
                        await LoadCoursesAsync();
                        await LoadEditorDataAsync();
                    }
                    else
                    {
                        MessageBox.Show("Invalid database file. Please select a valid SQLite database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Loads all courses from the database and updates the CourseListView.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task LoadCoursesAsync()
        {
            var courses = await _databaseService.GetCoursesAsync();
            CourseListView.SetObjects(courses);
        }

        private async void CourseListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CourseListView.SelectedObject is Course selectedCourse)
            {
                var assignments = await _databaseService.GetAssignmentsAsync(selectedCourse.Id);
                AssignmentListView.SetObjects(assignments);
            }
            else
            {
                AssignmentListView.ClearObjects();
            }

            ResponseListView.ClearObjects();
            RMessageBox.Text = "";
        }

        private async void AssignmentListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AssignmentListView.SelectedObject is Assignment selectedAssignment)
            {
                var responses = await _databaseService.GetResponsesAsync(selectedAssignment.Id);
                ResponseListView.SetObjects(responses);
            }
            else
            {
                ResponseListView.ClearObjects();
            }

            RMessageBox.Text = "";
        }

        private async void ResponseListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ResponseListView.SelectedObject is Response selectedResponse)
            {
                RMessageBox.Text = selectedResponse.ResponseText;
            }
            else
            {
                RMessageBox.Text = "";
            }
        }


        /// <summary>
        /// Handles the event for adding Or Editing or deleting a course or Assignment or Response.
        /// Prompts the user for NeededData and adds it to the database.
        /// Refreshes the lists in ObjectListView after adding.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data.</param>
        private async void NewCourseBtn_Click(object sender, EventArgs e)
        {
            string courseName = Prompt.ShowDialog("Enter Course Name:", "New Course");
            string courseDescription = Prompt.ShowDialog("Enter Course Description:", "New Course");

            if (!string.IsNullOrEmpty(courseName) && !string.IsNullOrEmpty(courseDescription))
            {
                await _databaseService.AddCourseAsync(courseName, courseDescription);
                var courses = await _databaseService.GetCoursesAsync();
                CourseListView.SetObjects(courses); // Refresh OLV
                await RefreshAllEditorDataAsync();
            }
        }

        private async void NewAssigmBtn_Click(object sender, EventArgs e)
        {
            if (CourseListView.SelectedObject is Course selectedCourse)
            {
                string assignmentTitle = Prompt.ShowDialog("Enter Assignment Title:", "New Assignment");
                string assignmentDescription = Prompt.ShowDialog("Enter Assignment Description:", "New Assignment");
                string assignmentPositionStr = Prompt.ShowDialog("Enter Assignment Position:", "New Assignment");

                if (!string.IsNullOrEmpty(assignmentTitle) && !string.IsNullOrEmpty(assignmentDescription) && int.TryParse(assignmentPositionStr, out int assignmentPosition))
                {
                    await _databaseService.AddAssignmentAsync(selectedCourse.Id, assignmentTitle, assignmentDescription, assignmentPosition);
                    var assignments = await _databaseService.GetAssignmentsAsync(selectedCourse.Id);
                    AssignmentListView.SetObjects(assignments); // Refresh OLV
                    await RefreshAllEditorDataAsync();
                }
            }
        }

        private async void NewRespBtn_Click(object sender, EventArgs e)
        {
            if (AssignmentListView.SelectedObject is Assignment selectedAssignment)
            {
                string responseTitle = Prompt.ShowDialog("Enter Response Title:", "New Response");
                string responseText = Prompt.ShowDialog("Enter Response Text:", "New Message");
                if (!string.IsNullOrEmpty(responseTitle))
                {
                    await _databaseService.AddResponseAsync(selectedAssignment.Id, responseTitle, responseText);
                    var responses = await _databaseService.GetResponsesAsync(selectedAssignment.Id);
                    ResponseListView.SetObjects(responses); // Refresh OLV
                    RMessageBox.Text = responseText.ToString();
                    await RefreshAllEditorDataAsync();
                }
            }
        }

        private async void DeleteCourseBtn_Click(object sender, EventArgs e)
        {
            if (CourseListView.SelectedObject is Course selectedCourse)
            {
                DialogResult result = MessageBox.Show($"Delete {selectedCourse.CourseName}?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _databaseService.DeleteCourseAsync(selectedCourse.Id);
                    var courses = await _databaseService.GetCoursesAsync();
                    CourseListView.SetObjects(courses); // Refresh OLV
                    AssignmentListView.ClearObjects();
                    ResponseListView.ClearObjects();
                    await RefreshAllEditorDataAsync();
                }
            }
        }

        private async void DeleteAssigmBtn_Click(object sender, EventArgs e)
        {
            if (AssignmentListView.SelectedObject is Assignment selectedAssignment)
            {
                DialogResult result = MessageBox.Show($"Delete {selectedAssignment.AssignmentTitle}?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _databaseService.DeleteAssignmentAsync(selectedAssignment.Id);
                    var assignments = await _databaseService.GetAssignmentsAsync(selectedAssignment.CourseId);
                    AssignmentListView.SetObjects(assignments); // Refresh OLV
                    ResponseListView.ClearObjects();
                    await RefreshAllEditorDataAsync();
                }
            }
        }

        private async void DeleteRespBtn_Click(object sender, EventArgs e)
        {
            if (ResponseListView.SelectedObject is Response selectedResponse)
            {
                DialogResult result = MessageBox.Show($"Delete {selectedResponse.ResponseTitle}?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await _databaseService.DeleteResponseAsync(selectedResponse.Id);
                    var responses = await _databaseService.GetResponsesAsync(selectedResponse.AssignmentId);
                    ResponseListView.SetObjects(responses); // Refresh OLV
                    await RefreshAllEditorDataAsync();
                }
            }
        }

        private async void EditCourseBtn_Click(object sender, EventArgs e)
        {
            if (CourseListView.SelectedObject is Course selectedCourse)
            {
                string newCourseName = Prompt.ShowDialog("Enter New Course Name:", "Edit Course", selectedCourse.CourseName);
                string newCourseDescription = Prompt.ShowDialog("Enter New Course Description:", "Edit Course", selectedCourse.CourseDescription);

                if (!string.IsNullOrEmpty(newCourseName) && !string.IsNullOrEmpty(newCourseDescription))
                {
                    await _databaseService.UpdateCourseAsync(selectedCourse.Id, newCourseName, newCourseDescription);
                    var courses = await _databaseService.GetCoursesAsync();
                    CourseListView.SetObjects(courses); // Refresh OLV
                    await RefreshAllEditorDataAsync();
                }
            }
        }

        private async void EditAssignmentBtn_Click(object sender, EventArgs e)
        {
            if (AssignmentListView.SelectedObject is Assignment selectedAssignment)
            {
                string newAssignmentTitle = Prompt.ShowDialog("Enter New Assignment Title:", "Edit Assignment", selectedAssignment.AssignmentTitle);
                string newAssignmentDescription = Prompt.ShowDialog("Enter New Assignment Description:", "Edit Assignment", selectedAssignment.AssignmentDescription);
                string newAssignmentPositionStr = Prompt.ShowDialog("Enter New Assignment Position:", "Edit Assignment", selectedAssignment.AssignmentPosition.ToString());

                if (!string.IsNullOrEmpty(newAssignmentTitle) && !string.IsNullOrEmpty(newAssignmentDescription) && int.TryParse(newAssignmentPositionStr, out int newAssignmentPosition))
                {
                    await _databaseService.UpdateAssignmentAsync(selectedAssignment.Id, newAssignmentTitle, newAssignmentDescription, newAssignmentPosition);
                    var assignments = await _databaseService.GetAssignmentsAsync(selectedAssignment.CourseId);
                    AssignmentListView.SetObjects(assignments); // Refresh OLV
                    await RefreshAllEditorDataAsync();
                }
            }
        }

        private async void EditResponseBtn_Click(object sender, EventArgs e)
        {
            if (ResponseListView.SelectedObject is Response selectedResponse)
            {
                string newResponseTitle = Prompt.ShowDialog("Enter New Response Title:", "Edit Response", selectedResponse.ResponseTitle);
                string newResponseText = Prompt.ShowDialog("Enter New Message:", "Edit Response", selectedResponse.ResponseText);

                if (!string.IsNullOrEmpty(newResponseTitle) && !string.IsNullOrEmpty(newResponseText))
                {
                    await _databaseService.UpdateResponseAsync(selectedResponse.Id, newResponseTitle, newResponseText);

                    var responses = await _databaseService.GetResponsesAsync(selectedResponse.AssignmentId);
                    ResponseListView.SetObjects(responses);

                    var updatedResponse = responses.FirstOrDefault(r => r.Id == selectedResponse.Id);
                    if (updatedResponse != null)
                    {
                        ResponseListView.SelectObject(updatedResponse); // Select the updated response
                        RMessageBox.Text = updatedResponse.ResponseText; // Update message box immediately
                    }

                    await RefreshAllEditorDataAsync();
                }
            }
        }


        //Copy Text from The message field to clipboard
        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RMessageBox.Text))
            {
                Clipboard.SetText(RMessageBox.Text);
                MessageBox.Show("Text copied to clipboard!");
            }
            else
            {
                MessageBox.Show("No text to copy.");
            }
        }


        /// <summary>
        /// Loads all courses, assignments, and responses into their respective DataGridViews.
        /// </summary>
        private async Task LoadEditorDataAsync()
        {
            try
            {
                // ✅ Load Courses Table
                var courses = await _databaseService.GetCoursesAsync();
                dataGridViewCoursesEditor.DataSource = new BindingSource { DataSource = courses };

                // ✅ Load Assignments Table
                var assignments = await _databaseService.GetAllAssignmentsAsync(); // Fetch all assignments
                dataGridViewAssignmentsEditor.DataSource = new BindingSource { DataSource = assignments };

                // ✅ Load Responses Table
                var responses = await _databaseService.GetAllResponsesAsync(); // 🔥 Fetch all responses
                dataGridViewResponsesEditor.DataSource = new BindingSource { DataSource = responses };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading table data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves changes to the currently selected DataGridView.
        /// </summary>
        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!IsDatabaseOpen()) return;

            switch (TablesTabControl.SelectedTab.Name)
            {
                case "tabPageCourses":
                    await SaveCoursesAsync();
                    await RefreshAllEditorDataAsync();
                    break;
                case "tabPageAssignments":
                    await SaveAssignmentsAsync();
                    await RefreshAllEditorDataAsync();
                    break;
                case "tabPageResponses":
                    await SaveResponsesAsync();
                    await RefreshAllEditorDataAsync();
                    break;
            }
        }

        /// <summary>
        /// Saves changes made in the Courses DataGridView.
        /// </summary>
        private async Task SaveCoursesAsync()
        {
            try
            {
                var courses = (List<Course>)((BindingSource)dataGridViewCoursesEditor.DataSource).DataSource;
                foreach (var course in courses)
                {
                    if (course.Id == 0)
                        await _databaseService.AddCourseAsync(course.CourseName, course.CourseDescription);
                    else
                        await _databaseService.UpdateCourseAsync(course.Id, course.CourseName, course.CourseDescription);
                }

                MessageBox.Show("Courses saved successfully!");
                await RefreshEditorDataAsync(); // 🔥 Refresh without tab switch
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves changes made in the Assignments DataGridView.
        /// </summary>
        private async Task SaveAssignmentsAsync()
        {
            try
            {
                var assignments = (List<Assignment>)((BindingSource)dataGridViewAssignmentsEditor.DataSource).DataSource;
                foreach (var assignment in assignments)
                {
                    if (assignment.Id == 0)
                        await _databaseService.AddAssignmentAsync(assignment.CourseId, assignment.AssignmentTitle, assignment.AssignmentDescription, assignment.AssignmentPosition);
                    else
                        await _databaseService.UpdateAssignmentAsync(assignment.Id, assignment.AssignmentTitle, assignment.AssignmentDescription, assignment.AssignmentPosition);
                }

                MessageBox.Show("Assignments saved successfully!");
                await RefreshEditorDataAsync(); // 🔥 Refresh without tab switch
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving assignments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves changes made in the Responses DataGridView.
        /// </summary>
        private async Task SaveResponsesAsync()
        {
            try
            {
                var responses = (List<Response>)((BindingSource)dataGridViewResponsesEditor.DataSource).DataSource;
                foreach (var response in responses)
                {
                    if (response.Id == 0)
                        await _databaseService.AddResponseAsync(response.AssignmentId, response.ResponseTitle, response.ResponseText);
                    else
                        await _databaseService.UpdateResponseAsync(response.Id, response.ResponseTitle, response.ResponseText);
                }

                MessageBox.Show("Responses saved successfully!");
                await RefreshEditorDataAsync(); // 🔥 Refresh without tab switch
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving responses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles tab switching and reloads data for the selected tab.
        /// </summary>
        private async void TablesTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_databaseService == null)
            {
                return; // Prevent error when no database is open
            }

            await RefreshEditorDataAsync();
            await RefreshAllEditorDataAsync();

        }

        /// <summary>
        /// Refreshes data for the currently selected tab without requiring a tab switch.
        /// </summary>
        private async Task RefreshEditorDataAsync()
        {
            if (!IsDatabaseOpen())
                return;

            switch (TablesTabControl.SelectedTab.Name)
            {
                case "tabPageCourses":
                    var courses = await _databaseService.GetCoursesAsync();
                    dataGridViewCoursesEditor.DataSource = new BindingSource { DataSource = courses };
                    break;

                case "tabPageAssignments":
                    var assignments = await _databaseService.GetAllAssignmentsAsync();
                    dataGridViewAssignmentsEditor.DataSource = new BindingSource { DataSource = assignments };
                    break;

                case "tabPageResponses":
                    var responses = await _databaseService.GetAllResponsesAsync();
                    dataGridViewResponsesEditor.DataSource = new BindingSource { DataSource = responses };
                    break;
            }
        }

        /// <summary>
        /// Enables or disables UI elements based on whether a database is loaded.
        /// </summary>
        private void SetDatabaseState(bool isEnabled)
        {
            if (_databaseService == null || string.IsNullOrWhiteSpace(databasePath))
            {
                Console.WriteLine("Database is null or empty. Disabling UI.");
                isEnabled = false;
            }
            else
            {
                Console.WriteLine("Database is open. Enabling UI.");
            }

            // ✅ Enable/Disable buttons
            NewCourseBtn.Enabled = isEnabled;
            EditCourseBtn.Enabled = isEnabled;
            DeleteCourseBtn.Enabled = isEnabled;

            NewAssigmBtn.Enabled = isEnabled;
            EditAssignmentBtn.Enabled = isEnabled;
            DeleteAssigmBtn.Enabled = isEnabled;

            NewRespBtn.Enabled = isEnabled;
            EditResponseBtn.Enabled = isEnabled;
            DeleteRespBtn.Enabled = isEnabled;

            SaveBtn.Enabled = isEnabled;
            CopyBtn.Enabled = isEnabled;

            // ✅ Enable/Disable ObjectListViews
            CourseListView.Enabled = isEnabled;
            AssignmentListView.Enabled = isEnabled;
            ResponseListView.Enabled = isEnabled;

            dataGridViewCoursesEditor.Enabled = isEnabled;
            dataGridViewAssignmentsEditor.Enabled = isEnabled;
            dataGridViewResponsesEditor.Enabled = isEnabled;

            // ✅ Enable/Disable Tabs
            foreach (TabPage tab in TablesTabControl.TabPages)
            {
                if (tab.Name != "tabPageDatabase") // Prevent disabling database selection tab
                {
                    tab.Enabled = isEnabled;
                }
            }

            TablesTabControl.Enabled = isEnabled; // ✅ Ensure the whole tab control is enabled
            Console.WriteLine($"UI set to {(isEnabled ? "Enabled" : "Disabled")}. Tabs are now {(isEnabled ? "enabled" : "disabled")}.");
        }

        private void TablesTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // Ensure the database is open, otherwise prevent tab switching
            if (!IsDatabaseOpen(false))
            {
                // Double-check your actual tab name in the Designer file
                if (e.TabPage != null && e.TabPage.Name != "Use") // ✅ Ensure correct tab name
                {
                    Console.WriteLine("Preventing tab switch. Database is not open.");
                    e.Cancel = true; // ✅ Prevents tab switching
                    MessageBox.Show("Please open a database first.", "Database Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async Task RefreshAllEditorDataAsync()
        {
            Console.WriteLine("Refreshing all editor data...");

            if (!IsDatabaseOpen())
                return;

            try
            {
                // ✅ Load Courses Table
                var courses = await _databaseService.GetCoursesAsync();
                CourseListView.SetObjects(courses);
                dataGridViewCoursesEditor.DataSource = new BindingSource { DataSource = courses };
                TablesTabControl.SelectedTab.Name = "tabPageCourses";

                // ✅ Load Assignments Table
                var assignments = await _databaseService.GetAllAssignmentsAsync();
                dataGridViewAssignmentsEditor.DataSource = new BindingSource { DataSource = assignments };

                // ✅ Load Responses Table
                var responses = await _databaseService.GetAllResponsesAsync();
                dataGridViewResponsesEditor.DataSource = new BindingSource { DataSource = responses };

                Console.WriteLine("All editor data refreshed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing editor data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
