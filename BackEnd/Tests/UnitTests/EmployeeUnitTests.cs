
using CommonTestHelper;
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentAssertions;
using FluentAssertions.Equivalency;
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
            var orgId = await CommonHelper.AddOrg();
            var deptId = await CommonHelper.AddDept(orgId, "Engineering");
            var actId = await CommonHelper.AddActivity(deptId, "IT");

            var dto = TestData.GetEmpDTO(0);
            //EmpDTO dto = new EmpDTO();
            //dto.Name = "Eu";
            //dto.ManagerNodeText = null;
            var empId1 = await empService.AddEmployee(dto);

            //Act add employee level 1
            dto.Name = "mama1";
            dto.ManagerNodeText = "/";// my sub 1
            var empId2 = await empService.AddEmployee(dto);

            //Act add employee level 1
            dto.Name = "mama11";
            dto.ManagerNodeText = "/"; // my sub 2
            var empId3 = await empService.AddEmployee(dto);

            //Act add employee level 2
            dto.Name = "vili2";
            dto.ManagerNodeText = "/1"; // mama1 sub 1
            var empId4 = await empService.AddEmployee(dto);

            //Act add employee level 2
            dto.Name = "vili22";
            dto.ManagerNodeText = "/1";//mama1 sub 2
            var empId5 = await empService.AddEmployee(dto);

            //Act add employee level 2
            dto.Name = "vili23";        //mama11 sub 1
            dto.ManagerNodeText = "/2";
            var empId6 = await empService.AddEmployee(dto);

            await empService.DeleteEmployee(empId6);
            await empService.DeleteEmployee(empId5);
            await empService.DeleteEmployee(empId4);

            await empService.DeleteEmployee(empId3);
            await empService.DeleteEmployee(empId2);
            await empService.DeleteEmployee(empId1);
        }

        [Fact]
        public async Task UpdateEmployee_Unit_Should_Be_OK()
        {
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
            //Assert
            var empList = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 2).ToListAsync();
            await DeleteActAssert(empList);
            //Assert
            empList = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == 1).ToListAsync();

            await DeleteActAssert(empList);
            empService.DeleteEmployee(empId);

            //Assert
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
