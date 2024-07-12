namespace CleanArchitecture.IntegrationTests;

public class CustomerControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly HttpClient _httpClient;

    public CustomerControllerIntegrationTests(TestingWebAppFactory<Program> factory) => _httpClient = factory.CreateClient();

    [Fact]
    public async Task Get_WhenCalled_ReturnsCustomerList()
    {
        var response = await _httpClient.GetAsync("api/Customer");

        var responseAsString = await response.Content.ReadAsStringAsync();

    }
}
