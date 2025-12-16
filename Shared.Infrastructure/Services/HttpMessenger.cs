using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Shared.Infrastructure.Interfaces;

namespace Shared.Infrastructure.Services;

public class HttpMessenger : IMessenger
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpMessenger(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<TResponse?> GetAsync<TResponse>(string serviceName, string endpoint, CancellationToken ct = default)
    {
        var client = _httpClientFactory.CreateClient(serviceName);
        // Assuming serviceName is configured as the BaseAddress or named client in Program.cs
        // If using a Gateway or internal DNS, the URL construction might differ.
        // For now, we assume the client is pre-configured with the base URL.
        
        // If the client doesn't have a base address, we might need to construct it.
        // But cleaner is to rely on named clients having BaseAddress set.
        
        var response = await client.GetAsync(endpoint, ct);
        response.EnsureSuccessStatusCode();

        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            return default;

        return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: ct);
    }

    public async Task PostAsync<TRequest>(string serviceName, string endpoint, TRequest request, CancellationToken ct = default)
    {
        var client = _httpClientFactory.CreateClient(serviceName);
        var response = await client.PostAsJsonAsync(endpoint, request, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string serviceName, string endpoint, TRequest request, CancellationToken ct = default)
    {
        var client = _httpClientFactory.CreateClient(serviceName);
        var response = await client.PostAsJsonAsync(endpoint, request, ct);
        response.EnsureSuccessStatusCode();

        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            return default;

        return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: ct);
    }
}
