namespace MyMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuCategory main = new MenuCategory("Главное меню", new MenuItem[]
        {
        new MenuPredicate("Пункт 1", SomeActionMethod1),
        new MenuAction("Пункт 2", SomeActionMethod),
        new MenuAction("Пункт 3", SomeActionMethod),
        new MenuCategory("Подменю 1", new MenuItem[]
        {
            new MenuAction("Пункт 1.1", SomeActionMethod),
            new MenuAction ("Пункт 1.2", SomeActionMethod),
            new MenuAction ("Пункт 1.3", SomeActionMethod),
            new MenuBack()
        }),
        new MenuCategory("Подменю 2", new MenuItem[]
        {
            new MenuAction ("Пункт 2.1", SomeActionMethod),
            new MenuAction ("Пункт 2.2", SomeActionMethod),
            new MenuBack()
        }),
        new MenuBack("Выход")
        });

            UserMenu menu = new UserMenu(main);
            menu.Run();

            Console.WriteLine("Выход из приложения, нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void SomeActionMethod(MenuItem menuItem)
        {
            Console.WriteLine($"Вы нажали: {menuItem.Name}");
        }
        private static void SomeActionMethod2(int menuItem)
        {
            Console.WriteLine($"Вы нажали: {menuItem}");
        }
        private static bool SomeActionMethod1(MenuItem menuItem)
        {
            Console.WriteLine($"Вы нажали: {menuItem.Name}");
            return true;
        }
    }

}
