using System.Data;
using System.Data.SQLite;

namespace SQLDatabaseViewer
{
    public partial class Form1 : Form
    {
        // Method to handle the click event of the Open File button
        public static void OpenFileButton_Click(Form1 form)
        {
            // Open file dialog to select SQLite database file
            var openFileDialog = new OpenFileDialog
            {
                Filter = "SQLite Database File (*.db;*.sqlite)|*.db;*.sqlite|All files (*.*)|*.*",
                Title = "Select SQLite Database File"
            };
            openFileDialog.ShowDialog();

            // Update selected file path and load data from SQLite file
            form.SelectedFile = openFileDialog.FileName;
            if (!string.IsNullOrEmpty(form.SelectedFile))
            {
                form.LoadDataFromSQLite(form.SelectedFile);
            }
        }

        // Method to handle the click event of the Update Data button
        public static void UpdateDataButton_Click(Form1 form)
        {
            // Check if there is data to update
            if (form.dataGridView1.DataSource is not DataTable dataTable || dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No data to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Retrieve primary key columns and validate
            var primaryKeys = form.GetPrimaryKeys(dataTable.TableName);
            if (primaryKeys.Length != 1)
            {
                MessageBox.Show(primaryKeys.Length == 0 ? "No primary key column found." : "Multiple primary key columns found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var primaryKey = primaryKeys[0];

            try
            {
                // Open connection to SQLite database
                using var conn = new SQLiteConnection(Form1.connectionString);
                conn.Open();

                // Iterate through each row in the data table
                foreach (DataRow row in dataTable.Rows)
                {
                    // Check if row is added or modified
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    {
                        // Construct SQL command for insert or update
                        var updateCommandText = $"INSERT OR REPLACE INTO {dataTable.TableName} (";
                        var values = new List<string>();

                        // Iterate through columns to construct command
                        for (var i = 0; i < dataTable.Columns.Count; i++)
                        {
                            updateCommandText += $"{dataTable.Columns[i].ColumnName}";
                            values.Add($"@{dataTable.Columns[i].ColumnName}");
                            updateCommandText += i < dataTable.Columns.Count - 1 ? ", " : ") VALUES (";
                        }

                        updateCommandText += string.Join(", ", values) + ");";

                        // Execute command
                        using var updateCommand = new SQLiteCommand(updateCommandText, conn);
                        for (var i = 0; i < dataTable.Columns.Count; i++)
                        {
                            updateCommand.Parameters.AddWithValue($"@{dataTable.Columns[i].ColumnName}", row[dataTable.Columns[i].ColumnName]);
                        }

                        updateCommand.ExecuteNonQuery();
                    }
                    // Check if row is deleted
                    else if (row.RowState == DataRowState.Deleted)
                    {
                        // Construct SQL command for delete
                        var deleteCommandText = $"DELETE FROM {dataTable.TableName} WHERE {primaryKey} = @PrimaryKey";
                        using var deleteCommand = new SQLiteCommand(deleteCommandText, conn);
                        deleteCommand.Parameters.AddWithValue("@PrimaryKey", row[primaryKey, DataRowVersion.Original]);
                        deleteCommand.ExecuteNonQuery();
                    }
                }

                // Show success message and reload data
                MessageBox.Show("Changes updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!string.IsNullOrEmpty(form.SelectedFile))
                {
                    form.LoadDataFromSQLite(form.SelectedFile);
                }
            }
            catch (Exception ex)
            {
                // Show error message if update fails
                MessageBox.Show($"Error updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to handle the click event of the Save Database button
        public static void SaveDatabaseButton_Click(Form1 form)
        {
            // Get file name from text box and validate
            var fileName = form.textBox1.Text.Trim();
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Please enter a valid file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!fileName.EndsWith(".db") && !fileName.EndsWith(".sqlite"))
            {
                fileName += ".db";
            }

            // Show save file dialog to choose location
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "SQLite Database File (*.db;*.sqlite)|*.db;*.sqlite|All files (*.*)|*.*",
                Title = "Save SQLite Database File",
                FileName = fileName
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get file path and create new database
                var filePath = saveFileDialog.FileName;
                form.CreateNewDatabase(filePath, form.dataGridView2.DataSource as DataTable);
            }
        }

        // Method to handle the click event of the Add Column button
        public static void AddColumnButton_Click(Form1 form)
        {
            // Get column name and data type from text boxes
            var dataType = form.textBox4.Text.Trim();
            var columnName = form.textBox2.Text.Trim();
            if (string.IsNullOrEmpty(columnName))
            {
                MessageBox.Show("Please enter a column name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add new column to data table and refresh grid view
            var newColumn = new DataColumn(columnName, typeof(object));
            if (!string.IsNullOrEmpty(dataType))
            {
                columnDataTypes[columnName] = dataType;
            }

            form.tableSchema.Columns.Add(newColumn);
            form.dataGridView2.Refresh();
        }

        // Method to handle the click event of the Change Table Name button
        public static void ChangeTableNameButton_Click(Form1 form)
        {
            // Get new table name from text box and validate
            var newTableName = form.textBox3.Text.Trim();
            if (string.IsNullOrEmpty(newTableName))
            {
                MessageBox.Show("Please enter a valid table name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update table name and refresh grid view
            form.tableSchema.TableName = newTableName;
            form.dataGridView2.Refresh();
        }
        // Method to search a Database
        public static void SearchButton_Click(Form1 form)
        {
            // Get the search value from a text box
            string searchValue = form.textBox5.Text.Trim();

            // Check if the search value is empty
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Please enter a search value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the data source of dataGridView1
            if (form.dataGridView1.DataSource is not DataTable dataTable)
            {
                MessageBox.Show("No data to search.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Clear the current selection
            form.dataGridView1.ClearSelection();

            // Filter the data table to show only matching rows
            DataTable filteredDataTable = dataTable.Clone();
            foreach (DataRow row in dataTable.Rows)
            {
                // Iterate through each cell in the row
                foreach (var item in row.ItemArray)
                {
                    if (item.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                    {
                        // Add the row to the filtered data table
                        filteredDataTable.ImportRow(row);
                        break; // Break after finding a match in this row
                    }
                }
            }

            // Update the data source of dataGridView1 to show only the filtered rows
            form.dataGridView1.DataSource = filteredDataTable;

            // If no matching value is found, show a message
            if (filteredDataTable.Rows.Count == 0)
            {
                MessageBox.Show("No matching value found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
