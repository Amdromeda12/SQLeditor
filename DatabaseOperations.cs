using System.Data;
using System.Data.SQLite;

namespace SQLDatabaseViewer
{
    public partial class Form1 : Form
    {
        // Method to retrieve all table names from a SQLite database
        private List<string> GetAllTableNames(SQLiteConnection connection)
        {
            var tableNames = new List<string>();
            using (var table = connection.GetSchema("Tables"))
            {
                foreach (DataRow row in table.Rows)
                {
                    tableNames.Add(row["TABLE_NAME"].ToString());
                }
            }
            return tableNames;
        }

        // Method to retrieve primary key column names of a table in a SQLite database
        private string[] GetPrimaryKeys(string tableName)
        {
            var primaryKeys = new List<string>();
            using (var conn = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand($"PRAGMA table_info({tableName})", conn))
            {
                conn.Open();
                using var reader = command.ExecuteReader();
                // Iterate through the result set and add primary key column names to the list
                while (reader.Read())
                {
                    if (Convert.ToInt64(reader["pk"]) == 1)
                    {
                        primaryKeys.Add(reader["name"].ToString());
                    }
                }
            }
            return [.. primaryKeys];
        }

        // Method to load data from a SQLite database file and display it in a DataGridView
        // Method to load data from a SQLite database file and display it in a DataGridView
        private void LoadDataFromSQLite(string databaseFilePath)
        {
            // Check if the database file exists
            if (!File.Exists(databaseFilePath))
            {
                MessageBox.Show("Database file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Construct the connection string
                connectionString = $"Data Source={databaseFilePath};Version=3;";

                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                var tableNames = GetAllTableNames(conn);

                // Check if any tables exist in the database
                if (tableNames.Count == 0)
                {
                    MessageBox.Show("No tables found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Populate ComboBox with table names (new functionality)
                PopulateComboBoxWithTables(tableNames);

                // Load the first table by default (keeping existing functionality)
                var tableName = tableNames[0];
                var query = $"SELECT * FROM {tableName}";
                var dataAdapter = new SQLiteDataAdapter(query, conn);
                var dataTable = new DataTable { TableName = tableName };

                // Fill the DataTable schema and data
                dataAdapter.FillSchema(dataTable, SchemaType.Source);
                dataAdapter.Fill(dataTable);
                dataTable.AcceptChanges();

                // Populate the column data types dictionary
                foreach (DataColumn column in dataTable.Columns)
                {
                    columnDataTypes[column.ColumnName] = column.DataType.ToString();
                }

                // Set the DataGridView's data source to the loaded DataTable
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data from SQLite database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
