using System.Data;
using System.Data.SQLite;

namespace SQLDatabaseViewer
{
    public partial class Form1 : Form
    {
        public static string connectionString;
        public static Dictionary<string, string> columnDataTypes = new Dictionary<string, string>();
        public string SelectedFile { get; set; }
        private DataTable tableSchema;

        // Constructor for Form1
        public Form1()
        {
            InitializeComponent();

            // Initialize tableSchema DataTable and bind it to dataGridView2
            tableSchema = new DataTable("");
            dataGridView2.DataSource = tableSchema;
        }
        // Event handler for cell click in dataGridView1
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the value of the clicked cell and display it in a message box
                string cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                MessageBox.Show($"Selected cell value: {cellValue}", "Cell Content", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Method to load data from the selected table
        private void LoadTableData(string tableName)
        {
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();

                var query = $"SELECT * FROM {tableName}";
                var dataAdapter = new SQLiteDataAdapter(query, conn);
                var dataTable = new DataTable { TableName = tableName };

                // Fill the DataTable schema and data
                dataAdapter.FillSchema(dataTable, SchemaType.Source);
                dataAdapter.Fill(dataTable);
                dataTable.AcceptChanges();

                // Populate the column data types dictionary
                columnDataTypes.Clear();
                foreach (DataColumn column in dataTable.Columns)
                {
                    columnDataTypes[column.ColumnName] = column.DataType.ToString();
                }

                // Set the DataGridView's data source to the loaded DataTable
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading table data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for cell value changed in dataGridView1
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is DataRowView dataRowView)
                {
                    // Mark the corresponding DataRow as modified when cell value changes
                    DataRow rowInDataTable = dataRowView.Row;
                    rowInDataTable.SetModified();
                }
            }
        }
        // Method to populate ComboBox with table names
        private void PopulateComboBoxWithTables(List<string> tableNames)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(tableNames.ToArray());

            // Select the first table by default
            if (tableNames.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        // Event handler methods for button clicks
        #region Buttons
        private void LoadButton(object sender, EventArgs e) => OpenFileButton_Click(this);
        private void UpdateButton(object sender, EventArgs e) => UpdateDataButton_Click(this);
        private void SaveButton(object sender, EventArgs e) => SaveDatabaseButton_Click(this);
        private void AddColumnButton(object sender, EventArgs e) => AddColumnButton_Click(this);
        private void SetNameButton(object sender, EventArgs e) => ChangeTableNameButton_Click(this);
        private void SearchButton(object sender, EventArgs e) => SearchButton_Click(this);
        #endregion
        // Event handler methods for text changes and dataGridView
        #region FormNecessities
        private void dataGridView2_CellContentClick(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        #endregion

        // Event handler for table selection change
        private void comboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedTable = comboBox1.SelectedItem.ToString();
                LoadTableData(selectedTable);
            }
        }
    }
}