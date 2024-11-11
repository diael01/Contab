using Xunit;

namespace IntegrationTests
{
    public class BanksControllerTests : BaseIntegrationTest
    {

        [Fact]
        public async Task GetBanks_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await httpClient.GetAsync("/api/banks");
            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
