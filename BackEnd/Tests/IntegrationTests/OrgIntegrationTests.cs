using CommonTestHelper;
using Contracts.Models;
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using Xunit;
using static CommonTestHelper.CommonHelper;

namespace IntegrationTests
{
    [TestClass]
    [Collection("Sequential")]
    public class OrgIntegrationTests : BaseIntegrationTest
    {
        [TestMethod]
        public async Task GetNodes_Integration_Should_Return_OK()
        {
            // Arrange - in base test
            var content = JsonContent.Create(TestData.GetOrgDTO(0));
            var comp = await httpClient.PostAsync("/api/v1/Org/AddNode", content);
            comp.Should().NotBeNull();
            comp.StatusCode.Should().Be(HttpStatusCode.OK);
            content = JsonContent.Create(TestData.GetOrgDTO(1, await comp.Content.ReadAsStringAsync()));
            var dept = await httpClient.PostAsync("/api/v1/Org/AddNode", content);
            dept.Should().NotBeNull();
            dept.StatusCode.Should().Be(HttpStatusCode.OK);
            content = JsonContent.Create(TestData.GetOrgDTO(2, await dept.Content.ReadAsStringAsync()));
            var act = await httpClient.PostAsync("/api/v1/Org/AddNode", content);
            act.Should().NotBeNull();
            act.StatusCode.Should().Be(HttpStatusCode.OK);
            content = JsonContent.Create(TestData.GetOrgDTO(3, await act.Content.ReadAsStringAsync()));
            var fnc = await httpClient.PostAsync("/api/v1/Org/AddNode", content);
            fnc.Should().NotBeNull();
            fnc.StatusCode.Should().Be(HttpStatusCode.OK);
            // Act      
            using (HttpResponseMessage response = await httpClient.GetAsync("/api/v1/Org/GetOrganisations"))
            {
                await CheckResponse(response);
            }
            using (HttpResponseMessage response = await httpClient.GetAsync("/api/v1/Org/GetDepartments"))
            {
                await CheckResponse(response);
            }
            using (HttpResponseMessage response = await httpClient.GetAsync("/api/v1/Org/GetActivities"))
            {
                await CheckResponse(response);
            }
            using (HttpResponseMessage response = await httpClient.GetAsync("/api/v1/Org/GetFunctions"))
            {
                CheckResponse(response);
            }
            //cleanup
            await DeleteNode(httpClient, new Dictionary<string, string>
            {
                ["node"] = await fnc.Content.ReadAsStringAsync()
            });
            await DeleteNode(httpClient, new Dictionary<string, string>
            {
                ["node"] = await act.Content.ReadAsStringAsync()
            });
            await DeleteNode(httpClient, new Dictionary<string, string>
            {
                ["node"] = await dept.Content.ReadAsStringAsync()
            });
            await DeleteNode(httpClient, new Dictionary<string, string>
            {
                ["node"] = await comp.Content.ReadAsStringAsync()
            });
        }


        [TestMethod]
        public async Task AddOrg_Integration_Should_Return_OK()
        {
            // Arrange             
            var content = JsonContent.Create(TestData.GetOrgDTO(0));

            // Act          
            var add = await httpClient.PostAsync("/api/v1/Org/AddNode", content);

            //Assert
            add.Should().NotBeNull();
            add.StatusCode.Should().Be(HttpStatusCode.OK);

            var hNode = await add.Content.ReadAsStringAsync();
            //var id = add.Content.ReadAsString();
            // Remove the object to leave the DB in the same state  
            await DeleteNode(httpClient, new Dictionary<string, string>
            {
                ["node"] = hNode
            });
        }


        [TestMethod]
        public async Task UpdateOrg_Integration_Should_Return_OK()
        {
            // Arrange
            var org = TestData.GetOrgDTO(0);
            var content = JsonContent.Create(org);
            var add = await httpClient.PostAsync("/api/v1/Org/AddNode", content);
            add.Should().NotBeNull();
            add.StatusCode.Should().Be(HttpStatusCode.OK);
            org.NodeName = "TestDataNameUpdate";
            org.NodeText = await add.Content.ReadAsStringAsync();
            content = JsonContent.Create(org);

            // Act
            var update = await httpClient.PutAsync("/api/v1/Org/UpdateNode", content);
            //Assert
            update.Should().NotBeNull();
            update.StatusCode.Should().Be(HttpStatusCode.OK);

            //get again the Org from DB
            var query = new Dictionary<string, string>
            {
                ["node"] = await update.Content.ReadAsStringAsync()
            };

            // Act
            var node = await httpClient.GetAsync(QueryHelpers.AddQueryString("/api/v1/Org/GetNodeById", query!));
            string contentString = await node.Content.ReadAsStringAsync();
            var orgres = JsonConvert.DeserializeObject<OrgDTO>(contentString);
            orgres.Should().NotBeNull();
            orgres!.NodeName.Should().Be(org.NodeName);

            // Remove the object to leave the DB in the same state  
            query = new Dictionary<string, string> { ["node"] = orgres.NodeText! };
            await DeleteNode(httpClient, query);
        }

    }
}
