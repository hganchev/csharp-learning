namespace AdvancedConcepts.DependencyInjection;

// HTTP Client Factory
public interface IHttpClientFactory
{
    HttpClient CreateClient();
}

public class HttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateClient() => new HttpClient();
}
