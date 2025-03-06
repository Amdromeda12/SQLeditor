using System;
using System.Drawing;
using System.Windows.Forms;
using Serilog;
using SQLeditor.Models;

namespace SQLeditor.Services
{
    public static class UIHelper
    {
        public static void SetDatabaseState(Form1 form, bool isEnabled)
        {
            if (form == null) return;
            isEnabled &= !string.IsNullOrWhiteSpace(form.DatabasePath);

            form.NewCourseBtn.Enabled = isEnabled;
            form.EditCourseBtn.Enabled = isEnabled;
            form.DeleteCourseBtn.Enabled = isEnabled;
            form.NewAssigmBtn.Enabled = isEnabled;
            form.EditAssignmentBtn.Enabled = isEnabled;
            form.DeleteAssigmBtn.Enabled = isEnabled;
            form.NewRespBtn.Enabled = isEnabled;
            form.EditResponseBtn.Enabled = isEnabled;
            form.DeleteRespBtn.Enabled = isEnabled;
            form.SaveBtn.Enabled = isEnabled;
            form.CopyBtn.Enabled = isEnabled;
            form.TablesTabControl.Enabled = isEnabled;
            form.btnSortAssignments.Enabled = isEnabled;

            Log.Information($"Database state set to {(isEnabled ? "Enabled" : "Disabled")}");
        }

        public static void InitializeObjectListViews(Form1 form)
        {
            form.CourseListView = new BrightIdeasSoftware.ObjectListView();
            form.AssignmentListView = new BrightIdeasSoftware.ObjectListView();
            form.ResponseListView = new BrightIdeasSoftware.ObjectListView();

            // Define a better font (e.g., Segoe UI, 12pt for readability)
            Font customFont = new Font("Segoe UI", 12, FontStyle.Regular);

            foreach (var olv in new[] { form.CourseListView, form.AssignmentListView, form.ResponseListView })
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
            form.CourseListView.AllColumns.Add(new BrightIdeasSoftware.OLVColumn { AspectName = "CourseName", FillsFreeSpace = true });
            form.AssignmentListView.AllColumns.Add(new BrightIdeasSoftware.OLVColumn { AspectName = "AssignmentTitle", FillsFreeSpace = true });
            form.ResponseListView.AllColumns.Add(new BrightIdeasSoftware.OLVColumn { AspectName = "ResponseTitle", FillsFreeSpace = true });

            // Apply the column configuration
            form.CourseListView.RebuildColumns();
            form.AssignmentListView.RebuildColumns();
            form.ResponseListView.RebuildColumns();

            // Add OLVs to the existing UI panels in the "Use" tab
            form.panelCourses.Controls.Add(form.CourseListView);
            form.panelAssignments.Controls.Add(form.AssignmentListView);
            form.panelResponses.Controls.Add(form.ResponseListView);
        }
    }
}

