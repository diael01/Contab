
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Models.Enums;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Services;

namespace UnitTests
{

    public class OrganisationUnitTest : BaseUnitTest
    {

        IOrgService orgService;
        public OrganisationUnitTest() : base()
        {
            orgService = new OrgService(DBContext, mapper);
        }
        //root
        [Fact]
        public async Task AddOrganization_Unit_Should_Be_OK()
        {

            var orgId = await AddOrg();
            await orgService.DeleteNode(orgId);
        }

        //level 1
        [Fact]
        public async Task AddDepartments_Should_Be_OK()
        {
            //Arrange
            var orgId = await AddOrg();

            //Act add department
            string deptId = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        deptId = await AddDept(orgId, "HumanResources");
                        break;
                    case 1:
                        deptId = await AddDept(orgId, "Finance");
                        break;
                    case 2:
                        deptId = await AddDept(orgId, "Engineering");
                        break;
                }
                deptId.Should().NotBeNull();
                await orgService.DeleteNode(deptId);
            }
            await orgService.DeleteNode(orgId);
        }

        //level 2
        [Fact]
        public async Task AddActivities_Should_Be_OK()
        {
            var orgId = await AddOrg();
            var deptId = await AddDept(orgId, "Engineering");

            //Act add Activity
            OrgDTO dto = new OrgDTO();
            string actId = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        actId = await AddActivity(deptId, "R&D");
                        break;
                    case 1:
                        actId = await AddActivity(deptId, "IT");
                        break;
                }
                actId.Should().NotBeNull();
                await orgService.DeleteNode(actId);
            }

            await orgService.DeleteNode(deptId);
            await orgService.DeleteNode(orgId);
        }

        //level 3
        [Fact]
        public async Task AddFunctions_Should_Be_OK()
        {
            //Arrange
            var orgId = await AddOrg();
            var deptId = await AddDept(orgId, "Engineering");
            var actId = await AddActivity(deptId, "IT");

            //Act add Function
            string fnId = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        fnId = await AddFunction(actId, "SoftwareDeveloper");
                        break;
                    case 1:
                        fnId = await AddFunction(actId, "QA");
                        break;
                    case 2:
                        fnId = await AddFunction(actId, "BuildEngineer");
                        break;
                }
                //Assert   
                fnId.Should().NotBeNull();
                await orgService.DeleteNode(fnId);
            }
            await orgService.DeleteNode(actId);
            await orgService.DeleteNode(deptId);
            await orgService.DeleteNode(orgId);
        }

        [Fact]
        public async void DeleteOrganization_Unit_Should_Be_OK()
        {
            var orgList = await DBContext.Organisations.Where(e => e.OrgNode.GetLevel() == 0).ToListAsync();
            //Arrange
            await DeleteActAssert(orgList);
        }

        [Fact]
        public async void DeleteFunctions_Unit_Should_Be_OK()
        {
            //Arrange
            var funcList = await DBContext.Organisations.Where(e => e.OrgNode.GetLevel() == 3).ToListAsync();

            //Act - delete function
            await DeleteActAssert(funcList);
        }

        [Fact]
        public async void DeleteActivities_Unit_Should_Be_OK()
        {
            //Arrange
            var actList = await DBContext.Organisations.Where(e => e.OrgNode.GetLevel() == 2).ToListAsync();

            //Act - delete activities
            await DeleteActAssert(actList);
        }

        [Fact]
        public async void DeleteDepartments_Unit_Should_Be_OK()
        {
            //Arrange
            var deptList = await DBContext.Organisations.Where(e => e.OrgNode.GetLevel() == 1).ToListAsync();

            //Act - delete dept
            await DeleteActAssert(deptList);
        }

        private async Task DeleteActAssert(List<Organisation> list)
        {
            foreach (var node in list)
            {
                await orgService.DeleteNode(node.OrgNode.ToString());
                //Assert
                var func = DBContext.Organisations.Where(e => e.OrgNode == node.OrgNode).FirstOrDefault();
                //
                func.Should().BeNull();
            }
        }

        private async Task<string> AddDept(string orgId, string name)
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            dto.Type = (int)OrganisationType.Department;
            dto.ParentNodeText = orgId;

            //Act add company
            return (await orgService.AddNode(dto)).ToString();
        }

        private async Task<string> AddOrg()
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = "Construct";
            dto.Type = (int)OrganisationType.Company;

            //Act add company
            return (await orgService.AddNode(dto)).ToString();
        }

        private async Task<string> AddActivity(string deptId, string name)
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            dto.Type = (int)OrganisationType.Activity;
            dto.ParentNodeText = deptId;

            //Act add activity
            return (await orgService.AddNode(dto)).ToString();
        }

        private async Task<string> AddFunction(string actId, string name)
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            dto.Type = (int)OrganisationType.Function;
            dto.ParentNodeText = actId;

            //Act add function
            return (await orgService.AddNode(dto)).ToString();
        }
    }
}
