namespace WinFormsApp1
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            CreaterRandomToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            CreateFilling = new ToolStripMenuItem();
            стандартноToolStripMenuItem = new ToolStripMenuItem();
            количествоКорзин10ToolStripMenuItem = new ToolStripMenuItem();
            количествоКорзин25ToolStripMenuItem = new ToolStripMenuItem();
            количествоКорзин3ToolStripMenuItem = new ToolStripMenuItem();
            количествоКорзин100ToolStripMenuItem = new ToolStripMenuItem();
            MunualCreaterMenuItem3 = new ToolStripMenuItem();
            OpenFileMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ClearTable = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            SaveDef = new ToolStripMenuItem();
            SaveHow = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            SaveXML = new ToolStripMenuItem();
            SaveJson = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            SpeedTest = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            AddRandomMenuItem = new ToolStripMenuItem();
            AddManualMenuItem2 = new ToolStripMenuItem();
            AddNElement = new ToolStripMenuItem();
            PrintMenuItem = new ToolStripMenuItem();
            PrintPV = new ToolStripMenuItem();
            PrintCase = new ToolStripMenuItem();
            Del = new ToolStripMenuItem();
            FilterToolStripMenuItem = new ToolStripMenuItem();
            ActiveClass = new ToolStripMenuItem();
            ProductionItem = new ToolStripMenuItem();
            FactoryItem = new ToolStripMenuItem();
            WorkshopItem = new ToolStripMenuItem();
            ShopItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            openFileTable = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            CheckTime = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Snow;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, testToolStripMenuItem, PrintMenuItem, Del, FilterToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1350, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { CreaterRandomToolStripMenuItem, OpenFileMenuItem, toolStripSeparator1, ClearTable, toolStripSeparator2, SaveDef, SaveHow, toolStripSeparator3, SpeedTest });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(59, 24);
            toolStripMenuItem1.Text = "Файл";
            // 
            // CreaterRandomToolStripMenuItem
            // 
            CreaterRandomToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, стандартноToolStripMenuItem, MunualCreaterMenuItem3 });
            CreaterRandomToolStripMenuItem.Name = "CreaterRandomToolStripMenuItem";
            CreaterRandomToolStripMenuItem.Size = new Size(236, 26);
            CreaterRandomToolStripMenuItem.Text = "Создать новый файл";            
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { CreateFilling });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(289, 26);
            toolStripMenuItem2.Text = "Случайно заполненый файл";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // CreateFilling
            // 
            CreateFilling.Name = "CreateFilling";
            CreateFilling.Size = new Size(237, 26);
            CreateFilling.Text = "Создать и заполнить";
            CreateFilling.Click += CreateFilling_Click;
            // 
            // стандартноToolStripMenuItem
            // 
            стандартноToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { количествоКорзин10ToolStripMenuItem, количествоКорзин25ToolStripMenuItem, количествоКорзин3ToolStripMenuItem, количествоКорзин100ToolStripMenuItem });
            стандартноToolStripMenuItem.Name = "стандартноToolStripMenuItem";
            стандартноToolStripMenuItem.Size = new Size(289, 26);
            стандартноToolStripMenuItem.Text = "Стандартно";
            // 
            // количествоКорзин10ToolStripMenuItem
            // 
            количествоКорзин10ToolStripMenuItem.Name = "количествоКорзин10ToolStripMenuItem";
            количествоКорзин10ToolStripMenuItem.Size = new Size(255, 26);
            количествоКорзин10ToolStripMenuItem.Text = "Количество корзин 10";
            количествоКорзин10ToolStripMenuItem.Click += количествоКорзин10ToolStripMenuItem_Click;
            // 
            // количествоКорзин25ToolStripMenuItem
            // 
            количествоКорзин25ToolStripMenuItem.Name = "количествоКорзин25ToolStripMenuItem";
            количествоКорзин25ToolStripMenuItem.Size = new Size(255, 26);
            количествоКорзин25ToolStripMenuItem.Text = "Количество корзин 25";
            количествоКорзин25ToolStripMenuItem.Click += количествоКорзин25ToolStripMenuItem_Click;
            // 
            // количествоКорзин3ToolStripMenuItem
            // 
            количествоКорзин3ToolStripMenuItem.Name = "количествоКорзин3ToolStripMenuItem";
            количествоКорзин3ToolStripMenuItem.Size = new Size(255, 26);
            количествоКорзин3ToolStripMenuItem.Text = "Количество корзин 50";
            количествоКорзин3ToolStripMenuItem.Click += количествоКорзин3ToolStripMenuItem_Click;
            // 
            // количествоКорзин100ToolStripMenuItem
            // 
            количествоКорзин100ToolStripMenuItem.Name = "количествоКорзин100ToolStripMenuItem";
            количествоКорзин100ToolStripMenuItem.Size = new Size(255, 26);
            количествоКорзин100ToolStripMenuItem.Text = "Количество корзин 100";
            количествоКорзин100ToolStripMenuItem.Click += количествоКорзин100ToolStripMenuItem_Click;
            // 
            // MunualCreaterMenuItem3
            // 
            MunualCreaterMenuItem3.Name = "MunualCreaterMenuItem3";
            MunualCreaterMenuItem3.Size = new Size(289, 26);
            MunualCreaterMenuItem3.Text = "Вручную";
            MunualCreaterMenuItem3.Click += MunualCreaterMenuItem3_Click;
            // 
            // OpenFileMenuItem
            // 
            OpenFileMenuItem.Name = "OpenFileMenuItem";
            OpenFileMenuItem.Size = new Size(236, 26);
            OpenFileMenuItem.Text = "Открыть";
            OpenFileMenuItem.Click += OpenFileMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(233, 6);
            // 
            // ClearTable
            // 
            ClearTable.Enabled = false;
            ClearTable.Name = "ClearTable";
            ClearTable.Size = new Size(236, 26);
            ClearTable.Text = "Очистить файл";
            ClearTable.Click += ClearTable_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(233, 6);
            // 
            // SaveDef
            // 
            SaveDef.Enabled = false;
            SaveDef.Name = "SaveDef";
            SaveDef.Size = new Size(236, 26);
            SaveDef.Text = "Сохранить";
            SaveDef.Click += SaveDef_Click;
            // 
            // SaveHow
            // 
            SaveHow.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem5, toolStripMenuItem6, SaveXML, SaveJson });
            SaveHow.Enabled = false;
            SaveHow.Name = "SaveHow";
            SaveHow.Size = new Size(236, 26);
            SaveHow.Text = "Сохранить как";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(242, 26);
            toolStripMenuItem5.Text = "Текстовый файл(.TXT)";
            toolStripMenuItem5.Click += SaveTxt_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(242, 26);
            toolStripMenuItem6.Text = "Binary(.BIN)";
            toolStripMenuItem6.Click += SaveBin_Click;
            // 
            // SaveXML
            // 
            SaveXML.Name = "SaveXML";
            SaveXML.Size = new Size(242, 26);
            SaveXML.Text = "XML-Файл(.XML)";
            SaveXML.Click += SaveXML_Click;
            // 
            // SaveJson
            // 
            SaveJson.Name = "SaveJson";
            SaveJson.Size = new Size(242, 26);
            SaveJson.Text = "JSON-Файл(.JSON)";
            SaveJson.Click += SaveJson_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(233, 6);
            // 
            // SpeedTest
            // 
            SpeedTest.DropDownItems.AddRange(new ToolStripItem[] { CheckTime });
            SpeedTest.Name = "SpeedTest";
            SpeedTest.Size = new Size(236, 26);
            SpeedTest.Text = "Замерить время";
            SpeedTest.Click += SpeedTest_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddRandomMenuItem, AddManualMenuItem2, AddNElement });
            testToolStripMenuItem.Enabled = false;
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(151, 24);
            testToolStripMenuItem.Text = "Добавить элемент";            
            // 
            // AddRandomMenuItem
            // 
            AddRandomMenuItem.Name = "AddRandomMenuItem";
            AddRandomMenuItem.Size = new Size(313, 26);
            AddRandomMenuItem.Text = "Добавить случайный элемент";
            AddRandomMenuItem.Click += AddRandomMenuItem_Click;
            // 
            // AddManualMenuItem2
            // 
            AddManualMenuItem2.Name = "AddManualMenuItem2";
            AddManualMenuItem2.Size = new Size(313, 26);
            AddManualMenuItem2.Text = "Добавить вручную";
            AddManualMenuItem2.Click += AddManualMenuItem2_Click;
            // 
            // AddNElement
            // 
            AddNElement.Name = "AddNElement";
            AddNElement.Size = new Size(313, 26);
            AddNElement.Text = "Добавить несколько элементов";
            AddNElement.Click += AddNElement_Click;
            // 
            // PrintMenuItem
            // 
            PrintMenuItem.DropDownItems.AddRange(new ToolStripItem[] { PrintPV, PrintCase });
            PrintMenuItem.Enabled = false;
            PrintMenuItem.Name = "PrintMenuItem";
            PrintMenuItem.Size = new Size(133, 24);
            PrintMenuItem.Text = "Вывод на экран";
            // 
            // PrintPV
            // 
            PrintPV.CheckOnClick = true;
            PrintPV.Name = "PrintPV";
            PrintPV.Size = new Size(272, 26);
            PrintPV.Text = "Отображать по порядку";
            PrintPV.Click += PrintPV_Click;
            // 
            // PrintCase
            // 
            PrintCase.CheckOnClick = true;
            PrintCase.Name = "PrintCase";
            PrintCase.Size = new Size(272, 26);
            PrintCase.Text = "Отображать по корзинам";
            PrintCase.Click += PrintCase_Click;
            // 
            // Del
            // 
            Del.CheckOnClick = true;
            Del.Enabled = false;
            Del.Name = "Del";
            Del.Size = new Size(228, 24);
            Del.Text = "Удалять элемент по нажатию";
            Del.Click += Del_Click;
            // 
            // FilterToolStripMenuItem
            // 
            FilterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ActiveClass, toolStripMenuItem4 });
            FilterToolStripMenuItem.Enabled = false;
            FilterToolStripMenuItem.Name = "FilterToolStripMenuItem";
            FilterToolStripMenuItem.Size = new Size(74, 24);
            FilterToolStripMenuItem.Text = "Фильтр";
            // 
            // ActiveClass
            // 
            ActiveClass.DropDownItems.AddRange(new ToolStripItem[] { ProductionItem, FactoryItem, WorkshopItem, ShopItem });
            ActiveClass.Name = "ActiveClass";
            ActiveClass.Size = new Size(183, 26);
            ActiveClass.Text = "По Классам";
            // 
            // ProductionItem
            // 
            ProductionItem.Name = "ProductionItem";
            ProductionItem.Size = new Size(164, 26);
            ProductionItem.Text = "Production";
            ProductionItem.Click += ProductionItem_Click;
            // 
            // FactoryItem
            // 
            FactoryItem.Name = "FactoryItem";
            FactoryItem.Size = new Size(164, 26);
            FactoryItem.Text = "Factory";
            FactoryItem.Click += FactoryItem_Click;
            // 
            // WorkshopItem
            // 
            WorkshopItem.Name = "WorkshopItem";
            WorkshopItem.Size = new Size(164, 26);
            WorkshopItem.Text = "Workshop";
            WorkshopItem.Click += WorkshopItem_Click;
            // 
            // ShopItem
            // 
            ShopItem.Name = "ShopItem";
            ShopItem.Size = new Size(164, 26);
            ShopItem.Text = "Shop";
            ShopItem.Click += ShopItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(183, 26);
            toolStripMenuItem4.Text = "Иеархически";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = SystemColors.WindowText;
            dataGridView1.Location = new Point(0, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.ShowCellErrors = false;
            dataGridView1.ShowCellToolTips = false;
            dataGridView1.Size = new Size(1350, 645);
            dataGridView1.StandardTab = true;
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // openFileTable
            // 
            openFileTable.FileName = "openFileDialog1";
            openFileTable.Filter = "Текстовый документ|*.txt|Бинарный документ|*.bin|Xml-файл|*.xml|Json-файл|*.json|Все файлы|*.*";
            
            // 
            // saveFileDialog
            // 
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Filter = "Текстовый документ|*.txt|Бинарный документ|*.bin|Xml-файл|*.xml|Json-файл|*.json|Все файлы|*.*";
            // 
            // CheckTime
            // 
            CheckTime.Checked = true;
            CheckTime.CheckOnClick = true;
            CheckTime.CheckState = CheckState.Checked;
            CheckTime.Name = "CheckTime";
            CheckTime.Size = new Size(224, 26);
            CheckTime.Text = "Замерять время";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(1350, 673);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Лабораторная работа 16 Hash-Table";            
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem CreaterRandomToolStripMenuItem;
        private ToolStripMenuItem OpenFileMenuItem;
        private DataGridView dataGridView1;
        private ToolStripMenuItem PrintMenuItem;
        private ToolStripMenuItem PrintCase;
        private ToolStripMenuItem PrintPV;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem Del;
        private ToolStripMenuItem AddRandomMenuItem;
        private ToolStripMenuItem AddManualMenuItem2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem стандартноToolStripMenuItem;
        private ToolStripMenuItem количествоКорзин10ToolStripMenuItem;
        private ToolStripMenuItem количествоКорзин25ToolStripMenuItem;
        private ToolStripMenuItem количествоКорзин3ToolStripMenuItem;
        private ToolStripMenuItem количествоКорзин100ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem ClearTable;
        private OpenFileDialog openFileTable;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem MunualCreaterMenuItem3;
        private ToolStripMenuItem AddNElement;
        private ToolStripMenuItem CreateFilling;
        private ToolStripMenuItem FilterToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem ActiveClass;
        private ToolStripMenuItem ProductionItem;
        private ToolStripMenuItem FactoryItem;
        private ToolStripMenuItem WorkshopItem;
        private ToolStripMenuItem ShopItem;
        private ToolStripMenuItem SaveDef;
        private ToolStripMenuItem SaveHow;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem SpeedTest;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem SaveXML;
        private ToolStripMenuItem SaveJson;
        private SaveFileDialog saveFileDialog;
        private ToolStripMenuItem CheckTime;
    }
}
