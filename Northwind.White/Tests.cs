using System;
using System.Linq;
using Xunit;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;


namespace Northwind.White
{
    public class Tests
    {
        [Fact]
        public void GettingStarted()
        {
            //Get application
            Application application = Application.Launch(
                @"C:\Users\Vlad\Desktop\1-wpf-exercise-files\Northwind\Northwind.UI\bin\Debug\Northwind.UI.exe");
            //Get window by it's name
            Window main= application.GetWindow("Northwind");
            //Get ListBox item in main window
            var mainMenu = main.Get<ListBox>();
            //select item in listbox
            mainMenu.Item("Employees").Select();
            //click button by text
            main.Get<Button>(SearchCriteria.ByText("Add")).Click();

            //create new window with awaiting it 
            Window newEmployee = Retry.For(
                () => application.GetWindows().First(x => x.Title.Contains("New employee")),
                TimeSpan.FromSeconds(5));
            //get text box by index and insert text there
            newEmployee.Get<TextBox>(SearchCriteria.Indexed(0)).Text = "Vladimir";
            newEmployee.Get<TextBox>(SearchCriteria.Indexed(1)).Text = "Khorikov";
            newEmployee.Get<TextBox>(SearchCriteria.Indexed(2)).Text = "I'm a software developer";
            newEmployee.Get<Button>(SearchCriteria.ByText("Change")).Click();
            Window department = Retry.For(
                () => application.GetWindows().First(x => x.Title.Contains("Change department")),
                TimeSpan.FromSeconds(5));
            department.Get<ListBox>().Item("Test department").Select();
            department.Get<Button>(SearchCriteria.ByText("OK")).Click();
            newEmployee.Get<Button>(SearchCriteria.ByText("OK")).Click();

            Window employee = Retry.For(
                () => application.GetWindows().First(x => x.Title.Contains("Employee")),
                TimeSpan.FromSeconds(5));
            employee.Get<Button>(SearchCriteria.ByText("OK")).Click();

            //get list view
            var listView = main.Get<ListView>();
            //get cel in the list view
            listView.Cell("First Name",0).Click();
            main.Get<Button>(SearchCriteria.ByText("Edit")).Click();
            Window editEmployee = Retry.For(
                () => application.GetWindows().First(x => x.Title.Contains("Employee")),
                TimeSpan.FromSeconds(5));
            var textBox = editEmployee.Get<TextBox>(SearchCriteria.Indexed(0));
            Assert.Equal("Vladimir2", textBox.Text);

        }
    }
}
