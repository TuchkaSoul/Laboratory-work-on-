using System.Collections;

namespace HashTableCollection
{
    public class HahTable<T> : IDisposable, ICollection<T>, ICloneable, IEnumerable<T>, IEquatable<HahTable<T>?>
    {
        public ListProduction<T>[] table;
        protected int Size;
        private bool disposed = false;

        public HahTable(int size = 8)
        {
            Size = size;
            table = new ListProduction<T>[Size];
        }
        public HahTable(HahTable<T> hahTable)
        {
            Size = hahTable.Length;
            table = new ListProduction<T>[Size];
            disposed = hahTable.disposed;
            for (int i = 0; i < Size; i++)
            {
                if (hahTable.table[i] is null)
                {
                    table[i] = null!;
                    continue;
                }
                table[i] = (ListProduction<T>)hahTable.table[i].Clone();
            }
        }
        public virtual T this[int key0, int key1]//поиск/получение элемента по ключу или создание новой пары ключ\значение 
        {
            get
            {
                if (!(key0 >= Size))
                {
                    if (table[key0] is not null)
                    {
                        int i = 0;
                        var cur = table[key0];
                        while (i <= key1 || cur.next is not null)
                        {
                            if (i == key1 && cur.value is not null)
                            {
                                return cur.value;
                            }
                            i++;
                            if (cur.next is not null)
                                cur = cur.next;
                            else
                                throw new IndexOutOfRangeException();
                        }
                    }
                    throw new IndexOutOfRangeException();

                }
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                bool isCheck = false;
                try
                {
                    isCheck = this[key0, key1] is not null;




                }
                catch { }

                if (value == null && isCheck)
                {
                    Remove(this[key0, key1]);
                }


            }
        }
        public virtual bool Add(params T[] objs)//Добавляет элемент(-ы) если такой(-ие) еще не был(-и) добавлен(-ы).
        {
            if (objs == null || Size == 0)
                return false;
            int index;
            for (int i = 0; i < objs.Length; i++)
            {
                index = Math.Abs(objs[i].GetHashCode()) % Size;
                if (table[index] == null)
                {
                    table[index] = new ListProduction<T>(objs[i]);

                }
                else
                {
                    ListProduction<T> cur = table[index];
                    if (cur.value is null)
                    {
                        cur.value = objs[i];

                    }
                    if (cur.value.Equals(objs[i])) continue;
                    while (cur.next != null)
                    {
                        if (cur.value.Equals(objs[i])) break;
                        cur = cur.next;
                    }
                    cur.next = new ListProduction<T>(objs[i]);
                }
            }
            return true;
        }

        public virtual bool Remove(params T[] objs)//Удаляет элемент(-ы) если такой(-ие) еще не был(-и) добавлен(-ы).
        {
            if (objs == null || Size == 0)
                return false;
            bool isRes = true;
            int index;
            for (int i = 0; i < objs.Length; i++)
            {
                index = Math.Abs(objs[i].GetHashCode()) % Size;
                if (table[index] == null) continue;

                if (table[index].next == null)
                {
                    if (objs[i].Equals(table[index].value))
                    {
                        table[index] = null!;
                    }
                }
                else
                {
                    ListProduction<T> cur = table[index];
                    if (cur.value.Equals(objs[i]))
                    {

                        if (cur.next != null)
                        {
                            table[index] = (ListProduction<T>)cur.next.Clone();
                        }
                        continue;
                    }
                    while (cur != null)
                    {

                        if (cur.next != null)
                        {
                            if (cur.next.value.Equals(objs[i]))
                            {

                                if (cur.next.next != null)
                                {
                                    cur.next = (ListProduction<T>)cur.next.next.Clone();
                                    isRes = isRes && true;
                                }
                                else
                                {
                                    cur.next = null!;
                                    isRes = isRes && true;

                                }
                                break;
                            }
                        }
                        cur = cur.next!;
                    }
                }
                isRes = isRes && !Contains(objs[i]);
            }
            return isRes;
        }



        public void Print()//Выводит в консоль Хеш-таблицу
        {
            if (table == null || Count == 0 || disposed || Size == 0)
            {
                Console.WriteLine("[ Хэш-Таблица пуста ]");
                return;
            }
            for (int i = 0; i < Size; i++)
            {
                if (table[i] != null)
                {
                    Console.Write($"[{i}] : ");
                    ListProduction<T> p = table[i];
                    while (p != null)
                    {
                        if (p.value == null) break;
                        Console.Write(p.value!.ToString() + "  -->\t");
                        p = p.next;
                    }
                    Console.Write("null\n");
                }
                else
                {
                    Console.WriteLine($"[{i}] : ");
                }
            }
        }
        public void PrintKV()
        {
            if (table == null || Count == 0 || disposed || Size == 0)
            {
                Console.WriteLine("[ Хэш-Таблица пуста ]");
                return;
            }
            int i = 0;
            foreach (T item in this)
            {
                i++;
                Console.WriteLine("\n------------\n" + item.ToString() + "\n------------");
            }
            if (i == 0)
                Console.WriteLine("[ Хэш-Таблица пуста ]");
        }


        public virtual int Length
        {
            get { return Size; }
        }
        public virtual int Count
        {
            get
            {
                int count = 0;
                foreach (T item in this)
                {
                    count++;
                }
                return count;
            }
        }

        public bool IsSynchronized => table.IsSynchronized;
        public object SyncRoot => table.SyncRoot;

        public bool IsReadOnly => throw new NotImplementedException();

        public virtual void Clear()
        {
            if (this == null || Size == 0 || disposed)
                return;
            for (int i = 0; i < Length; i++)
            {
                if (table[i] is null) continue;
                table[i] = null!;
            }
            return;
        }

        public virtual void Dispose()
        {
            // освобождаем неуправляемые ресурсы
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Освобождаем управляемые ресурсы
                table = null!;
                Size = 0;
            }
            // освобождаем неуправляемые объекты
            disposed = true;
        }
        ~HahTable()
        {
            Dispose(false);
        }


        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }
        public object Clone()
        {
            return new HahTable<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }

        public override bool Equals(object? obj)
        {
            if (obj is HahTable<T>)
            {
                HahTable<T> other = (HahTable<T>)obj;
                return Equals(other);
            }
            return false;
        }
        public bool Equals(HahTable<T>? other)
        {
            return other is not null &&
               EqualsTable(other) &&
               Size == other.Size;
        }
        public bool EqualsTable(HahTable<T>? other)//создан для корректного сравнения данных двух колекций
        {
            if (Size == other.Size)
            {
                bool resalt = true;
                for (int i = 0; i < Length && resalt; i++)
                {

                    if (table[i] is null && other.table[i] is null)
                        continue;
                    else if (table[i] is null || other.table[i] is null)
                        return false;
                    resalt = resalt && table[i].Equals(other.table[i]);
                }
                return resalt;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(table, Size, Count);
        }

        public virtual void Add(T item)
        {
            if (item == null || Size == 0)
                return;
            int index;

            index = Math.Abs(item.GetHashCode()) % Size;
            if (table[index] == null)
            {
                table[index] = new ListProduction<T>(item);
            }
            else
            {
                ListProduction<T> cur = table[index];
                if (cur.value is null)
                {
                    cur.value = item;
                }
                if (cur.value.Equals(item))
                    return;
                while (cur.next != null)
                {
                    if (cur.value.Equals(item)) break;
                    cur = cur.next;
                }
                cur.next = new ListProduction<T>(item);
            }

            return;
        }


        public bool Contains(T item)
        {
            if (item == null || Size == 0)
                return false;
            int index = Math.Abs(item.GetHashCode()) % Size;
            ListProduction<T> cur = table[index];
            if (cur == null)
                return false;
            while (cur.next != null)
            {
                if (string.Compare(cur.value.ToString(), item.ToString()) == 0)
                    return true;
                cur = cur.next;
            }
            if (string.Compare(cur.value.ToString(), item.ToString()) == 0)
                return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public virtual bool Remove(T item)
        {
            if (item == null || Size == 0)
                return false;
            bool isRes = Contains(item);
            int index;

            index = Math.Abs(item.GetHashCode()) % Size;
            if (table[index] == null)
                return false;

            if (table[index].next == null)
            {
                if (item.Equals(table[index].value))
                {
                    table[index] = null!;
                }
            }
            else
            {
                ListProduction<T> cur = table[index];
                if (cur.value.Equals(item))
                {

                    if (cur.next != null)
                    {
                        table[index] = (ListProduction<T>)cur.next.Clone();
                    }
                    return true;
                }
                while (cur != null)
                {

                    if (cur.next != null)
                    {
                        if (cur.next.value.Equals(item))
                        {

                            if (cur.next.next != null)
                            {
                                cur.next = (ListProduction<T>)cur.next.next.Clone();
                                isRes = isRes && true;
                            }
                            else
                            {
                                cur.next = null!;
                                isRes = isRes && true;

                            }
                            break;
                        }
                    }
                    cur = cur.next!;
                }
            }
            isRes = isRes && !Contains(item);
            return isRes;
        }
            

        public class MyEnumerator<T> : IEnumerator<T>
        {
            ListProduction<T>[] arr;
            ListProduction<T> current;
            ListProduction<T> beg;
            private int position;
            public MyEnumerator(HahTable<T> Hah)
            {
                arr = Hah.table;
                beg = null!;
                position = -1;
            }

            public T Current
            {
                get
                {
                    if (position == -1 || position >= arr.Length)
                    {
                        throw new ArgumentException();
                    }
                    return current.value;
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public bool MoveNext()
            {

                while (beg is null && position < arr.Length - 1)
                {
                    beg = arr[++position];
                }
                if (position >= arr.Length || beg is null)
                    return false;
                current = beg;
                if (current.next is null && beg is null)
                {
                    if (position < arr.Length - 1)
                    {
                        beg = arr[++position];
                        return true;
                    }
                    return false;

                }
                else
                {
                    current = beg;
                    beg = beg.next;
                    return true;
                }

            }
            public void Reset()
            {
                current = arr[0];
                position = -1;
            }
            public void Dispose() { }

        }

        public static bool operator ==(HahTable<T>? left, HahTable<T>? right)
        {
            return EqualityComparer<HahTable<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(HahTable<T>? left, HahTable<T>? right)
        {
            return !(left == right);
        }
    }


    public class NewHashtableCollection<T> : HahTable<T>
    {
        public string Name { get; init; } = "Name0";

        public event CollectionHandler<T> CollectionCountChanged;
        public event CollectionHandler<T> CollectionReferenceChanged;

        public NewHashtableCollection(string name, int size = 8) : base(size) => Name = name;

        public NewHashtableCollection(NewHashtableCollection<T> obj) : base(obj) => Name = obj.Name;


        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs<T> e)
        {
            CollectionCountChanged?.Invoke(source, e);
        }
        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs<T> e)
        {
            CollectionReferenceChanged.Invoke(source, e);
        }
        public override void Add(T product)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, "Добавление", product));
            base.Add(product);
        }
        public override bool Add(params T[] objs)
        {
            bool result = true;
            foreach (var obj in objs)
            {
                Add(obj);
                result = result && Contains(obj);
            }
            return result;
        }
        public override bool Remove(T data)
        {
            if (!Contains(data)) return false;
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, "Удаление", data));
            return base.Remove(data);
        }
        public bool Remove(int j)
        {
            if (j > Length) return false;
            foreach (T item in this)
            {
                if (--j == 0)
                    if (Contains(item))
                        return Remove(item);
                    else if (j < 0)
                        return false;
            }
            return false;
        }
        public object Clone()
        {
            return new NewHashtableCollection<T>(this);
        }
        public T this[int index]
        {
            get
            {
                if (!CheckIndex(index))
                {
                    throw new IndexOutOfRangeException("Индекс больше/меньше, чем возможно!");
                }
                foreach (T item in this)
                {
                    if (index-- == 0)
                        return item;
                }
                return default(T);
            }
            set
            {
                if (!CheckIndex(index))
                {
                    throw new IndexOutOfRangeException("Индекс больше/меньше, чем возможно!");
                }
                if (value == null)
                {
                    T oldValue = this[index];
                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs<T>(Name, "Измененно(зануленно)", oldValue));
                    base.Remove(oldValue);
                }
            }
        }

        public bool CheckIndex(int index)
        {
            if (index > this.Count - 1)
                return false;
            else if (index < 0)
                return false;
            return true;
        }
        public override void Clear()
        {
            foreach (var item in this)
            {
                if (!Contains(item)) continue;
                else
                {
                    base.Remove(item);
                    OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, "Очистка", item));
                }
            }
        }
        public override int Length => base.Count;
        public int Size => base.Length;


    }
    public delegate void CollectionHandler<T>(object source, CollectionHandlerEventArgs<T> args);
    public class CollectionHandlerEventArgs<T> : EventArgs
    {
        public string nameCollection { get; set; }
        public string typeChange { get; set; }
        public T ChaingedObj { get; }

        public CollectionHandlerEventArgs(string nameCollection, string typeChange, T? ChaingedObj)
        {
            this.nameCollection = nameCollection;
            this.typeChange = typeChange;
            this.ChaingedObj = ChaingedObj ?? default!;
        }

        public override string ToString() => $"Название коллекции:\t {nameCollection};\t Тип изменения:\t {typeChange};";
    }
    public class Journal<T>
    {
        protected List<JournalEntry<T>> journalList;
        protected class JournalEntry<T>
        {
            public string Name { get; }
            public string CollectionChangeType { get; }
            public string ObjectInformation { get; }


            public JournalEntry(string name, string collectionChangeType, string objectInformation)
            {
                Name = name;
                CollectionChangeType = collectionChangeType;
                ObjectInformation = objectInformation;
            }
            public override string ToString()
            {
                string outString = "";
                outString += "Название коллекции: " + Name + '\n'
                    + "Тип изменения: " + CollectionChangeType + '\n'
                    + "Информация об объекте: " + ObjectInformation + '\n'
                    + "\t--------------\n" + '\n';
                return outString;
            }
        }

        public Journal()
        {
            journalList = new List<JournalEntry<T>>();
        }

        protected void Add(JournalEntry<T> je)
        {
            journalList.Add(je);
        }

        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs<T> args)
        {
            var j = new JournalEntry<T>(args.nameCollection, args.typeChange, args.ChaingedObj.ToString());
            this.Add(j);
        }
        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs<T> args)
        {
            JournalEntry<T> je = new JournalEntry<T>(args.nameCollection, args.typeChange, args.ChaingedObj.ToString());
            this.Add(je);
        }

        public override string ToString()
        {
            string outString = "";
            outString += "[Начало журнала]" + "\n\n";

            foreach (JournalEntry<T> je in journalList)
                outString += je.ToString();
            outString += "[Конец журнала]" + '\n';

            return outString;
        }
        public void Print()
        {
            if (journalList != null)
            { Console.WriteLine(this); }
        }
    }
}
