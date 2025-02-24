namespace SQLDatabaseViewer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Edit = new TabPage();
            textBox5 = new TextBox();
            button6 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            Create = new TabPage();
            label4 = new Label();
            textBox4 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            button5 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            button4 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            dataGridView2 = new DataGridView();
            comboBox1 = new ComboBox();
            tabControl1.SuspendLayout();
            Edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            Create.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Edit);
            tabControl1.Controls.Add(Create);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1145, 605);
            tabControl1.TabIndex = 0;
            // 
            // Edit
            // 
            Edit.Controls.Add(comboBox1);
            Edit.Controls.Add(textBox5);
            Edit.Controls.Add(button6);
            Edit.Controls.Add(button2);
            Edit.Controls.Add(dataGridView1);
            Edit.Controls.Add(button1);
            Edit.Location = new Point(4, 24);
            Edit.Name = "Edit";
            Edit.Padding = new Padding(3);
            Edit.Size = new Size(1137, 577);
            Edit.TabIndex = 0;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 133);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(237, 23);
            textBox5.TabIndex = 7;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // button6
            // 
            button6.Location = new Point(6, 104);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 6;
            button6.Text = "Search";
            button6.UseVisualStyleBackColor = true;
            button6.Click += SearchButton;
            // 
            // button2
            // 
            button2.Location = new Point(6, 35);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            button2.Click += UpdateButton;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(395, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(736, 565);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(6, 6);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += LoadButton;
            // 
            // Create
            // 
            Create.Controls.Add(label4);
            Create.Controls.Add(textBox4);
            Create.Controls.Add(label3);
            Create.Controls.Add(textBox3);
            Create.Controls.Add(button5);
            Create.Controls.Add(textBox2);
            Create.Controls.Add(label2);
            Create.Controls.Add(button4);
            Create.Controls.Add(label1);
            Create.Controls.Add(textBox1);
            Create.Controls.Add(button3);
            Create.Controls.Add(dataGridView2);
            Create.Location = new Point(4, 24);
            Create.Name = "Create";
            Create.Padding = new Padding(3);
            Create.Size = new Size(1137, 577);
            Create.TabIndex = 1;
            Create.Text = "Create";
            Create.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(225, 106);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 19;
            label4.Text = "Datatype";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(225, 124);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(148, 23);
            textBox4.TabIndex = 18;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 12);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 17;
            label3.Text = "Name of Table";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 30);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(213, 23);
            textBox3.TabIndex = 16;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // button5
            // 
            button5.Location = new Point(6, 59);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 15;
            button5.Text = "SetName";
            button5.UseVisualStyleBackColor = true;
            button5.Click += SetNameButton;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 124);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(213, 23);
            textBox2.TabIndex = 14;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 106);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 13;
            label2.Text = "Column Name";
            // 
            // button4
            // 
            button4.Location = new Point(6, 153);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 9;
            button4.Text = "AddColumn";
            button4.UseVisualStyleBackColor = true;
            button4.Click += AddColumnButton;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 201);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 8;
            label1.Text = "Name of Database";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 219);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 23);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // button3
            // 
            button3.Location = new Point(6, 248);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Create";
            button3.UseVisualStyleBackColor = true;
            button3.Click += SaveButton;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(395, 6);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(736, 565);
            dataGridView2.TabIndex = 5;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 162);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(237, 23);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 629);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "SQLDatabaseViewer";
            tabControl1.ResumeLayout(false);
            Edit.ResumeLayout(false);
            Edit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            Create.ResumeLayout(false);
            Create.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Edit;
        private Button button1;
        private TabPage Create;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView2;
        private TextBox textBox1;
        private Label label1;
        private Button button4;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Button button5;
        private Label label4;
        private TextBox textBox4;
        private Button button6;
        private TextBox textBox5;
        private ComboBox comboBox1;
    }
}
