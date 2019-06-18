using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace Northwind.White
{
    public class MainWindow : WindowObject
    {
        private Window _window;

        private ListItem DepartmentsTab
        {
            get { return ListBox().Item("Departments"); }
        }

        private Button AddButton
        {
            get { return Button("Add"); }
        }

        private ListView DataGrid
        {
            get { return _window.Get<ListView>(); }
        }

        internal MainWindow(Window window) : base(window)
        {
            _window = window;
        }

        public void AddDepartment()
        {
            DepartmentsTab.Select();
            AddButton.Click();
        }

        public bool IsDepartmentInList(string departmentName)
        {
            DepartmentsTab.Select();
            return DataGrid.Rows[0].Cells["Name"].Text == departmentName;
        }
    }
}