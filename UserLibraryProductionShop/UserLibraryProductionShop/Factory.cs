
using System.Runtime.Serialization;

namespace UserLibraryProductionShop

{
    [Serializable]
    public class Factory : Production
    {
        //1. поля Фабрики.
        string nameFactory = "nameFactory0";
        double annualOutput = 0;

        //2. поля Фабрика.
        public string NameFactory
        {
            get { return nameFactory; }
            set
            {
                if (value == null || value == "")
                {
                    throw new Exception("Данный параметр не может являться названием фабрики!");
                }
                nameFactory = value;
            }
        }
        public Production BaseProduction
        {
            get 
            {
                return new Production(NameProduction, BranchProduction); 
            }
        }
        public double AnnualOutput
        {
            get { return annualOutput; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Данный параметр не может являться названием фабрики!");
                }
                annualOutput = value;
            }
        }
        public Factory() { }

        public Factory(string nameProduction, string branchProduction, string nameFactory, double annualOutput) :
            base(nameProduction, branchProduction)
        {
            NameFactory = nameFactory;
            AnnualOutput = annualOutput;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Фабрика - {NameFactory}\nГодовой объём производства фабрики - {AnnualOutput} Млн\\год");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите название фабрики:");
            NameFactory = Console.ReadLine()!;
            Console.WriteLine($"Введите годовой объем производства фабрики \"{NameFactory}\":");
            AnnualOutput = UserUtility1.InputData.EnterDataDouble();
        }
        public override void InitRandom()
        {
            base.InitRandom();
            String[] defaultNameFactory = new String[] { "ТехноИмпульс", "ПроизводСтрой", "ЗаводНоваЭра", "ИнноваСталь", "КристаллТех", "ФьюжнМеталл", "ПрогрессПолимер", "АвангардПром", "ЭлементаСтрой", "МеталлоКрафт", "СинтезПром", "ЭкоЛайнПроизвод", "АтомнаяСила", "КвантТех", "ГигаПроизвод", "ИндустрияБудущего", "МодернСталь", "ПрометейТех", "РеволюшнФабрика", "ПромышленныйРенессанс", "ЭнергоКонструкт", "Формула Производства", "ЗаводИнтеграция", "ПередовойПром", "ВекторТехнологий", "Титан Промышленности", "ВековойСтандарт", "ТрансформаЗавод" };
            NameFactory = defaultNameFactory[rnd.Next(1, defaultNameFactory.Length)];
            AnnualOutput = (double)rnd.Next(1000, 10000000) / 10000;
        }

        public override bool Equals(object? obj)
        {
            return obj is Factory factory &&
                   base.Equals(obj) &&
                   NameProduction == factory.NameProduction &&
                   BranchProduction == factory.BranchProduction &&
                   NameFactory == factory.NameFactory &&
                   AnnualOutput == factory.AnnualOutput;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), NameProduction, BranchProduction, NameFactory, AnnualOutput);
        }

        public static bool operator ==(Factory? left, Factory? right)
        {
            return EqualityComparer<Factory>.Default.Equals(left, right);
        }

        public static bool operator !=(Factory? left, Factory? right)
        {
            return !(left == right);
        }
        public override object Clone()
        {
            return new Factory(NameProduction, BranchProduction, NameFactory, AnnualOutput);
        }
        public override string ToString()
        {
            string str = NameProduction.ToString() + " " + BranchProduction.ToString() + " " + NameFactory.ToString() + " " + AnnualOutput.ToString();
            return str;
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("NameFactory", NameFactory);
            info.AddValue("AnnualOutput", AnnualOutput);
        }
        public Factory(SerializationInfo info, StreamingContext context):base(info, context)
        {
            NameFactory = info.GetString("NameFactory");
            AnnualOutput = info.GetDouble("AnnualOutput");
        }
        public override string ToTXTString()
        {

            return $"{NameProduction}; {BranchProduction}; {NameFactory}; {AnnualOutput};";
        }
    }
}
