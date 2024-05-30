using HashTableCollection;

namespace Laba13
{
    public class NewHashtableCollection<T> : HahTable<T>
    {
        public string Name { get; init; } = "Name0";

        public event CollectionHandler<T> CollectionCountChanged;
        public event CollectionHandler<T> CollectionReferenceChanged;

        public NewHashtableCollection(string name, int size = 8) : base(size) => Name = name;

        public NewHashtableCollection( NewHashtableCollection<T> obj) : base(obj) => Name = obj.Name;


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
                result = result&&Contains(obj);
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
}
