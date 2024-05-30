using HashTableCollection;
using MyMenu;
using UserLibraryProductionShop;
using UserUtility1;

namespace Laba14
{
    internal class Program
    {
        static SortedDictionary<Production, List<Shop>> dictListHashtab = new SortedDictionary<Production, List<Shop>>();
        static HahTable<Shop> hahTable = new HahTable<Shop>(100);
        static void FillingColl(int countDict = 0, int countList = 0) //наполнение коллекции
        {
            if (!(dictListHashtab.Count == 0))
                dictListHashtab.Clear();
            if (countDict == countList && countDict == 0)
            {
                countDict = InputData.EnterElement(message: "Введите количество количество корпораций (элементов SortedDict): ", leftBorder: -1);
                if (countDict <= 0) { return; }
                countList = InputData.EnterElement(message: "Введите количество количество отделов (элементов List): ", leftBorder: -1);
                if (countList <= 0) { return; }
            }
            for (int i = 0; i < countDict; i++)
            {
                Production exp = new Production();
                exp.InitRandom();
                int err = 1000;
                while (dictListHashtab.ContainsKey(exp) && err-- > 0)
                {
                    exp.InitRandom();
                }
                if (!dictListHashtab.ContainsKey(exp))
                {
                    err = 1000;
                }
                else
                {
                    Console.Write("Варианты разных производств закончились..\nНовое количество записей в SortedDict: ");
                    Console.WriteLine(dictListHashtab.Count);
                    return;
                }
                List<Shop> list = new List<Shop>();
                for (int j = 0; j < countList; j++)
                {
                    Shop shop = new Shop();
                    shop.InitRandom();
                    shop.NameProduction = exp.NameProduction;
                    shop.BranchProduction = exp.BranchProduction;
                    list.Add(shop);
                }
                dictListHashtab.Add(exp, list);
            }


        }
        static void Print()//вывод коллекции
        {
            if (dictListHashtab.Count == 0) { Console.WriteLine("Колекция пуста"); }
            foreach (KeyValuePair<Production, List<Shop>> pair in dictListHashtab)
            {
                Console.WriteLine($"\t[ {pair.Key} ]\n");
                foreach (Shop shop in pair.Value)
                {
                    Console.WriteLine(shop.ToString());
                }
                Console.WriteLine("\n");
            }
        }

        #region Запросы
        static void Exp1()
        {
            var item2 = hahTable.Where(p => p.NumberShopWorkers >= 75);
            foreach (Shop shop in item2)
            {
                Console.WriteLine(shop);
            }
            Console.WriteLine();
        }
        static void Exp2()
        {
            Console.WriteLine("[Сортировка по возрастанию по свойству \" NumberShopWorkers \"]");
            var item2 = hahTable.OrderBy(p => p.NumberShopWorkers);
            foreach (Shop shop in item2)
            {
                Console.WriteLine(shop);
            }
            Console.WriteLine("--------------");
            Console.WriteLine("[Сортировка по возрастанию по свойству \" AnnualOutput \"]");
            item2 = hahTable.OrderBy(p => p.AnnualOutput);
            foreach (Shop shop in item2)
            {
                Console.WriteLine(shop);
            }
        }
        static void Exp3()
        {
            Console.WriteLine("Cуммарное производство");
            Console.WriteLine(hahTable.Sum(x => x.AnnualOutput));
            Console.WriteLine("--------------");
            Console.WriteLine("Cуммарное количество работников");
            Console.WriteLine(hahTable.Sum(x => x.NumberShopWorkers));
        }
        static void QueryA()
        {
            Console.WriteLine("[ Вывести лучших работников фабрик ]");

            var nameLinq = (from dict in dictListHashtab
                            from shop in dict.Value
                            orderby shop.AnnualOutput descending
                            select shop.ManagerWorkshop).Distinct();

            Console.WriteLine("  Ответ от LINQ: " + nameLinq.Count());

            foreach (string model in nameLinq)
                Console.WriteLine(model);   

            var uniqueNameMethods = dictListHashtab.SelectMany(dict => dict.Value)
                                   .OrderByDescending(shop => shop.AnnualOutput)
                                   .Select(shop => shop.ManagerWorkshop)
                                   .Distinct();
            

            Console.WriteLine("  С помощью методов: " + uniqueNameMethods.Count());

            foreach (string name in uniqueNameMethods)
                Console.WriteLine(name);
        }
        static void QueryB()
        {
            Console.WriteLine("[ Вывод количества цехов с штатом сотрудников не ниже 15 ] ");

            int countLinq = (from sortDict in dictListHashtab
                             from shop in sortDict.Value
                             where shop.NumberShopWorkers >= 15
                             select shop).Count();

            Console.WriteLine("  Ответ от LINQ: " + countLinq.ToString());

            int countMethod = dictListHashtab.SelectMany(d => d.Value.Where(p => p.NumberShopWorkers >= 15)).Count();

            Console.WriteLine("  Ответ от методов расширения: " + countMethod.ToString());
        }
        static void QueryС()
        {
            Console.WriteLine("Самая прибыльная Фабрика");

            var maxPriceLinq = (from dict in dictListHashtab
                                from shop in dict.Value
                                orderby shop.AnnualOutput descending
                                select shop).FirstOrDefault();

            Console.WriteLine("С помощью LINQ: \n" + maxPriceLinq?.NameFactory + " - " + maxPriceLinq?.AnnualOutput);

            var minPriceMethod = dictListHashtab.SelectMany(d => d.Value)
                                      .OrderByDescending(t => t.AnnualOutput)
                                      .FirstOrDefault();

            Console.WriteLine("С помощью методов расширения: \n" + minPriceMethod?.NameFactory + " - " + minPriceMethod?.AnnualOutput);
        }
        static void QueryD()
        {
            Console.WriteLine("[ Вывод количества цехов с штатом сотрудников не входящих в (15;75) ]");

            var bigSmallShop = (from sortDict in dictListHashtab
                                from shop in sortDict.Value
                                where shop.NumberShopWorkers <= 15
                                select shop)
                                .Union(from sortDict in dictListHashtab
                                       from shop in sortDict.Value
                                       where shop.NumberShopWorkers >= 75
                                       select shop);

            Console.WriteLine("С помощью LINQ: " + bigSmallShop.Count());
            foreach (var dict in bigSmallShop)
                Console.WriteLine(dict.ToString());

            var minPriceMethod = dictListHashtab.SelectMany
                (d => d.Value.Where(p => p.NumberShopWorkers <= 15))
                .Union(dictListHashtab.SelectMany
                (d => d.Value.Where(p => p.NumberShopWorkers >= 75)));

            Console.WriteLine("С помощью методов расширения: " + minPriceMethod.Count());
            foreach (var dict in minPriceMethod)
                Console.WriteLine(dict.ToString());
        }
        static void QueryE()
        {
            Console.WriteLine("Группировка по названию фабрики");

            var groupByLinq = (from dict in dictListHashtab
                               from shop in dict.Value
                               group shop by shop.NameFactory);

            Console.WriteLine("\nМетоды LINQ: \n");
            foreach (var item in groupByLinq)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ {item.Key}]: {item.Count()}");
                Console.ResetColor();
                foreach (var dict in item)
                    Console.WriteLine(dict);
                Console.WriteLine();
            }
            var groupByMethod = dictListHashtab.SelectMany(d => d.Value)
                                    .GroupBy(t => t.NameFactory);

            Console.WriteLine("\nМетоды расширения: \n");
            foreach (var item in groupByMethod)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[ {item.Key}]: {item.Count()}");
                Console.ResetColor();
                foreach (var dict in item)
                    Console.WriteLine(dict);
                Console.WriteLine();

            }
        }

        #endregion



        public static void PrintHah()
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

        static void Main(string[] args)
        {

            FillingColl(5, 5);
            Console.Clear();

            MenuCategory main = new MenuCategory("Главное меню", new MenuItem[]
        {
        new MenuCategory("1) Hash-table1", new MenuItem[]
        {
            new MenuCategory("1) Управление Hashtable", new MenuItem[]
        {
            new MenuCategory("1) Добавление", new MenuItem[]
        {

            new MenuAction("1) Добавить 1 элемент class \"Shop\"", InitAddColl<Shop>),
            new MenuAction("2) Добавить n элементов" , InitAddCollRandomN),
            new MenuBack()
        }),
            new MenuCategory("2) Удаление", new MenuItem[]
        {
            new MenuAction("1) Удалить 1 элемент class \"Shop\"", InitManualRemoveColl<Shop>),
            new MenuAction ("2) Очистить", hahTable.Clear),
            new MenuBack()
        }),
            new MenuAction ("3) Вывод Foreach", PrintHah),
            new MenuAction("4) Количество элементов",SomeAction),
            new MenuBack()
        }),
            new MenuCategory("2) Запросы", new MenuItem[]
        {
            new MenuAction("1) Вывод количества цехов",Exp1),
            new MenuAction("2) Сортировка",Exp2),
            new MenuAction("3) Сумма",Exp3),
            new MenuBack()
        }),
            new MenuBack()
        }),
        new MenuCategory("2) SortedDictionary<,List<>>", new MenuItem[]
        {
            new MenuCategory("1) Запросы", new MenuItem[]
        {
            new MenuAction("1) Вывести лучших работников фабрик",QueryA),
            new MenuAction("2) Вывод количества цехов с штатом(count)",QueryB),
            new MenuAction("3) Самая прибыльная Фабрика",QueryС),
            new MenuAction("4) Вывод количества цехов(union)",QueryD),
            new MenuAction("5) \"Группировка по названию фабрики\"",QueryE),
            new MenuBack()
        }),
            new MenuCategory("2) Заполнение", new MenuItem[]
        {
            new MenuAction("1) Указать размеры",Fill1 ),
            new MenuAction("2) Заполнить по умолчанию" ,Fill2 ),
            new MenuBack()
        }),
            new MenuAction("3) Вывод в консоль",Print),
        new MenuBack()
        }),
        new MenuBack("Выход")
        });
            UserMenu menu = new UserMenu(main);
            menu.Run();
        }


        private static void SomeAction()
        {
            Console.WriteLine($"Количество элементов в 1 таблице: {hahTable.Count()}");
        }
        private static void Fill1()
        {
            FillingColl();
        }
        private static void Fill2()
        {
            FillingColl(5, 7);
        }
        public static void InitAddColl<T>() where T : Production, new()
        {
            Shop production = new Shop();
            production.InitRandom();
            hahTable.Add(production);
            if (hahTable.Contains(production))
                Console.WriteLine("[Успешно добавлена новая запись]");
            else Console.WriteLine("[Не добавлено]");

        }
        public static void InitConteinsColl<T>() where T : Production, new()
        {
            Shop production = new Shop();
            production.InitRandom();
            if (hahTable.Contains(production))
                Console.WriteLine("[Успешно Найдена запись]");
            else
                Console.WriteLine("[Запись Ненайдена]");
        }

        public static void InitManualAddColl<T>() where T : Production, new()
        {
            Shop production = new Shop();
            production.InitRandom();
            hahTable.Add(production, production);
            if (hahTable.Contains(production))
                Console.WriteLine("[Успешно добавлена новая запись]");
            else Console.WriteLine("[Не добавлено]");

        }

        public static void InitManualRemoveColl<T>() where T : Production, new()
        {
            Shop production = new Shop();
            production.InitRandom();
            if (hahTable.Remove(production))
                Console.WriteLine("[Успешно удалена запись]");
            else Console.WriteLine("[Не удалено]");
        }
        public static void InitAddCollRandomN()
        {
            int n = InputData.EnterElement(message: "Введите количество элементов для рандомного добавления: ", leftBorder: -1);
            int k = hahTable.Count;
            Random rand = new Random();
            int e = 0;
            while (n > 0 && e++ < 10000)
            {
                InitAddColl<Shop>();
                n--;
            }

            Console.WriteLine($"[Успешно добавлено {hahTable.Count - k}]");

        }


    }

}
