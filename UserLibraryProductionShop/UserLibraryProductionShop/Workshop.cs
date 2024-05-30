
using System.Runtime.Serialization;

namespace UserLibraryProductionShop
{
    [Serializable]
    public class Workshop: Factory
	{
        //1. поля мастерской.

        protected string managerWorkshop = "managerWorkshop0";
        //2. свойства мастерской.

        public string ManagerWorkshop
        {
            get { return managerWorkshop; }
            set
            {
                if (value == null || value == "")
                {
                    throw new Exception("Данный параметр не может являться именем менеджера!");
                }
                managerWorkshop = value;
            }
        }
        //3. конструкторы Матстерсокой.
        public Workshop() { }

        public Workshop(string nameProduction, string branchProduction, string nameFactory, double annualOutput, string managerWorkshop) : 
            base(nameProduction, branchProduction, nameFactory, annualOutput)
        {
            ManagerWorkshop = managerWorkshop;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Менеджер - {ManagerWorkshop}");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите фамилию менежера:");
            ManagerWorkshop = Console.ReadLine()!;
        }
        public override void InitRandom()
        {
            base.InitRandom();
            String[] defaultNameMenegmet = new String[] { "Шилова Милана Тимуровна", "Трифонова София Романовна", "Шувалова Софья Владиславовна", "Щербаков Михаил Маркович", "Коротков Максим Тимурович", "Кузьмин Эмиль Николаевич", "Крючкова Анна Мирославовна", "Нечаев Даниил Александрович", "Гаврилов Александр Антонович", "Воронин Мария Дмитриевна", "Денисов Даниил Тимофеевич", "Поляков Савва Макарович", "Макарова Вероника Ивановна", "Кузьмина Елизавета Арсентьевна", "Кузнецов Дмитрий Артурович", "Дегтярев Давид Владимирович", "Кулагина Елизавета Матвеевна", "Калугина Алиса Даниловна", "Кузнецова Мария Фёдоровна", "Ермолаев Фёдор Владимирович", "Колесников Пётр Сергеевич", "Румянцев Даниил Даниилович", "Тарасов Артур Максимович", "Давыдов Марат Михайлович", "Александров Тимур Артёмович", "Андрианова Надежда Арсеновна", "Зайцев Илья Маркович", "Назаров Матвей Тимурович", "Платонов Михаил Яковлевич", "Токарев Александр Алексеевич", "Филиппова Майя Георгиевна", "Чернышев Тимур Артёмович", "Афанасьева Любовь Павловна", "Алексеева Варвара Владимировна", "Новиков Иван Даниилович", "Селезнев Артур Кириллович", "Петров Даниил Михайлович", "Петрова Агния Матвеевна", "Захаров Вадим Андреевич", "Селезнев Владимир Артемьевич", "Никифорова Анастасия Дмитриевна", "Вешняков Руслан Иванович", "Демина Вероника Никитична", "Титова Оливия Ильинична", "Андреева Анна Степановна", "Мельникова Агата Ивановна", "Новиков Константин Дмитриевич", "Терентьев Егор Захарович", "Гусев Константин Арсентьевич", "Русанов Даниил Александрович", "Данилова Екатерина Данииловна", "Нефедова Алиса Георгиевна", "Виноградов Илья Фёдорович", "Богданов Александр Мирославович", "Морозова Нина Вячеславовна", "Афанасьев Николай Артёмович", "Козлова Дарья Львовна", "Киселева Ева Максимовна", "Панова Дарья Матвеевна", "Лаврентьев Артём Матвеевич" };
            ManagerWorkshop =defaultNameMenegmet[ rnd.Next(0,defaultNameMenegmet.Length)];
            
        }

        public override bool Equals(object? obj)
        {
            return obj is Workshop workshop &&
                   base.Equals(obj) &&
                   NameProduction == workshop.NameProduction &&
                   BranchProduction == workshop.BranchProduction &&
                   NameFactory == workshop.NameFactory &&
                   AnnualOutput == workshop.AnnualOutput &&
                   ManagerWorkshop == workshop.ManagerWorkshop;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), NameProduction, BranchProduction, NameFactory, AnnualOutput, ManagerWorkshop);
        }

        public static bool operator ==(Workshop? left, Workshop? right)
        {
            return EqualityComparer<Workshop>.Default.Equals(left, right);
        }

        public static bool operator !=(Workshop? left, Workshop? right)
        {
            return !(left == right);
        }
        public override object Clone()
        {
            return new Workshop(NameProduction, BranchProduction, NameFactory, AnnualOutput,ManagerWorkshop);
        }
        public override string ToString()
        {
            string str = NameProduction.ToString() + " " + BranchProduction.ToString() + " " + NameFactory.ToString() + " " + AnnualOutput.ToString() + " " + ManagerWorkshop.ToString();
            return str;
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ManagerWorkshop", ManagerWorkshop);
        }
        public Workshop(SerializationInfo info, StreamingContext context): base(info, context) 
        {
            ManagerWorkshop = info.GetString("ManagerWorkshop");

        }
        public override string ToTXTString()
        {

            return $"{NameProduction}; {BranchProduction}; {NameFactory}; {AnnualOutput}; {ManagerWorkshop};";
        }

    }

}
