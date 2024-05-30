namespace Laba13
{
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
}
