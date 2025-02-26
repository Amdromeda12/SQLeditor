using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SQLeditor;

public partial class Form1 : Form
{
    private DataGridView dataGridView1;
    private string dbPath = @"Data Source=""C:\Users\Dennis Wiklund\Desktop\Project\SQLeditor\db.db"";Version=3"; // Path to SQLite database

    public Form1()
    {
        InitializeComponent();
        AddButtons();
        SetupDataGridView();
    }

    private void AddButtons()
    {
        Button btn1 = new Button { Text = "Courses", Location = new System.Drawing.Point(20, 20) };
        btn1.Click += Btn1_Click;
        
        Button btn2 = new Button { Text = "Assignments", Location = new System.Drawing.Point(20, 80) };
        btn2.Click += Btn2_Click;
        
        Button btn3 = new Button { Text = "Responses", Location = new System.Drawing.Point(20, 140) };
        btn3.Click += Btn3_Click;
        
        this.Controls.AddRange(new Button[] { btn1, btn2, btn3 });
    }
    private void SetupDataGridView()
    {
        dataGridView1 = new DataGridView
        {
            Width = 900,
            Height = 300,
            ForeColor = Color.Purple,
            GridColor = Color.Gray,
            Location = Location = new System.Drawing.Point(170, 380)
        };

        this.Controls.Add(dataGridView1);
    }
    public string test;

    private void LoadData(string query)
    {
        using (SQLiteConnection conn = new SQLiteConnection(dbPath))
        {
            conn.Open();
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
    private void Btn1_Click(object sender, EventArgs e) => LoadData("Select * From courses");
    private void Btn2_Click(object sender, EventArgs e) => LoadData("Select * From assignments");
    private void Btn3_Click(object sender, EventArgs e) => LoadData("Select * From responses");
}
