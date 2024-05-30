using System.Media;

namespace AerialReconnaissance
{
    public partial class Form1 : Form
    {
        int n = 20;
        static int[,]? mapData;
        static Point droneBaseLocal = new Point(-10, -10);
        readonly Dictionary<int, Drone> droneDict = new Dictionary<int, Drone>();        
        Task[] tasks;
        bool isRunning = false;
        bool isBreak = true;
        int coverSize = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mapData = new int[n, n];
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
            Nmatrix.Text = $"{n}";
            CreaterButton_Click(sender, e);
        }

        private void DataGridView1_CellContentDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (droneBaseLocal != new Point(-10, -10))
            {
                mapData[droneBaseLocal.X, droneBaseLocal.Y] = 0;
                dataGridView1.Rows[droneBaseLocal.X].Cells[droneBaseLocal.Y].Value = " ";
                dataGridView1.Rows[droneBaseLocal.X].Cells[droneBaseLocal.Y].Style.BackColor = Color.White;
                if (tasks != null)
                {
                    isRunning=false;
                    isBreak=false;                    
                    Task.WaitAll(tasks);
                }
                isBreak = true;                
                toolStripStatusLabel1.Text = "OK";
            }
            else
                droneBaseLocal = new Point(e.RowIndex, e.ColumnIndex);
            mapData[e.RowIndex, e.ColumnIndex] = 3;
            coverSize = 1;
            ProgressBar1.Value = coverSize;
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Gold;
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "✈️"; //0 or 1
            droneBaseLocal = new Point(e.RowIndex, e.ColumnIndex);
        }

        private void CreaterButton_Click(object sender, EventArgs e)
        {
            if (Nmatrix.Value > 80 && toolStripStatusLabel1.Text != "Это действие не рекомендуется")
            {
                SystemSounds.Beep.Play();
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Это действие не рекомендуется";
                return;
            }
            n = (int)Nmatrix.Value;
            toolStripStatusLabel1.ForeColor = Color.Green;
            toolStripStatusLabel1.Text = "OK";
            ProgressBar1.Maximum = n*n;
            droneDict.Clear();
            Random rand = new Random();
            droneBaseLocal = new Point();
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
            mapData = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mapData[i, j] = rand.Next(100);
                    if (mapData[i, j] >= 80)
                    {
                        if (mapData[i, j] >= 97)
                        {
                            mapData[i, j] = 2;
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Violet;
                            dataGridView1.Rows[i].Cells[j].Value = "💰"; //0 or 1
                        }
                        else
                        {
                            mapData[i, j] = 1;
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightSkyBlue;
                            dataGridView1.Rows[i].Cells[j].Value = "💸"; //0 or 1
                        }
                    }
                    else
                    {
                        mapData[i, j] = 0;
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        dataGridView1.Rows[i].Cells[j].Value = "    ";
                    }
                }
            }
        }
        private void Run()
        {
            Task.WaitAll(tasks);
            toolStripStatusLabel1.Text = "ОК";
            ThreadBar.Text = "";
            string st = "";
            foreach (var p in droneDict.Values)
            {
                st += $"{p.Name} исследовал {p.findCount[0]} редких и {p.findCount[1]} очень редких источников.\n";
            }
            MessageBox.Show(st, "Результат исследования", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            pointchange.Text = $"Выбрана точка ({e.RowIndex},{e.ColumnIndex});\t {mapData[e.RowIndex, e.ColumnIndex]}";
        }
        void Investigate(Drone drone, Point end1, Point end2)
        {
            Color[] colors = new Color[10] {Color.LightPink,
                                            Color.PaleGreen,
                                            Color.SkyBlue,
                                            Color.LightYellow,
                                            Color.LightCoral,
                                            Color.MintCream,
                                            Color.PowderBlue,
                                            Color.PeachPuff,
                                            Color.LightCyan,
                                            Color.SeaShell };
            Point prevLocal = drone.Local;
            while (drone.InvestigateRedion(droneBaseLocal, end1, end2, mapData) && coverSize < n * n && isBreak)
            {
                lock (dataGridView1)
                {
                    mapData[drone.Local.X, drone.Local.Y] = 4;
                    dataGridView1.Rows[drone.Local.X].Cells[drone.Local.Y].Value = drone.ID;
                    dataGridView1.Rows[drone.Local.X].Cells[drone.Local.Y].Style.BackColor = colors[drone.ID];
                    dataGridView1.Rows[prevLocal.X].Cells[prevLocal.Y].Value = "";
                    prevLocal = drone.Local;
                    lock (ThreadBar)
                    {
                        ThreadBar.Text = $"OK {drone.Name} : {drone.visitedCount} покрыто {coverSize}";
                    }
                        coverSize += drone.visitedCount;
                    ProgressBar1.Value=coverSize;
                    if(!checkBox1.Checked)
                    {
                        dataGridView1.Refresh();
                        dataGridView1.Update();
                    }                    
                    Task.Delay(100);
                }
                while (!isRunning)
                {
                    Task.Delay(5000);
                }
            }
            ThreadBar.Text = $"OK {drone.Name} закончил исследование: Найдено {drone.findCount[0]}; ={drone.findCount[1]} ";
        }
        async void UpdatedGrid(DataGridView grid)
        {
            if (grid == null)return;

            dataGridView1.Refresh();
            dataGridView1.Update();
        }
        private void starter_Click(object sender, EventArgs e)
        {
            // Найдите отправные точки для каждого разведывательного маршрута
            if (mapData[droneBaseLocal.X, droneBaseLocal.Y] != 3)
                return;
            toolStripStatusLabel1.Text = "В процессе";
            tasks=new Task[(int)ThreadSpin.Value];
            coverSize = 0;
            var AP = Drone.FindAnchorPoints((int)(ThreadSpin.Value), mapData.GetLength(0), droneBaseLocal);

            foreach (var p in AP)
            {
               dataGridView1.Rows[p.X].Cells[p.Y].Style.BackColor = Color.LightPink;
            }

            isRunning = true;
            tasks = new Task[(int)(ThreadSpin.Value)];
            for (int i = 0; i < ThreadSpin.Value; i++)
            {
                var drone = new Drone(i, $"Дрон {i}", droneBaseLocal);
                droneDict[drone.ID] = drone;

                if (drone.ID != ThreadSpin.Value - 1)
                {
                    tasks[i] = new Task(() => Investigate(drone, AP[drone.ID], AP[drone.ID + 1]));
                }
                else
                {
                    tasks[i] = new Task(() => Investigate(drone, AP[drone.ID], AP[0]));
                }
            }
            foreach (var p in tasks)
                p.Start();
            CreaterThread.Visible = true;
            Task.Factory.StartNew(() => { Run(); });

        }

        private void CreaterThread_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                isRunning = false;
                CreaterThread.Text = "Продолжить?";
                toolStripStatusLabel1.Text = "Стоп";
                string st = "";                
                foreach (var p in droneDict.Values)
                {
                    st += $"{p.Name} исследовал {p.findCount[0]} редких и {p.findCount[1]} очень редких источников.\n";
                }
                MessageBox.Show(st, "Результат исследования", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                isRunning = true;
                CreaterThread.Text = "Стоп";
            }

        }


    }
}
