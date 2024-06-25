using FluentAssertions;
using System.Net;

namespace IntegrationTests
{
  [TestClass]
  public class HealthIntegrationTest : BaseIntegrationTest
  {
    [TestMethod]
    public async Task GetHealth_Integration_Should_Return_OK()
    {
      // Arrange - in base test     

      // Act
      health = await client.GetAsync("/api/health/GetHealth");

      //Assert
      health.Should().NotBeNull();
      health.StatusCode.Should().Be(HttpStatusCode.OK);
      health.Content.Should().NotBeNull();

    }

    [TestMethod]
    public async Task GetHealthThrowException_Should_Fail()
    {
      try
      {
        health = await client.GetAsync("/api/health/GetHealthThrowException");
      } catch
      {
        health.Should().NotBeNull();
        health!.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        health.Content.Should().NotBeNull();
        health.Content.Should().Be(Constants.VissionRMMError);
      }
    }
  }
}


