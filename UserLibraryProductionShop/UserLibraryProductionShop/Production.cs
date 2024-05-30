using System.Runtime.Serialization;

namespace UserLibraryProductionShop
{
    [Serializable]
    public class Production : IInit, IComparable<Production>, ICloneable, ISerializable
    {
        protected static Random rnd = new Random();
        //1. поля производства.
        protected string nameProduction = "nameProduction0";
        protected string branchProduction = "branchProduction0";

        //2. свойства производства.
        public string NameProduction
        {
            get { return nameProduction; }
            set
            {
                if (value == null || value == "")
                    throw new Exception("Данное поле не принимает такое значение");
                nameProduction = value!;
            }
        }

        public string BranchProduction
        {
            get { return branchProduction; }
            set
            {
                if (value == null || value == "")
                    throw new Exception("Данное поле не принимает такое значение");
                branchProduction = value!;
            }
        }
        //3. Конструкторы производства.

        public Production() { }

        public Production(string nameProduction, string branchProduction)
        {
            this.nameProduction = nameProduction;
            this.branchProduction = branchProduction;
        }
        public virtual void Show()
        {
            Console.WriteLine($"Название производста - {NameProduction}\nОтросль производства - {BranchProduction}");
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите имя производства:");
            NameProduction = Console.ReadLine()!;
            Console.WriteLine($"Введите отрасль производства {NameProduction}:");
            branchProduction = Console.ReadLine()!;
        }
        public virtual void InitRandom()
        {
            String[] defaultName = new String[] { "Сабона Плюс", "Арт-Комплект", "Металлиндустрия", "Ресурс-Капитал", "Торговый дом ", "Оникс", "Ремстройсервис", "МедиаСервис", "Аргумент", "Прайм-Информ", "О Г М", "НПП Модус-М", "Стройтехносфера", "Промснаб", "Элегия", "Интра-Трейд", "Производственная компания \"УралВагонМеханика\"", "Шина", "Строй-Астер", "Автодиск", "Торгово-производственное предприятие Черметопторг", "АтомнаяСила", "КвантТех", "ГигаПроизвод", "ИндустрияБудущего", "МодернСталь", "ПрометейТех", "РеволюшнФабрика", "ПромышленныйРенессанс", "ЭнергоКонструкт", "Формула Производства", "ЗаводИнтеграция", "ПередовойПром", "ВекторТехнологий", "Титан Промышленности", "ВековойСтандарт","Норма жизни","Расцвет империи","Возрождение","МММ","Инженерия богов","БиологЭкспо","Кулачная","РАДИОн","Лучший производитель" };
            String[] defaultBranch = new String[] { "добывающая промышленность", "электроэнергетика", "гидроэлектроэнергетика", "металлургия", "черная металлургия", "цветная металлургия", "машиностроение", "автомобилестроение", "самолетостроение", "кораблестроение", "электронная промышленность", "химическая промышленность", "сельско-хозяйственая промышленность", "лёгкая промышленность", "пищевая промышленность", "топливная промышленность", "лесная промышленность", "Промышленность стройматериалов","Атомная энергетика","ИП","рыбоводство"," животноводство","производство сторительных материалов","перерабатывающая промышленность","Угольная промышленность","железнорудная промышленносить","аэрокосмическое производств","индустрия информатики","Текстильная промышленность" };
            
            NameProduction = defaultName[rnd.Next(0,defaultName.Length)];           
            BranchProduction = defaultBranch[rnd.Next(0, defaultBranch.Length)];
        }
        public override bool Equals(object? obj)
        {
            return obj is Production production &&
                   NameProduction == production.NameProduction &&
                   BranchProduction == production.BranchProduction;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(NameProduction, BranchProduction);
        }
        public bool Equals(Production? production)
        {
            return NameProduction == production!.NameProduction &&
                   BranchProduction == production.BranchProduction;
        }
        public static bool operator ==(Production? left, Production? right)
        {
            return EqualityComparer<Production>.Default.Equals(left, right);
        }
        public static bool operator !=(Production? left, Production? right)
        {
            return !(left == right);
        }
        public int CompareTo(Production? obj)
        {
            return NameProduction.CompareTo(obj!.NameProduction);
        }
        public int CompareTo(String obj)
        {
            if (String.Compare(this.NameProduction, obj) > 0) return 1;
            if (String.Compare(this.NameProduction, obj) < 0) return -1;
            return 0;
        }
        public static int Compare(Object? obj, Object? obj1)
        {
            Production temp = (Production)obj!;//приведение к типу Production
            Production temp1 = (Production)obj1!;//приведение к типу Production
            if (String.Compare(temp.NameProduction, temp1.NameProduction) > 0) return 1;
            if (String.Compare(temp.NameProduction, temp1.NameProduction) < 0) return -1;
            return 0;
        }
        public virtual object Clone()
        {
            return new Production(NameProduction, BranchProduction);
        }
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }
        public override string ToString()
        {
            string str = NameProduction.ToString() + " " + BranchProduction.ToString();
            return str;
            
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("NameProduction", NameProduction);
            info.AddValue("BranchProduction", BranchProduction);
        }
        public Production(SerializationInfo info, StreamingContext context)
        {
            NameProduction = info.GetString("NameProduction");
            BranchProduction = info.GetString("BranchProduction");
        }
        public virtual string ToTXTString()
        {

            return $"{NameProduction}; {BranchProduction};";
        }
    }

}
