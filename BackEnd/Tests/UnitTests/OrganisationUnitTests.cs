
using CommonTestHelper;
using Contracts.Models;
using Contracts.Validation;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
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
            var orgId = await AddEntityNode("Con");
            await orgService.DeleteNode(orgId);
        }

        [Fact]
        public async Task UpdateOrganization_Unit_Should_Be_OK()
        {
            //Arrange
            var orgId = await AddEntityNode("Con");
            var Node = await DBContext.Organisations.Where(e => e.Node.GetLevel() == 0).FirstOrDefaultAsync();
            new OrgValidator().ValidateAndThrow(Node!);
            Node!.Name = "ChangedName";
            Node.Location = "Location";
            Node.Surname = "Surname";
            var orgDTO = mapper.Map<OrgDTO>(Node);
            orgDTO.NodeAsText = orgId;
            //Act
            await orgService.UpdateNode(orgDTO);
            var node = await DBContext.Organisations.Where(e => String.Equals(e.Name.ToUpper(), Node.Name.ToUpper())).FirstOrDefaultAsync();
            //Assert
            Assert.Equal(node.Name, Node!.Name);
            await orgService.DeleteNode(orgId);
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
            var orgId = await AddEntityNode("Con");
            var deptId = await AddEntityNode("Eng", orgId, "Con");

            //Act add Activity
            OrgDTO dto = new OrgDTO();
            string actId1 = string.Empty;
            string actId2 = string.Empty;
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
            var orgId = await AddEntityNode("Con");
            var deptId = await AddEntityNode("Eng", orgId);
            var actId = await AddEntityNode("IT", deptId);

            //Act add Function
            string fnId1 = string.Empty;
            string fnId2 = string.Empty;
            string fnId3 = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        fnId1 = await AddEntityNode("SoftwareDeveloper", actId, "IT");
                        fnId1.Should().NotBeNull();
                        break;
                    case 1:
                        fnId2 = await AddEntityNode("QA", actId, "IT");
                        fnId2.Should().NotBeNull();
                        break;
                    case 2:
                        fnId3 = await AddEntityNode("BuildEngineer", actId, "IT");
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


    }
}
