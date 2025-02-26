using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLeditor
{
    public partial class Form1 : Form
    {
        // Existing fields for your main editing functionality…
        private DatabaseHelper dbHelper;
        private string selectedDatabasePath = "";
        private string selectedResponseId = "";
        private bool isLoadingResponseText = false;
        private readonly SemaphoreSlim dbSemaphore = new SemaphoreSlim(1, 1);

        // Fields for full-table editing (Table Editor)
        private DataTable coursesTable;
        private DataTable assignmentsTable;
        private DataTable responsesTable;
        private SQLiteDataAdapter coursesAdapter;
        private SQLiteDataAdapter assignmentsAdapter;
        private SQLiteDataAdapter responsesAdapter;

        private bool IsDatabaseOpen()
        {
            return !string.IsNullOrEmpty(selectedDatabasePath) && dbHelper != null;
        }

        public Form1()
        {
            InitializeComponent();
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            // Your existing event handler bindings
            CourseDataGridView.SelectionChanged += CourseDataGridView_SelectionChanged;
            AssignmentDataGridView.SelectionChanged += AssignmentDataGridView_SelectionChanged;
            ResponseDataGridView.SelectionChanged += ResponseDataGridView_SelectionChanged;
            CourseDataGridView.CellEndEdit += CourseDataGridView_CellEndEdit;
            AssignmentDataGridView.CellEndEdit += AssignmentDataGridView_CellEndEdit;
            ResponseDataGridView.CellEndEdit += ResponseDataGridView_CellEndEdit;
            TablesTabControl.SelectedIndexChanged += TablesTabControl_SelectedIndexChanged;
            RMessageBox.TextChanged += RMessageBox_TextChanged;
            CourseDataGridView.KeyDown += DataGridView_KeyDown;
            AssignmentDataGridView.KeyDown += DataGridView_KeyDown;
            ResponseDataGridView.KeyDown += DataGridView_KeyDown;


            // Bind Save buttons for the Table Editor if not set in designer
            SaveBtn.Click += SaveBtn_Click;
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

        private async void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQLite Database (*.db)|*.db|All files (*.*)|*.*";
                openFileDialog.Title = "Select SQLite Database";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedDatabasePath = openFileDialog.FileName;
                    dbHelper = new DatabaseHelper(selectedDatabasePath);
                    this.Text = $"SQLeditor | Loaded Database: \"{selectedDatabasePath}\"";
                    await LoadCourses(); // Load courses for your main UI as before
                }
            }
        }

        private async Task LoadCourses()
        {

            try
            {
                CourseDataGridView.Rows.Clear();
                CourseDataGridView.Columns.Clear();
                CourseDataGridView.Columns.Add("CourseName", string.Empty);

                DataTable dt = await dbHelper.ExecuteQueryAsync("SELECT Id, CourseName FROM courses");
                foreach (DataRow row in dt.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(CourseDataGridView, row["CourseName"]);
                    dgvRow.Tag = row["Id"];
                    CourseDataGridView.Rows.Add(dgvRow);
                }
                CourseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                CourseDataGridView.RowHeadersVisible = false;
                CourseDataGridView.ColumnHeadersVisible = false;
                CourseDataGridView.BorderStyle = BorderStyle.None;
                CourseDataGridView.GridColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        private void CourseDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (CourseDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = CourseDataGridView.SelectedRows[0];
                if (selectedRow.Tag != null)
                {
                    string courseId = selectedRow.Tag.ToString();
                    LoadAssignments(courseId);
                }
            }
            else
            {
                AssignmentDataGridView.Rows.Clear();
                ResponseDataGridView.Rows.Clear();
                RMessageBox.Clear();
            }
        }

        private async void LoadAssignments(string courseId)
        {
            try
            {
                AssignmentDataGridView.Rows.Clear();
                AssignmentDataGridView.Columns.Clear();
                AssignmentDataGridView.Columns.Add("AssignmentTitle", string.Empty);

                DataTable dt = await dbHelper.ExecuteQueryAsync("SELECT Id, AssignmentTitle FROM assignments WHERE CourseId = @courseId",
                    new SQLiteParameter[] { new SQLiteParameter("@courseId", courseId) });

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No assignments found for this course.");
                }

                foreach (DataRow row in dt.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(AssignmentDataGridView, row["AssignmentTitle"]);
                    dgvRow.Tag = row["Id"];
                    AssignmentDataGridView.Rows.Add(dgvRow);
                }
                AssignmentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                AssignmentDataGridView.RowHeadersVisible = false;
                AssignmentDataGridView.ColumnHeadersVisible = false;
                AssignmentDataGridView.BorderStyle = BorderStyle.None;
                AssignmentDataGridView.GridColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assignments: " + ex.Message);
            }
        }

        private void AssignmentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (AssignmentDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = AssignmentDataGridView.SelectedRows[0];
                if (selectedRow.Tag != null)
                {
                    string assignmentId = selectedRow.Tag.ToString();
                    LoadResponses(assignmentId);
                }
            }
            else
            {
                ResponseDataGridView.Rows.Clear();
                RMessageBox.Clear();
            }
        }

        private async void LoadResponses(string assignmentId)
        {
            try
            {
                ResponseDataGridView.Rows.Clear();
                ResponseDataGridView.Columns.Clear();
                ResponseDataGridView.Columns.Add("ResponseTitle", string.Empty);

                DataTable dt = await dbHelper.ExecuteQueryAsync(
                    "SELECT Id, ResponseTitle FROM responses WHERE AssignmentId = @assignmentId",
                    new SQLiteParameter[] { new SQLiteParameter("@assignmentId", assignmentId) });

                if (dt.Rows.Count == 0)
                {
                    RMessageBox.Clear();
                }

                foreach (DataRow row in dt.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(ResponseDataGridView, row["ResponseTitle"]);
                    dgvRow.Tag = row["Id"];
                    ResponseDataGridView.Rows.Add(dgvRow);
                }
                ResponseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ResponseDataGridView.RowHeadersVisible = false;
                ResponseDataGridView.ColumnHeadersVisible = false;
                ResponseDataGridView.BorderStyle = BorderStyle.None;
                ResponseDataGridView.GridColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading responses: " + ex.Message);
            }
        }

        private void ResponseDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ResponseDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = ResponseDataGridView.SelectedRows[0];
                if (selectedRow.Tag != null)
                {
                    selectedResponseId = selectedRow.Tag.ToString();
                    LoadResponseText(selectedResponseId);
                }
            }
        }

        private async void LoadResponseText(string responseId)
        {
            try
            {
                isLoadingResponseText = true;
                DataTable dt = await dbHelper.ExecuteQueryAsync("SELECT ResponseText FROM responses WHERE Id = @responseId",
                    new SQLiteParameter[] { new SQLiteParameter("@responseId", responseId) });

                if (dt.Rows.Count > 0)
                {
                    RMessageBox.Text = dt.Rows[0]["ResponseText"].ToString();
                }
                else
                {
                    RMessageBox.Clear();
                    selectedResponseId = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading response text: " + ex.Message);
            }
            finally
            {
                isLoadingResponseText = false;
            }
        }

        // Handle Course Edit
        private async void CourseDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string newCourseName = CourseDataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                string courseId = CourseDataGridView.Rows[e.RowIndex].Tag?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(courseId))
                {
                    await UpdateCourseNameAsync(courseId, newCourseName);
                }
            }
        }

        private async Task UpdateCourseNameAsync(string courseId, string newCourseName)
        {
            await dbSemaphore.WaitAsync();
            try
            {
                await dbHelper.ExecuteNonQueryAsync("UPDATE courses SET CourseName = @courseName WHERE Id = @courseId",
                    new SQLiteParameter[]
                    {
                        new SQLiteParameter("@courseName", newCourseName),
                        new SQLiteParameter("@courseId", courseId)
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating course name: " + ex.Message);
            }
            finally
            {
                dbSemaphore.Release();
            }
        }

        // Handle Assignment Edit
        private async void AssignmentDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string newAssignmentTitle = AssignmentDataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                string assignmentId = AssignmentDataGridView.Rows[e.RowIndex].Tag?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(assignmentId))
                {
                    await UpdateAssignmentTitleAsync(assignmentId, newAssignmentTitle);
                }
            }
        }

        private async Task UpdateAssignmentTitleAsync(string assignmentId, string newAssignmentTitle)
        {
            await dbSemaphore.WaitAsync();
            try
            {
                await dbHelper.ExecuteNonQueryAsync("UPDATE assignments SET AssignmentTitle = @assignmentTitle WHERE Id = @assignmentId",
                    new SQLiteParameter[]
                    {
                        new SQLiteParameter("@assignmentTitle", newAssignmentTitle),
                        new SQLiteParameter("@assignmentId", assignmentId)
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating assignment title: " + ex.Message);
            }
            finally
            {
                dbSemaphore.Release();
            }
        }

        // Handle Response Edit
        private async void ResponseDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ResponseDataGridView.Rows[e.RowIndex].Tag != null)
            {
                string newResponseTitle = ResponseDataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                string responseId = ResponseDataGridView.Rows[e.RowIndex].Tag?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(responseId))
                {
                    await UpdateResponseTitleAsync(responseId, newResponseTitle);
                }
            }
        }

        private async Task UpdateResponseTitleAsync(string responseId, string newResponseTitle)
        {
            await dbSemaphore.WaitAsync();
            try
            {
                await dbHelper.ExecuteNonQueryAsync("UPDATE responses SET ResponseTitle = @responseTitle WHERE Id = @responseId",
                    new SQLiteParameter[]
                    {
                        new SQLiteParameter("@responseTitle", newResponseTitle),
                        new SQLiteParameter("@responseId", responseId)
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating response title: " + ex.Message);
            }
            finally
            {
                dbSemaphore.Release();
            }
        }

        // Handle RMessageBox Text Change
        private async void RMessageBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedResponseId) && !isLoadingResponseText)
            {
                await UpdateResponseTextAsync(selectedResponseId, RMessageBox.Text);
            }
        }

        private async Task UpdateResponseTextAsync(string responseId, string newText)
        {
            await dbSemaphore.WaitAsync();
            try
            {
                await dbHelper.ExecuteNonQueryAsync("UPDATE responses SET ResponseText = @responseText WHERE Id = @responseId",
                    new SQLiteParameter[]
                    {
                        new SQLiteParameter("@responseText", newText),
                        new SQLiteParameter("@responseId", responseId)
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating response text: " + ex.Message);
            }
            finally
            {
                dbSemaphore.Release();
            }
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (!IsDatabaseOpen())
            {
                MessageBox.Show("Please open a database first.");
                return;
            }

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

        private async void NewCourseBtn_Click(object sender, EventArgs e)
        {
            if (!IsDatabaseOpen())
            {
                MessageBox.Show("Please open a database first.");
                return;
            }

            string courseName = Prompt.ShowDialog("Enter Course Name:", "New Course");
            string courseDescription = Prompt.ShowDialog("Enter Course Description:", "New Course");

            if (!string.IsNullOrEmpty(courseName) && !string.IsNullOrEmpty(courseDescription))
            {
                await dbHelper.ExecuteNonQueryAsync(
                    "INSERT INTO courses (CourseName, CourseDescription) VALUES (@courseName, @courseDescription)",
                    new SQLiteParameter[]
                    {
                        new SQLiteParameter("@courseName", courseName),
                        new SQLiteParameter("@courseDescription", courseDescription)
                    });
                MessageBox.Show("New course added successfully!");
                await LoadCourses();
            }
            else
            {
                MessageBox.Show("Course name and description cannot be empty.");
            }
        }

        private async void NewAssigmBtn_Click(object sender, EventArgs e)
        {
            if (!IsDatabaseOpen())
            {
                MessageBox.Show("Please open a database first.");
                return;
            }

            if (CourseDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = CourseDataGridView.SelectedRows[0];
                string courseId = selectedRow.Tag.ToString();

                string assignmentTitle = Prompt.ShowDialog("Enter Assignment Title:", "New Assignment");
                string assignmentDescription = Prompt.ShowDialog("Enter Assignment Description:", "New Assignment");
                string assignmentPosition = Prompt.ShowDialog("Enter Assignment Position:", "New Assignment");

                if (!string.IsNullOrEmpty(assignmentTitle) && !string.IsNullOrEmpty(assignmentDescription))
                {
                    await dbHelper.ExecuteNonQueryAsync(
                        "INSERT INTO assignments (AssignmentTitle, AssignmentDescription, AssignmentPosition, CourseId) VALUES (@assignmentTitle, @assignmentDescription, @assignmentPosition, @courseId)",
                        new SQLiteParameter[]
                        {
                            new SQLiteParameter("@assignmentTitle", assignmentTitle),
                            new SQLiteParameter("@assignmentDescription", assignmentDescription),
                            new SQLiteParameter("@assignmentPosition", assignmentPosition),
                            new SQLiteParameter("@courseId", courseId)
                        });
                    MessageBox.Show("New assignment added successfully!");
                    LoadAssignments(courseId);
                }
                else
                {
                    MessageBox.Show("Assignment title and description cannot be empty.");
                }
            }
            else
            {
                MessageBox.Show("Please select a course first.");
            }
        }

        private async void NewRespBtn_Click(object sender, EventArgs e)
        {
            if (!IsDatabaseOpen())
            {
                MessageBox.Show("Please open a database first.");
                return;
            }

            if (AssignmentDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = AssignmentDataGridView.SelectedRows[0];
                string assignmentId = selectedRow.Tag.ToString();

                string responseTitle = Prompt.ShowDialog("Enter Response Title:", "New Response");
                string responseText = Prompt.ShowDialog("Enter Response Text:", "New Response");

                if (!string.IsNullOrEmpty(responseTitle) && !string.IsNullOrEmpty(responseText))
                {
                    await dbHelper.ExecuteNonQueryAsync(
                        "INSERT INTO responses (ResponseTitle, ResponseText, AssignmentId) VALUES (@responseTitle, @responseText, @assignmentId)",
                        new SQLiteParameter[]
                        {
                            new SQLiteParameter("@responseTitle", responseTitle),
                            new SQLiteParameter("@responseText", responseText),
                            new SQLiteParameter("@assignmentId", assignmentId)
                        });
                    MessageBox.Show("New response added successfully!");
                    LoadResponses(assignmentId);
                }
                else
                {
                    MessageBox.Show("Response title and text cannot be empty.");
                }
            }
            else
            {
                MessageBox.Show("Please select an assignment first.");
            }
        }

        private async void DeleteCourseBtn_Click(object sender, EventArgs e)
        {
            if (!IsDatabaseOpen())
            {
                MessageBox.Show("Please open a database first.");
                return;
            }

            if (CourseDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = CourseDataGridView.SelectedRows[0];
                string courseId = selectedRow.Tag?.ToString() ?? string.Empty;

                if (!string.IsNullOrEmpty(courseId))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this course and all related assignments and responses?",
                                                          "Delete Course",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        await dbHelper.ExecuteNonQueryAsync(
                            "DELETE FROM responses WHERE AssignmentId IN (SELECT Id FROM assignments WHERE CourseId = @courseId); " +
                            "DELETE FROM assignments WHERE CourseId = @courseId; " +
                            "DELETE FROM courses WHERE Id = @courseId;",
                            new SQLiteParameter[] { new SQLiteParameter("@courseId", courseId) });

                        MessageBox.Show("Course and all related assignments and responses deleted successfully.");
                        RMessageBox.Clear();
                        await LoadCourses();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a course to delete.");
            }
        }

        private async void DeleteAssigmBtn_Click(object sender, EventArgs e)
        {
            if (!IsDatabaseOpen())
            {
                MessageBox.Show("Please open a database first.");
                return;
            }

            if (AssignmentDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = AssignmentDataGridView.SelectedRows[0];
                string assignmentId = selectedRow.Tag?.ToString() ?? string.Empty;

                if (!string.IsNullOrEmpty(assignmentId))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this assignment and all related responses?",
                                                          "Delete Assignment",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        await dbHelper.ExecuteNonQueryAsync(
                            "DELETE FROM responses WHERE AssignmentId = @assignmentId; " +
                            "DELETE FROM assignments WHERE Id = @assignmentId;",
                            new SQLiteParameter[] { new SQLiteParameter("@assignmentId", assignmentId) });

                        MessageBox.Show("Assignment and all related responses deleted successfully.");
                        RMessageBox.Clear();
                        LoadAssignments(CourseDataGridView.SelectedRows[0].Tag.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an assignment to delete.");
            }
        }

        private async void DeleteRespBtn_Click(object sender, EventArgs e)
        {
            if (!IsDatabaseOpen())
            {
                MessageBox.Show("Please open a database first.");
                return;
            }

            if (ResponseDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = ResponseDataGridView.SelectedRows[0];
                string responseId = selectedRow.Tag?.ToString() ?? string.Empty;

                if (!string.IsNullOrEmpty(responseId))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this response?", "Delete Response", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        await dbHelper.ExecuteNonQueryAsync(
                            "DELETE FROM responses WHERE Id = @responseId",
                            new SQLiteParameter[] { new SQLiteParameter("@responseId", responseId) });

                        MessageBox.Show("Response deleted successfully.");
                        RMessageBox.Clear();
                        // Refresh responses for the currently selected assignment
                        if (AssignmentDataGridView.SelectedRows.Count > 0)
                        {
                            LoadResponses(AssignmentDataGridView.SelectedRows[0].Tag.ToString());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a response to delete.");
            }
        }

        private async Task LoadEditorDataAsync()
        {
            try
            {
                // Load courses table
                coursesTable = await dbHelper.ExecuteQueryAsync("SELECT * FROM courses");
                dataGridViewCoursesEditor.DataSource = coursesTable;
                dataGridViewCoursesEditor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewCoursesEditor.AutoGenerateColumns = true; // Ensure columns are auto-generated

                // Load assignments table
                assignmentsTable = await dbHelper.ExecuteQueryAsync("SELECT * FROM assignments");
                dataGridViewAssignmentsEditor.DataSource = assignmentsTable;
                dataGridViewAssignmentsEditor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewAssignmentsEditor.AutoGenerateColumns = true;

                // Load responses table
                responsesTable = await dbHelper.ExecuteQueryAsync("SELECT * FROM responses");
                dataGridViewResponsesEditor.DataSource = responsesTable;
                dataGridViewResponsesEditor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewResponsesEditor.AutoGenerateColumns = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading table data: " + ex.Message);
            }
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!IsDatabaseOpen())
            {
                MessageBox.Show("Please open a database first.");
                return;
            }
                
            if (TablesTabControl.SelectedTab == tabPageCourses)
            {
                await SaveCoursesAsync();
            }
            else if (TablesTabControl.SelectedTab == tabPageAssignments)
            {
                await SaveAssignmentsAsync();
            }
            else if (TablesTabControl.SelectedTab == tabPageResponses)
            {
                await SaveResponsesAsync();
            }
        }

        private async Task SaveCoursesAsync()
        {
            try
            {
                // Create a data adapter and command builder for courses
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM courses", dbHelper.ConnectionString);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
                await Task.Run(() => adapter.Update(coursesTable));
                MessageBox.Show("Courses saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving courses: " + ex.Message);
            }
        }

        private async Task SaveAssignmentsAsync()
        {
            try
            {
                // Create a data adapter and command builder for assignments
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM assignments", dbHelper.ConnectionString);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
                await Task.Run(() => adapter.Update(assignmentsTable));
                MessageBox.Show("Assignments saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving assignments: " + ex.Message);
            }
        }

        private async Task SaveResponsesAsync()
        {
            try
            {
                // Create a data adapter and command builder for responses
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM responses", dbHelper.ConnectionString);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
                await Task.Run(() => adapter.Update(responsesTable));
                MessageBox.Show("Responses saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving responses: " + ex.Message);
            }
        }

        private async void TablesTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsDatabaseOpen())
            {
                MessageBox.Show("Please open a database first.");
                return;
            }

            // Assume the editor tabs are named: tabPageCourses, tabPageAssignments, tabPageResponses.
            // Adjust as needed.
            if (TablesTabControl.SelectedTab == tabPageCourses ||
                TablesTabControl.SelectedTab == tabPageAssignments ||
                TablesTabControl.SelectedTab == tabPageResponses)
            {
                await LoadEditorDataAsync();
            }
        }
    }
}
