namespace WinFormsApp1
{
    partial class InsertUpdate
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
            nameProduction = new TextBox();
            branchProduction = new TextBox();
            NamePro = new Label();
            label2 = new Label();
            Prodaction = new GroupBox();
            Factory = new GroupBox();
            annualOutput = new NumericUpDown();
            nameFactory = new TextBox();
            label1 = new Label();
            label3 = new Label();
            Workshop = new GroupBox();
            managerWorkshop = new TextBox();
            label5 = new Label();
            Shop = new GroupBox();
            numberShopWorkers = new NumericUpDown();
            label4 = new Label();
            menuStrip1 = new MenuStrip();
            Save = new ToolStripMenuItem();
            SaveExit = new ToolStripMenuItem();
            Cansel = new ToolStripMenuItem();
            CanselExit = new ToolStripMenuItem();
            Exit = new ToolStripMenuItem();
            ActiveClass = new ToolStripMenuItem();
            ProductionItem = new ToolStripMenuItem();
            FactoryItem = new ToolStripMenuItem();
            WorkshopItem = new ToolStripMenuItem();
            ShopItem = new ToolStripMenuItem();
            DeleteElem = new ToolStripMenuItem();
            Prodaction.SuspendLayout();
            Factory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)annualOutput).BeginInit();
            Workshop.SuspendLayout();
            Shop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numberShopWorkers).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // nameProduction
            // 
            nameProduction.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nameProduction.Location = new Point(6, 69);
            nameProduction.Multiline = true;
            nameProduction.Name = "nameProduction";
            nameProduction.RightToLeft = RightToLeft.No;
            nameProduction.Size = new Size(420, 38);
            nameProduction.TabIndex = 0;
            // 
            // branchProduction
            // 
            branchProduction.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            branchProduction.Location = new Point(6, 156);
            branchProduction.Name = "branchProduction";
            branchProduction.Size = new Size(420, 39);
            branchProduction.TabIndex = 0;
            // 
            // NamePro
            // 
            NamePro.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            NamePro.AutoSize = true;
            NamePro.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            NamePro.Location = new Point(73, 31);
            NamePro.Name = "NamePro";
            NamePro.Size = new Size(311, 32);
            NamePro.TabIndex = 1;
            NamePro.Text = "Название производства";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            label2.Location = new Point(6, 121);
            label2.Name = "label2";
            label2.Size = new Size(420, 32);
            label2.TabIndex = 2;
            label2.Text = "Название отрасли производства";
            // 
            // Prodaction
            // 
            Prodaction.BackColor = Color.FromArgb(255, 224, 192);
            Prodaction.Controls.Add(nameProduction);
            Prodaction.Controls.Add(label2);
            Prodaction.Controls.Add(NamePro);
            Prodaction.Controls.Add(branchProduction);
            Prodaction.FlatStyle = FlatStyle.Flat;
            Prodaction.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            Prodaction.Location = new Point(12, 36);
            Prodaction.Name = "Prodaction";
            Prodaction.Size = new Size(432, 227);
            Prodaction.TabIndex = 3;
            Prodaction.TabStop = false;
            Prodaction.Text = "Prodaction";
            // 
            // Factory
            // 
            Factory.BackColor = Color.FromArgb(255, 192, 192);
            Factory.Controls.Add(annualOutput);
            Factory.Controls.Add(nameFactory);
            Factory.Controls.Add(label1);
            Factory.Controls.Add(label3);
            Factory.FlatStyle = FlatStyle.Popup;
            Factory.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            Factory.Location = new Point(454, 36);
            Factory.Name = "Factory";
            Factory.Size = new Size(432, 227);
            Factory.TabIndex = 3;
            Factory.TabStop = false;
            Factory.Text = "Factory";
            // 
            // annualOutput
            // 
            annualOutput.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            annualOutput.DecimalPlaces = 4;
            annualOutput.Location = new Point(6, 156);
            annualOutput.Maximum = new decimal(new int[] { -727379969, 232, 0, 262144 });
            annualOutput.Name = "annualOutput";
            annualOutput.Size = new Size(420, 39);
            annualOutput.TabIndex = 4;
            annualOutput.ThousandsSeparator = true;
            // 
            // nameFactory
            // 
            nameFactory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nameFactory.Location = new Point(6, 69);
            nameFactory.Multiline = true;
            nameFactory.Name = "nameFactory";
            nameFactory.RightToLeft = RightToLeft.No;
            nameFactory.Size = new Size(420, 38);
            nameFactory.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            label1.Location = new Point(50, 121);
            label1.Name = "label1";
            label1.Size = new Size(335, 32);
            label1.TabIndex = 2;
            label1.Text = "Годовой выпуск фабрики";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(77, 31);
            label3.Name = "label3";
            label3.Size = new Size(253, 32);
            label3.TabIndex = 1;
            label3.Text = "Название фабрики";
            // 
            // Workshop
            // 
            Workshop.BackColor = Color.FromArgb(192, 255, 255);
            Workshop.Controls.Add(managerWorkshop);
            Workshop.Controls.Add(label5);
            Workshop.FlatStyle = FlatStyle.Flat;
            Workshop.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            Workshop.Location = new Point(12, 278);
            Workshop.Name = "Workshop";
            Workshop.Size = new Size(432, 222);
            Workshop.TabIndex = 3;
            Workshop.TabStop = false;
            Workshop.Text = "Workshop";
            // 
            // managerWorkshop
            // 
            managerWorkshop.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            managerWorkshop.Location = new Point(6, 92);
            managerWorkshop.Multiline = true;
            managerWorkshop.Name = "managerWorkshop";
            managerWorkshop.RightToLeft = RightToLeft.No;
            managerWorkshop.Size = new Size(420, 38);
            managerWorkshop.TabIndex = 0;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            label5.Location = new Point(90, 57);
            label5.Name = "label5";
            label5.Size = new Size(224, 32);
            label5.TabIndex = 1;
            label5.Text = "ФИО менеджера";
            // 
            // Shop
            // 
            Shop.BackColor = Color.MistyRose;
            Shop.Controls.Add(numberShopWorkers);
            Shop.Controls.Add(label4);
            Shop.FlatStyle = FlatStyle.Flat;
            Shop.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            Shop.Location = new Point(454, 278);
            Shop.Name = "Shop";
            Shop.Size = new Size(432, 222);
            Shop.TabIndex = 3;
            Shop.TabStop = false;
            Shop.Text = "Shop";
            // 
            // numberShopWorkers
            // 
            numberShopWorkers.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numberShopWorkers.Location = new Point(6, 93);
            numberShopWorkers.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numberShopWorkers.Name = "numberShopWorkers";
            numberShopWorkers.Size = new Size(420, 39);
            numberShopWorkers.TabIndex = 2;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold);
            label4.Location = new Point(22, 58);
            label4.Name = "label4";
            label4.Size = new Size(379, 32);
            label4.TabIndex = 1;
            label4.Text = "Количество работников цеха";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Save, Cansel, ActiveClass, DeleteElem, Exit });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(898, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // Save
            // 
            Save.DropDownItems.AddRange(new ToolStripItem[] { SaveExit });
            Save.Name = "Save";
            Save.Size = new Size(97, 24);
            Save.Text = "Сохранить";
            Save.Click += Save_Click;
            // 
            // SaveExit
            // 
            SaveExit.Name = "SaveExit";
            SaveExit.Size = new Size(226, 26);
            SaveExit.Text = "Сохранить и выйти";
            SaveExit.Click += SaveExit_Click;
            // 
            // Cansel
            // 
            Cansel.DropDownItems.AddRange(new ToolStripItem[] { CanselExit });
            Cansel.Name = "Cansel";
            Cansel.Size = new Size(91, 24);
            Cansel.Text = "Отменить";
            Cansel.Click += Cansel_Click;
            // 
            // CanselExit
            // 
            CanselExit.Name = "CanselExit";
            CanselExit.Size = new Size(224, 26);
            CanselExit.Text = "Отменить и выйти";
            CanselExit.Click += toolStripMenuItem1_Click;
            // 
            // Exit
            // 
            Exit.ImageTransparentColor = Color.Blue;
            Exit.Name = "Exit";
            Exit.Size = new Size(67, 24);
            Exit.Text = "Выход";
            Exit.Click += Exit_Click;
            // 
            // ActiveClass
            // 
            ActiveClass.DropDownItems.AddRange(new ToolStripItem[] { ProductionItem, FactoryItem, WorkshopItem, ShopItem });
            ActiveClass.Name = "ActiveClass";
            ActiveClass.Size = new Size(131, 24);
            ActiveClass.Text = "Класс элемента";
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
            // DeleteElem
            // 
            DeleteElem.Name = "DeleteElem";
            DeleteElem.Size = new Size(140, 24);
            DeleteElem.Text = "Удалить элемент";
            DeleteElem.Click += DeleteElem_Click;
            // 
            // InsertUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 507);
            Controls.Add(Factory);
            Controls.Add(Shop);
            Controls.Add(Workshop);
            Controls.Add(Prodaction);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "InsertUpdate";
            Text = "InsertUpdate";
            Prodaction.ResumeLayout(false);
            Prodaction.PerformLayout();
            Factory.ResumeLayout(false);
            Factory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)annualOutput).EndInit();
            Workshop.ResumeLayout(false);
            Workshop.PerformLayout();
            Shop.ResumeLayout(false);
            Shop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numberShopWorkers).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameProduction;
        private TextBox branchProduction;
        private Label NamePro;
        private Label label2;
        private GroupBox Prodaction;
        private GroupBox Factory;
        private TextBox nameFactory;
        private Label label1;
        private Label label3;
        private NumericUpDown annualOutput;
        private GroupBox Workshop;
        private TextBox managerWorkshop;
        private Label label5;
        private GroupBox Shop;
        private NumericUpDown numberShopWorkers;
        private Label label4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Save;
        private ToolStripMenuItem SaveExit;
        private ToolStripMenuItem Cansel;
        private ToolStripMenuItem CanselExit;
        private ToolStripMenuItem Exit;
        private ToolStripMenuItem ActiveClass;
        private ToolStripMenuItem ProductionItem;
        private ToolStripMenuItem FactoryItem;
        private ToolStripMenuItem WorkshopItem;
        private ToolStripMenuItem ShopItem;
        private ToolStripMenuItem DeleteElem;
    }
}