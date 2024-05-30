namespace AerialReconnaissance
{
    public class Drone
    {
        int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                if (value < -1)
                    throw new Exception("ID меньше 0 быть не может...");
                id = value;
            }
        }
        public string Name { get; set; }
        public Point Local { get; set; }



        public int[] findCount { get; set; }
        public int visitedCount= 0;

        public Stack<Point> stack = new Stack<Point>();

        public Drone()
        {
            ID = 0;
            Name = $"Drone{ID}";
            Local = new Point();
            findCount = new int[2];
            
        }
        public Drone(int Id, string name, Point point)
        {
            ID = Id;
            Name = name;
            Local = point;
            findCount = new int[2];
        }
        public bool InvestigateRedion(Point start, Point end1, Point end2, int[,] matrix)
        {
            int x = Local.X;
            int y = Local.Y;
            int dx = 0;
            int dy = 0;

            // Определите возможные направления
            int[] dxs = { 1, 1, 0, -1, -1, -1, 0, 1 };
            int[] dys = { 0, 1, 1, 1, 0, -1, -1, -1 };

            // Итерация по соседним ячейкам

            // Определит стек для хранения узлов, посещенных на данный момент
            for (int i = 0; i < 8; i++)
            {
                int newX = x + dxs[i];
                int newY = y + dys[i];

                if (CheckRegion(start, end1, end2, newX, newY) && (matrix[newX, newY] != 4))
                {
                    dx = dxs[i];
                    dy = dys[i];
                    break;
                }                
            }
            // Проверьте, не зашли ли мы в тупик
            if (dx == 0 && dy == 0)
            {
                // Обратный путь к предыдущему узлу
                if (stack.Count > 0)
                {
                    Point prevNode = stack.Pop();
                    Local = prevNode;
                    x = prevNode.X;
                    y = prevNode.Y;
                    Local = new Point(x, y);
                    visitedCount = 0;
                    return true;
                }
                else
                {
                    // Больше нет узлов для обратного пути, выйдите из функции
                    return false;
                }
            }
            // Переход к следующей ячейке
            Local = new Point(Local.X + dx, Local.Y + dy);
            visitedCount=1;
            if (matrix[Local.X, Local.Y] == 1)
                findCount[0]++;
            if (matrix[Local.X, Local.Y] == 2)
                findCount[1]++;

            // Добавьте текущий узел в стек
            stack.Push(new Point(Local.X, Local.Y));
            
            return true;

        }

        public void InvestigateRedion1(Point start, Point end1, Point end2, int[,] matrix)
        {
            int x = Local.X;
            int y = Local.Y;
            int dx = 0;
            int dy = 0;
            if (matrix[x + 1, y] != 4 && CheckRegion(start, end1, end2, x + 1, y))
            {
                dx = 1;
                dy = 0;
            }
            else if (matrix[x + 1, y + 1] != 4 && CheckRegion(start, end1, end2, x + 1, y + 1))
            {
                dx = 1;
                dy = 1;
            }
            else if (matrix[x, y + 1] != 4 && CheckRegion(start, end1, end2, x, y + 1))
            {
                dx = 0;
                dy = 1;
            }
            else if (matrix[x - 1, y + 1] != 4 && CheckRegion(start, end1, end2, x - 1, y + 1))
            {
                dx = -1;
                dy = +1;
            }
            else if (matrix[x - 1, y] != 4 && CheckRegion(start, end1, end2, x - 1, y))
            {
                dx = -1;
                dy = 0;
            }
            else if (matrix[x - 1, y - 1] != 4 && CheckRegion(start, end1, end2, x - 1, y - 1))
            {
                dx = -1;
                dy = -1;
            }
            else if (matrix[x, y - 1] != 4 && CheckRegion(start, end1, end2, x, y - 1))
            {
                dx = 0;
                dy = -1;
            }
            else if (matrix[x + 1, y - 1] != 4 && CheckRegion(start, end1, end2, x + 1, y - 1))
            {
                dx = +1;
                dy = -1;
            }

            // Переход к следующей ячейке
            Local = new Point(Local.X + dx, Local.Y + dy);
        }
        public static bool CheckRegion(Point start, Point end1, Point end2, int x, int y)
        {
            bool Line(Point start, Point end1, int x, int y, bool isFirst = true)
            {
                bool line = false;
                if ((end1.X != start.X) && (end1.Y != start.Y))
                {
                    double x1 = (double)(-x + start.X) / (-end1.X + start.X);
                    double y1 = (double)(y - start.Y) / (end1.Y - start.Y);
                    if (end1.Y - start.Y < 0)
                        if (end1.X - start.X < 0)
                            line = x1 >= y1;
                        else line = x1 <= y1;
                    else
                    {
                        if (end1.X - start.X < 0)
                            line = x1 <= y1;
                        else line = x1 >= y1;
                    }
                    if (isFirst)
                    {
                        return line;
                    }
                    else
                    {
                        return !line;
                    }
                }
                else if ((end1.X == start.X) && (end1.Y != start.Y))
                {
                    if (isFirst)
                        return x <= start.X;
                    else
                        return x >= start.X;
                }
                else if ((end1.X != start.X) && (end1.Y == start.Y))
                {
                    if (isFirst)
                        return y >= start.Y;
                    else
                        return y <= start.Y;
                }
                else
                    return true;
            }
            if (end1 == end2)
                return true;
            bool isInRegion = false;
            var minX = new List<int>() { start.X, end1.X, end2.X }.Min();
            var maxX = new List<int>() { start.X, end1.X, end2.X }.Max();
            var minY = new List<int>() { start.Y, end1.Y, end2.Y }.Min();
            var maxY = new List<int>() { start.Y, end1.Y, end2.Y }.Max();
            isInRegion = x >= minX
                && x <= maxX
                && y >= minY
                && y <= maxY;
            if (!isInRegion)
                return isInRegion;
            return Line(start, end1, x, y) && Line(start, end2, x, y, false);
        }

        public static List<Point> FindAnchorPoints(int VertexCount, int N, Point baseDrone, Point start = new Point())
        {
            List<Point> result = new List<Point>() { start };
            Point cur = start;
            double squareRigion = N * N / VertexCount;

            List<Point> points = new List<Point>();
            for (int i = 0; i < N; i++)
            {
                points.Add(new Point(0, i));
            }
            for (int i = 1; i < N - 1; i++)
            {
                points.Add(new Point(i, N - 1));
            }
            for (int i = N - 1; i >= 0; i--)
            {
                points.Add(new Point(N - 1, i));
            }
            for (int i = N - 2; i > 0; i--)
            {
                points.Add(new Point(i, 0));
            }


            for (int k = 1; k < VertexCount; k++)
            {
                points = points.GetRange(points.IndexOf(cur), points.Count - points.IndexOf(cur));
                foreach (Point item in points)
                {
                    double sq = GetSquare(baseDrone, cur, item, points, N);
                    if (squareRigion - squareRigion * 0.1 <= sq && squareRigion + squareRigion * 0.2 >= sq)
                    {
                        cur = item;
                        result.Add(cur);
                        break;
                    }
                }
            }
            return result;
            double GetSquare(Point baseDrone, Point start, Point end, List<Point> points, int N)
            {
                List<Point> angles = new List<Point>() { new Point(0, 0), new Point(0, N - 1), new Point(N - 1, 0), new Point(N - 1, N - 1) };
                angles.Remove(start);
                var a = points.GetRange(points.IndexOf(start), points.IndexOf(end) - points.IndexOf(start));
                int countAng = 0;
                foreach (Point item in angles)
                {
                    if (a.Contains(item))
                    {
                        countAng++;
                    }
                }
                switch (countAng)
                {
                    case 0:
                        return GetSquareTricl(baseDrone, start, end);
                    case 1:
                        return GetSquareTricl(angles.Intersect(a).First(), start, end) + GetSquareTricl(baseDrone, start, end);
                    case 2:
                        return GetSquareTricl(angles.Intersect(a).Last(), start, end) + GetSquareTricl(angles.Intersect(a).First(), start, end) + GetSquareTricl(baseDrone, start, end);

                }
                return 0;
                double GetSquareTricl(Point baseDrone, Point start, Point end)
                {
                    double l1 = Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2));
                    double l2 = Math.Sqrt(Math.Pow(start.X - baseDrone.X, 2) + Math.Pow(start.Y - baseDrone.Y, 2));
                    double l3 = Math.Sqrt(Math.Pow(baseDrone.X - end.X, 2) + Math.Pow(baseDrone.Y - end.Y, 2));
                    double p = (l1 + l2 + l3) / 2;
                    return Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3));
                }

            }

        }
    }
    public class Box
    {
        int x;
        int y;
        bool isVisited = false;
        int value = 0;
        Color color = Color.White;
        public Box(int x, int y, int value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
        }


    }
}
