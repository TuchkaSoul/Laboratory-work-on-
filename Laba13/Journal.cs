namespace Laba13
{
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
