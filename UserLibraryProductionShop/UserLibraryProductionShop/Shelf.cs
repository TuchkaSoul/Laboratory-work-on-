namespace Task
{
    public class Shelf : IInit, ICloneable
    {
        private static Random rnd = new Random();
        public Dictionary<string, int> books = new Dictionary<string, int>();
        public Shelf() {}
        public Shelf(Shelf other)
        {
            books = other.books.ToDictionary(t => t.Key, t => t.Value);
        }
        public object Clone()
        {
            return new Shelf(this);
        }
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }
        public void Init()
        {
            Console.WriteLine("Введите количество книг:");
            var count = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите название книги:");
                var name = Console.ReadLine();

                if (books.ContainsKey(name!))
                {
                    books[name!] += 1;
                }
                else
                {
                    books[name!] = 1;
                }
            }
        }
        public void InitRandom()
        {
            var count = rnd.Next(0, 25);

            for (int i = 0; i < count; i++)
            {
                string[] namebook = new string[] { "Недоросль", "Бедная Лиза", "Горе от ума", "Евгений Онегин", "Борис Годунов", "Повести Белкина", "Маленькие трагедии", "Медный всадник", "Пиковая дама", "Капитанская дочка", "Герой нашего времени", "Вечера на хуторе близ Диканьки", "Миргород", "Мертвые души", "Ревизор", "Тарас Бульба", "Петербургские повести", "Кто виноват?", "Обломов", "Обыкновенная история", "Записки охотника", "Муму", "Дворянское нездо", "Ася", "Отцы и дети", "Вешние воды", "Детство. Отрочество. Юность", "Война и мир", "Кавказский пленник", "Анна Каренина", "Воскресение", "Крейцерова соната", "Гроза", "Бесприданница", "Что делать?", "Леди Макбет Мценского уезда", "Левша", "Село Степанчиково и его обитатели", "Записки из Мертвого дома", "Преступление  аказание", "Идиот", "Бесы", "Подро́сток", "Братья Карамазовы", "История одного города", "Господа Головлевы", "Кому на Руси жить хорошо", "Драма на охоте", "Рассказы", "Дуэль", "Дядя Ваня", "Чайка", "Три сестры", "Вишневый сад", "На дне", "Мать", "Детство", "Жизнь Клима Самгина", "Красный смех", "Олеся", "Гранатовый браслет", "Петербург", "Мы", "Антоновские яблоки", "Лёгкое дыхание", "Митина любовь", "Темные аллеи", "Алые паруса", "Три Толстяка", "Одесские рассказы", "Петр Первый", "Хождение по мукам", "Собачье сердце", "Белая гвардия", "Записки юного врача", "Мастер и Маргарита", "12 стульев", "Золотой теленок", "Донские рассказы", "Тихий дон", "Чевенгур", "Котлован", "Как закалялась сталь", "Рассказы о Леле и Миньке", "Перед восходом олнца", "Старуха", "Дракон", "Белеет парус одинокий", "Сын полка", "Два капитана", "Повесть о жизни", "Доктор Живаго", "Молодая гвардия", "Жизнь и судьба", "А зори здесь тихие", "Пикник на обочине", "Калина красная", "Кролики и удавы", "Заповедник", "Чемодан" };
                string name = namebook[rnd.Next(0, namebook.Length)];
                if (books.ContainsKey(name))
                {
                    books[name] += 1;
                }
                else
                {
                    books[name] = 1;
                }
            }
        }
        public virtual void Show()
        {
            books.Keys.ToList().ForEach(x => Console.WriteLine($"Книга: {x}\tКоличество: {books[x]}"));
        }

        public override bool Equals(object? obj)
        {
            return obj is Shelf shelf &&
                   EqualityComparer<Dictionary<string, int>>.Default.Equals(books, shelf.books);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(books);
        }
    }
}
