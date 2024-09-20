
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Models.Enums;
using Contracts.Validation;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Services;
using System;

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

        [Fact]
        public async Task UpdateOrganization_Unit_Should_Be_OK()
        {

            var orgId = await AddOrg();
            var orgNode = await DBContext.Organisations.Where(e => e.OrgNode.GetLevel() == 0).FirstOrDefaultAsync();
            new OrgValidator().ValidateAndThrow(orgNode!);
            orgNode!.Name = "ChangedName";
            orgNode.Location = "Location";
            orgNode.LongName = "LongName";
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
            var orgId = await AddOrg();

            //Act add department
            string deptId1 = string.Empty;
            string deptId2 = string.Empty;
            string deptId3 = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        deptId1 = await AddDept(orgId, "HumanResources");
                        deptId1.Should().NotBeNull();
                        break;
                    case 1:
                        deptId2 = await AddDept(orgId, "Finance");
                        deptId2.Should().NotBeNull();
                        break;
                    case 2:
                        deptId3 = await AddDept(orgId, "Engineering");
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
            var orgId = await AddOrg();
            var deptId = await AddDept(orgId, "Engineering");

            //Act add Activity
            OrgDTO dto = new OrgDTO();
            string actId1 = string.Empty;
            string actId2 = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        actId1 = await AddActivity(deptId, "R&D");
                        actId1.Should().NotBeNull();
                        break;
                    case 1:
                        actId2 = await AddActivity(deptId, "IT");
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
            var orgId = await AddOrg();
            var deptId = await AddDept(orgId, "Engineering");
            var actId = await AddActivity(deptId, "IT");

            //Act add Function
            string fnId1 = string.Empty;
            string fnId2 = string.Empty;
            string fnId3 = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        fnId1 = await AddFunction(actId, "SoftwareDeveloper");
                        fnId1.Should().NotBeNull();
                        break;
                    case 1:
                        fnId2 = await AddFunction(actId, "QA");
                        fnId2.Should().NotBeNull();
                        break;
                    case 2:
                        fnId3 = await AddFunction(actId, "BuildEngineer");
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

        private async Task<string> AddDept(string orgId, string name)
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            dto.ParentNodeText = orgId;

            //Act add company
            return (await orgService.AddNode(dto)).ToString();
        }

        private async Task<string> AddOrg()
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = "Construct";

            //Act add company
            return (await orgService.AddNode(dto)).ToString();
        }

        private async Task<string> AddActivity(string deptId, string name)
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            dto.ParentNodeText = deptId;

            //Act add activity
            return (await orgService.AddNode(dto)).ToString();
        }

        private async Task<string> AddFunction(string actId, string name)
        {
            //Arrange
            OrgDTO dto = new OrgDTO();
            dto.Name = name;
            dto.ParentNodeText = actId;

            //Act add function
            return (await orgService.AddNode(dto)).ToString();
        }
    }
}
