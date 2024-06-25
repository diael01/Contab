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
  public class ClientIntegrationTest : BaseIntegrationTest
  {

    [TestMethod]
    public async Task GetClients_Integration_Should_Return_OK()
    {
      // Arrange - in base test     
      // Act      
      using (HttpResponseMessage response = await client.GetAsync("/api/v1/client/GetClients"))
      {
        //Assert
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        using (HttpContent content = response.Content)
        {
          string contentString = await content.ReadAsStringAsync();
          var cli = JsonConvert.DeserializeObject<ClientDTO[]>(contentString);
          cli.Should().NotBeNull();
        }
      }
    }

    [TestMethod]
    public async Task GetClientByID_Integration_Should_Return_OK()
    {
      // Arrange
      var content = JsonContent.Create(TestData.GetClientDTO());
      var add = await client.PostAsync("/api/v1/client/AddClient", content);
      add.Should().NotBeNull();
      add.StatusCode.Should().Be(HttpStatusCode.OK);
      var clidi = await add.Content.ReadAsStringAsync();
      var query = new Dictionary<string, string>
      {
        ["id"] = clidi
      };

      // Act
      var customer = await client.GetAsync(QueryHelpers.AddQueryString("/api/v1/client/GetClientById", query!));
      //Assert
      customer.Should().NotBeNull();
      customer.StatusCode.Should().Be(HttpStatusCode.OK);
      string contentString = await customer.Content.ReadAsStringAsync();
      var clires = JsonConvert.DeserializeObject<ClientDTO>(contentString);
      clires.Should().NotBeNull();
      clires!.Id.ToString().Should().Be(clidi);

      //remove
      query = new Dictionary<string, string> { ["id"] = clidi };
      ClientHelper.DeleteClient(client, query);
    }

    [TestMethod]
    public async Task AddClient_Integration_Should_Return_OK()
    {
      // Arrange             
      var content = JsonContent.Create(TestData.GetClientDTO());

      // Act          
      var add = await client.PostAsync("/api/v1/client/AddClient", content);

      //Assert
      add.Should().NotBeNull();
      add.StatusCode.Should().Be(HttpStatusCode.OK);

      // Remove the object to leave the DB in the same state  
      ClientHelper.DeleteClient(client, new Dictionary<string, string>
      {
        ["id"] = await add.Content.ReadAsStringAsync()
      });
    }


    [TestMethod]
    public async Task UpdateClient_Integration_Should_Return_OK()
    {
      // Arrange
      var cl1 = TestData.GetClientDTO();
      var content = JsonContent.Create(cl1);
      var add = await client.PostAsync("/api/v1/client/AddClient", content);
      add.Should().NotBeNull();
      add.StatusCode.Should().Be(HttpStatusCode.OK);
      cl1.Name = "TestDataNameUpdate";
      cl1.Ip = "IpUpdate";
      content = JsonContent.Create(cl1);

      // Act
      var update = await client.PutAsync("/api/v1/client/UpdateClient", content);
      //Assert
      update.Should().NotBeNull();
      update.StatusCode.Should().Be(HttpStatusCode.OK);

      //get again the client from DB
      var query = new Dictionary<string, string>
      {
        ["id"] = await update.Content.ReadAsStringAsync()
      };

      // Act
      var customer = await client.GetAsync(QueryHelpers.AddQueryString("/api/v1/client/GetClientById", query!));
      string contentString = await customer.Content.ReadAsStringAsync();
      var clires = JsonConvert.DeserializeObject<ClientDTO>(contentString);
      clires.Should().NotBeNull();
      clires!.Name.Should().Be(cl1.Name);

      // Remove the object to leave the DB in the same state  
      query = new Dictionary<string, string> { ["id"] = await add.Content.ReadAsStringAsync() };
      ClientHelper.DeleteClient(client, query);
    }

  }
}
