using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;

namespace Northwind.White
{
    public class NewDepartmentWindow : WindowObject

    {
    private Window _window;

    private TextBox NameTextBox
    {
        get { return TextBox(); }
    }

    private Button OkButton
    {
        get { return Button("OK"); }
    }

    internal NewDepartmentWindow(Window window) : base(window)
    {
        _window = window;
    }

    public void CreateDepartment(string name)
    {
        NameTextBox.Text = name;
        OkButton.Click();
    }
    }
}
