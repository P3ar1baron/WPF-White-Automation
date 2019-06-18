using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace Northwind.White
{
    public class MainWindow
    {
        private Window _window;

        private ListItem DepartmentsTab
        {
            get
            {
                var listBox = _window.Get<ListBox>();
                return listBox.Item("Departments");
            }
        }

        private Button AddButton
        {
            get { return _window.Get<Button>(SearchCriteria.ByText("Add")); }
        }

        private ListView DataGrid
        {
            get { return _window.Get<ListView>(); }
        }

        public MainWindow(Application application)
        {
            _window = application.GetWindow("Northwind");
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