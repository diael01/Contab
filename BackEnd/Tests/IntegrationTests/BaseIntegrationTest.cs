namespace IntegrationTests
{
    public abstract class BaseIntegrationTest : CustomWebApplicationFactory<Program>
    {
        protected readonly CustomWebApplicationFactory<Program> factory;
        protected readonly HttpClient httpClient;
        protected HttpResponseMessage? health;
        public BaseIntegrationTest()
        {
            factory = new CustomWebApplicationFactory<Program>();
            httpClient = factory.CreateClient();
        }
    }
}
