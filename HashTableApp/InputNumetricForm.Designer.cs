namespace WinFormsApp1
{
    partial class InputNumetricForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            numericUpDown2 = new NumericUpDown();
            Save1 = new Button();
            Save2 = new Button();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 62);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(86, 32);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown1.Location = new Point(15, 99);
            numericUpDown1.Margin = new Padding(6, 5, 6, 5);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(320, 39);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Location = new Point(120, 297);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(86, 32);
            label2.TabIndex = 0;
            label2.Text = "label1";
            label2.Visible = false;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown2.Enabled = false;
            numericUpDown2.Location = new Point(15, 334);
            numericUpDown2.Margin = new Padding(6, 5, 6, 5);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(320, 39);
            numericUpDown2.TabIndex = 1;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Visible = false;
            // 
            // Save1
            // 
            Save1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Save1.Location = new Point(348, 97);
            Save1.Name = "Save1";
            Save1.Size = new Size(172, 39);
            Save1.TabIndex = 2;
            Save1.Text = "Сохранить";
            Save1.UseVisualStyleBackColor = true;
            Save1.Click += Save1_Click;
            // 
            // Save2
            // 
            Save2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Save2.Enabled = false;
            Save2.Location = new Point(348, 332);
            Save2.Name = "Save2";
            Save2.Size = new Size(172, 39);
            Save2.TabIndex = 2;
            Save2.Text = "Сохранить";
            Save2.UseVisualStyleBackColor = true;
            Save2.Visible = false;
            Save2.Click += Save2_Click;
            // 
            // InputNumetricForm
            // 
            AutoScaleDimensions = new SizeF(16F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 490);
            Controls.Add(Save2);
            Controls.Add(Save1);
            Controls.Add(numericUpDown2);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            Margin = new Padding(6, 5, 6, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputNumetricForm";
            Text = "InputNumetricForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private NumericUpDown numericUpDown2;
        private Button Save1;
        private Button Save2;
        private ToolTip toolTip1;
    }
}