using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;
using SQLeditor.Models;
using SQLeditor.Services;

namespace SQLeditor.Services
{
    public class DatabaseService
    {
        public string DatabasePath { get; set; }

        private readonly string _connectionString;

        public DatabaseService(string databasePath)
        {
            if (string.IsNullOrWhiteSpace(databasePath))
            {
                databasePath = ":memory:"; // Use an in-memory database if no path is provided
            }
            _connectionString = $"Data Source={databasePath};Version=3;";
        }

        private SQLiteConnection GetConnection() => new SQLiteConnection(_connectionString);

        // ✅ GET COURSES
        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Course>("SELECT Id, CourseName, CourseDescription FROM courses");
            }
        }

        // ✅ GET ASSIGNMENTS
        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync(int courseId)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Assignment>(
                    "SELECT Id, CourseId, AssignmentTitle, AssignmentDescription, AssignmentPosition FROM assignments WHERE CourseId = @CourseId",
                    new { CourseId = courseId }
                );
            }
        }

        // ✅ GET RESPONSES
        public async Task<IEnumerable<Response>> GetResponsesAsync(int assignmentId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    await conn.OpenAsync();
                    return await conn.QueryAsync<Response>(
                        "SELECT Id, AssignmentId, ResponseTitle, ResponseText FROM responses WHERE AssignmentId = @AssignmentId",
                        new { AssignmentId = assignmentId }
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching responses: {ex.Message}");
                return new List<Response>();
            }
        }

        // ✅ GET SINGLE RESPONSE 
        public async Task<Response> GetResponseByIdAsync(int responseId)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Response>(
                    "SELECT Id, AssignmentId, ResponseTitle, ResponseText FROM responses WHERE Id = @Id",
                    new { Id = responseId }
                );
            }
        }

        // ✅ ADD COURSE
        public async Task<int> AddCourseAsync(string courseName, string courseDescription)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                return await conn.ExecuteScalarAsync<int>(
                    "INSERT INTO courses (CourseName, CourseDescription) VALUES (@CourseName, @CourseDescription); SELECT last_insert_rowid();",
                    new { CourseName = courseName, CourseDescription = courseDescription }
                );
            }
        }

        // ✅ UPDATE COURSE
        public async Task<bool> UpdateCourseAsync(int id, string newCourseName, string newCourseDescription)
        {
            using (var conn = GetConnection())
            {
                Debug.WriteLine($"🔹 Database Path in UpdateCourseAsync: {conn.ConnectionString}");

                if (string.IsNullOrWhiteSpace(conn.ConnectionString))
                {
                    throw new InvalidOperationException("Database path is not set. Please select a database first.");
                }

                await conn.OpenAsync();

                var affectedRows = await conn.ExecuteAsync(
                    "UPDATE courses SET CourseName = @NewCourseName, CourseDescription = @NewCourseDescription WHERE Id = @Id",
                    new { Id = id, NewCourseName = newCourseName, NewCourseDescription = newCourseDescription }
                );

                return affectedRows > 0;
            }
        }

        // ✅ DELETE COURSE
        public async Task<bool> DeleteCourseAsync(int id)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                var affectedRows = await conn.ExecuteAsync(@"
                DELETE FROM responses WHERE AssignmentId IN (SELECT Id FROM assignments WHERE CourseId = @Id);
                DELETE FROM assignments WHERE CourseId = @Id;
                DELETE FROM courses WHERE Id = @Id;",
                    new { Id = id }
                );

                if (affectedRows > 0)
                {
                    await ResetAutoIncrementAsync("courses");
                    await ResetAutoIncrementAsync("assignments");
                    await ResetAutoIncrementAsync("responses");
                }

                return affectedRows > 0;
            }
        }

        // ✅ ADD ASSIGNMENT 
        public async Task<int> AddAssignmentAsync(int courseId, string assignmentTitle, string assignmentDescription, int assignmentPosition)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                return await conn.ExecuteScalarAsync<int>(
                    "INSERT INTO assignments (CourseId, AssignmentTitle, AssignmentDescription, AssignmentPosition) VALUES (@CourseId, @AssignmentTitle, @AssignmentDescription, @AssignmentPosition); SELECT last_insert_rowid();",
                    new { CourseId = courseId, AssignmentTitle = assignmentTitle, AssignmentDescription = assignmentDescription, AssignmentPosition = assignmentPosition }
                );
            }
        }

        // ✅ UPDATE ASSIGNMENT
        public async Task<bool> UpdateAssignmentAsync(int id, string newAssignmentTitle, string newAssignmentDescription, int newAssignmentPosition)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                var affectedRows = await conn.ExecuteAsync(
                    "UPDATE assignments SET AssignmentTitle = @NewAssignmentTitle, AssignmentDescription = @NewAssignmentDescription, AssignmentPosition = @NewAssignmentPosition WHERE Id = @Id",
                    new { Id = id, NewAssignmentTitle = newAssignmentTitle, NewAssignmentDescription = newAssignmentDescription, NewAssignmentPosition = newAssignmentPosition }
                );
                return affectedRows > 0;
            }
        }

        // ✅ DELETE ASSIGNMENT
        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                var affectedRows = await conn.ExecuteAsync(@"
                DELETE FROM responses WHERE AssignmentId = @Id;
                DELETE FROM assignments WHERE Id = @Id;",
                    new { Id = id }
                );

                if (affectedRows > 0)
                {
                    await ResetAutoIncrementAsync("assignments");
                    await ResetAutoIncrementAsync("responses");
                }

                return affectedRows > 0;
            }
        }

        // ✅ ADD RESPONSE 
        public async Task<int> AddResponseAsync(int assignmentId, string responseTitle, string responseText)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                return await conn.ExecuteScalarAsync<int>(
                    "INSERT INTO responses (AssignmentId, ResponseTitle, ResponseText) VALUES (@AssignmentId, @ResponseTitle, @ResponseText); SELECT last_insert_rowid();",
                    new { AssignmentId = assignmentId, ResponseTitle = responseTitle, ResponseText = responseText }
                );
            }
        }

        // ✅ UPDATE RESPONSE
        public async Task<bool> UpdateResponseAsync(int id, string newResponseTitle, string newResponseText)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                var affectedRows = await conn.ExecuteAsync(
                    "UPDATE responses SET ResponseTitle = @NewResponseTitle, ResponseText = @NewResponseText WHERE Id = @Id",
                    new { Id = id, NewResponseTitle = newResponseTitle, NewResponseText = newResponseText }
                );
                return affectedRows > 0;
            }
        }

        // ✅ DELETE RESPONSE
        public async Task<bool> DeleteResponseAsync(int id)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                var affectedRows = await conn.ExecuteAsync(
                    "DELETE FROM responses WHERE Id = @Id",
                    new { Id = id }
                );

                if (affectedRows > 0)
                {
                    await ResetAutoIncrementAsync("responses");
                }

                return affectedRows > 0;
            }
        }

        // ✅ GET ALL ASSIGNMENTS (Fetches All Assignments Without Filtering)
        public async Task<IEnumerable<Assignment>> GetAllAssignmentsAsync()
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Assignment>(
                    "SELECT Id, CourseId, AssignmentTitle, AssignmentDescription, AssignmentPosition FROM assignments"
                );
            }
        }

        // ✅ GET ALL RESPONSES (Fetches All Responses Without Filtering)
        public async Task<IEnumerable<Response>> GetAllResponsesAsync()
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Response>(
                    "SELECT Id, AssignmentId, ResponseTitle, ResponseText FROM responses"
                );
            }
        }

        public async Task ResetAutoIncrementAsync(string tableName)
        {
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                string resetQuery = $"DELETE FROM sqlite_sequence WHERE name = @TableName";
                await conn.ExecuteAsync(resetQuery, new { TableName = tableName });
            }
        }
    }
}