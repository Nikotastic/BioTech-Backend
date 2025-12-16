
using Microsoft.AspNetCore.Http;
using System;

namespace CommercialService.Presentation.Services;

public interface IGatewayAuthenticationService
{
    int GetFarmId();
    int GetUserId();
}

public class GatewayAuthenticationService : IGatewayAuthenticationService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GatewayAuthenticationService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetFarmId()
    {
        if (_httpContextAccessor.HttpContext?.Request.Headers.TryGetValue("X-Farm-Id", out var farmIdHeader) == true)
        {
            if (int.TryParse(farmIdHeader, out var farmId))
                return farmId;
        }

        throw new UnauthorizedAccessException("Farm context missing");
    }

    public int GetUserId()
    {
        if (_httpContextAccessor.HttpContext?.Request.Headers.TryGetValue("X-User-Id", out var userIdHeader) == true)
        {
            if (int.TryParse(userIdHeader, out var userId))
                return userId;
        }

        // Return 0 or throw if strict user context is required everywhere
        return 0; 
    }
}
