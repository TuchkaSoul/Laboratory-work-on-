using HashTableCollection;
using UserLibraryProductionShop;

namespace WinFormsApp1
{
    public static class Extension
    {
        public static IEnumerable<Tvalue> Where<Tvalue>(this HahTable<Tvalue> hah, Func<Tvalue, bool> func)
        {
            foreach (var item in hah)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }
        public static Type GetTypes(this object item)
        {
            if (item == null)
                return null;
            return item.GetType();
        }
        public static IEnumerable<T> FilterByTypeHierarchy<T>(this IEnumerable<T> source, Type targetType)
        {
            return source.Where(x => targetType.IsAssignableFrom(x.GetTypes()));
        }

        public static IEnumerable<T> FilterByExactType<T>(this IEnumerable<T> source, Type targetType)
        {
            return source.Where(x => x.GetType() == targetType);
        }

        public static IEnumerable<T> OrderBy<T, TKey>(this HahTable<T> hashtable, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
        where T : IComparable<T>
        {
            if (hashtable == null) throw new ArgumentNullException(nameof(hashtable));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            List<T> collection = new List<T>();
            foreach (var item in hashtable)
            {
                collection.Add(item);
            }
            collection.Sort((x, y) => keySelector(x).CompareTo(keySelector(y)));
            foreach (var item in collection)
            {
                yield return item;
            }
        }
        public static IEnumerable<T> OrderByDescending<T, TKey>(this HahTable<T> hashtable, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
        where T : IComparable<T>
        {
            return hashtable.OrderBy(keySelector).Reverse();
        }
        public static List<Production> ToList(this HahTable<Production> hah) => (from i in hah select i).ToList();

        
        public static Production ParseClass(this string str)
        {
            string[] parts = str.Split("; ");
            switch(parts.Length)
            {
                case 3:
                    return new Production(parts[0], parts[1]);
                case 5: 
                    return new Factory(parts[0], parts[1], parts[2], double.Parse(parts[3]));
                case 6:
                    return new Workshop(parts[0], parts[1], parts[2], double.Parse(parts[3]), parts[4]);
                case 7:
                    return new Shop(parts[0], parts[1], parts[2], double.Parse(parts[3]), parts[4], int.Parse(parts[5]));
            }
            return null ;
            
        }
        public static IEnumerable<T> FilterByType<T>(this IEnumerable<T> source, Type targetType)
        {
            return source.Where(x =>
            {
                var type = x.GetTypes();
                return type == targetType || type.IsSubclassOf(targetType);
            });
        }

        public static int MaxSize<T>(this HahTable<Production> hahtable)
        {
            int resalt = 0;
            foreach (var list in hahtable.table)
            {
                var cur = list;
                int size = 0;
                while (cur is not null)
                {
                    size++;
                    cur = cur.next;
                }
                resalt = Math.Max(resalt, size);
            }
            return resalt;
        }


        public static double Sum<T, TKey>(this HahTable<T> hah, Func<T, double> keySelector)
        {
            double sum = 0;
            if (hah == null) throw new ArgumentNullException(nameof(hah));
            List<T> collection = [.. hah];
            var iten = collection.Select(keySelector);
            foreach (var item in iten)
            {
                sum += item;
            }
            return sum;
        }
        public static int Count(this HahTable<Workshop> hah)
        {
            int sum = 0;
            if (hah == null) throw new ArgumentNullException(nameof(hah));
            foreach (var item in hah)
            {
                sum++;
            }
            return sum;
        }
        public static int Count<T>(this HahTable<T> hah, Func<T, bool> predicate)
        {
            int count = hah.Where(predicate).Count();
            return count;
        }

        public static void InitAddCollRandomN(this HahTable<Production> hahTable, int n = 15)
        {
            int k = hahTable.Count + n;
            Random rand = new Random();
            int e = 0;
            while (hahTable.Count != k && e++ < 10000)
            {
                switch (rand.Next(0, 4))
                {
                    case 0:
                        InitAddColl<Production>(hahTable);
                        break;
                    case 1:
                        InitAddColl<Factory>(hahTable);
                        break;
                    case 2:
                        InitAddColl<Workshop>(hahTable);
                        break;
                    case 3:
                        InitAddColl<Shop>(hahTable);
                        break;
                }
            }
        }
        public static bool Add(this HahTable<Production>hah, List<Production> list)
        {
            if (list == null || hah == null || hah.Length == 0)
            {
                return false;
            }
            foreach (var i in list)
            {
                if (!hah.Contains(i))
                    hah.Add(i);
            }
            return true;
        }

        public static bool InitAddColl<T>(this HahTable<Production> hahTable) where T : Production, new()
        {
            T production = new T();
            production.InitRandom();
            int i = 25;
            while (hahTable.Contains(production)&&i-->0)
                production.InitRandom();
            hahTable.Add(production);
            return hahTable.Contains(production);
                
        }

    }

}
