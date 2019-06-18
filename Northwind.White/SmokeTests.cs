using System;
using TestStack.White;
using Xunit;
using Xunit.Sdk;

namespace Northwind.White
{
    public class SmokeTests
    {
        [Fact]
        public void Can_add_a_department()
        {
            Windows.Main.AddDepartment();
            Windows.NewDepartment.CreateDepartment("Automation Department");

            Assert.True(
                Windows.Main.IsDepartmentInList("Automation Department"),
                "Created department is not in the list");
        }
    }
}
