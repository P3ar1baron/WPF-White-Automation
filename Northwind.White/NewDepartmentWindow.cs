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
    public class NewDepartmentWindow
    {
        private Window _window;

        public NewDepartmentWindow(Application application)
        {
            Window _window = Retry.For(
                () => application.GetWindows().First(x => x.Title.Contains("New department")),
                TimeSpan.FromSeconds(5));
        }

        public void CreateDepartment(string name)
        {
            _window.Get<TextBox>().Text = name;
            _window.Get<Button>(SearchCriteria.ByText("OK")).Click();
        }
    }
}
