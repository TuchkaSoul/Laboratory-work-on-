
using System.Runtime.Serialization;

namespace UserLibraryProductionShop
{
    [Serializable]
    public class Shop : Workshop
    {
        protected int numberShopWorkers = 0;

        public int NumberShopWorkers
        {
            get { return numberShopWorkers; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Данный параметр не может являться количеством работников цеха!");
                }
                numberShopWorkers = value;
            }
        }
        public Shop() { }

        public Shop(string nameProduction, string branchProduction, string nameFactory, double annualOutput, string managerWorkshop, int numberShopWorkers) :
            base(nameProduction, branchProduction, nameFactory, annualOutput, managerWorkshop)
        {
            NumberShopWorkers = numberShopWorkers;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Количество работников цеха - {NumberShopWorkers}");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество работников цеха:");
            NumberShopWorkers = UserUtility1.InputData.EnterData();
        }

        public override void InitRandom()
        {
            base.InitRandom();
            NumberShopWorkers = rnd.Next(1, 100);
        } 

        public override bool Equals(object? obj)
        {
            return obj is Shop shop &&
                   base.Equals(obj) &&
                   NameProduction == shop.NameProduction &&
                   BranchProduction == shop.BranchProduction &&
                   NameFactory == shop.NameFactory &&
                   AnnualOutput == shop.AnnualOutput &&
                   ManagerWorkshop == shop.ManagerWorkshop &&
                   NumberShopWorkers == shop.NumberShopWorkers;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), NameProduction, BranchProduction, NameFactory, AnnualOutput, ManagerWorkshop, NumberShopWorkers);
        }

        public static bool operator ==(Shop? left, Shop? right)
        {
            return EqualityComparer<Shop>.Default.Equals(left, right);
        }

        public static bool operator !=(Shop? left, Shop? right)
        {
            return !(left == right);
        }
        public override object Clone()
        {
            return new Shop(NameProduction, BranchProduction, NameFactory, AnnualOutput, ManagerWorkshop, NumberShopWorkers);
        }
        public override string ToString()
        {
            string str=NameProduction.ToString() + " " + BranchProduction.ToString() + " " + NameFactory.ToString() +" "+ AnnualOutput.ToString() + " " + ManagerWorkshop.ToString() +" "+ NumberShopWorkers.ToString();
            return str;
        }
        public override string ToTXTString()
        {
            
            return $"{NameProduction}; {BranchProduction}; {NameFactory}; {AnnualOutput}; {ManagerWorkshop}; {NumberShopWorkers};";
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("NumberShopWorkers", NumberShopWorkers);
        }
        public Shop(SerializationInfo info, StreamingContext context):base(info, context)
        {
            NumberShopWorkers = info.GetInt32("NumberShopWorkers");
        }
    }

}
