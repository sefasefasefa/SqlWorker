namespace SqlWorker
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
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            btnGetDatabase = new Button();
            label4 = new Label();
            txtServerName = new TextBox();
            lBDatabase = new ListBox();
            LBTable = new ListBox();
            LBColumn = new ListBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            TxtProperty = new TextBox();
            sqlLogin1 = new SqlLogin();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(873, 0);
            label2.Name = "label2";
            label2.Size = new Size(20, 21);
            label2.TabIndex = 2;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(851, -2);
            label1.Name = "label1";
            label1.Size = new Size(17, 21);
            label1.TabIndex = 1;
            label1.Text = "_";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(893, 23);
            panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(354, 30);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(84, 19);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "UserLogin?";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // btnGetDatabase
            // 
            btnGetDatabase.Location = new Point(35, 55);
            btnGetDatabase.Name = "btnGetDatabase";
            btnGetDatabase.Size = new Size(95, 23);
            btnGetDatabase.TabIndex = 2;
            btnGetDatabase.Text = "Database Çek";
            btnGetDatabase.UseVisualStyleBackColor = true;
            btnGetDatabase.Click += btnGetDatabase_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 34);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 10;
            label4.Text = "Server Name:";
            // 
            // txtServerName
            // 
            txtServerName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtServerName.Location = new Point(134, 29);
            txtServerName.Name = "txtServerName";
            txtServerName.Size = new Size(207, 20);
            txtServerName.TabIndex = 9;
            txtServerName.TextChanged += txtServerName_TextChanged;
            // 
            // lBDatabase
            // 
            lBDatabase.FormattingEnabled = true;
            lBDatabase.ItemHeight = 15;
            lBDatabase.Location = new Point(12, 199);
            lBDatabase.Name = "lBDatabase";
            lBDatabase.Size = new Size(198, 409);
            lBDatabase.TabIndex = 13;
            lBDatabase.DoubleClick += listBox1_DoubleClick;
            // 
            // LBTable
            // 
            LBTable.FormattingEnabled = true;
            LBTable.ItemHeight = 15;
            LBTable.Location = new Point(220, 198);
            LBTable.Name = "LBTable";
            LBTable.Size = new Size(198, 409);
            LBTable.TabIndex = 14;
            LBTable.DoubleClick += LBTable_DoubleClick;
            // 
            // LBColumn
            // 
            LBColumn.FormattingEnabled = true;
            LBColumn.ItemHeight = 15;
            LBColumn.Location = new Point(427, 198);
            LBColumn.Name = "LBColumn";
            LBColumn.Size = new Size(198, 409);
            LBColumn.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 180);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 16;
            label5.Text = "DataBase Name:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(220, 180);
            label6.Name = "label6";
            label6.Size = new Size(72, 15);
            label6.TabIndex = 17;
            label6.Text = "Table Name:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(427, 180);
            label7.Name = "label7";
            label7.Size = new Size(88, 15);
            label7.TabIndex = 18;
            label7.Text = "Column Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(631, 180);
            label8.Name = "label8";
            label8.Size = new Size(70, 15);
            label8.TabIndex = 20;
            label8.Text = "PropertyList";
            // 
            // TxtProperty
            // 
            TxtProperty.Location = new Point(631, 199);
            TxtProperty.Multiline = true;
            TxtProperty.Name = "TxtProperty";
            TxtProperty.Size = new Size(262, 409);
            TxtProperty.TabIndex = 21;
            // 
            // sqlLogin1
            // 
            sqlLogin1.Location = new Point(467, 29);
            sqlLogin1.Name = "sqlLogin1";
            sqlLogin1.Size = new Size(207, 147);
            sqlLogin1.TabIndex = 22;
            sqlLogin1.Visible = false;
            sqlLogin1.Load += sqlLogin1_Load;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(896, 620);
            Controls.Add(sqlLogin1);
            Controls.Add(TxtProperty);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(LBColumn);
            Controls.Add(LBTable);
            Controls.Add(lBDatabase);
            Controls.Add(label4);
            Controls.Add(txtServerName);
            Controls.Add(btnGetDatabase);
            Controls.Add(checkBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Panel panel1;
        private CheckBox checkBox1;
        private Button btnGetDatabase;
        private Label label4;
        private ListBox lBDatabase;
        private TextBox txtServerName;
        private ListBox LBTable;
        private ListBox LBColumn;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ListBox LBProperty;
        private TextBox TxtProperty;
        private SqlLogin sqlLogin1;
    }
}