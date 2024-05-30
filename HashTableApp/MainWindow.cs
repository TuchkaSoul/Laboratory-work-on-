using HashTableCollection;
using System.Data;
using System.Diagnostics;
using UserLibraryProductionShop;


namespace WinFormsApp1
{
    public partial class MainWindow : Form
    {
        public static HahTable<Production> table;
        private string fileName;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void PrintCase_Click(object sender, EventArgs e)
        {
            if (PrintPV.Checked)
            {
                PrintPV.Checked = false;
            }
            PrintCase.Checked = true;
            DataTable dataTable = new DataTable();
            DataColumn idColumn = new DataColumn("Номер корзины", typeof(int));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = true; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 0; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки
            dataTable.Columns.Add(idColumn);

            int k = table.MaxSize<Production>();
            for (int i = 0; i < k; i++)
            {
                DataColumn valColumn = new DataColumn($"Содержимое {i}", typeof(Production));
                valColumn.AllowDBNull = true; // не может принимать null
                dataTable.Columns.Add(valColumn);
            }

            foreach (var production in table.table)
            {
                DataRow dataRow = dataTable.NewRow();
                object[] objects = new object[k + 1];
                var cur = production;
                int i = 1;
                while (cur is not null)
                {
                    objects[i++] = cur.value;
                    if (cur.next is not null)
                    {
                        cur = cur.next;
                    }
                    else
                        break;
                }
                dataRow.ItemArray = objects;
                dataTable.Rows.Add(dataRow);
            }
            dataGridView1.DataSource = dataTable;
        }

        private void PrintPV_Click(object sender, EventArgs e)
        {
            if (PrintCase.Checked)
            {
                PrintCase.Checked = false;
            }
            PrintPV.Checked = true;
            DataTable dataTable = new DataTable();
            DataColumn idColumn = new DataColumn("Номер №", typeof(int));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = true; // не может принимать null
            idColumn.AutoIncrement = true; // будет авто инкрементироваться
            idColumn.AutoIncrementSeed = 0; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки
            dataTable.Columns.Add(idColumn);
            dataTable.Columns.Add("Элемент", typeof(Production));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };
            foreach (var production in table)
            {
                dataTable.Rows.Add([null, production]);
            }
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex <= 0 || e.RowIndex == -1)
            {
                return;
            }
            else
            {
                if (Del.Checked)
                {
                    table.Remove((Production)dataGridView1[e.ColumnIndex, e.RowIndex].Value);
                }
                else
                {
                    //MessageBox.Show(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString(), "Уведомление о создании", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InsertUpdate update = new InsertUpdate(dataGridView1[e.ColumnIndex, e.RowIndex].Value);
                    update.ShowDialog();
                    table.Remove((Production)update.Old);
                    table.Add((Production)update.New);
                }
            }
            UpdateGridData(sender, e);
        }

        private void UpdateGridData(object sender, EventArgs e)
        {
            if (PrintCase.Checked)
            {
                PrintCase_Click(sender, e);
            }
            else
            {
                PrintPV_Click(sender, e);
            }
        }      

        private void Del_Click(object sender, EventArgs e)
        {
            Del.ForeColor = Del.Checked ? Color.Red : Color.Black;
            Del.Text = Del.Checked ? "Не Удалять элемент по нажатию" : "Удалять элемент по нажатию";
        }

        private void AddRandomMenuItem_Click(object sender, EventArgs e)
        {
            table.InitAddCollRandomN(1);
            UpdateGridData(sender, e);
        }

        private void AddManualMenuItem2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"{table.MaxSize<Production>()}\n{table.Count}", "Уведомление о создании", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            InsertUpdate update = new InsertUpdate();
            update.ShowDialog();
            if (update.Value.Count > 0)
                foreach (var item in update.Value)
                    table.Add((Production)item);
            UpdateGridData(sender, e);
        }

        private void количествоКорзин10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = new HahTable<Production>(10);
            Unlock();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            table = new HahTable<Production>(200);
            table.InitAddCollRandomN(1000);
            Unlock();

            PrintCase_Click(sender, e);
        }
        private void Unlock()
        {
            PrintMenuItem.Enabled = true;
            testToolStripMenuItem.Enabled = true;
            Del.Enabled = true;
            ClearTable.Enabled = true;
            FilterToolStripMenuItem.Enabled = true;
            SaveDef.Enabled = true;
            SaveHow.Enabled = true;
        }

        private void количествоКорзин25ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = new HahTable<Production>(25);
            Unlock();

        }

        private void количествоКорзин3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = new HahTable<Production>(50);
            Unlock();

        }

        private void количествоКорзин100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = new HahTable<Production>(100);
            Unlock();
        }

        private void ClearTable_Click(object sender, EventArgs e)
        {
            if (table != null)
            {
                table.Clear();
                UpdateGridData(sender, e);
            }

        }
        private void MunualCreaterMenuItem3_Click(object sender, EventArgs e)
        {
            InputNumetricForm input = new InputNumetricForm("Ввод количества корзин в hahtable", "Количество корзин", 0);
            input.ShowDialog();
            if (input.intValue1 > 0)
            {
                table = new HahTable<Production>(input.intValue1);
                Unlock();
                UpdateGridData(sender, e);
            }
            else if (MessageBox.Show("Создание провалено", "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
            {
                MunualCreaterMenuItem3_Click(sender, e);
            }
        }

        private void AddNElement_Click(object sender, EventArgs e)
        {
            InputNumetricForm input = new InputNumetricForm("Ввод количества элементов для добавления в hahtable", "Количество элементов", 0);
            input.ShowDialog();
            if (input.intValue1 > 0)
            {
                table.InitAddCollRandomN(input.intValue1);
                Unlock();
                UpdateGridData(sender, e);
            }
            else if (MessageBox.Show("Добавление провалено", "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
            {
                MunualCreaterMenuItem3_Click(sender, e);
            }
        }

        private void CreateFilling_Click(object sender, EventArgs e)
        {
            InputNumetricForm input = new InputNumetricForm("Форма создания", "Количество корзин", 0, "Количество элементов", 0);
            input.ShowDialog();
            if (input.intValue1 > 0 && input.intValue2 > 0)
            {
                table = new HahTable<Production>(input.intValue1);
                table.InitAddCollRandomN(input.intValue2);
                Unlock();
                UpdateGridData(sender, e);
            }
            else if (MessageBox.Show("Создание провалено", "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
            {
                MunualCreaterMenuItem3_Click(sender, e);
            }
        }

        private void UseFilltres<T>(IEnumerable<T> sortTable)
        {
            if (PrintCase.Checked)
            {
                PrintCase.Checked = false;
            }
            PrintPV.Checked = false;
            DataTable dataTable = new DataTable();
            DataColumn idColumn = new DataColumn("Номер №", typeof(int));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = true; // не может принимать null
            idColumn.AutoIncrement = true; // будет авто инкрементироваться
            idColumn.AutoIncrementSeed = 0; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки
            dataTable.Columns.Add(idColumn);
            dataTable.Columns.Add("Элемент", typeof(Production));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };
            foreach (var production in sortTable)
            {
                dataTable.Rows.Add([null, production]);
            }
            dataGridView1.DataSource = dataTable;
        }
        private void ProductionItem_Click(object sender, EventArgs e)
        {
            UseFilltres(table.FilterByExactType(typeof(Production)));
        }

        private void FactoryItem_Click(object sender, EventArgs e)
        {
            UseFilltres(table.FilterByExactType(typeof(Factory)));
        }

        private void WorkshopItem_Click(object sender, EventArgs e)
        {
            UseFilltres(table.FilterByExactType(typeof(Workshop)));
        }

        private void ShopItem_Click(object sender, EventArgs e)
        {
            UseFilltres(table.FilterByExactType(typeof(Shop)));
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var filteredResults = table.FilterByExactType(typeof(Production))
                           .Union(table.FilterByExactType(typeof(Factory)))
                           .Union(table.FilterByExactType(typeof(Workshop)))
                           .Union(table.FilterByExactType(typeof(Shop)));
            UseFilltres(filteredResults);
        }

        private void SaveTxt_Click(object sender, EventArgs e)
        {
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Сохранение в Текстовый файл";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Операция была отменена пользователем.","Отмена",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            fileName = saveFileDialog.FileName;
            SaveDef_Click(sender, e);
        }

        private void SaveBin_Click(object sender, EventArgs e)
        {
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.Title = "Сохранение в бинарный файл";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Операция была отменена пользователем.","Отмена",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            fileName = saveFileDialog.FileName;
            SaveDef_Click(sender, e);

        }

        private void SaveDef_Click(object sender, EventArgs e)
        {
            if (fileName == null)
            {
                MessageBox.Show("Операция была отменена\nВыберите путь сохранения.","Отмена",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            try
            {
                SerializationHahtable sh = new SerializationHahtable(fileName);
                if (CheckTime.Checked)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    sh.SerializeAsync(table);
                    stopwatch.Stop();
                    MessageBox.Show($"Cериализация в файл {stopwatch.ElapsedMilliseconds} ms", "Время", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sh.SerializeAsync(table);
                    MessageBox.Show("Операция была успешно выполнена.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                return;
            }
        }
        private async void OpenFileMenuItem_Click(object sender, EventArgs e)
        {
            if (table is null || table.Length == 0)
            {
                MunualCreaterMenuItem3_Click(sender, e);
            }
            if (openFileTable.ShowDialog() == DialogResult.Cancel) return;
            ClearTable_Click(sender, EventArgs.Empty);
            fileName = openFileTable.FileName;
            SerializationHahtable sh = new SerializationHahtable(fileName);
            if(CheckTime.Checked)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                table.Add(await sh.DeserializeAsync(fileName));
                stopwatch.Stop();
                MessageBox.Show($"Десериализация из файла {stopwatch.ElapsedMilliseconds} ms","Время",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                table.Add(await sh.DeserializeAsync(fileName));
            }
            Unlock();
            PrintPV_Click(sender, e);
        }

        private void SaveXML_Click(object sender, EventArgs e)
        {
            saveFileDialog.FilterIndex = 3;
            saveFileDialog.Title = "Сохранение в Xml файл";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Операция была отменена пользователем.","Отмена",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            fileName = saveFileDialog.FileName;
            SaveDef_Click(sender, e);

        }

        private void SaveJson_Click(object sender, EventArgs e)
        {
            saveFileDialog.FilterIndex = 4;

            saveFileDialog.Title = "Сохранение в Json-файл";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Операция была отменена пользователем.","Отмена",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            fileName = saveFileDialog.FileName;
            SaveDef_Click(sender, e);

        }

        private void SpeedTest_Click(object sender, EventArgs e)
        {
            if (openFileTable.ShowDialog() == DialogResult.Cancel) return;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Характеристики", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Тип теста", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Асинхронность", typeof(string)));
            dataTable.Columns.Add(new DataColumn("TXT", typeof(long)));
            dataTable.Columns.Add(new DataColumn("BIN", typeof(long)));
            dataTable.Columns.Add(new DataColumn("XML", typeof(long)));
            dataTable.Columns.Add(new DataColumn("JSON", typeof(long)));

            Test(openFileTable.FileName, ref dataTable, 10, 1000);
            Test(openFileTable.FileName, ref dataTable, 10, 2000);
            Test(openFileTable.FileName, ref dataTable, 100, 1000);
            Test(openFileTable.FileName, ref dataTable, 100, 2000);
            Test(openFileTable.FileName, ref dataTable, 1000, 1000);
            Test(openFileTable.FileName, ref dataTable, 1000, 2000);

            dataGridView1.DataSource = dataTable;



        }
        private static void Test(string FileName, ref DataTable dataTable, int size = 100, int count = 1000)
        {
            HahTable<Production> table = new HahTable<Production>(size);
            table.InitAddCollRandomN(count);
            SerializationHahtable timer = new SerializationHahtable(FileName);
            List<List<long>> list = new List<List<long>>();
            list.Add(timer.MeasureSerializationTime(table));
            System.Threading.Tasks.Task.Run(() => { list.Add(timer.MeasureSerializationTime(table)); }).Wait();
            System.Threading.Tasks.Task.Run(() => { list.Add(timer.MeasureSerializationTimeAsync(table)); }).Wait();
            System.Threading.Tasks.Task.Run(() => { list.Add(timer.MeasureDeserializationTime()); }).Wait();
            System.Threading.Tasks.Task.Run(() => { list.Add(timer.MeasureDeserializationTimeAsync().Result); }).Wait();


            
            
            int l = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    object[] objects = new object[7];
                    int k = 3;
                    objects[0] = $"Длина-Количество: {table.Length} - {table.Count}";
                    objects[1] = i == 0 ? "Запись" : "Чтение";
                    objects[2] = j == 0 ? "Синхронно" : "Асинхронно";
                    foreach (long time in list[l])
                    {
                        objects[k++] = time;
                    }
                    l++;
                    dataRow.ItemArray = objects;
                    dataTable.Rows.Add(dataRow);

                }
            }
        }
    }
}
