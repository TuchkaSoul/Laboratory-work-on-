namespace AerialReconnaissance
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            CreaterButton = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            pointchange = new ToolStripStatusLabel();
            ThreadBar = new ToolStripStatusLabel();
            ProgressBar1 = new ToolStripProgressBar();
            Nmatrix = new NumericUpDown();
            starter = new Button();
            CreaterThread = new Button();
            ThreadSpin = new NumericUpDown();
            MapLabel = new Label();
            label1 = new Label();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Nmatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThreadSpin).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "    ";
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.GridColor = SystemColors.ActiveCaptionText;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 29;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.RowTemplate.ReadOnly = true;
            dataGridView1.Size = new Size(1000, 800);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellContentDoubleClick += DataGridView1_CellContentDoubleClick;
            // 
            // CreaterButton
            // 
            CreaterButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CreaterButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CreaterButton.Location = new Point(1164, 109);
            CreaterButton.Name = "CreaterButton";
            CreaterButton.Size = new Size(133, 30);
            CreaterButton.TabIndex = 4;
            CreaterButton.Text = "Пересоздать";
            CreaterButton.UseVisualStyleBackColor = true;
            CreaterButton.Click += CreaterButton_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, pointchange, ThreadBar, ProgressBar1 });
            statusStrip1.Location = new Point(0, 818);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1342, 26);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // pointchange
            // 
            pointchange.Name = "pointchange";
            pointchange.Size = new Size(0, 20);
            // 
            // ThreadBar
            // 
            ThreadBar.Name = "ThreadBar";
            ThreadBar.Size = new Size(0, 20);
            // 
            // ProgressBar1
            // 
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new Size(100, 18);
            // 
            // Nmatrix
            // 
            Nmatrix.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Nmatrix.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Nmatrix.Location = new Point(1164, 69);
            Nmatrix.Name = "Nmatrix";
            Nmatrix.Size = new Size(133, 34);
            Nmatrix.TabIndex = 7;
            Nmatrix.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // starter
            // 
            starter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            starter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            starter.Location = new Point(1164, 249);
            starter.Name = "starter";
            starter.Size = new Size(133, 29);
            starter.TabIndex = 8;
            starter.Text = "Запуск";
            starter.UseVisualStyleBackColor = true;
            starter.Click += starter_Click;
            // 
            // CreaterThread
            // 
            CreaterThread.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CreaterThread.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CreaterThread.Location = new Point(1164, 284);
            CreaterThread.Name = "CreaterThread";
            CreaterThread.Size = new Size(133, 29);
            CreaterThread.TabIndex = 9;
            CreaterThread.Text = "СТОП";
            CreaterThread.UseVisualStyleBackColor = true;
            CreaterThread.Visible = false;
            CreaterThread.Click += CreaterThread_Click;
            // 
            // ThreadSpin
            // 
            ThreadSpin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ThreadSpin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ThreadSpin.Location = new Point(1164, 209);
            ThreadSpin.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            ThreadSpin.Name = "ThreadSpin";
            ThreadSpin.Size = new Size(133, 34);
            ThreadSpin.TabIndex = 7;
            ThreadSpin.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // MapLabel
            // 
            MapLabel.AutoSize = true;
            MapLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            MapLabel.Location = new Point(1131, 12);
            MapLabel.Name = "MapLabel";
            MapLabel.Size = new Size(166, 32);
            MapLabel.TabIndex = 10;
            MapLabel.Text = "Размер карты";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1103, 162);
            label1.Name = "label1";
            label1.Size = new Size(233, 32);
            label1.TabIndex = 10;
            label1.Text = "Количество дронов";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1235, 788);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(95, 24);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Ускорить";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1342, 844);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(MapLabel);
            Controls.Add(CreaterThread);
            Controls.Add(starter);
            Controls.Add(ThreadSpin);
            Controls.Add(Nmatrix);
            Controls.Add(statusStrip1);
            Controls.Add(CreaterButton);
            Controls.Add(dataGridView1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Воздушная разведка";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Nmatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThreadSpin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button CreaterButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private NumericUpDown Nmatrix;
        private ToolStripStatusLabel pointchange;
        private Button starter;
        private Button CreaterThread;
        private NumericUpDown ThreadSpin;
        private ToolStripStatusLabel ThreadBar;
        private Label MapLabel;
        private Label label1;
        private ToolStripProgressBar ProgressBar1;
        private CheckBox checkBox1;
    }
}
