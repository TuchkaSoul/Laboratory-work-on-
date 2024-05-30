using MyMenu;
using UserLibraryProductionShop;
using UserUtility1;
namespace Laba13
{
    internal class Program
    {
        static NewHashtableCollection<Production> hahTable = new NewHashtableCollection<Production>("Первая коллекция", 25);
        static NewHashtableCollection<Production> hahTable2 = new NewHashtableCollection<Production>("Вторая коллекция ", 10);
        static Journal<Production> journalTable = new Journal<Production>();
        static Journal<Production> journalTable2 = new Journal<Production>();
        public static void Print()
        {
            int i, j;
            (i, j) = Console.GetCursorPosition();
            Thread thread = new Thread(() =>
            {
                Console.SetCursorPosition(i, j);
                hahTable.PrintKV();
            });
            thread.Start();
            Thread.Sleep(100);
        }
        public static void Print2()
        {
            int i, j;
            (i, j) = Console.GetCursorPosition();
            Thread thread1 = new Thread(() =>
            {
                Console.SetCursorPosition(i, j);
                Console.WriteLine(Thread.CurrentThread.Name);
                hahTable2.PrintKV();

            });
            thread1.Start();
            Thread.Sleep(100);
        }
        static void Main(string[] args)
        {

            hahTable.CollectionCountChanged += new CollectionHandler<Production>(journalTable.CollectionCountChanged);
            hahTable.CollectionReferenceChanged += new CollectionHandler<Production>(journalTable.CollectionReferenceChanged);

            hahTable.CollectionReferenceChanged += new CollectionHandler<Production>(journalTable2.CollectionReferenceChanged);
            hahTable2.CollectionReferenceChanged += new CollectionHandler<Production>(journalTable2.CollectionReferenceChanged);

            
            Console.Clear();


            MenuCategory main = new MenuCategory("Главное меню", new MenuItem[]
        {
        new MenuCategory($"1) {hahTable.Name}", new MenuItem[]
        {
            new MenuCategory("1) Добавление", new MenuItem[]
        {
            new MenuAction("1) Добавить 1 элемент class \"Production\"", InitAddColl<Production>),
            new MenuAction("2) Добавить 1 элемент class \"Factory\"", InitAddColl<Factory>),
            new MenuAction("3) Добавить 1 элемент class \"Workshop\"", InitAddColl<Workshop>),
            new MenuAction("4) Добавить 1 элемент class \"Shop\"", InitAddColl<Shop>),
            new MenuAction("5) Добавить n элементов" , InitAddCollRandomN),
            new MenuCategory("Добавление в ручную", new MenuItem[]
        {
            new MenuAction("1) Добавить 1 элемент class \"Production\"", InitManualAddColl<Production>),
            new MenuAction("2) Добавить 1 элемент class \"Factory\"", InitManualAddColl<Factory>),
            new MenuAction("3) Добавить 1 элемент class \"Workshop\"", InitManualAddColl<Workshop>),
            new MenuAction("4) Добавить 1 элемент class \"Shop\"", InitManualAddColl<Shop>),
            new MenuBack()
        }),
            new MenuBack()
        }),
            new MenuCategory("2) Удаление", new MenuItem[]
        {
            new MenuAction("Удалить по индексу",InitRemoveColl),
            new MenuCategory("Удаление в ручную", new MenuItem[]
        {
            new MenuAction("1) Удалить 1 элемент class \"Production\"", InitManualRemoveColl<Production>),
            new MenuAction("2) Удалить 1 элемент class \"Factory\"", InitManualRemoveColl<Factory>),
            new MenuAction("3) Удалить 1 элемент class \"Workshop\"", InitManualRemoveColl<Workshop>),
            new MenuAction("4) Удалить 1 элемент class \"Shop\"", InitManualRemoveColl<Shop>),
            new MenuBack()
        }),
            new MenuBack()
        }),
            new MenuCategory("3) Вывод на экран", new MenuItem[]
        {
            new MenuAction("1) Print", hahTable.Print),
            new MenuAction ("2) Foreach", Print),
            new MenuBack()
        }),
            new MenuCategory("4) Очистка", new MenuItem[]
        {
            new MenuAction ("Очистить", hahTable.Clear),
            new MenuAction ("Удалить", hahTable.Dispose),
            new MenuBack()
        }),
            new MenuAction("5) Количество элементов",SomeAction),
            new MenuCategory("6) Клонирование", new MenuItem[]
        {
            new MenuAction ("Глубокое копирование второй хеш таблицы", Clone1Into2),
            new MenuAction ("Поверхностное копирование второй хеш таблицы", SClone1Into2),
            new MenuBack()
        }),
            new MenuCategory("7) Найти", new MenuItem[]
        {
            new MenuCategory("Поиск в ручную", new MenuItem[]
        {
            new MenuAction("1) Найти 1 элемент class \"Production\"", InitConteinsColl<Production>),
            new MenuAction("2) Найти 1 элемент class \"Factory\"", InitConteinsColl<Factory>),
            new MenuAction("3) Найти 1 элемент class \"Workshop\"", InitConteinsColl<Workshop>),
            new MenuAction("4) Найти 1 элемент class \"Shop\"", InitConteinsColl<Shop>),
            new MenuBack()
        }),
        new MenuBack()

        }),
            new MenuCategory("8) Индекс", new MenuItem[]
        {
            new MenuAction("1) Обращение по индексу", GetValueIndex),
            new MenuAction("2) Изменение(удаление) по индексу", SetValueIndex),
            new MenuBack()
        }),
            new MenuBack()
        }),
        new MenuCategory($"2) {hahTable2.Name}", new MenuItem[]
        {
            new MenuCategory("1) Добавление", new MenuItem[]
        {
            new MenuAction("1) Добавить 1 элемент class \"Production\"", InitAddColl2<Production>),
            new MenuAction("2) Добавить 1 элемент class \"Factory\"", InitAddColl2<Factory>),
            new MenuAction("3) Добавить 1 элемент class \"Workshop\"", InitAddColl2<Workshop>),
            new MenuAction("4) Добавить 1 элемент class \"Shop\"", InitAddColl2<Shop>),
            new MenuAction("5) Добавить n элементов" , InitAddColl2RandomN),
            new MenuCategory("Добавление в ручную", new MenuItem[]
        {
            new MenuAction("1) Добавить 1 элемент class \"Production\"", InitManualAddColl2<Production>),
            new MenuAction("2) Добавить 1 элемент class \"Factory\"", InitManualAddColl2<Factory>),
            new MenuAction("3) Добавить 1 элемент class \"Workshop\"", InitManualAddColl2<Workshop>),
            new MenuAction("4) Добавить 1 элемент class \"Shop\"", InitManualAddColl2<Shop>),
            new MenuBack()
        }),
            new MenuBack()
        }),
            new MenuCategory("2) Удаление", new MenuItem[]
        {
            new MenuAction("Удалить по индексу",InitRemoveColl),
            new MenuCategory("Удаление в ручную", new MenuItem[]
        {
            new MenuAction("1) Удалить 1 элемент class \"Production\"", InitManualRemoveColl2<Production>),
            new MenuAction("2) Удалить 1 элемент class \"Factory\"", InitManualRemoveColl2<Factory>),
            new MenuAction("3) Удалить 1 элемент class \"Workshop\"", InitManualRemoveColl2<Workshop>),
            new MenuAction("4) Удалить 1 элемент class \"Shop\"", InitManualRemoveColl2<Shop>),
            new MenuBack()
        }),
            new MenuBack()
        }),
        new MenuCategory("3) Вывод на экран", new MenuItem[]
        {
            new MenuAction("1) Print", hahTable2.Print),
            new MenuAction ("2) Foreach", Print2),
            new MenuBack()
        }),
        new MenuCategory("4) Очистка", new MenuItem[]
        {
            new MenuAction ("Очистить", hahTable2.Clear),
            new MenuAction ("Удалить", hahTable2.Dispose),
            new MenuBack()
        }),

        new MenuAction("5) Количество элементов",SomeAction2),
        new MenuCategory("6) Клонирование", new MenuItem[]
        {
            new MenuAction ("Глубокое копирование первой хеш таблицы", Clone2Into1),
            new MenuAction ("Поверхностное копирование первой хеш таблицы", SClone2Into1),
            new MenuBack()
        }),
        new MenuCategory("7) Найти", new MenuItem[]
        {
            new MenuCategory("Поиск в ручную", new MenuItem[]
        {
            new MenuAction("1) Найти 1 элемент class \"Production\"", InitConteinsColl2<Production>),
            new MenuAction("2) Найти 1 элемент class \"Factory\"", InitConteinsColl2<Factory>),
            new MenuAction("3) Найти 1 элемент class \"Workshop\"", InitConteinsColl2<Workshop>),
            new MenuAction("4) Найти 1 элемент class \"Shop\"", InitConteinsColl2<Shop>),
            new MenuBack()
        }),
        new MenuBack()

        }),
        new MenuCategory("8) Индекс", new MenuItem[]
        {
            new MenuAction("1) Обращение по индексу", GetValueIndex2),
            new MenuAction("2) Изменение(удаление) по индексу", SetValueIndex2),
            new MenuBack()
        }),
        new MenuBack()
        }),
        new MenuAction("3) Вывод 1 журнала", journalTable.Print),
        new MenuAction("4) Вывод 2 журнала", journalTable2.Print),
        new MenuBack("Выход")
        });
            UserMenu menu = new UserMenu(main);
            menu.Run();
        }
        public static void GetValueIndex()
        {
            int index = InputData.EnterElement("Введите индекс искомого элемента: ", -1, hahTable.Length); ;
            try
            {
                Console.WriteLine(hahTable[index]);
            }
            catch 
            {
                Console.WriteLine($"Недопустимый индекс\nПопробуйте ещё раз.[Индекс не должен превышать: {hahTable.Length-1}]");;
            }
            
        }
        public static void SetValueIndex()
        {
            int index = InputData.EnterElement("Введите индекс искомого элемента: ",-1, hahTable.Length);
            try
            {
                hahTable[index] = null!;
                Console.WriteLine("Успешно изменнено");
            }
            catch
            {
                Console.WriteLine($"Недопустимый индекс\nПопробуйте ещё раз.[Индекс не должен превышать: {hahTable.Length - 1}]"); ;
            }
            Console.WriteLine("Успешно изменнено");
        }
        public static void SetValueIndex2()
        {
            int index = InputData.EnterElement("Введите индекс искомого элемента: ", -1, hahTable.Length);
            try
            {
                hahTable2[index] = null!;
            }
            catch
            {
                Console.WriteLine($"Недопустимый индекс\nПопробуйте ещё раз.[Индекс не должен превышать: {hahTable2.Length - 1}]"); ;
            }

        }
        public static void GetValueIndex2()
        {
            int index = InputData.EnterElement("Введите индекс искомого элемента: ", -1, hahTable.Length);
            try
            {
                Console.WriteLine(hahTable2[index]);
            }
            catch
            {
                Console.WriteLine($"Недопустимый индекс\nПопробуйте ещё раз.[Индекс не должен превышать: {hahTable2.Length - 1}]"); ;
            }

        }
        private static void SomeAction()
        {
            Console.WriteLine($"Количество элементов в 1 таблице: {hahTable.Count}");
        }
        private static void SomeAction2()
        {
            Console.WriteLine($"Количество элементов в 2 таблице: {hahTable2.Count}");
        }
        public static void Clone1Into2()
        {
            hahTable = (NewHashtableCollection<Production>)hahTable2.Clone();
        }
        public static void SClone1Into2()
        {
            hahTable = (NewHashtableCollection<Production>)hahTable2.ShallowCopy();
        }
        public static void Clone2Into1()
        {
            hahTable2 = (NewHashtableCollection<Production>)hahTable.Clone();
        }
        public static void SClone2Into1()
        {
            hahTable2 = (NewHashtableCollection<Production>)hahTable.ShallowCopy();
        }
        public static void InitAddColl<T>() where T : Production, new()
        {
            T production = new T();
            production.InitRandom();
            hahTable.Add(production);
            if (hahTable.Contains(production))
                Console.WriteLine("[Успешно добавлена новая запись]");
            else Console.WriteLine("[Не добавлено]");

        }
        public static void InitConteinsColl<T>() where T : Production, new()
        {
            T production = new T();
            production.Init();
            if (hahTable.Contains(production))
                Console.WriteLine("[Успешно Найдена запись]");
            else
                Console.WriteLine("[Запись Ненайдена]");
        }
        public static void InitConteinsColl2<T>() where T : Production, new()
        {
            T production = new T();
            production.InitRandom();
            if (hahTable2.Contains(production))
                Console.WriteLine("[Успешно Найдена запись]");
            else
                Console.WriteLine("[Запись Ненайдена]");
        }
        public static void InitAddColl2<T>() where T : Production, new()
        {
            T production = new T();
            production.InitRandom();
            if (hahTable2.Add(production, production))
                Console.WriteLine("[Успешно добавлена новая запись]");
            else Console.WriteLine("[Не добавлено]");

        }
        public static void InitManualAddColl<T>() where T : Production, new()
        {
            T production = new T();
            production.Init();
            hahTable.Add(production, production);
            if (hahTable.Contains(production))
                Console.WriteLine("[Успешно добавлена новая запись]");
            else Console.WriteLine("[Не добавлено]");

        }
        public static void InitManualAddColl2<T>() where T : Production, new()
        {
            T production = new T();
            production.Init();
            hahTable2.Add(production);
            if (hahTable2.Contains(production))
                Console.WriteLine("[Успешно добавлена новая запись]");
            else Console.WriteLine("[Не добавлено]");
        }
        public static void InitManualRemoveColl<T>() where T : Production, new()
        {
            T production = new T();
            production.Init();
            if (hahTable.Remove(production))
                Console.WriteLine("[Успешно удалена запись]");
            else Console.WriteLine("[Не удалено]");
        }
        public static void InitRemoveColl()
        {
            if (hahTable.Remove(InputData.EnterElement(message: "Введите номер элемента для удалений: ", leftBorder: -1) + 1))
                Console.WriteLine("[Успешно удалена запись]");
            else Console.WriteLine("[Не удалено]");
        }
        public static void InitRemoveColl2()
        {
            if (hahTable2.Remove(InputData.EnterElement(message: "Введите номер элемента для удалений: ", leftBorder: -1) + 1))
                Console.WriteLine("[Успешно удалена запись]");
            else Console.WriteLine("[Не удалено]");
        }
        public static void InitManualRemoveColl2<T>() where T : Production, new()
        {
            T production = new T();
            production.Init();
            if (hahTable2.Remove(production))
                Console.WriteLine("[Успешно удалена запись]");
            else Console.WriteLine("[Не удалено]");
        }
        public static void InitAddCollRandomN()
        {
            int n = InputData.EnterElement(message: "Введите количество элементов для рандомного добавления: ", leftBorder: -1);
            int k = hahTable.Count;
            Production production = new Production();
            Factory factory = new Factory();
            Workshop workshop = new Workshop();
            Shop shop = new Shop();
            Random rand = new Random();
            int e = 0;
            while (n > 0 && e++ < 10000)
            {
                switch (rand.Next(0, 3))
                {
                    case 0:
                        InitAddColl<Production>();
                        break;
                    case 1:
                        InitAddColl<Factory>();
                        break;
                    case 2:
                        InitAddColl<Workshop>();
                        break;
                    case 3:
                        InitAddColl<Shop>();
                        break;
                }
                n--;
            }

            Console.WriteLine($"[Успешно добавлено {hahTable.Count - k}]");

        }
        public static void InitAddColl2RandomN()
        {
            int n = InputData.EnterElement(message: "Введите количество элементов для рандомного добавления: ", leftBorder: -1);
            int k = hahTable2.Count;
            Production production = new Production();
            Factory factory = new Factory();
            Workshop workshop = new Workshop();
            Shop shop = new Shop();
            Random rand = new Random();
            int e = 0;
            while (n > 0 && e++ < 10000)
            {
                switch (rand.Next(0, 3))
                {
                    case 0:
                        InitAddColl2<Production>();
                        break;
                    case 1:
                        InitAddColl2<Factory>();
                        break;
                    case 2:
                        InitAddColl2<Workshop>();
                        break;
                    case 3:
                        InitAddColl2<Shop>();
                        break;
                }
                n--;
            }
            Console.WriteLine($"[Успешно добавлено {hahTable2.Count - k}]");

        }

    }

}
