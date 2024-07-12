using CommonTestHelper;
using Contracts.Models;
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTests
{
    [TestClass]
    public class OrgIntegrationTests : BaseIntegrationTest
    {

        [TestMethod]
        public async Task GetNodes_Integration_Should_Return_OK()
        {
            // Arrange - in base test     
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
                await CheckResponse(response);
            }
        }

        private async Task CheckResponse(HttpResponseMessage response)
        {
            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            using (HttpContent content = response.Content)
            {
                string contentString = await content.ReadAsStringAsync();
                var cli = JsonConvert.DeserializeObject<OrgDTO[]>(contentString);
                cli.Should().NotBeNull();
            }
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

            // Remove the object to leave the DB in the same state  
            OrgHelper.DeleteNode(httpClient, new Dictionary<string, string>
            {
                ["id"] = await add.Content.ReadAsStringAsync()
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
            org.Name = "TestDataNameUpdate";
            content = JsonContent.Create(org);

            // Act
            var update = await httpClient.PutAsync("/api/v1/Org/UpdateNode", content);
            //Assert
            update.Should().NotBeNull();
            update.StatusCode.Should().Be(HttpStatusCode.OK);

            //get again the Org from DB
            var query = new Dictionary<string, string>
            {
                ["id"] = await update.Content.ReadAsStringAsync()
            };

            // Act
            var customer = await httpClient.GetAsync(QueryHelpers.AddQueryString("/api/v1/Org/GetNodeById", query!));
            string contentString = await customer.Content.ReadAsStringAsync();
            var orgres = JsonConvert.DeserializeObject<OrgDTO>(contentString);
            orgres.Should().NotBeNull();
            orgres!.Name.Should().Be(org.Name);

            // Remove the object to leave the DB in the same state  
            query = new Dictionary<string, string> { ["id"] = await add.Content.ReadAsStringAsync() };
            OrgHelper.DeleteNode(httpClient, query);
        }

    }
}
