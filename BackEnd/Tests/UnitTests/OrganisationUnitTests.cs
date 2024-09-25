
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Services;
using CommonTestHelper;

namespace UnitTests
{

    public class OrganisationUnitTests : BaseUnitTest
    {

        IOrgService orgService;
        public OrganisationUnitTests() : base()
        {
            orgService = CommonHelper.orgService = new OrgService(DBContext, mapper);
        }
        //root
        [Fact]
        public async Task AddOrganization_Unit_Should_Be_OK()
        {

            var orgId = await CommonHelper.AddOrg();
            await orgService.DeleteNode(orgId);
        }

        [Fact]
        public async Task UpdateOrganization_Unit_Should_Be_OK()
        {

            var orgId = await CommonHelper.AddOrg();
            var orgNode = await DBContext.Organisations.Where(e => e.OrgNode.GetLevel() == 0).FirstOrDefaultAsync();
            new OrgValidator().ValidateAndThrow(orgNode!);
            orgNode!.Name = "ChangedName";
            orgNode.Location = "Location";
            orgNode.Surname = "Surname";
            var orgDTO = mapper.Map<OrgDTO>(orgNode);
            orgDTO.OrgNodeText = orgId;
            await orgService.UpdateNode(orgDTO);
            await orgService.DeleteNode(orgId);
        }

        //level 1
        [Fact]
        public async Task AddDepartments_Should_Be_OK()
        {
            //Arrange
            var orgId = await CommonHelper.AddOrg();

            //Act add department
            string deptId1 = string.Empty;
            string deptId2 = string.Empty;
            string deptId3 = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        deptId1 = await CommonHelper.AddDept(orgId, "HumanResources");
                        deptId1.Should().NotBeNull();
                        break;
                    case 1:
                        deptId2 = await CommonHelper.AddDept(orgId, "Finance");
                        deptId2.Should().NotBeNull();
                        break;
                    case 2:
                        deptId3 = await CommonHelper.AddDept(orgId, "Engineering");
                        deptId3.Should().NotBeNull();
                        break;
                }
            }
            await orgService.DeleteNode(deptId1);
            await orgService.DeleteNode(deptId2);
            await orgService.DeleteNode(deptId3);
            await orgService.DeleteNode(orgId);
        }

        //level 2
        [Fact]
        public async Task AddActivities_Should_Be_OK()
        {
            var orgId = await CommonHelper.AddOrg();
            var deptId = await CommonHelper.AddDept(orgId, "Engineering");

            //Act add Activity
            OrgDTO dto = new OrgDTO();
            string actId1 = string.Empty;
            string actId2 = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        actId1 = await CommonHelper.AddActivity(deptId, "R&D");
                        actId1.Should().NotBeNull();
                        break;
                    case 1:
                        actId2 = await CommonHelper.AddActivity(deptId, "IT");
                        actId2.Should().NotBeNull();
                        break;
                }


            }
            await orgService.DeleteNode(actId1);
            await orgService.DeleteNode(actId2);
            await orgService.DeleteNode(deptId);
            await orgService.DeleteNode(orgId);
        }

        //level 3
        [Fact]
        public async Task AddFunctions_Should_Be_OK()
        {
            //Arrange
            var orgId = await CommonHelper.AddOrg();
            var deptId = await CommonHelper.AddDept(orgId, "Engineering");
            var actId = await CommonHelper.AddActivity(deptId, "IT");

            //Act add Function
            string fnId1 = string.Empty;
            string fnId2 = string.Empty;
            string fnId3 = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        fnId1 = await CommonHelper.AddFunction(actId, "SoftwareDeveloper");
                        fnId1.Should().NotBeNull();
                        break;
                    case 1:
                        fnId2 = await CommonHelper.AddFunction(actId, "QA");
                        fnId2.Should().NotBeNull();
                        break;
                    case 2:
                        fnId3 = await CommonHelper.AddFunction(actId, "BuildEngineer");
                        fnId3.Should().NotBeNull();
                        break;
                }

            }
            await orgService.DeleteNode(fnId1);
            await orgService.DeleteNode(fnId2);
            await orgService.DeleteNode(fnId3);
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

     
    }
}
