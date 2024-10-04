using CommonTestHelper;
using Contracts.Models;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using static CommonTestHelper.CommonHelper;

namespace UnitTests
{

    [Collection("Sequential")]
    public class EmployeeUnitTests : BaseUnitTest, IDisposable
    {


        public EmployeeUnitTests() : base()
        {
        }

        public async Task Dispose()
        {
        }

        private async Task<EmpData> Setup()
        {
            EmpData d = new EmpData();
            d.orgId = await CommonHelper.AddEntityNode("Con");

            d.deptId = await CommonHelper.AddEntityNode("Business", d.orgId, "Con");
            d.actId = await CommonHelper.AddEntityNode("Mgmt", d.deptId, "Business");
            d.funcId1 = await CommonHelper.AddEntityNode("CEO", d.actId, "Mgmt");
            d.funcId2 = await CommonHelper.AddEntityNode("CTO", d.actId, "Mgmt");
            d.funcId3 = await CommonHelper.AddEntityNode("Manager", d.actId, "Mgmt");

            d.dto = TestData.GetEmpDTO(0, "Eu", null, "CEO", d.funcId1);
            d.empId = await empService.AddEmployee(d.dto);
            var empNode = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 0).FirstOrDefaultAsync();

            //Arrange add employee level 1
            d.dto1 = TestData.GetEmpDTO(1, "Vili", "Eu", "CTO", d.funcId2);
            d.dto1.ManagerNodeText = empNode.EmpNode.ToString();
            d.empId1 = await empService.AddEmployee(d.dto1);

            //Arrange add employee level 2
            d.dto2 = TestData.GetEmpDTO(2, "mama", "Eu", "Manager", d.funcId3);
            d.dto2.ManagerNodeText = empNode.EmpNode.ToString();
            d.empId2 = await empService.AddEmployee(d.dto2);
            return d;
        }

        private async Task TearDown(EmpData d)
        {
            await empService.DeleteEmployee(d.empId2);
            await empService.DeleteEmployee(d.empId1);
            await empService.DeleteEmployee(d.empId);

            await orgService.DeleteNode(d.funcId3);
            await orgService.DeleteNode(d.funcId1);
            await orgService.DeleteNode(d.funcId2);

            await orgService.DeleteNode(d.actId);
            await orgService.DeleteNode(d.deptId);
            await orgService.DeleteNode(d.orgId);
        }



        //root
        [Fact]
        public async Task AddEmployee_Unit_Should_Be_OK()
        {

            //Arrange
            var d = await Setup();

            await TearDown(d);
        }

        [Fact]
        public async Task UpdateEmployee_Unit_Should_Be_OK()
        {
            //Arrange
            var d = await Setup();

            //act emp3 => change manager
            var empNode2 = await DBContext.Employees.Where(e => e.Name == "Vili").FirstOrDefaultAsync();
            var empNode3 = await DBContext.Employees.Where(e => e.Name == "mama").FirstOrDefaultAsync();
            empNode3.ManagerNode = empNode2.EmpNode;
            empNode3.ManagerNodeText = empNode3.ManagerNode.ToString();
            empNode3.ManagerNodeName = empNode2.Name;
            empNode3.Location = "aaaLoc";
            empNode3.Surname = "aaaSur";

            var empdto = mapper.Map<EmpDTO>(empNode3);
            await empService.UpdateEmployee(empdto);

            await TearDown(d);
        }


        [Fact]
        public async void DeleteEmployeeList_Unit_Should_Be_OK()
        {
            var d = await Setup();

            //Act
            //Assert -- delete level 2
            var empList = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 2).ToListAsync();
            //Assert -- delete level 1
            var empList1 = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 1).ToListAsync();

            //Assert
            await DeleteActAssert(empList);
            await DeleteActAssert(empList1);

            await TearDown(d);
        }

        private async Task DeleteActAssert(List<Employee> list)
        {
            foreach (var node in list)
            {
                await empService.DeleteEmployee(node.EmpNode.ToString());
                //Assert
                var func = DBContext.Employees.Where(e => e.EmpNode == node.EmpNode).FirstOrDefault();
                func.Should().BeNull();
            }
        }
    }
}
