namespace UserLibraryProductionShop
{
    public class ProductionBranchComparer : IComparer<Production>
    {
        public int Compare(Production? x, Production? y) => x!.BranchProduction.CompareTo(y!.BranchProduction);
    }
}
