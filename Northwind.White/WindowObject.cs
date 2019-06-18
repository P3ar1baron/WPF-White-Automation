using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;

namespace Northwind.White
{
    public class WindowObject
    {
        protected Window _window;

        protected WindowObject(Window window)
        {
            _window = window;
        }

        protected Button Button(string title)
        {
            return _window.Get<Button>(SearchCriteria.ByText("OK"));
        }

        protected TextBox TextBox()
        {
            return _window.Get<TextBox>();
        }

        protected ListView ListView()
        {
            return _window.Get<ListView>();
        }

        protected ListBox ListBox()
        {
            return _window.Get<ListBox>();
        }

    }
}