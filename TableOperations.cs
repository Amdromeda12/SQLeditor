using System.Data;
using System.Data.SQLite;

namespace SQLDatabaseViewer
{
    public partial class Form1 : Form
    {
        // Method to create a new SQLite database file with the provided table schema
        private void CreateNewDatabase(string filePath, DataTable tableSchema)
        {
            // Check if the table schema is valid
            if (tableSchema == null || tableSchema.Columns.Count == 0)
            {
                MessageBox.Show("Table schema is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                var connectionString = $"Data Source={filePath};Version=3;";
                // Create a new SQLite database file at the specified path
                SQLiteConnection.CreateFile(filePath);

                using var connection = new SQLiteConnection(connectionString);
                connection.Open();

                var tableName = tableSchema.TableName;
                var createTableQuery = $"CREATE TABLE \"{tableName}\" (";
                var primaryKeyColumns = string.Join(", ", tableSchema.PrimaryKey.Select(col => $"\"{col.ColumnName}\""));

                // Iterate through each column in the table schema
                foreach (DataColumn column in tableSchema.Columns)
                {
                    var columnName = column.ColumnName;
                    var columnType = columnDataTypes.ContainsKey(columnName) ? columnDataTypes[columnName] : "TEXT";

                    // Append the column definition to the create table query
                    createTableQuery += $"\"{columnName}\" {columnType}, ";
                }

                // If primary key columns exist, append them to the create table query
                if (!string.IsNullOrEmpty(primaryKeyColumns))
                {
                    createTableQuery += $"PRIMARY KEY ({primaryKeyColumns}), ";
                }

                // Trim excess comma and space and close the parentheses
                createTableQuery = createTableQuery.TrimEnd(',', ' ') + ")";

                // Execute the create table query
                using var command = new SQLiteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("New database file created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
