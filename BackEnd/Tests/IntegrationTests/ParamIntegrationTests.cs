using Contracts.Models;
using Newtonsoft.Json;
using System.Text;
using Xunit;

namespace IntegrationTests
{


    public class ParamsControllerTests : BaseIntegrationTest
    {

        [Fact]
        public async Task GetParams_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await httpClient.GetAsync("/api/params");
            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GetParam_ReturnsParam()
        {
            // Arrange
            var param = new Param
            {
                Id = 1,
                ProcessingDate = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/api/params", content);
            // Act
            var response = await httpClient.GetAsync("/api/params/1");
            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var returnedParam = JsonConvert.DeserializeObject<Param>(responseString);
            //11 / 14 / 24, 6:42 PM Microsoft Copilot: Your AI companion
            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 1/3
            Xunit.Assert.Equal(param.Id, returnedParam.Id);
        }
        [Fact]
        public async Task AddParam_ReturnsSuccessStatusCode()
        {
            // Arrange
            var param = new Param
            {
                Id = 1,
                ProcessingDate = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            // Act
            var response = await httpClient.PostAsync("/api/params", content);
            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task UpdateParam_ReturnsSuccessStatusCode()
        {
            // Arrange
            var param = new Param
            {
                Id = 1,
                ProcessingDate = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/api/params", content);
            param.AdvancePercentRate = 50;
            var updateContent = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            // Act
            var response = await httpClient.PutAsync("/api/params/1", updateContent);
            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task DeleteParam_ReturnsSuccessStatusCode()
        {
            // Arrange
            var param = new Param
            {
                Id = 1,
                ProcessingDate = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/api/params", content);
            //11 / 14 / 24, 6:42 PM Microsoft Copilot: Your AI companion
            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 2/3
            // Act
            var response = await httpClient.DeleteAsync("/api/params/1");
            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
