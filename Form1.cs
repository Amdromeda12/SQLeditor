using System;
using System.Windows.Forms;
using Serilog;
using SQLeditor.Services;
using SQLeditor.Models;
using System.Drawing;
using System.Diagnostics;

namespace SQLeditor
{
    public partial class Form1 : Form
    {
        public DatabaseService DatabaseService { get; set; }
        public string DatabasePath { get; set; } = "";

        public int SelectedCourseId { get; set; } // Track the selected course ID

        private readonly EventHandlers _eventHandlers;

        public Form1(DatabaseService databaseService)
        {
            DatabaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            InitializeComponent();

            _eventHandlers = new EventHandlers(this, DatabaseService);

            InitializeUI();
            InitializeEventHandlers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log.Information("Form1 loaded.");
            UIHelper.SetDatabaseState(this, false);
        }

        private void InitializeEventHandlers()
        {
            // ✅ Menu Events
            openDatabaseToolStripMenuItem.Click += _eventHandlers.OpenDatabaseToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += _eventHandlers.ExitToolStripMenuItem_Click;

            // ✅ Button Clicks
            SaveBtn.Click += _eventHandlers.SaveBtn_Click;
            CopyBtn.Click += _eventHandlers.CopyBtn_Click;
            NewCourseBtn.Click += _eventHandlers.NewCourseBtn_Click;
            EditCourseBtn.Click += _eventHandlers.EditCourseBtn_Click;
            DeleteCourseBtn.Click += _eventHandlers.DeleteCourseBtn_Click;
            NewAssigmBtn.Click += _eventHandlers.NewAssigmBtn_Click;
            EditAssignmentBtn.Click += _eventHandlers.EditAssignmentBtn_Click;
            DeleteAssigmBtn.Click += _eventHandlers.DeleteAssigmBtn_Click;
            NewRespBtn.Click += _eventHandlers.NewRespBtn_Click;
            EditResponseBtn.Click += _eventHandlers.EditResponseBtn_Click;
            DeleteRespBtn.Click += _eventHandlers.DeleteRespBtn_Click;

            // ✅ Tab Events
            TablesTabControl.Selecting += TablesTabControl_Selecting;
            TablesTabControl.SelectedIndexChanged += TablesTabControl_SelectedIndexChanged;

            //✅ Choosing item in objectlistview
            CourseListView.SelectedIndexChanged += _eventHandlers.CourseListView_SelectedIndexChanged;
            AssignmentListView.SelectedIndexChanged += _eventHandlers.AssignmentListView_SelectedIndexChanged;
            ResponseListView.SelectedIndexChanged += _eventHandlers.ResponseListView_SelectedIndexChanged;

            // ✅ Attach event handlers for Buttons
            SaveBtn.Click += _eventHandlers.SaveBtn_Click;

            btnSortAssignments.Click += (sender, e) => _eventHandlers.BtnSortAssignments_Click(sender, e, SelectedCourseId);
        }

        private void InitializeUI()
        {
            UIHelper.InitializeObjectListViews(this); // ✅ Ensure UIHelper sets up OLVs
        }

        /// <summary>
        /// Configures ObjectListView with default settings.
        /// </summary>


        /// <summary>
        /// Prevents switching tabs if no database is open.
        /// </summary>
        private void TablesTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DatabasePath))
            {
                e.Cancel = true;
                MessageBox.Show("Please open a database first.", "Database Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Refreshes data when switching tabs.
        /// </summary>
        private async void TablesTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            await DataLoader.LoadEditorDataAsync(this, DatabaseService);
        }
 
    }
}