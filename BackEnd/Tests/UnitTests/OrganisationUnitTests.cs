
using CommonTestHelper;
using Contracts.Models;
using Contracts.Validation;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using static CommonTestHelper.CommonHelper;

namespace UnitTests
{
    [Collection("Sequential")]
    public class OrganisationUnitTests : BaseUnitTest
    {
        public OrganisationUnitTests() : base()
        {
        }

        //root
        [Fact]
        public async Task AddOrganization_Unit_Should_Be_OK()
        {
            string? orgId = null;
            try
            {
                orgId = await AddEntityNode("Con");
            } finally
            {
                await orgService.DeleteNode(orgId);
            }
        }

        [Fact]
        public async Task UpdateOrganization_Unit_Should_Be_OK()
        {
            string? orgId = null;
            try
            {
                //Arrange
                orgId = await AddEntityNode("Con");
                var Node = await DBContext.Organisations.Where(e => e.Node.GetLevel() == 0).FirstOrDefaultAsync();
                new OrgValidator().ValidateAndThrow(Node!);
                Node!.Name = "ChangedName";
                Node.Location = "Location";
                var orgDTO = mapper.Map<OrgDTO>(Node);
                orgDTO.NodeAsText = orgId;
                //Act
                await orgService.UpdateNode(orgDTO);
                var node = await DBContext.Organisations.Where(e => String.Equals(e.Name.ToUpper(), Node.Name.ToUpper())).FirstOrDefaultAsync();
                //Assert
                Assert.Equal(node.Name, Node!.Name);
            } finally
            {
                await orgService.DeleteNode(orgId);
            }
        }

        //level 1
        [Fact]
        public async Task AddDepartments_Should_Be_OK()
        {
            //Arrange
            var orgId = await CommonHelper.AddEntityNode("Con");

            //Act add department
            string deptId1 = string.Empty;
            string deptId2 = string.Empty;
            string deptId3 = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        deptId1 = await CommonHelper.AddEntityNode("HR", orgId, "Con");
                        deptId1.Should().NotBeNull();
                        break;
                    case 1:
                        deptId2 = await CommonHelper.AddEntityNode("Fin", orgId, "Con");
                        deptId2.Should().NotBeNull();
                        break;
                    case 2:
                        deptId3 = await CommonHelper.AddEntityNode("Eng", orgId, "Con");
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
            string orgId, deptId, actId1, actId2;
            orgId = string.Empty;
            deptId = string.Empty;
            actId1 = string.Empty;
            actId2 = string.Empty;
            try
            {
                orgId = await AddEntityNode("Con");
                deptId = await AddEntityNode("Eng", orgId, "Con");

                //Act add Activity
                OrgDTO dto = new OrgDTO();

                for (int i = 0; i < 2; i++)
                {
                    switch (i)
                    {
                        case 0:
                            actId1 = await AddEntityNode("R&D", deptId, "Eng");
                            actId1.Should().NotBeNull();
                            break;
                        case 1:
                            actId2 = await AddEntityNode("IT", deptId, "Eng");
                            actId2.Should().NotBeNull();
                            break;
                    }
                }
            } finally
            {
                await orgService.DeleteNode(actId1);
                await DeleteActDeptOrg(actId2, deptId, orgId);
            }
        }


        //level 2
        [Fact]// Ignore("work in progress")]
        public async Task AddWorkTypes_Should_Be_OK()
        {
            var orgId = await AddEntityNode("Con");
            var deptId = await AddEntityNode("Eng", orgId, "Con");
            var actId = await AddEntityNode("IT", deptId);


            //Act add SUBActivity
            OrgDTO dto = new OrgDTO();
            string workTypeId1 = string.Empty;
            string workTypeId2 = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        workTypeId1 = await AddEntityNode("PazaR&D", actId, "IT");
                        workTypeId1.Should().NotBeNull();
                        break;
                    case 1:
                        workTypeId2 = await AddEntityNode("PazaIT", actId, "IT");
                        workTypeId2.Should().NotBeNull();
                        break;
                }
            }
            await orgService.DeleteNode(workTypeId1);
            await orgService.DeleteNode(workTypeId2);
            await DeleteActDeptOrg(actId, deptId, orgId);
        }

        //level 3
        [Fact]
        public async Task AddFunctions_Should_Be_OK()
        {
            //Arrange
            var orgId = await AddEntityNode("Con");
            var deptId = await AddEntityNode("Eng", orgId);
            var actId = await AddEntityNode("IT", deptId);
            var workTypeId = await AddEntityNode("PazaIT", actId);

            //Act add Function
            string fnId1 = string.Empty;
            string fnId2 = string.Empty;
            string fnId3 = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        fnId1 = await AddEntityNode("SoftwareDeveloper", workTypeId, "PazaIT");
                        fnId1.Should().NotBeNull();
                        break;
                    case 1:
                        fnId2 = await AddEntityNode("QA", workTypeId, "PazaIT");
                        fnId2.Should().NotBeNull();
                        break;
                    case 2:
                        fnId3 = await AddEntityNode("BuildEngineer", workTypeId, "PazaIT");
                        fnId3.Should().NotBeNull();
                        break;
                }

            }
            await orgService.DeleteNode(fnId1);
            await orgService.DeleteNode(fnId2);
            await DeleteFuncWorkType(fnId3, workTypeId);
            await DeleteActDeptOrg(actId, deptId, orgId);
        }

        [Fact]
        public async void DeleteOrganization_Unit_Should_Be_OK()
        {
            var orgId = await AddEntityNode("Con");
            var orgList = await DBContext.Organisations.Where(e => e.Node.GetLevel() == 0).ToListAsync();
            //Arrange
            await DeleteActAssert(orgList);
        }

        private async Task DeleteActAssert(List<Organisation> list)
        {
            foreach (var node in list)
            {
                await orgService.DeleteNode(node.Node.ToString());
                //Assert
                var func = await DBContext.Organisations.Where(e => e.Node == node.Node).FirstOrDefaultAsync();
                //
                func.Should().BeNull();
            }
        }

        private async Task DeleteFuncWorkType(string funcId,
                                                string workTypeId)
        {
            await orgService.DeleteNode(funcId);
            await orgService.DeleteNode(workTypeId);
            //await orgService.DeleteNode(actId);
        }

        private async Task DeleteActDeptOrg(string actId, string deptId, string orgId)
        {
            await orgService.DeleteNode(actId);
            await orgService.DeleteNode(deptId);
            await orgService.DeleteNode(orgId);
        }


    }
}
