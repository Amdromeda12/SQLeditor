using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLeditor.Models;
using Serilog;
using System.Diagnostics;
using System.Linq;
using SQLeditor.Services;

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
            switch (form.TablesTabControl.SelectedTab.Name)
            {
                case "tabPageCourses":
                    await SaveCoursesAsync(form, databaseService);
                    break;
                case "tabPageAssignments":
                    await SaveAssignmentsAsync(form, databaseService);
                    break;
                case "tabPageResponses":
                    await SaveResponsesAsync(form, databaseService);
                    break;
            }
        }

        private static async Task SaveCoursesAsync(Form1 form, DatabaseService databaseService)
        {
            var courses = (System.Collections.Generic.List<Course>)form.dataGridViewCoursesEditor.DataSource;
            foreach (var course in courses)
            {
                if (course.Id == 0)
                    await databaseService.AddCourseAsync(course.CourseName, course.CourseDescription);
                else
                    await databaseService.UpdateCourseAsync(course.Id, course.CourseName, course.CourseDescription);
            }
            await LoadCoursesAsync(form, databaseService);
        }

        private static async Task SaveAssignmentsAsync(Form1 form, DatabaseService databaseService)
        {
            var assignments = (System.Collections.Generic.List<Assignment>)form.dataGridViewAssignmentsEditor.DataSource;
            foreach (var assignment in assignments)
            {
                if (assignment.Id == 0)
                    await databaseService.AddAssignmentAsync(assignment.CourseId, assignment.AssignmentTitle, assignment.AssignmentDescription, assignment.AssignmentPosition);
                else
                    await databaseService.UpdateAssignmentAsync(assignment.Id, assignment.AssignmentTitle, assignment.AssignmentDescription, assignment.AssignmentPosition);
            }
        }

        private static async Task SaveResponsesAsync(Form1 form, DatabaseService databaseService)
        {
            var responses = (System.Collections.Generic.List<Response>)form.dataGridViewResponsesEditor.DataSource;
            foreach (var response in responses)
            {
                if (response.Id == 0)
                    await databaseService.AddResponseAsync(response.AssignmentId, response.ResponseTitle, response.ResponseText);
                else
                    await databaseService.UpdateResponseAsync(response.Id, response.ResponseTitle, response.ResponseText);
            }
        }

    }
}