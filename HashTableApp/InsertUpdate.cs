using HashTableCollection;
using UserLibraryProductionShop;

namespace WinFormsApp1
{
    public partial class InsertUpdate : Form
    {

        int indexClass = -1;
        object old;

        public object Old { get;set; }
        public object New { get;set; }
        public object cur;
        public HashSet<object> Value;

        public InsertUpdate(object value)
        {
            InitializeComponent();
            if ( value is null)
            {
                this.Close();
            }
            old = value;
            cur = value;
            indexClass = CheckClass(cur);
            CheckClass(cur);

            cur = new Shop();
            

        }
        public InsertUpdate()
        {
            InitializeComponent();
            cur = new Shop();
            ShopItem_Click(this, new EventArgs());
            this.Text = "Добавление";
            Save.Text = "Добавить";
            SaveExit.Text = "Добавить и выйти";
            Value = new HashSet<object>();
            DeleteElem.Visible = false;
            DeleteElem.Enabled = false;

        }
        private void SelectClassMenu(int index)
        {
            ProductionItem.Checked = index == 0;
            FactoryItem.Checked = index == 1;
            WorkshopItem.Checked = index == 2;
            ShopItem.Checked = index == 3;
        }
        private int CheckClass(object cur)
        {
            if (cur is Shop)
            {
                ShopItem_Click(cur, new EventArgs());
                return indexClass;
            }
            else if (cur is Workshop)
            {
                WorkshopItem_Click(cur, new EventArgs());
                return indexClass;
            }
            else if (cur is Factory)
            {
                FactoryItem_Click(cur, new EventArgs());
                return indexClass;
            }
            else if (cur is Production)
            {
                ProductionItem_Click(cur, new EventArgs());
                return indexClass;
            }
            else return -1;
        }

        private void Exit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы хотите выйти?", "Подтвердите закрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void setSettings(int index)
        {
            object[][] objects =
            [
                new object[] {
                DockStyle.Fill ,
                DockStyle.None,
                DockStyle.None,
                DockStyle.None,
                true,
                true,
                false,
                false,
                false,
                false,
                false,
                false
            },new object[] {
                DockStyle.Left ,
                DockStyle.Right,
                DockStyle.None,
                DockStyle.None,
                true,
                true,
                true,
                true,
                false,
                false,
                false,
                false
            },new object[] {
                DockStyle.None ,
                DockStyle.None,
                DockStyle.Bottom,
                DockStyle.None,
                true,
                true,
                true,
                true,
                true,
                true,
                false,
                false
            },new object[] {
                DockStyle.None ,
                DockStyle.None,
                DockStyle.None,
                DockStyle.None,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true
            }
            ];
            if (index < 0 || index > 3)
            {
                index = 3;
            }
            object[] settings = objects[index];
            Prodaction.Dock = (DockStyle)settings[0];
            Factory.Dock = (DockStyle)settings[1];
            Workshop.Dock = (DockStyle)settings[2];
            Shop.Dock = (DockStyle)settings[3];
            Prodaction.Visible = (bool)settings[4];
            Prodaction.Enabled = (bool)settings[5];
            Factory.Visible = (bool)settings[6];
            Factory.Enabled = (bool)settings[7];
            Workshop.Visible = (bool)settings[8];
            Workshop.Enabled = (bool)settings[9];
            Shop.Visible = (bool)settings[10];
            Shop.Enabled = (bool)settings[11];
        }
        private void ProductionItem_Click(object sender, EventArgs e)
        {
            if((indexClass == 0))
            {
                Production shop = (Production)cur;
                nameProduction.Text = shop.NameProduction;
                branchProduction.Text = shop.BranchProduction;
            }            
            this.Text = "Изменение Production";
            setSettings(0);
            indexClass = 0;
            SelectClassMenu(indexClass);
            
        }
        private void FactoryItem_Click(object sender, EventArgs e)
        {
            if (!(indexClass < 1))
            {
                Factory shop = (Factory)cur;
                nameProduction.Text = shop.NameProduction;
                branchProduction.Text = shop.BranchProduction;
                nameFactory.Text = shop.NameFactory;
                annualOutput.Value = (decimal)shop.AnnualOutput;
            }
            this.Text = "Изменение Factory";
            setSettings(1);
            indexClass = 1;
            SelectClassMenu(indexClass);

        }
        private void WorkshopItem_Click(object sender, EventArgs e)
        {
            if (!(indexClass < 2))
            {
                Workshop shop = (Workshop)cur;
                nameProduction.Text = shop.NameProduction;
                branchProduction.Text = shop.BranchProduction;
                nameFactory.Text = shop.NameFactory;
                annualOutput.Value = (decimal)shop.AnnualOutput;
                managerWorkshop.Text = shop.ManagerWorkshop;
            }
            this.Text = "Изменение Workshop";
            Workshop.Dock = DockStyle.Bottom;
            setSettings(2);
            indexClass = 2;
            SelectClassMenu(indexClass);

        }
        private void ShopItem_Click(object sender, EventArgs e)
        {
            if (!(indexClass < 3))
            {
                Shop shop = (Shop)cur;
                nameProduction.Text = shop.NameProduction;
                branchProduction.Text = shop.BranchProduction;
                nameFactory.Text = shop.NameFactory;
                annualOutput.Value = (decimal)shop.AnnualOutput;
                managerWorkshop.Text = shop.ManagerWorkshop;
                numberShopWorkers.Value = shop.NumberShopWorkers;
            }
            this.Text = "Изменение Shop";
            setSettings(3);
            indexClass = 3;
            SelectClassMenu(indexClass);
        }
        private void Save_Click(object sender, EventArgs e)
        {
            switch (indexClass)
            {
                case 0:
                    New= new Production(nameProduction.Text, branchProduction.Text);
                    break;
                case 1:
                    New = new Factory(nameProduction.Text, branchProduction.Text, nameFactory.Text, (double)annualOutput.Value);
                    break;
                case 2:
                    New = new Workshop(nameProduction.Text, branchProduction.Text, nameFactory.Text, (double)annualOutput.Value, managerWorkshop.Text);
                    break;
                case 3:
                    New = new Shop(nameProduction.Text, branchProduction.Text, nameFactory.Text, (double)annualOutput.Value, managerWorkshop.Text, (int)numberShopWorkers.Value);
                    break;
            }
            if (Value is not null)
                Value.Add(New);
            


        }

        private void SaveExit_Click(object sender, EventArgs e)
        {
            Save_Click(sender, e);
            Old=old;
            Exit_Click(sender, e);
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            cur = old;
            indexClass = CheckClass(cur);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cansel_Click(sender, e);           
            Exit_Click(sender, e);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DeleteElem_Click(object sender, EventArgs e)
        {
            cur = null;
            Old = old;            
            Exit_Click(sender, e);

        }
    }
}
