using System;
using System.Linq;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;

namespace Northwind.White
{
    public static class Windows
    {
        private static Application _application;

        public static MainWindow Main
        {
            get
            {
                Window window = GetWindow("Northwind");
                return new MainWindow(window);
            }
        }

        public static NewDepartmentWindow NewDepartment
        {
            get
            {
                Window window = GetWindow("Northwind");
                return new NewDepartmentWindow(window);
            }
        }

        public static void Init(Application application)
        {
            _application = application;
        }

        private static Window GetWindow(string title)
        {
            return Retry.For(
                () => _application.GetWindows().First(x => x.Title.Contains("New department")),
                TimeSpan.FromSeconds(5));
        }
    }
}
