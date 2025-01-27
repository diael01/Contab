using Contracts.Models;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using static CommonTestHelper.CommonHelper;

namespace UnitTests
{

    [Collection("Sequential")]
    public class EmployeeUnitTests : BaseUnitTest
    {


        //root
        [Fact]
        public async Task AddEmployee_Unit_Should_Be_OK()
        {
            EmpData d = null;
            try
            {
                //Arrange
                d = await SetupEmp();

            } finally
            {
                await TearDownEmp(d);
            }
        }

        [Fact]
        public async Task UpdateEmployee_Unit_Should_Be_OK()
        {
            EmpData d = null;
            try
            {
                //Arrange
                d = await SetupEmp();

                //act emp3 => change manager
                var empNode2 = await DBContext.Employees.Where(e => e.LastName == "Vili").FirstOrDefaultAsync();
                var empNode3 = await DBContext.Employees.Where(e => e.LastName == "mama").FirstOrDefaultAsync();
                empNode3.ManagerNode = empNode2.EmpNode;
                empNode3.Location = "aaaLoc";
                empNode3.FirstName = "aaaSur";

                var empdto = mapper.Map<EmpDTO>(empNode3);
                await empService.UpdateEmployee(empdto);
            } finally
            {
                await TearDownEmp(d);
            }
        }

        [Fact]
        public async void DeleteEmployeeList_Unit_Should_Be_OK()
        {
            EmpData d = null;
            try
            {
                //Arrange
                d = await SetupEmp();

                //Act
                //Assert -- delete level 2
                var empList = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 2).ToListAsync();
                //Assert -- delete level 1
                var empList1 = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 1).ToListAsync();

                //Assert
                await DeleteActAssert(empList);
                await DeleteActAssert(empList1);
            } finally
            {
                await TearDownEmp(d);
            }
        }

        private async Task DeleteActAssert(List<Employee> list)
        {
            foreach (var node in list)
            {
                await empService.DeleteEmployee(node.EmpNode.ToString());
                //Assert
                var func = await DBContext.Employees.Where(e => e.EmpNode == node.EmpNode).FirstOrDefaultAsync();
                func.Should().BeNull();
            }
        }
    }
}
