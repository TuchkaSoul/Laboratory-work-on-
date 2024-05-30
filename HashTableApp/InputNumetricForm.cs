namespace WinFormsApp1
{
    public partial class InputNumetricForm : Form
    {
        public int intValue1;
        public int intValue2;
        public double doubleValue1;
        public double doubleValue2;
        public InputNumetricForm(string NameForm, string Labe1, int decimalPlaces1)
        {
            InitializeComponent();
            this.Text = NameForm;
            label1.Text = Labe1;
            if (decimalPlaces1 >= 0)
                numericUpDown1.DecimalPlaces = decimalPlaces1;
            else
                numericUpDown1.DecimalPlaces = 0;

            if (numericUpDown1.DecimalPlaces == 0)
                numericUpDown1.ValueChanged += (sender, e) => { intValue1 = (int)numericUpDown1.Value; };
            else
                numericUpDown1.ValueChanged += (sender, e) => { doubleValue1 = (double)numericUpDown1.Value; };
            this.ControlBox = false;
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Dock = DockStyle.Top;
            toolStrip.Items.Add(new ToolStripButton("Закрыть", null, (sender, e) => this.Close()));
            this.Controls.Add(toolStrip);
        }
        public InputNumetricForm(string NameForm, string Labe1, int decimalPlaces1, string Labe2, int decimalPlaces2)
        {
            InitializeComponent();
            this.Text = NameForm;
            label1.Text = Labe1;
            if (decimalPlaces1 >= 0)
                numericUpDown1.DecimalPlaces = decimalPlaces1;
            else
                numericUpDown1.DecimalPlaces = 0;

            if (numericUpDown1.DecimalPlaces == 0)
                numericUpDown1.ValueChanged += (sender, e) => { intValue1 = (int)numericUpDown1.Value; };
            else
                numericUpDown1.ValueChanged += (sender, e) => { doubleValue1 = (double)numericUpDown1.Value; };
            this.ControlBox = false;
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Dock = DockStyle.Top;
            toolStrip.Items.Add(new ToolStripButton("Закрыть", null, (sender, e) => this.Close()));
            this.Controls.Add(toolStrip);

            label2.Visible = true;
            numericUpDown2.Visible = true;
            Save2.Visible = true;
            label2.Enabled = true;
            numericUpDown2.Enabled = true;
            Save2.Enabled = true;

            label2.Text = Labe2;
            if (decimalPlaces2 >= 0)
                numericUpDown2.DecimalPlaces = decimalPlaces2;
            else
                numericUpDown2.DecimalPlaces = 0;
            if (numericUpDown1.DecimalPlaces == 0)
                numericUpDown2.ValueChanged += (sender, e) => { intValue2 = (int)numericUpDown2.Value; };
            else
                numericUpDown2.ValueChanged += (sender, e) => { doubleValue2 = (double)numericUpDown2.Value; };
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            if (!numericUpDown2.Enabled)
            {   
                numericUpDown1.Value += numericUpDown1.Value;
                numericUpDown1.Value = numericUpDown1.Value / 2;
                if (MessageBox.Show("Вы хотите выйти?", "Подтвердите закрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else { Save2_Click(sender, e); }
        }

        private void Save2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value += numericUpDown1.Value;
            numericUpDown1.Value = numericUpDown1.Value/2;
            numericUpDown2.Value += numericUpDown2.Value;
            numericUpDown2.Value = numericUpDown2.Value / 2;
            if (MessageBox.Show("Вы хотите выйти?", "Подтвердите закрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
