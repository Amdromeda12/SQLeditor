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
            this.panelResponses = new System.Windows.Forms.Panel();
            this.panelAssignments = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ResponsesLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSortAssignments = new System.Windows.Forms.Button();
            this.AssignmentsLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CoursesLbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CopyBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RMessageBox = new System.Windows.Forms.RichTextBox();
            this.panelCourses = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteCourseBtn = new System.Windows.Forms.Button();
            this.EditCourseBtn = new System.Windows.Forms.Button();
            this.NewCourseBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteAssigmBtn = new System.Windows.Forms.Button();
            this.EditAssignmentBtn = new System.Windows.Forms.Button();
            this.NewAssigmBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteRespBtn = new System.Windows.Forms.Button();
            this.EditResponseBtn = new System.Windows.Forms.Button();
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
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
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
            this.TabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TablesTabControl_Selecting);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.09524F));
            this.tableLayoutPanel1.Controls.Add(this.panelResponses, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelAssignments, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.RMessageBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelCourses, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(788, 390);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelResponses
            // 
            this.panelResponses.BackColor = System.Drawing.Color.White;
            this.panelResponses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResponses.Location = new System.Drawing.Point(340, 43);
            this.panelResponses.Name = "panelResponses";
            this.panelResponses.Size = new System.Drawing.Size(144, 306);
            this.panelResponses.TabIndex = 19;
            // 
            // panelAssignments
            // 
            this.panelAssignments.BackColor = System.Drawing.Color.White;
            this.panelAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAssignments.Location = new System.Drawing.Point(153, 43);
            this.panelAssignments.Name = "panelAssignments";
            this.panelAssignments.Size = new System.Drawing.Size(181, 306);
            this.panelAssignments.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Controls.Add(this.ResponsesLbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(340, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(144, 34);
            this.panel3.TabIndex = 2;
            // 
            // ResponsesLbl
            // 
            this.ResponsesLbl.AutoSize = true;
            this.ResponsesLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResponsesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponsesLbl.ForeColor = System.Drawing.Color.White;
            this.ResponsesLbl.Location = new System.Drawing.Point(0, 0);
            this.ResponsesLbl.Name = "ResponsesLbl";
            this.ResponsesLbl.Size = new System.Drawing.Size(114, 24);
            this.ResponsesLbl.TabIndex = 1;
            this.ResponsesLbl.Text = "Responses";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.btnSortAssignments);
            this.panel2.Controls.Add(this.AssignmentsLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(153, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 34);
            this.panel2.TabIndex = 1;
            // 
            // btnSortAssignments
            // 
            this.btnSortAssignments.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSortAssignments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortAssignments.Location = new System.Drawing.Point(145, 0);
            this.btnSortAssignments.Name = "btnSortAssignments";
            this.btnSortAssignments.Size = new System.Drawing.Size(36, 34);
            this.btnSortAssignments.TabIndex = 3;
            this.btnSortAssignments.Text = "↑";
            this.btnSortAssignments.UseVisualStyleBackColor = true;
            // 
            // AssignmentsLbl
            // 
            this.AssignmentsLbl.AutoSize = true;
            this.AssignmentsLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.AssignmentsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssignmentsLbl.ForeColor = System.Drawing.Color.White;
            this.AssignmentsLbl.Location = new System.Drawing.Point(0, 0);
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
            this.panel1.Size = new System.Drawing.Size(144, 34);
            this.panel1.TabIndex = 0;
            // 
            // CoursesLbl
            // 
            this.CoursesLbl.AutoSize = true;
            this.CoursesLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.CoursesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoursesLbl.ForeColor = System.Drawing.Color.White;
            this.CoursesLbl.Location = new System.Drawing.Point(0, 0);
            this.CoursesLbl.Name = "CoursesLbl";
            this.CoursesLbl.Size = new System.Drawing.Size(87, 24);
            this.CoursesLbl.TabIndex = 3;
            this.CoursesLbl.Text = "Courses";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel4.Controls.Add(this.CopyBtn);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(490, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(295, 34);
            this.panel4.TabIndex = 3;
            // 
            // CopyBtn
            // 
            this.CopyBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CopyBtn.Location = new System.Drawing.Point(252, 0);
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(43, 34);
            this.CopyBtn.TabIndex = 4;
            this.CopyBtn.Text = "CO";
            this.CopyBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message";
            // 
            // RMessageBox
            // 
            this.RMessageBox.BackColor = System.Drawing.Color.White;
            this.RMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RMessageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RMessageBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RMessageBox.Location = new System.Drawing.Point(490, 43);
            this.RMessageBox.Name = "RMessageBox";
            this.RMessageBox.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.RMessageBox, 2);
            this.RMessageBox.Size = new System.Drawing.Size(295, 344);
            this.RMessageBox.TabIndex = 7;
            this.RMessageBox.Text = "";
            // 
            // panelCourses
            // 
            this.panelCourses.BackColor = System.Drawing.Color.White;
            this.panelCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCourses.Location = new System.Drawing.Point(3, 43);
            this.panelCourses.Name = "panelCourses";
            this.panelCourses.Size = new System.Drawing.Size(144, 306);
            this.panelCourses.TabIndex = 17;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.DeleteCourseBtn, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.EditCourseBtn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.NewCourseBtn, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 355);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(144, 32);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // DeleteCourseBtn
            // 
            this.DeleteCourseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DeleteCourseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteCourseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCourseBtn.ForeColor = System.Drawing.Color.Black;
            this.DeleteCourseBtn.Location = new System.Drawing.Point(97, 3);
            this.DeleteCourseBtn.Name = "DeleteCourseBtn";
            this.DeleteCourseBtn.Size = new System.Drawing.Size(44, 26);
            this.DeleteCourseBtn.TabIndex = 24;
            this.DeleteCourseBtn.Text = "Delete";
            this.DeleteCourseBtn.UseVisualStyleBackColor = false;
            // 
            // EditCourseBtn
            // 
            this.EditCourseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.EditCourseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditCourseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCourseBtn.ForeColor = System.Drawing.Color.Black;
            this.EditCourseBtn.Location = new System.Drawing.Point(50, 3);
            this.EditCourseBtn.Name = "EditCourseBtn";
            this.EditCourseBtn.Size = new System.Drawing.Size(41, 26);
            this.EditCourseBtn.TabIndex = 23;
            this.EditCourseBtn.Text = "Edit";
            this.EditCourseBtn.UseVisualStyleBackColor = false;
            // 
            // NewCourseBtn
            // 
            this.NewCourseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.NewCourseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewCourseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCourseBtn.ForeColor = System.Drawing.Color.Black;
            this.NewCourseBtn.Location = new System.Drawing.Point(3, 3);
            this.NewCourseBtn.Name = "NewCourseBtn";
            this.NewCourseBtn.Size = new System.Drawing.Size(41, 26);
            this.NewCourseBtn.TabIndex = 22;
            this.NewCourseBtn.Text = "New";
            this.NewCourseBtn.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.DeleteAssigmBtn, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.EditAssignmentBtn, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.NewAssigmBtn, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(153, 355);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(181, 32);
            this.tableLayoutPanel4.TabIndex = 21;
            // 
            // DeleteAssigmBtn
            // 
            this.DeleteAssigmBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DeleteAssigmBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteAssigmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteAssigmBtn.Location = new System.Drawing.Point(123, 3);
            this.DeleteAssigmBtn.Name = "DeleteAssigmBtn";
            this.DeleteAssigmBtn.Size = new System.Drawing.Size(55, 26);
            this.DeleteAssigmBtn.TabIndex = 25;
            this.DeleteAssigmBtn.Text = "Delete";
            this.DeleteAssigmBtn.UseVisualStyleBackColor = false;
            // 
            // EditAssignmentBtn
            // 
            this.EditAssignmentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.EditAssignmentBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditAssignmentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditAssignmentBtn.Location = new System.Drawing.Point(63, 3);
            this.EditAssignmentBtn.Name = "EditAssignmentBtn";
            this.EditAssignmentBtn.Size = new System.Drawing.Size(54, 26);
            this.EditAssignmentBtn.TabIndex = 24;
            this.EditAssignmentBtn.Text = "Edit";
            this.EditAssignmentBtn.UseVisualStyleBackColor = false;
            // 
            // NewAssigmBtn
            // 
            this.NewAssigmBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.NewAssigmBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewAssigmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewAssigmBtn.Location = new System.Drawing.Point(3, 3);
            this.NewAssigmBtn.Name = "NewAssigmBtn";
            this.NewAssigmBtn.Size = new System.Drawing.Size(54, 26);
            this.NewAssigmBtn.TabIndex = 23;
            this.NewAssigmBtn.Text = "New";
            this.NewAssigmBtn.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.DeleteRespBtn, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.EditResponseBtn, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.NewRespBtn, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(340, 355);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(144, 32);
            this.tableLayoutPanel5.TabIndex = 25;
            // 
            // DeleteRespBtn
            // 
            this.DeleteRespBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DeleteRespBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteRespBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteRespBtn.Location = new System.Drawing.Point(97, 3);
            this.DeleteRespBtn.Name = "DeleteRespBtn";
            this.DeleteRespBtn.Size = new System.Drawing.Size(44, 26);
            this.DeleteRespBtn.TabIndex = 25;
            this.DeleteRespBtn.Text = "Delete";
            this.DeleteRespBtn.UseVisualStyleBackColor = false;
            // 
            // EditResponseBtn
            // 
            this.EditResponseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.EditResponseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditResponseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditResponseBtn.Location = new System.Drawing.Point(50, 3);
            this.EditResponseBtn.Name = "EditResponseBtn";
            this.EditResponseBtn.Size = new System.Drawing.Size(41, 26);
            this.EditResponseBtn.TabIndex = 24;
            this.EditResponseBtn.Text = "Edit";
            this.EditResponseBtn.UseVisualStyleBackColor = false;
            // 
            // NewRespBtn
            // 
            this.NewRespBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.NewRespBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewRespBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRespBtn.Location = new System.Drawing.Point(3, 3);
            this.NewRespBtn.Name = "NewRespBtn";
            this.NewRespBtn.Size = new System.Drawing.Size(41, 26);
            this.NewRespBtn.TabIndex = 23;
            this.NewRespBtn.Text = "New";
            this.NewRespBtn.UseVisualStyleBackColor = false;
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
            this.dataGridViewCoursesEditor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dataGridViewAssignmentsEditor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dataGridViewResponsesEditor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabControl.ResumeLayout(false);
            this.Use.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
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

        public System.Windows.Forms.TabControl TabControl;
        public System.Windows.Forms.TabPage Use;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label ResponsesLbl;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label AssignmentsLbl;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label CoursesLbl;
        public System.Windows.Forms.Button CopyBtn;
        public System.Windows.Forms.RichTextBox RMessageBox;
        public System.Windows.Forms.TabPage Database;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TabControl TablesTabControl;
        public System.Windows.Forms.TabPage tabPageCourses;
        public System.Windows.Forms.DataGridView dataGridViewCoursesEditor;
        public System.Windows.Forms.TabPage tabPageAssignments;
        public System.Windows.Forms.DataGridView dataGridViewAssignmentsEditor;
        public System.Windows.Forms.TabPage tabPageResponses;
        public System.Windows.Forms.DataGridView dataGridViewResponsesEditor;
        public System.Windows.Forms.Panel panel8;
        public System.Windows.Forms.Button SaveBtn;
        public System.Windows.Forms.Panel panelCourses;
        public System.Windows.Forms.Panel panelAssignments;
        public System.Windows.Forms.Panel panelResponses;
        public BrightIdeasSoftware.ObjectListView CourseListView;
        public BrightIdeasSoftware.ObjectListView AssignmentListView;
        public BrightIdeasSoftware.ObjectListView ResponseListView;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.Button DeleteCourseBtn;
        public System.Windows.Forms.Button EditCourseBtn;
        public System.Windows.Forms.Button NewCourseBtn;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        public System.Windows.Forms.Button DeleteAssigmBtn;
        public System.Windows.Forms.Button EditAssignmentBtn;
        public System.Windows.Forms.Button NewAssigmBtn;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        public System.Windows.Forms.Button DeleteRespBtn;
        public System.Windows.Forms.Button EditResponseBtn;
        public System.Windows.Forms.Button NewRespBtn;
        public System.Windows.Forms.Button btnSortAssignments;
    }
}

