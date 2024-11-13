using Newtonsoft.Json;
using Repository.Models;
using System.Text;
using Xunit;

namespace IntegrationTests
{
    public class HolidaysControllerTests : BaseIntegrationTest
    {
        [Fact]
        public async Task GetHolidays_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await httpClient.GetAsync("/api/holidays");
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetHoliday_ReturnsHoliday()
        {
            // Arrange
            var holiday = new Holiday
            {
                Id = 1,
                VacationStartDate = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(holiday), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/api/holidays", content);
            // Act
            var response = await httpClient.GetAsync("/api/holidays/1");
            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var returnedHoliday = JsonConvert.DeserializeObject<Holiday>(responseString);
            Xunit.Assert.Equal(holiday.Id, returnedHoliday.Id);
            //11 / 13 / 24, 12:48 PM Microsoft Copilot: Your AI companion
            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 1/3
        }

        [Fact]
        public async Task AddHoliday_ReturnsSuccessStatusCode()
        {
            // Arrange
            var holiday = new Holiday
            {
                Id = 1,
                VacationStartDate = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(holiday), Encoding.UTF8, "application/json");
            // Act
            var response = await httpClient.PostAsync("/api/holidays", content);
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateHoliday_ReturnsSuccessStatusCode()
        {
            // Arrange
            var holiday = new Holiday
            {
                Id = 1,
                VacationStartDate = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(holiday), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/api/holidays", content);
            holiday.VacationStartDay = 15;
            var updateContent = new StringContent(JsonConvert.SerializeObject(holiday), Encoding.UTF8, "application/json");
            // Act
            var response = await httpClient.PutAsync("/api/holidays/1", updateContent);
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteHoliday_ReturnsSuccessStatusCode()
        {
            // Arrange
            var holiday = new Holiday
            {
                Id = 1,
                VacationStartDate = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow
            };
            var content = new StringContent(JsonConvert.SerializeObject(holiday), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/api/holidays", content);
            // Act
            //11 / 13 / 24, 12:48 PM Microsoft Copilot: Your AI companion
            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 2/3
            var response = await httpClient.DeleteAsync("/api/holidays/1");
            // Assert
            response.EnsureSuccessStatusCode();
        }
    }

}
