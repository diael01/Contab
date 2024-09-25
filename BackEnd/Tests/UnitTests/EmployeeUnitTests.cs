
using CommonTestHelper;
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Services;

namespace UnitTests
{

    public class EmployeeUnitTests : BaseUnitTest
    {
        IOrgService orgService;
        IEmpService empService;
        public EmployeeUnitTests() : base()
        {
            orgService = new OrgService(DBContext, mapper);
            empService = new EmpService(DBContext, mapper);
            CommonHelper.orgService = orgService;
        }

        //root
        [Fact]
        public async Task AddEmployee_Unit_Should_Be_OK()
        {

            //Arrange
            var orgId = await CommonHelper.AddEntityNode("Con");

            var deptId = await CommonHelper.AddEntityNode("Business", orgId, "Con");
            var actId = await CommonHelper.AddEntityNode("Mgmt", deptId, "Business");
            var funcId1 = await CommonHelper.AddEntityNode("CEO", actId, "Mgmt");
            var funcId2 = await CommonHelper.AddEntityNode("CTO", actId, "Mgmt");
            var funcId3 = await CommonHelper.AddEntityNode("Manager", actId, "Mgmt");

            var dto = TestData.GetEmpDTO(0,null, "CEO");
            //EmpDTO dto = new EmpDTO();
            //dto.Name = "Eu";
            //dto.ManagerNodeText = null;
            var empId = await empService.AddEmployee(dto);

            //Act add employee level 1
            var dto1 = TestData.GetEmpDTO(1, "Eu", "CTO");
            var empId1 = await empService.AddEmployee(dto1);

            //Act add employee level 1
            var dto2 = TestData.GetEmpDTO(2, "mama", "Manager");
            var empId2 = await empService.AddEmployee(dto2);


            //await empService.DeleteEmployee(empId2);
            //await empService.DeleteEmployee(empId1);
            //await empService.DeleteEmployee(empId);

            //await orgService.DeleteNode(funcId3);
            //await orgService.DeleteNode(funcId1);
            //await orgService.DeleteNode(funcId2);

            //await orgService.DeleteNode(actId);
            //await orgService.DeleteNode(deptId);
            //await orgService.DeleteNode(orgId);

        }

        [Fact]
        public async Task UpdateEmployee_Unit_Should_Be_OK()
        {
            //Arrange
            var orgId = await CommonHelper.AddEntityNode("Con");
            var deptId = await CommonHelper.AddEntityNode("Business", orgId, "Con");
            var actId = await CommonHelper.AddEntityNode("Mgmt", deptId, "Business");
            var funcId = await CommonHelper.AddEntityNode("CEO", actId, "Mgmt");


            var dto = TestData.GetEmpDTO(0);
            var empId = await empService.AddEmployee(dto);
            var empNode = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 0).FirstOrDefaultAsync();
            new EmpValidator().ValidateAndThrow(empNode!);
            empNode!.Name = "ChangedName";
            empNode.Location = "Location";
            empNode.Surname = "SurName";
            var empDTO = mapper.Map<EmpDTO>(empNode);
            empDTO.EmpNodeText = empId;
            await empService.UpdateEmployee(empDTO);
            await empService.DeleteEmployee(empId);
            await orgService.DeleteNode(funcId);
            await orgService.DeleteNode(actId);
            await orgService.DeleteNode(deptId);
            await orgService.DeleteNode(orgId);
        }


        [Fact]
        public async void DeleteEmployee_Unit_Should_Be_OK()
        {
            //Arrange
            var dto = TestData.GetEmpDTO(0);
            var empId = await empService.AddEmployee(dto);
            var dto1 = TestData.GetEmpDTO(0);
            var empId1 = await empService.AddEmployee(dto1);
            var dto2 = TestData.GetEmpDTO(0);
            var empId2 = await empService.AddEmployee(dto2);

            //Act
            //Assert -- delete level 2
            var empList = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 2).ToListAsync();
            //Assert -- delete level 1
            var empList1 = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 1).ToListAsync();
            //delete root
            empService.DeleteEmployee(empId);

            //Assert
            await DeleteActAssert(empList);
            await DeleteActAssert(empList1);
            var root = DBContext.Employees.Where(e => e.EmpNode.ToString() == empId).FirstOrDefault();
            root.Should().BeNull();
        }

        private async Task DeleteActAssert(List<Employee> list)
        {
            foreach (var node in list)
            {
                await empService.DeleteEmployee(node.EmpNode.ToString());
                //Assert
                var func = DBContext.Employees.Where(e => e.EmpNode == node.EmpNode).FirstOrDefault();
                //
                func.Should().BeNull();
            }
        }

    }
}
