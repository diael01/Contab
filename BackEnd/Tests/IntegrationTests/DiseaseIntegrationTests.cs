using Newtonsoft.Json;
using Repository.Models;
using System.Text;
using Xunit;

namespace IntegrationTests
{
    public class DiseasesControllerTests : BaseIntegrationTest
    {

        [Fact]
        public async Task GetDiseases_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await httpClient.GetAsync("/api/diseases");
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetDisease_ReturnsDisease()
        {
            // Arrange
            var disease = new Disease
            {
                Id = 1,
                CodeDisease = 1001,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(disease), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/api/diseases", content);
            // Act
            var response = await httpClient.GetAsync("/api/diseases/1");
            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var returnedDisease = JsonConvert.DeserializeObject<Disease>(responseString);
            Xunit.Assert.Equal(disease.Id, returnedDisease.Id);
        }

        //11/13/24, 11:24 AM Microsoft Copilot: Your AI companion
        //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 1/3
        [Fact]
        public async Task AddDisease_ReturnsSuccessStatusCode()
        {
            // Arrange
            var disease = new Disease
            {
                Id = 1,
                CodeDisease = 1001,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(disease), Encoding.UTF8, "application/json");
            // Act
            var response = await httpClient.PostAsync("/api/diseases", content);
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateDisease_ReturnsSuccessStatusCode()
        {
            // Arrange
            var disease = new Disease
            {
                Id = 1,
                CodeDisease = 1001,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(disease), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/api/diseases", content);
            disease.CodeDisease = 1002;
            var updateContent = new StringContent(JsonConvert.SerializeObject(disease), Encoding.UTF8, "application/json");
            // Act
            var response = await httpClient.PutAsync("/api/diseases/1", updateContent);
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteDisease_ReturnsSuccessStatusCode()
        {
            // Arrange
            var disease = new Disease
            {
                Id = 1,
                CodeDisease = 1001,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(disease), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/api/diseases", content);
            // Act
            var response = await httpClient.DeleteAsync("/api/diseases/1");
            //11 / 13 / 24, 11:24 AM Microsoft Copilot: Your AI companion
            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 2/3
            // Assert
            response.EnsureSuccessStatusCode();
        }
    }

}
