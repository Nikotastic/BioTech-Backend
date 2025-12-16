using System.Threading;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Interfaces;

public interface IMessenger
{
    Task<TResponse?> GetAsync<TResponse>(string serviceName, string endpoint, CancellationToken ct = default);
    Task PostAsync<TRequest>(string serviceName, string endpoint, TRequest request, CancellationToken ct = default);
    Task<TResponse?> PostAsync<TRequest, TResponse>(string serviceName, string endpoint, TRequest request, CancellationToken ct = default);
}
