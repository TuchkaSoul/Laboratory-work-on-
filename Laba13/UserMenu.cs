using UserLibraryProductionShop;
using UserUtility1;

namespace MyMenu
{
    public class UserMenu
    {
        private MenuCategory cur;

        public UserMenu(MenuCategory root)
        {
            cur = root;
        }

        public void Run()
        {
            Stack<MenuCategory> wayBack = new Stack<MenuCategory>();
            int index = 0;
            while (true)
            {
                DrawMenu(0, 0, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < cur.Items.Length - 1)
                            index++;
                        else
                            index = 0;
                        Console.Clear();
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        else
                            index = cur.Items.Length - 1;
                        Console.Clear();

                        break;

                    case ConsoleKey.Escape:
                        if (wayBack.Count == 0)
                        {
                            InputData.Exit();
                            continue;
                        }
                        MenuCategory parent1 = wayBack.Pop();
                        index = Array.IndexOf(parent1.Items, cur);
                        cur = parent1;
                        Console.Clear();
                        break;
                    case ConsoleKey.Enter:
                        switch (cur.Items[index])
                        {
                            case MenuCategory category:
                                wayBack.Push(cur);
                                index = 0;
                                cur = category;
                                Console.Clear();
                                break;

                            case MenuAction action:
                                Console.Clear();
                                DrawMenu(0, 0, index);
                                action.Action();
                                break;

                            case MenuPredicate predicate:
                                Production production = new Production();
                                production.InitRandom();
                                predicate.Predicate(production);
                                break;


                            case MenuBack:
                                if (wayBack.Count == 0)
                                {
                                    InputData.Exit();
                                    continue;
                                }
                                MenuCategory parent = wayBack.Pop();
                                index = Array.IndexOf(parent.Items, cur);
                                cur = parent;
                                Console.Clear();
                                break;
                            default:
                                throw new InvalidCastException("Неизвестный тип пункта меню");
                        }
                        break;
                }
            }
        }

        private void DrawMenu(int row, int col, int index)
        {

            Console.SetCursorPosition(col = 78, row = 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(cur.Name);
            Console.ResetColor();
            Console.WriteLine();

            for (int i = 0; i < cur.Items.Length; i++)
            {
                Console.SetCursorPosition(col = 75, row = 2 + i);
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(cur.Items[i].Name);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
    public abstract class MenuItem
    {
        public string Name { get; }

        public MenuItem(string name)
        {
            Name = name;
        }
    }
    public class MenuCategory : MenuItem
    {
        public MenuItem[] Items { get; }

        public MenuCategory(string name, MenuItem[] items) : base(name)
        {
            Items = items;
        }
    }
    public class MenuAction : MenuItem
    {
        public Action Action { get; }

        public MenuAction(string name, Action action) : base(name)
        {
            Action = action;
        }
    }

    public class MenuPredicate : MenuItem
    {
        public Predicate<Production> Predicate { get; }

        public MenuPredicate(string name, Predicate<Production> predicate) : base(name)
        {
            Predicate = predicate;
        }
    }
    public class MenuBack : MenuItem
    {
        public MenuBack(string name = "Назад") : base(name) { }
    }


}
