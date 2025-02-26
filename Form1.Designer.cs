namespace SQLeditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl = new System.Windows.Forms.TabControl();
            this.Use = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ResponseDataGridView = new System.Windows.Forms.DataGridView();
            this.AssignmentDataGridView = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ResponsesLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AssignmentsLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CoursesLbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CopyBtn = new System.Windows.Forms.Button();
            this.RMessageBox = new System.Windows.Forms.RichTextBox();
            this.CourseDataGridView = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DeleteCourseBtn = new System.Windows.Forms.Button();
            this.NewCourseBtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DeleteAssigmBtn = new System.Windows.Forms.Button();
            this.NewAssigmBtn = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.DeleteRespBtn = new System.Windows.Forms.Button();
            this.NewRespBtn = new System.Windows.Forms.Button();
            this.Database = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TablesTabControl = new System.Windows.Forms.TabControl();
            this.tabPageCourses = new System.Windows.Forms.TabPage();
            this.dataGridViewCoursesEditor = new System.Windows.Forms.DataGridView();
            this.tabPageAssignments = new System.Windows.Forms.TabPage();
            this.dataGridViewAssignmentsEditor = new System.Windows.Forms.DataGridView();
            this.tabPageResponses = new System.Windows.Forms.TabPage();
            this.dataGridViewResponsesEditor = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl.SuspendLayout();
            this.Use.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResponseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssignmentDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CourseDataGridView)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.Database.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.TablesTabControl.SuspendLayout();
            this.tabPageCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoursesEditor)).BeginInit();
            this.tabPageAssignments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssignmentsEditor)).BeginInit();
            this.tabPageResponses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResponsesEditor)).BeginInit();
            this.panel8.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.Use);
            this.TabControl.Controls.Add(this.Database);
            this.TabControl.Location = new System.Drawing.Point(-3, 27);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(802, 422);
            this.TabControl.TabIndex = 0;
            // 
            // Use
            // 
            this.Use.Controls.Add(this.tableLayoutPanel1);
            this.Use.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Use.Location = new System.Drawing.Point(4, 22);
            this.Use.Name = "Use";
            this.Use.Padding = new System.Windows.Forms.Padding(3);
            this.Use.Size = new System.Drawing.Size(794, 396);
            this.Use.TabIndex = 0;
            this.Use.Text = "Use";
            this.Use.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.ResponseDataGridView, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.AssignmentDataGridView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.RMessageBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.CourseDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(788, 390);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ResponseDataGridView
            // 
            this.ResponseDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ResponseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResponseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResponseDataGridView.Location = new System.Drawing.Point(317, 43);
            this.ResponseDataGridView.Name = "ResponseDataGridView";
            this.ResponseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResponseDataGridView.Size = new System.Drawing.Size(151, 306);
            this.ResponseDataGridView.TabIndex = 13;
            this.ResponseDataGridView.SelectionChanged += new System.EventHandler(this.ResponseDataGridView_SelectionChanged);
            // 
            // AssignmentDataGridView
            // 
            this.AssignmentDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.AssignmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AssignmentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssignmentDataGridView.Location = new System.Drawing.Point(160, 43);
            this.AssignmentDataGridView.Name = "AssignmentDataGridView";
            this.AssignmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AssignmentDataGridView.Size = new System.Drawing.Size(151, 306);
            this.AssignmentDataGridView.TabIndex = 12;
            this.AssignmentDataGridView.SelectionChanged += new System.EventHandler(this.AssignmentDataGridView_SelectionChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Controls.Add(this.ResponsesLbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(317, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(151, 34);
            this.panel3.TabIndex = 2;
            // 
            // ResponsesLbl
            // 
            this.ResponsesLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ResponsesLbl.AutoSize = true;
            this.ResponsesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponsesLbl.ForeColor = System.Drawing.Color.White;
            this.ResponsesLbl.Location = new System.Drawing.Point(20, 0);
            this.ResponsesLbl.Name = "ResponsesLbl";
            this.ResponsesLbl.Size = new System.Drawing.Size(114, 24);
            this.ResponsesLbl.TabIndex = 1;
            this.ResponsesLbl.Text = "Responses";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.AssignmentsLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(160, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 34);
            this.panel2.TabIndex = 1;
            // 
            // AssignmentsLbl
            // 
            this.AssignmentsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.AssignmentsLbl.AutoSize = true;
            this.AssignmentsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssignmentsLbl.ForeColor = System.Drawing.Color.White;
            this.AssignmentsLbl.Location = new System.Drawing.Point(10, 0);
            this.AssignmentsLbl.Name = "AssignmentsLbl";
            this.AssignmentsLbl.Size = new System.Drawing.Size(129, 24);
            this.AssignmentsLbl.TabIndex = 2;
            this.AssignmentsLbl.Text = "Assignments";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.CoursesLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 34);
            this.panel1.TabIndex = 0;
            // 
            // CoursesLbl
            // 
            this.CoursesLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.CoursesLbl.AutoSize = true;
            this.CoursesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoursesLbl.ForeColor = System.Drawing.Color.White;
            this.CoursesLbl.Location = new System.Drawing.Point(29, 0);
            this.CoursesLbl.Name = "CoursesLbl";
            this.CoursesLbl.Size = new System.Drawing.Size(87, 24);
            this.CoursesLbl.TabIndex = 3;
            this.CoursesLbl.Text = "Courses";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.CopyBtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(474, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(311, 34);
            this.panel4.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(103, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message";
            // 
            // CopyBtn
            // 
            this.CopyBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CopyBtn.Location = new System.Drawing.Point(268, 0);
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(43, 34);
            this.CopyBtn.TabIndex = 4;
            this.CopyBtn.Text = "CO";
            this.CopyBtn.UseVisualStyleBackColor = true;
            this.CopyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // RMessageBox
            // 
            this.RMessageBox.BackColor = System.Drawing.Color.White;
            this.RMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RMessageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RMessageBox.Location = new System.Drawing.Point(474, 43);
            this.RMessageBox.Name = "RMessageBox";
            this.tableLayoutPanel1.SetRowSpan(this.RMessageBox, 2);
            this.RMessageBox.Size = new System.Drawing.Size(311, 344);
            this.RMessageBox.TabIndex = 7;
            this.RMessageBox.Text = "";
            this.RMessageBox.TextChanged += new System.EventHandler(this.RMessageBox_TextChanged);
            // 
            // CourseDataGridView
            // 
            this.CourseDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.CourseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CourseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CourseDataGridView.Location = new System.Drawing.Point(3, 43);
            this.CourseDataGridView.Name = "CourseDataGridView";
            this.CourseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CourseDataGridView.Size = new System.Drawing.Size(151, 306);
            this.CourseDataGridView.TabIndex = 11;
            this.CourseDataGridView.SelectionChanged += new System.EventHandler(this.CourseDataGridView_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.DeleteCourseBtn);
            this.panel5.Controls.Add(this.NewCourseBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 355);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(151, 32);
            this.panel5.TabIndex = 14;
            // 
            // DeleteCourseBtn
            // 
            this.DeleteCourseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DeleteCourseBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeleteCourseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCourseBtn.ForeColor = System.Drawing.Color.Black;
            this.DeleteCourseBtn.Location = new System.Drawing.Point(79, 0);
            this.DeleteCourseBtn.Name = "DeleteCourseBtn";
            this.DeleteCourseBtn.Size = new System.Drawing.Size(72, 32);
            this.DeleteCourseBtn.TabIndex = 10;
            this.DeleteCourseBtn.Text = "Delete";
            this.DeleteCourseBtn.UseVisualStyleBackColor = false;
            this.DeleteCourseBtn.Click += new System.EventHandler(this.DeleteCourseBtn_Click);
            // 
            // NewCourseBtn
            // 
            this.NewCourseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.NewCourseBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.NewCourseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCourseBtn.ForeColor = System.Drawing.Color.Black;
            this.NewCourseBtn.Location = new System.Drawing.Point(0, 0);
            this.NewCourseBtn.Name = "NewCourseBtn";
            this.NewCourseBtn.Size = new System.Drawing.Size(72, 32);
            this.NewCourseBtn.TabIndex = 9;
            this.NewCourseBtn.Text = "New";
            this.NewCourseBtn.UseVisualStyleBackColor = false;
            this.NewCourseBtn.Click += new System.EventHandler(this.NewCourseBtn_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.DeleteAssigmBtn);
            this.panel6.Controls.Add(this.NewAssigmBtn);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(160, 355);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(151, 32);
            this.panel6.TabIndex = 15;
            // 
            // DeleteAssigmBtn
            // 
            this.DeleteAssigmBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DeleteAssigmBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeleteAssigmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteAssigmBtn.Location = new System.Drawing.Point(79, 0);
            this.DeleteAssigmBtn.Name = "DeleteAssigmBtn";
            this.DeleteAssigmBtn.Size = new System.Drawing.Size(72, 32);
            this.DeleteAssigmBtn.TabIndex = 11;
            this.DeleteAssigmBtn.Text = "Delete";
            this.DeleteAssigmBtn.UseVisualStyleBackColor = false;
            this.DeleteAssigmBtn.Click += new System.EventHandler(this.DeleteAssigmBtn_Click);
            // 
            // NewAssigmBtn
            // 
            this.NewAssigmBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.NewAssigmBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.NewAssigmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewAssigmBtn.Location = new System.Drawing.Point(0, 0);
            this.NewAssigmBtn.Name = "NewAssigmBtn";
            this.NewAssigmBtn.Size = new System.Drawing.Size(72, 32);
            this.NewAssigmBtn.TabIndex = 10;
            this.NewAssigmBtn.Text = "New";
            this.NewAssigmBtn.UseVisualStyleBackColor = false;
            this.NewAssigmBtn.Click += new System.EventHandler(this.NewAssigmBtn_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.DeleteRespBtn);
            this.panel7.Controls.Add(this.NewRespBtn);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(317, 355);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(151, 32);
            this.panel7.TabIndex = 16;
            // 
            // DeleteRespBtn
            // 
            this.DeleteRespBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DeleteRespBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeleteRespBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteRespBtn.Location = new System.Drawing.Point(79, 0);
            this.DeleteRespBtn.Name = "DeleteRespBtn";
            this.DeleteRespBtn.Size = new System.Drawing.Size(72, 32);
            this.DeleteRespBtn.TabIndex = 12;
            this.DeleteRespBtn.Text = "Delete";
            this.DeleteRespBtn.UseVisualStyleBackColor = false;
            this.DeleteRespBtn.Click += new System.EventHandler(this.DeleteRespBtn_Click);
            // 
            // NewRespBtn
            // 
            this.NewRespBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.NewRespBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.NewRespBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRespBtn.Location = new System.Drawing.Point(0, 0);
            this.NewRespBtn.Name = "NewRespBtn";
            this.NewRespBtn.Size = new System.Drawing.Size(72, 32);
            this.NewRespBtn.TabIndex = 11;
            this.NewRespBtn.Text = "New";
            this.NewRespBtn.UseVisualStyleBackColor = false;
            this.NewRespBtn.Click += new System.EventHandler(this.NewRespBtn_Click);
            // 
            // Database
            // 
            this.Database.BackColor = System.Drawing.Color.Transparent;
            this.Database.Controls.Add(this.tableLayoutPanel2);
            this.Database.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Database.Location = new System.Drawing.Point(4, 22);
            this.Database.Name = "Database";
            this.Database.Padding = new System.Windows.Forms.Padding(3);
            this.Database.Size = new System.Drawing.Size(794, 396);
            this.Database.TabIndex = 1;
            this.Database.Text = "Database ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.TablesTabControl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(788, 390);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // TablesTabControl
            // 
            this.TablesTabControl.Controls.Add(this.tabPageCourses);
            this.TablesTabControl.Controls.Add(this.tabPageAssignments);
            this.TablesTabControl.Controls.Add(this.tabPageResponses);
            this.TablesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablesTabControl.Location = new System.Drawing.Point(3, 3);
            this.TablesTabControl.Name = "TablesTabControl";
            this.TablesTabControl.SelectedIndex = 0;
            this.TablesTabControl.Size = new System.Drawing.Size(624, 384);
            this.TablesTabControl.TabIndex = 0;
            this.TablesTabControl.SelectedIndexChanged += new System.EventHandler(this.TablesTabControl_SelectedIndexChanged);
            // 
            // tabPageCourses
            // 
            this.tabPageCourses.Controls.Add(this.dataGridViewCoursesEditor);
            this.tabPageCourses.Location = new System.Drawing.Point(4, 22);
            this.tabPageCourses.Name = "tabPageCourses";
            this.tabPageCourses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCourses.Size = new System.Drawing.Size(616, 358);
            this.tabPageCourses.TabIndex = 0;
            this.tabPageCourses.Text = "Courses";
            this.tabPageCourses.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCoursesEditor
            // 
            this.dataGridViewCoursesEditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoursesEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCoursesEditor.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCoursesEditor.Name = "dataGridViewCoursesEditor";
            this.dataGridViewCoursesEditor.Size = new System.Drawing.Size(610, 352);
            this.dataGridViewCoursesEditor.TabIndex = 0;
            // 
            // tabPageAssignments
            // 
            this.tabPageAssignments.Controls.Add(this.dataGridViewAssignmentsEditor);
            this.tabPageAssignments.Location = new System.Drawing.Point(4, 22);
            this.tabPageAssignments.Name = "tabPageAssignments";
            this.tabPageAssignments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAssignments.Size = new System.Drawing.Size(616, 358);
            this.tabPageAssignments.TabIndex = 1;
            this.tabPageAssignments.Text = "Assignments";
            this.tabPageAssignments.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAssignmentsEditor
            // 
            this.dataGridViewAssignmentsEditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssignmentsEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAssignmentsEditor.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAssignmentsEditor.Name = "dataGridViewAssignmentsEditor";
            this.dataGridViewAssignmentsEditor.Size = new System.Drawing.Size(610, 352);
            this.dataGridViewAssignmentsEditor.TabIndex = 0;
            // 
            // tabPageResponses
            // 
            this.tabPageResponses.Controls.Add(this.dataGridViewResponsesEditor);
            this.tabPageResponses.Location = new System.Drawing.Point(4, 22);
            this.tabPageResponses.Name = "tabPageResponses";
            this.tabPageResponses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResponses.Size = new System.Drawing.Size(616, 358);
            this.tabPageResponses.TabIndex = 2;
            this.tabPageResponses.Text = "Responses";
            this.tabPageResponses.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResponsesEditor
            // 
            this.dataGridViewResponsesEditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResponsesEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewResponsesEditor.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewResponsesEditor.Name = "dataGridViewResponsesEditor";
            this.dataGridViewResponsesEditor.Size = new System.Drawing.Size(610, 352);
            this.dataGridViewResponsesEditor.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.SaveBtn);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(633, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(152, 384);
            this.panel8.TabIndex = 1;
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.White;
            this.SaveBtn.Location = new System.Drawing.Point(3, 337);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(146, 31);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDatabaseToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open Database";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SQL_Editor";
            this.TabControl.ResumeLayout(false);
            this.Use.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResponseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssignmentDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CourseDataGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.Database.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.TablesTabControl.ResumeLayout(false);
            this.tabPageCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoursesEditor)).EndInit();
            this.tabPageAssignments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssignmentsEditor)).EndInit();
            this.tabPageResponses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResponsesEditor)).EndInit();
            this.panel8.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage Use;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label ResponsesLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label AssignmentsLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CoursesLbl;
        private System.Windows.Forms.Button CopyBtn;
        private System.Windows.Forms.RichTextBox RMessageBox;
        private System.Windows.Forms.DataGridView CourseDataGridView;
        private System.Windows.Forms.DataGridView ResponseDataGridView;
        private System.Windows.Forms.DataGridView AssignmentDataGridView;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button DeleteCourseBtn;
        private System.Windows.Forms.Button NewCourseBtn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button DeleteAssigmBtn;
        private System.Windows.Forms.Button NewAssigmBtn;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button DeleteRespBtn;
        private System.Windows.Forms.Button NewRespBtn;
        private System.Windows.Forms.TabPage Database;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabControl TablesTabControl;
        private System.Windows.Forms.TabPage tabPageCourses;
        private System.Windows.Forms.DataGridView dataGridViewCoursesEditor;
        private System.Windows.Forms.TabPage tabPageAssignments;
        private System.Windows.Forms.DataGridView dataGridViewAssignmentsEditor;
        private System.Windows.Forms.TabPage tabPageResponses;
        private System.Windows.Forms.DataGridView dataGridViewResponsesEditor;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button SaveBtn;
    }
}

