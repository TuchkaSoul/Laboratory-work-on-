namespace HashTableCollection
{
    public class ListProduction<T> : ICloneable, IEquatable<ListProduction<T>?>
    {
        public int key;//ключ
        public T value;//значение
        public ListProduction<T> next;//ссылка на следующий элемент

        static Random rnd = new Random();
        public ListProduction(T s)
        {
            value = s;
            key = GetHashCode();
            next = null!;
        }
        public ListProduction(ListProduction<T> lp) 
        {
            key = lp.key;
            value = lp.value;
            if(lp.next is not null)
                next = (ListProduction<T>)lp.next.Clone();
            else next = null!;
        }
        public ListProduction() { }
        public ListProduction(int key, T value, ListProduction<T> next)
        {
            this.key = key;
            this.value = value;
            this.next = next;
        }
        public object Clone()
        {
            return new ListProduction<T>(this);
        }
        public override string ToString()
        {
            return key + ":" + value!.ToString();
        }
        
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ListProduction<T>);
        }

        public bool Equals(ListProduction<T>? other)
        {
            return other is not null &&
                   key == other.key &&
                   EqualityComparer<T>.Default.Equals(value, other.value) &&
                   EqualityComparer<ListProduction<T>>.Default.Equals(next, other.next);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(key, value, next);
        }

        public static bool operator ==(ListProduction<T>? left, ListProduction<T>? right)
        {
            return EqualityComparer<ListProduction<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(ListProduction<T>? left, ListProduction<T>? right)
        {
            return !(left == right);
        }
    }

}
