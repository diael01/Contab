namespace IntegrationTests
{
  public abstract class BaseIntegrationTest : CustomWebApplicationFactory<Program>
  {
    protected readonly CustomWebApplicationFactory<Program> factory;
    protected readonly HttpClient client;
    protected HttpResponseMessage? health;
    public BaseIntegrationTest()
    {
      factory = new CustomWebApplicationFactory<Program>();
      client = factory.CreateClient();
    }
  }
}
