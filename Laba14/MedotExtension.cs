using HashTableCollection;
using System;
using System.Collections;
using UserLibraryProductionShop;

namespace Laba14
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


        public static double Sum<T, TKey>(this HahTable<T> hah, Func<T, double> keySelector) 
        {
            double sum = 0;
            if (hah == null) throw new ArgumentNullException(nameof(hah));
            List<T> collection = new List<T>();
            foreach (var item in hah)
            {
                collection.Add(item);
            }
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


    }
}
