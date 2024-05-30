using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibraryProductionShop;

namespace MyMenu
{
    public class UserMenu
    {
        private MenuCategory _current;

        public UserMenu(MenuCategory root)
        {
            _current = root;
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
                        if (index < _current.Items.Length - 1)
                            index++;
                        else
                            index = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        else
                            index = _current.Items.Length - 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (_current.Items[index])
                        {
                            case MenuCategory category:
                                wayBack.Push(_current);
                                index = 0;
                                _current = category;
                                Console.Clear();
                                break;
                            case MenuAction action:
                                action.Action();
                                break;
                                                      
                            case MenuPredicate predicate:
                                predicate.Predicate(predicate);
                                break;
                            case MenuBack:
                                if (wayBack.Count == 0)
                                    return;
                                MenuCategory parent = wayBack.Pop();
                                index = Array.IndexOf(parent.Items, _current);
                                _current = parent;
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
            Console.SetCursorPosition(col=0, row=0);
            Console.WriteLine(_current.Name);
            Console.WriteLine();

            for (int i = 0; i < _current.Items.Length; i++)
            {
                if (i == index)
                {

                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(_current.Items[i].Name);
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
    public class MenuAct<K,T> : MenuItem
    {
        public delegate void Act(K Key, T Value);
        Act Action { get; }
        K Key { get; }      
        T Value { get; }

        public MenuAct(string name, Act action, K key, T value) : base(name)
        {
            Action = action;
            Key = key;
            Value = value;
        }
    }
    public class MenuPredicate : MenuItem
    {
        public Predicate<MenuItem> Predicate { get; }

        public MenuPredicate(string name, Predicate<MenuItem> predicate) : base(name)
        {
            Predicate = predicate;
        }
    }
    public class MenuBack : MenuItem
    {
        public MenuBack(string name = "Назад") : base(name) { }
    }


}
